using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CampusCourier.Models;
using CampusCourier.Logic;
using System.Data.Entity;
using System.Configuration;
using System.Data.SqlClient;

namespace CampusCourier.Checkout
{
    public partial class CheckoutReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NVPAPICaller payPalCaller = new NVPAPICaller();

                string retMsg = "";
                string token = "";
                string PayerID = "";
                NVPCodec decoder = new NVPCodec();
                token = Session["token"].ToString();

                bool ret = payPalCaller.GetCheckoutDetails(token, ref PayerID, ref decoder, ref retMsg);
                if (ret)
                {
                    Session["payerId"] = PayerID;

                    var myOrder = new Orders();
         
                    myOrder.Username = User.Identity.Name;
                    myOrder.Total = Convert.ToDecimal(decoder["AMT"].ToString());

                    // Verify total payment amount as set on CheckoutStart.aspx.
                    try
                    {
                        decimal paymentAmountOnCheckout = Convert.ToDecimal(Session["payment_amt"].ToString());
                        decimal paymentAmoutFromPayPal = Convert.ToDecimal(decoder["AMT"].ToString());
                        if (paymentAmountOnCheckout != paymentAmoutFromPayPal)
                        {
                            Response.Redirect("CheckoutError.aspx?" + "Desc=Amount%20total%20mismatch.");
                        }
                    }
                    catch (Exception)
                    {
                        Response.Redirect("CheckoutError.aspx?" + "Desc=Amount%20total%20mismatch.");
                    }

                    // Get DB context.
                    ProductContext _db = new ProductContext();

                    // Add order to DB.
                    _db.Orders.Add(myOrder);
                    _db.SaveChanges();

                    // Get the shopping cart items and process them.
                    using (CampusCourier.Logic.ShoppingCartActions usersShoppingCart = new CampusCourier.Logic.ShoppingCartActions())
                    {
                        List<CartItem> myOrderList = usersShoppingCart.GetCartItems();

                        // Add OrderDetail information to the DB for each product purchased.
                        for (int i = 0; i < myOrderList.Count; i++)
                        {
                            // Create a new OrderDetail object.
                            var myOrderDetail = new OrderDetail();
                            myOrderDetail.OrderId = myOrder.OrderId;
                            myOrderDetail.CustName = User.Identity.Name;
                            myOrderDetail.ProductId = myOrderList[i].ProductId;
                            myOrderDetail.Quantity = myOrderList[i].Quantity;
                            myOrderDetail.UnitPrice = myOrderList[i].Product.UnitPrice;

                            // Add OrderDetail to DB.
                            _db.OrderDetails.Add(myOrderDetail);
                            _db.SaveChanges();
                        }
                        

                        // Set OrderId. Remove this if it wont work
                        Session["currentOrderId"] = myOrder.OrderId;

                        //Adding data to orders

                        List<CartItem> ordersdatalist = usersShoppingCart.GetCartItems();
                        for (int i = 0; i < ordersdatalist.Count; i++)
                        {
                            var ordersdata = new Orders();
                            ordersdata.OrderId = myOrder.OrderId;
                            ordersdata.Quantity = ordersdatalist[i].Quantity;
                            int productid = ordersdatalist[i].ProductId;
                            ordersdata.RestName = ordersdatalist[i].Product.Restaurant.RestaurantName;

                            int location = Convert.ToInt32(ordersdatalist[i].Product.RestaurantID);

                            string Query = "SELECT LocationName from Locations WHERE LocationID ='" + location + "'";
                            string connectionstring = ConfigurationManager.ConnectionStrings["CampusCourier"].ConnectionString;
                            SqlConnection conn = new SqlConnection(connectionstring);
                            SqlCommand comm = new SqlCommand(Query, conn);
                            conn.Open();
                            SqlDataReader nwReader = comm.ExecuteReader();
                               
                                while (nwReader.Read())
                                {
                                    ordersdata.Location = (string)nwReader["LocationName"];
                                  
                                }
                                nwReader.Close();
                                conn.Close();
                          
                                ordersdata.Total = Convert.ToDecimal(ordersdatalist[i].Product.UnitPrice);
                                ordersdata.Status = "Waiting For Delivery";
                                _db.Orders.Add(ordersdata);
                                _db.SaveChanges();
                            }

                        // Display Order information.
                        List<Orders> orderList = new List<Orders>();
                        orderList.Add(myOrder);
                        ShipInfo.DataSource = orderList;
                        ShipInfo.DataBind();

                        // Display OrderDetails.
                        OrderItemList.DataSource = myOrderList;
                        OrderItemList.DataBind();
                        Session["userCheckoutCompleted"] = "true";
                        Response.Redirect("~/Checkout/CheckoutComplete.aspx");
                    }
                }
                else
                {
                    Response.Redirect("CheckoutError.aspx?" + retMsg);
                }
            }
        }

      
    }
}

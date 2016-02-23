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

namespace CampusCourier

{

    public partial class Orderspage : System.Web.UI.Page

    {

        protected void Page_Load(object sender, EventArgs e)

        {

            //  ordersGrid_GetData();

        }

        public IQueryable<Orders> ordersGrid_GetData()

        {

            var _db = new CampusCourier.Models.ProductContext();

            IQueryable<Orders> query = _db.Orders;

            //  ProductContext db = new ProductContext();

            //   var query = db.Orders.Include(s => s.OrderDetails.Select(e => e.OrderId));

            query = _db.Orders.Include(s => s.CC_orderdetail);

            //if(_db.Orde Contains(X => ""))

            //{




            //}

            return query;

        }

        protected Boolean IsWaitForDelivery(String status)

        {

            if (status == "Waiting for Delivery")

                return true;

            else

                return false;

        }

        protected Boolean IsAccept(String status)

        {

            if (status == "Reserved")

                return true;

            else

                return false;

        }




        protected void ordersGrid_SelectedIndexChanged(object sender, EventArgs e)

        {




        }




        protected void ordersGrid_RowCommand(object sender, GridViewCommandEventArgs e)

        {

            int autoId = Convert.ToInt32(e.CommandArgument);

            string text = e.CommandSource.ToString();

            autoId = autoId + 1;

            string connectionstring = ConfigurationManager.ConnectionStrings["CampusCourier"].ConnectionString;

            string UserId = System.Web.HttpContext.Current.User.Identity.Name;

            using (SqlConnection conn = new SqlConnection(connectionstring))




            {

                string Query = "UPDATE Orders SET Status = 'Reserved' , CourierEmail = '" + UserId + "' WHERE OrderId ='" + autoId + "'";

                conn.Close();

                conn.Open();

                using (SqlCommand comm = new SqlCommand(Query, conn))

                {

                    SqlDataAdapter da = new SqlDataAdapter(comm);

                    comm.ExecuteNonQuery();

                    conn.Close();

                    ordersGrid.DataBind();

                }

            }

        }




        protected void ordersGrid_UpdateIndexChanged(object sender, GridViewUpdateEventArgs e)

        {

            var autoId = ordersGrid.DataKeys[e.RowIndex].Value;

            string connectionstring = ConfigurationManager.ConnectionStrings["CampusCourier"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionstring))




            {

                string Query = "UPDATE Orders SET Status = 'On the way' WHERE OrderId ='" + autoId + "'";

                conn.Close();

                conn.Open();

                using (SqlCommand comm = new SqlCommand(Query, conn))

                {

                    SqlDataAdapter da = new SqlDataAdapter(comm);

                    comm.ExecuteNonQuery();

                    conn.Close();

                    ordersGrid.DataBind();

                }

            }

        }

        protected void Orders_Selecting(object sender, LinqDataSourceSelectEventArgs e)

        {




        }

    }
}


       
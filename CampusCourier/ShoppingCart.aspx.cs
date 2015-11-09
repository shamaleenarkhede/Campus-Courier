using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CampusCourier.Models;
using CampusCourier.Logic;

namespace CampusCourier
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        decimal cartTotal = 0;
        decimal cartTotaltip = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtaddtip.Visible = false;
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
               
                cartTotal = usersShoppingCart.GetTotal();
                if (cartTotal > 0)
                {
                    // Display Total.
                    lblTotal.Text = String.Format("{0:c}", cartTotal);
                }
                else
                {
                    LabelTotalText.Text = "";
                    lblTotal.Text = "";
                    ShoppingCartTitle.InnerText = "Shopping Cart is Empty";
                    CheckoutImageBtn.Visible = false;
                }
            }
        }

        public List<CartItem> GetShoppingCartItems()
        {
            ShoppingCartActions actions = new ShoppingCartActions();
            return actions.GetCartItems();
        }

        protected void CheckoutBtn_Click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToString(Session["tipchecked"]) == "true")
            {
               // Session["payment_amt"] = cartTotaltip;
                Response.Redirect("Checkout/CheckoutStart.aspx");
            }
            else
            {
                using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
                {
                   // Session["payment_amt"] = usersShoppingCart.GetTotal();
                     Session["payment_amt"] = cartTotal;
                }
            }
            Response.Redirect("Checkout/CheckoutStart.aspx");

        }

        protected void chkaddtip_CheckedChanged(object sender, EventArgs e)
        {
           
            if (chkaddtip.Checked == true)
            {
                txtaddtip.Visible = true;
               
            }
        }

        protected void txtaddtip_TextChanged(object sender, EventArgs e)
        {
            decimal tip = decimal.Parse(txtaddtip.Text);
            cartTotaltip = cartTotal + tip;
            lblTotal.Text = String.Format("{0:c}", cartTotaltip);
            Session["payment_amt"] = cartTotaltip;
            Session["tipchecked"] = "true";
        }
    }
}
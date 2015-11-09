using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CampusCourier.Models;
using CampusCourier.Logic;
using System.Data.Entity;

namespace CampusCourier
{
    public partial class Orderspage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }
        public IQueryable<Orders> ordersGrid_GetData()
        {
            var _db = new CampusCourier.Models.ProductContext();
            IQueryable<Orders> query = _db.Orders;
          
            query = _db.Orders.Include(s => s.CC_orderdetail);
            return query;
        }

       


    }



}
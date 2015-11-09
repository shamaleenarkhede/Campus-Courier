using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CampusCourier.Models;
namespace CampusCourier.Logic
{
    public class OrdersController : Controller
    {


        // GET: Orders


        public ActionResult Index()

        {

            Orderdetails _objOrdermodel = new Orderdetails();

            List<Orders> _objOrders = new List<Orders>();

            _objOrders = GetOrders();


            _objOrdermodel.Ordermodel = _objOrders;

            return View(_objOrdermodel);

        }

        public List<Orders> GetOrders()

        {

            List<Orders> objOrders = new List<Orders>();

            /*Create instance of entity model*/

             
            

            /*Getting data from database for user validation*/

            var _objordersdetail = (from data in objOrders

                                  select data);

            foreach (var item in _objordersdetail)

            {

                objOrders.Add(new Orders { OrderId = item.Id, RestName = item.Name, Section = item.Section, Class = item.Class, Address = item.Address });

            }

            return objOrders;

            objOrders;
        }
    }
}
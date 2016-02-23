using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CampusCourier.Models
{

    public class Orderdetails

    {

        public List<Orders> Ordermodel { get; set; }

    }

    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        //   public System.DateTime OrderTime { get; set; }
      // public System.DateTime OrderDate { get; set; }

        public string RestName { get; set; }
        public string Location { get; set; }
        public string CustName { get; set; }
        public string Destination { get; set; }
        public string Status { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public virtual ICollection<OrderDetail> CC_orderdetail { get; set; }

        public string Username { get; set; }

        public int Quantity { get; set; }

        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        [ScaffoldColumn(false)]
        public string PaymentTransactionId { get; set; }

        [ScaffoldColumn(false)]
        public bool HasBeenShipped { get; set; }

        public string CourierEmail { get; set; }






    }
}
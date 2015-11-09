using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusCourier.Models
{
    public class Restaurant
    {
        [ScaffoldColumn(false)]
        public int RestaurantID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string RestaurantName { get; set; }

        [Display(Name = "Product Description")]
        public string Description { get; set; }
        
        public int LocationID { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusCourier.Models
{
    public class Location
    {
        [ScaffoldColumn(false)]
        public int LocationID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string LocationName { get; set; }

        [Display(Name = "Product Description")]
        public string Description { get; set; }

        public virtual ICollection<Product> Restaurants { get; set; }
    }
}
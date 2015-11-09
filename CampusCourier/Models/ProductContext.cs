using System.Data.Entity;

namespace CampusCourier.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("CampusCourier")
        {
        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
      //  public DbSet<Orders> Orders { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
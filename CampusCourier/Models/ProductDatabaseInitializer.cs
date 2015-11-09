using System.Collections.Generic;
using System.Data.Entity;

namespace CampusCourier.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        //public override void InitializeDatabase(ProductContext context)
        //{
        //    context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
        //        , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

        //    base.InitializeDatabase(context);
        //}


        protected override void Seed(ProductContext context)
        {
            GetLocations().ForEach(l => context.Locations.Add(l));
            GetRestaurants().ForEach(r => context.Restaurants.Add(r));
            GetProducts().ForEach(p => context.Products.Add(p));
            GetOrders().ForEach(o => context.Orders.Add(o));
            base.Seed(context);
        }

        private static List<Location> GetLocations()
        {
            var locations = new List<Location>
            {
                new Location
                {
                    LocationID = 1,
                    LocationName = "Prospector"
                },
                new Location
                {
                    LocationID = 2,
                    LocationName = "Student Union"
                },
                new Location
                {
                    LocationID = 3,
                    LocationName = "Cone Center Main Street Market"
                }
            };
            return locations;
        }

        private static List<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    RestaurantID = 101,
                    RestaurantName = "Wendy's",
                    LocationID = 1,
                },
                new Restaurant
                {
                    RestaurantID = 102,
                    RestaurantName = "Bojangles'",
                    LocationID = 1,
                },
                new Restaurant
                {
                    RestaurantID = 201,
                    RestaurantName = "Chick-fil-A Express",
                    LocationID = 2,
                },
                new Restaurant
                {
                    RestaurantID = 301,
                    RestaurantName = "Panda Express",
                    LocationID = 3,
                },
                new Restaurant
                {
                    RestaurantID = 202,
                    RestaurantName = "Feisty's",
                    LocationID = 2,
                },
            };
            return restaurants;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product
                { //Wendy's (101) 10-piece Nugget
                    ProductID = 10101,
                    ProductName = "10-piece Nugget",
                    Description = "placeholder descrip",
                    ImagePath = "10101.jpg",
                    UnitPrice = 5.00,
                    RestaurantID = 101,
                },
                new Product
                { //Wendy's (101) 1/2 lb Double
                    ProductID = 10102,
                    ProductName = "1/2 lb Double",
                    Description = "placeholder descrip",
                    ImagePath = "10102.jpg",
                    UnitPrice = 5.00,
                    RestaurantID = 101,
                },
                new Product
                { //Wendy's (101) 1/4 lb Single
                    ProductID = 10103,
                    ProductName = "1/4 lb Single",
                    Description = "placeholder descrip",
                    ImagePath = "10103.jpg",
                    UnitPrice = 2.99,
                    RestaurantID = 101,
                },
                new Product
                { //Wendy's (101) Baconator
                    ProductID = 10101,
                    ProductName = "Baconator",
                    Description = "placeholder descrip",
                    ImagePath = "10104.jpg",
                    UnitPrice = 6.79,
                    RestaurantID = 101,
                },
                new Product
                { //Wendy's (101) Crispy Chicken Sandwich
                    ProductID = 10101,
                    ProductName = "Crispy Chicken Sandwich",
                    Description = "placeholder descrip",
                    ImagePath = "10105.jpg",
                    UnitPrice = 5.00,
                    RestaurantID = 101,
                }, //Wendy's menu
                new Product
                { //Bojangles' (102) Bacon, Egg, and Cheese Biscuit
                    ProductID = 10201,
                    ProductName = "Bacon, Egg, and Cheese Biscuit",
                    Description = "placeholder descrip",
                    ImagePath = "10201.jpg",
                    UnitPrice = 2.99,
                    RestaurantID = 102,
                },
                new Product
                { //Bojangles' (102) Cajun Filet Biscuit
                    ProductID = 10202,
                    ProductName = "Cajun Filet Biscuit",
                    Description = "placeholder descrip",
                    ImagePath = "10202.jpg",
                    UnitPrice = 3.99,
                    RestaurantID = 102,
                },
                new Product
                { //Bojangles' (102) 12-piece Supremes Box
                    ProductID = 10203,
                    ProductName = "12-piece Supremes Box",
                    Description = "placeholder descrip",
                    ImagePath = "10203.jpg",
                    UnitPrice = 7.99,
                    RestaurantID = 102,
                },
                new Product
                { //Bojangles' (102) Grilled Chicken Sandwich
                    ProductID = 10204,
                    ProductName = "Grilled Chicken Sandwich",
                    Description = "placeholder descrip",
                    ImagePath = "10204.jpg",
                    UnitPrice = 3.99,
                    RestaurantID = 102,
                },
                new Product
                { //Bojangles' (102) Chicken Supreme Salad
                    ProductID = 10205,
                    ProductName = "Chicken Supreme Salad",
                    Description = "placeholder descrip",
                    ImagePath = "10205.jpg",
                    UnitPrice = 6.99,
                    RestaurantID = 102,
                }, //Bojangles' menu
                new Product
                { //Chick-fil-A Express (201) Chicken Biscuit
                    ProductID = 20101,
                    ProductName = "Chicken Biscuit",
                    Description = "placeholder descrip",
                    ImagePath = "20101.jpg",
                    UnitPrice = 3.49,
                    RestaurantID = 201,
                },
                new Product
                { //Chick-fil-A Express (201) Chicken Sandwich
                    ProductID = 20102,
                    ProductName = "Chicken Sandwich",
                    Description = "placeholder descrip",
                    ImagePath = "20102.jpg",
                    UnitPrice = 4.49,
                    RestaurantID = 201,
                },
                new Product
                { //Chick-fil-A Express (201) Chocolate Milkshake
                    ProductID = 20103,
                    ProductName = "Chocolate Milkshake",
                    Description = "placeholder descrip",
                    ImagePath = "20103.jpg",
                    UnitPrice = 2.49,
                    RestaurantID = 201,
                }, //Chick-fil-A Express menu
                new Product
                { //Feisty's (202) Feisty American
                    ProductID = 20201,
                    ProductName = "Feisty American",
                    Description = "placeholder descrip",
                    ImagePath = "20201.jpg",
                    UnitPrice = 3.05,
                    RestaurantID = 202,
                },
                new Product
                { //Feisty's (202) Big Apple Feisty
                    ProductID = 20202,
                    ProductName = "Big Apple Feisty",
                    Description = "placeholder descrip",
                    ImagePath = "20202.jpg",
                    UnitPrice = 3.05,
                    RestaurantID = 202,
                },
                new Product
                { //Feisty's (202) Cackalacky Feisty
                    ProductID = 20203,
                    ProductName = "Cackalacky Feisty",
                    Description = "placeholder descrip",
                    ImagePath = "20203.jpg",
                    UnitPrice = 3.05,
                    RestaurantID = 202,
                },
                new Product
                { //Feisty's (202) Windy City Feisty
                    ProductID = 20204,
                    ProductName = "Windy City Feisty",
                    Description = "placeholder descrip",
                    ImagePath = "20204.jpg",
                    UnitPrice = 3.59,
                    RestaurantID = 202,
                },
                new Product
                { //Feisty's (202) South Philly Feisty
                    ProductID = 20205,
                    ProductName = "South Philly Feisty",
                    Description = "placeholder descrip",
                    ImagePath = "20205.jpg",
                    UnitPrice = 3.79,
                    RestaurantID = 202,
                }, //Feisty's menu
                new Product
                { //Panda Express (301) Orange Chicken
                    ProductID = 30101,
                    ProductName = "Orange Chicken",
                    Description = "placeholder descrip",
                    ImagePath = "30101.jpg",
                    UnitPrice = 5.99,
                    RestaurantID = 301,
                },
                new Product
                { //Panda Express (301) Honey Walnut Shrimp
                    ProductID = 30102,
                    ProductName = "Honey Walnut Shrimp",
                    Description = "placeholder descrip",
                    ImagePath = "30102.jpg",
                    UnitPrice = 7.99,
                    RestaurantID = 301,
                },
                new Product
                { //Panda Express (301) Beijing Beef
                    ProductID = 30103,
                    ProductName = "Beijing Beef",
                    Description = "placeholder descrip",
                    ImagePath = "30103.jpg",
                    UnitPrice = 5.99,
                    RestaurantID = 301,
                },
                new Product
                { //Panda Express (301) Sweetfire Chicken Breast
                    ProductID = 30104,
                    ProductName = "Beijing Beef",
                    Description = "placeholder descrip",
                    ImagePath = "30104.jpg",
                    UnitPrice = 5.99,
                    RestaurantID = 301,
                },
                new Product
                { //Panda Express (301) Sweet and Sour Pork
                    ProductID = 30105,
                    ProductName = "Sweet and Sour Pork",
                    Description = "placeholder descrip",
                    ImagePath = "30105.jpg",
                    UnitPrice = 5.99,
                    RestaurantID = 301,
                }, //Panda Express menu
            };
            return products;
        }

        private static List<Orders> GetOrders()
        {
            var orders = new List<Orders>
            {
                new Orders
                {
                 OrderId = 1,
               //OrderTime = 2015-10-24,
                 RestName = "Wendy's",
                 Location = "Student Union",
                 CustName = "Pranjal Patil",
                 Destination = "EPIC",
                 Status = "Waiting for Delivery"
                // DateCreated = "2015-10-28";
                 
                },

                 new Orders
                {
                 OrderId = 2,
               //OrderTime = 2015-10-24,
                 RestName = "Wendy's",
                 Location = "Student Union",
                 CustName = "Sloan",
                 Destination = "Fretwell",
                 Status = "On the way"
                // DateCreated = "2015-10-28";
                 
                },

                  new Orders
                {
                 OrderId = 3,
               //OrderTime = 2015-10-24,
                 RestName = "Bojangles",
                 Location = "Student Union",
                 CustName = "Jim",
                 Destination = "Duke",
                 Status = "Delivered"
                // DateCreated = "2015-10-28";
                 
                },

                   new Orders
                {
                 OrderId = 4,
               //OrderTime = 2015-10-24,
                 RestName = "Chick-fil-a",
                 Location = "Prospector",
                 CustName = "Bhavya",
                 Destination = "Woodward",
                 Status = "Waiting for Delivery"
                // DateCreated = "2015-10-28";
                 
                },

                    new Orders
                {
                 OrderId = 5,
               //OrderTime = 2015-10-24,
                 RestName = "Panda Express",
                 Location = "Cone Center Main Street Market",
                 CustName = "Shamalee",
                 Destination = "Bioinformatics",
                 Status = "On the way"
                // DateCreated = "2015-10-28";
                 
                },

                     new Orders
                {
                 OrderId = 6,
               //OrderTime = 2015-10-24,
                 RestName = "Wendy's",
                 Location = "Student Union",
                 CustName = "Martin",
                 Destination = "Grigg Hall",
                 Status = "Waiting for Delivery"
                // DateCreated = "2015-10-28";
                 
                },
            };
            return orders;
            }
    }
}
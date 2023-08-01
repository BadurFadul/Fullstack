using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;

namespace backend.Controllers
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
         public double Price { get; set; }
         public int StockQuantity { get; set; }
         public string Description { get; set; }
         public string[] Images { get; set; }
         public Category category { get; set; }
         public List<OrderDetail> orderDetails { get; set; }
         public List<Review> reviews { get; set; } 
         public List<CartItem> cartItems {get; set;} 
         
    }
}
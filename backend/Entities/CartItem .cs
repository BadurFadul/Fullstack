using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers;

namespace backend.Entities
{
    public class CartItem: BaseEntity 
    {
        public int Quantity { get; set; }
        public Product product { get; set; }
        public ShoppingCart shoppingCart { get; set; }
    }
}
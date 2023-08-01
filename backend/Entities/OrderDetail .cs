using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers;

namespace backend.Entities
{
    public class OrderDetail: BaseEntity 
    {
        public int Quantity { get; set; }
        public double Price {get; set;}
        public Order order { get; set; }
        public Product product { get; set; }
         
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public class OrderDetail: BaseEntity 
    {
        public int Quantity { get; set; }
        public double Price {get; set;}
         
    }
}
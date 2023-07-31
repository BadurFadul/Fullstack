using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public class CartItem: BaseEntity 
    {
        public int Quantity { get; set; }
    }
}
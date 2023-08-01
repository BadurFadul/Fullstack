using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public class Payment: BaseEntity 
    {
         public string PaymentMethod { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public User user { get; set; }
        public Order order { get; set; }
    }
}
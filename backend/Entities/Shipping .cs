using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public class Shipping: BaseEntity 
    {
         public string ShippingMethod { get; set; }
        public double ShippingCost { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public Order order { get; set; }
    }
}
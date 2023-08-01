using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public class Order: BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public double TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public User user { get; set; }
        public List<OrderDetail> Details { get; set; }
        public List<Payment> Payment { get; set; }
        public Shipping shipping { get; set; }
    }
}
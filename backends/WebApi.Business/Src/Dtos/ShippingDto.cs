using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Business.Src.Dtos
{
    public class ShippingReadDto
    {
        public Guid Id { get; set; }
        public string ShippingMethod { get; set; }
        public double ShippingCost { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public OrderReadDto order { get; set; }
    }
    public class ShippingCreateDto
    {
        public string ShippingMethod { get; set; }
        public double ShippingCost { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; } = DateTime.Now.AddDays(7);
        public Guid OrderId { get; set; }
    }
    public class ShippingUpdateDto
    {
        public string ShippingMethod { get; set; }
        public double ShippingCost { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        
    }
}
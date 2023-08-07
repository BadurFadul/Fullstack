using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Business.Src.Dtos
{
    public class ShippingDto
    {
        public string ShippingMethod { get; set; }
        public double ShippingCost { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
    }
}
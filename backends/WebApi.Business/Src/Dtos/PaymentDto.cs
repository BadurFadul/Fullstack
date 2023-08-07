using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Business.Src.Dtos
{
    public class PaymentDto
    {
        public string PaymentMethod { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
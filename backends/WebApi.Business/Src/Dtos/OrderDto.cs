using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Src.Entities;

namespace WebApi.Business.Src.Dtos
{
    public class OrderReadDto
    {
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
    public class OrderCreateDto
    {
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
    public class OrderUpdateDto
    {
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Src.Entities;

namespace WebApi.Business.Src.Dtos
{
    public class OrderReadDto
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public UserReadDto user { get; set; }
        // public List<OrderDetailReadDto> Details { get; set; }
        // public List<PaymentReadDto> Payments { get; set; }
        public ShippingReadDto shipping { get; set; }
    }
    public class OrderCreateDto
    {
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string OrderStatus { get; set; }
        public Guid UserId { get; set; }
        public Guid ShippingId { get; set; }
    }
    public class OrderUpdateDto
    {
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public string OrderStatus { get; set; }
    }
}
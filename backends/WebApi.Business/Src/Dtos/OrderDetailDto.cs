using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Business.Src.Dtos
{
    public class OrderDetailReadDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public OrderReadDto Order { get; set; }
        // public ProductReadDto Product { get; set; }
        
    }
    public class OrderDetailCreateDto
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid OrderId { get; set; }
        
        // public Guid ProductId { get; set; }
    }
    public class OrderDetailUpdateDto
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
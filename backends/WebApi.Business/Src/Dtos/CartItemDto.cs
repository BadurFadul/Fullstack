using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Src.Entities;

namespace WebApi.Business.Src.Dtos
{
    public class CartItemReadDto
    {
        public int Quantity { get; set; }
        public ProductReadDto Product { get; set; }
    }
    public class CartItemCreateDto
    {
        public int Quantity { get; set; }
    }
    public class CartItemUpdateDto
    {
        public int Quantity { get; set; }
    }
}
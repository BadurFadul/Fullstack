using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Business.Src.Dtos
{
    public class ShoppingCartReadDto
    {
         public List<CartItemReadDto> CartItems { get; set; }
    }
    public class ShoppingCartCreateDto
    {
        public List<CartItemReadDto> CartItems { get; set; }
    }
    public class ShoppingCartUpdateDto
    {
        public List<CartItemReadDto> CartItems { get; set; }
    }
}
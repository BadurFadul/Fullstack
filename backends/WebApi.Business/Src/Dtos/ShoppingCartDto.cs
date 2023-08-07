using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Business.Src.Dtos
{
    public class ShoppingCartDto
    {
         public List<CartItemDto> CartItems { get; set; }
    }
}
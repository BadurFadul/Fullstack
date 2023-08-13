using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;
using WebApi.WebApi.Database;

namespace WebApi.WebApi.Repositores
{
    public class CartItemRepo : BaseRepo<CartItem>, ICartItemRepo
    {
        public CartItemRepo(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
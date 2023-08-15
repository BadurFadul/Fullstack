using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;
using WebApi.WebApi.Database;

namespace WebApi.WebApi.Repositores
{
    public class ShoppingCartRepo : BaseRepo<ShoppingCart>, IShoppingCartRepo
    {
        private readonly DbSet<ShoppingCart> _shoppingCarts;
        private readonly DatabaseContext _context;
        public ShoppingCartRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _shoppingCarts = dbContext.ShoppingCarts;
            _context = dbContext;
        }
    }
}
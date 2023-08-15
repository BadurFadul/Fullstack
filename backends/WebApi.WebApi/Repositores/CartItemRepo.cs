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
    public class CartItemRepo : BaseRepo<CartItem>, ICartItemRepo
    {
        private readonly DbSet<CartItem> _CartItems;
        private readonly DatabaseContext _context;
        public CartItemRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _CartItems = dbContext.CartItems;
            _context = dbContext;
        }
    }
}
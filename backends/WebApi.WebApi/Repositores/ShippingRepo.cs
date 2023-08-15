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
    public class ShippingRepo : BaseRepo<Shipping>, IShippingRepo
    {
        private readonly DbSet<Shipping> _shipping;
        private readonly DatabaseContext _context;
        public ShippingRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _shipping = dbContext.Shippings;
            _context=dbContext;
        }
    }
}
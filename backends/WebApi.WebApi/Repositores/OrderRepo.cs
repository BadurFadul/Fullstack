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
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {
        private readonly DbSet<Order> _orders;
        private readonly DatabaseContext _context;
        public OrderRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _orders = dbContext.Orders;
            _context = dbContext;
        }
    }
}
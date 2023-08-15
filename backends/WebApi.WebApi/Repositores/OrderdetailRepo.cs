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
    public class OrderdetailRepo : BaseRepo<OrderDetail>, IOrderdetailRepo
    {
        private readonly DbSet<OrderDetail> _orderdetail;
        private readonly DatabaseContext databaseContext;
        public OrderdetailRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _orderdetail = dbContext.OrderDetails;
            databaseContext = dbContext;
        }
    }
}
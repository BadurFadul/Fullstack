using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;
using WebApi.WebApi.Database;

namespace WebApi.WebApi.Repositores
{
    public class OrderdetailRepo : BaseRepo<OrderDetail>, IOrderdetailRepo
    {
        public OrderdetailRepo(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
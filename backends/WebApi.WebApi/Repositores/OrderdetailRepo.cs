using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Src.Entities;
using WebApi.WebApi.Database;

namespace WebApi.WebApi.Repositores
{
    public class OrderdetailRepo : BaseRepo<OrderDetail>
    {
        public OrderdetailRepo(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
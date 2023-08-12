using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Src.Entities;
using WebApi.WebApi.Database;

namespace WebApi.WebApi.Repositores
{
    public class ProductRepo : BaseRepo<Product>
    {
        public ProductRepo(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
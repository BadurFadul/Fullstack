using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Src.Entities;
using WebApi.WebApi.Database;

namespace WebApi.WebApi.Repositores
{
    public class CategoryRepo : BaseRepo<Category>
    {
        public CategoryRepo(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
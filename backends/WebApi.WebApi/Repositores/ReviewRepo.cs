using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Src.Entities;
using WebApi.WebApi.Database;

namespace WebApi.WebApi.Repositores
{
    public class ReviewRepo : BaseRepo<Review>
    {
        public ReviewRepo(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
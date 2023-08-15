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
    public class ReviewRepo : BaseRepo<Review>, IReviewRepo
    {
        private readonly DbSet<Review> _review;
        private readonly DatabaseContext _context;
        public ReviewRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _review = dbContext.Reviews;
            _context = dbContext;
        }
    }
}
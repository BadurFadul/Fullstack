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
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        private readonly DbSet<Category> _categories;
        private readonly DatabaseContext _context;
        public CategoryRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _categories = dbContext.Categorys;
            _context = dbContext;
        }
    }
}
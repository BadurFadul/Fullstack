using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;
using WebApi.Domain.Src.Shared;
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

        public override async Task<IEnumerable<Category>> GetAll(Options queryOptions)
        {
            // IQueryable<T> query = _dbSet;

            // if (_context.Users == null)
            // {
            //     throw new Exception("Users not found");
            // }
            // //Apply searching if needed
            // if(!string.IsNullOrEmpty(queryOptions.searching))
            // {
            //     query = query.Where(n => EF.Property<string>(n, "Name").Contains(queryOptions.searching));
            // }
            // // Apply ordering
            // if(queryOptions.OrderByDescending)
            // {
            //     query = query.OrderByDescending(n => EF.Property<object>(n, queryOptions.OrderBy));
            // }else
            // {
            //     query = query.OrderBy(x => EF.Property<object>(x, queryOptions.OrderBy));
            // }
            // // Apply Pagination
            // if(queryOptions.PagNumber > 0)
            // {
            //     query = query.Skip((queryOptions.PagNumber - 1) * queryOptions.PerPage).Take(queryOptions.PerPage);
            // }
            return await _context.Categorys
            .Include(n => n.Products)
            .AsNoTracking()
            .ToListAsync();     
        }
    }
}
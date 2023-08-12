using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Shared;
using WebApi.WebApi.Database;

namespace WebApi.WebApi.Repositores
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly DatabaseContext _context;
        public BaseRepo(DatabaseContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
            _context = dbContext;
        }
        public async Task<bool> DeleteItem(T item)
        {
             if (item == null)
            {
                throw new Exception("Entity to delete not found");
            }
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAll(Options queryOptions)
        {
            IQueryable<T> query = _dbSet;

            if (_context.Users == null)
            {
                throw new Exception("Users not found");
            }
            //Apply searching if needed
            if(!string.IsNullOrEmpty(queryOptions.searching))
            {
                query = query.Where(n => EF.Property<string>(n, "Name").Contains(queryOptions.searching));
            }
            // Apply ordering
            if(queryOptions.OrderByDescending)
            {
                query = query.OrderByDescending(n => EF.Property<object>(n, queryOptions.OrderBy));
            }else
            {
                query = query.OrderBy(x => EF.Property<object>(x, queryOptions.OrderBy));
            }
            // Apply Pagination
            if(queryOptions.PagNumber > 0)
            {
                query = query.Skip((queryOptions.PagNumber - 1) * queryOptions.PerPage).Take(queryOptions.PerPage);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            var enrity = await _dbSet.FindAsync(id);
            if(enrity == null)
            {
                throw new Exception("Entity not found");
            }
            await _context.SaveChangesAsync();
            return enrity;
        }

        public async Task<T> postItem(T item)
        {
            if(item == null)
            {
                throw new Exception("Entity item is corapted");
            }
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> UpdateItem(string id, T item)
        {
            var enrity = await _dbSet.FindAsync(id);
            if(enrity == null)
            {
                throw new Exception("Entity not found");
            }
            _context.Entry(enrity).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return enrity;
        }
    }
}
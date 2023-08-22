using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;
using WebApi.Domain.Src.Shared;
using WebApi.WebApi.Database;

namespace WebApi.WebApi.Repositores
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        private readonly DbSet<User> _users;
        private readonly DatabaseContext _context;
        public UserRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _users = dbContext.Users;
            _context = dbContext;
        }

        public override async Task<IEnumerable<User>> GetAll(Options queryOptions)
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
            return await _users
            .Include(x => x.Orders)
            .Include(x => x.Reviews)
            .Include(x => x.payments)
            .Include(x =>x.shoppingCart)
            .AsNoTracking().
            ToListAsync();
            
        }

        public async Task<User> CreateAdmin(User user)
        {
            user.Role = Role.Admin;
            await _users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> FindOneByEmail(string email)
        {
            return await _users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> UpdatePassword(User user)
        {
             _users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

         public override async Task<User> postItem(User item)
         {
            item.Role = Role.Client;
            return await base.postItem(item);
         }
    }
}
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;
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

        public async Task<User> CreateAdmin(User user)
        {
            user.Role = Role.Admin;
            await _users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> FindOneByEmail(string email)
        {
            return await _users.FirstOrDefaultAsync(x => x.Email == email);
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
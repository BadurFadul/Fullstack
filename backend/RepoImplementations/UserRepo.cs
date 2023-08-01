using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Database;
using backend.Entities;
using backend.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.RepoImplementations
{
    public class UserRepo : IUserRepo
    {
        private readonly DbSet<User> _users;
        private readonly DatabaseContext _context;

        public UserRepo(DatabaseContext context)
        {
            _users = context.Users;
            _context = context;
        }
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _users.FindAsync(id);
            if(user == null)
            {
                return new NotFoundResult();
            }
            _users.Remove(user);
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            if(_context.Users == null)
            {
                return new NotFoundResult();
            }
            var users = await _users.ToListAsync();
            await _context.SaveChangesAsync();
            return users; 
            
        }

        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _users.FindAsync(id);
            if(user == null)
            {
                return new NotFoundResult();
            }
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<ActionResult<User>> PostUser(User user)
        {
            user.Role = Role.Client;
             _users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<ActionResult<User>> PutUser(Guid id, User user)
        {
             throw new NotImplementedException();
        }
    }
}
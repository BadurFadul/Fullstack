using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backend.Repositories
{
    public interface IUserRepo
    {
        Task<ActionResult<IEnumerable<User>>> GetAllUsers();
        Task<ActionResult<User>> GetUser(Guid id);
        Task<ActionResult<User>> PostUser(User user);
        Task<ActionResult<User>> PutUser(Guid id, User user);
        Task<IActionResult> DeleteUser(Guid id);

    }
}
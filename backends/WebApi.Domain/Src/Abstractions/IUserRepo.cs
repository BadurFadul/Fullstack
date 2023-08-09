using WebApi.Domain.Src.Entities;

namespace WebApi.Domain.Src.Abstractions
{
    public interface IUserRepo: IBaseRepo<User>
    {
        Task<User> CreateAdmin(User user);
        Task<User> UpdatePassword (User user, string password);
    }
}
using WebApi.Domain.Src.Entities;

namespace WebApi.Domain.Src.Abstractions
{
    public interface IUserRepo: IBaseRepo<User>
    {
         User CreateAdmin(User user);
         User UpdatePassword (User user, string password);
    }
}
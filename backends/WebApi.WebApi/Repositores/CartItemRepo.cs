using WebApi.Domain.Src.Entities;
using WebApi.WebApi.Database;

namespace WebApi.WebApi.Repositores
{
    public class CartItemRepo : BaseRepo<CartItem>
    {
        public CartItemRepo(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
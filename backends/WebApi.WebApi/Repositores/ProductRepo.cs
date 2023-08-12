using WebApi.Domain.Src.Entities;
using WebApi.WebApi.Database;

namespace WebApi.WebApi.Repositores
{
    public class ProductRepo : BaseRepo<Product>
    {
        public ProductRepo(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
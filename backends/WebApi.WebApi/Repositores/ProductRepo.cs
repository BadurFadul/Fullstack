using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;
using WebApi.WebApi.Database;

namespace WebApi.WebApi.Repositores
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        public ProductRepo(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;
using WebApi.WebApi.Database;

namespace WebApi.WebApi.Repositores
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        private readonly DbSet<Product> _products;
        private readonly DatabaseContext _context;
        public ProductRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _products = dbContext.Products;
            _context = dbContext;
        }
    }
}
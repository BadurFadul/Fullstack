using WebApi.Domain.Src.Entities;

namespace WebApi.Business.Src.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
         public double Price { get; set; }
         public string Description { get; set; }
         //public List<Image> Images { get; set; }
    }
}
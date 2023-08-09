using WebApi.Domain.Src.Entities;

namespace WebApi.Business.Src.Dtos
{
    public class ProductReadDto
    {
        public string Name { get; set; }
         public double Price { get; set; }
         public string Description { get; set; }
         public List<Image> Images { get; set; }
        public int StockQuantity { get; set; }
    }

     public class ProductCreateDto
    {
         public string Name { get; set; }
         public double Price { get; set; }
         public string Description { get; set; }
         public List<Image> Images { get; set; }
         public int StockQuantity { get; set; }
    }

    public class ProductUpdateDto
    {
         public string Name { get; set; }
         public double Price { get; set; }
         public string Description { get; set; }
         public List<Image> Images { get; set; }
         public int StockQuantity { get; set; }
    }

}
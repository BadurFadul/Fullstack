using WebApi.Domain.Src.Entities;

namespace WebApi.Business.Src.Dtos
{
    public class ProductReadDto
    {
        public Guid Id { get; set;}
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public List<Image> Images { get; set; }
        public int StockQuantity { get; set; }
        //public CategoryReadDto category { get; set; }
        //public List<ReviewReadDto> reviews { get; set; } 
        // public List<CartItemReadDto> cartItems {get; set;}
        // public List<OrderDetailReadDto> orderDetails { get; set; } 
    }

     public class ProductCreateDto
    {
         public string Name { get; set; }
         public double Price { get; set; }
         public string Description { get; set; }
         public List<Image> Images { get; set; }
         public int StockQuantity { get; set; }
         public Guid CategoryId { get; set; }
        // public Guid CategoryId { get; set; }
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
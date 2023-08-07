
namespace WebApi.Domain.Src.Entities
{
    public class Product: BaseWithId
    {
        public string Name { get; set; }
         public double Price { get; set; }
         public int StockQuantity { get; set; }
         public string Description { get; set; }
         public List<Image> Images { get; set; }
         public Category category { get; set; }
         public List<OrderDetail> orderDetails { get; set; }
         public List<Review> reviews { get; set; } 
         public List<CartItem> cartItems {get; set;} 
         
    }
}
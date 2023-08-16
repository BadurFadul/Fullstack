
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
         public Guid CategoryId { get; set; }
         public List<Review> Reviews { get; set; }
         public List<CartItem> cartItems {get; set;} 
        //  public List<OrderDetail> orderDetails { get; set; } 
         
    }
}
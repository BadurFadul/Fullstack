
namespace WebApi.Domain.Src.Entities
{
    public class CartItem: BaseWithId 
    {
        public int Quantity { get; set; }
        public Product product { get; set; }
        public ShoppingCart shoppingCart { get; set; }
    }
}
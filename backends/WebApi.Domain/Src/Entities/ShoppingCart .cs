
namespace WebApi.Domain.Src.Entities
{
    public class ShoppingCart: BaseWithId 
    {
        public int UserID { get; set; }
        public User user { get; set; }
        public List<CartItem> cartItems { get; set; }
    }
}
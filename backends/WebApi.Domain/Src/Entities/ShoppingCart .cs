
namespace WebApi.Domain.Src.Entities
{
    public class ShoppingCart: BaseWithId 
    {
        public List<CartItem> cartItems { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        
    }
}
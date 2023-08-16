
namespace WebApi.Domain.Src.Entities
{
    public class CartItem: BaseWithId 
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public ShoppingCart shoppingCart { get; set; }
        public Guid ShoppingCartId { get; set; }
    }
}
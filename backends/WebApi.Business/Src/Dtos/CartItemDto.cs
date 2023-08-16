
namespace WebApi.Business.Src.Dtos
{
    public class CartItemReadDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public ProductReadDto Product { get; set; }
        public ShoppingCartReadDto ShoppingCart { get; set; }
    }
    public class CartItemCreateDto
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid ShoppingCartId { get; set; }
    }
    public class CartItemUpdateDto
    {
        public int Quantity { get; set; }
    }
}
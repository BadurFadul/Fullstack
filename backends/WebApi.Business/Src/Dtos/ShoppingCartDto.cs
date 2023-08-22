
namespace WebApi.Business.Src.Dtos
{
    public class ShoppingCartReadDto
    {
        public Guid Id { get; set; }
        public List<CartItemReadDto> CartItems { get; set; }
        public UserReadDto user { get; set; }
    }
    public class ShoppingCartCreateDto
    {
        public Guid UserId { get; set; }
    }
    public class ShoppingCartUpdateDto
    {
        //public List<CartItemReadDto> CartItems { get; set; }
    }
}
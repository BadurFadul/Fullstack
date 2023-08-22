
using WebApi.Domain.Src.Entities;

namespace WebApi.Business.Src.Dtos
{
    public class UserReadDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Avatar { get; set; }
        public Role Role { get; set; }
        public List<OrderReadDto> Orders { get; set; }
        public List<ReviewReadDto> Reviews { get; set; }
        public List<PaymentReadDto> Payments { get; set; }
        public ShoppingCartReadDto shoppingCart { get; set; }
    }

    public class UserCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        //public ShoppingCartReadDto shoppingCart { get; set; }
    }

    public class UserUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
    }
    public class UserCredentialDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

namespace WebApi.Business.Src.Dtos
{
    public class PaymentReadDto
    {
        public Guid Id { get; set; }
        public string PaymentMethod { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public UserReadDto User { get; set; }
        public OrderReadDto Order { get; set; }
    }
    public class PaymentCreateDto
    {
         public string PaymentMethod { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public Guid UserId {get; set;}
        public Guid OrderId { get; set; }
    }
    public class PaymentUpdateDto
    {
        public string PaymentMethod { get; set; }
        public double PaymentAmount { get; set; }
    }
}
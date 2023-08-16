
namespace WebApi.Domain.Src.Entities
{
    public class Payment: BaseWithId 
    {
        public string PaymentMethod { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}
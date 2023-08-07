
namespace WebApi.Domain.Src.Entities
{
    public class Payment: BaseWithId 
    {
        public string PaymentMethod { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public User user { get; set; }
        public Order order { get; set; }
    }
}

namespace WebApi.Business.Src.Dtos
{
    public class PaymentReadDto
    {
        public string PaymentMethod { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
    public class PaymentCreateDto
    {
         public string PaymentMethod { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
    public class PaymentUpdateDto
    {
        public string PaymentMethod { get; set; }
        public double PaymentAmount { get; set; }
    }
}
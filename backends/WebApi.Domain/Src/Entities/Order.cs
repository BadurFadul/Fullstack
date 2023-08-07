
namespace WebApi.Domain.Src.Entities
{
    public class Order: BaseWithId
    {
        public DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public User user { get; set; }
        public List<OrderDetail> Details { get; set; }
        public List<Payment> Payment { get; set; }
        public Shipping shipping { get; set; }
    }

    public enum OrderStatus
    {
        received,
        Pending,
        shipped
    }
}
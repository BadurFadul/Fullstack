
namespace WebApi.Domain.Src.Entities
{
    public class Order: BaseWithId
    {
        public DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public double TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Payment> Payments { get; set; }
         public Shipping shipping { get; set; }
    }

    // [JsonConverter(typeof(JsonStringEnumConverter))]
    // public enum OrderStatus
    // {
    //     received,
    //     Pending,
    //     shipped
    // }
}

namespace WebApi.Domain.Src.Entities
{
    public class Shipping: BaseWithId 
    {
        public string ShippingMethod { get; set; }
        public double ShippingCost { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public Order order { get; set; }
    }
}
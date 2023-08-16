
namespace WebApi.Domain.Src.Entities
{
    public class OrderDetail: BaseWithId 
    {
        public int Quantity { get; set; }
        public double Price {get; set;}
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
        // public Product product { get; set; }
         
    }
}

namespace WebApi.Domain.Src.Entities
{
    public class Review: BaseWithId 
    {
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public User User {get; set;}
        public Guid UserId { get; set; }
        public Product Product {get; set;}
        public Guid ProductId {get; set;}     
    }
}
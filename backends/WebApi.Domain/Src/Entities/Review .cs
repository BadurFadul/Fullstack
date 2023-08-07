
namespace WebApi.Domain.Src.Entities
{
    public class Review: BaseWithId 
    {
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public User User {get; set;}
        public Product product {get; set;}     
    }
}
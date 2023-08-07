

namespace WebApi.Domain.Src.Entities
{
    public class Category: BaseWithId
    {
        public string name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}

namespace WebApi.Business.Src.Dtos
{
    public class CategoryReadDto
    {
        public Guid Id { get; set;}
        public string name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<ProductReadDto> Products { get; set; }
    }
    public class CategoryCreateDto
    {
        public string name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
    public class CategoryUpdateDto
    {
        public string name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
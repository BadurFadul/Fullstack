using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Business.Src.Dtos
{
    public class CategoryReadDto
    {
        public string name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
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
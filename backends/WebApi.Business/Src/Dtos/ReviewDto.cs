using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Business.Src.Dtos
{
    public class ReviewReadDto
    {
        public string ReviewText { get; set; }
        public int Rating { get; set; }
    }
    public class ReviewCreateDto
    {
        public string ReviewText { get; set; }
        public int Rating { get; set; }
    }
    public class ReviewUpdateDto
    {
        public string ReviewText { get; set; }
        public int Rating { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Business.Src.Dtos
{
    public class ReviewDto
    {
        public string ReviewText { get; set; }
        public int Rating { get; set; }
    }
}
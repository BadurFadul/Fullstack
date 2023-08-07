using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain.Src.Entities
{
    public class Image: BaseWithId
    {
        public string Link { get; set; }
    }
}
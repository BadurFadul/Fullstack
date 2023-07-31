using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public class Category: BaseEntity
    {
        public string name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
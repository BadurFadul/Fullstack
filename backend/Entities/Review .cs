using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public class Review: BaseEntity 
    {
        public string ReviewText { get; set; }
        public int Rating { get; set; }     
    }
}
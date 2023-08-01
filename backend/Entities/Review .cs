using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers;

namespace backend.Entities
{
    public class Review: BaseEntity 
    {
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public User User {get; set;}
        public Product product {get; set;}     
    }
}
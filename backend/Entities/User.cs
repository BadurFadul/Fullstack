using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public List<Order> orders { get; set; }
        public List<Review> reviews { get; set; }
        public List<Payment> payments { get; set; }
        public ShoppingCart shoppingCart { get; set; }
    }

    public enum Role {
        Admin,
        Client
    }

    
}
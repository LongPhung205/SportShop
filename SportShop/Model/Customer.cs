using System;
using System.Collections.Generic;

namespace SportShop.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int? LoyaltyPoints { get; set; }
        public DateTime? CreatedAt { get; set; }

        // Navigation Properties
        public List<Order> Orders { get; set; } = new List<Order>();

        public Customer() { }

        public Customer(int id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }
    }
}
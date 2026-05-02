using System;
using System.Collections.Generic;

namespace SportShop.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public decimal? HourlyRate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }

        // Navigation Properties
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<ImportOrder> ImportOrders { get; set; } = new List<ImportOrder>();
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();

        public User() { }

        public User(int id, string username, string fullName, string role)
        {
            Id = id;
            Username = username;
            FullName = fullName;
            Role = role;
        }
    }
}
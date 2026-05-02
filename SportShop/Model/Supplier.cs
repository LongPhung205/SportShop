using System;
using System.Collections.Generic;

namespace SportShop.Model
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }

        // Navigation
        public List<ImportOrder> ImportOrders { get; set; } = new List<ImportOrder>();

        public Supplier() { }
        public Supplier(int id, string name, string phone) { Id = id; Name = name; Phone = phone; }
    }
}
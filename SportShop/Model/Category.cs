using System;
using System.Collections.Generic;

namespace SportShop.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }

        // Navigation Properties
        public List<Product> Products { get; set; } = new List<Product>();

        public Category() { }

        public Category(int id, string categoryName)
        {
            Id = id;
            CategoryName = categoryName;
        }
    }
}
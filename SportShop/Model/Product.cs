using System;
using System.Collections.Generic;

namespace SportShop.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public string ImagePath { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Thuộc tính mở rộng dùng để hiển thị (Không map với DB)
        public string CategoryName { get; set; }

        // Navigation Properties
        public Category Category { get; set; }
        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();

        public Product() { }

        public Product(int id, string sku, string name, int categoryId, string description, decimal basePrice, string imagePath = null)
        {
            Id = id;
            SKU = sku;
            Name = name;
            CategoryId = categoryId;
            Description = description;
            BasePrice = basePrice;
            ImagePath = imagePath;
        }
    }
}
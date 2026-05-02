using System;

namespace SportShop.Model
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int Quantity { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public bool? IsActive { get; set; }

        // Thuộc tính mở rộng dùng để hiển thị (Không map với DB)
        public string ProductName { get; set; }
        public string SizeName { get; set; }
        public string ColorName { get; set; }
        public string FullDisplayName { get; set; } // VD: "Áo thun thể thao - XL - Đỏ"

        // Navigation Properties
        public Product Product { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }

        public ProductVariant() { }

        public ProductVariant(int id, string sku, int productId, int sizeId, int colorId, int quantity, decimal sellingPrice)
        {
            Id = id;
            SKU = sku;
            ProductId = productId;
            SizeId = sizeId;
            ColorId = colorId;
            Quantity = quantity;
            SellingPrice = sellingPrice;
        }
    }
}
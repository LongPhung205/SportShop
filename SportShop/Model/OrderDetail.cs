using System;

namespace SportShop.Model
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductVariantId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Thuộc tính mở rộng dùng để tính toán/hiển thị
        public decimal LineTotal => Quantity * UnitPrice;
        public string VariantDisplayName { get; set; }

        // Navigation Properties
        public Order Order { get; set; }
        public ProductVariant ProductVariant { get; set; }

        public OrderDetail() { }

        public OrderDetail(int id, int orderId, int productVariantId, int quantity, decimal unitPrice)
        {
            Id = id;
            OrderId = orderId;
            ProductVariantId = productVariantId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
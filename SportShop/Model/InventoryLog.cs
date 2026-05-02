using System;

namespace SportShop.Model
{
    public class InventoryLog
    {
        public int Id { get; set; }
        public int ProductVariantId { get; set; }
        public int ChangeAmount { get; set; }
        public string Type { get; set; } // IMPORT, EXPORT, ADJUSTMENT, RETURN
        public int? OrderId { get; set; }
        public int? ImportOrderId { get; set; }
        public int? UserId { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedAt { get; set; }

        // Mở rộng hiển thị
        public string VariantDisplayName { get; set; }
        public string UserName { get; set; }

        // Navigation
        public ProductVariant ProductVariant { get; set; }
        public Order Order { get; set; }
        public ImportOrder ImportOrder { get; set; }
        public User User { get; set; }

        public InventoryLog() { }
    }
}
namespace SportShop.Model
{
    public class ImportOrderDetail
    {
        public int Id { get; set; }
        public int ImportOrderId { get; set; }
        public int ProductVariantId { get; set; }
        public int Quantity { get; set; }
        public decimal ImportPrice { get; set; }

        // Mở rộng hiển thị / Tính toán
        public decimal LineTotal => Quantity * ImportPrice;
        public string VariantDisplayName { get; set; }

        // Navigation
        public ImportOrder ImportOrder { get; set; }
        public ProductVariant ProductVariant { get; set; }

        public ImportOrderDetail() { }
    }
}
// Nơi lưu trữ: Thư mục Model
namespace SportShop.Model
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Thêm trường VariantId nếu bạn muốn giỏ hàng phân biệt được Size/Màu
        // public int VariantId { get; set; } 

        public decimal TotalPrice => Price * Quantity;
    }
}
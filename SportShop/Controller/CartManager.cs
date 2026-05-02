using System.ComponentModel; // Thư viện chứa BindingList
using System.Linq;

namespace SportShop.Model
{
    public static class CartManager
    {
        // 👉 ĐỔI SANG BINDINGLIST: Bí quyết để DataGridView không bao giờ bị crash
        public static BindingList<CartItem> CurrentCart { get; set; } = new BindingList<CartItem>();

        // Hàm thêm sản phẩm vào giỏ
        public static void AddToCart(Product p)
        {
            // BindingList không có hàm Find, nên dùng FirstOrDefault của Linq
            var existingItem = CurrentCart.FirstOrDefault(x => x.ProductId == p.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += 1;
            }
            else
            {
                CurrentCart.Add(new CartItem
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    Price = p.BasePrice,
                    Quantity = 1
                });
            }
        }
    }
}
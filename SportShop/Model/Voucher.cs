using System;
using System.Collections.Generic;

namespace SportShop.Model
{
    public class Voucher
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int DiscountPercent { get; set; }
        public int? MaxUsage { get; set; }
        public int CurrentUsage { get; set; }
        public int PerCustomerLimit { get; set; }
        public decimal? MinimumOrderAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Trạng thái kiểm tra nhanh (Mở rộng)
        public bool IsValid => IsActive == true && ExpiryDate >= DateTime.Now && (MaxUsage == null || CurrentUsage < MaxUsage);

        public List<OrderVoucher> UsedInOrders { get; set; } = new List<OrderVoucher>();

        public Voucher() { }
    }
}
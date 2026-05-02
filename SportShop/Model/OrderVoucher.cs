using System;

namespace SportShop.Model
{
    public class OrderVoucher
    {
        public int OrderId { get; set; }
        public int VoucherId { get; set; }
        public DateTime? AppliedDate { get; set; }

        // Navigation
        public Order Order { get; set; }
        public Voucher Voucher { get; set; }

        public OrderVoucher() { }
    }
}
using System;
using System.Collections.Generic;

namespace SportShop.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public int? CustomerId { get; set; }
        public int UserId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Thuộc tính mở rộng dùng để hiển thị
        public string CustomerName { get; set; }
        public string StaffName { get; set; }

        // Navigation Properties
        public Customer Customer { get; set; }
        public User User { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public List<OrderVoucher> AppliedVouchers { get; set; } = new List<OrderVoucher>();

        public Order() { }

        public Order(int id, string orderCode, int? customerId, int userId, decimal? totalAmount, string paymentMethod)
        {
            Id = id;
            OrderCode = orderCode;
            CustomerId = customerId;
            UserId = userId;
            TotalAmount = totalAmount;
            PaymentMethod = paymentMethod;
        }
    }
}
using System;

namespace SportShop.Model
{
    public class Expense
    {
        public int Id { get; set; }
        public string ExpenseName { get; set; }
        public decimal Amount { get; set; }
        public DateTime? ExpenseDate { get; set; }
        public string Note { get; set; }
        public int? UserId { get; set; }

        // Mở rộng hiển thị
        public string UserName { get; set; }

        // Navigation
        public User User { get; set; }

        public Expense() { }
    }
}
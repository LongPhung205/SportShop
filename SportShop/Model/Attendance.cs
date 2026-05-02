using System;

namespace SportShop.Model
{
    public class Attendance
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public DateTime? WorkDate { get; set; }

        // Mở rộng hiển thị
        public string UserName { get; set; }

        // Navigation
        public User User { get; set; }

        public Attendance() { }
    }
}
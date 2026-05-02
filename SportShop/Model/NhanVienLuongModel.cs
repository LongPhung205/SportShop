using System;

namespace SportShop.Model
{
    public class NhanVienLuongModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public decimal HourlyRate { get; set; }
        public bool IsActive { get; set; }

        public decimal TongGioLam { get; set; }
        public decimal TongLuong { get; set; }
        public string TrangThaiLuong { get; set; }
    }
}
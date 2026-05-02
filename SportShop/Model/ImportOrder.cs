using System;
using System.Collections.Generic;

namespace SportShop.Model
{
    public class ImportOrder
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int UserId { get; set; }
        public DateTime? ImportDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Notes { get; set; }

        // 👉 ĐÃ BỔ SUNG: Trạng thái phiếu nhập ('DRAFT' hoặc 'COMPLETED')
        public string Status { get; set; }

        // Mở rộng hiển thị (Không ánh xạ trực tiếp vào DB, chỉ dùng để hiện lên View)
        public string SupplierName { get; set; }
        public string UserName { get; set; }

        // Navigation (Dành cho OOP/Entity Framework)
        public Supplier Supplier { get; set; }
        public User User { get; set; }
        public List<ImportOrderDetail> ImportOrderDetails { get; set; } = new List<ImportOrderDetail>();

        // Hàm tạo mặc định
        public ImportOrder()
        {
            Status = "DRAFT"; // Mặc định tạo ra instance mới là bản nháp
        }

        // Hàm tạo có tham số (Đã cập nhật thêm Status)
        public ImportOrder(int id, int supplierId, int userId, decimal? totalAmount, string status = "DRAFT")
        {
            Id = id;
            SupplierId = supplierId;
            UserId = userId;
            TotalAmount = totalAmount;
            Status = status;
        }
    }
}
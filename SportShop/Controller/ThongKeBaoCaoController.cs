using SportShop.DataBase;
using SportShop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SportShop.Controller
{

    // ==========================================
    // CONTROLLER CHÍNH
    // ==========================================
    public class ThongKeBaoCaoController
    {
        // ==========================================
        // 1. THỐNG KÊ TỔNG QUAN TÀI CHÍNH
        // ==========================================
        public TongQuanTaiChinh GetTongQuanTaiChinh(DateTime tuNgay, DateTime denNgay)
        {
            var tq = new TongQuanTaiChinh();

            // 1. Tổng doanh thu bán hàng
            const string sqlThu = "SELECT ISNULL(SUM(TotalAmount), 0) FROM Orders WHERE CAST(OrderDate AS DATE) >= CAST(@tu AS DATE) AND CAST(OrderDate AS DATE) <= CAST(@den AS DATE)";
            // 2. Tổng chi phí nhập hàng (chỉ lấy phiếu đã chốt)
            const string sqlNhap = "SELECT ISNULL(SUM(TotalAmount), 0) FROM ImportOrder WHERE CAST(ImportDate AS DATE) >= CAST(@tu AS DATE) AND CAST(ImportDate AS DATE) <= CAST(@den AS DATE) AND Status = 'COMPLETED'";
            // 3. Tổng chi phí phát sinh khác (Expense) - Giữ nguyên logic cũ của bạn
            const string sqlChiPhi = "SELECT ISNULL(SUM(Amount), 0) FROM Expense WHERE CAST(ExpenseDate AS DATE) >= CAST(@tu AS DATE) AND CAST(ExpenseDate AS DATE) <= CAST(@den AS DATE)";

            var parameters = new[] {
                new SqlParameter("@tu", SqlDbType.Date) { Value = tuNgay },
                new SqlParameter("@den", SqlDbType.Date) { Value = denNgay }
            };

            // Dùng kết nối chung để chạy 3 câu query cho tối ưu
            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlThu, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@tu", SqlDbType.Date) { Value = tuNgay });
                    cmd.Parameters.Add(new SqlParameter("@den", SqlDbType.Date) { Value = denNgay });
                    tq.TongDoanhThu = Convert.ToDecimal(cmd.ExecuteScalar());
                }
                using (SqlCommand cmd = new SqlCommand(sqlNhap, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@tu", SqlDbType.Date) { Value = tuNgay });
                    cmd.Parameters.Add(new SqlParameter("@den", SqlDbType.Date) { Value = denNgay });
                    tq.TongTienNhapHang = Convert.ToDecimal(cmd.ExecuteScalar());
                }
                using (SqlCommand cmd = new SqlCommand(sqlChiPhi, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@tu", SqlDbType.Date) { Value = tuNgay });
                    cmd.Parameters.Add(new SqlParameter("@den", SqlDbType.Date) { Value = denNgay });
                    tq.TongChiPhiKhac = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            return tq;
        }

        // ==========================================
        // 2. BIỂU ĐỒ DOANH THU & LỢI NHUẬN THEO NGÀY
        // ==========================================
        public List<BaoCaoDoanhThu> GetDoanhThuLoiNhuanTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            const string sql = @"
                SELECT CAST(OrderDate AS DATE) AS Ngay, 
                       COUNT(Id) AS SoLuongDon, 
                       ISNULL(SUM(TotalAmount), 0) AS TongDoanhThu
                FROM Orders
                WHERE CAST(OrderDate AS DATE) >= CAST(@tuNgay AS DATE) 
                  AND CAST(OrderDate AS DATE) <= CAST(@denNgay AS DATE)
                GROUP BY CAST(OrderDate AS DATE)
                ORDER BY CAST(OrderDate AS DATE) ASC";

            var parameters = new[]
            {
                new SqlParameter("@tuNgay", SqlDbType.Date) { Value = tuNgay },
                new SqlParameter("@denNgay", SqlDbType.Date) { Value = denNgay }
            };

            DataTable dt = DBConnection.GetDataTable(sql, parameters);
            var list = new List<BaoCaoDoanhThu>();

            foreach (DataRow row in dt.Rows)
            {
                decimal doanhThu = Convert.ToDecimal(row["TongDoanhThu"]);
                list.Add(new BaoCaoDoanhThu
                {
                    Ngay = Convert.ToDateTime(row["Ngay"]),
                    SoLuongDon = Convert.ToInt32(row["SoLuongDon"]),
                    TongDoanhThu = doanhThu,

                    // Lợi nhuận tạm tính (Giả định tỷ suất 30% để vẽ biểu đồ, bạn có thể custom lại nếu có cột Giá vốn)
                    LoiNhuan = doanhThu * 0.3m
                });
            }
            return list;
        }

        // ==========================================
        // 3. TOP SẢN PHẨM BÁN CHẠY NHẤT
        // ==========================================
        public List<ThongKeSanPham> GetTopSanPhamBanChay(int top, DateTime tuNgay, DateTime denNgay)
        {
            string sql = $@"
                SELECT TOP {top} 
                       p.Name AS ProductName, s.Name AS SizeName, c.Name AS ColorName,
                       ISNULL(SUM(od.Quantity), 0) AS TongSoLuongBan,
                       ISNULL(SUM(od.Quantity * od.UnitPrice), 0) AS TongTienThuVe
                FROM OrderDetail od
                INNER JOIN Orders o ON od.OrderId = o.Id
                INNER JOIN ProductVariant pv ON od.ProductVariantId = pv.Id
                INNER JOIN Product p ON pv.ProductId = p.Id
                LEFT JOIN Size s ON pv.SizeId = s.Id
                LEFT JOIN Color c ON pv.ColorId = c.Id
                WHERE CAST(o.OrderDate AS DATE) >= CAST(@tuNgay AS DATE) 
                  AND CAST(o.OrderDate AS DATE) <= CAST(@denNgay AS DATE)
                GROUP BY p.Name, s.Name, c.Name
                ORDER BY TongSoLuongBan DESC";

            var parameters = new[]
            {
                new SqlParameter("@tuNgay", SqlDbType.Date) { Value = tuNgay },
                new SqlParameter("@denNgay", SqlDbType.Date) { Value = denNgay }
            };

            DataTable dt = DBConnection.GetDataTable(sql, parameters);
            var list = new List<ThongKeSanPham>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ThongKeSanPham
                {
                    // Nối chuỗi để hiển thị Tên - Size - Màu (Lấy logic cũ của bạn)
                    TenSanPham = $"{row["ProductName"]} - {row["SizeName"]} - {row["ColorName"]}",
                    SoLuong = Convert.ToInt32(row["TongSoLuongBan"]),
                    TongTien = Convert.ToDecimal(row["TongTienThuVe"])
                });
            }
            return list;
        }

        // ==========================================
        // 4. TOP KHÁCH HÀNG MUA NHIỀU NHẤT
        // ==========================================
        // ==========================================
        // 4. TOP KHÁCH HÀNG MUA NHIỀU NHẤT
        // ==========================================
        public DataTable GetTopKhachHang(int top, DateTime tuNgay, DateTime denNgay)
        {
            // Mẹo: Dùng LEFT JOIN phòng trường hợp đơn hàng khách vãng lai không có CustomerId
            // Hoặc bảng Khách hàng của bạn tên khác, hãy check lại FROM Orders o LEFT JOIN ...
            string sql = $@"
                SELECT TOP {top} 
                    ISNULL(c.Name, N'Khách vãng lai') AS TenKhachHang, 
                    ISNULL(SUM(o.TotalAmount), 0) AS TongChiTieu,
                    COUNT(o.Id) AS SoDonHang
                FROM Orders o
                LEFT JOIN Customer c ON o.CustomerId = c.Id
                WHERE CAST(o.OrderDate AS DATE) >= CAST(@tuNgay AS DATE) 
                  AND CAST(o.OrderDate AS DATE) <= CAST(@denNgay AS DATE)
                GROUP BY c.Name
                ORDER BY TongChiTieu DESC";

            var parameters = new[]
            {
                new SqlParameter("@tuNgay", SqlDbType.Date) { Value = tuNgay },
                new SqlParameter("@denNgay", SqlDbType.Date) { Value = denNgay }
            };

            return DBConnection.GetDataTable(sql, parameters);
        }

        // ==========================================
        // 5. CẢNH BÁO TỒN KHO THẤP
        // ==========================================
        public DataTable GetSanPhamTonKhoThap(int threshold)
        {
            // Đã xóa điều kiện IsActive = 1 đề phòng database của bạn không có cột này
            const string sql = @"
                SELECT p.Name + ' (' + ISNULL(c.Name, '') + ' - ' + ISNULL(s.Name, '') + ')' AS TenSanPham, 
                       pv.Quantity
                FROM ProductVariant pv
                INNER JOIN Product p ON pv.ProductId = p.Id
                LEFT JOIN Size s ON pv.SizeId = s.Id
                LEFT JOIN Color c ON pv.ColorId = c.Id
                WHERE pv.Quantity <= @minQty 
                ORDER BY pv.Quantity ASC";

            var p = new SqlParameter("@minQty", SqlDbType.Int) { Value = threshold };
            return DBConnection.GetDataTable(sql, new[] { p });
        }
    }
}
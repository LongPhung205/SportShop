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
            // 3. Tổng chi phí phát sinh khác (Expense)
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
            // Sử dụng CTE để bóc tách riêng lẻ Doanh Thu và Giá Vốn, tránh bị đúp dữ liệu khi JOIN
            const string sql = @"
        WITH DoanhThuCTE AS (
            SELECT 
                CAST(OrderDate AS DATE) AS Ngay,
                COUNT(Id) AS SoLuongDon,
                ISNULL(SUM(TotalAmount), 0) AS TongDoanhThu
            FROM Orders
            WHERE CAST(OrderDate AS DATE) >= CAST(@tuNgay AS DATE)
              AND CAST(OrderDate AS DATE) <= CAST(@denNgay AS DATE)
            GROUP BY CAST(OrderDate AS DATE)
        ),
        GiaVonCTE AS (
            SELECT 
                CAST(o.OrderDate AS DATE) AS Ngay,
               
                ISNULL(SUM(od.Quantity * pv.CostPrice), 0) AS TongGiaVon
            FROM Orders o
            JOIN OrderDetail od ON o.Id = od.OrderId
            JOIN ProductVariant pv ON od.ProductVariantId = pv.Id
            WHERE CAST(o.OrderDate AS DATE) >= CAST(@tuNgay AS DATE)
              AND CAST(o.OrderDate AS DATE) <= CAST(@denNgay AS DATE)
            GROUP BY CAST(o.OrderDate AS DATE)
        )
        SELECT 
            d.Ngay, 
            d.SoLuongDon, 
            d.TongDoanhThu, 
            ISNULL(v.TongGiaVon, 0) AS TongGiaVon
        FROM DoanhThuCTE d
        LEFT JOIN GiaVonCTE v ON d.Ngay = v.Ngay
        ORDER BY d.Ngay ASC";

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
                decimal giaVon = Convert.ToDecimal(row["TongGiaVon"]);

                list.Add(new BaoCaoDoanhThu
                {
                    Ngay = Convert.ToDateTime(row["Ngay"]),
                    SoLuongDon = Convert.ToInt32(row["SoLuongDon"]),
                    TongDoanhThu = doanhThu,

                    // 👉 CHUẨN KẾ TOÁN: Lợi Nhuận Gộp = Doanh Thu Thực Tế - Giá Vốn
                    LoiNhuan = doanhThu - giaVon
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
        public DataTable GetTopKhachHang(int top, DateTime tuNgay, DateTime denNgay)
        {
            // Đã đổi thành c.Name theo chuẩn Database của bạn
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

        // ==========================================
        // 6. CHI TIẾT HÓA ĐƠN
        // ==========================================
        public DataTable GetChiTietHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            // Bóc tách Doanh thu gốc (Quantity * UnitPrice), Giá Vốn, và DiscountAmount
            string sql = @"
        SELECT 
            'HD' + RIGHT('00000' + CAST(o.Id AS VARCHAR), 5) AS [Mã HĐ],
            FORMAT(o.OrderDate, 'dd/MM/yyyy HH:mm') AS [Ngày Lập],
            ISNULL(c.Name, N'Khách vãng lai') AS [Khách Hàng],
            
            ISNULL(SUM(od.Quantity * od.UnitPrice), 0) AS [Doanh Thu],
            ISNULL(SUM(od.Quantity * pv.CostPrice), 0) AS [Giá Vốn],
            ISNULL(o.DiscountAmount, 0) AS [Giảm Giá],
            
            ISNULL(SUM(od.Quantity * od.UnitPrice), 0) 
            - ISNULL(SUM(od.Quantity * pv.CostPrice), 0) 
            - ISNULL(o.DiscountAmount, 0) AS [Lợi Nhuận]
        FROM Orders o         
        LEFT JOIN Customer c ON o.CustomerId = c.Id 

        JOIN OrderDetail od ON o.Id = od.OrderId
        JOIN ProductVariant pv ON od.ProductVariantId = pv.Id
        WHERE CAST(o.OrderDate AS DATE) >= CAST(@tuNgay AS DATE)
          AND CAST(o.OrderDate AS DATE) <= CAST(@denNgay AS DATE)
        GROUP BY 
            o.Id, 
            o.OrderDate, 
            c.Name, 
            o.DiscountAmount
        ORDER BY o.OrderDate DESC";

            var parameters = new[]
            {
        new System.Data.SqlClient.SqlParameter("@tuNgay", SqlDbType.Date) { Value = tuNgay },
        new System.Data.SqlClient.SqlParameter("@denNgay", SqlDbType.Date) { Value = denNgay }
    };

            return DBConnection.GetDataTable(sql, parameters);
        }
    }
}
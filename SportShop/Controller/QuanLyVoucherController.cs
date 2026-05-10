using SportShop.DataBase;
using SportShop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SportShop.Controller
{
    public class QuanLyVoucherController
    {
        // ==========================================
        // [NÂNG CẤP] HÀM KIỂM TRA TRÙNG MÃ VOUCHER
        // ==========================================
        public bool IsCodeExists(string code, int excludeId = 0)
        {
            const string sql = "SELECT COUNT(*) FROM Voucher WHERE Code = @code AND Id != @id";
            var parameters = new[]
            {
                new SqlParameter("@code", SqlDbType.NVarChar, 30) { Value = code },
                new SqlParameter("@id", SqlDbType.Int) { Value = excludeId }
            };

            DataTable dt = DBConnection.GetDataTable(sql, parameters);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // ==========================================
        // 1. LẤY TẤT CẢ VOUCHER
        // ==========================================
        public List<Voucher> GetAllVouchers()
        {
            const string sql = "SELECT * FROM Voucher ORDER BY Id DESC";
            DataTable dt = DBConnection.GetDataTable(sql);
            return ConvertToVoucherList(dt);
        }

        // ==========================================
        // 2. LẤY VOUCHER THEO ID
        // ==========================================
        public Voucher GetVoucherById(int id)
        {
            const string sql = "SELECT * FROM Voucher WHERE Id = @id";
            var p = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { p });
            var list = ConvertToVoucherList(dt);

            return list.Count > 0 ? list[0] : null;
        }

        // ==========================================
        // 3. THÊM MỚI VOUCHER
        // ==========================================
        public bool AddVoucher(Voucher voucher)
        {
            // Chống trùng mã Voucher
            if (IsCodeExists(voucher.Code))
                throw new Exception($"Mã Voucher '{voucher.Code}' đã tồn tại trong hệ thống!");

            const string sql = @"
                INSERT INTO Voucher (Code, DiscountPercent, MaxUsage, CurrentUsage, PerCustomerLimit, MinimumOrderAmount, ExpiryDate, IsActive) 
                VALUES (@code, @discount, @max, @current, @limit, @minAmount, @expiry, @active)";

            var parameters = new[]
            {
                new SqlParameter("@code", SqlDbType.NVarChar, 30) { Value = voucher.Code },
                new SqlParameter("@discount", SqlDbType.Int) { Value = voucher.DiscountPercent },
                new SqlParameter("@max", SqlDbType.Int) { Value = (object)voucher.MaxUsage ?? DBNull.Value },
                new SqlParameter("@current", SqlDbType.Int) { Value = 0 }, // Mặc định tạo mới là 0
                new SqlParameter("@limit", SqlDbType.Int) { Value = voucher.PerCustomerLimit },
                new SqlParameter("@minAmount", SqlDbType.Decimal) { Value = (object)voucher.MinimumOrderAmount ?? DBNull.Value },
                new SqlParameter("@expiry", SqlDbType.DateTime) { Value = voucher.ExpiryDate },
                new SqlParameter("@active", SqlDbType.Bit) { Value = voucher.IsActive ?? true }
            };

            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        // ==========================================
        // 4. CẬP NHẬT VOUCHER
        // ==========================================
        public bool UpdateVoucher(Voucher voucher)
        {
            // Chống trùng mã Voucher với các ID khác
            if (IsCodeExists(voucher.Code, voucher.Id))
                throw new Exception($"Mã Voucher '{voucher.Code}' đã được sử dụng cho một chương trình khác!");

            const string sql = @"
                UPDATE Voucher 
                SET Code = @code, DiscountPercent = @discount, MaxUsage = @max, 
                    PerCustomerLimit = @limit, MinimumOrderAmount = @minAmount, 
                    ExpiryDate = @expiry, IsActive = @active, UpdatedAt = GETDATE()
                WHERE Id = @id";

            var parameters = new[]
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = voucher.Id },
                new SqlParameter("@code", SqlDbType.NVarChar, 30) { Value = voucher.Code },
                new SqlParameter("@discount", SqlDbType.Int) { Value = voucher.DiscountPercent },
                new SqlParameter("@max", SqlDbType.Int) { Value = (object)voucher.MaxUsage ?? DBNull.Value },
                new SqlParameter("@limit", SqlDbType.Int) { Value = voucher.PerCustomerLimit },
                new SqlParameter("@minAmount", SqlDbType.Decimal) { Value = (object)voucher.MinimumOrderAmount ?? DBNull.Value },
                new SqlParameter("@expiry", SqlDbType.DateTime) { Value = voucher.ExpiryDate },
                new SqlParameter("@active", SqlDbType.Bit) { Value = voucher.IsActive ?? true }
            };

            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        // ==========================================
        // 5. XÓA VOUCHER (XÓA MỀM HOẶC CỨNG)
        // ==========================================
        public bool DeleteVoucher(int id)
        {
            const string sqlCheck = "SELECT CurrentUsage FROM Voucher WHERE Id = @id";
            var pCheck = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            DataTable dtCheck = DBConnection.GetDataTable(sqlCheck, new[] { pCheck });

            if (dtCheck.Rows.Count > 0)
            {
                int currentUsage = Convert.ToInt32(dtCheck.Rows[0]["CurrentUsage"]);

                if (currentUsage > 0)
                {
                    // Đã có người dùng -> Xóa mềm (Vô hiệu hóa)
                    const string sqlDisable = "UPDATE Voucher SET IsActive = 0, UpdatedAt = GETDATE() WHERE Id = @id";
                    return DBConnection.ExecuteNonQuery(sqlDisable, new[] { new SqlParameter("@id", SqlDbType.Int) { Value = id } }) > 0;
                }
                else
                {
                    // Chưa ai dùng -> Xóa cứng
                    const string sqlDelete = "DELETE FROM Voucher WHERE Id = @id";
                    return DBConnection.ExecuteNonQuery(sqlDelete, new[] { new SqlParameter("@id", SqlDbType.Int) { Value = id } }) > 0;
                }
            }
            return false;
        }

        // ==========================================
        // 6. TÌM KIẾM VOUCHER
        // ==========================================
        public List<Voucher> SearchVouchers(string keyword)
        {
            const string sql = "SELECT * FROM Voucher WHERE Code LIKE @key ORDER BY Id DESC";
            var pKey = new SqlParameter("@key", SqlDbType.NVarChar, 50) { Value = "%" + keyword + "%" };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { pKey });

            return ConvertToVoucherList(dt);
        }

        // ==========================================
        // 7. KIỂM TRA VOUCHER KHI THANH TOÁN
        // ==========================================
        public Voucher GetValidVoucherToApply(string code, decimal currentOrderTotal, int? customerId = null)
        {
            const string sql = "SELECT * FROM Voucher WHERE Code = @code AND IsActive = 1";
            var p = new SqlParameter("@code", SqlDbType.NVarChar, 30) { Value = code };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { p });
            var list = ConvertToVoucherList(dt);

            if (list.Count == 0) return null; // Không tồn tại hoặc đã bị vô hiệu hóa

            Voucher v = list[0];

            // 1. Kiểm tra hạn sử dụng
            if (v.ExpiryDate < DateTime.Now) return null;

            // 2. Kiểm tra tổng lượt sử dụng của toàn hệ thống
            if (v.MaxUsage.HasValue && v.CurrentUsage >= v.MaxUsage.Value) return null;

            // 3. Kiểm tra giá trị đơn hàng tối thiểu
            if (v.MinimumOrderAmount.HasValue && currentOrderTotal < v.MinimumOrderAmount.Value) return null;

            // 4. 👉 BỔ SUNG: Kiểm tra giới hạn lượt dùng của từng khách hàng (PerCustomerLimit)
            if (customerId.HasValue && customerId.Value > 0 && v.PerCustomerLimit > 0)
            {
                int usageCount = GetVoucherUsageByCustomer(v.Id, customerId.Value);
                if (usageCount >= v.PerCustomerLimit)
                {
                    // Trả về null (hoặc bạn có thể ném Exception để hiện thông báo chi tiết bên View)
                    return null;
                }
            }

            return v;
        }
        // ==========================================
        // [NÂNG CẤP] 8. TĂNG LƯỢT SỬ DỤNG KHI THANH TOÁN XONG
        // ==========================================
        public bool IncreaseVoucherUsage(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) return false;

            const string sql = @"
                UPDATE Voucher 
                SET CurrentUsage = CurrentUsage + 1, UpdatedAt = GETDATE() 
                WHERE Code = @code AND IsActive = 1";
            var p = new SqlParameter("@code", SqlDbType.NVarChar, 30) { Value = code };

            return DBConnection.ExecuteNonQuery(sql, new[] { p }) > 0;
        }

        public int GetVoucherUsageByCustomer(int voucherId, int customerId)
        {
            // Nối bảng OrderVoucher và Orders để đếm số lần khách hàng đã dùng mã này
            const string sql = @"
                SELECT COUNT(ov.VoucherId) 
                FROM OrderVoucher ov
                JOIN Orders o ON ov.OrderId = o.Id
                WHERE ov.VoucherId = @vid AND o.CustomerId = @cid";

            var parameters = new[]
            {
                new SqlParameter("@vid", SqlDbType.Int) { Value = voucherId },
                new SqlParameter("@cid", SqlDbType.Int) { Value = customerId }
            };

            DataTable dt = DBConnection.GetDataTable(sql, parameters);
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            return 0;
        }
        // ==========================================
        // HÀM HELPER: CHUYỂN DATATABLE SANG LIST MODEL
        // ==========================================
        private List<Voucher> ConvertToVoucherList(DataTable dt)
        {
            var list = new List<Voucher>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Voucher
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Code = row["Code"].ToString(),
                    DiscountPercent = Convert.ToInt32(row["DiscountPercent"]),
                    MaxUsage = row["MaxUsage"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["MaxUsage"]),
                    CurrentUsage = Convert.ToInt32(row["CurrentUsage"]),
                    PerCustomerLimit = Convert.ToInt32(row["PerCustomerLimit"]),
                    MinimumOrderAmount = row["MinimumOrderAmount"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["MinimumOrderAmount"]),
                    ExpiryDate = Convert.ToDateTime(row["ExpiryDate"]),
                    IsActive = row["IsActive"] == DBNull.Value ? true : Convert.ToBoolean(row["IsActive"]),
                    CreatedAt = row["CreatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = row["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["UpdatedAt"])
                });
            }
            return list;
        }
    }
}
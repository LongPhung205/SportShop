using SportShop.DataBase;
using SportShop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SportShop.Controller
{
    public class QuanLyKhachHangController
    {
        // ==========================================
        // QUẢN LÝ THÔNG TIN CƠ BẢN (CRUD)
        // ==========================================

        // 1. LẤY TẤT CẢ KHÁCH HÀNG
        public List<Customer> GetAllCustomers()
        {
            const string sql = "SELECT * FROM Customer ORDER BY Id DESC";
            DataTable dt = DBConnection.GetDataTable(sql);
            return ConvertToCustomerList(dt);
        }

        // 2. LẤY KHÁCH HÀNG THEO ID
        public Customer GetCustomerById(int id)
        {
            const string sql = "SELECT * FROM Customer WHERE Id = @id";
            var p = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { p });
            var list = ConvertToCustomerList(dt);

            return list.Count > 0 ? list[0] : null;
        }

        // 3. THÊM MỚI KHÁCH HÀNG
        public bool AddCustomer(Customer customer)
        {
            const string sql = @"
                INSERT INTO Customer (Name, Phone, Address, LoyaltyPoints) 
                VALUES (@name, @phone, @address, @loyaltyPoints)";

            var parameters = new[]
            {
                new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = customer.Name },
                new SqlParameter("@phone", SqlDbType.NVarChar, 20) { Value = (object)customer.Phone ?? DBNull.Value },
                
                new SqlParameter("@address", SqlDbType.NVarChar, 500) { Value = (object)customer.Address ?? DBNull.Value },
                new SqlParameter("@loyaltyPoints", SqlDbType.Int) { Value = customer.LoyaltyPoints ?? 0 }
            };

            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        // 4. CẬP NHẬT THÔNG TIN KHÁCH HÀNG
        public bool UpdateCustomer(Customer customer)
        {
            const string sql = @"
                UPDATE Customer 
                SET Name = @name, Phone = @phone, Address = @address, LoyaltyPoints = @loyaltyPoints 
                WHERE Id = @id";

            var parameters = new[]
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = customer.Id },
                new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = customer.Name },
                new SqlParameter("@phone", SqlDbType.NVarChar, 20) { Value = (object)customer.Phone ?? DBNull.Value },
              
                new SqlParameter("@address", SqlDbType.NVarChar, 500) { Value = (object)customer.Address ?? DBNull.Value },
                new SqlParameter("@loyaltyPoints", SqlDbType.Int) { Value = customer.LoyaltyPoints ?? 0 }
            };

            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        // 5. XÓA KHÁCH HÀNG
        public bool DeleteCustomer(int id)
        {
            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 5.1 Gỡ CustomerId ở bảng Orders thành NULL (để không mất hóa đơn cũ)
                        const string sqlRemoveRef = "UPDATE Orders SET CustomerId = NULL WHERE CustomerId = @id";
                        using (var cmdRef = new SqlCommand(sqlRemoveRef, conn, trans))
                        {
                            cmdRef.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
                            cmdRef.ExecuteNonQuery();
                        }

                        // 5.2 Xóa khách hàng
                        const string sqlDelete = "DELETE FROM Customer WHERE Id = @id";
                        using (var cmdDel = new SqlCommand(sqlDelete, conn, trans))
                        {
                            cmdDel.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
                            cmdDel.ExecuteNonQuery();
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        try { trans.Rollback(); } catch { }
                        return false;
                    }
                }
            }
        }

        // 6. TÌM KIẾM KHÁCH HÀNG (Theo Tên hoặc Số điện thoại)
        public List<Customer> SearchCustomers(string keyword)
        {
            const string sql = "SELECT * FROM Customer WHERE Name LIKE @key OR Phone LIKE @key ORDER BY Id DESC";
            var pKey = new SqlParameter("@key", SqlDbType.NVarChar, 200) { Value = "%" + keyword + "%" };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { pKey });

            return ConvertToCustomerList(dt);
        }

        // ==========================================
        // CÁC NGHIỆP VỤ NÂNG CAO (CRM)
        // ==========================================

        // 7. LẤY LỊCH SỬ MUA HÀNG CỦA KHÁCH
        public DataTable GetCustomerPurchaseHistory(int customerId)
        {
            const string sql = @"
                SELECT 
                    OrderCode AS [Mã Hóa Đơn], 
                    OrderDate AS [Ngày Mua], 
                    TotalAmount AS [Tổng Tiền], 
                    DiscountAmount AS [Giảm Giá], 
                    PaymentMethod AS [Phương Thức]
                FROM Orders 
                WHERE CustomerId = @cid 
                ORDER BY OrderDate DESC";

            var p = new SqlParameter("@cid", SqlDbType.Int) { Value = customerId };
            return DBConnection.GetDataTable(sql, new[] { p });
        }

        // 8. LẤY TỔNG SỐ TIỀN KHÁCH ĐÃ CHI TIÊU
        public decimal GetCustomerTotalSpend(int customerId)
        {
            const string sql = "SELECT SUM(TotalAmount) FROM Orders WHERE CustomerId = @cid";
            var p = new SqlParameter("@cid", SqlDbType.Int) { Value = customerId };

            DataTable dt = DBConnection.GetDataTable(sql, new[] { p });
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                return Convert.ToDecimal(dt.Rows[0][0]);
            }
            return 0m;
        }

        // 9. TỰ ĐỘNG CỘNG ĐIỂM KHI THANH TOÁN 
        public bool AddLoyaltyPoints(int customerId, decimal orderTotalAmount)
        {
            // Tỷ lệ quy đổi: 10,000đ = 1 điểm. Bạn có thể sửa con số 10000 này theo ý muốn.
            int pointsToAdd = (int)(orderTotalAmount / 10000);

            if (pointsToAdd <= 0) return true; // Hóa đơn quá nhỏ, không có điểm cộng

            const string sql = "UPDATE Customer SET LoyaltyPoints = ISNULL(LoyaltyPoints, 0) + @points WHERE Id = @cid";
            var parameters = new[]
            {
                new SqlParameter("@points", SqlDbType.Int) { Value = pointsToAdd },
                new SqlParameter("@cid", SqlDbType.Int) { Value = customerId }
            };

            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }
        // Hàm trừ điểm tích lũy của khách hàng khi thanh toán
        public bool DeductLoyaltyPoints(int customerId, int pointsToDeduct)
        {
            // Câu lệnh SQL: Trừ điểm, nếu số điểm trừ lớn hơn số điểm hiện có thì set về 0 (chống âm điểm)
            string sql = @"
        UPDATE Customer 
        SET LoyaltyPoints = CASE 
                                WHEN LoyaltyPoints >= @points THEN LoyaltyPoints - @points 
                                ELSE 0 
                            END 
        WHERE Id = @id";

            // Truyền tham số
            var parameters = new[]
            {
        new System.Data.SqlClient.SqlParameter("@points", pointsToDeduct),
        new System.Data.SqlClient.SqlParameter("@id", customerId)
    };

            try
            {
                // Sử dụng hàm ExecuteNonQuery từ class DBConnection của bạn
                return DataBase.DBConnection.ExecuteNonQuery(sql, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi trừ điểm khách hàng: " + ex.Message);
            }
        }


        // ==========================================
        // HÀM HELPER: CHUYỂN DATATABLE SANG LIST MODEL
        // ==========================================
        private List<Customer> ConvertToCustomerList(DataTable dt)
        {
            var list = new List<Customer>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Customer
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Phone = row["Phone"] == DBNull.Value ? "" : row["Phone"].ToString(),
                    
                    Address = row["Address"] == DBNull.Value ? "" : row["Address"].ToString(),
                    LoyaltyPoints = row["LoyaltyPoints"] == DBNull.Value ? 0 : Convert.ToInt32(row["LoyaltyPoints"]),
                    CreatedAt = row["CreatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["CreatedAt"])
                });
            }
            return list;
        }
    }
}
using BCrypt.Net;
using SportShop.DataBase;
using SportShop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SportShop.Controller
{
    public class QuanLyNguoiDungController
    {
        // WorkFactor = 12 là mức độ băm tiêu chuẩn và an toàn
        private const int BcryptWorkFactor = 12;

        // ==========================================
        // 1. ĐĂNG NHẬP
        // ==========================================
        public User Login(string username, string password)
        {
            try
            {
                const string sql = "SELECT * FROM [User] WHERE Username = @user AND IsActive = 1";
                var parameters = new[]
                {
            new SqlParameter("@user", SqlDbType.NVarChar, 50) { Value = username }
        };

                DataTable dt = DBConnection.GetDataTable(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    string storedPass = row["Password"].ToString();

                    bool isLoginSuccess = false;

                    // 🔥 CASE 1: Password đã là bcrypt
                    if (!string.IsNullOrEmpty(storedPass) && storedPass.StartsWith("$2"))
                    {
                        isLoginSuccess = BCrypt.Net.BCrypt.Verify(password, storedPass);
                    }
                    else
                    {
                        // 🔥 CASE 2: Password cũ (plain text)
                        if (storedPass == password)
                        {
                            isLoginSuccess = true;

                            // 👉 AUTO UPGRADE lên bcrypt
                            string newHash = BCrypt.Net.BCrypt.HashPassword(password, BcryptWorkFactor);

                            const string updateSql = "UPDATE [User] SET Password = @pw WHERE Id = @id";
                            var updateParams = new[]
                            {
                        new SqlParameter("@pw", SqlDbType.NVarChar, 255) { Value = newHash },
                        new SqlParameter("@id", SqlDbType.Int) { Value = Convert.ToInt32(row["Id"]) }
                    };

                            DBConnection.ExecuteNonQuery(updateSql, updateParams);
                        }
                    }

                    if (isLoginSuccess)
                    {
                        return ConvertToUserList(dt)[0];
                    }
                }
            }
            catch
            {
            }

            return null;
        }

        // ==========================================
        // 2. LẤY TẤT CẢ NGƯỜI DÙNG
        // ==========================================
        public List<User> GetAllUsers()
        {
            const string sql = "SELECT * FROM [User] ORDER BY Id DESC";
            DataTable dt = DBConnection.GetDataTable(sql);
            return ConvertToUserList(dt);
        }

        // ==========================================
        // 3. LẤY NGƯỜI DÙNG THEO ID
        // ==========================================
        public User GetUserById(int id)
        {
            const string sql = "SELECT * FROM [User] WHERE Id = @id";
            var p = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { p });
            var list = ConvertToUserList(dt);

            return list.Count > 0 ? list[0] : null;
        }

        // ==========================================
        // 4. THÊM MỚI NGƯỜI DÙNG
        // ==========================================
        public bool AddUser(User user)
        {
            try
            {
                // Băm mật khẩu trước khi thêm vào Database
                string hash = BCrypt.Net.BCrypt.HashPassword(user.Password, BcryptWorkFactor);

                const string sql = @"
                    INSERT INTO [User] (Username, Password, FullName, Role, HourlyRate, IsActive) 
                    VALUES (@un, @pw, @fn, @role, @rate, @active)";

                var parameters = new[]
                {
                    new SqlParameter("@un", SqlDbType.NVarChar, 50) { Value = user.Username },
                    new SqlParameter("@pw", SqlDbType.NVarChar, 255) { Value = hash }, // Lưu chuỗi đã băm
                    new SqlParameter("@fn", SqlDbType.NVarChar, 100) { Value = user.FullName },
                    new SqlParameter("@role", SqlDbType.NVarChar, 20) { Value = user.Role },
                    new SqlParameter("@rate", SqlDbType.Decimal) { Value = user.HourlyRate ?? 0m },
                    new SqlParameter("@active", SqlDbType.Bit) { Value = user.IsActive ?? true }
                };

                return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }

        // ==========================================
        // 5. CẬP NHẬT NGƯỜI DÙNG
        // ==========================================
        public bool UpdateUser(User user)
        {
            try
            {
                string finalPassword = user.Password;

                // Chuỗi băm của BCrypt luôn bắt đầu bằng "$2". 
                // Nếu mật khẩu truyền vào KHÔNG bắt đầu bằng "$2", tức là mật khẩu mới (plain text) -> Cần băm lại
                if (!string.IsNullOrEmpty(user.Password) && !user.Password.StartsWith("$2"))
                {
                    finalPassword = BCrypt.Net.BCrypt.HashPassword(user.Password, BcryptWorkFactor);
                }

                const string sql = @"
                    UPDATE [User] 
                    SET Username = @un, Password = @pw, FullName = @fn, 
                        Role = @role, HourlyRate = @rate, IsActive = @active 
                    WHERE Id = @id";

                var parameters = new[]
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = user.Id },
                    new SqlParameter("@un", SqlDbType.NVarChar, 50) { Value = user.Username },
                    new SqlParameter("@pw", SqlDbType.NVarChar, 255) { Value = finalPassword },
                    new SqlParameter("@fn", SqlDbType.NVarChar, 100) { Value = user.FullName },
                    new SqlParameter("@role", SqlDbType.NVarChar, 20) { Value = user.Role },
                    new SqlParameter("@rate", SqlDbType.Decimal) { Value = user.HourlyRate ?? 0m },
                    new SqlParameter("@active", SqlDbType.Bit) { Value = user.IsActive ?? true }
                };

                return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }

        // ==========================================
        // 6. XÓA NGƯỜI DÙNG
        // ==========================================
        public bool DeleteUser(int id)
        {
            try
            {
                const string sqlCheck = @"
                    SELECT (SELECT COUNT(*) FROM Orders WHERE UserId = @id) + 
                           (SELECT COUNT(*) FROM ImportOrder WHERE UserId = @id)";

                var pCheck = new SqlParameter("@id", SqlDbType.Int) { Value = id };
                DataTable dtCheck = DBConnection.GetDataTable(sqlCheck, new[] { pCheck });

                int relatedRecords = Convert.ToInt32(dtCheck.Rows[0][0]);

                if (relatedRecords > 0)
                {
                    // Đã có giao dịch -> Xóa mềm (Soft Delete)
                    const string sqlDisable = "UPDATE [User] SET IsActive = 0 WHERE Id = @id";
                    var pDisable = new SqlParameter("@id", SqlDbType.Int) { Value = id };
                    return DBConnection.ExecuteNonQuery(sqlDisable, new[] { pDisable }) > 0;
                }
                else
                {
                    // Chưa có giao dịch -> Xóa cứng (Hard Delete)
                    const string sqlDelete = "DELETE FROM [User] WHERE Id = @id";
                    var pDelete = new SqlParameter("@id", SqlDbType.Int) { Value = id };
                    return DBConnection.ExecuteNonQuery(sqlDelete, new[] { pDelete }) > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        // ==========================================
        // 7. TÌM KIẾM NGƯỜI DÙNG
        // ==========================================
        public List<User> SearchUsers(string keyword)
        {
            const string sql = @"
                SELECT * FROM [User] 
                WHERE Username LIKE @key OR FullName LIKE @key 
                ORDER BY Id DESC";

            var pKey = new SqlParameter("@key", SqlDbType.NVarChar, 200) { Value = "%" + keyword + "%" };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { pKey });

            return ConvertToUserList(dt);
        }

        // ==========================================
        // HÀM HELPER: CHUYỂN DATATABLE SANG LIST MODEL
        // ==========================================
        private List<User> ConvertToUserList(DataTable dt)
        {
            var list = new List<User>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new User
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Role = row["Role"].ToString(),
                    HourlyRate = row["HourlyRate"] == DBNull.Value ? 0m : Convert.ToDecimal(row["HourlyRate"]),
                    IsActive = row["IsActive"] == DBNull.Value ? true : Convert.ToBoolean(row["IsActive"]),
                    CreatedAt = row["CreatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["CreatedAt"])
                });
            }
            return list;
        }
        // ==========================================
        // 8. LẤY BẢNG CHẤM CÔNG TỔNG HỢP HÔM NAY
        // ==========================================
        public DataTable GetBangChamCongTheoNgay(DateTime date)
        {
            const string sql = @"
        SELECT 
            u.Id AS UserId, 
            u.Username, 
            u.FullName, 
            u.Role,
            a.Id AS AttendanceId, 
            a.CheckInTime, 
            a.CheckOutTime
        FROM [User] u
        LEFT JOIN Attendance a ON u.Id = a.UserId AND a.WorkDate = CAST(@selectedDate AS DATE)
        WHERE u.IsActive = 1
        ORDER BY a.CheckInTime DESC, u.FullName ASC";

            var p = new SqlParameter("@selectedDate", SqlDbType.Date) { Value = date };
            return DBConnection.GetDataTable(sql, new[] { p });
        }

        public decimal CalculateMonthlySalary(int userId, int month, int year)
        {
            // 1. Lấy mức lương theo giờ (HourlyRate) của nhân viên
            const string sqlUser = "SELECT HourlyRate FROM [User] WHERE Id = @uid";
            var pUser = new SqlParameter("@uid", SqlDbType.Int) { Value = userId };
            DataTable dtUser = DBConnection.GetDataTable(sqlUser, new[] { pUser });

            if (dtUser.Rows.Count == 0) return 0;

            decimal hourlyRate = dtUser.Rows[0]["HourlyRate"] == DBNull.Value ? 0m : Convert.ToDecimal(dtUser.Rows[0]["HourlyRate"]);

            if (hourlyRate <= 0) return 0; // Chưa set lương hoặc không tính theo giờ

            // 2. Lấy tổng số phút làm việc trong tháng (Dùng DATEDIFF của SQL)
            const string sqlHours = @"
                SELECT SUM(DATEDIFF(MINUTE, CheckInTime, CheckOutTime)) AS TotalMinutes
                FROM Attendance 
                WHERE UserId = @uid 
                  AND MONTH(WorkDate) = @month 
                  AND YEAR(WorkDate) = @year 
                  AND CheckOutTime IS NOT NULL";

            var parameters = new[]
            {
                new SqlParameter("@uid", SqlDbType.Int) { Value = userId },
                new SqlParameter("@month", SqlDbType.Int) { Value = month },
                new SqlParameter("@year", SqlDbType.Int) { Value = year }
            };

            DataTable dtHours = DBConnection.GetDataTable(sqlHours, parameters);

            if (dtHours.Rows.Count == 0 || dtHours.Rows[0]["TotalMinutes"] == DBNull.Value)
                return 0;

            int totalMinutes = Convert.ToInt32(dtHours.Rows[0]["TotalMinutes"]);
            decimal totalHours = totalMinutes / 60m; // Quy đổi phút ra giờ có thập phân

            return totalHours * hourlyRate;
        }

    }
}

using SportShop.DataBase;
using SportShop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SportShop.Controller
{
    public class QuanLyNhanVienController
    {
        // ==========================================
        // 1. QUẢN LÝ THÔNG TIN NHÂN VIÊN
        // ==========================================

        // Lấy danh sách chỉ hiển thị NHÂN VIÊN (STAFF)
        public List<User> GetAllStaffs()
        {
            const string sql = "SELECT * FROM [User] WHERE Role = 'STAFF' ORDER BY Id DESC";
            DataTable dt = DBConnection.GetDataTable(sql);
            return ConvertToUserList(dt);
        }

        // ==========================================
        // 2. NGHIỆP VỤ CHẤM CÔNG (ATTENDANCE)
        // ==========================================

        // Nhân viên Check-in (Bắt đầu ca)
        // Xác thực tài khoản nhân viên lúc điểm danh (Bảo mật)
        public User XacThucDiemDanh(string username, string password)
        {
            const string sql = "SELECT * FROM [User] WHERE Username = @user AND Password = @pass AND IsActive = 1";
            var parameters = new[] {
        new SqlParameter("@user", SqlDbType.NVarChar, 50) { Value = username },
        new SqlParameter("@pass", SqlDbType.NVarChar, 255) { Value = password }
    };
            DataTable dt = DBConnection.GetDataTable(sql, parameters);
            var list = ConvertToUserList(dt);
            return list.Count > 0 ? list[0] : null;
        }

        // Lấy bảng trạng thái của TẤT CẢ nhân viên trong hôm nay
        public DataTable GetBangChamCongHomNay()
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
        LEFT JOIN Attendance a ON u.Id = a.UserId AND a.WorkDate = CAST(GETDATE() AS DATE)
        WHERE u.IsActive = 1
        ORDER BY a.CheckInTime DESC, u.FullName ASC"; // Người mới check-in xếp lên trên

            return DBConnection.GetDataTable(sql);
        }
        public bool CheckIn(int userId)
        {
            // Kiểm tra xem hôm nay nhân viên này đã check-in chưa
            const string sqlCheck = "SELECT COUNT(*) FROM Attendance WHERE UserId = @uid AND WorkDate = CAST(GETDATE() AS DATE)";
            var pCheck = new SqlParameter("@uid", SqlDbType.Int) { Value = userId };
            DataTable dtCheck = DBConnection.GetDataTable(sqlCheck, new[] { pCheck });

            if (Convert.ToInt32(dtCheck.Rows[0][0]) > 0)
            {
                // Đã check-in trong ngày hôm nay rồi thì không cho check-in đè lên
                return false;
            }

            // Ghi nhận Check-in
            const string sqlInsert = "INSERT INTO Attendance (UserId, CheckInTime, WorkDate) VALUES (@uid, GETDATE(), CAST(GETDATE() AS DATE))";
            var pInsert = new SqlParameter("@uid", SqlDbType.Int) { Value = userId };

            return DBConnection.ExecuteNonQuery(sqlInsert, new[] { pInsert }) > 0;
        }

        // Nhân viên Check-out (Kết thúc ca)
        public bool CheckOut(int userId)
        {
            // Cập nhật giờ ra cho bản ghi check-in của ngày hôm nay
            const string sqlUpdate = @"
                UPDATE Attendance 
                SET CheckOutTime = GETDATE() 
                WHERE UserId = @uid 
                  AND WorkDate = CAST(GETDATE() AS DATE) 
                  AND CheckOutTime IS NULL"; // Chỉ update nếu chưa check-out

            var pUpdate = new SqlParameter("@uid", SqlDbType.Int) { Value = userId };
            return DBConnection.ExecuteNonQuery(sqlUpdate, new[] { pUpdate }) > 0;
        }
        // Lấy trạng thái chấm công của ngày hôm nay
        public Attendance GetTodayAttendance(int userId)
        {
            const string sql = "SELECT * FROM Attendance WHERE UserId = @uid AND WorkDate = CAST(GETDATE() AS DATE)";
            var p = new SqlParameter("@uid", SqlDbType.Int) { Value = userId };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { p });

            var list = ConvertToAttendanceList(dt);
            return list.Count > 0 ? list[0] : null;
        }

        // Lấy lịch sử chấm công của một nhân viên theo tháng/năm
        public List<Attendance> GetAttendanceHistory(int userId, int month, int year)
        {
            const string sql = @"
                SELECT a.Id, a.UserId, u.FullName AS UserName, a.CheckInTime, a.CheckOutTime, a.WorkDate 
                FROM Attendance a
                INNER JOIN [User] u ON a.UserId = u.Id
                WHERE a.UserId = @uid 
                  AND MONTH(a.WorkDate) = @month 
                  AND YEAR(a.WorkDate) = @year
                ORDER BY a.WorkDate DESC";

            var parameters = new[]
            {
                new SqlParameter("@uid", SqlDbType.Int) { Value = userId },
                new SqlParameter("@month", SqlDbType.Int) { Value = month },
                new SqlParameter("@year", SqlDbType.Int) { Value = year }
            };

            DataTable dt = DBConnection.GetDataTable(sql, parameters);
            return ConvertToAttendanceList(dt);
        }

        // ==========================================
        // 3. TÍNH LƯƠNG (PAYROLL)
        // ==========================================

        // Tính lương nhân viên trong 1 tháng (Dựa vào số giờ làm thực tế * Mức lương theo giờ)
       
        // ==========================================
        // HÀM HELPER: CHUYỂN ĐỔI DỮ LIỆU
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

        private List<Attendance> ConvertToAttendanceList(DataTable dt)
        {
            var list = new List<Attendance>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Attendance
                {
                    Id = Convert.ToInt32(row["Id"]),
                    UserId = Convert.ToInt32(row["UserId"]),
                    UserName = row["UserName"] == DBNull.Value ? "" : row["UserName"].ToString(),
                    CheckInTime = Convert.ToDateTime(row["CheckInTime"]),
                    CheckOutTime = row["CheckOutTime"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["CheckOutTime"]),
                    WorkDate = row["WorkDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["WorkDate"])
                });
            }
            return list;
        }
    }
}
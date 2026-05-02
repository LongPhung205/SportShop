using SportShop.Controller;
using SportShop.Model;
using SportShop.DataBase; // Thêm dòng này để gọi DBConnection xử lý lương
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SportShop.View
{
    public partial class QuanLyNhanVien : UserControl
    {
        private QuanLyNguoiDungController _userController = new QuanLyNguoiDungController();

        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            // Thiết lập ComboBox Phân quyền (Viết in hoa để khớp với Database Check)
            cboRole.Items.Clear();
            cboRole.Items.Add("ADMIN");
            cboRole.Items.Add("STAFF");
            cboRole.SelectedIndex = 1;

            // Gắn sự kiện cho các control tính lương
            cboKyTinhLuong.SelectedIndexChanged += cboKyTinhLuong_SelectedIndexChanged;
            cboTrangThaiLuong.SelectedIndexChanged += (s, ev) => LoadData();
            btnTraLuongCaNhan.Click += btnTraLuongCaNhan_Click;
            btnTraLuongTatCa.Click += btnTraLuongTatCa_Click;

            // Khởi tạo mặc định
            cboTrangThaiLuong.SelectedIndex = 0;
            cboKyTinhLuong.SelectedIndex = 0;    // Sẽ tự động trigger LoadData()
        }

        // =======================================================
        // 1. LOGIC ẨN HIỆN VÀ LẤY NGÀY CỦA KỲ LƯƠNG
        // =======================================================
        private void cboKyTinhLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            string luaChon = cboKyTinhLuong.SelectedItem.ToString();
            DateTime now = DateTime.Now;

            // Tạm gỡ sự kiện để không bị LoadData 2-3 lần khi set Value
            dtpTuNgay.ValueChanged -= dtpNgay_ValueChanged_Trigger;
            dtpDenNgay.ValueChanged -= dtpNgay_ValueChanged_Trigger;

            if (luaChon == "Tháng này")
            {
                ChuyenTrangThaiNgay(false);
                dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
                dtpDenNgay.Value = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));
            }
            else if (luaChon == "Tháng trước")
            {
                ChuyenTrangThaiNgay(false);
                DateTime lastMonth = now.AddMonths(-1);
                dtpTuNgay.Value = new DateTime(lastMonth.Year, lastMonth.Month, 1);
                dtpDenNgay.Value = new DateTime(lastMonth.Year, lastMonth.Month, DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month));
            }
            else if (luaChon == "Tùy chọn")
            {
                ChuyenTrangThaiNgay(true);
            }

            // Gắn sự kiện lại và LoadData
            dtpTuNgay.ValueChanged += dtpNgay_ValueChanged_Trigger;
            dtpDenNgay.ValueChanged += dtpNgay_ValueChanged_Trigger;
            LoadData();
        }

        private void ChuyenTrangThaiNgay(bool isVisible)
        {
            dtpTuNgay.Visible = isVisible;
            dtpDenNgay.Visible = isVisible;
            lblTuNgay.Visible = isVisible;
            lblDenNgay.Visible = isVisible;
        }

        private void dtpNgay_ValueChanged_Trigger(object sender, EventArgs e) { LoadData(); }


        // =======================================================
        // 2. LOAD VÀ TÍNH TOÁN DỮ LIỆU
        // =======================================================
        private void LoadData()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;
                string filterStatus = cboTrangThaiLuong.SelectedItem?.ToString() ?? "Tất cả";

                var rawUsers = _userController.GetAllUsers();
                var displayList = new List<NhanVienLuongModel>();

                foreach (var u in rawUsers)
                {
                    decimal tongGio = TinhTongGioLam(u.Id, tuNgay, denNgay);
                    decimal tongLuong = tongGio * (u.HourlyRate ?? 0m);
                    bool daTra = KiemTraDaTraLuong(u.Id, tuNgay, denNgay);
                    string trangThai = daTra ? "Đã trả" : "Chưa trả";

                    // Chặn hiển thị nếu bị vướng bộ lọc
                    if (filterStatus == "Chưa trả" && daTra) continue;
                    if (filterStatus == "Đã trả" && !daTra) continue;

                    displayList.Add(new NhanVienLuongModel
                    {
                        Id = u.Id,
                        Username = u.Username,
                        FullName = u.FullName,
                        Role = u.Role,
                        HourlyRate = u.HourlyRate ?? 0m,
                        IsActive = u.IsActive ?? false,
                        TongGioLam = Math.Round(tongGio, 2),
                        TongLuong = tongLuong,
                        TrangThaiLuong = trangThai
                    });
                }

                // Chạy thanh tìm kiếm
                string keyword = txtTimKiem.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(keyword))
                {
                    displayList = displayList.Where(x => x.Username.ToLower().Contains(keyword) || x.FullName.ToLower().Contains(keyword)).ToList();
                }

                dgvNhanVien.DataSource = displayList;
                CustomGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void CustomGridView()
        {
            if (dgvNhanVien.Columns["Id"] != null) dgvNhanVien.Columns["Id"].Visible = false;

            if (dgvNhanVien.Columns["Username"] != null) dgvNhanVien.Columns["Username"].HeaderText = "Tài Khoản";
            if (dgvNhanVien.Columns["FullName"] != null) dgvNhanVien.Columns["FullName"].HeaderText = "Họ và Tên";
            if (dgvNhanVien.Columns["Role"] != null) dgvNhanVien.Columns["Role"].HeaderText = "Chức Vụ";

            if (dgvNhanVien.Columns["HourlyRate"] != null)
            {
                dgvNhanVien.Columns["HourlyRate"].HeaderText = "Lương/Giờ (₫)";
                dgvNhanVien.Columns["HourlyRate"].DefaultCellStyle.Format = "N0";
            }

            if (dgvNhanVien.Columns["IsActive"] != null) dgvNhanVien.Columns["IsActive"].HeaderText = "Trạng Thái";

            if (dgvNhanVien.Columns["TongGioLam"] != null) dgvNhanVien.Columns["TongGioLam"].HeaderText = "Tổng Giờ";
            if (dgvNhanVien.Columns["TongLuong"] != null)
            {
                dgvNhanVien.Columns["TongLuong"].HeaderText = "Tổng Lương (₫)";
                dgvNhanVien.Columns["TongLuong"].DefaultCellStyle.Format = "N0";
            }
            if (dgvNhanVien.Columns["TrangThaiLuong"] != null) dgvNhanVien.Columns["TrangThaiLuong"].HeaderText = "Tình Trạng Lương";
        }


        // =======================================================
        // 3. NGHIỆP VỤ TRẢ LƯƠNG & XỬ LÝ NÚT
        // =======================================================
        private void btnTraLuongCaNhan_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để trả lương!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 👉 CHỐT CHẶN 1: KHÔNG ĐƯỢC CHỐT LƯƠNG SỚM
            if (dtpDenNgay.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("NGUYÊN TẮC KẾ TOÁN: Không thể chốt lương cho kỳ chưa kết thúc!\nNhân viên vẫn có thể phát sinh giờ làm trong hôm nay hoặc các ngày tới. Vui lòng chọn 'Đến ngày' là một ngày trong quá khứ.", "Khóa Chốt Lương", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string status = dgvNhanVien.CurrentRow.Cells["TrangThaiLuong"].Value.ToString();
            if (status == "Đã trả")
            {
                MessageBox.Show("Kỳ lương này của nhân viên đã được thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal luong = Convert.ToDecimal(dgvNhanVien.CurrentRow.Cells["TongLuong"].Value);
            if (luong <= 0)
            {
                MessageBox.Show("Nhân viên này không có giờ làm việc hoặc lương bằng 0 trong kỳ này!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int uid = Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["Id"].Value);
            string fname = dgvNhanVien.CurrentRow.Cells["FullName"].Value.ToString();
            DateTime from = dtpTuNgay.Value.Date;
            DateTime to = dtpDenNgay.Value.Date;

            if (MessageBox.Show($"Xác nhận xuất quỹ trả {luong:N0} ₫ cho {fname}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ThucHienTraLuong(uid, fname, luong, from, to))
                {
                    MessageBox.Show("Thanh toán lương thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }
        private void btnTraLuongTatCa_Click(object sender, EventArgs e)
        {
            var list = dgvNhanVien.DataSource as List<NhanVienLuongModel>;
            if (list == null || list.Count == 0) return;

            // 👉 CHỐT CHẶN 1: KHÔNG ĐƯỢC CHỐT LƯƠNG SỚM
            if (dtpDenNgay.Value.Date >= DateTime.Now.Date)
            {
                MessageBox.Show("NGUYÊN TẮC KẾ TOÁN: Không thể chốt lương hàng loạt cho kỳ chưa kết thúc!\nVui lòng chọn 'Đến ngày' là một ngày trong quá khứ (ví dụ: ngày cuối cùng của tháng trước).", "Khóa Chốt Lương", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Tìm những người chưa trả và có lương > 0
            var toPay = list.Where(x => x.TrangThaiLuong == "Chưa trả" && x.TongLuong > 0).ToList();
            if (toPay.Count == 0)
            {
                MessageBox.Show("Không có nhân viên nào cần trả lương trong danh sách hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Bạn sắp thanh toán lương cho {toPay.Count} nhân viên.\nTổng tiền xuất quỹ: {toPay.Sum(x => x.TongLuong):N0} ₫\n\nXác nhận tiếp tục?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DateTime from = dtpTuNgay.Value.Date;
                DateTime to = dtpDenNgay.Value.Date;
                int successCount = 0;

                foreach (var emp in toPay)
                {
                    if (ThucHienTraLuong(emp.Id, emp.FullName, emp.TongLuong, from, to))
                    {
                        successCount++;
                    }
                }

                MessageBox.Show($"Đã trả lương thành công cho {successCount}/{toPay.Count} nhân viên!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        // =======================================================
        // 4. HÀM GIAO TIẾP DATABASE (PAYROLL)
        // =======================================================
        private decimal TinhTongGioLam(int userId, DateTime tuNgay, DateTime denNgay)
        {
            const string sql = @"
                SELECT SUM(DATEDIFF(MINUTE, CheckInTime, CheckOutTime)) 
                FROM Attendance 
                WHERE UserId = @uid 
                  AND WorkDate >= @tuNgay AND WorkDate <= @denNgay 
                  AND CheckOutTime IS NOT NULL";

            var parameters = new[] {
                new SqlParameter("@uid", SqlDbType.Int) { Value = userId },
                new SqlParameter("@tuNgay", SqlDbType.Date) { Value = tuNgay },
                new SqlParameter("@denNgay", SqlDbType.Date) { Value = denNgay }
            };

            DataTable dt = DBConnection.GetDataTable(sql, parameters);
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                return Convert.ToInt32(dt.Rows[0][0]) / 60m;
            }
            return 0m;
        }

        private bool KiemTraDaTraLuong(int userId, DateTime tuNgay, DateTime denNgay)
        {
            // Cấu trúc tag ngầm định để check xem khoảng thời gian này đã thanh toán chưa
            string noteTag = $"PAYROLL_{tuNgay:yyyyMMdd}_{denNgay:yyyyMMdd}_{userId}";
            const string sql = "SELECT COUNT(*) FROM Expense WHERE Note = @note";

            var p = new SqlParameter("@note", SqlDbType.NVarChar) { Value = noteTag };
            return Convert.ToInt32(DBConnection.GetDataTable(sql, new[] { p }).Rows[0][0]) > 0;
        }

        private bool ThucHienTraLuong(int userId, string fullName, decimal amount, DateTime tuNgay, DateTime denNgay)
        {
            int adminId = UserSession.CurrentUser != null ? UserSession.CurrentUser.Id : 1;
            string noteTag = $"PAYROLL_{tuNgay:yyyyMMdd}_{denNgay:yyyyMMdd}_{userId}";
            string expenseName = $"Trả lương: {fullName} (Kỳ {tuNgay:dd/MM} - {denNgay:dd/MM})";

            const string sql = @"
                INSERT INTO Expense (ExpenseName, Amount, ExpenseDate, Note, UserId) 
                VALUES (@name, @amount, GETDATE(), @note, @uid)";

            var parameters = new[] {
                new SqlParameter("@name", SqlDbType.NVarChar, 150) { Value = expenseName },
                new SqlParameter("@amount", SqlDbType.Decimal) { Value = amount },
                new SqlParameter("@note", SqlDbType.NVarChar, 300) { Value = noteTag },
                new SqlParameter("@uid", SqlDbType.Int) { Value = adminId }
            };

            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        // =======================================================
        // 5. CÁC NGHIỆP VỤ CRUD QUẢN LÝ NHÂN VIÊN (GIỮ NGUYÊN)
        // =======================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = new User
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Role = cboRole.SelectedItem.ToString(),
                HourlyRate = nmHourlyRate.Value,
                IsActive = chkIsActive.Checked
            };

            if (_userController.AddUser(user))
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnLamMoi_Click(null, null);
            }
            else MessageBox.Show("Thêm thất bại. Có thể tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = new User
            {
                Id = Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["Id"].Value),
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Role = cboRole.SelectedItem?.ToString() ?? "STAFF",
                HourlyRate = nmHourlyRate.Value,
                IsActive = chkIsActive.Checked
            };

            if (_userController.UpdateUser(user))
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                txtPassword.Clear();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["Id"].Value);
            string username = dgvNhanVien.CurrentRow.Cells["Username"].Value.ToString();

            if (UserSession.CurrentUser != null && UserSession.CurrentUser.Id == id)
            {
                MessageBox.Show("Bạn không thể xóa chính tài khoản đang đăng nhập!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa/vô hiệu hóa tài khoản '{username}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_userController.DeleteUser(id))
                {
                    LoadData();
                    btnLamMoi_Click(null, null);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            cboRole.SelectedIndex = 1;
            nmHourlyRate.Value = 0;
            chkIsActive.Checked = true;
            txtTimKiem.Clear();

            cboKyTinhLuong.SelectedIndex = 0;
            cboTrangThaiLuong.SelectedIndex = 0;
            LoadData();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                txtUsername.Text = row.Cells["Username"].Value?.ToString();
                txtPassword.Clear();
                txtFullName.Text = row.Cells["FullName"].Value?.ToString();

                string role = row.Cells["Role"].Value?.ToString();
                if (cboRole.Items.Contains(role)) cboRole.SelectedItem = role;

                nmHourlyRate.Value = Convert.ToDecimal(row.Cells["HourlyRate"].Value ?? 0);
                chkIsActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value ?? true);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadData(); // Chạy lại hàm LoadData (đã có tích hợp search ở dòng 123)
        }
    }
}
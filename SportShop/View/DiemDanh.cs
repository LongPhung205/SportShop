using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SportShop.Controller;
using SportShop.Model;

namespace SportShop.View
{
    public partial class DiemDanh : UserControl
    {
        private QuanLyNhanVienController _nhanVienController;
        private QuanLyNguoiDungController _nguoiDungController = new QuanLyNguoiDungController();

        public DiemDanh()
        {
            InitializeComponent();
            _nhanVienController = new QuanLyNhanVienController();
        }

        private void DiemDanh_Load(object sender, EventArgs e)
        {
            SetupLichSuGrid();
            TaiDanhSachHomNay();
        }

        private void SetupLichSuGrid()
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDanhSach.AllowUserToAddRows = false;
            dgvDanhSach.ReadOnly = true;
            dgvDanhSach.RowHeadersVisible = false;
            dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 👉 ĐÃ FIX: Bổ sung thêm Name = "..." cho tất cả các cột
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "FullName", DataPropertyName = "FullName", HeaderText = "Họ Tên Nhân Viên" });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "Role", DataPropertyName = "Role", HeaderText = "Chức Vụ" });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "CheckInTime", DataPropertyName = "CheckInTime", HeaderText = "Giờ Vào Ca", DefaultCellStyle = { Format = "HH:mm:ss" } });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "CheckOutTime", DataPropertyName = "CheckOutTime", HeaderText = "Giờ Ra Ca", DefaultCellStyle = { Format = "HH:mm:ss" } });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng Thái Hôm Nay" });

            // Cột ẩn chứa Username để tiện auto-fill
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "Username", DataPropertyName = "Username", Visible = false });
        }

        private void TaiDanhSachHomNay()
        {
            // Đổi sang dùng _nguoiDungController
            DateTime selectedDate = calDiemDanh.SelectionStart; // Lấy ngày đang chọn trên lịch
            lblTitle.Text = $"CHI TIẾT CHẤM CÔNG NGÀY {selectedDate.ToString("dd/MM/yyyy")}";
            DataTable dt = _nguoiDungController.GetBangChamCongTheoNgay(selectedDate);
            dgvDanhSach.DataSource = dt;
            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                if (row.Cells["CheckInTime"].Value == DBNull.Value)
                {
                    row.Cells["TrangThai"].Value = "🔴 Chưa vào ca";
                    row.Cells["TrangThai"].Style.ForeColor = System.Drawing.Color.Red;
                }
                else if (row.Cells["CheckOutTime"].Value == DBNull.Value)
                {
                    row.Cells["TrangThai"].Value = "🟢 Đang trong ca";
                    row.Cells["TrangThai"].Style.ForeColor =  System.Drawing.Color.Green;
                    row.Cells["TrangThai"].Style.Font = new Font(dgvDanhSach.Font, FontStyle.Bold);
                }
                else
                {
                    row.Cells["TrangThai"].Value = "⚪ Đã kết thúc ca";
                    row.Cells["TrangThai"].Style.ForeColor = System.Drawing.Color.Gray;
                }
            }

            txtPassword.Clear();
        }

        // Tự động điền Username khi click vào người đó trong bảng
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtUsername.Text = dgvDanhSach.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                txtPassword.Focus(); // Nhảy con trỏ xuống ô mật khẩu cho tiện
            }
        }

        private void calDiemDanh_DateChanged(object sender, DateRangeEventArgs e)
        {
            TaiDanhSachHomNay();
        }
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            XyLyChamCong(isCheckIn: true);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            XyLyChamCong(isCheckIn: false);
        }

        // Hàm xử lý chung (Xác thực -> Gọi Controller -> Thông báo)
        private void XyLyChamCong(bool isCheckIn)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tài khoản và Mật khẩu!", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 👉 SỬA Ở ĐÂY: Dùng hàm Login của QuanLyNguoiDungController để BCrypt có thể giải mã đúng!
            User user = _nguoiDungController.Login(username, password);

            if (user == null)
            {
                MessageBox.Show("Sai mật khẩu hoặc tài khoản không tồn tại!", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Từ đây trở xuống gọi QuanLyNhanVienController để CheckIn/Out như bình thường
            if (isCheckIn)
            {
                if (_nhanVienController.CheckIn(user.Id))
                {
                    MessageBox.Show($"Xin chào {user.FullName}. Bạn đã Check-in thành công lúc {DateTime.Now:HH:mm}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachHomNay();
                }
                else MessageBox.Show("Bạn đã Check-in trong hôm nay rồi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else // Check-out
            {
                if (_nhanVienController.CheckOut(user.Id))
                {
                    MessageBox.Show($"Tạm biệt {user.FullName}. Đã Check-out thành công lúc {DateTime.Now:HH:mm}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachHomNay();
                }
                else MessageBox.Show("Check-out thất bại! Có thể bạn chưa Check-in hoặc đã Check-out rồi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlAuth_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
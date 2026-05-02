using SportShop.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SportShop.View
{
    public partial class MainMenu : Form
    {
        private Button btnDangXuat;

        public MainMenu()
        {
            InitializeComponent();
            InitializeDynamicControls();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

            if (UserSession.CurrentUser == null)
            {
                UserSession.CurrentUser = new User
                {
                    Id = 1,
                    Username = "admin",
                    FullName = "Admin Test",
                    Role = "Admin"
                };
            }

            UpdateAuthButtons();
            LoadControl(new TrangChu()); // Mặc định load trang chủ
        }

        private void InitializeDynamicControls()
        {
            btnDangXuat = new Button
            {
                Anchor = (AnchorStyles.Top | AnchorStyles.Right),
                Font = btnDangNhap.Font,
                Size = btnDangNhap.Size,
                Location = btnDangNhap.Location,
                Text = "Đăng xuất",
                Visible = false,
                BackColor = System.Drawing.Color.FromArgb(220, 53, 69), // Màu đỏ cho nút đăng xuất (Tùy chọn)
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat
            };
            btnDangXuat.FlatAppearance.BorderSize = 0;
            btnDangXuat.Click += BtnDangXuat_Click;

            panelTop.Controls.Add(btnDangXuat);
            btnDangXuat.BringToFront();
        }

        private void UpdateAuthButtons()
        {
            bool loggedIn = UserSession.CurrentUser != null;
            btnDangNhap.Visible = !loggedIn;
            btnDangXuat.Visible = loggedIn;

            if (loggedIn)
            {
                // Ưu tiên hiển thị FullName theo chuẩn DB mới
                string tenHienThi = string.IsNullOrWhiteSpace(UserSession.CurrentUser.FullName)
                                    ? UserSession.CurrentUser.Username
                                    : UserSession.CurrentUser.FullName;

                this.Text = $"Quản Lý Bán Đồ Thể Thao - Xin chào: {tenHienThi} ({UserSession.CurrentUser.Role})";
            }
            else
            {
                this.Text = "Quản Lý Bán Đồ Thể Thao";
            }

            ApplyRolePermissions();
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            using (var loginForm = new Login())
            {
                loginForm.ShowDialog(this);
            }
            UpdateAuthButtons();
        }

        public void ApplyRolePermissions()
        {
            // Nếu muốn làm chuẩn UX, bạn có thể Tắt (Disable) các nút mà STAFF không được ấn ở đây.
            // Hiện tại dùng CheckPermission() chặn lúc Click cũng đã rất an toàn.
            btnQuanLyHoaDon.Enabled = true;
            btnQuanLySanPham.Enabled = true;
            btnQuanLyKhachHang.Enabled = true;
            btnQuanLyNhanVien.Enabled = true;
            btnThongKeBaoCao.Enabled = true;
            btnLoaiSP.Enabled = true;
            button1.Enabled = true;
        }

        private void BtnDangXuat_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;

            // Dọn dẹp Session
            UserSession.Logout();
            this.Hide();

            // Dùng 'using' để giải phóng bộ nhớ Form Login sau khi dùng xong
            using (Login loginForm = new Login())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Code đã được dọn sạch, xóa các dòng lặp vô lý
                    panelMain.Controls.Clear();
                    UpdateAuthButtons();
                    LoadControl(new TrangChu());
                    this.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private bool CheckPermission(string requiredRole = "")
        {
            if (UserSession.CurrentUser == null)
            {
                MessageBox.Show("Vui lòng đăng nhập để sử dụng chức năng này!", "Yêu cầu đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                using (var loginForm = new Login())
                {
                    loginForm.ShowDialog(this);
                }

                if (UserSession.CurrentUser == null) return false;

                UpdateAuthButtons();
            }

            if (!string.IsNullOrEmpty(requiredRole) && !UserSession.CurrentUser.Role.Equals(requiredRole, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Bạn không đủ quyền để truy cập vào chức năng này!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        private void LoadControl(UserControl uc)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
            uc.BringToFront();
        }

        // ==========================================
        // CÁC SỰ KIỆN CLICK MENU
        // ==========================================

        private void btnTrangchu_Click(object sender, EventArgs e)
        {
            if (CheckPermission())
            {
                LoadControl(new TrangChu());
            }
        }

        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            if (CheckPermission())
            {
                LoadControl(new QuanLyHoaDon());
            }
        }

        private void btnQuanLySanPham_Click_1(object sender, EventArgs e)
        {
            if (CheckPermission("Admin"))
            {
                LoadControl(new QuanLySanPham());
            }
        }

        private void btnQuanLyKho_Click(object sender, EventArgs e)
        {
            if (CheckPermission("Admin"))
            {
                // Đã xóa tiền tố PMQLBanDoTheThao.View. bị nhầm
                LoadControl(new QuanLyKho());
            }
        }

        private void btnLoaiSP_Click(object sender, EventArgs e)
        {
            if (CheckPermission("Admin"))
            {
                LoadControl(new QuanLyLoaiSanPham());
            }
        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            if (CheckPermission("Admin"))
            {

                LoadControl(new QuanLyKhachHang());
            }
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            if (CheckPermission("Admin"))
            {
                LoadControl(new QuanLyNhanVien());
            }
        }

        private void button1_Click(object sender, EventArgs e) // Nút quản lý Voucher
        {
            if (CheckPermission("Admin"))
            {
                LoadControl(new QuanLyVoucher());
            }
        }

        private void btnThongKeBaoCao_Click(object sender, EventArgs e)
        {
            if (CheckPermission("Admin"))
            {
                LoadControl(new ThongKeBaoCao());
            }
        }

        // ==========================================
        // HÀM HỖ TRỢ ĐIỀU HƯỚNG TỪ FORM KHÁC
        // ==========================================
        public void ChuyenSangTrangHoaDon(int productId)
        {
            if (CheckPermission())
            {
                LoadControl(new QuanLyHoaDon(productId));
            }
        }
        public void ChuyenSangTrangHoaDonTuGioHang()
        {
            if (CheckPermission())
            {
                // Gọi form hóa đơn, Form hóa đơn sẽ tự động chui vào class CartManager.CurrentCart để moi dữ liệu ra
                LoadControl(new QuanLyHoaDon());
            }
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            if (CheckPermission())
            {
                // Gọi form hóa đơn, Form hóa đơn sẽ tự động chui vào class CartManager.CurrentCart để moi dữ liệu ra
                LoadControl(new DiemDanh());
            }
        }
    }
}
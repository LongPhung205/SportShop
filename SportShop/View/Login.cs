using SportShop.Controller;
using SportShop.Model;
using System;
using System.Windows.Forms;

namespace SportShop.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu và làm sạch khoảng trắng
            string user = txtUserName.Text.Trim();
            string pass = txtPassword.Text.Trim();

            // 2. Kiểm tra dữ liệu rỗng tại tầng Giao diện (View)
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Gọi Controller xử lý 
            // (Lưu ý: Đổi tên Controller cho khớp với file bạn đang dùng, ở đây mình ví dụ là QuanLyNguoiDungController)
            QuanLyNguoiDungController ctrl = new QuanLyNguoiDungController();

            // Hứng kết quả trả về là một đối tượng User
            User loggedInUser = ctrl.Login(user, pass);

            // Kiểm tra xem User có tồn tại không (khác null)
            if (loggedInUser != null)
            {
                // Gán thông tin người dùng vào Session tĩnh để lưu trạng thái đăng nhập
                UserSession.CurrentUser = loggedInUser;

                // Ưu tiên hiển thị FullName, nếu không có thì hiển thị Username
                string tenHienThi = string.IsNullOrWhiteSpace(UserSession.CurrentUser.FullName)
                                    ? UserSession.CurrentUser.Username
                                    : UserSession.CurrentUser.FullName;

                MessageBox.Show($"Chào mừng {tenHienThi} quay trở lại!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gán kết quả OK và đóng Form Login lại để Form MainMenu được hiển thị
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Đăng nhập thất bại (Trả về null do sai User, sai Pass, hoặc tài khoản bị khóa)
                MessageBox.Show("Tên đăng nhập, mật khẩu không chính xác hoặc tài khoản đã bị khóa!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Trả về Cancel để Program.cs biết là người dùng chủ động hủy đăng nhập và tắt hẳn App
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Hỗ trợ nhấn phím Enter để đăng nhập nhanh thay vì phải dùng chuột
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnLogIn.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
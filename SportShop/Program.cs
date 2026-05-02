using SportShop.View; // Nhớ thêm using thư mục chứa View của bạn
using System;
using System.Windows.Forms;

namespace SportShop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Khởi tạo và hiển thị Form Đăng nhập TRƯỚC (Dùng ShowDialog để tạm dừng code, chờ người dùng thao tác)
            Login frmLogin = new Login();

            // 2. Kiểm tra tín hiệu trả về từ Form Đăng nhập
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                // 3. Nếu đăng nhập thành công (nhận được OK), bắt đầu chạy vòng đời chính của ứng dụng với Form MainMenu
                Application.Run(new View.MainMenu());
            }
            else
            {
                // Nếu bấm nút X trên cùng góc phải hoặc nút Thoát (nhận được Cancel), thoát ứng dụng
                Application.Exit();
            }
        }
    }
}
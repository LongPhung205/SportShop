using SportShop.Model;
using System;

namespace SportShop.Model
{
    public static class UserSession
    {
        // Biến tĩnh này sẽ lưu trữ thông tin User trong suốt quá trình ứng dụng chạy
        public static User CurrentUser { get; set; }

        // Hàm gọi khi đăng xuất
        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
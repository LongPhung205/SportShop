namespace SportShop.Model
{
    public class ThongKeSanPham
    {
        public string TenSanPham { get; set; }   // Tên đầy đủ (Sản phẩm + Size + Màu)
        public int SoLuong { get; set; }         // Số lượng bán ra hoặc số lượng tồn kho
        public decimal TongTien { get; set; }    // Tổng doanh thu mang về từ sản phẩm này

        public ThongKeSanPham() { }

        public ThongKeSanPham(string tenSanPham, int soLuong, decimal tongTien = 0)
        {
            TenSanPham = tenSanPham;
            SoLuong = soLuong;
            TongTien = tongTien;
        }
    }
}
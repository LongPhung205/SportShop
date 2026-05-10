namespace SportShop.Model
{
    public class TongQuanTaiChinh
    {
        public decimal TongDoanhThu { get; set; }      // Tổng tiền thu từ hóa đơn bán lẻ
        public decimal TongTienNhapHang { get; set; }  // Giữ nguyên tên gốc của bạn (Sẽ dùng để chứa Giá vốn hàng bán)
        public decimal TongChiPhiKhac { get; set; }    // Các chi phí phát sinh (tiền điện, nước, mặt bằng...)

        // Thuộc tính gốc của bạn
        public decimal LoiNhuanThuan => TongDoanhThu - TongTienNhapHang - TongChiPhiKhac;

        // ==============================================================
        // 👉 BỔ SUNG CÁC THUỘC TÍNH NÀY CHO MÀN HÌNH THỐNG KÊ (VIEW) VÀ EXCEL
        // ==============================================================

        // 1. Lợi nhuận gộp = Doanh thu - Giá vốn (TongTienNhapHang)
        public decimal LoiNhuanGop => TongDoanhThu - TongTienNhapHang;

        // 2. Tổng tất cả các loại chi phí
        public decimal TongChiPhi => TongTienNhapHang + TongChiPhiKhac;

        // 3. Lợi Nhuận Ròng (Lấy luôn kết quả từ LoiNhuanThuan của bạn cho nhanh)
        public decimal LoiNhuanRong => LoiNhuanThuan;

        public TongQuanTaiChinh() { }

        public TongQuanTaiChinh(decimal thu, decimal nhap, decimal chiPhiKhac)
        {
            TongDoanhThu = thu;
            TongTienNhapHang = nhap;
            TongChiPhiKhac = chiPhiKhac;
        }
    }
}
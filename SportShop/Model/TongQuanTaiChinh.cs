namespace SportShop.Model
{
    public class TongQuanTaiChinh
    {
        public decimal TongDoanhThu { get; set; }      // Tổng tiền thu từ hóa đơn bán lẻ
        public decimal TongTienNhapHang { get; set; }  // Tổng tiền chi từ phiếu nhập hàng
        public decimal TongChiPhiKhac { get; set; }    // Các chi phí phát sinh (tiền điện, nước, mặt bằng...)

        // Thuộc tính tính toán Lợi Nhuận Thuần (Code gốc của bạn)
        public decimal LoiNhuanThuan => TongDoanhThu - TongTienNhapHang - TongChiPhiKhac;

        // ==============================================================
        // 👉 BỔ SUNG 2 THUỘC TÍNH NÀY CHO MÀN HÌNH THỐNG KÊ (VIEW)
        // ==============================================================
        public decimal TongChiPhi => TongTienNhapHang + TongChiPhiKhac;
        public decimal LoiNhuanRong => LoiNhuanThuan; // Lấy luôn giá trị của Lợi Nhuận Thuần

        public TongQuanTaiChinh() { }

        public TongQuanTaiChinh(decimal thu, decimal nhap, decimal chiPhiKhac)
        {
            TongDoanhThu = thu;
            TongTienNhapHang = nhap;
            TongChiPhiKhac = chiPhiKhac;
        }
    }
}
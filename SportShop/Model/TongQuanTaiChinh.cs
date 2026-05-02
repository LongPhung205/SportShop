namespace SportShop.Model
{
    public class TongQuanTaiChinh
    {
        public decimal TongDoanhThu { get; set; }      // Tổng tiền thu từ hóa đơn bán lẻ
        public decimal TongTienNhapHang { get; set; }  // Tổng tiền chi từ phiếu nhập hàng
        public decimal TongChiPhiKhac { get; set; }    // Các chi phí phát sinh (tiền điện, nước, mặt bằng...)

        // Thuộc tính tính toán Lợi Nhuận Thuần
        public decimal LoiNhuanThuan => TongDoanhThu - TongTienNhapHang - TongChiPhiKhac;

        public TongQuanTaiChinh() { }

        public TongQuanTaiChinh(decimal thu, decimal nhap, decimal chiPhiKhac)
        {
            TongDoanhThu = thu;
            TongTienNhapHang = nhap;
            TongChiPhiKhac = chiPhiKhac;
        }
    }
}
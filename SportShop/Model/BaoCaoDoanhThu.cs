using System;

namespace SportShop.Model
{
    public class BaoCaoDoanhThu
    {
        public DateTime Ngay { get; set; }
        public int SoLuongDon { get; set; }
        public decimal TongDoanhThu { get; set; }
        public decimal LoiNhuan { get; set; }
        public BaoCaoDoanhThu() { }

        public BaoCaoDoanhThu(DateTime ngay, int soLuongDon, decimal tongDoanhThu, decimal loiNhuan)
        {
            Ngay = ngay;
            SoLuongDon = soLuongDon;
            TongDoanhThu = tongDoanhThu;
            LoiNhuan = loiNhuan;
        }
    }
}
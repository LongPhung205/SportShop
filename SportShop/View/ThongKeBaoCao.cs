using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SportShop.Controller;
using SportShop.Model;
using ClosedXML.Excel;

namespace SportShop.View
{
    public partial class ThongKeBaoCao : UserControl
    {
        private ThongKeBaoCaoController _controller = new ThongKeBaoCaoController();
        private Timer _timerRealtime;

        public ThongKeBaoCao()
        {
            InitializeComponent();
            SetupRealtimeTimer();
        }

        private void SetupRealtimeTimer()
        {
            _timerRealtime = new Timer();
            _timerRealtime.Interval = 30000; // Tự động làm mới mỗi 30s
            _timerRealtime.Tick += (s, e) =>
            {
                // Chỉ auto-refresh nếu bộ lọc bao gồm ngày hôm nay
                if (dtpDenNgay.Value.Date >= DateTime.Now.Date)
                {
                    LoadDashboardData();
                }
            };
        }

        private void ThongKeBaoCao_Load(object sender, EventArgs e)
        {
            // Thiết lập mặc định
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            // Nhãn chuẩn Kế toán
            label1.Text = "TỔNG DOANH THU ";
            label3.Text = "GIÁ VỐN VÀ CHI PHÍ";
            label5.Text = "LỢI NHUẬN RÒNG (NET PROFIT)";

            LoadDashboardData();
            _timerRealtime.Start();
        }

        private void ThongKeBaoCao_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) _timerRealtime.Start();
            else _timerRealtime.Stop();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadDashboardData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        // ==============================================================
        // HÀM ĐIỀU PHỐI CHÍNH (Đã được chia nhỏ để code "sạch" hơn)
        // ==============================================================
        public void LoadDashboardData()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1); // Lấy hết ngày

                UpdateOverviewCards(tuNgay, denNgay);
                UpdateCharts(tuNgay, denNgay);
                UpdateDetailGrids(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu Thống kê: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --------------------------------------------------------------
        // 1. CẬP NHẬT CÁC THẺ CARD TỔNG QUAN TÀI CHÍNH
        // --------------------------------------------------------------
        private void UpdateOverviewCards(DateTime tuNgay, DateTime denNgay)
        {
            TongQuanTaiChinh hienTai = _controller.GetTongQuanTaiChinh(tuNgay, denNgay);

            lblTongDoanhThu.Text = hienTai.TongDoanhThu.ToString("N0") + " ₫";
            lblTongDon.Text = hienTai.TongChiPhi.ToString("N0") + " ₫";
            lblTongKhachHang.Text = hienTai.LoiNhuanRong.ToString("N0") + " ₫";
            lblTongKhachHang.ForeColor = hienTai.LoiNhuanRong < 0 ? System.Drawing.Color.Red : System.Drawing.Color.FromArgb(40, 167, 69);

            // Tính toán tháng trước để so sánh
            TimeSpan khoangThoiGian = denNgay - tuNgay;
            DateTime tuNgayTruoc = tuNgay.AddDays(-khoangThoiGian.TotalDays);
            DateTime denNgayTruoc = tuNgay.AddTicks(-1);

            TongQuanTaiChinh kyTruoc = _controller.GetTongQuanTaiChinh(tuNgayTruoc, denNgayTruoc);

            HienThiSoSanh(lblSoSanhDoanhThu, hienTai.TongDoanhThu, kyTruoc.TongDoanhThu);
            HienThiSoSanh(lblSoSanhChiPhi, hienTai.TongChiPhi, kyTruoc.TongChiPhi);
            HienThiSoSanh(lblSoSanhLoiNhuan, hienTai.LoiNhuanRong, kyTruoc.LoiNhuanRong);
        }

        // --------------------------------------------------------------
        // 2. VẼ BIỂU ĐỒ (TAB 1)
        // --------------------------------------------------------------
        private void UpdateCharts(DateTime tuNgay, DateTime denNgay)
        {
            // A. Biểu đồ Kép (Doanh thu & Lợi nhuận)
            List<BaoCaoDoanhThu> dtNgay = _controller.GetDoanhThuLoiNhuanTheoNgay(tuNgay, denNgay);
            chartDoanhThu.Series.Clear();

            Series sDoanhThu = new Series("Doanh Thu") { ChartType = SeriesChartType.Column, Color = System.Drawing.Color.FromArgb(0, 123, 255), IsValueShownAsLabel = true, LabelFormat = "{0:N0}" };
            Series sLoiNhuan = new Series("Lợi Nhuận Gộp") { ChartType = SeriesChartType.Spline, BorderWidth = 3, Color = System.Drawing.Color.FromArgb(40, 167, 69), MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle, MarkerSize = 8, IsValueShownAsLabel = true, LabelFormat = "{0:N0}" };

            foreach (var item in dtNgay)
            {
                string labelNgay = item.Ngay.ToString("dd/MM");
                sDoanhThu.Points.AddXY(labelNgay, item.TongDoanhThu);
                sLoiNhuan.Points.AddXY(labelNgay, item.LoiNhuan);
            }

            chartDoanhThu.Series.Add(sDoanhThu);
            chartDoanhThu.Series.Add(sLoiNhuan);
            chartDoanhThu.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartDoanhThu.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;

            // B. Biểu đồ Tròn (Top Sản Phẩm)
            List<ThongKeSanPham> topSP = _controller.GetTopSanPhamBanChay(5, tuNgay, denNgay);
            chartTopSP.Series.Clear();
            Series seriesTopSP = new Series("TopSanPham") { ChartType = SeriesChartType.Doughnut, IsValueShownAsLabel = true };

            foreach (var sp in topSP)
            {
                seriesTopSP.Points.AddXY(sp.TenSanPham, sp.SoLuong);
            }
            chartTopSP.Series.Add(seriesTopSP);
        }

        // --------------------------------------------------------------
        // 3. ĐỔ DỮ LIỆU & FORMAT LƯỚI (TAB 2)
        // --------------------------------------------------------------
        private void UpdateDetailGrids(DateTime tuNgay, DateTime denNgay)
        {
            // Bảng 1: Chi tiết Hóa đơn
            dgvChiTietHoaDon.DataSource = _controller.GetChiTietHoaDon(tuNgay, denNgay);
            if (dgvChiTietHoaDon.Columns.Count > 0)
            {
                dgvChiTietHoaDon.Columns["Doanh Thu"].DefaultCellStyle.Format = "N0";
                dgvChiTietHoaDon.Columns["Giá Vốn (Trừ Kho)"].DefaultCellStyle.Format = "N0";
                dgvChiTietHoaDon.Columns["Lợi Nhuận"].DefaultCellStyle.Format = "N0";
                dgvChiTietHoaDon.Columns["Lợi Nhuận"].DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
                dgvChiTietHoaDon.Columns["Lợi Nhuận"].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            }

            // Bảng 2: Top Khách Hàng
            dgvTopKhachHang.DataSource = _controller.GetTopKhachHang(5, tuNgay, denNgay);
            if (dgvTopKhachHang.Columns.Count > 0)
            {
                dgvTopKhachHang.Columns["TongChiTieu"].DefaultCellStyle.Format = "N0";
            }

            // Bảng 3: Cảnh báo tồn kho
            dgvTonKhoThap.DataSource = _controller.GetSanPhamTonKhoThap(10);
            if (dgvTonKhoThap.Columns.Count > 0)
            {
                dgvTonKhoThap.Columns["Quantity"].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                dgvTonKhoThap.Columns["Quantity"].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
                dgvTonKhoThap.Columns["Quantity"].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // ==============================================================
        // HÀM HELPER: TÍNH % SO SÁNH VÀ ĐỔI MÀU LABEL
        // ==============================================================
        private void HienThiSoSanh(Label lbl, decimal hienTai, decimal kyTruoc)
        {
            if (kyTruoc == 0)
            {
                lbl.Text = hienTai > 0 ? "▲ 100%" : "-";
                lbl.ForeColor = hienTai > 0 ? System.Drawing.Color.FromArgb(40, 167, 69) : System.Drawing.Color.Gray;
                return;
            }

            decimal phanTram = ((hienTai - kyTruoc) / kyTruoc) * 100;

            if (phanTram > 0)
            {
                lbl.Text = $"▲ {phanTram:F1}% so với kỳ trước";
                lbl.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69); // Xanh lá
            }
            else if (phanTram < 0)
            {
                lbl.Text = $"▼ {Math.Abs(phanTram):F1}% so với kỳ trước";
                lbl.ForeColor = System.Drawing.Color.Red; // Đỏ
            }
            else
            {
                lbl.Text = "Tương đương kỳ trước";
                lbl.ForeColor = System.Drawing.Color.Gray; // Xám
            }
        }

        // ==============================================================
        // XUẤT EXCEL 3 SHEET CHUYÊN NGHIỆP
        // ==============================================================
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = $"BaoCao_ChiTiet_HoaDon_{DateTime.Now:ddMMyyyy}.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var wsHoaDon = workbook.Worksheets.Add("Chi Tiết Hóa Đơn");

                            DateTime tuNgay = dtpTuNgay.Value.Date;
                            DateTime denNgay = dtpDenNgay.Value.Date;

                            // 1. Lấy dữ liệu Hóa đơn (Bảng chi tiết)
                            DataTable dtHoaDon = _controller.GetChiTietHoaDon(tuNgay, denNgay);

                            // 2. Lấy dữ liệu Tổng quan (Để có biến Lương, Chi phí phát sinh)
                            TongQuanTaiChinh tq = _controller.GetTongQuanTaiChinh(tuNgay, denNgay.AddDays(1).AddTicks(-1));

                            if (dtHoaDon.Rows.Count > 0)
                            {
                                // --- PHẦN 1: BẢNG CHI TIẾT ---
                                var titleHD = wsHoaDon.Range(1, 1, 2, dtHoaDon.Columns.Count);
                                titleHD.Merge().Value = $"BẢNG KÊ CHI TIẾT HÓA ĐƠN TỪ {tuNgay:dd/MM/yyyy} ĐẾN {denNgay:dd/MM/yyyy}";
                                titleHD.Style.Font.Bold = true;
                                titleHD.Style.Font.FontSize = 14;
                                titleHD.Style.Font.FontColor = XLColor.White;
                                titleHD.Style.Fill.BackgroundColor = XLColor.FromHtml("#17a2b8");
                                titleHD.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                titleHD.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                var table = wsHoaDon.Cell(4, 1).InsertTable(dtHoaDon);
                                table.Theme = XLTableTheme.TableStyleMedium2;

                                wsHoaDon.Columns(4, 6).Style.NumberFormat.Format = "#,##0 ₫";
                                wsHoaDon.Columns().AdjustToContents();

                                // --- PHẦN 2: BẢNG TỔNG KẾT TÀI CHÍNH CUỐI FILE ---
                                int lastRow = 4 + dtHoaDon.Rows.Count + 1;

                                // Dòng 1: Tổng Lợi nhuận gộp từ bán hàng (Tự động SUM cột Lợi nhuận)
                                int rowTongGop = lastRow + 2;
                                wsHoaDon.Cell(rowTongGop, 4).Value = "Tổng Lợi Nhuận Gộp (Từ bán hàng):";
                                wsHoaDon.Cell(rowTongGop, 4).Style.Font.Bold = true;
                                wsHoaDon.Cell(rowTongGop, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                wsHoaDon.Range(rowTongGop, 4, rowTongGop, 5).Merge(); // Gộp ô cho đẹp

                                wsHoaDon.Cell(rowTongGop, 6).FormulaA1 = $"SUM(F5:F{lastRow - 1})";
                                wsHoaDon.Cell(rowTongGop, 6).Style.Font.Bold = true;
                                wsHoaDon.Cell(rowTongGop, 6).Style.NumberFormat.Format = "#,##0 ₫";

                                // Dòng 2: Trừ đi Lương & Chi phí vận hành (Lấy từ bảng Expense)
                                int rowChiPhi = rowTongGop + 1;
                                wsHoaDon.Cell(rowChiPhi, 4).Value = "(-) Tổng Chi Phí (Lương, Điện, Mặt bằng...):";
                                wsHoaDon.Cell(rowChiPhi, 4).Style.Font.Bold = true;
                                wsHoaDon.Cell(rowChiPhi, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                wsHoaDon.Range(rowChiPhi, 4, rowChiPhi, 5).Merge();

                                wsHoaDon.Cell(rowChiPhi, 6).Value = tq.TongChiPhiKhac; // Truyền dữ liệu chi phí vào
                                wsHoaDon.Cell(rowChiPhi, 6).Style.Font.Bold = true;
                                wsHoaDon.Cell(rowChiPhi, 6).Style.Font.FontColor = XLColor.Red; // Bôi đỏ khoản trừ
                                wsHoaDon.Cell(rowChiPhi, 6).Style.NumberFormat.Format = "#,##0 ₫";

                                // Dòng 3: Lợi nhuận Ròng (Thực lãi)
                                int rowRong = rowChiPhi + 1;
                                wsHoaDon.Cell(rowRong, 4).Value = "(=) LỢI NHUẬN RÒNG (LÃI THỰC TẾ):";
                                wsHoaDon.Cell(rowRong, 4).Style.Font.Bold = true;
                                wsHoaDon.Cell(rowRong, 4).Style.Font.FontSize = 12;
                                wsHoaDon.Cell(rowRong, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                wsHoaDon.Range(rowRong, 4, rowRong, 5).Merge();

                                wsHoaDon.Cell(rowRong, 6).FormulaA1 = $"F{rowTongGop} - F{rowChiPhi}";
                                wsHoaDon.Cell(rowRong, 6).Style.Font.Bold = true;
                                wsHoaDon.Cell(rowRong, 6).Style.Font.FontSize = 12;
                                wsHoaDon.Cell(rowRong, 6).Style.Font.FontColor = XLColor.FromHtml("#28a745"); // Bôi xanh lá
                                wsHoaDon.Cell(rowRong, 6).Style.NumberFormat.Format = "#,##0 ₫";

                                // Kẻ viền cho bảng tổng kết
                                var summaryRange = wsHoaDon.Range(rowTongGop, 4, rowRong, 6);
                                summaryRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                                summaryRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                            }
                            else
                            {
                                wsHoaDon.Cell(1, 1).Value = "Không có dữ liệu hóa đơn trong khoảng thời gian này.";
                            }

                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất Báo cáo Chi tiết thành công! Đã đính kèm bảng Tổng trừ lương và chi phí ở cuối file.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
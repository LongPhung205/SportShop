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
        // HÀM ĐIỀU PHỐI CHÍNH
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
        // 1. CẬP NHẬT THẺ TỔNG QUAN TÀI CHÍNH
        // --------------------------------------------------------------
        private void UpdateOverviewCards(DateTime tuNgay, DateTime denNgay)
        {
            TongQuanTaiChinh hienTai = _controller.GetTongQuanTaiChinh(tuNgay, denNgay);

            lblTongDoanhThu.Text = hienTai.TongDoanhThu.ToString("N0") + " ₫";
            lblTongDon.Text = hienTai.TongChiPhi.ToString("N0") + " ₫";
            lblTongKhachHang.Text = hienTai.LoiNhuanRong.ToString("N0") + " ₫";
            lblTongKhachHang.ForeColor = hienTai.LoiNhuanRong < 0 ? System.Drawing.Color.Red : System.Drawing.Color.FromArgb(40, 167, 69);

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
            dgvChiTietHoaDon.DataSource = _controller.GetChiTietHoaDon(tuNgay, denNgay);
            if (dgvChiTietHoaDon.Columns.Count > 0)
            {
                dgvChiTietHoaDon.Columns["Doanh Thu"].DefaultCellStyle.Format = "N0";
                dgvChiTietHoaDon.Columns["Giá Vốn"].DefaultCellStyle.Format = "N0";

                if (dgvChiTietHoaDon.Columns.Contains("Giảm Giá"))
                {
                    dgvChiTietHoaDon.Columns["Giảm Giá"].DefaultCellStyle.Format = "N0";
                    dgvChiTietHoaDon.Columns["Giảm Giá"].DefaultCellStyle.ForeColor = System.Drawing.Color.DarkOrange;
                }

                if (dgvChiTietHoaDon.Columns.Contains("Lợi Nhuận"))
                {
                    dgvChiTietHoaDon.Columns["Lợi Nhuận"].DefaultCellStyle.Format = "N0";
                    dgvChiTietHoaDon.Columns["Lợi Nhuận"].DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
                    dgvChiTietHoaDon.Columns["Lợi Nhuận"].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
                }
            }

            dgvTopKhachHang.DataSource = _controller.GetTopKhachHang(5, tuNgay, denNgay);
            if (dgvTopKhachHang.Columns.Count > 0)
            {
                dgvTopKhachHang.Columns["TongChiTieu"].DefaultCellStyle.Format = "N0";
            }

            dgvTonKhoThap.DataSource = _controller.GetSanPhamTonKhoThap(10);
            if (dgvTonKhoThap.Columns.Count > 0)
            {
                dgvTonKhoThap.Columns["Quantity"].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                dgvTonKhoThap.Columns["Quantity"].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
                dgvTonKhoThap.Columns["Quantity"].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // ==============================================================
        // XUẤT EXCEL
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
                            // Lấy hết ngày đến 23:59:59 để đảm bảo không rớt bill
                            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);

                            DataTable dtHoaDon = _controller.GetChiTietHoaDon(tuNgay, denNgay);

                            // 👉 FIX 1: Đặt tên cho DataTable để InsertTable không bị crash
                            dtHoaDon.TableName = "BangChiTietHoaDon";

                            TongQuanTaiChinh tq = _controller.GetTongQuanTaiChinh(tuNgay, denNgay);

                            if (dtHoaDon.Rows.Count > 0)
                            {
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

                                // 👉 FIX 2: Bọc chữ đ trong ngoặc kép "\"₫\""
                                wsHoaDon.Columns(4, 7).Style.NumberFormat.Format = "#,##0 \"₫\"";
                                wsHoaDon.Columns().AdjustToContents();

                                int lastRow = 4 + dtHoaDon.Rows.Count + 1;

                                int rowTongGop = lastRow + 2;
                                wsHoaDon.Cell(rowTongGop, 5).Value = "Tổng Lợi Nhuận Gộp (Từ bán hàng):";
                                wsHoaDon.Cell(rowTongGop, 5).Style.Font.Bold = true;
                                wsHoaDon.Cell(rowTongGop, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                wsHoaDon.Range(rowTongGop, 5, rowTongGop, 6).Merge();

                                // 👉 FIX 3: Thêm dấu = vào công thức Formula
                                wsHoaDon.Cell(rowTongGop, 7).FormulaA1 = $"=SUM(G5:G{lastRow - 1})";
                                wsHoaDon.Cell(rowTongGop, 7).Style.Font.Bold = true;
                                wsHoaDon.Cell(rowTongGop, 7).Style.NumberFormat.Format = "#,##0 \"₫\"";

                                int rowChiPhi = rowTongGop + 1;
                                wsHoaDon.Cell(rowChiPhi, 5).Value = "(-) Tổng Chi Phí (Lương, Điện, Mặt bằng...):";
                                wsHoaDon.Cell(rowChiPhi, 5).Style.Font.Bold = true;
                                wsHoaDon.Cell(rowChiPhi, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                wsHoaDon.Range(rowChiPhi, 5, rowChiPhi, 6).Merge();

                                // Tránh lỗi NullReferenceException nếu tq rỗng
                                decimal chiPhiKhac = tq != null ? tq.TongChiPhiKhac : 0;
                                wsHoaDon.Cell(rowChiPhi, 7).Value = chiPhiKhac;
                                wsHoaDon.Cell(rowChiPhi, 7).Style.Font.Bold = true;
                                wsHoaDon.Cell(rowChiPhi, 7).Style.Font.FontColor = XLColor.Red;
                                wsHoaDon.Cell(rowChiPhi, 7).Style.NumberFormat.Format = "#,##0 \"₫\"";

                                int rowRong = rowChiPhi + 1;
                                wsHoaDon.Cell(rowRong, 5).Value = "(=) LỢI NHUẬN RÒNG (LÃI THỰC TẾ):";
                                wsHoaDon.Cell(rowRong, 5).Style.Font.Bold = true;
                                wsHoaDon.Cell(rowRong, 5).Style.Font.FontSize = 12;
                                wsHoaDon.Cell(rowRong, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                wsHoaDon.Range(rowRong, 5, rowRong, 6).Merge();

                                // 👉 FIX 3: Thêm dấu = vào công thức Formula
                                wsHoaDon.Cell(rowRong, 7).FormulaA1 = $"=G{rowTongGop}-G{rowChiPhi}";
                                wsHoaDon.Cell(rowRong, 7).Style.Font.Bold = true;
                                wsHoaDon.Cell(rowRong, 7).Style.Font.FontSize = 12;
                                wsHoaDon.Cell(rowRong, 7).Style.Font.FontColor = XLColor.FromHtml("#28a745");
                                wsHoaDon.Cell(rowRong, 7).Style.NumberFormat.Format = "#,##0 \"₫\"";

                                var summaryRange = wsHoaDon.Range(rowTongGop, 5, rowRong, 7);
                                summaryRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                                summaryRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                                wsHoaDon.Columns().AdjustToContents();
                            }
                            else
                            {
                                wsHoaDon.Cell(1, 1).Value = "Không có dữ liệu hóa đơn trong khoảng thời gian này.";
                            }

                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất Báo cáo Chi tiết thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Nhớ đóng file Excel nếu bạn đang mở nó nhé, lỗi "Process cannot access file..." rất hay xảy ra
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==============================================================
        // HÀM HELPER
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
                lbl.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
            }
            else if (phanTram < 0)
            {
                lbl.Text = $"▼ {Math.Abs(phanTram):F1}% so với kỳ trước";
                lbl.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lbl.Text = "Tương đương kỳ trước";
                lbl.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }
}
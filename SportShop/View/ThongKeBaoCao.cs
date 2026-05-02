using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SportShop.Controller;
using SportShop.Model;
using ClosedXML.Excel;
using System.IO;

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
                // Chỉ auto-refresh nếu khoảng thời gian lọc có bao gồm ngày hôm nay
                if (dtpDenNgay.Value.Date >= DateTime.Now.Date)
                {
                    LoadDashboardData();
                }
            };
        }

        private void ThongKeBaoCao_Load(object sender, EventArgs e)
        {
            // Set mặc định bộ lọc là tháng hiện tại
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            label1.Text = "TỔNG DOANH THU";
            label3.Text = "CHI PHÍ NHẬP HÀNG";
            label5.Text = "LỢI NHUẬN TẠM TÍNH";

            LoadDashboardData();
            _timerRealtime.Start();
        }

        private void ThongKeBaoCao_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) _timerRealtime.Start();
            else _timerRealtime.Stop();
        }

        // Sự kiện khi bấm nút Lọc
        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadDashboardData();
        }

        public void LoadDashboardData()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1); // Lấy đến hết ngày

                // ==============================================
                // 1. TỔNG QUAN TÀI CHÍNH & SO SÁNH THÁNG TRƯỚC
                // ==============================================
                TongQuanTaiChinh hienTai = _controller.GetTongQuanTaiChinh(tuNgay, denNgay);
                decimal loiNhuanHienTai = hienTai.TongDoanhThu - hienTai.TongTienNhapHang - hienTai.TongChiPhiKhac;

                lblTongDoanhThu.Text = hienTai.TongDoanhThu.ToString("N0") + " ₫";
                lblTongDon.Text = hienTai.TongTienNhapHang.ToString("N0") + " ₫";
                lblTongKhachHang.Text = loiNhuanHienTai.ToString("N0") + " ₫";
                lblTongKhachHang.ForeColor = loiNhuanHienTai < 0 ? System.Drawing.Color.Red : System.Drawing.Color.FromArgb(40, 167, 69); // Xanh lá nếu lãi

                // Tính toán tháng trước để so sánh (Giả định khoảng thời gian tương đương)
                TimeSpan khoangThoiGian = denNgay - tuNgay;
                DateTime tuNgayTruoc = tuNgay.AddDays(-khoangThoiGian.TotalDays);
                DateTime denNgayTruoc = tuNgay.AddTicks(-1);

                TongQuanTaiChinh kyTruoc = _controller.GetTongQuanTaiChinh(tuNgayTruoc, denNgayTruoc);
                decimal loiNhuanKyTruoc = kyTruoc.TongDoanhThu - kyTruoc.TongTienNhapHang - kyTruoc.TongChiPhiKhac;

                // Cập nhật Label so sánh
                HienThiSoSanh(lblSoSanhDoanhThu, hienTai.TongDoanhThu, kyTruoc.TongDoanhThu);
                HienThiSoSanh(lblSoSanhChiPhi, hienTai.TongTienNhapHang, kyTruoc.TongTienNhapHang);
                HienThiSoSanh(lblSoSanhLoiNhuan, loiNhuanHienTai, loiNhuanKyTruoc);

                // ==============================================
                // 2. BIỂU ĐỒ KÉP: DOANH THU & LỢI NHUẬN (THÊM ĐƯỜNG LỢI NHUẬN)
                // ==============================================
                List<BaoCaoDoanhThu> dtNgay = _controller.GetDoanhThuLoiNhuanTheoNgay(tuNgay, denNgay);

                chartDoanhThu.Series.Clear();

                // Cột Doanh Thu
                Series sDoanhThu = new Series("Doanh Thu")
                {
                    ChartType = SeriesChartType.Column,
                    Color = System.Drawing.Color.FromArgb(0, 123, 255), // Xanh dương
                    IsValueShownAsLabel = true,
                    LabelFormat = "{0:N0}"
                };

                // Đường Lợi Nhuận
                Series sLoiNhuan = new Series("Lợi Nhuận")
                {
                    ChartType = SeriesChartType.Spline, // Đường cong mượt
                    BorderWidth = 3,
                    Color = System.Drawing.Color.FromArgb(40, 167, 69), // Xanh lá
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 8,
                    IsValueShownAsLabel = true,
                    LabelFormat = "{0:N0}"
                };

                foreach (var item in dtNgay)
                {
                    string labelNgay = item.Ngay.ToString("dd/MM");
                    sDoanhThu.Points.AddXY(labelNgay, item.TongDoanhThu);
                    sLoiNhuan.Points.AddXY(labelNgay, item.LoiNhuan); // Cần có property LoiNhuan trong Model
                }

                chartDoanhThu.Series.Add(sDoanhThu);
                chartDoanhThu.Series.Add(sLoiNhuan);
                chartDoanhThu.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chartDoanhThu.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;

                // ==============================================
                // 3. BIỂU ĐỒ TOP SẢN PHẨM BÁN CHẠY
                // ==============================================
                List<ThongKeSanPham> topSP = _controller.GetTopSanPhamBanChay(5, tuNgay, denNgay);
                chartTopSP.Series.Clear();
                Series seriesTopSP = new Series("TopSanPham")
                {
                    ChartType = SeriesChartType.Doughnut,
                    IsValueShownAsLabel = true
                };

                foreach (var sp in topSP)
                {
                    seriesTopSP.Points.AddXY(sp.TenSanPham, sp.SoLuong);
                }
                chartTopSP.Series.Add(seriesTopSP);

                // ==============================================
                // 4. BẢNG TOP KHÁCH HÀNG MUA NHIỀU
                // ==============================================
                dgvTopKhachHang.DataSource = _controller.GetTopKhachHang(5, tuNgay, denNgay);
                if (dgvTopKhachHang.Columns.Count > 0)
                {
                    dgvTopKhachHang.Columns["TenKhachHang"].HeaderText = "Khách Hàng";
                    dgvTopKhachHang.Columns["TongChiTieu"].HeaderText = "Đã Chi (₫)";
                    dgvTopKhachHang.Columns["TongChiTieu"].DefaultCellStyle.Format = "N0";
                    dgvTopKhachHang.Columns["SoDonHang"].HeaderText = "Số Đơn";
                }

                // ==============================================
                // 5. CẢNH BÁO TỒN KHO THẤP (DƯỚI 10 SẢN PHẨM)
                // ==============================================
                dgvTonKhoThap.DataSource = _controller.GetSanPhamTonKhoThap(10); // Ngưỡng cảnh báo là 10
                if (dgvTonKhoThap.Columns.Count > 0)
                {
                    dgvTonKhoThap.Columns["TenSanPham"].HeaderText = "Sản Phẩm";
                    dgvTonKhoThap.Columns["Quantity"].HeaderText = "Tồn Kho";
                    dgvTonKhoThap.Columns["Quantity"].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                    dgvTonKhoThap.Columns["Quantity"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật Dashboard: " + ex.Message);
            }
        }

        // Nút làm mới thủ công
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        // ==============================================
        // HÀM HELPER: TÍNH % SO SÁNH VÀ ĐỔI MÀU LABEL
        // ==============================================
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
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = $"BaoCao_SportsHub_{DateTime.Now:ddMMyyyy}.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            // ==========================================
                            // 1. SHEET TỔNG QUAN TÀI CHÍNH
                            // ==========================================
                            var wsTongQuan = workbook.Worksheets.Add("Tổng Quan Tài Chính");

                            // -- Tiêu đề chính --
                            var titleRange = wsTongQuan.Range("A1:B2");
                            titleRange.Merge().Value = "BÁO CÁO TỔNG QUAN TÀI CHÍNH";
                            titleRange.Style.Font.Bold = true;
                            titleRange.Style.Font.FontSize = 16;
                            titleRange.Style.Font.FontColor = XLColor.White;
                            titleRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#007bff"); // Xanh dương Sports Hub
                            titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            titleRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                            // -- Khối Thời gian --
                            wsTongQuan.Cell(4, 1).Value = "Thời gian lọc:";
                            wsTongQuan.Cell(4, 1).Style.Font.Bold = true;
                            wsTongQuan.Cell(4, 2).Value = $"{dtpTuNgay.Value:dd/MM/yyyy} - {dtpDenNgay.Value:dd/MM/yyyy}";
                            wsTongQuan.Cell(4, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                            // -- Khối Số liệu (Đóng khung và tô màu) --
                            wsTongQuan.Cell(6, 1).Value = "Tổng Doanh Thu";
                            wsTongQuan.Cell(6, 2).Value = lblTongDoanhThu.Text;
                            wsTongQuan.Cell(6, 2).Style.Font.FontColor = XLColor.FromHtml("#007bff");

                            wsTongQuan.Cell(7, 1).Value = "Chi Phí Nhập";
                            wsTongQuan.Cell(7, 2).Value = lblTongDon.Text;
                            wsTongQuan.Cell(7, 2).Style.Font.FontColor = XLColor.FromHtml("#fd7e14"); // Cam

                            wsTongQuan.Cell(8, 1).Value = "Lợi Nhuận Tạm Tính";
                            wsTongQuan.Cell(8, 2).Value = lblTongKhachHang.Text;
                            wsTongQuan.Cell(8, 2).Style.Font.FontColor = XLColor.FromHtml("#28a745"); // Xanh lá

                            // Định dạng cho khối số liệu (In đậm, đóng khung chữ nhật)
                            var dataRange = wsTongQuan.Range("A6:B8");
                            dataRange.Style.Font.Bold = true;
                            dataRange.Style.Font.FontSize = 12;
                            dataRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                            dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                            wsTongQuan.Range("B6:B8").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                            // Căn chỉnh độ rộng cột cho đẹp
                            wsTongQuan.Column(1).Width = 25;
                            wsTongQuan.Column(2).Width = 25;

                            // ==========================================
                            // 2. SHEET TOP KHÁCH HÀNG & TỒN KHO THẤP
                            // ==========================================
                            var wsKhachHang = workbook.Worksheets.Add("Top Khách Hàng");
                            ExportGridToSheetBeautiful(dgvTopKhachHang, wsKhachHang, "DANH SÁCH TOP KHÁCH HÀNG");

                            var wsKho = workbook.Worksheets.Add("Cảnh Báo Tồn Kho");
                            ExportGridToSheetBeautiful(dgvTonKhoThap, wsKho, "DANH SÁCH SẢN PHẨM TỒN KHO THẤP");

                            // Lưu file
                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất Báo cáo Excel thành công! Mở file để xem ngay nhé.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm hỗ trợ xuất Grid sang Sheet (ĐÃ NÂNG CẤP GIAO DIỆN)
        private void ExportGridToSheetBeautiful(DataGridView grid, IXLWorksheet sheet, string title)
        {
            if (grid.Columns.Count == 0) return;

            // 1. Tạo dòng Tiêu đề lớn
            var titleRange = sheet.Range(1, 1, 2, grid.Columns.Count);
            titleRange.Merge().Value = title;
            titleRange.Style.Font.Bold = true;
            titleRange.Style.Font.FontSize = 14;
            titleRange.Style.Font.FontColor = XLColor.White;
            titleRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#343a40"); // Xám đậm
            titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            titleRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            int startRow = 4; // Bắt đầu in Header từ dòng 4

            // 2. Xuất Header của Grid (In đậm, nền xanh nhạt, có viền)
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                var cell = sheet.Cell(startRow, i + 1);
                cell.Value = grid.Columns[i].HeaderText;
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#e2eef5");
                cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            // 3. Xuất Data từ Grid (Có đóng khung từng ô)
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    var cell = sheet.Cell(i + startRow + 1, j + 1);
                    if (grid.Rows[i].Cells[j].Value != null)
                    {
                        cell.Value = grid.Rows[i].Cells[j].Value.ToString();
                    }
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    // Căn lề: Cột chữ thì căn trái, cột số thì căn phải
                    var colType = grid.Columns[j].ValueType;
                    if (colType == typeof(int) || colType == typeof(decimal) || colType == typeof(double))
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    else
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                }
            }

            // 4. Tự động giãn cột cho vừa khít với đoạn text dài nhất
            sheet.Columns().AdjustToContents();
        }
    }
}
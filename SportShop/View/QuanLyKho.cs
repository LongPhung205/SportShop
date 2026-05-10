using SportShop.Controller;
using SportShop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace SportShop.View
{
    public partial class QuanLyKho : UserControl
    {
        private QuanLySanPhamController _productController = new QuanLySanPhamController();
        private QuanLyKhoController _khoController = new QuanLyKhoController();

        public QuanLyKho()
        {
            InitializeComponent();
        }

        private void QuanLyKho_Load(object sender, EventArgs e)
        {
            LoadDataTonKho();
            LoadDataPhieuNhap();

            // Đăng ký sự kiện click cho lưới Phiếu Nhập để xem chi tiết
            if (this.Controls.Find("dgvPhieuNhap", true).Length > 0)
            {
                DataGridView dgvPhieuNhap = (DataGridView)this.Controls.Find("dgvPhieuNhap", true)[0];
                dgvPhieuNhap.CellClick += DgvPhieuNhap_CellClick;
            }

            // ĐĂNG KÝ SỰ KIỆN GỘP TÊN SẢN PHẨM CHO LƯỚI KHO
            dgvKho.CellFormatting += DgvKho_CellFormatting;
        }

        // ========================================================
        // TAB 1: XEM TỒN KHO HIỆN TẠI
        // ========================================================
        // ========================================================
        // TAB 1: XEM TỒN KHO HIỆN TẠI
        // ========================================================
        public void LoadDataTonKho()
        {
            try
            {
                var listKho = _productController.GetAllProductVariants();
                if (listKho != null)
                {
                    // 👉 Dùng LINQ để lọc: Chỉ lấy những biến thể có Số lượng > 0
                    var filteredList = listKho.Where(x => x.Quantity > 0).ToList();
                    dgvKho.DataSource = filteredList;
                }
                CustomGridViewTonKho();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomGridViewTonKho()
        {
            // 1. Ẩn tất cả ID thừa và CẢ 2 cột Size/Color rời rạc (vì ta sẽ gộp nó vào Tên)
            string[] colsToHide = { "Id", "ProductId", "SizeId", "ColorId", "Product", "Size", "Color", "ImportPrice", "Image", "SizeName", "ColorName","FullDisplayName"};
            foreach (string col in colsToHide)
            {
                if (dgvKho.Columns[col] != null) dgvKho.Columns[col].Visible = false;
            }

            // 2. Format các cột hiển thị chính
            if (dgvKho.Columns["ProductName"] != null)
            {
                dgvKho.Columns["ProductName"].HeaderText = "Tên Sản Phẩm Phân Loại";
                // Ép cột Tên giãn ra chiếm hết toàn bộ diện tích trống để đọc được chữ dài
                dgvKho.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (dgvKho.Columns["Quantity"] != null)
            {
                dgvKho.Columns["Quantity"].HeaderText = "Tồn Kho";
                dgvKho.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; // Co gọn theo nội dung
                dgvKho.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvKho.Columns["Quantity"].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
                dgvKho.Columns["Quantity"].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
            }

            if (dgvKho.Columns["SellingPrice"] != null)
            {
                dgvKho.Columns["SellingPrice"].HeaderText = "Giá Bán (₫)";
                dgvKho.Columns["SellingPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; // Co gọn theo nội dung
                dgvKho.Columns["SellingPrice"].DefaultCellStyle.Format = "N0";
            }
        }

        // THỦ THUẬT: TỰ ĐỘNG GỘP (TÊN + MÀU + SIZE) KHI HIỂN THỊ
        private void DgvKho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKho.Columns[e.ColumnIndex].Name == "ProductName" && e.Value != null)
            {
                var row = dgvKho.Rows[e.RowIndex];
                string name = e.Value.ToString();

                // Lấy data màu và size (dù cột bị ẩn nhưng data vẫn nằm đó)
                string color = row.Cells["ColorName"].Value?.ToString() ?? "";
                string size = row.Cells["SizeName"].Value?.ToString() ?? "";

                if (!string.IsNullOrEmpty(color) || !string.IsNullOrEmpty(size))
                {
                    // Trả ra kết quả siêu đẹp: Ví dụ "Giày Nike (Đỏ - 42)"
                    e.Value = $"{name} ({color} - {size})";
                    e.FormattingApplied = true;
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                var listTimKiem = _productController.SearchVariants(keyword);

                if (listTimKiem != null)
                {
                    // 👉 Vẫn phải giữ bộ lọc chặn hàng ảo khi tìm kiếm
                    var filteredList = listTimKiem.Where(x => x.Quantity > 0).ToList();
                    dgvKho.DataSource = filteredList;
                }
            }
            catch { }
        }

        // ========================================================
        // TAB 2: QUẢN LÝ QUY TRÌNH NHẬP KHO (IMPORT FLOW)
        // ========================================================
        public void LoadDataPhieuNhap()
        {
            try
            {
                if (this.Controls.Find("dgvPhieuNhap", true).Length > 0)
                {
                    DataGridView dgvPhieuNhap = (DataGridView)this.Controls.Find("dgvPhieuNhap", true)[0];
                    dgvPhieuNhap.DataSource = _khoController.GetAllImportOrders();

                    // 1. Ẩn các cột thừa
                    string[] colsToHide = { "SupplierId", "UserId", "Supplier", "User", "ImportOrderDetails", "Notes" };
                    foreach (string col in colsToHide)
                    {
                        if (dgvPhieuNhap.Columns[col] != null) dgvPhieuNhap.Columns[col].Visible = false;
                    }

                    // 2. Format các cột cần thiết
                    if (dgvPhieuNhap.Columns["Id"] != null)
                    {
                        dgvPhieuNhap.Columns["Id"].HeaderText = "Mã Phiếu";
                        dgvPhieuNhap.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    if (dgvPhieuNhap.Columns["SupplierName"] != null) dgvPhieuNhap.Columns["SupplierName"].HeaderText = "Nhà Cung Cấp";
                    if (dgvPhieuNhap.Columns["UserName"] != null) dgvPhieuNhap.Columns["UserName"].HeaderText = "Người Nhập";
                    if (dgvPhieuNhap.Columns["ImportDate"] != null)
                    {
                        dgvPhieuNhap.Columns["ImportDate"].HeaderText = "Ngày Tạo";
                        dgvPhieuNhap.Columns["ImportDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }
                    if (dgvPhieuNhap.Columns["TotalAmount"] != null)
                    {
                        dgvPhieuNhap.Columns["TotalAmount"].HeaderText = "Tổng Tiền (₫)";
                        dgvPhieuNhap.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                    }
                    if (dgvPhieuNhap.Columns["Status"] != null)
                    {
                        dgvPhieuNhap.Columns["Status"].HeaderText = "Trạng Thái";
                        dgvPhieuNhap.Columns["Status"].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
                    }
                }

                // Clear lưới chi tiết (nếu có) khi load lại phiếu
                if (this.Controls.Find("dgvChiTietPhieuNhap", true).Length > 0)
                {
                    ((DataGridView)this.Controls.Find("dgvChiTietPhieuNhap", true)[0]).DataSource = null;
                }
            }
            catch { }
        }

        // SỰ KIỆN: XEM CHI TIẾT SẢN PHẨM CỦA PHIẾU NHẬP
        private void DgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView dgvPhieuNhap = (DataGridView)sender;
                int importId = Convert.ToInt32(dgvPhieuNhap.Rows[e.RowIndex].Cells["Id"].Value);

                // Tìm lưới chi tiết trên giao diện
                if (this.Controls.Find("dgvChiTietPhieuNhap", true).Length > 0)
                {
                    DataGridView dgvChiTiet = (DataGridView)this.Controls.Find("dgvChiTietPhieuNhap", true)[0];
                    dgvChiTiet.DataSource = _khoController.GetImportOrderDetails(importId);

                    // Format lưới chi tiết
                    if (dgvChiTiet.Columns["Id"] != null) dgvChiTiet.Columns["Id"].Visible = false;
                    if (dgvChiTiet.Columns["ImportOrderId"] != null) dgvChiTiet.Columns["ImportOrderId"].Visible = false;
                    if (dgvChiTiet.Columns["ProductVariantId"] != null) dgvChiTiet.Columns["ProductVariantId"].Visible = false;
                    if (dgvChiTiet.Columns["ImportOrder"] != null) dgvChiTiet.Columns["ImportOrder"].Visible = false;
                    if (dgvChiTiet.Columns["ProductVariant"] != null) dgvChiTiet.Columns["ProductVariant"].Visible = false;

                    if (dgvChiTiet.Columns["VariantDisplayName"] != null)
                    {
                        dgvChiTiet.Columns["VariantDisplayName"].HeaderText = "Tên Sản Phẩm Đầy Đủ";
                        dgvChiTiet.Columns["VariantDisplayName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    if (dgvChiTiet.Columns["Quantity"] != null) dgvChiTiet.Columns["Quantity"].HeaderText = "Số Lượng";
                    if (dgvChiTiet.Columns["ImportPrice"] != null)
                    {
                        dgvChiTiet.Columns["ImportPrice"].HeaderText = "Giá Nhập (₫)";
                        dgvChiTiet.Columns["ImportPrice"].DefaultCellStyle.Format = "N0";
                    }
                }
            }
        }

        // BƯỚC 1 & 2: Mở Form Tạo Phiếu Nhập
        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            frmTaoPhieuNhap frm = new frmTaoPhieuNhap();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDataPhieuNhap();
            }
        }

        // BƯỚC 4: CHỐT PHIẾU NHẬP (COMMIT)
        private void btnChotKho_Click(object sender, EventArgs e)
        {
            DataGridView dgvPhieuNhap = (DataGridView)this.Controls.Find("dgvPhieuNhap", true)[0];
            if (dgvPhieuNhap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập nháp để chốt kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int importId = Convert.ToInt32(dgvPhieuNhap.CurrentRow.Cells["Id"].Value);
            string status = dgvPhieuNhap.CurrentRow.Cells["Status"].Value.ToString();

            if (status == "COMPLETED")
            {
                MessageBox.Show("Phiếu này đã được chốt và cộng vào kho rồi, không thể chốt lại!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show($"Xác nhận HỢP LỆ và CHỐT phiếu nhập #{importId}?\n(Hàng hóa sẽ được cộng vào tồn kho và không thể hoàn tác quy trình này)", "Kiểm duyệt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int currentUserId = UserSession.CurrentUser != null ? UserSession.CurrentUser.Id : 1;

                if (_khoController.CommitImportOrder(importId, currentUserId))
                {
                    MessageBox.Show("Chốt kho thành công! Hàng đã lên kệ.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataPhieuNhap();
                    LoadDataTonKho();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi chốt kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // BƯỚC HỦY: Xóa phiếu nháp
        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            DataGridView dgvPhieuNhap = (DataGridView)this.Controls.Find("dgvPhieuNhap", true)[0];
            if (dgvPhieuNhap.CurrentRow == null) return;

            int importId = Convert.ToInt32(dgvPhieuNhap.CurrentRow.Cells["Id"].Value);
            string status = dgvPhieuNhap.CurrentRow.Cells["Status"].Value.ToString();

            if (status == "COMPLETED")
            {
                MessageBox.Show("Không thể xóa phiếu đã nhập kho hoàn tất! Hãy làm quy trình Xuất Hủy nếu hàng có vấn đề.", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show($"Xóa phiếu nhập nháp #{importId}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_khoController.DeleteImportOrder(importId))
                {
                    MessageBox.Show("Đã xóa phiếu nhập!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataPhieuNhap();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadDataTonKho();
            LoadDataPhieuNhap();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dtpTuNgay.Value.Date;
                DateTime toDate = dtpDenNgay.Value.Date;

                // KIỂM TRA NGÀY
                if (fromDate > toDate)
                {
                    MessageBox.Show(
                        "Từ ngày không được lớn hơn Đến ngày!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // Chỉ lấy phiếu COMPLETED
                var list = _khoController.FilterImportOrders(
                    fromDate,
                    toDate,
                    "COMPLETED"
                );

                DataGridView dgvPhieuNhap =
                    (DataGridView)this.Controls.Find("dgvPhieuNhap", true)[0];

                dgvPhieuNhap.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi lọc phiếu nhập: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
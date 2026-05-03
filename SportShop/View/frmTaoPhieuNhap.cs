using SportShop.Controller;
using SportShop.DataBase;
using SportShop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SportShop.View
{
    public partial class frmTaoPhieuNhap : Form
    {
        private QuanLyKhoController _khoController = new QuanLyKhoController();
        private QuanLySanPhamController _spController = new QuanLySanPhamController();

        // Dùng BindingList để DataGridView tự động cập nhật khi thêm/xóa món hàng
        private BindingList<ImportOrderDetail> _cart = new BindingList<ImportOrderDetail>();

        public frmTaoPhieuNhap()
        {
            InitializeComponent();
        }

        private void frmTaoPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            LoadProducts();

            // Gắn giỏ hàng vào DataGridView
            dgvChiTiet.DataSource = _cart;
            CustomGridView();
        }

        // 1. TẢI DANH SÁCH NHÀ CUNG CẤP
        private void LoadSuppliers()
        {
            try
            {
                DataTable dt = DBConnection.GetDataTable("SELECT Id, Name FROM Supplier WHERE IsActive = 1");
                cboNhaCungCap.DataSource = dt;
                cboNhaCungCap.DisplayMember = "Name";
                cboNhaCungCap.ValueMember = "Id";
                cboNhaCungCap.SelectedIndex = -1;

                // 👉 CẤU HÌNH COMBOBOX: Cho phép gõ text tự do vào
                cboNhaCungCap.DropDownStyle = ComboBoxStyle.DropDown;
                cboNhaCungCap.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboNhaCungCap.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch { }
        }

        // 2. TẢI DANH SÁCH SẢN PHẨM (BIẾN THỂ)
        private void LoadProducts()
        {
            try
            {
                var variants = _spController.GetAllProductVariants();

                // Tạo một danh sách ẩn danh để format tên hiển thị cho đẹp trong ComboBox
                var displayList = variants.Select(v => new
                {
                    Id = v.Id,
                    DisplayName = $"{v.ProductName} ({v.ColorName} - {v.SizeName})"
                }).ToList();

                cboSanPham.DataSource = displayList;
                cboSanPham.DisplayMember = "DisplayName";
                cboSanPham.ValueMember = "Id";
                cboSanPham.SelectedIndex = -1;
            }
            catch { }
        }

        // 3. ĐỊNH DẠNG LƯỚI GIỎ HÀNG
        private void CustomGridView()
        {
            if (dgvChiTiet.Columns["Id"] != null) dgvChiTiet.Columns["Id"].Visible = false;
            if (dgvChiTiet.Columns["ImportOrderId"] != null) dgvChiTiet.Columns["ImportOrderId"].Visible = false;
            if (dgvChiTiet.Columns["ProductVariantId"] != null) dgvChiTiet.Columns["ProductVariantId"].Visible = false;
            if (dgvChiTiet.Columns["ProductVariant"] != null) dgvChiTiet.Columns["ProductVariant"].Visible = false;
            if (dgvChiTiet.Columns["ImportOrder"] != null) dgvChiTiet.Columns["ImportOrder"].Visible = false;


            if (dgvChiTiet.Columns["VariantDisplayName"] != null) dgvChiTiet.Columns["VariantDisplayName"].HeaderText = "Tên Sản Phẩm";

            if (dgvChiTiet.Columns["Quantity"] != null)
            {
                dgvChiTiet.Columns["Quantity"].HeaderText = "Số Lượng";
                dgvChiTiet.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvChiTiet.Columns["ImportPrice"] != null)
            {
                dgvChiTiet.Columns["ImportPrice"].HeaderText = "Giá Nhập (₫)";
                dgvChiTiet.Columns["ImportPrice"].DefaultCellStyle.Format = "N0";
            }
        }

        // 4. TÍNH LẠI TỔNG TIỀN
        private void TinhTongTien()
        {
            decimal total = _cart.Sum(x => x.Quantity * x.ImportPrice);
            lblTongTien.Text = total.ToString("N0") + " ₫";
        }

        // 5. NÚT: THÊM VÀO PHIẾU
        private void btnThemItem_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nmSoLuong.Value <= 0 || nmGiaNhap.Value <= 0)
            {
                MessageBox.Show("Số lượng và Giá nhập phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int variantId = Convert.ToInt32(cboSanPham.SelectedValue);
            string displayName = cboSanPham.Text;

            // Kiểm tra xem sản phẩm đã có trong lưới chưa (nếu có thì cộng dồn số lượng)
            var existingItem = _cart.FirstOrDefault(x => x.ProductVariantId == variantId);
            if (existingItem != null)
            {
                existingItem.Quantity += (int)nmSoLuong.Value;
                // Nếu giá nhập mới khác giá cũ, lấy giá mới nhất
                existingItem.ImportPrice = nmGiaNhap.Value;
                dgvChiTiet.Refresh();
            }
            else
            {
                // Thêm dòng mới
                _cart.Add(new ImportOrderDetail
                {
                    ProductVariantId = variantId,
                    VariantDisplayName = displayName,
                    Quantity = (int)nmSoLuong.Value,
                    ImportPrice = nmGiaNhap.Value
                });
            }

            TinhTongTien();

            // Reset ô nhập để nhập tiếp cho nhanh
            cboSanPham.SelectedIndex = -1;
            nmSoLuong.Value = 1;
            nmGiaNhap.Value = 0;
            cboSanPham.Focus();
        }

        // Xóa món hàng khỏi lưới khi Double Click
        private void dgvChiTiet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (MessageBox.Show("Bỏ sản phẩm này khỏi phiếu nhập?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _cart.RemoveAt(e.RowIndex);
                    TinhTongTien();
                }
            }
        }

        // 6. NÚT: LƯU NHÁP PHIẾU NHẬP
        private void btnLuuNhap_Click(object sender, EventArgs e)
        {
            string tenNCC = cboNhaCungCap.Text.Trim();

            if (string.IsNullOrEmpty(tenNCC))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập tên Nhà cung cấp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_cart.Count == 0)
            {
                MessageBox.Show("Phiếu nhập chưa có sản phẩm nào!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int supplierId = 0;

            // XỬ LÝ NHÀ CUNG CẤP: Kiểm tra xem người dùng chọn trong list hay gõ tên mới
            if (cboNhaCungCap.SelectedValue != null && cboNhaCungCap.SelectedValue is int)
            {
                // Trường hợp 1: Chọn một NCC đã có trong danh sách xổ xuống
                supplierId = (int)cboNhaCungCap.SelectedValue;
            }
            else
            {
                // Trường hợp 2: Gõ một tên hoàn toàn mới -> Tự động Insert vào CSDL và lấy ID
                string sqlInsertNCC = "INSERT INTO Supplier (Name, IsActive, CreatedAt) OUTPUT INSERTED.Id VALUES (@name, 1, GETDATE())";
                using (var conn = DBConnection.GetDBConnection())
                {
                    conn.Open();
                    using (var cmd = new System.Data.SqlClient.SqlCommand(sqlInsertNCC, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", tenNCC);
                        supplierId = (int)cmd.ExecuteScalar();
                    }
                }
            }

            // TẠO OBJECT PHIẾU NHẬP VỚI ID NHÀ CUNG CẤP (CŨ HOẶC MỚI)
            var order = new ImportOrder
            {
                SupplierId = supplierId,
                UserId = UserSession.CurrentUser != null ? UserSession.CurrentUser.Id : 1, // Lấy người đang đăng nhập
                ImportDate = DateTime.Now,
                TotalAmount = _cart.Sum(x => x.Quantity * x.ImportPrice),
                Notes = txtGhiChu.Text.Trim()
            };

            // LƯU PHIẾU
            if (_khoController.SaveDraftImportOrder(order, _cart.ToList()))
            {
                MessageBox.Show("Đã lưu Phiếu Nhập Nháp thành công!\nPhiếu này hiện chưa cộng vào Tồn kho cho đến khi được duyệt.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Báo về cho QuanLyKho biết để tải lại danh sách
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu phiếu nhập. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
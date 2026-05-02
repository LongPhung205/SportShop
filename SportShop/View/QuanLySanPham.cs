using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SportShop.Controller;
using SportShop.Model;

namespace SportShop.View
{
    public partial class QuanLySanPham : UserControl
    {
        private readonly QuanLySanPhamController _productController = new QuanLySanPhamController();
        private string _selectedImagePath = "";

        // Biến theo dõi xem người dùng đang thao tác với SP gốc hay Biến thể
        private bool _isEditingVariant = false;

        public QuanLySanPham()
        {
            InitializeComponent();

            this.Load += QuanLySanPham_Load;

            // 👉 ĐĂNG KÝ SỰ KIỆN TỪ DỰ ÁN CŨ ĐỂ LOAD ẢNH MƯỢT MÀ
            dgvSanPham.CellFormatting += dgvSanPham_CellFormatting;
            dgvSanPham.DataError += (s, e) => { e.Cancel = true; };

            dgvSanPham.CellClick += dgvSanPham_CellClick;
            dgvBienThe.CellClick += dgvBienThe_CellClick;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnChonAnh.Click += btnChonAnh_Click;
           

            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            btnThemBienThe.Click += btnThemBienThe_Click;
        }

        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            LoadAllComboBoxes();

            dgvSanPham.RowTemplate.Height = 80; // Set theo dự án cũ cho đẹp
            dgvBienThe.RowTemplate.Height = 35;

            LoadData();
        }

        // ==========================================
        // TẢI COMBOBOX & DỮ LIỆU
        // ==========================================
        private void LoadAllComboBoxes()
        {
            try
            {
                cboLoaiSP.DataSource = _productController.GetAllCategories();
                cboLoaiSP.DisplayMember = "CategoryName";
                cboLoaiSP.ValueMember = "Id";
                cboLoaiSP.SelectedIndex = -1;

                cboSize.DataSource = _productController.GetAllSizes();
                cboSize.DisplayMember = "Name";
                cboSize.ValueMember = "Id";
                cboSize.SelectedIndex = -1;

                cboColor.DataSource = _productController.GetAllColors();
                cboColor.DisplayMember = "Name";
                cboColor.ValueMember = "Id";
                cboColor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadData()
        {
            try
            {
                dgvSanPham.DataSource = _productController.GetAllProducts();

                CustomGridView();
                AddImageColumn(); // Chỉ tạo cột, KHÔNG lặp để load ảnh ở đây nữa

                // Tự động chọn và hiển thị sản phẩm đầu tiên
                if (dgvSanPham.Rows.Count > 0)
                {
                    var firstVisibleCol = dgvSanPham.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Visible);
                    if (firstVisibleCol != null)
                    {
                        dgvSanPham.CurrentCell = dgvSanPham.Rows[0].Cells[firstVisibleCol.Index];
                    }
                    dgvSanPham.Rows[0].Selected = true;
                    dgvSanPham_CellClick(this, new DataGridViewCellEventArgs(firstVisibleCol != null ? firstVisibleCol.Index : 0, 0));
                }
                else
                {
                    dgvBienThe.DataSource = null;
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu sản phẩm:\n\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadVariantsToGrid(int productId)
        {
            var variants = _productController.GetVariantsByProductId(productId);
            dgvBienThe.DataSource = variants;
            CustomVariantGridView();
        }

        // ==========================================
        // CƠ CHẾ ĐỔI CHẾ ĐỘ THÔNG MINH (UX)
        // ==========================================
        private void SetEditingMode(bool isVariant)
        {
            _isEditingVariant = isVariant;
            if (isVariant)
            {
                btnSua.Text = "SỬA BT";
                btnXoa.Text = "XÓA BT";
            }
            else
            {
                btnSua.Text = "SỬA SP";
                btnXoa.Text = "XÓA SP";
            }
        }

        // ==========================================
        // CUSTOM HIỂN THỊ CỘT LƯỚI
        // ==========================================
        private void CustomGridView()
        {
            string[] hiddenColumns = { "Id", "CategoryId", "ImagePath", "Description", "CreatedAt", "UpdatedAt", "Category" };
            foreach (string col in hiddenColumns)
            {
                if (dgvSanPham.Columns[col] != null)
                    dgvSanPham.Columns[col].Visible = false;
            }

            if (dgvSanPham.Columns["SKU"] != null) dgvSanPham.Columns["SKU"].HeaderText = "Mã SKU Gốc";
            if (dgvSanPham.Columns["Name"] != null) dgvSanPham.Columns["Name"].HeaderText = "Tên Sản Phẩm";
            if (dgvSanPham.Columns["CategoryName"] != null) dgvSanPham.Columns["CategoryName"].HeaderText = "Loại";

            if (dgvSanPham.Columns["BasePrice"] != null)
            {
                dgvSanPham.Columns["BasePrice"].HeaderText = "Giá Niêm Yết";
                dgvSanPham.Columns["BasePrice"].DefaultCellStyle.Format = "N0";
            }
            if (dgvSanPham.Columns["IsActive"] != null) dgvSanPham.Columns["IsActive"].HeaderText = "Kích Hoạt";
        }

        private void CustomVariantGridView()
        {
            string[] visibleCols = { "SKU", "SizeName", "ColorName", "Quantity", "SellingPrice", "IsActive" };

            foreach (DataGridViewColumn col in dgvBienThe.Columns)
            {
                if (!visibleCols.Contains(col.Name))
                {
                    col.Visible = false;
                }
            }

            if (dgvBienThe.Columns["SKU"] != null) dgvBienThe.Columns["SKU"].HeaderText = "Mã SKU Biến Thể";
            if (dgvBienThe.Columns["SizeName"] != null) dgvBienThe.Columns["SizeName"].HeaderText = "Kích cỡ";
            if (dgvBienThe.Columns["ColorName"] != null) dgvBienThe.Columns["ColorName"].HeaderText = "Màu sắc";
            if (dgvBienThe.Columns["Quantity"] != null) dgvBienThe.Columns["Quantity"].HeaderText = "Tồn kho";
            if (dgvBienThe.Columns["SellingPrice"] != null)
            {
                dgvBienThe.Columns["SellingPrice"].HeaderText = "Giá bán";
                dgvBienThe.Columns["SellingPrice"].DefaultCellStyle.Format = "N0";
            }
            if (dgvBienThe.Columns["IsActive"] != null) dgvBienThe.Columns["IsActive"].HeaderText = "Mở Bán";
        }

        // ==========================================
        // KHỞI TẠO CỘT ẢNH THEO LOGIC MỚI
        // ==========================================
        private void AddImageColumn()
        {
            if (!dgvSanPham.Columns.Contains("ColImage"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                imgCol.Name = "ColImage";
                imgCol.HeaderText = "Ảnh sản phẩm";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.Width = 100;

                // ---> DÒNG QUAN TRỌNG: XÓA DẤU X ĐỎ <---
                imgCol.DefaultCellStyle.NullValue = null;

                dgvSanPham.Columns.Insert(0, imgCol);
            }
            // KHÔNG LẶP FOREACH Ở ĐÂY NỮA! Để việc load ảnh cho sự kiện CellFormatting tự lo.
        }

        // ==========================================
        // 👉 SỰ KIỆN LOAD ẢNH THÔNG MINH (TỪ DỰ ÁN CŨ)
        // ==========================================
        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "ColImage" && e.RowIndex >= 0)
            {
                // Lấy đường dẫn ảnh từ cột ImagePath đang bị ẩn
                var pathCell = dgvSanPham.Rows[e.RowIndex].Cells["ImagePath"].Value;

                if (pathCell != null && !string.IsNullOrWhiteSpace(pathCell.ToString()))
                {
                    string path = pathCell.ToString();

                    if (File.Exists(path))
                    {
                        try
                        {
                            // Đọc file thành mảng byte, rồi nạp vào Image để không bị khóa file
                            byte[] imageBytes = System.IO.File.ReadAllBytes(path);
                            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                            {
                                e.Value = Image.FromStream(ms);
                            }
                        }
                        catch
                        {
                            e.Value = null;
                        }
                    }
                    else
                    {
                        e.Value = null;
                    }
                }
            }
        }

        // ==========================================
        // SỰ KIỆN CLICK SẢN PHẨM & BIẾN THỂ
        // ==========================================
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                SetEditingMode(false); // Chuyển về chế độ chỉnh sửa Sản phẩm gốc

                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                // ==================== THÔNG TIN SẢN PHẨM GỐC ====================
                txtSKU.Text = row.Cells["SKU"]?.Value?.ToString() ?? "";
                txtTenSP.Text = row.Cells["Name"]?.Value?.ToString() ?? "";
                txtMoTa.Text = row.Cells["Description"]?.Value?.ToString() ?? "";

                if (row.Cells["CategoryId"].Value != DBNull.Value && row.Cells["CategoryId"].Value != null)
                {
                    cboLoaiSP.SelectedValue = Convert.ToInt32(row.Cells["CategoryId"].Value);
                }

                nmBasePrice.Value = Convert.ToDecimal(row.Cells["BasePrice"].Value ?? 0);
                chkIsActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value ?? true);

                _selectedImagePath = row.Cells["ImagePath"]?.Value?.ToString();

                // ==================== HIỂN THỊ ẢNH TRÊN PICTUREBOX ====================
                if (!string.IsNullOrEmpty(_selectedImagePath) && File.Exists(_selectedImagePath))
                {
                    try
                    {
                        picSanPham.Image?.Dispose();
                        using (var fs = new FileStream(_selectedImagePath, FileMode.Open, FileAccess.Read))
                        {
                            picSanPham.Image = Image.FromStream(fs);
                        }
                    }
                    catch
                    {
                        picSanPham.Image = null;
                    }
                }
                else
                {
                    picSanPham.Image?.Dispose();
                    picSanPham.Image = null;
                }

                if (txtDuongDanAnh != null)
                    txtDuongDanAnh.Text = _selectedImagePath ?? "";

                // ==================== LOAD BIẾN THỂ ====================
                int productId = Convert.ToInt32(row.Cells["Id"].Value);
                LoadVariantsToGrid(productId);

                if (dgvBienThe.Rows.Count > 0)
                {
                    DataGridViewRow firstVariantRow = dgvBienThe.Rows[0];

                    if (firstVariantRow.Cells["SizeId"].Value != DBNull.Value)
                        cboSize.SelectedValue = Convert.ToInt32(firstVariantRow.Cells["SizeId"].Value);

                    if (firstVariantRow.Cells["ColorId"].Value != DBNull.Value)
                        cboColor.SelectedValue = Convert.ToInt32(firstVariantRow.Cells["ColorId"].Value);

                    nmSoLuong.Value = Convert.ToInt32(firstVariantRow.Cells["Quantity"].Value ?? 0);
                }
                else
                {
                    cboSize.SelectedIndex = -1;
                    cboColor.SelectedIndex = -1;
                    nmSoLuong.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị thông tin sản phẩm:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBienThe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                SetEditingMode(true); // Chuyển sang chế độ Biến thể

                DataGridViewRow row = dgvBienThe.Rows[e.RowIndex];

                txtSKU.Text = row.Cells["SKU"].Value?.ToString();

                if (row.Cells["SellingPrice"].Value != DBNull.Value)
                    nmBasePrice.Value = Convert.ToDecimal(row.Cells["SellingPrice"].Value);

                if (row.Cells["IsActive"].Value != DBNull.Value)
                    chkIsActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);

                if (row.Cells["SizeId"].Value != DBNull.Value)
                    cboSize.SelectedValue = Convert.ToInt32(row.Cells["SizeId"].Value);

                if (row.Cells["ColorId"].Value != DBNull.Value)
                    cboColor.SelectedValue = Convert.ToInt32(row.Cells["ColorId"].Value);

                nmSoLuong.Value = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);
            }
            catch { }
        }

        // ==========================================
        // CÁC HÀM XỬ LÝ CHỨC NĂNG (THÊM, SỬA, XÓA)
        // ==========================================

        private void btnTaoSKU_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mã SKU Gốc và Biến thể sẽ được hệ thống tự động sinh ra cực chuẩn xác ngay khi bạn bấm nút THÊM SP!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_isEditingVariant)
            {
                if (dgvBienThe.CurrentRow == null) return;

                var variant = new ProductVariant
                {
                    Id = Convert.ToInt32(dgvBienThe.CurrentRow.Cells["Id"].Value),
                    ProductId = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["Id"].Value),
                    SKU = txtSKU.Text.Trim().ToUpper(),
                    SizeId = (int)cboSize.SelectedValue,
                    ColorId = (int)cboColor.SelectedValue,
                    Quantity = (int)nmSoLuong.Value,
                    SellingPrice = nmBasePrice.Value,
                    CostPrice = nmBasePrice.Value * 0.7m,
                    IsActive = chkIsActive.Checked
                };

                if (_productController.UpdateVariant(variant))
                {
                    MessageBox.Show("Cập nhật Biến thể thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int productId = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["Id"].Value);
                    LoadVariantsToGrid(productId);
                }
                else
                {
                    MessageBox.Show("Cập nhật Biến thể thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (dgvSanPham.CurrentRow == null) return;

                var product = new Product
                {
                    Id = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["Id"].Value),
                    SKU = txtSKU.Text.Trim().ToUpper(),
                    Name = txtTenSP.Text.Trim(),
                    CategoryId = (int)cboLoaiSP.SelectedValue,
                    Description = txtMoTa.Text.Trim(),
                    BasePrice = nmBasePrice.Value,
                    ImagePath = _selectedImagePath,
                    IsActive = chkIsActive.Checked
                };

                if (_productController.UpdateProduct(product))
                {
                    MessageBox.Show("Cập nhật Sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int selectedIndex = dgvSanPham.CurrentRow.Index;
                    LoadData();

                    if (dgvSanPham.Rows.Count > selectedIndex)
                    {
                        dgvSanPham.Rows[selectedIndex].Selected = true;
                        dgvSanPham_CellClick(null, new DataGridViewCellEventArgs(0, selectedIndex));
                    }
                }
                else
                {
                    MessageBox.Show("Cập nhật Sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_isEditingVariant)
            {
                if (dgvBienThe.CurrentRow == null) return;

                int variantId = Convert.ToInt32(dgvBienThe.CurrentRow.Cells["Id"].Value);
                string sku = dgvBienThe.CurrentRow.Cells["SKU"].Value?.ToString();

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa Biến thể '{sku}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_productController.DeleteVariant(variantId))
                    {
                        MessageBox.Show("Đã xóa biến thể thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int productId = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["Id"].Value);
                        LoadVariantsToGrid(productId);
                        SetEditingMode(false);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa biến thể này (có thể đã phát sinh hóa đơn giao dịch)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (dgvSanPham.CurrentRow == null) return;

                int id = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["Id"].Value);
                string name = dgvSanPham.CurrentRow.Cells["Name"].Value.ToString();

                if (MessageBox.Show($"Bạn có chắc muốn xóa toàn bộ sản phẩm '{name}' và các biến thể của nó không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_productController.DeleteProduct(id))
                    {
                        MessageBox.Show("Đã xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa sản phẩm do đang có hóa đơn liên quan!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh sản phẩm";
                ofd.Filter = "Hình ảnh|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = ofd.FileName;
                    txtDuongDanAnh.Text = _selectedImagePath;
                    using (var fs = new FileStream(_selectedImagePath, FileMode.Open, FileAccess.Read))
                    {
                        picSanPham.Image = Image.FromStream(fs);
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSP.Text) || cboLoaiSP.SelectedIndex == -1 ||
                cboSize.SelectedIndex == -1 || cboColor.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm và thiết lập ít nhất 1 biến thể!", "Thiếu thông tin");
                return;
            }

            var product = new Product
            {
                Name = txtTenSP.Text.Trim(),
                CategoryId = (int)cboLoaiSP.SelectedValue,
                Description = txtMoTa.Text.Trim(),
                BasePrice = nmBasePrice.Value,
                ImagePath = _selectedImagePath,
                IsActive = chkIsActive.Checked
            };

            if (_productController.AddProduct(product))
            {
                var variant = new ProductVariant
                {
                    ProductId = product.Id, // ID đã được Controller trả về
                    SizeId = (int)cboSize.SelectedValue,
                    ColorId = (int)cboColor.SelectedValue,
                    Quantity = (int)nmSoLuong.Value,
                    SellingPrice = nmBasePrice.Value,
                    CostPrice = nmBasePrice.Value * 0.7m,
                    IsActive = true
                };

                _productController.AddProductVariant(variant);

                MessageBox.Show($"Thêm sản phẩm thành công!\nMã SKU gốc của bạn là: {product.SKU}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemBienThe_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn 1 Sản phẩm ở danh sách trên để thêm biến thể!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboSize.SelectedIndex == -1 || cboColor.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Size và Màu sắc cho biến thể mới!", "Thiếu thông tin");
                return;
            }

            int productId = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["Id"].Value);

            var variant = new ProductVariant
            {
                ProductId = productId,
                SizeId = (int)cboSize.SelectedValue,
                ColorId = (int)cboColor.SelectedValue,
                Quantity = (int)nmSoLuong.Value,
                SellingPrice = nmBasePrice.Value,
                CostPrice = nmBasePrice.Value * 0.7m,
                IsActive = true
            };

            if (_productController.AddProductVariant(variant))
            {
                MessageBox.Show("Đã thêm biến thể mới cho sản phẩm này!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadVariantsToGrid(productId);
            }
            else
            {
                MessageBox.Show("Thêm lỗi! Biến thể màu/size này có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
        }

        private void ClearForm()
        {
            txtSKU.Clear();
            txtTenSP.Clear();
            txtMoTa.Clear();
            txtDuongDanAnh.Clear();
            _selectedImagePath = "";

            cboLoaiSP.SelectedIndex = -1;
            cboSize.SelectedIndex = -1;
            cboColor.SelectedIndex = -1;

            nmSoLuong.Value = 0;
            nmBasePrice.Value = 0;
            chkIsActive.Checked = true;

            picSanPham.Image?.Dispose();
            picSanPham.Image = null;
            dgvBienThe.DataSource = null;

            SetEditingMode(false);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                dgvSanPham.DataSource = _productController.SearchProducts(keyword);
                CustomGridView();

                dgvBienThe.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }
    }
}
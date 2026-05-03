using SportShop.Controller;
using SportShop.Model;
using System;
using System.Windows.Forms;

namespace SportShop.View
{
    public partial class QuanLyLoaiSanPham : UserControl
    {
        // Khởi tạo Controller tổng (xử lý cả Danh Mục, Màu, Size)
        private QuanLyLoaiSanPhamController _controller = new QuanLyLoaiSanPhamController();

        public QuanLyLoaiSanPham()
        {
            InitializeComponent();
        }

        private void QuanLyLoaiSanPham_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        // Tải toàn bộ dữ liệu cho cả 3 bảng
        private void LoadAllData()
        {
            LoadDataDanhMuc();
            LoadDataMauSac();
            LoadDataKichThuoc();
        }

        #region ================= 1. QUẢN LÝ DANH MỤC SẢN PHẨM =================

        private void LoadDataDanhMuc()
        {
            try
            {
                dgvLoaiSP.DataSource = _controller.GetAllCategories();

                if (dgvLoaiSP.Columns["Id"] != null) dgvLoaiSP.Columns["Id"].Visible = false;
                if (dgvLoaiSP.Columns["IsActive"] != null) dgvLoaiSP.Columns["IsActive"].Visible = false;
                if (dgvLoaiSP.Columns["CreatedAt"] != null) dgvLoaiSP.Columns["CreatedAt"].Visible = false;

                if (dgvLoaiSP.Columns["CategoryName"] != null) dgvLoaiSP.Columns["CategoryName"].HeaderText = "Tên Loại Sản Phẩm";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải Danh mục: " + ex.Message); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Tên danh mục không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var category = new Category { CategoryName = txtTenLoai.Text.Trim(), IsActive = true };

            if (_controller.AddCategory(category))
            {
                MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataDanhMuc();
                txtTenLoai.Clear();
            }
            else
            {
                MessageBox.Show("Thêm thất bại. Có thể tên loại này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLoaiSP.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một danh mục để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var category = new Category
            {
                Id = Convert.ToInt32(dgvLoaiSP.CurrentRow.Cells["Id"].Value),
                CategoryName = txtTenLoai.Text.Trim(),
                IsActive = true
            };

            if (_controller.UpdateCategory(category))
            {
                MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataDanhMuc();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLoaiSP.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvLoaiSP.CurrentRow.Cells["Id"].Value);
            string name = dgvLoaiSP.CurrentRow.Cells["CategoryName"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa danh mục '{name}'?\n(Không thể xóa nếu đang có sản phẩm thuộc danh mục này)", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_controller.DeleteCategory(id))
                {
                    LoadDataDanhMuc();
                    txtTenLoai.Clear();
                }
                else
                {
                    MessageBox.Show("Không thể xóa danh mục này vì đang có sản phẩm liên kết!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvLoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtTenLoai.Text = dgvLoaiSP.Rows[e.RowIndex].Cells["CategoryName"].Value?.ToString();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            dgvLoaiSP.DataSource = _controller.SearchCategories(keyword);
        }

        // Nút làm mới dùng chung cho cả Form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenLoai.Clear();
            txtTenMau.Clear();
            txtTenSize.Clear();
            txtTimKiem.Clear();
            LoadAllData();
        }

        #endregion


        #region ================= 2. QUẢN LÝ MÀU SẮC =================

        private void LoadDataMauSac()
        {
            try
            {
                dgvMauSac.DataSource = _controller.GetAllColors();

                if (dgvMauSac.Columns["Id"] != null) dgvMauSac.Columns["Id"].Visible = false;
                if (dgvMauSac.Columns["ProductVariants"] != null) dgvMauSac.Columns["ProductVariants"].Visible = false;
                if (dgvMauSac.Columns["IsActive"] != null) dgvMauSac.Columns["IsActive"].Visible = false;

                if (dgvMauSac.Columns["Name"] != null) dgvMauSac.Columns["Name"].HeaderText = "Tên Màu Sắc";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải Màu sắc: " + ex.Message); }
        }

        private void btnThemMauSac_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenMau.Text))
            {
                MessageBox.Show("Tên màu không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var color = new Color { Name = txtTenMau.Text.Trim(), IsActive = true };

            if (_controller.AddColor(color))
            {
                LoadDataMauSac();
                txtTenMau.Clear();
            }
            else MessageBox.Show("Thêm thất bại. Có thể màu này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSuaMauSac_Click(object sender, EventArgs e)
        {
            if (dgvMauSac.CurrentRow == null) return;

            var color = new Color
            {
                Id = Convert.ToInt32(dgvMauSac.CurrentRow.Cells["Id"].Value),
                Name = txtTenMau.Text.Trim(),
                IsActive = true
            };

            if (_controller.UpdateColor(color))
            {
                LoadDataMauSac();
            }
        }

        private void btnXoaMauSac_Click(object sender, EventArgs e)
        {
            if (dgvMauSac.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvMauSac.CurrentRow.Cells["Id"].Value);
            string name = dgvMauSac.CurrentRow.Cells["Name"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa màu '{name}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_controller.DeleteColor(id))
                {
                    LoadDataMauSac();
                    txtTenMau.Clear();
                }
                else MessageBox.Show("Không thể xóa màu này vì đang có sản phẩm liên kết!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMauSac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtTenMau.Text = dgvMauSac.Rows[e.RowIndex].Cells["Name"].Value?.ToString();
            }
        }

        #endregion


        #region ================= 3. QUẢN LÝ KÍCH CỠ (SIZE) =================

        private void LoadDataKichThuoc()
        {
            try
            {
                dgvKichThuoc.DataSource = _controller.GetAllSizes();

                if (dgvKichThuoc.Columns["Id"] != null) dgvKichThuoc.Columns["Id"].Visible = false;
                if (dgvKichThuoc.Columns["IsActive"] != null) dgvKichThuoc.Columns["IsActive"].Visible = false;

                if (dgvKichThuoc.Columns["Name"] != null) dgvKichThuoc.Columns["Name"].HeaderText = "Kích Cỡ (Size)";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải Kích cỡ: " + ex.Message); }
        }

        private void btnThemSize_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSize.Text))
            {
                MessageBox.Show("Tên Size không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var size = new Size { Name = txtTenSize.Text.Trim(), IsActive = true };

            if (_controller.AddSize(size))
            {
                LoadDataKichThuoc();
                txtTenSize.Clear();
            }
            else MessageBox.Show("Thêm thất bại. Có thể Size này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSuaSize_Click(object sender, EventArgs e)
        {
            if (dgvKichThuoc.CurrentRow == null) return;

            var size = new Size
            {
                Id = Convert.ToInt32(dgvKichThuoc.CurrentRow.Cells["Id"].Value),
                Name = txtTenSize.Text.Trim(),
                IsActive = true
            };

            if (_controller.UpdateSize(size))
            {
                LoadDataKichThuoc();
            }
        }

        private void btnXoaSize_Click(object sender, EventArgs e)
        {
            if (dgvKichThuoc.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvKichThuoc.CurrentRow.Cells["Id"].Value);
            string name = dgvKichThuoc.CurrentRow.Cells["Name"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa Size '{name}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_controller.DeleteSize(id))
                {
                    LoadDataKichThuoc();
                    txtTenSize.Clear();
                }
                else MessageBox.Show("Không thể xóa Size này vì đang có sản phẩm liên kết!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKichThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtTenSize.Text = dgvKichThuoc.Rows[e.RowIndex].Cells["Name"].Value?.ToString();
            }
        }

        #endregion
    }
}
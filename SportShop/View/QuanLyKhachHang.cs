using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using SportShop.Controller;
using SportShop.Model;

namespace SportShop.View
{
    public partial class QuanLyKhachHang : UserControl
    {
        private QuanLyKhachHangController _customerController = new QuanLyKhachHangController();

        public QuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvKhachHang.DataSource = _customerController.GetAllCustomers();
            CustomGridView();
        }

        private void CustomGridView()
        {
            if (dgvKhachHang.Columns["Id"] != null) dgvKhachHang.Columns["Id"].HeaderText = "Mã KH";
            if (dgvKhachHang.Columns["Name"] != null) dgvKhachHang.Columns["Name"].HeaderText = "Họ Tên";
            if (dgvKhachHang.Columns["Phone"] != null) dgvKhachHang.Columns["Phone"].HeaderText = "Số Điện Thoại";
            if (dgvKhachHang.Columns["Address"] != null) dgvKhachHang.Columns["Address"].HeaderText = "Địa Chỉ";
            

            // Bổ sung hiển thị Điểm tích lũy trên lưới
            if (dgvKhachHang.Columns["LoyaltyPoints"] != null)
            {
                dgvKhachHang.Columns["LoyaltyPoints"].HeaderText = "Điểm Tích Lũy";
                dgvKhachHang.Columns["LoyaltyPoints"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvKhachHang.Columns["CreatedAt"] != null) dgvKhachHang.Columns["CreatedAt"].Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập ít nhất Họ tên và Số điện thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var customer = new Customer
            {
                Name = txtHoTen.Text.Trim(),
                Phone = txtSDT.Text.Trim(),
                Address = txtDiaChi.Text.Trim(),
               
                LoyaltyPoints = 0 // Khách mới tạo mặc định 0 điểm
            };

            if (_customerController.AddCustomer(customer))
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnLamMoi_Click(null, null);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null) return;

            var customer = new Customer
            {
                Id = Convert.ToInt32(dgvKhachHang.CurrentRow.Cells["Id"].Value),
                Name = txtHoTen.Text.Trim(),
                Phone = txtSDT.Text.Trim(),
                Address = txtDiaChi.Text.Trim(),
                
                // Giữ nguyên điểm tích lũy cũ khi cập nhật thông tin
                LoyaltyPoints = Convert.ToInt32(dgvKhachHang.CurrentRow.Cells["LoyaltyPoints"].Value ?? 0)
            };

            if (_customerController.UpdateCustomer(customer))
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvKhachHang.CurrentRow.Cells["Id"].Value);
            string name = dgvKhachHang.CurrentRow.Cells["Name"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng '{name}'?\n(Lịch sử hóa đơn của khách sẽ vẫn được giữ lại để đối soát doanh thu)", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_customerController.DeleteCustomer(id))
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btnLamMoi_Click(null, null);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
           
            txtTimKiem.Clear();

            // Xóa rỗng các thông tin hiển thị phụ
            if (this.Controls.Find("lblDiemTichLuy", true).Length > 0) this.Controls.Find("lblDiemTichLuy", true)[0].Text = "0";
            if (this.Controls.Find("lblTongChiTieu", true).Length > 0) this.Controls.Find("lblTongChiTieu", true)[0].Text = "0 ₫";
            if (this.Controls.Find("dgvLichSuMua", true).Length > 0) ((DataGridView)this.Controls.Find("dgvLichSuMua", true)[0]).DataSource = null;

            LoadData();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = _customerController.SearchCustomers(txtTimKiem.Text.Trim());
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

                int customerId = Convert.ToInt32(row.Cells["Id"].Value);

                // 1. Điền thông tin cơ bản
                txtHoTen.Text = row.Cells["Name"].Value?.ToString();
                txtSDT.Text = row.Cells["Phone"].Value?.ToString();
                txtDiaChi.Text = row.Cells["Address"].Value?.ToString();
                

                // 2. Hiển thị Điểm Tích Lũy (Chỉ cập nhật nếu trên giao diện bạn có kéo label tên là lblDiemTichLuy)
                int diem = Convert.ToInt32(row.Cells["LoyaltyPoints"].Value ?? 0);
                if (this.Controls.Find("lblDiemTichLuy", true).Length > 0)
                {
                    this.Controls.Find("lblDiemTichLuy", true)[0].Text = diem.ToString("N0") + " điểm";
                }

                // 3. Tính Tổng Chi Tiêu (Chỉ cập nhật nếu có label tên là lblTongChiTieu)
                decimal tongChiTieu = _customerController.GetCustomerTotalSpend(customerId);
                if (this.Controls.Find("lblTongChiTieu", true).Length > 0)
                {
                    this.Controls.Find("lblTongChiTieu", true)[0].Text = tongChiTieu.ToString("N0") + " ₫";
                }

                // 4. Tải Lịch sử mua hàng (Chỉ cập nhật nếu có DataGridView tên là dgvLichSuMua)
                if (this.Controls.Find("dgvLichSuMua", true).Length > 0)
                {
                    DataGridView dgvLichSuMua = (DataGridView)this.Controls.Find("dgvLichSuMua", true)[0];
                    DataTable dtLichSu = _customerController.GetCustomerPurchaseHistory(customerId);
                    dgvLichSuMua.DataSource = dtLichSu;

                    // Format hiển thị tiền cho đẹp
                    if (dgvLichSuMua.Columns["Tổng Tiền"] != null)
                        dgvLichSuMua.Columns["Tổng Tiền"].DefaultCellStyle.Format = "N0";
                    if (dgvLichSuMua.Columns["Giảm Giá"] != null)
                        dgvLichSuMua.Columns["Giảm Giá"].DefaultCellStyle.Format = "N0";
                }
            }
        }
    }
}
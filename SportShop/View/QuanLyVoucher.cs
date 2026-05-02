using SportShop.Controller;
using SportShop.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SportShop.View
{
    public partial class QuanLyVoucher : UserControl
    {
        private QuanLyVoucherController _voucherController = new QuanLyVoucherController();

        public QuanLyVoucher()
        {
            InitializeComponent();
        }

        private void QuanLyVoucher_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvVoucher.DataSource = _voucherController.GetAllVouchers();
                CustomGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Voucher: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomGridView()
        {
            // Ẩn các cột không cần thiết
            if (dgvVoucher.Columns["Id"] != null) dgvVoucher.Columns["Id"].Visible = false;
            if (dgvVoucher.Columns["CreatedAt"] != null) dgvVoucher.Columns["CreatedAt"].Visible = false;
            if (dgvVoucher.Columns["UpdatedAt"] != null) dgvVoucher.Columns["UpdatedAt"].Visible = false;

            // Đổi tên và format các cột hiển thị
            if (dgvVoucher.Columns["Code"] != null) dgvVoucher.Columns["Code"].HeaderText = "Mã Voucher";

            if (dgvVoucher.Columns["DiscountPercent"] != null) dgvVoucher.Columns["DiscountPercent"].HeaderText = "Giảm Giá (%)";

            if (dgvVoucher.Columns["MaxUsage"] != null) dgvVoucher.Columns["MaxUsage"].HeaderText = "Giới Hạn Tổng";

            if (dgvVoucher.Columns["CurrentUsage"] != null) dgvVoucher.Columns["CurrentUsage"].HeaderText = "Đã Dùng";

            if (dgvVoucher.Columns["PerCustomerLimit"] != null) dgvVoucher.Columns["PerCustomerLimit"].HeaderText = "Giới Hạn/Khách";

            if (dgvVoucher.Columns["MinimumOrderAmount"] != null) // Đã sửa tên chuẩn
            {
                dgvVoucher.Columns["MinimumOrderAmount"].HeaderText = "Đơn Tối Thiểu (₫)";
                dgvVoucher.Columns["MinimumOrderAmount"].DefaultCellStyle.Format = "N0";
            }

            if (dgvVoucher.Columns["ExpiryDate"] != null) // Đã sửa tên chuẩn
            {
                dgvVoucher.Columns["ExpiryDate"].HeaderText = "Ngày Hết Hạn";
                dgvVoucher.Columns["ExpiryDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            if (dgvVoucher.Columns["IsActive"] != null) dgvVoucher.Columns["IsActive"].HeaderText = "Đang Hoạt Động";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Voucher!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gán dữ liệu vào Model (Có bổ sung kiểm tra null cho các NumericUpDown nếu bạn chưa kéo vào giao diện)
            var voucher = new Voucher
            {
                Code = txtCode.Text.Trim().ToUpper(),
                DiscountPercent = (int)nmDiscount.Value,
                MinimumOrderAmount = nmMinOrder.Value,
                ExpiryDate = dtpExpiration.Value,
                IsActive = chkIsActive.Checked,

                // Bổ sung lấy giá trị từ UI (Nếu form bạn có nmMaxUsage và nmPerCustomerLimit)
                // Nếu chưa có trên form, bạn có thể thiết lập mặc định (VD: PerCustomerLimit = 1)
                MaxUsage = this.Controls.Find("nmMaxUsage", true).Length > 0 ? (int?)((NumericUpDown)this.Controls.Find("nmMaxUsage", true)[0]).Value : null,
                PerCustomerLimit = this.Controls.Find("nmPerCustomerLimit", true).Length > 0 ? (int)((NumericUpDown)this.Controls.Find("nmPerCustomerLimit", true)[0]).Value : 1
            };

            try
            {
                if (_voucherController.AddVoucher(voucher))
                {
                    MessageBox.Show("Thêm mã khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btnLamMoi_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                // Hứng lỗi trùng mã từ Controller ném ra
                MessageBox.Show(ex.Message, "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvVoucher.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một Voucher để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var voucher = new Voucher
            {
                Id = Convert.ToInt32(dgvVoucher.CurrentRow.Cells["Id"].Value),
                Code = txtCode.Text.Trim().ToUpper(),
                DiscountPercent = (int)nmDiscount.Value,
                MinimumOrderAmount = nmMinOrder.Value,
                ExpiryDate = dtpExpiration.Value,
                IsActive = chkIsActive.Checked,

                MaxUsage = this.Controls.Find("nmMaxUsage", true).Length > 0 ? (int?)((NumericUpDown)this.Controls.Find("nmMaxUsage", true)[0]).Value : null,
                PerCustomerLimit = this.Controls.Find("nmPerCustomerLimit", true).Length > 0 ? (int)((NumericUpDown)this.Controls.Find("nmPerCustomerLimit", true)[0]).Value : 1
            };

            try
            {
                if (_voucherController.UpdateVoucher(voucher))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvVoucher.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvVoucher.CurrentRow.Cells["Id"].Value);
            string code = dgvVoucher.CurrentRow.Cells["Code"].Value.ToString();
            int currentUsage = Convert.ToInt32(dgvVoucher.CurrentRow.Cells["CurrentUsage"].Value ?? 0);

            string msg = currentUsage > 0
                ? $"Mã {code} đã được sử dụng {currentUsage} lần.\nHệ thống sẽ khóa (Vô hiệu hóa) mã này thay vì xóa vĩnh viễn để bảo toàn lịch sử hóa đơn.\n\nTiếp tục?"
                : $"Bạn có chắc chắn muốn xóa vĩnh viễn mã {code} không?";

            if (MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_voucherController.DeleteVoucher(id))
                {
                    MessageBox.Show("Đã xử lý thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btnLamMoi_Click(null, null);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtCode.Clear();
            nmDiscount.Value = 0;
            nmMinOrder.Value = 0;
            dtpExpiration.Value = DateTime.Now.AddDays(7); // Mặc định hạn là 7 ngày tới
            chkIsActive.Checked = true;
            txtTimKiem.Clear();

            if (this.Controls.Find("nmMaxUsage", true).Length > 0) ((NumericUpDown)this.Controls.Find("nmMaxUsage", true)[0]).Value = 0;
            if (this.Controls.Find("nmPerCustomerLimit", true).Length > 0) ((NumericUpDown)this.Controls.Find("nmPerCustomerLimit", true)[0]).Value = 1;

            LoadData();
        }

        private void dgvVoucher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVoucher.Rows[e.RowIndex];

                txtCode.Text = row.Cells["Code"].Value?.ToString();
                nmDiscount.Value = Convert.ToDecimal(row.Cells["DiscountPercent"].Value ?? 0);
                nmMinOrder.Value = Convert.ToDecimal(row.Cells["MinimumOrderAmount"].Value ?? 0);

                if (row.Cells["ExpiryDate"].Value != DBNull.Value)
                    dtpExpiration.Value = Convert.ToDateTime(row.Cells["ExpiryDate"].Value);

                chkIsActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value ?? false);

                if (this.Controls.Find("nmMaxUsage", true).Length > 0)
                    ((NumericUpDown)this.Controls.Find("nmMaxUsage", true)[0]).Value = Convert.ToDecimal(row.Cells["MaxUsage"].Value ?? 0);

                if (this.Controls.Find("nmPerCustomerLimit", true).Length > 0)
                    ((NumericUpDown)this.Controls.Find("nmPerCustomerLimit", true)[0]).Value = Convert.ToDecimal(row.Cells["PerCustomerLimit"].Value ?? 1);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            dgvVoucher.DataSource = _voucherController.SearchVouchers(keyword);
        }
    }
}
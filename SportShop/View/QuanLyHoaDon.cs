using FastReport;
using FastReport.Export.PdfSimple;
using SportShop.Controller;
using SportShop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace SportShop.View
{
    public partial class QuanLyHoaDon : UserControl
    {
        private DataTable dtGioHang = new DataTable();
        private decimal giamGia = 0;
        private int _sanPhamDuocChon = -1;
        private int phanTramGiam = 0;
        private decimal tongTienTruocGiam = 0;

        // --- CÁC BIẾN CHO ĐIỂM LOYALTY ---
        private int _diemKhachHangHienTai = 0;
        private int _diemSuDung = 0;
        private decimal _tienGiamTuDiem = 0;
        // ---------------------------------

        // Khởi tạo các Controller
        private QuanLyVoucherController _voucherController = new QuanLyVoucherController();
        private QuanLyHoaDonController _orderController = new QuanLyHoaDonController();
        private QuanLyKhachHangController _customerController = new QuanLyKhachHangController();
        private QuanLySanPhamController _productController = new QuanLySanPhamController();

        public QuanLyHoaDon(int productId = -1)
        {
            InitializeComponent();
            SetupDataGridView();
            _sanPhamDuocChon = productId;
        }

        private void SetupDataGridView()
        {
            dgvGioHang.DataSource = null;
            dgvGioHang.Columns.Clear();
            dgvGioHang.AutoGenerateColumns = true;

            dtGioHang.Columns.Clear();
            dtGioHang.Columns.Add("IdVariant", typeof(int));
            dtGioHang.Columns.Add("TenSP", typeof(string));
            dtGioHang.Columns.Add("Size", typeof(string));
            dtGioHang.Columns.Add("Mau", typeof(string));
            dtGioHang.Columns.Add("SoLuong", typeof(int));
            dtGioHang.Columns.Add("DonGia", typeof(decimal));
            dtGioHang.Columns.Add("GiamGia", typeof(decimal));
            dtGioHang.Columns.Add("ThanhTien", typeof(decimal));

            dgvGioHang.DataSource = dtGioHang;

            dgvGioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGioHang.MultiSelect = false;
            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGioHang.AllowUserToAddRows = false;

            dgvGioHang.Columns["IdVariant"].Visible = false;
            dgvGioHang.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            dgvGioHang.Columns["Size"].HeaderText = "Kích Cỡ";
            dgvGioHang.Columns["Mau"].HeaderText = "Màu Sắc";
            dgvGioHang.Columns["SoLuong"].HeaderText = "SL";
            dgvGioHang.Columns["DonGia"].HeaderText = "Đơn Giá (₫)";
            dgvGioHang.Columns["GiamGia"].HeaderText = "Giảm Giá (₫)";
            dgvGioHang.Columns["ThanhTien"].HeaderText = "Thành Tiền (₫)";

            dgvGioHang.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvGioHang.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGioHang.Columns["GiamGia"].DefaultCellStyle.Format = "N0";
            dgvGioHang.Columns["GiamGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGioHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvGioHang.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGioHang.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            LoadComboBoxSanPham();
            LoadComboBoxPhuongThucThanhToan();
            cboSanPham.SelectedIndexChanged += CboSanPham_SelectedIndexChanged;

            // 👉 Đăng ký sự kiện Tự động tìm khách hàng khi nhập xong SĐT
            txtSoDienThoai.Leave += TxtSoDienThoai_Leave;

            NhanDuLieuTuGioHang();

            if (_sanPhamDuocChon != -1)
            {
                cboSanPham.SelectedValue = _sanPhamDuocChon;
            }
        }

        // =======================================================
        // CƠ CHẾ TÌM KHÁCH HÀNG & ĐIỂM LOYALTY
        // =======================================================
        private void TxtSoDienThoai_Leave(object sender, EventArgs e)
        {
            string sdt = txtSoDienThoai.Text.Trim();
            if (!string.IsNullOrEmpty(sdt))
            {
                var customers = _customerController.SearchCustomers(sdt);
                if (customers.Count > 0)
                {
                    var cus = customers[0];
                    txtTenKhachHang.Text = cus.Name;
                    txtDiaChi.Text = cus.Address;

                    // Giả sử Model Customer của bạn có cột LoyaltyPoints (nếu tên khác bạn tự sửa lại nhé)
                    _diemKhachHangHienTai = cus.LoyaltyPoints ?? 0;

                    lblDiemKhaDung.Text = $"Điểm hiện có: {_diemKhachHangHienTai}";
                    nmDiemSuDung.Maximum = _diemKhachHangHienTai;
                }
                else
                {
                    ResetDiemLoyalty();
                }
            }
            else
            {
                ResetDiemLoyalty();
            }
        }

        private void ResetDiemLoyalty()
        {
            _diemKhachHangHienTai = 0;
            _diemSuDung = 0;
            _tienGiamTuDiem = 0;
            lblDiemKhaDung.Text = "Điểm hiện có: 0";
            if (nmDiemSuDung != null)
            {
                nmDiemSuDung.Maximum = 0;
                nmDiemSuDung.Value = 0;
            }
        }

       

        private void btnApDiem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem khách có nhập lố số điểm mình đang có không
            if (nmDiemSuDung.Value > _diemKhachHangHienTai)
            {
                MessageBox.Show($"Khách hàng chỉ có tối đa {_diemKhachHangHienTai} điểm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nmDiemSuDung.Value = _diemKhachHangHienTai;
            }

            // Chốt số điểm dùng và chạy hàm tính tiền
            _diemSuDung = (int)nmDiemSuDung.Value;
            _tienGiamTuDiem = _diemSuDung * 100;
            TinhTongTien();
        }

        private void btnDungAllDiem_Click(object sender, EventArgs e)
        {
            if (_diemKhachHangHienTai > 0)
            {
                nmDiemSuDung.Value = _diemKhachHangHienTai;

                // Tự động kích hoạt luôn tính tiền khi bấm Dùng All cho nhanh
                _diemSuDung = _diemKhachHangHienTai;
                _tienGiamTuDiem = _diemSuDung * 1000;
                TinhTongTien();
            }
            else
            {
                MessageBox.Show("Khách hàng hiện chưa có điểm tích lũy nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // =======================================================
        // CÁC HÀM XỬ LÝ SẢN PHẨM & GIỎ HÀNG NHƯ CŨ
        // =======================================================
        private void NhanDuLieuTuGioHang()
        {
            if (SportShop.Model.CartManager.CurrentCart != null && SportShop.Model.CartManager.CurrentCart.Count > 0)
            {
                foreach (var item in SportShop.Model.CartManager.CurrentCart)
                {
                    dtGioHang.Rows.Add(0, item.ProductName, "(Chọn Size)", "(Chọn Màu)", 1, item.Price, 0, item.Price);
                }

                SportShop.Model.CartManager.CurrentCart.Clear();
                TinhTongTien();

                MessageBox.Show("Đã nhận sản phẩm từ Giỏ Hàng!\n\nLưu ý: Vui lòng click vào từng món, chọn Size và Màu sắc rồi bấm SỬA để hoàn thiện thông tin trước khi thanh toán.", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadComboBoxPhuongThucThanhToan()
        {
            if (cboPhuongThucThanhToan != null)
            {
                cboPhuongThucThanhToan.Items.Clear();
                cboPhuongThucThanhToan.Items.Add("Tiền mặt");
                cboPhuongThucThanhToan.Items.Add("Chuyển khoản");
                cboPhuongThucThanhToan.SelectedIndex = 0;
            }
        }

        private void LoadComboBoxSanPham()
        {
            try
            {
                var danhSachSP = _productController.GetAllProducts().Where(p => p.IsActive == true).ToList();
                cboSanPham.DataSource = danhSachSP;
                cboSanPham.DisplayMember = "Name";
                cboSanPham.ValueMember = "Id";
                cboSanPham.SelectedIndex = -1;
            }
            catch { }
        }

        private void CboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue == null || !(cboSanPham.SelectedValue is int)) return;

            int pId = (int)cboSanPham.SelectedValue;
            LoadSize(pId);
            LoadMauSac(pId);
        }

        private void LoadSize(int productId)
        {
            try
            {
                var variants = _productController.GetVariantsByProductId(productId).Where(v => v.IsActive == true).ToList();
                var sizes = variants.GroupBy(v => v.SizeId)
                                    .Select(g => new { Id = g.Key, Name = g.First().SizeName })
                                    .ToList();

                cboSize.DataSource = sizes;
                cboSize.DisplayMember = "Name";
                cboSize.ValueMember = "Id";
            }
            catch { }
        }

        private void LoadMauSac(int productId)
        {
            try
            {
                var variants = _productController.GetVariantsByProductId(productId).Where(v => v.IsActive == true).ToList();
                var colors = variants.GroupBy(v => v.ColorId)
                                     .Select(g => new { Id = g.Key, Name = g.First().ColorName })
                                     .ToList();

                cboMauSac.DataSource = colors;
                cboMauSac.DisplayMember = "Name";
                cboMauSac.ValueMember = "Id";
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedIndex == -1 || cboSize.SelectedIndex == -1 || cboMauSac.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin sản phẩm (Tên, Size, Màu)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int pId = (int)cboSanPham.SelectedValue;
                int sId = (int)cboSize.SelectedValue;
                int cId = (int)cboMauSac.SelectedValue;

                var variant = _productController.GetVariantsByProductId(pId)
                                                .FirstOrDefault(v => v.SizeId == sId && v.ColorId == cId && v.IsActive == true);

                if (variant != null)
                {
                    int soLuongMuonMua = (int)nmSoLuong.Value;
                    if (soLuongMuonMua <= 0) { MessageBox.Show("Số lượng phải lớn hơn 0!"); return; }

                    int tonKho = variant.Quantity;
                    if (soLuongMuonMua > tonKho)
                    {
                        MessageBox.Show($"Tồn kho không đủ! Sản phẩm này chỉ còn {tonKho} chiếc.", "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int variantId = variant.Id;
                    decimal donGia = variant.SellingPrice;

                    DataRow[] existRows = dtGioHang.Select($"IdVariant = {variantId}");
                    if (existRows.Length > 0)
                    {
                        int slHienTai = Convert.ToInt32(existRows[0]["SoLuong"]);
                        if (slHienTai + soLuongMuonMua > tonKho)
                        {
                            MessageBox.Show($"Tổng số lượng trong giỏ vượt quá tồn kho ({tonKho} chiếc).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        existRows[0]["SoLuong"] = slHienTai + soLuongMuonMua;
                    }
                    else
                    {
                        dtGioHang.Rows.Add(variantId, cboSanPham.Text, cboSize.Text, cboMauSac.Text, soLuongMuonMua, donGia, 0, 0);
                    }

                    TinhTongTien();
                }
                else
                {
                    MessageBox.Show("Phiên bản (Size/Màu) này đã hết hoặc không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow != null)
            {
                int rowIndex = dgvGioHang.CurrentRow.Index;
                int slMoi = (int)nmSoLuong.Value;

                if (slMoi <= 0) { MessageBox.Show("Số lượng phải lớn hơn 0!"); return; }

                if (cboSanPham.SelectedIndex != -1 && cboSize.SelectedIndex != -1 && cboMauSac.SelectedIndex != -1)
                {
                    int pId = (int)cboSanPham.SelectedValue;
                    int sId = (int)cboSize.SelectedValue;
                    int cId = (int)cboMauSac.SelectedValue;

                    var variant = _productController.GetVariantsByProductId(pId)
                                                    .FirstOrDefault(v => v.SizeId == sId && v.ColorId == cId && v.IsActive == true);
                    if (variant != null)
                    {
                        int tonKho = variant.Quantity;
                        int slDaCoTrongGio = 0;

                        foreach (DataRow r in dtGioHang.Rows)
                        {
                            if (dtGioHang.Rows.IndexOf(r) != rowIndex && Convert.ToInt32(r["IdVariant"]) == variant.Id)
                            {
                                slDaCoTrongGio += Convert.ToInt32(r["SoLuong"]);
                            }
                        }

                        if (slDaCoTrongGio + slMoi > tonKho)
                        {
                            MessageBox.Show($"Tồn kho không đủ! Sản phẩm này hiện chỉ còn {tonKho} chiếc\n(Bạn đã có {slDaCoTrongGio} chiếc ở dòng khác trong giỏ hàng).", "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        dtGioHang.Rows[rowIndex]["IdVariant"] = variant.Id;
                        dtGioHang.Rows[rowIndex]["Size"] = cboSize.Text;
                        dtGioHang.Rows[rowIndex]["Mau"] = cboMauSac.Text;
                        dtGioHang.Rows[rowIndex]["DonGia"] = variant.SellingPrice;
                    }
                    else
                    {
                        MessageBox.Show("Phiên bản (Size/Màu) này đã hết hoặc không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin Sản phẩm, Size và Màu sắc trên thanh chọn để tiến hành sửa!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dtGioHang.Rows[rowIndex]["SoLuong"] = slMoi;
                TinhTongTien();

                MessageBox.Show("Đã cập nhật thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng sản phẩm trong giỏ hàng để sửa!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow != null)
            {
                dtGioHang.Rows.RemoveAt(dgvGioHang.CurrentRow.Index);
                TinhTongTien();
            }
        }

        private void dgvGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string tenSP = dgvGioHang.Rows[e.RowIndex].Cells["TenSP"].Value.ToString();
                cboSanPham.SelectedIndex = cboSanPham.FindStringExact(tenSP);

                nmSoLuong.Value = Convert.ToInt32(dgvGioHang.Rows[e.RowIndex].Cells["SoLuong"].Value);
            }
        }

        // =======================================================
        // TÍNH TOÁN TIỀN (GỘP CẢ VOUCHER VÀ ĐIỂM LOYALTY)
        // =======================================================
        private void TinhTongTien()
        {
            decimal tongGiamGiaVoucher = 0;
            decimal tongTienSauGiamVoucher = 0;
            tongTienTruocGiam = 0;

            dgvGioHang.SuspendLayout();

            foreach (DataRow r in dtGioHang.Rows)
            {
                decimal donGia = Convert.ToDecimal(r["DonGia"]);
                int soLuong = Convert.ToInt32(r["SoLuong"]);

                decimal tienGoc = donGia * soLuong;
                tongTienTruocGiam += tienGoc;

                decimal giamGiaMon = tienGoc * phanTramGiam / 100;
                decimal thanhTien = tienGoc - giamGiaMon;

                r.BeginEdit();
                r["GiamGia"] = giamGiaMon;
                r["ThanhTien"] = thanhTien;
                r.EndEdit();

                tongGiamGiaVoucher += giamGiaMon;
                tongTienSauGiamVoucher += thanhTien;
            }

            dtGioHang.AcceptChanges();
            dgvGioHang.ResumeLayout();
            dgvGioHang.Refresh();

            giamGia = tongGiamGiaVoucher;

            // Xử lý cấn trừ điểm để không bị âm tiền
            if (_tienGiamTuDiem > tongTienSauGiamVoucher)
            {
                // Chỉ cho phép dùng tối đa điểm bằng đúng số tiền đơn hàng
                nmDiemSuDung.Value = Math.Ceiling(tongTienSauGiamVoucher / 1000);
                _tienGiamTuDiem = nmDiemSuDung.Value * 1000;
            }

            decimal tongCuoiCung = tongTienSauGiamVoucher - _tienGiamTuDiem;
            if (tongCuoiCung < 0) tongCuoiCung = 0;

            // Update Label hiển thị
            string txtGiamGia = $"Voucher ({phanTramGiam}%): -{giamGia:N0} ₫\nTừ điểm: -{_tienGiamTuDiem:N0} ₫";
            lblGiamGia.Text = txtGiamGia;

            lblTongTien.Text = "TỔNG: " + tongCuoiCung.ToString("N0") + " ₫";
        }

        private void txtMaVoucher_Click(object sender, EventArgs e)
        {
            string ma = txtVoucher.Text.Trim();

            if (string.IsNullOrEmpty(ma))
            {
                phanTramGiam = 0;
                TinhTongTien();
                MessageBox.Show("Đã hủy áp mã Voucher!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Voucher validVoucher = _voucherController.GetValidVoucherToApply(ma, tongTienTruocGiam);

            if (validVoucher == null)
            {
                phanTramGiam = 0;
                MessageBox.Show("Mã giảm giá không hợp lệ, đã hết hạn, hoặc đơn hàng chưa đạt giá trị tối thiểu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                phanTramGiam = validVoucher.DiscountPercent;
                MessageBox.Show($"Áp mã thành công! Đơn hàng được giảm {phanTramGiam}%.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            TinhTongTien();
        }

        // =======================================================
        // THANH TOÁN & IN BÁO CÁO
        // =======================================================
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                foreach (DataRow r in dtGioHang.Rows)
                {
                    if (Convert.ToInt32(r["IdVariant"]) == 0)
                    {
                        MessageBox.Show($"Sản phẩm '{r["TenSP"]}' chưa được chọn Size và Màu!\n\nVui lòng click vào sản phẩm, chọn thông tin và bấm SỬA.", "Chưa đủ thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                int? customerId = null;
                string sdt = txtSoDienThoai.Text.Trim();

                if (!string.IsNullOrEmpty(sdt))
                {
                    var customers = _customerController.SearchCustomers(sdt);
                    if (customers.Count > 0)
                    {
                        customerId = customers[0].Id;
                    }
                    else
                    {
                        string tenKH = string.IsNullOrWhiteSpace(txtTenKhachHang.Text) ? "Khách vãng lai" : txtTenKhachHang.Text.Trim();
                        string diaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text) ? "" : txtDiaChi.Text.Trim();

                        Customer newCus = new Customer { Name = tenKH, Phone = sdt, Address = diaChi };
                        if (_customerController.AddCustomer(newCus))
                        {
                            var createdCus = _customerController.SearchCustomers(sdt);
                            if (createdCus.Count > 0) customerId = createdCus[0].Id;
                        }
                    }
                }

                int currentUserId = UserSession.CurrentUser != null ? UserSession.CurrentUser.Id : 1;
                string phuongThucThanhToan = cboPhuongThucThanhToan != null && cboPhuongThucThanhToan.SelectedItem != null
                    ? cboPhuongThucThanhToan.SelectedItem.ToString()
                    : "Tiền mặt";

                decimal tongTruocVoucher = tongTienTruocGiam;
                decimal tongDuocGiamGia = giamGia + _tienGiamTuDiem; // Gộp cả giảm voucher + giảm từ điểm
                decimal tongPhaiTra = tongTienTruocGiam - tongDuocGiamGia;
                if (tongPhaiTra < 0) tongPhaiTra = 0;

                Order newOrder = new Order
                {
                    CustomerId = customerId,
                    UserId = currentUserId,
                    OrderDate = DateTime.Now,
                    Subtotal = tongTruocVoucher,
                    DiscountAmount = tongDuocGiamGia,
                    TotalAmount = tongPhaiTra,
                    PaymentMethod = phuongThucThanhToan,
                    Notes = $"Thanh toán tại quầy. (Voucher: -{giamGia:N0}, Điểm: -{_tienGiamTuDiem:N0})"
                };

                List<OrderDetail> details = new List<OrderDetail>();
                foreach (DataRow r in dtGioHang.Rows)
                {
                    details.Add(new OrderDetail
                    {
                        ProductVariantId = Convert.ToInt32(r["IdVariant"]),
                        Quantity = Convert.ToInt32(r["SoLuong"]),
                        UnitPrice = Convert.ToDecimal(r["DonGia"])
                    });
                }

                if (_orderController.AddOrder(newOrder, details))
                {
                    MessageBox.Show("Thanh toán thành công! Hóa đơn đã được lưu.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var result = MessageBox.Show("Bạn có muốn in hóa đơn không?", "In Hóa Đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        btnXuatHoaDon_Click(null, null);
                    }

                    // XỬ LÝ KHÁCH HÀNG THÂN THIẾT SAU KHI MUA THÀNH CÔNG
                    if (customerId.HasValue)
                    {
                        // 1. Trừ số điểm khách đã lấy ra xài
                        if (_diemSuDung > 0)
                        {
                            // YÊU CẦU: Bạn cần có hàm DeductLoyaltyPoints trong _customerController
                            _customerController.DeductLoyaltyPoints(customerId.Value, _diemSuDung);
                        }
                        // 2. Cộng điểm tích lũy mới (Dựa trên số tiền mặt khách trả thực tế)
                        _customerController.AddLoyaltyPoints(customerId.Value, tongPhaiTra);
                    }

                    if (!string.IsNullOrWhiteSpace(txtVoucher.Text))
                    {
                        _voucherController.IncreaseVoucherUsage(txtVoucher.Text.Trim());
                    }

                    btnLamMoi_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Lỗi thanh toán (Kho có thể không đủ số lượng để trừ). Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtGioHang.Rows.Clear();
            txtTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            txtVoucher.Clear();

            ResetDiemLoyalty();

            if (cboPhuongThucThanhToan != null) cboPhuongThucThanhToan.SelectedIndex = 0;

            phanTramGiam = 0;
            giamGia = 0;
            tongTienTruocGiam = 0;
            TinhTongTien();
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống. Không thể in!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (Report report = new Report())
                {
                    report.Load("HoaDon.frx");
                    double tongTienBang = 0;

                    using (DataTable dtReport = new DataTable())
                    {
                        dtReport.Columns.Add("STT", typeof(int));
                        dtReport.Columns.Add("TenSP", typeof(string));
                        dtReport.Columns.Add("MauSac", typeof(string));
                        dtReport.Columns.Add("Size", typeof(string));
                        dtReport.Columns.Add("SoLuong", typeof(int));
                        dtReport.Columns.Add("Gia", typeof(double));
                        dtReport.Columns.Add("GiamGia", typeof(double));
                        dtReport.Columns.Add("ThanhTien", typeof(double));

                        int stt = 1;
                        foreach (DataRow r in dtGioHang.Rows)
                        {
                            string ten = r["TenSP"].ToString();
                            string mau = r["Mau"].ToString();
                            string size = r["Size"].ToString();
                            int sl = Convert.ToInt32(r["SoLuong"]);
                            double gia = Convert.ToDouble(r["DonGia"]);
                            double giamGiaMon = Convert.ToDouble(r["GiamGia"]);
                            double thanhTien = Convert.ToDouble(r["ThanhTien"]);

                            dtReport.Rows.Add(stt, ten, mau, size, sl, gia, giamGiaMon, thanhTien);

                            tongTienBang += thanhTien;
                            stt++;
                        }
                        report.RegisterData(dtReport, "Data");
                    }

                    string tenKH = string.IsNullOrWhiteSpace(txtTenKhachHang.Text) ? "Khách vãng lai" : txtTenKhachHang.Text.Trim();
                    string sdtKH = string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ? "(Không có)" : txtSoDienThoai.Text.Trim();
                    string diaChiKH = string.IsNullOrWhiteSpace(txtDiaChi.Text) ? "(Không có)" : txtDiaChi.Text.Trim();

                    report.SetParameterValue("TenKhachHang", tenKH);
                    report.SetParameterValue("SoDienThoai", sdtKH);
                    report.SetParameterValue("DiaChi", diaChiKH);
                    report.SetParameterValue("NgayIn", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

                    // Trừ đi cả số tiền đổi từ điểm Loyalty khi in hóa đơn
                    double tongCuoi = tongTienBang - Convert.ToDouble(_tienGiamTuDiem);
                    if (tongCuoi < 0) tongCuoi = 0;

                    report.SetParameterValue("TongTien", tongCuoi);

                    report.Prepare();

                    PDFSimpleExport pdfExport = new PDFSimpleExport();
                    string pdfFileName = "HoaDon_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";

                    report.Export(pdfExport, pdfFileName);

                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = pdfFileName,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cấu hình in báo cáo: " + ex.Message + "\n\n(Lưu ý: Bạn cần có file template 'HoaDon.frx' ở thư mục build để in)", "Lỗi in", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
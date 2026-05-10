using System.Drawing;
using System.Windows.Forms;

namespace SportShop.View
{
    partial class QuanLyHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.groupSanPham = new System.Windows.Forms.GroupBox();
            this.cboPhuongThucThanhToan = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMauSac = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nmSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtVoucher = new System.Windows.Forms.TextBox();
            this.btnApVoucher = new System.Windows.Forms.Button();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.groupThanhToan = new System.Windows.Forms.GroupBox();
            this.btnApDiem = new System.Windows.Forms.Button();
            this.btnDungAllDiem = new System.Windows.Forms.Button();
            this.lblDiemKhaDung = new System.Windows.Forms.Label();
            this.labelDiem = new System.Windows.Forms.Label();
            this.nmDiemSuDung = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnXuatHoaDon = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.panelFill = new System.Windows.Forms.Panel();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.groupSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.groupThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiemSuDung)).BeginInit();
            this.panelFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panelTop.Controls.Add(this.groupSanPham);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(15);
            this.panelTop.Size = new System.Drawing.Size(1000, 200);
            this.panelTop.TabIndex = 0;
            // 
            // groupSanPham
            // 
            this.groupSanPham.BackColor = System.Drawing.Color.White;
            this.groupSanPham.Controls.Add(this.cboPhuongThucThanhToan);
            this.groupSanPham.Controls.Add(this.label7);
            this.groupSanPham.Controls.Add(this.btnLamMoi);
            this.groupSanPham.Controls.Add(this.label1);
            this.groupSanPham.Controls.Add(this.cboSanPham);
            this.groupSanPham.Controls.Add(this.label2);
            this.groupSanPham.Controls.Add(this.cboSize);
            this.groupSanPham.Controls.Add(this.label3);
            this.groupSanPham.Controls.Add(this.cboMauSac);
            this.groupSanPham.Controls.Add(this.label4);
            this.groupSanPham.Controls.Add(this.nmSoLuong);
            this.groupSanPham.Controls.Add(this.btnThem);
            this.groupSanPham.Controls.Add(this.btnSua);
            this.groupSanPham.Controls.Add(this.btnXoa);
            this.groupSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSanPham.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupSanPham.Location = new System.Drawing.Point(15, 15);
            this.groupSanPham.Name = "groupSanPham";
            this.groupSanPham.Size = new System.Drawing.Size(970, 170);
            this.groupSanPham.TabIndex = 0;
            this.groupSanPham.TabStop = false;
            this.groupSanPham.Text = "   Chọn Sản Phẩm & Áp Dụng Voucher";
            // 
            // cboPhuongThucThanhToan
            // 
            this.cboPhuongThucThanhToan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPhuongThucThanhToan.FormattingEnabled = true;
            this.cboPhuongThucThanhToan.Location = new System.Drawing.Point(239, 125);
            this.cboPhuongThucThanhToan.Name = "cboPhuongThucThanhToan";
            this.cboPhuongThucThanhToan.Size = new System.Drawing.Size(140, 31);
            this.cboPhuongThucThanhToan.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label7.Location = new System.Drawing.Point(34, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 21);
            this.label7.TabIndex = 16;
            this.label7.Text = "Phương Thức Thanh Toán:";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(810, 75);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 38);
            this.btnLamMoi.TabIndex = 12;
            this.btnLamMoi.Text = "LÀM MỚI";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label1.Location = new System.Drawing.Point(25, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sản phẩm:";
            // 
            // cboSanPham
            // 
            this.cboSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSanPham.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSanPham.Location = new System.Drawing.Point(110, 32);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(380, 31);
            this.cboSanPham.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label2.Location = new System.Drawing.Point(25, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kích cỡ:";
            // 
            // cboSize
            // 
            this.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSize.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSize.Location = new System.Drawing.Point(110, 72);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(130, 31);
            this.cboSize.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label3.Location = new System.Drawing.Point(255, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Màu sắc:";
            // 
            // cboMauSac
            // 
            this.cboMauSac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMauSac.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMauSac.Location = new System.Drawing.Point(325, 72);
            this.cboMauSac.Name = "cboMauSac";
            this.cboMauSac.Size = new System.Drawing.Size(165, 31);
            this.cboMauSac.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label4.Location = new System.Drawing.Point(510, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số lượng:";
            // 
            // nmSoLuong
            // 
            this.nmSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nmSoLuong.Location = new System.Drawing.Point(590, 32);
            this.nmSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmSoLuong.Name = "nmSoLuong";
            this.nmSoLuong.Size = new System.Drawing.Size(80, 30);
            this.nmSoLuong.TabIndex = 8;
            this.nmSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(690, 30);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 38);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "+ THÊM";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(810, 30);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(110, 38);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "SỬA DÒNG";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(690, 75);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 38);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "XÓA DÒNG";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtVoucher
            // 
            this.txtVoucher.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtVoucher.Location = new System.Drawing.Point(29, 168);
            this.txtVoucher.Name = "txtVoucher";
            this.txtVoucher.Size = new System.Drawing.Size(220, 30);
            this.txtVoucher.TabIndex = 13;
            // 
            // btnApVoucher
            // 
            this.btnApVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.btnApVoucher.FlatAppearance.BorderSize = 0;
            this.btnApVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApVoucher.ForeColor = System.Drawing.Color.White;
            this.btnApVoucher.Location = new System.Drawing.Point(259, 168);
            this.btnApVoucher.Name = "btnApVoucher";
            this.btnApVoucher.Size = new System.Drawing.Size(95, 30);
            this.btnApVoucher.TabIndex = 14;
            this.btnApVoucher.Text = "Áp mã";
            this.btnApVoucher.UseVisualStyleBackColor = false;
            this.btnApVoucher.Click += new System.EventHandler(this.txtMaVoucher_Click);
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGiamGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblGiamGia.Location = new System.Drawing.Point(367, 171);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(118, 23);
            this.lblGiamGia.TabIndex = 15;
            this.lblGiamGia.Text = "Giảm giá: 0 ₫";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panelBottom.Controls.Add(this.groupThanhToan);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 610);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.panelBottom.Size = new System.Drawing.Size(1000, 240);
            this.panelBottom.TabIndex = 1;
            // 
            // groupThanhToan
            // 
            this.groupThanhToan.BackColor = System.Drawing.Color.White;
            this.groupThanhToan.Controls.Add(this.btnApDiem);
            this.groupThanhToan.Controls.Add(this.btnDungAllDiem);
            this.groupThanhToan.Controls.Add(this.lblDiemKhaDung);
            this.groupThanhToan.Controls.Add(this.labelDiem);
            this.groupThanhToan.Controls.Add(this.nmDiemSuDung);
            this.groupThanhToan.Controls.Add(this.label5);
            this.groupThanhToan.Controls.Add(this.txtTenKhachHang);
            this.groupThanhToan.Controls.Add(this.label6);
            this.groupThanhToan.Controls.Add(this.txtSoDienThoai);
            this.groupThanhToan.Controls.Add(this.lblDiaChi);
            this.groupThanhToan.Controls.Add(this.txtDiaChi);
            this.groupThanhToan.Controls.Add(this.lblTongTien);
            this.groupThanhToan.Controls.Add(this.btnXuatHoaDon);
            this.groupThanhToan.Controls.Add(this.btnThanhToan);
            this.groupThanhToan.Controls.Add(this.lblGiamGia);
            this.groupThanhToan.Controls.Add(this.btnApVoucher);
            this.groupThanhToan.Controls.Add(this.txtVoucher);
            this.groupThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupThanhToan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupThanhToan.Location = new System.Drawing.Point(15, 10);
            this.groupThanhToan.Name = "groupThanhToan";
            this.groupThanhToan.Size = new System.Drawing.Size(970, 215);
            this.groupThanhToan.TabIndex = 0;
            this.groupThanhToan.TabStop = false;
            this.groupThanhToan.Text = "   Thông tin Khách hàng & Thanh toán";
            // 
            // btnApDiem
            // 
            this.btnApDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.btnApDiem.FlatAppearance.BorderSize = 0;
            this.btnApDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApDiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApDiem.ForeColor = System.Drawing.Color.White;
            this.btnApDiem.Location = new System.Drawing.Point(774, 167);
            this.btnApDiem.Name = "btnApDiem";
            this.btnApDiem.Size = new System.Drawing.Size(80, 31);
            this.btnApDiem.TabIndex = 12;
            this.btnApDiem.Text = "Áp dụng";
            this.btnApDiem.UseVisualStyleBackColor = false;
            this.btnApDiem.Click += new System.EventHandler(this.btnApDiem_Click);
            // 
            // btnDungAllDiem
            // 
            this.btnDungAllDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnDungAllDiem.FlatAppearance.BorderSize = 0;
            this.btnDungAllDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDungAllDiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDungAllDiem.ForeColor = System.Drawing.Color.Black;
            this.btnDungAllDiem.Location = new System.Drawing.Point(860, 167);
            this.btnDungAllDiem.Name = "btnDungAllDiem";
            this.btnDungAllDiem.Size = new System.Drawing.Size(90, 31);
            this.btnDungAllDiem.TabIndex = 13;
            this.btnDungAllDiem.Text = "Dùng All";
            this.btnDungAllDiem.UseVisualStyleBackColor = false;
            this.btnDungAllDiem.Click += new System.EventHandler(this.btnDungAllDiem_Click);
            // 
            // lblDiemKhaDung
            // 
            this.lblDiemKhaDung.AutoSize = true;
            this.lblDiemKhaDung.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDiemKhaDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblDiemKhaDung.Location = new System.Drawing.Point(611, 145);
            this.lblDiemKhaDung.Name = "lblDiemKhaDung";
            this.lblDiemKhaDung.Size = new System.Drawing.Size(128, 21);
            this.lblDiemKhaDung.TabIndex = 9;
            this.lblDiemKhaDung.Text = "Điểm hiện có: 0";
            // 
            // labelDiem
            // 
            this.labelDiem.AutoSize = true;
            this.labelDiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.labelDiem.Location = new System.Drawing.Point(611, 172);
            this.labelDiem.Name = "labelDiem";
            this.labelDiem.Size = new System.Drawing.Size(71, 21);
            this.labelDiem.TabIndex = 10;
            this.labelDiem.Text = "Sử dụng:";
            // 
            // nmDiemSuDung
            // 
            this.nmDiemSuDung.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nmDiemSuDung.Location = new System.Drawing.Point(688, 169);
            this.nmDiemSuDung.Name = "nmDiemSuDung";
            this.nmDiemSuDung.Size = new System.Drawing.Size(80, 30);
            this.nmDiemSuDung.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label5.Location = new System.Drawing.Point(25, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Khách hàng:";
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenKhachHang.Location = new System.Drawing.Point(130, 32);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(280, 30);
            this.txtTenKhachHang.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label6.Location = new System.Drawing.Point(25, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "Điện thoại:";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoDienThoai.Location = new System.Drawing.Point(130, 72);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(280, 30);
            this.txtSoDienThoai.TabIndex = 3;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDiaChi.Location = new System.Drawing.Point(25, 115);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(60, 21);
            this.lblDiaChi.TabIndex = 4;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiaChi.Location = new System.Drawing.Point(130, 112);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(280, 30);
            this.txtDiaChi.TabIndex = 5;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.lblTongTien.Location = new System.Drawing.Point(520, 60);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(271, 46);
            this.lblTongTien.TabIndex = 6;
            this.lblTongTien.Text = "TỔNG TIỀN: 0 ₫";
            // 
            // btnXuatHoaDon
            // 
            this.btnXuatHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnXuatHoaDon.FlatAppearance.BorderSize = 0;
            this.btnXuatHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnXuatHoaDon.Location = new System.Drawing.Point(810, 32);
            this.btnXuatHoaDon.Name = "btnXuatHoaDon";
            this.btnXuatHoaDon.Size = new System.Drawing.Size(140, 45);
            this.btnXuatHoaDon.TabIndex = 7;
            this.btnXuatHoaDon.Text = "📄 XUẤT";
            this.btnXuatHoaDon.UseVisualStyleBackColor = false;
            this.btnXuatHoaDon.Click += new System.EventHandler(this.btnXuatHoaDon_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(810, 85);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(140, 55);
            this.btnThanhToan.TabIndex = 8;
            this.btnThanhToan.Text = " CHỐT";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.dgvGioHang);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 200);
            this.panelFill.Name = "panelFill";
            this.panelFill.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelFill.Size = new System.Drawing.Size(1000, 410);
            this.panelFill.TabIndex = 2;
            // 
            // dgvGioHang
            // 
            this.dgvGioHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvGioHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGioHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGioHang.Location = new System.Drawing.Point(15, 10);
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.RowHeadersWidth = 51;
            this.dgvGioHang.Size = new System.Drawing.Size(970, 390);
            this.dgvGioHang.TabIndex = 0;
            this.dgvGioHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGioHang_CellClick);
            // 
            // QuanLyHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "QuanLyHoaDon";
            this.Size = new System.Drawing.Size(1000, 850);
            this.Load += new System.EventHandler(this.QuanLyHoaDon_Load);
            this.panelTop.ResumeLayout(false);
            this.groupSanPham.ResumeLayout(false);
            this.groupSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.groupThanhToan.ResumeLayout(false);
            this.groupThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiemSuDung)).EndInit();
            this.panelFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.GroupBox groupSanPham;
        private System.Windows.Forms.GroupBox groupThanhToan;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.ComboBox cboMauSac;
        private System.Windows.Forms.NumericUpDown nmSoLuong;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnApVoucher;
        private System.Windows.Forms.Button btnXuatHoaDon;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.TextBox txtVoucher;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDiaChi;
        private Label label7;
        private ComboBox cboPhuongThucThanhToan;

        private System.Windows.Forms.Label lblDiemKhaDung;
        private System.Windows.Forms.Label labelDiem;
        private System.Windows.Forms.NumericUpDown nmDiemSuDung;
        private System.Windows.Forms.Button btnApDiem;
        private System.Windows.Forms.Button btnDungAllDiem;
    }
}
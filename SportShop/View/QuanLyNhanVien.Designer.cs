namespace SportShop.View
{
    partial class QuanLyNhanVien
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

        private void InitializeComponent()
        {
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.nmHourlyRate = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.pnlTinhLuong = new System.Windows.Forms.Panel();
            this.btnTraLuongTatCa = new System.Windows.Forms.Button();
            this.btnTraLuongCaNhan = new System.Windows.Forms.Button();
            this.cboTrangThaiLuong = new System.Windows.Forms.ComboBox();
            this.lblTrangThaiLuong = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.cboKyTinhLuong = new System.Windows.Forms.ComboBox();
            this.lblKyLuong = new System.Windows.Forms.Label();
            this.lblTitleLuong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmHourlyRate)).BeginInit();
            this.pnlTinhLuong.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Location = new System.Drawing.Point(20, 220);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size = new System.Drawing.Size(960, 310);
            this.dgvNhanVien.TabIndex = 0;
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.chkIsActive);
            this.panelTop.Controls.Add(this.nmHourlyRate);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Controls.Add(this.cboRole);
            this.panelTop.Controls.Add(this.label5);
            this.panelTop.Controls.Add(this.txtFullName);
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.txtPassword);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.txtUsername);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Location = new System.Drawing.Point(20, 20);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(960, 120);
            this.panelTop.TabIndex = 1;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(710, 72);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(144, 25);
            this.chkIsActive.TabIndex = 10;
            this.chkIsActive.Text = "Đang hoạt động";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // nmHourlyRate
            // 
            this.nmHourlyRate.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmHourlyRate.Location = new System.Drawing.Point(440, 70);
            this.nmHourlyRate.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nmHourlyRate.Name = "nmHourlyRate";
            this.nmHourlyRate.Size = new System.Drawing.Size(200, 29);
            this.nmHourlyRate.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Lương/giờ (₫):";
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(120, 70);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(180, 29);
            this.cboRole.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Chức vụ:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(710, 22);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(220, 29);
            this.txtFullName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(620, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Họ và tên:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(440, 22);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(140, 29);
            this.txtPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(120, 22);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(180, 29);
            this.txtUsername.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(20, 160);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "THÊM";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(135, 160);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "SỬA";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(250, 160);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "XÓA";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(365, 160);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 35);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "LÀM MỚI";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(600, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(680, 165);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 29);
            this.txtTimKiem.TabIndex = 7;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // pnlTinhLuong
            // 
            this.pnlTinhLuong.BackColor = System.Drawing.Color.White;
            this.pnlTinhLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTinhLuong.Controls.Add(this.btnTraLuongTatCa);
            this.pnlTinhLuong.Controls.Add(this.btnTraLuongCaNhan);
            this.pnlTinhLuong.Controls.Add(this.cboTrangThaiLuong);
            this.pnlTinhLuong.Controls.Add(this.lblTrangThaiLuong);
            this.pnlTinhLuong.Controls.Add(this.dtpDenNgay);
            this.pnlTinhLuong.Controls.Add(this.lblDenNgay);
            this.pnlTinhLuong.Controls.Add(this.dtpTuNgay);
            this.pnlTinhLuong.Controls.Add(this.lblTuNgay);
            this.pnlTinhLuong.Controls.Add(this.cboKyTinhLuong);
            this.pnlTinhLuong.Controls.Add(this.lblKyLuong);
            this.pnlTinhLuong.Controls.Add(this.lblTitleLuong);
            this.pnlTinhLuong.Location = new System.Drawing.Point(20, 550);
            this.pnlTinhLuong.Name = "pnlTinhLuong";
            this.pnlTinhLuong.Size = new System.Drawing.Size(960, 140);
            this.pnlTinhLuong.TabIndex = 8;
            // 
            // btnTraLuongTatCa
            // 
            this.btnTraLuongTatCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(126)))), ((int)(((byte)(20)))));
            this.btnTraLuongTatCa.FlatAppearance.BorderSize = 0;
            this.btnTraLuongTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraLuongTatCa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTraLuongTatCa.ForeColor = System.Drawing.Color.White;
            this.btnTraLuongTatCa.Location = new System.Drawing.Point(580, 88);
            this.btnTraLuongTatCa.Name = "btnTraLuongTatCa";
            this.btnTraLuongTatCa.Size = new System.Drawing.Size(200, 35);
            this.btnTraLuongTatCa.TabIndex = 10;
            this.btnTraLuongTatCa.Text = "TRẢ LƯƠNG TẤT CẢ";
            this.btnTraLuongTatCa.UseVisualStyleBackColor = false;
            // 
            // btnTraLuongCaNhan
            // 
            this.btnTraLuongCaNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnTraLuongCaNhan.FlatAppearance.BorderSize = 0;
            this.btnTraLuongCaNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraLuongCaNhan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTraLuongCaNhan.ForeColor = System.Drawing.Color.White;
            this.btnTraLuongCaNhan.Location = new System.Drawing.Point(365, 88);
            this.btnTraLuongCaNhan.Name = "btnTraLuongCaNhan";
            this.btnTraLuongCaNhan.Size = new System.Drawing.Size(200, 35);
            this.btnTraLuongCaNhan.TabIndex = 9;
            this.btnTraLuongCaNhan.Text = "TRẢ LƯƠNG NHÂN VIÊN NÀY";
            this.btnTraLuongCaNhan.UseVisualStyleBackColor = false;
            this.btnTraLuongCaNhan.Click += new System.EventHandler(this.btnTraLuongCaNhan_Click);
            // 
            // cboTrangThaiLuong
            // 
            this.cboTrangThaiLuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThaiLuong.FormattingEnabled = true;
            this.cboTrangThaiLuong.Items.AddRange(new object[] {
            "Tất cả",
            "Chưa trả",
            "Đã trả"});
            this.cboTrangThaiLuong.Location = new System.Drawing.Point(125, 92);
            this.cboTrangThaiLuong.Name = "cboTrangThaiLuong";
            this.cboTrangThaiLuong.Size = new System.Drawing.Size(140, 29);
            this.cboTrangThaiLuong.TabIndex = 8;
            // 
            // lblTrangThaiLuong
            // 
            this.lblTrangThaiLuong.AutoSize = true;
            this.lblTrangThaiLuong.Location = new System.Drawing.Point(15, 95);
            this.lblTrangThaiLuong.Name = "lblTrangThaiLuong";
            this.lblTrangThaiLuong.Size = new System.Drawing.Size(82, 21);
            this.lblTrangThaiLuong.TabIndex = 7;
            this.lblTrangThaiLuong.Text = "Trạng thái:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(600, 52);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(130, 29);
            this.dtpDenNgay.TabIndex = 6;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(515, 55);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(79, 21);
            this.lblDenNgay.TabIndex = 5;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(365, 52);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(130, 29);
            this.dtpTuNgay.TabIndex = 4;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(290, 55);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(68, 21);
            this.lblTuNgay.TabIndex = 3;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // cboKyTinhLuong
            // 
            this.cboKyTinhLuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKyTinhLuong.FormattingEnabled = true;
            this.cboKyTinhLuong.Items.AddRange(new object[] {
            "Tháng này",
            "Tháng trước",
            "Tùy chọn"});
            this.cboKyTinhLuong.Location = new System.Drawing.Point(125, 52);
            this.cboKyTinhLuong.Name = "cboKyTinhLuong";
            this.cboKyTinhLuong.Size = new System.Drawing.Size(140, 29);
            this.cboKyTinhLuong.TabIndex = 2;
            // 
            // lblKyLuong
            // 
            this.lblKyLuong.AutoSize = true;
            this.lblKyLuong.Location = new System.Drawing.Point(15, 55);
            this.lblKyLuong.Name = "lblKyLuong";
            this.lblKyLuong.Size = new System.Drawing.Size(105, 21);
            this.lblKyLuong.TabIndex = 1;
            this.lblKyLuong.Text = "Kỳ tính lương:";
            // 
            // lblTitleLuong
            // 
            this.lblTitleLuong.AutoSize = true;
            this.lblTitleLuong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitleLuong.Location = new System.Drawing.Point(15, 10);
            this.lblTitleLuong.Name = "lblTitleLuong";
            this.lblTitleLuong.Size = new System.Drawing.Size(236, 25);
            this.lblTitleLuong.TabIndex = 0;
            this.lblTitleLuong.Text = "💸 QUẢN LÝ TRẢ LƯƠNG";
            // 
            // QuanLyNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlTinhLuong);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.dgvNhanVien);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "QuanLyNhanVien";
            this.Size = new System.Drawing.Size(1073, 805);
            this.Load += new System.EventHandler(this.QuanLyNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmHourlyRate)).EndInit();
            this.pnlTinhLuong.ResumeLayout(false);
            this.pnlTinhLuong.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nmHourlyRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimKiem;

        // BIẾN CHO PHẦN TÍNH LƯƠNG
        private System.Windows.Forms.Panel pnlTinhLuong;
        private System.Windows.Forms.Label lblTitleLuong;
        private System.Windows.Forms.Label lblKyLuong;
        private System.Windows.Forms.ComboBox cboKyTinhLuong;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblTrangThaiLuong;
        private System.Windows.Forms.ComboBox cboTrangThaiLuong;
        private System.Windows.Forms.Button btnTraLuongCaNhan;
        private System.Windows.Forms.Button btnTraLuongTatCa;
    }
}
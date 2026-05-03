namespace SportShop.View
{
    partial class QuanLySanPham
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
            this.components = new System.ComponentModel.Container();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.txtDuongDanAnh = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.grpVariant = new System.Windows.Forms.GroupBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.btnThemBienThe = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.picSanPham = new System.Windows.Forms.PictureBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.nmBasePrice = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cboLoaiSP = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.dgvBienThe = new System.Windows.Forms.DataGridView();
            this.lblBienThe = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.panelTop.SuspendLayout();
            this.grpVariant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmBasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBienThe)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSanPham.Location = new System.Drawing.Point(0, 0);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(1086, 264);
            this.dgvSanPham.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.txtDuongDanAnh);
            this.panelTop.Controls.Add(this.label7);
            this.panelTop.Controls.Add(this.txtTimKiem);
            this.panelTop.Controls.Add(this.grpVariant);
            this.panelTop.Controls.Add(this.label5);
            this.panelTop.Controls.Add(this.btnChonAnh);
            this.panelTop.Controls.Add(this.btnThemBienThe);
            this.panelTop.Controls.Add(this.btnLamMoi);
            this.panelTop.Controls.Add(this.picSanPham);
            this.panelTop.Controls.Add(this.btnXoa);
            this.panelTop.Controls.Add(this.txtMoTa);
            this.panelTop.Controls.Add(this.btnSua);
            this.panelTop.Controls.Add(this.label6);
            this.panelTop.Controls.Add(this.btnThem);
            this.panelTop.Controls.Add(this.chkIsActive);
            this.panelTop.Controls.Add(this.nmBasePrice);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Controls.Add(this.cboLoaiSP);
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.txtTenSP);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.txtSKU);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1086, 240);
            this.panelTop.TabIndex = 1;
            // 
            // txtDuongDanAnh
            // 
            this.txtDuongDanAnh.Location = new System.Drawing.Point(814, 174);
            this.txtDuongDanAnh.Name = "txtDuongDanAnh";
            this.txtDuongDanAnh.ReadOnly = true;
            this.txtDuongDanAnh.Size = new System.Drawing.Size(150, 29);
            this.txtDuongDanAnh.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(687, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 21);
            this.label7.TabIndex = 15;
            this.label7.Text = "Đường dẫn ảnh:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(815, 208);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(210, 29);
            this.txtTimKiem.TabIndex = 7;
            // 
            // grpVariant
            // 
            this.grpVariant.Controls.Add(this.lblSize);
            this.grpVariant.Controls.Add(this.cboSize);
            this.grpVariant.Controls.Add(this.lblColor);
            this.grpVariant.Controls.Add(this.cboColor);
            this.grpVariant.Location = new System.Drawing.Point(10, 145);
            this.grpVariant.Name = "grpVariant";
            this.grpVariant.Size = new System.Drawing.Size(360, 80);
            this.grpVariant.TabIndex = 14;
            this.grpVariant.TabStop = false;
            this.grpVariant.Text = "Thông tin Biến thể";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(10, 35);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(41, 21);
            this.lblSize.TabIndex = 0;
            this.lblSize.Text = "Size:";
            // 
            // cboSize
            // 
            this.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Location = new System.Drawing.Point(50, 32);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(80, 29);
            this.cboSize.TabIndex = 1;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(140, 35);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(44, 21);
            this.lblColor.TabIndex = 2;
            this.lblColor.Text = "Màu:";
            // 
            // cboColor
            // 
            this.cboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(185, 32);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(80, 29);
            this.cboColor.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(684, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tìm kiếm nhanh:";
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Location = new System.Drawing.Point(938, 145);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(120, 28);
            this.btnChonAnh.TabIndex = 12;
            this.btnChonAnh.Text = "Chọn Ảnh...";
            this.btnChonAnh.UseVisualStyleBackColor = true;
            // 
            // btnThemBienThe
            // 
            this.btnThemBienThe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnThemBienThe.FlatAppearance.BorderSize = 0;
            this.btnThemBienThe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemBienThe.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThemBienThe.ForeColor = System.Drawing.Color.Black;
            this.btnThemBienThe.Location = new System.Drawing.Point(688, 128);
            this.btnThemBienThe.Name = "btnThemBienThe";
            this.btnThemBienThe.Size = new System.Drawing.Size(167, 35);
            this.btnThemBienThe.TabIndex = 17;
            this.btnThemBienThe.Text = "+ THÊM BIẾN THỂ";
            this.btnThemBienThe.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(815, 73);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(117, 41);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "LÀM MỚI";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // picSanPham
            // 
            this.picSanPham.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSanPham.Location = new System.Drawing.Point(938, 11);
            this.picSanPham.Name = "picSanPham";
            this.picSanPham.Size = new System.Drawing.Size(120, 120);
            this.picSanPham.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSanPham.TabIndex = 11;
            this.picSanPham.TabStop = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(814, 26);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(118, 41);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "XÓA";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(468, 23);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoTa.Size = new System.Drawing.Size(184, 100);
            this.txtMoTa.TabIndex = 10;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(688, 73);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 41);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "SỬA";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "Mô tả:";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(687, 26);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(121, 41);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "THÊM SP";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(468, 128);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(127, 25);
            this.chkIsActive.TabIndex = 8;
            this.chkIsActive.Text = "Đang mở bán";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // nmBasePrice
            // 
            this.nmBasePrice.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmBasePrice.Location = new System.Drawing.Point(120, 110);
            this.nmBasePrice.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nmBasePrice.Name = "nmBasePrice";
            this.nmBasePrice.Size = new System.Drawing.Size(250, 29);
            this.nmBasePrice.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Giá bán (₫):";
            // 
            // cboLoaiSP
            // 
            this.cboLoaiSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiSP.FormattingEnabled = true;
            this.cboLoaiSP.Location = new System.Drawing.Point(120, 66);
            this.cboLoaiSP.Name = "cboLoaiSP";
            this.cboLoaiSP.Size = new System.Drawing.Size(250, 29);
            this.cboLoaiSP.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại SP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên SP:";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(120, 15);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(250, 29);
            this.txtTenSP.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã SKU:";
            // 
            // txtSKU
            // 
            this.txtSKU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSKU.Location = new System.Drawing.Point(468, 186);
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.ReadOnly = true;
            this.txtSKU.Size = new System.Drawing.Size(150, 29);
            this.txtSKU.TabIndex = 0;
            // 
            // dgvBienThe
            // 
            this.dgvBienThe.AllowUserToAddRows = false;
            this.dgvBienThe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBienThe.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvBienThe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBienThe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBienThe.Location = new System.Drawing.Point(0, 0);
            this.dgvBienThe.Name = "dgvBienThe";
            this.dgvBienThe.ReadOnly = true;
            this.dgvBienThe.RowHeadersWidth = 51;
            this.dgvBienThe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBienThe.Size = new System.Drawing.Size(1086, 206);
            this.dgvBienThe.TabIndex = 9;
            // 
            // lblBienThe
            // 
            this.lblBienThe.AutoSize = true;
            this.lblBienThe.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBienThe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblBienThe.Location = new System.Drawing.Point(-4, 507);
            this.lblBienThe.Name = "lblBienThe";
            this.lblBienThe.Size = new System.Drawing.Size(336, 21);
            this.lblBienThe.TabIndex = 8;
            this.lblBienThe.Text = "Danh sách Biến thể của Sản phẩm đã chọn:";
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSanPham);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1086, 264);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvBienThe);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 531);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1086, 206);
            this.panel2.TabIndex = 11;
            // 
            // QuanLySanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblBienThe);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "QuanLySanPham";
            this.Size = new System.Drawing.Size(1086, 737);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.grpVariant.ResumeLayout(false);
            this.grpVariant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmBasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBienThe)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Khai báo controls
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.ComboBox cboLoaiSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmBasePrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picSanPham;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThemBienThe; // <-- Khai báo nút mới
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.GroupBox grpVariant;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.DataGridView dgvBienThe;
        private System.Windows.Forms.Label lblBienThe;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtDuongDanAnh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
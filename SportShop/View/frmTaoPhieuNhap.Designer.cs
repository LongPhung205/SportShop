namespace SportShop.View
{
    partial class frmTaoPhieuNhap
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlAddItem = new System.Windows.Forms.Panel();
            this.btnThemItem = new System.Windows.Forms.Button();
            this.nmGiaNhap = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nmSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuuNhap = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlAddItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmGiaNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(884, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "➕ TẠO PHIẾU NHẬP MỚI";
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.txtGhiChu);
            this.pnlInfo.Controls.Add(this.label2);
            this.pnlInfo.Controls.Add(this.cboNhaCungCap);
            this.pnlInfo.Controls.Add(this.label1);
            this.pnlInfo.Location = new System.Drawing.Point(15, 75);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(850, 80);
            this.pnlInfo.TabIndex = 1;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtGhiChu.Location = new System.Drawing.Point(460, 35);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(370, 31);
            this.txtGhiChu.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(456, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ghi chú:";
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(20, 35);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(380, 33);
            this.cboNhaCungCap.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhà cung cấp:";
            // 
            // pnlAddItem
            // 
            this.pnlAddItem.BackColor = System.Drawing.Color.White;
            this.pnlAddItem.Controls.Add(this.btnThemItem);
            this.pnlAddItem.Controls.Add(this.nmGiaNhap);
            this.pnlAddItem.Controls.Add(this.label5);
            this.pnlAddItem.Controls.Add(this.nmSoLuong);
            this.pnlAddItem.Controls.Add(this.label4);
            this.pnlAddItem.Controls.Add(this.cboSanPham);
            this.pnlAddItem.Controls.Add(this.label3);
            this.pnlAddItem.Location = new System.Drawing.Point(15, 170);
            this.pnlAddItem.Name = "pnlAddItem";
            this.pnlAddItem.Size = new System.Drawing.Size(850, 80);
            this.pnlAddItem.TabIndex = 2;
            // 
            // btnThemItem
            // 
            this.btnThemItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThemItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemItem.FlatAppearance.BorderSize = 0;
            this.btnThemItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThemItem.ForeColor = System.Drawing.Color.White;
            this.btnThemItem.Location = new System.Drawing.Point(680, 32);
            this.btnThemItem.Name = "btnThemItem";
            this.btnThemItem.Size = new System.Drawing.Size(150, 35);
            this.btnThemItem.TabIndex = 6;
            this.btnThemItem.Text = "Thêm Vào Phiếu";
            this.btnThemItem.UseVisualStyleBackColor = false;
            this.btnThemItem.Click += new System.EventHandler(this.btnThemItem_Click);
            // 
            // nmGiaNhap
            // 
            this.nmGiaNhap.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.nmGiaNhap.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            this.nmGiaNhap.Location = new System.Drawing.Point(510, 35);
            this.nmGiaNhap.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.nmGiaNhap.Name = "nmGiaNhap";
            this.nmGiaNhap.Size = new System.Drawing.Size(150, 31);
            this.nmGiaNhap.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(506, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Giá Nhập (₫):";
            // 
            // nmSoLuong
            // 
            this.nmSoLuong.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.nmSoLuong.Location = new System.Drawing.Point(410, 35);
            this.nmSoLuong.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.nmSoLuong.Name = "nmSoLuong";
            this.nmSoLuong.Size = new System.Drawing.Size(80, 31);
            this.nmSoLuong.TabIndex = 3;
            this.nmSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(406, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "SL:";
            // 
            // cboSanPham
            // 
            this.cboSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSanPham.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(20, 35);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(360, 33);
            this.cboSanPham.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(16, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sản phẩm (Màu - Size):";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTiet.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChiTiet.EnableHeadersVisualStyles = false;
            this.dgvChiTiet.Location = new System.Drawing.Point(15, 290);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.RowTemplate.Height = 35;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(850, 310);
            this.dgvChiTiet.TabIndex = 3;
            this.dgvChiTiet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellDoubleClick);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnHuy);
            this.pnlFooter.Controls.Add(this.btnLuuNhap);
            this.pnlFooter.Controls.Add(this.lblTongTien);
            this.pnlFooter.Controls.Add(this.label6);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 623);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(884, 88);
            this.pnlFooter.TabIndex = 4;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(580, 20);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 45);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "HỦY";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuuNhap
            // 
            this.btnLuuNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnLuuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuNhap.FlatAppearance.BorderSize = 0;
            this.btnLuuNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuNhap.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLuuNhap.ForeColor = System.Drawing.Color.White;
            this.btnLuuNhap.Location = new System.Drawing.Point(715, 20);
            this.btnLuuNhap.Name = "btnLuuNhap";
            this.btnLuuNhap.Size = new System.Drawing.Size(150, 45);
            this.btnLuuNhap.TabIndex = 2;
            this.btnLuuNhap.Text = "💾 LƯU NHÁP";
            this.btnLuuNhap.UseVisualStyleBackColor = false;
            this.btnLuuNhap.Click += new System.EventHandler(this.btnLuuNhap_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblTongTien.Location = new System.Drawing.Point(200, 22);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(63, 41);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "0 ₫";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(25, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 28);
            this.label6.TabIndex = 0;
            this.label6.Text = "TỔNG PHẢI TRẢ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(15, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(262, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "* Mẹo: Double Click vào món hàng để xóa";
            // 
            // frmTaoPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(884, 711);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.pnlAddItem);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTaoPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Giỏ Hàng Nhập Kho";
            this.Load += new System.EventHandler(this.frmTaoPhieuNhap_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlAddItem.ResumeLayout(false);
            this.pnlAddItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmGiaNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlAddItem;
        private System.Windows.Forms.Button btnThemItem;
        private System.Windows.Forms.NumericUpDown nmGiaNhap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nmSoLuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuuNhap;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
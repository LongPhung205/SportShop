namespace SportShop.View
{
    partial class QuanLyVoucher
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvVoucher = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.nmPerCustomerLimit = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nmMaxUsage = new System.Windows.Forms.NumericUpDown();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpExpiration = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.nmMinOrder = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nmDiscount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmPerCustomerLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxUsage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(437, 37);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "QUẢN LÝ MÃ KHUYẾN MÃI (VOUCHER)";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.label7);
            this.panelTop.Controls.Add(this.nmPerCustomerLimit);
            this.panelTop.Controls.Add(this.label6);
            this.panelTop.Controls.Add(this.nmMaxUsage);
            this.panelTop.Controls.Add(this.chkIsActive);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Controls.Add(this.dtpExpiration);
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.nmMinOrder);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.nmDiscount);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.txtCode);
            this.panelTop.Location = new System.Drawing.Point(20, 65);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1020, 150);
            this.panelTop.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Voucher:";
            // 
            // txtCode
            // 
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtCode.Location = new System.Drawing.Point(135, 15);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(180, 31);
            this.txtCode.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label2.Location = new System.Drawing.Point(340, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Giảm giá (%):";
            // 
            // nmDiscount
            // 
            this.nmDiscount.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.nmDiscount.Location = new System.Drawing.Point(460, 15);
            this.nmDiscount.Name = "nmDiscount";
            this.nmDiscount.Size = new System.Drawing.Size(100, 31);
            this.nmDiscount.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label3.Location = new System.Drawing.Point(630, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Đơn tối thiểu:";
            // 
            // nmMinOrder
            // 
            this.nmMinOrder.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.nmMinOrder.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            this.nmMinOrder.Location = new System.Drawing.Point(750, 15);
            this.nmMinOrder.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.nmMinOrder.Name = "nmMinOrder";
            this.nmMinOrder.Size = new System.Drawing.Size(180, 31);
            this.nmMinOrder.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label6.Location = new System.Drawing.Point(20, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Giới hạn tổng:";
            // 
            // nmMaxUsage
            // 
            this.nmMaxUsage.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.nmMaxUsage.Location = new System.Drawing.Point(135, 60);
            this.nmMaxUsage.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.nmMaxUsage.Name = "nmMaxUsage";
            this.nmMaxUsage.Size = new System.Drawing.Size(180, 31);
            this.nmMaxUsage.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label7.Location = new System.Drawing.Point(340, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "Giới hạn/Khách:";
            // 
            // nmPerCustomerLimit
            // 
            this.nmPerCustomerLimit.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.nmPerCustomerLimit.Location = new System.Drawing.Point(460, 60);
            this.nmPerCustomerLimit.Name = "nmPerCustomerLimit";
            this.nmPerCustomerLimit.Size = new System.Drawing.Size(100, 31);
            this.nmPerCustomerLimit.TabIndex = 11;
            this.nmPerCustomerLimit.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label4.Location = new System.Drawing.Point(630, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ngày hết hạn:";
            // 
            // dtpExpiration
            // 
            this.dtpExpiration.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpExpiration.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtpExpiration.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpiration.Location = new System.Drawing.Point(750, 60);
            this.dtpExpiration.Name = "dtpExpiration";
            this.dtpExpiration.Size = new System.Drawing.Size(180, 31);
            this.dtpExpiration.TabIndex = 6;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkIsActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.chkIsActive.Location = new System.Drawing.Point(135, 105);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(163, 27);
            this.chkIsActive.TabIndex = 8;
            this.chkIsActive.Text = "Đang hoạt động";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(20, 235);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 40);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "➕ THÊM";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(145, 235);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(110, 40);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "✏️ SỬA";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(270, 235);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 40);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "🗑️ XÓA";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(395, 235);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 40);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "🔄 LÀM MỚI";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(660, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTimKiem.Location = new System.Drawing.Point(760, 240);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(280, 32);
            this.txtTimKiem.TabIndex = 7;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // dgvVoucher
            // 
            this.dgvVoucher.AllowUserToAddRows = false;
            this.dgvVoucher.AllowUserToDeleteRows = false;
            this.dgvVoucher.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVoucher.BackgroundColor = System.Drawing.Color.White;
            this.dgvVoucher.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVoucher.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVoucher.ColumnHeadersHeight = 45;
            this.dgvVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVoucher.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVoucher.EnableHeadersVisualStyles = false;
            this.dgvVoucher.Location = new System.Drawing.Point(20, 295);
            this.dgvVoucher.Name = "dgvVoucher";
            this.dgvVoucher.ReadOnly = true;
            this.dgvVoucher.RowHeadersVisible = false;
            this.dgvVoucher.RowHeadersWidth = 51;
            this.dgvVoucher.RowTemplate.Height = 40;
            this.dgvVoucher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVoucher.Size = new System.Drawing.Size(1020, 500);
            this.dgvVoucher.TabIndex = 0;
            this.dgvVoucher.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVoucher_CellClick);
            // 
            // QuanLyVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.dgvVoucher);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "QuanLyVoucher";
            this.Size = new System.Drawing.Size(1065, 811);
            this.Load += new System.EventHandler(this.QuanLyVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmPerCustomerLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxUsage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVoucher;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nmDiscount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmMinOrder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpExpiration;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nmPerCustomerLimit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nmMaxUsage;
    }
}
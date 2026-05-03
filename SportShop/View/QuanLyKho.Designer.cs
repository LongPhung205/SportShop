namespace SportShop.View
{
    partial class QuanLyKho
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlKho = new System.Windows.Forms.TabControl();
            this.tabTonKho = new System.Windows.Forms.TabPage();
            this.dgvKho = new System.Windows.Forms.DataGridView();
            this.panelTopTonKho = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.tabPhieuNhap = new System.Windows.Forms.TabPage();
            this.splitContainerPhieuNhap = new System.Windows.Forms.SplitContainer();
            this.dgvPhieuNhap = new System.Windows.Forms.DataGridView();
            this.dgvChiTietPhieuNhap = new System.Windows.Forms.DataGridView();
            this.lblChiTietTitle = new System.Windows.Forms.Label();
            this.panelTopPhieuNhap = new System.Windows.Forms.Panel();
            this.lblTitlePhieuNhap = new System.Windows.Forms.Label();
            this.btnTaoPhieu = new System.Windows.Forms.Button();
            this.btnChotKho = new System.Windows.Forms.Button();
            this.btnXoaPhieu = new System.Windows.Forms.Button();
            this.tabControlKho.SuspendLayout();
            this.tabTonKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).BeginInit();
            this.panelTopTonKho.SuspendLayout();
            this.tabPhieuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPhieuNhap)).BeginInit();
            this.splitContainerPhieuNhap.Panel1.SuspendLayout();
            this.splitContainerPhieuNhap.Panel2.SuspendLayout();
            this.splitContainerPhieuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).BeginInit();
            this.panelTopPhieuNhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlKho
            // 
            this.tabControlKho.Controls.Add(this.tabTonKho);
            this.tabControlKho.Controls.Add(this.tabPhieuNhap);
            this.tabControlKho.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabControlKho.ItemSize = new System.Drawing.Size(200, 40);
            this.tabControlKho.Location = new System.Drawing.Point(7, 7);
            this.tabControlKho.Name = "tabControlKho";
            this.tabControlKho.Padding = new System.Drawing.Point(20, 3);
            this.tabControlKho.SelectedIndex = 0;
            this.tabControlKho.Size = new System.Drawing.Size(1045, 791);
            this.tabControlKho.TabIndex = 0;
            // 
            // tabTonKho
            // 
            this.tabTonKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.tabTonKho.Controls.Add(this.dgvKho);
            this.tabTonKho.Controls.Add(this.panelTopTonKho);
            this.tabTonKho.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabTonKho.Location = new System.Drawing.Point(4, 44);
            this.tabTonKho.Name = "tabTonKho";
            this.tabTonKho.Padding = new System.Windows.Forms.Padding(15);
            this.tabTonKho.Size = new System.Drawing.Size(1037, 743);
            this.tabTonKho.TabIndex = 0;
            this.tabTonKho.Text = "📦 XEM TỒN KHO";
            // 
            // dgvKho
            // 
            this.dgvKho.AllowUserToAddRows = false;
            this.dgvKho.AllowUserToDeleteRows = false;
            this.dgvKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKho.BackgroundColor = System.Drawing.Color.White;
            this.dgvKho.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvKho.ColumnHeadersHeight = 45;
            this.dgvKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKho.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKho.EnableHeadersVisualStyles = false;
            this.dgvKho.Location = new System.Drawing.Point(15, 105);
            this.dgvKho.Name = "dgvKho";
            this.dgvKho.ReadOnly = true;
            this.dgvKho.RowHeadersVisible = false;
            this.dgvKho.RowHeadersWidth = 51;
            this.dgvKho.RowTemplate.Height = 40;
            this.dgvKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKho.Size = new System.Drawing.Size(1007, 623);
            this.dgvKho.TabIndex = 0;
            // 
            // panelTopTonKho
            // 
            this.panelTopTonKho.BackColor = System.Drawing.Color.White;
            this.panelTopTonKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTopTonKho.Controls.Add(this.btnLamMoi);
            this.panelTopTonKho.Controls.Add(this.label1);
            this.panelTopTonKho.Controls.Add(this.txtTimKiem);
            this.panelTopTonKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopTonKho.Location = new System.Drawing.Point(15, 15);
            this.panelTopTonKho.Name = "panelTopTonKho";
            this.panelTopTonKho.Size = new System.Drawing.Size(1007, 90);
            this.panelTopTonKho.TabIndex = 1;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(400, 30);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 35);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "🔄 TẢI LẠI";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "🔍 Tìm kiếm sản phẩm trong kho:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTimKiem.Location = new System.Drawing.Point(20, 42);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(350, 32);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // tabPhieuNhap
            // 
            this.tabPhieuNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.tabPhieuNhap.Controls.Add(this.splitContainerPhieuNhap);
            this.tabPhieuNhap.Controls.Add(this.panelTopPhieuNhap);
            this.tabPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabPhieuNhap.Location = new System.Drawing.Point(4, 44);
            this.tabPhieuNhap.Name = "tabPhieuNhap";
            this.tabPhieuNhap.Padding = new System.Windows.Forms.Padding(15);
            this.tabPhieuNhap.Size = new System.Drawing.Size(1037, 743);
            this.tabPhieuNhap.TabIndex = 1;
            this.tabPhieuNhap.Text = "📄 QUẢN LÝ PHIẾU NHẬP";
            // 
            // splitContainerPhieuNhap
            // 
            this.splitContainerPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerPhieuNhap.Location = new System.Drawing.Point(15, 105);
            this.splitContainerPhieuNhap.Name = "splitContainerPhieuNhap";
            this.splitContainerPhieuNhap.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerPhieuNhap.Panel1
            // 
            this.splitContainerPhieuNhap.Panel1.Controls.Add(this.dgvPhieuNhap);
            // 
            // splitContainerPhieuNhap.Panel2
            // 
            this.splitContainerPhieuNhap.Panel2.Controls.Add(this.dgvChiTietPhieuNhap);
            this.splitContainerPhieuNhap.Panel2.Controls.Add(this.lblChiTietTitle);
            this.splitContainerPhieuNhap.Size = new System.Drawing.Size(1007, 623);
            this.splitContainerPhieuNhap.SplitterDistance = 350;
            this.splitContainerPhieuNhap.SplitterWidth = 5;
            this.splitContainerPhieuNhap.TabIndex = 3;
            // 
            // dgvPhieuNhap
            // 
            this.dgvPhieuNhap.AllowUserToAddRows = false;
            this.dgvPhieuNhap.AllowUserToDeleteRows = false;
            this.dgvPhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPhieuNhap.ColumnHeadersHeight = 45;
            this.dgvPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhieuNhap.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuNhap.EnableHeadersVisualStyles = false;
            this.dgvPhieuNhap.Location = new System.Drawing.Point(0, 0);
            this.dgvPhieuNhap.Name = "dgvPhieuNhap";
            this.dgvPhieuNhap.ReadOnly = true;
            this.dgvPhieuNhap.RowHeadersVisible = false;
            this.dgvPhieuNhap.RowHeadersWidth = 51;
            this.dgvPhieuNhap.RowTemplate.Height = 40;
            this.dgvPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuNhap.Size = new System.Drawing.Size(1007, 350);
            this.dgvPhieuNhap.TabIndex = 1;
            // 
            // dgvChiTietPhieuNhap
            // 
            this.dgvChiTietPhieuNhap.AllowUserToAddRows = false;
            this.dgvChiTietPhieuNhap.AllowUserToDeleteRows = false;
            this.dgvChiTietPhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietPhieuNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvChiTietPhieuNhap.ColumnHeadersHeight = 40;
            this.dgvChiTietPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietPhieuNhap.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvChiTietPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietPhieuNhap.EnableHeadersVisualStyles = false;
            this.dgvChiTietPhieuNhap.Location = new System.Drawing.Point(0, 35);
            this.dgvChiTietPhieuNhap.Name = "dgvChiTietPhieuNhap";
            this.dgvChiTietPhieuNhap.ReadOnly = true;
            this.dgvChiTietPhieuNhap.RowHeadersVisible = false;
            this.dgvChiTietPhieuNhap.RowHeadersWidth = 51;
            this.dgvChiTietPhieuNhap.RowTemplate.Height = 35;
            this.dgvChiTietPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietPhieuNhap.Size = new System.Drawing.Size(1007, 233);
            this.dgvChiTietPhieuNhap.TabIndex = 2;
            // 
            // lblChiTietTitle
            // 
            this.lblChiTietTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChiTietTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblChiTietTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblChiTietTitle.Location = new System.Drawing.Point(0, 0);
            this.lblChiTietTitle.Name = "lblChiTietTitle";
            this.lblChiTietTitle.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblChiTietTitle.Size = new System.Drawing.Size(1007, 35);
            this.lblChiTietTitle.TabIndex = 0;
            this.lblChiTietTitle.Text = "👇 CHI TIẾT SẢN PHẨM CỦA PHIẾU ĐANG CHỌN";
            this.lblChiTietTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelTopPhieuNhap
            // 
            this.panelTopPhieuNhap.BackColor = System.Drawing.Color.White;
            this.panelTopPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTopPhieuNhap.Controls.Add(this.lblTitlePhieuNhap);
            this.panelTopPhieuNhap.Controls.Add(this.btnTaoPhieu);
            this.panelTopPhieuNhap.Controls.Add(this.btnChotKho);
            this.panelTopPhieuNhap.Controls.Add(this.btnXoaPhieu);
            this.panelTopPhieuNhap.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopPhieuNhap.Location = new System.Drawing.Point(15, 15);
            this.panelTopPhieuNhap.Name = "panelTopPhieuNhap";
            this.panelTopPhieuNhap.Size = new System.Drawing.Size(1007, 90);
            this.panelTopPhieuNhap.TabIndex = 2;
            // 
            // lblTitlePhieuNhap
            // 
            this.lblTitlePhieuNhap.AutoSize = true;
            this.lblTitlePhieuNhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitlePhieuNhap.Location = new System.Drawing.Point(20, 30);
            this.lblTitlePhieuNhap.Name = "lblTitlePhieuNhap";
            this.lblTitlePhieuNhap.Size = new System.Drawing.Size(257, 28);
            this.lblTitlePhieuNhap.TabIndex = 7;
            this.lblTitlePhieuNhap.Text = "DANH SÁCH PHIẾU NHẬP";
            // 
            // btnTaoPhieu
            // 
            this.btnTaoPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnTaoPhieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoPhieu.FlatAppearance.BorderSize = 0;
            this.btnTaoPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTaoPhieu.ForeColor = System.Drawing.Color.White;
            this.btnTaoPhieu.Location = new System.Drawing.Point(450, 25);
            this.btnTaoPhieu.Name = "btnTaoPhieu";
            this.btnTaoPhieu.Size = new System.Drawing.Size(160, 40);
            this.btnTaoPhieu.TabIndex = 8;
            this.btnTaoPhieu.Text = "➕ TẠO PHIẾU MỚI";
            this.btnTaoPhieu.UseVisualStyleBackColor = false;
            this.btnTaoPhieu.Click += new System.EventHandler(this.btnTaoPhieu_Click);
            // 
            // btnChotKho
            // 
            this.btnChotKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnChotKho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChotKho.FlatAppearance.BorderSize = 0;
            this.btnChotKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChotKho.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnChotKho.ForeColor = System.Drawing.Color.White;
            this.btnChotKho.Location = new System.Drawing.Point(630, 25);
            this.btnChotKho.Name = "btnChotKho";
            this.btnChotKho.Size = new System.Drawing.Size(160, 40);
            this.btnChotKho.TabIndex = 9;
            this.btnChotKho.Text = "✅ DUYỆT / CHỐT KHO";
            this.btnChotKho.UseVisualStyleBackColor = false;
            this.btnChotKho.Click += new System.EventHandler(this.btnChotKho_Click);
            // 
            // btnXoaPhieu
            // 
            this.btnXoaPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoaPhieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaPhieu.FlatAppearance.BorderSize = 0;
            this.btnXoaPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoaPhieu.ForeColor = System.Drawing.Color.White;
            this.btnXoaPhieu.Location = new System.Drawing.Point(810, 25);
            this.btnXoaPhieu.Name = "btnXoaPhieu";
            this.btnXoaPhieu.Size = new System.Drawing.Size(160, 40);
            this.btnXoaPhieu.TabIndex = 10;
            this.btnXoaPhieu.Text = "🗑️ HỦY PHIẾU NHÁP";
            this.btnXoaPhieu.UseVisualStyleBackColor = false;
            this.btnXoaPhieu.Click += new System.EventHandler(this.btnXoaPhieu_Click);
            // 
            // QuanLyKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.tabControlKho);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "QuanLyKho";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1065, 811);
            this.Load += new System.EventHandler(this.QuanLyKho_Load);
            this.tabControlKho.ResumeLayout(false);
            this.tabTonKho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).EndInit();
            this.panelTopTonKho.ResumeLayout(false);
            this.panelTopTonKho.PerformLayout();
            this.tabPhieuNhap.ResumeLayout(false);
            this.splitContainerPhieuNhap.Panel1.ResumeLayout(false);
            this.splitContainerPhieuNhap.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPhieuNhap)).EndInit();
            this.splitContainerPhieuNhap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).EndInit();
            this.panelTopPhieuNhap.ResumeLayout(false);
            this.panelTopPhieuNhap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlKho;
        private System.Windows.Forms.TabPage tabTonKho;
        private System.Windows.Forms.TabPage tabPhieuNhap;
        private System.Windows.Forms.DataGridView dgvKho;
        private System.Windows.Forms.Panel panelTopTonKho;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Panel panelTopPhieuNhap;
        private System.Windows.Forms.Label lblTitlePhieuNhap;
        private System.Windows.Forms.Button btnTaoPhieu;
        private System.Windows.Forms.Button btnChotKho;
        private System.Windows.Forms.Button btnXoaPhieu;

        // Thêm các biến cho SplitContainer và Grid Chi Tiết
        private System.Windows.Forms.SplitContainer splitContainerPhieuNhap;
        private System.Windows.Forms.DataGridView dgvPhieuNhap;
        private System.Windows.Forms.DataGridView dgvChiTietPhieuNhap;
        private System.Windows.Forms.Label lblChiTietTitle;
    }
}
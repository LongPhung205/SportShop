namespace SportShop.View
{
    partial class ThongKeBaoCao
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControlThongKe = new System.Windows.Forms.TabControl();
            this.tabTongQuan = new System.Windows.Forms.TabPage();
            this.panelCard1 = new System.Windows.Forms.Panel();
            this.lblSoSanhDoanhThu = new System.Windows.Forms.Label();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCard2 = new System.Windows.Forms.Panel();
            this.lblSoSanhChiPhi = new System.Windows.Forms.Label();
            this.lblTongDon = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelCard3 = new System.Windows.Forms.Panel();
            this.lblSoSanhLoiNhuan = new System.Windows.Forms.Label();
            this.lblTongKhachHang = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelChart1 = new System.Windows.Forms.Label();
            this.labelChart2 = new System.Windows.Forms.Label();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTopSP = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabChiTiet = new System.Windows.Forms.TabPage();
            this.lblHoaDon = new System.Windows.Forms.Label();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvTopKhachHang = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvTonKhoThap = new System.Windows.Forms.DataGridView();
            this.pnlTopBar.SuspendLayout();
            this.tabControlThongKe.SuspendLayout();
            this.tabTongQuan.SuspendLayout();
            this.panelCard1.SuspendLayout();
            this.panelCard2.SuspendLayout();
            this.panelCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopSP)).BeginInit();
            this.tabChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKhoThap)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopBar.Controls.Add(this.btnXuatExcel);
            this.pnlTopBar.Controls.Add(this.btnLoc);
            this.pnlTopBar.Controls.Add(this.dtpDenNgay);
            this.pnlTopBar.Controls.Add(this.label2);
            this.pnlTopBar.Controls.Add(this.dtpTuNgay);
            this.pnlTopBar.Controls.Add(this.label4);
            this.pnlTopBar.Location = new System.Drawing.Point(20, 15);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1025, 60);
            this.pnlTopBar.TabIndex = 8;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(860, 12);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(150, 35);
            this.btnXuatExcel.TabIndex = 5;
            this.btnXuatExcel.Text = "📊 XUẤT EXCEL";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnLoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(450, 12);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(100, 35);
            this.btnLoc.TabIndex = 4;
            this.btnLoc.Text = "🔍 LỌC";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(300, 15);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(130, 31);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(255, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(100, 15);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(130, 31);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(15, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Từ ngày:";
            // 
            // tabControlThongKe
            // 
            this.tabControlThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlThongKe.Controls.Add(this.tabTongQuan);
            this.tabControlThongKe.Controls.Add(this.tabChiTiet);
            this.tabControlThongKe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.tabControlThongKe.ItemSize = new System.Drawing.Size(150, 40);
            this.tabControlThongKe.Location = new System.Drawing.Point(20, 90);
            this.tabControlThongKe.Name = "tabControlThongKe";
            this.tabControlThongKe.SelectedIndex = 0;
            this.tabControlThongKe.Size = new System.Drawing.Size(1025, 700);
            this.tabControlThongKe.TabIndex = 10;
            // 
            // tabTongQuan
            // 
            this.tabTongQuan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.tabTongQuan.Controls.Add(this.panelCard1);
            this.tabTongQuan.Controls.Add(this.panelCard2);
            this.tabTongQuan.Controls.Add(this.panelCard3);
            this.tabTongQuan.Controls.Add(this.labelChart1);
            this.tabTongQuan.Controls.Add(this.labelChart2);
            this.tabTongQuan.Controls.Add(this.chartDoanhThu);
            this.tabTongQuan.Controls.Add(this.chartTopSP);
            this.tabTongQuan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabTongQuan.Location = new System.Drawing.Point(4, 44);
            this.tabTongQuan.Name = "tabTongQuan";
            this.tabTongQuan.Padding = new System.Windows.Forms.Padding(3);
            this.tabTongQuan.Size = new System.Drawing.Size(1017, 652);
            this.tabTongQuan.TabIndex = 0;
            this.tabTongQuan.Text = "📊 TỔNG QUAN";
            // 
            // panelCard1
            // 
            this.panelCard1.BackColor = System.Drawing.Color.White;
            this.panelCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard1.Controls.Add(this.lblSoSanhDoanhThu);
            this.panelCard1.Controls.Add(this.lblTongDoanhThu);
            this.panelCard1.Controls.Add(this.label1);
            this.panelCard1.Location = new System.Drawing.Point(15, 15);
            this.panelCard1.Name = "panelCard1";
            this.panelCard1.Size = new System.Drawing.Size(315, 130);
            this.panelCard1.TabIndex = 0;
            // 
            // lblSoSanhDoanhThu
            // 
            this.lblSoSanhDoanhThu.AutoSize = true;
            this.lblSoSanhDoanhThu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSoSanhDoanhThu.ForeColor = System.Drawing.Color.Gray;
            this.lblSoSanhDoanhThu.Location = new System.Drawing.Point(15, 95);
            this.lblSoSanhDoanhThu.Name = "lblSoSanhDoanhThu";
            this.lblSoSanhDoanhThu.Size = new System.Drawing.Size(167, 21);
            this.lblSoSanhDoanhThu.TabIndex = 2;
            this.lblSoSanhDoanhThu.Text = "▲ 0% so với kỳ trước";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblTongDoanhThu.Location = new System.Drawing.Point(10, 45);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(71, 46);
            this.lblTongDoanhThu.TabIndex = 1;
            this.lblTongDoanhThu.Text = "0 ₫";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "TỔNG DOANH THU";
            // 
            // panelCard2
            // 
            this.panelCard2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelCard2.BackColor = System.Drawing.Color.White;
            this.panelCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard2.Controls.Add(this.lblSoSanhChiPhi);
            this.panelCard2.Controls.Add(this.lblTongDon);
            this.panelCard2.Controls.Add(this.label3);
            this.panelCard2.Location = new System.Drawing.Point(350, 15);
            this.panelCard2.Name = "panelCard2";
            this.panelCard2.Size = new System.Drawing.Size(315, 130);
            this.panelCard2.TabIndex = 1;
            // 
            // lblSoSanhChiPhi
            // 
            this.lblSoSanhChiPhi.AutoSize = true;
            this.lblSoSanhChiPhi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSoSanhChiPhi.ForeColor = System.Drawing.Color.Gray;
            this.lblSoSanhChiPhi.Location = new System.Drawing.Point(15, 95);
            this.lblSoSanhChiPhi.Name = "lblSoSanhChiPhi";
            this.lblSoSanhChiPhi.Size = new System.Drawing.Size(167, 21);
            this.lblSoSanhChiPhi.TabIndex = 3;
            this.lblSoSanhChiPhi.Text = "▼ 0% so với kỳ trước";
            // 
            // lblTongDon
            // 
            this.lblTongDon.AutoSize = true;
            this.lblTongDon.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTongDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(126)))), ((int)(((byte)(20)))));
            this.lblTongDon.Location = new System.Drawing.Point(10, 45);
            this.lblTongDon.Name = "lblTongDon";
            this.lblTongDon.Size = new System.Drawing.Size(71, 46);
            this.lblTongDon.TabIndex = 1;
            this.lblTongDon.Text = "0 ₫";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(15, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "CHI PHÍ NHẬP HÀNG";
            // 
            // panelCard3
            // 
            this.panelCard3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCard3.BackColor = System.Drawing.Color.White;
            this.panelCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard3.Controls.Add(this.lblSoSanhLoiNhuan);
            this.panelCard3.Controls.Add(this.lblTongKhachHang);
            this.panelCard3.Controls.Add(this.label5);
            this.panelCard3.Location = new System.Drawing.Point(685, 15);
            this.panelCard3.Name = "panelCard3";
            this.panelCard3.Size = new System.Drawing.Size(315, 130);
            this.panelCard3.TabIndex = 2;
            // 
            // lblSoSanhLoiNhuan
            // 
            this.lblSoSanhLoiNhuan.AutoSize = true;
            this.lblSoSanhLoiNhuan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSoSanhLoiNhuan.ForeColor = System.Drawing.Color.Gray;
            this.lblSoSanhLoiNhuan.Location = new System.Drawing.Point(15, 95);
            this.lblSoSanhLoiNhuan.Name = "lblSoSanhLoiNhuan";
            this.lblSoSanhLoiNhuan.Size = new System.Drawing.Size(167, 21);
            this.lblSoSanhLoiNhuan.TabIndex = 4;
            this.lblSoSanhLoiNhuan.Text = "▲ 0% so với kỳ trước";
            // 
            // lblTongKhachHang
            // 
            this.lblTongKhachHang.AutoSize = true;
            this.lblTongKhachHang.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTongKhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblTongKhachHang.Location = new System.Drawing.Point(10, 45);
            this.lblTongKhachHang.Name = "lblTongKhachHang";
            this.lblTongKhachHang.Size = new System.Drawing.Size(71, 46);
            this.lblTongKhachHang.TabIndex = 1;
            this.lblTongKhachHang.Text = "0 ₫";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(15, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "LỢI NHUẬN TẠM TÍNH";
            // 
            // labelChart1
            // 
            this.labelChart1.AutoSize = true;
            this.labelChart1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelChart1.Location = new System.Drawing.Point(10, 165);
            this.labelChart1.Name = "labelChart1";
            this.labelChart1.Size = new System.Drawing.Size(269, 28);
            this.labelChart1.TabIndex = 5;
            this.labelChart1.Text = "📈 Tăng trưởng & Lợi nhuận";
            // 
            // labelChart2
            // 
            this.labelChart2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelChart2.AutoSize = true;
            this.labelChart2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelChart2.Location = new System.Drawing.Point(680, 165);
            this.labelChart2.Name = "labelChart2";
            this.labelChart2.Size = new System.Drawing.Size(221, 28);
            this.labelChart2.TabIndex = 6;
            this.labelChart2.Text = "🔥 Top 5 SP Bán Chạy";
            // 
            // chartDoanhThu
            // 
            this.chartDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(15, 205);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Size = new System.Drawing.Size(650, 420);
            this.chartDoanhThu.TabIndex = 3;
            // 
            // chartTopSP
            // 
            this.chartTopSP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartTopSP.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Name = "Legend1";
            this.chartTopSP.Legends.Add(legend2);
            this.chartTopSP.Location = new System.Drawing.Point(685, 205);
            this.chartTopSP.Name = "chartTopSP";
            this.chartTopSP.Size = new System.Drawing.Size(315, 420);
            this.chartTopSP.TabIndex = 4;
            // 
            // tabChiTiet
            // 
            this.tabChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.tabChiTiet.Controls.Add(this.lblHoaDon);
            this.tabChiTiet.Controls.Add(this.dgvChiTietHoaDon);
            this.tabChiTiet.Controls.Add(this.label6);
            this.tabChiTiet.Controls.Add(this.dgvTopKhachHang);
            this.tabChiTiet.Controls.Add(this.label7);
            this.tabChiTiet.Controls.Add(this.dgvTonKhoThap);
            this.tabChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabChiTiet.Location = new System.Drawing.Point(4, 44);
            this.tabChiTiet.Name = "tabChiTiet";
            this.tabChiTiet.Padding = new System.Windows.Forms.Padding(3);
            this.tabChiTiet.Size = new System.Drawing.Size(1017, 652);
            this.tabChiTiet.TabIndex = 1;
            this.tabChiTiet.Text = "📝 CHI TIẾT SỐ LIỆU";
            // 
            // lblHoaDon
            // 
            this.lblHoaDon.AutoSize = true;
            this.lblHoaDon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHoaDon.Location = new System.Drawing.Point(10, 15);
            this.lblHoaDon.Name = "lblHoaDon";
            this.lblHoaDon.Size = new System.Drawing.Size(297, 25);
            this.lblHoaDon.TabIndex = 7;
            this.lblHoaDon.Text = "🧾 BẢNG KÊ CHI TIẾT HÓA ĐƠN";
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.AllowUserToAddRows = false;
            this.dgvChiTietHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTietHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(15, 45);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.ReadOnly = true;
            this.dgvChiTietHoaDon.RowHeadersVisible = false;
            this.dgvChiTietHoaDon.RowHeadersWidth = 51;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(985, 330);
            this.dgvChiTietHoaDon.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(10, 390);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(209, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "👑 TOP KHÁCH HÀNG";
            // 
            // dgvTopKhachHang
            // 
            this.dgvTopKhachHang.AllowUserToAddRows = false;
            this.dgvTopKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvTopKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopKhachHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopKhachHang.Location = new System.Drawing.Point(15, 420);
            this.dgvTopKhachHang.Name = "dgvTopKhachHang";
            this.dgvTopKhachHang.ReadOnly = true;
            this.dgvTopKhachHang.RowHeadersVisible = false;
            this.dgvTopKhachHang.RowHeadersWidth = 51;
            this.dgvTopKhachHang.Size = new System.Drawing.Size(480, 215);
            this.dgvTopKhachHang.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.label7.Location = new System.Drawing.Point(515, 390);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "⚠️ CẢNH BÁO KHO THẤP";
            // 
            // dgvTonKhoThap
            // 
            this.dgvTonKhoThap.AllowUserToAddRows = false;
            this.dgvTonKhoThap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTonKhoThap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTonKhoThap.BackgroundColor = System.Drawing.Color.White;
            this.dgvTonKhoThap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTonKhoThap.Location = new System.Drawing.Point(520, 420);
            this.dgvTonKhoThap.Name = "dgvTonKhoThap";
            this.dgvTonKhoThap.ReadOnly = true;
            this.dgvTonKhoThap.RowHeadersVisible = false;
            this.dgvTonKhoThap.RowHeadersWidth = 51;
            this.dgvTonKhoThap.Size = new System.Drawing.Size(480, 215);
            this.dgvTonKhoThap.TabIndex = 1;
            // 
            // ThongKeBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.tabControlThongKe);
            this.Controls.Add(this.pnlTopBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "ThongKeBaoCao";
            this.Size = new System.Drawing.Size(1065, 811);
            this.Load += new System.EventHandler(this.ThongKeBaoCao_Load);
            this.VisibleChanged += new System.EventHandler(this.ThongKeBaoCao_VisibleChanged);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.tabControlThongKe.ResumeLayout(false);
            this.tabTongQuan.ResumeLayout(false);
            this.tabTongQuan.PerformLayout();
            this.panelCard1.ResumeLayout(false);
            this.panelCard1.PerformLayout();
            this.panelCard2.ResumeLayout(false);
            this.panelCard2.PerformLayout();
            this.panelCard3.ResumeLayout(false);
            this.panelCard3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopSP)).EndInit();
            this.tabChiTiet.ResumeLayout(false);
            this.tabChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKhoThap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlThongKe;
        private System.Windows.Forms.TabPage tabTongQuan;
        private System.Windows.Forms.TabPage tabChiTiet;

        private System.Windows.Forms.Panel panelCard1;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelCard2;
        private System.Windows.Forms.Label lblTongDon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelCard3;
        private System.Windows.Forms.Label lblTongKhachHang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopSP;
        private System.Windows.Forms.Label labelChart1;
        private System.Windows.Forms.Label labelChart2;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSoSanhDoanhThu;
        private System.Windows.Forms.Label lblSoSanhChiPhi;
        private System.Windows.Forms.Label lblSoSanhLoiNhuan;

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblHoaDon;
        private System.Windows.Forms.DataGridView dgvTonKhoThap;
        private System.Windows.Forms.DataGridView dgvTopKhachHang;
        private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
        private System.Windows.Forms.Button btnXuatExcel;
    }
}
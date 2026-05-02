namespace SportShop.View
{
    partial class QuanLyLoaiSanPham
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
            this.dgvLoaiSP = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.txtTenLoai = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();

            this.dgvMauSac = new System.Windows.Forms.DataGridView();
            this.dgvKichThuoc = new System.Windows.Forms.DataGridView();
            this.btnThemMauSac = new System.Windows.Forms.Button();
            this.btnThemSize = new System.Windows.Forms.Button();
            this.btnSuaMauSac = new System.Windows.Forms.Button();
            this.btnSuaSize = new System.Windows.Forms.Button();
            this.btnXoaMauSac = new System.Windows.Forms.Button();
            this.btnXoaSize = new System.Windows.Forms.Button();

            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTenMau = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();

            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTenSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();

            // Tiêu đề khu vực
            this.lblTitleDanhMuc = new System.Windows.Forms.Label();
            this.lblTitleMauSac = new System.Windows.Forms.Label();
            this.lblTitleSize = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiSP)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMauSac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKichThuoc)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();

            // ==========================================
            // KHU VỰC 1: QUẢN LÝ DANH MỤC (TRÊN CÙNG)
            // ==========================================
            this.lblTitleDanhMuc.AutoSize = true;
            this.lblTitleDanhMuc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitleDanhMuc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.lblTitleDanhMuc.Location = new System.Drawing.Point(20, 15);
            this.lblTitleDanhMuc.Name = "lblTitleDanhMuc";
            this.lblTitleDanhMuc.Size = new System.Drawing.Size(209, 28);
            this.lblTitleDanhMuc.Text = "QUẢN LÝ DANH MỤC";

            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.txtTenLoai);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Location = new System.Drawing.Point(20, 50);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1020, 65);

            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 21);
            this.label1.Text = "Tên loại:";

            this.txtTenLoai.Location = new System.Drawing.Point(100, 17);
            this.txtTenLoai.Name = "txtTenLoai";
            this.txtTenLoai.Size = new System.Drawing.Size(300, 29);

            this.btnThem.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(20, 130);
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.Text = "THÊM";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(135, 130);
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.Text = "SỬA";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(250, 130);
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.Text = "XÓA";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(365, 130);
            this.btnLamMoi.Size = new System.Drawing.Size(100, 35);
            this.btnLamMoi.Text = "LÀM MỚI";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(650, 137);
            this.label6.Text = "Tìm kiếm:";

            this.txtTimKiem.Location = new System.Drawing.Point(740, 134);
            this.txtTimKiem.Size = new System.Drawing.Size(300, 29);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            this.dgvLoaiSP.AllowUserToAddRows = false;
            this.dgvLoaiSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoaiSP.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoaiSP.Location = new System.Drawing.Point(20, 185);
            this.dgvLoaiSP.ReadOnly = true;
            this.dgvLoaiSP.RowHeadersVisible = false;
            this.dgvLoaiSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoaiSP.Size = new System.Drawing.Size(1020, 200);
            this.dgvLoaiSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiSP_CellClick);


            // ==========================================
            // KHU VỰC 2: QUẢN LÝ MÀU SẮC (DƯỚI TRÁI)
            // ==========================================
            this.lblTitleMauSac.AutoSize = true;
            this.lblTitleMauSac.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitleMauSac.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.lblTitleMauSac.Location = new System.Drawing.Point(20, 405);
            this.lblTitleMauSac.Text = "🎨 QUẢN LÝ MÀU SẮC";

            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTenMau);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(20, 440);
            this.panel1.Size = new System.Drawing.Size(490, 65);

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 20);
            this.label2.Text = "Tên Màu:";

            this.txtTenMau.Location = new System.Drawing.Point(100, 17);
            this.txtTenMau.Size = new System.Drawing.Size(250, 29);

            this.btnThemMauSac.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnThemMauSac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMauSac.FlatAppearance.BorderSize = 0;
            this.btnThemMauSac.ForeColor = System.Drawing.Color.White;
            this.btnThemMauSac.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemMauSac.Location = new System.Drawing.Point(20, 520);
            this.btnThemMauSac.Size = new System.Drawing.Size(90, 35);
            this.btnThemMauSac.Text = "THÊM";
            this.btnThemMauSac.Click += new System.EventHandler(this.btnThemMauSac_Click);

            this.btnSuaMauSac.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnSuaMauSac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaMauSac.FlatAppearance.BorderSize = 0;
            this.btnSuaMauSac.ForeColor = System.Drawing.Color.White;
            this.btnSuaMauSac.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSuaMauSac.Location = new System.Drawing.Point(120, 520);
            this.btnSuaMauSac.Size = new System.Drawing.Size(90, 35);
            this.btnSuaMauSac.Text = "SỬA";
            this.btnSuaMauSac.Click += new System.EventHandler(this.btnSuaMauSac_Click);

            this.btnXoaMauSac.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnXoaMauSac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaMauSac.FlatAppearance.BorderSize = 0;
            this.btnXoaMauSac.ForeColor = System.Drawing.Color.White;
            this.btnXoaMauSac.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaMauSac.Location = new System.Drawing.Point(220, 520);
            this.btnXoaMauSac.Size = new System.Drawing.Size(90, 35);
            this.btnXoaMauSac.Text = "XÓA";
            this.btnXoaMauSac.Click += new System.EventHandler(this.btnXoaMauSac_Click);

            this.dgvMauSac.AllowUserToAddRows = false;
            this.dgvMauSac.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMauSac.BackgroundColor = System.Drawing.Color.White;
            this.dgvMauSac.Location = new System.Drawing.Point(20, 570);
            this.dgvMauSac.ReadOnly = true;
            this.dgvMauSac.RowHeadersVisible = false;
            this.dgvMauSac.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMauSac.Size = new System.Drawing.Size(490, 220);
            this.dgvMauSac.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMauSac_CellClick);


            // ==========================================
            // KHU VỰC 3: QUẢN LÝ SIZE (DƯỚI PHẢI)
            // ==========================================
            this.lblTitleSize.AutoSize = true;
            this.lblTitleSize.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitleSize.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.lblTitleSize.Location = new System.Drawing.Point(550, 405);
            this.lblTitleSize.Text = "📏 QUẢN LÝ KÍCH CỠ";

            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtTenSize);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(550, 440);
            this.panel2.Size = new System.Drawing.Size(490, 65);

            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 20);
            this.label3.Text = "Kích cỡ:";

            this.txtTenSize.Location = new System.Drawing.Point(100, 17);
            this.txtTenSize.Size = new System.Drawing.Size(250, 29);

            this.btnThemSize.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnThemSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSize.FlatAppearance.BorderSize = 0;
            this.btnThemSize.ForeColor = System.Drawing.Color.White;
            this.btnThemSize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemSize.Location = new System.Drawing.Point(550, 520);
            this.btnThemSize.Size = new System.Drawing.Size(90, 35);
            this.btnThemSize.Text = "THÊM";
            this.btnThemSize.Click += new System.EventHandler(this.btnThemSize_Click);

            this.btnSuaSize.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnSuaSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaSize.FlatAppearance.BorderSize = 0;
            this.btnSuaSize.ForeColor = System.Drawing.Color.White;
            this.btnSuaSize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSuaSize.Location = new System.Drawing.Point(650, 520);
            this.btnSuaSize.Size = new System.Drawing.Size(90, 35);
            this.btnSuaSize.Text = "SỬA";
            this.btnSuaSize.Click += new System.EventHandler(this.btnSuaSize_Click);

            this.btnXoaSize.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnXoaSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSize.FlatAppearance.BorderSize = 0;
            this.btnXoaSize.ForeColor = System.Drawing.Color.White;
            this.btnXoaSize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaSize.Location = new System.Drawing.Point(750, 520);
            this.btnXoaSize.Size = new System.Drawing.Size(90, 35);
            this.btnXoaSize.Text = "XÓA";
            this.btnXoaSize.Click += new System.EventHandler(this.btnXoaSize_Click);

            this.dgvKichThuoc.AllowUserToAddRows = false;
            this.dgvKichThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKichThuoc.BackgroundColor = System.Drawing.Color.White;
            this.dgvKichThuoc.Location = new System.Drawing.Point(550, 570);
            this.dgvKichThuoc.ReadOnly = true;
            this.dgvKichThuoc.RowHeadersVisible = false;
            this.dgvKichThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKichThuoc.Size = new System.Drawing.Size(490, 220);
            this.dgvKichThuoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKichThuoc_CellClick);


            // ==========================================
            // FORM MAIN PROPERTIES
            // ==========================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.Controls.Add(this.lblTitleDanhMuc);
            this.Controls.Add(this.lblTitleMauSac);
            this.Controls.Add(this.lblTitleSize);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnXoaSize);
            this.Controls.Add(this.btnXoaMauSac);
            this.Controls.Add(this.btnSuaSize);
            this.Controls.Add(this.btnSuaMauSac);
            this.Controls.Add(this.btnThemSize);
            this.Controls.Add(this.btnThemMauSac);
            this.Controls.Add(this.dgvKichThuoc);
            this.Controls.Add(this.dgvMauSac);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.dgvLoaiSP);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "QuanLyLoaiSanPham";
            this.Size = new System.Drawing.Size(1065, 811);
            this.Load += new System.EventHandler(this.QuanLyLoaiSanPham_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiSP)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMauSac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKichThuoc)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoaiSP;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtTenLoai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimKiem;

        private System.Windows.Forms.DataGridView dgvMauSac;
        private System.Windows.Forms.DataGridView dgvKichThuoc;

        private System.Windows.Forms.Button btnThemMauSac;
        private System.Windows.Forms.Button btnSuaMauSac;
        private System.Windows.Forms.Button btnXoaMauSac;

        private System.Windows.Forms.Button btnThemSize;
        private System.Windows.Forms.Button btnSuaSize;
        private System.Windows.Forms.Button btnXoaSize;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTenMau;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTenSize;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label lblTitleDanhMuc;
        private System.Windows.Forms.Label lblTitleMauSac;
        private System.Windows.Forms.Label lblTitleSize;
    }
}
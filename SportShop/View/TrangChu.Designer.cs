namespace SportShop.View
{
    partial class TrangChu
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
            this.panelFilter = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cmbLoai = new System.Windows.Forms.ComboBox();
            this.cmbGia = new System.Windows.Forms.ComboBox();
            this.cmbSapXep = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.pnlCart = new System.Windows.Forms.Panel();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblCartTitle = new System.Windows.Forms.Label();
            this.pnlCartBottom = new System.Windows.Forms.Panel();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelFilter.SuspendLayout();
            this.pnlCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlCartBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.Controls.Add(this.txtTimKiem);
            this.panelFilter.Controls.Add(this.cmbLoai);
            this.panelFilter.Controls.Add(this.cmbGia);
            this.panelFilter.Controls.Add(this.cmbSapXep);
            this.panelFilter.Controls.Add(this.btnTimKiem);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 0);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1073, 70);
            this.panelFilter.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.Location = new System.Drawing.Point(166, 21);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(250, 30);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.Text = "🔍 Nhập tên sản phẩm...";
            // 
            // cmbLoai
            // 
            this.cmbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoai.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoai.FormattingEnabled = true;
            this.cmbLoai.Location = new System.Drawing.Point(422, 21);
            this.cmbLoai.Name = "cmbLoai";
            this.cmbLoai.Size = new System.Drawing.Size(150, 31);
            this.cmbLoai.TabIndex = 1;
            // 
            // cmbGia
            // 
            this.cmbGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGia.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGia.FormattingEnabled = true;
            this.cmbGia.Location = new System.Drawing.Point(578, 21);
            this.cmbGia.Name = "cmbGia";
            this.cmbGia.Size = new System.Drawing.Size(150, 31);
            this.cmbGia.TabIndex = 2;
            // 
            // cmbSapXep
            // 
            this.cmbSapXep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSapXep.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSapXep.FormattingEnabled = true;
            this.cmbSapXep.Location = new System.Drawing.Point(734, 21);
            this.cmbSapXep.Name = "cmbSapXep";
            this.cmbSapXep.Size = new System.Drawing.Size(150, 31);
            this.cmbSapXep.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(19, 20);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(120, 33);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "TÌM KIẾM";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // pnlCart
            // 
            this.pnlCart.BackColor = System.Drawing.Color.White;
            this.pnlCart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCart.Controls.Add(this.dgvCart);
            this.pnlCart.Controls.Add(this.lblCartTitle);
            this.pnlCart.Controls.Add(this.pnlCartBottom);
            this.pnlCart.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCart.Location = new System.Drawing.Point(723, 70);
            this.pnlCart.Name = "pnlCart";
            this.pnlCart.Size = new System.Drawing.Size(350, 522);
            this.pnlCart.TabIndex = 1;
            // 
            // dgvCart
            // 
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.ColumnHeadersHeight = 29;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.Location = new System.Drawing.Point(0, 40);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.Size = new System.Drawing.Size(348, 370);
            this.dgvCart.TabIndex = 0;
            // 
            // lblCartTitle
            // 
            this.lblCartTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.lblCartTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCartTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.lblCartTitle.Location = new System.Drawing.Point(0, 0);
            this.lblCartTitle.Name = "lblCartTitle";
            this.lblCartTitle.Size = new System.Drawing.Size(348, 40);
            this.lblCartTitle.TabIndex = 1;
            this.lblCartTitle.Text = "🛒 GIỎ HÀNG CỦA BẠN";
            this.lblCartTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCartBottom
            // 
            this.pnlCartBottom.BackColor = System.Drawing.Color.White;
            this.pnlCartBottom.Controls.Add(this.btnThanhToan);
            this.pnlCartBottom.Controls.Add(this.lblTotal);
            this.pnlCartBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCartBottom.Location = new System.Drawing.Point(0, 410);
            this.pnlCartBottom.Name = "pnlCartBottom";
            this.pnlCartBottom.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCartBottom.Size = new System.Drawing.Size(348, 110);
            this.pnlCartBottom.TabIndex = 2;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThanhToan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(10, 55);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(328, 45);
            this.btnThanhToan.TabIndex = 0;
            this.btnThanhToan.Text = "TẠO HÓA ĐƠN NGAY";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.lblTotal.Location = new System.Drawing.Point(10, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(328, 35);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Tổng tiền: 0 ₫";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 70);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(723, 522);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlCart);
            this.Controls.Add(this.panelFilter);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TrangChu";
            this.Size = new System.Drawing.Size(1073, 592);
            this.Load += new System.EventHandler(this.TrangChu_Load);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.pnlCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlCartBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cmbLoai;
        private System.Windows.Forms.ComboBox cmbGia;
        private System.Windows.Forms.ComboBox cmbSapXep;
        private System.Windows.Forms.Button btnTimKiem;

        // Khai báo biến cho Giỏ Hàng
        private System.Windows.Forms.Panel pnlCart;
        private System.Windows.Forms.Label lblCartTitle;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel pnlCartBottom;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnThanhToan;
    }
}
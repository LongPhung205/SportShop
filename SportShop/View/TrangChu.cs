using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SportShop.Controller;
using SportShop.Model;

namespace SportShop.View
{
    public partial class TrangChu : UserControl
    {
        private QuanLySanPhamController _controller;
        private bool isLoaded = false;

        public TrangChu()
        {
            InitializeComponent();
            _controller = new QuanLySanPhamController();

            // Đăng ký sự kiện: Cứ đổi lựa chọn ở Dropdown là tự động lọc luôn (Không cần bấm nút)
            cmbLoai.SelectedIndexChanged += Filter_Changed;
            cmbGia.SelectedIndexChanged += Filter_Changed;
            cmbSapXep.SelectedIndexChanged += Filter_Changed;

            // Đăng ký sự kiện cho Ô tìm kiếm
            txtTimKiem.Enter += txtTimKiem_Enter;
            txtTimKiem.Leave += txtTimKiem_Leave;
            txtTimKiem.TextChanged += Filter_Changed; // Gõ đến đâu lọc đến đó

            // Khởi tạo lưới giỏ hàng
            if (dgvCart != null)
            {
                dgvCart.CellContentClick += DgvCart_CellContentClick;
                // Đã xóa sự kiện CellValueChanged vì không còn cho phép sửa số lượng ở đây
            }
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            SetupCartGrid();
            isLoaded = true;

            ThucHienLoc();
            RefreshCartUI(true); // Ép Load lại toàn bộ giỏ hàng lúc mở Form
        }

        // ================== CẤU HÌNH LƯỚI GIỎ HÀNG (CHỈ HIỆN TÊN VÀ GIÁ) ==================
        private void SetupCartGrid()
        {
            if (dgvCart == null) return;

            dgvCart.AutoGenerateColumns = false;
            dgvCart.AllowUserToAddRows = false;
            dgvCart.RowHeadersVisible = false;
            dgvCart.BackgroundColor = System.Drawing.Color.White;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvCart.Columns.Count == 0)
            {
                // 👉 1. TÊN SẢN PHẨM
                dgvCart.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ProductName",
                    DataPropertyName = "ProductName",
                    HeaderText = "Sản phẩm",
                    ReadOnly = true,
                    FillWeight = 60
                });

                // 👉 2. ĐƠN GIÁ
                dgvCart.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Price",
                    DataPropertyName = "Price",
                    HeaderText = "Đơn giá",
                    ReadOnly = true,
                    DefaultCellStyle = { Format = "N0" },
                    FillWeight = 30
                });

                // 👉 3. NÚT XÓA KHỎI GIỎ HÀNG (❌)
                DataGridViewButtonColumn btnDel = new DataGridViewButtonColumn
                {
                    Name = "ActionDelete",
                    HeaderText = "",
                    Text = "❌",
                    UseColumnTextForButtonValue = true,
                    FillWeight = 10,
                    FlatStyle = FlatStyle.Flat
                };
                dgvCart.Columns.Add(btnDel);
            }
        }

        // ================== CẤU HÌNH CÁC THANH COMBOBOX ==================
        private void LoadComboBoxData()
        {
            try
            {
                DataTable dtCat = _controller.GetAllCategories();
                DataRow dr = dtCat.NewRow();
                dr["Id"] = 0;
                dr["CategoryName"] = "--- Tất cả thể loại ---";
                dtCat.Rows.InsertAt(dr, 0);

                cmbLoai.DataSource = dtCat;
                cmbLoai.DisplayMember = "CategoryName";
                cmbLoai.ValueMember = "Id";

                cmbGia.Items.Clear();
                cmbGia.Items.Add("--- Mức giá ---");
                cmbGia.Items.Add("Dưới 500.000 ₫");
                cmbGia.Items.Add("500.000 ₫ - 1.000.000 ₫");
                cmbGia.Items.Add("Trên 1.000.000 ₫");
                cmbGia.SelectedIndex = 0;

                cmbSapXep.Items.Clear();
                cmbSapXep.Items.Add("--- Sắp xếp ---");
                cmbSapXep.Items.Add("Giá tăng dần");
                cmbSapXep.Items.Add("Giá giảm dần");
                cmbSapXep.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bộ lọc: " + ex.Message);
            }
        }

        // ================== LỌC DỮ LIỆU CHUYÊN NGHIỆP ==================
        private void ThucHienLoc()
        {
            if (!isLoaded) return;

            try
            {
                string tuKhoa = txtTimKiem.Text.Trim();
                if (tuKhoa == "🔍 Nhập tên sản phẩm...") tuKhoa = "";

                List<Product> ketQua = string.IsNullOrEmpty(tuKhoa)
                    ? _controller.GetAllProducts()
                    : _controller.SearchProducts(tuKhoa);

                if (cmbLoai.SelectedIndex >= 0 && cmbLoai.SelectedValue != null)
                {
                    if (int.TryParse(cmbLoai.SelectedValue.ToString(), out int catId) && catId > 0)
                    {
                        ketQua = ketQua.Where(p => p.CategoryId == catId).ToList();
                    }
                }

                int giaIndex = cmbGia.SelectedIndex;
                if (giaIndex == 1) ketQua = ketQua.Where(p => p.BasePrice < 500000).ToList();
                else if (giaIndex == 2) ketQua = ketQua.Where(p => p.BasePrice >= 500000 && p.BasePrice <= 1000000).ToList();
                else if (giaIndex == 3) ketQua = ketQua.Where(p => p.BasePrice > 1000000).ToList();

                int sortIndex = cmbSapXep.SelectedIndex;
                if (sortIndex == 1) ketQua = ketQua.OrderBy(p => p.BasePrice).ToList();
                else if (sortIndex == 2) ketQua = ketQua.OrderByDescending(p => p.BasePrice).ToList();

                HienThiDanhSachSanPham(ketQua);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình lọc dữ liệu: " + ex.Message);
            }
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            ThucHienLoc();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ThucHienLoc();
        }

        // ================== VẼ GIAO DIỆN SẢN PHẨM ==================
        private void HienThiDanhSachSanPham(List<Product> danhSach)
        {
            flowLayoutPanel1.Controls.Clear();

            if (danhSach == null || danhSach.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "Không tìm thấy sản phẩm nào phù hợp!",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = System.Drawing.Color.Gray,
                    Margin = new Padding(20)
                };
                flowLayoutPanel1.Controls.Add(lblEmpty);
                return;
            }

            flowLayoutPanel1.SuspendLayout();
            foreach (var p in danhSach)
            {
                if (p.IsActive == true)
                {
                    flowLayoutPanel1.Controls.Add(CreateProductCard(p));
                }
            }
            flowLayoutPanel1.ResumeLayout();
        }

        private Panel CreateProductCard(Product p)
        {
            Panel card = new Panel
            {
                Width = 190,
                Height = 290,
                Margin = new Padding(10, 10, 15, 15),
                BackColor = System.Drawing.Color.White,
                Cursor = Cursors.Hand,
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox pic = new PictureBox { Width = 170, Height = 140, Top = 10, Left = 10, SizeMode = PictureBoxSizeMode.Zoom };
            if (!string.IsNullOrEmpty(p.ImagePath) && File.Exists(p.ImagePath))
            {
                try
                {
                    using (var fs = new FileStream(p.ImagePath, FileMode.Open, FileAccess.Read))
                    {
                        pic.Image = Image.FromStream(fs);
                    }
                }
                catch { pic.Image = null; }
            }

            Label name = new Label { Text = p.Name, Top = 155, Left = 10, Width = 170, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(40, 40, 40), AutoEllipsis = true };
            Label cate = new Label { Text = p.CategoryName, Top = 178, Left = 10, Width = 170, Font = new Font("Segoe UI", 8.5f, FontStyle.Regular), ForeColor = System.Drawing.Color.Gray };
            Label price = new Label { Text = p.BasePrice.ToString("N0") + " ₫", Top = 200, Left = 10, Width = 170, Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(238, 77, 45) };

            Button btn = new Button
            {
                Text = "THÊM VÀO GIỎ",
                Top = 235,
                Left = 10,
                Width = 170,
                Height = 35,
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(238, 77, 45),
                ForeColor = System.Drawing.Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;

            btn.Click += (s, e) =>
            {
                CartManager.AddToCart(p);
                RefreshCartUI(true); // Thêm món mới thì ép Rebind lại bảng
            };

            EventHandler hoverEnter = (s, e) => { card.BackColor = System.Drawing.Color.FromArgb(248, 249, 250); };
            EventHandler hoverLeave = (s, e) => { card.BackColor = System.Drawing.Color.White; };
            card.MouseEnter += hoverEnter; card.MouseLeave += hoverLeave;
            pic.MouseEnter += hoverEnter; pic.MouseLeave += hoverLeave;
            name.MouseEnter += hoverEnter; name.MouseLeave += hoverLeave;
            cate.MouseEnter += hoverEnter; cate.MouseLeave += hoverLeave;
            price.MouseEnter += hoverEnter; price.MouseLeave += hoverLeave;

            card.Controls.Add(pic); card.Controls.Add(name); card.Controls.Add(cate); card.Controls.Add(price); card.Controls.Add(btn);
            return card;
        }

        // ================== XỬ LÝ LƯỚI GIỎ HÀNG ==================

        // Cập nhật giao diện giỏ
        private void RefreshCartUI(bool ignore = false)
        {
            if (dgvCart == null || lblTotal == null) return;

            // Rebind lại an toàn
            dgvCart.DataSource = null;
            dgvCart.DataSource = CartManager.CurrentCart;

            decimal total = CartManager.CurrentCart.Sum(x => x.TotalPrice);
            lblTotal.Text = "Tổng tiền: " + total.ToString("N0") + " ₫";
        }

        private void DgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bắt buộc e.ColumnIndex >= 0 để lỡ click vào viền bảng không bị lỗi
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var columnName = dgvCart.Columns[e.ColumnIndex].Name;

                if (columnName == "ActionDelete") // Bấm nút ❌
                {
                    var item = (CartItem)dgvCart.Rows[e.RowIndex].DataBoundItem;

                    // 👉 Trì hoãn việc xóa cho đến khi WinForms xử lý xong cú Click chuột
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        // Vì dùng BindingList nên chỉ cần gọi Remove, lưới sẽ TỰ ĐỘNG mượt mà biến mất dòng đó
                        CartManager.CurrentCart.Remove(item);

                        // Cập nhật lại tổng tiền (không cần gán lại DataSource = null lằng nhằng nữa)
                        decimal total = CartManager.CurrentCart.Sum(x => x.TotalPrice);
                        lblTotal.Text = "Tổng tiền: " + total.ToString("N0") + " ₫";
                    });
                }
            }
        }

        // ================== NÚT TẠO HÓA ĐƠN ==================
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (CartManager.CurrentCart == null || CartManager.CurrentCart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng của bạn đang trống! Hãy thêm sản phẩm trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MainMenu mainForm = this.FindForm() as MainMenu;
            if (mainForm != null)
            {
                mainForm.ChuyenSangTrangHoaDonTuGioHang();
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "🔍 Nhập tên sản phẩm...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "🔍 Nhập tên sản phẩm...";
                txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }
}
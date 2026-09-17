using System;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    public partial class chitietsanpham : Form
    {
        private SanPhamTam sanPham;
        private int soLuong = 1;

        public chitietsanpham()
        {
            InitializeComponent();

            // Gắn sự kiện nút
            button1.Click += button1_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
            button5.Click += button5_Click;

            this.Load += chitietsanpham_Load;
        }

        // =========================================================
        // CONSTRUCTOR NHẬN SẢN PHẨM
        // =========================================================

        public chitietsanpham(SanPhamTam sanPham)
            : this()
        {
            this.sanPham = sanPham;
        }

        // =========================================================
        // LOAD FORM
        // =========================================================

        private void chitietsanpham_Load(object sender, EventArgs e)
        {
            if (sanPham == null)
                return;

            soLuong = 1;

            HienThiSanPham();
        }

        // =========================================================
        // HIỂN THỊ SẢN PHẨM
        // =========================================================

        private void HienThiSanPham()
        {
            this.Text = "Chi tiết - " + sanPham.TenSP;

            label2.Text =
                "Tên Sản Phẩm: " + sanPham.TenSP;

            label3.Text =
                "Giá: " + sanPham.Gia.ToString("N0") + " Đ";

            label4.Text =
                "Thương Hiệu: " +
                (string.IsNullOrWhiteSpace(sanPham.ThuongHieu)
                    ? "Đang cập nhật"
                    : sanPham.ThuongHieu);

            label5.Text =
                "Màu Sắc: " +
                (string.IsNullOrWhiteSpace(sanPham.MauSac)
                    ? "Đang cập nhật"
                    : sanPham.MauSac);

            label8.Text =
                "Mô Tả: " +
                (string.IsNullOrWhiteSpace(sanPham.MoTa)
                    ? "Sản phẩm thể thao chính hãng."
                    : sanPham.MoTa);

            button2.Text = soLuong.ToString();

            // ==============================
            // HIỂN THỊ ẢNH
            // ==============================

            if (sanPham.Anh != null)
            {
                pictureBox1.Image = sanPham.Anh;
                pictureBox1.SizeMode =
                    PictureBoxSizeMode.Zoom;
            }

            // ==============================
            // LOAD SIZE
            // ==============================

            LoadSize();
        }

        // =========================================================
        // LOAD SIZE
        // =========================================================

        private void LoadSize()
        {
            comboBox1.Items.Clear();

            // Nếu là giày → size giày
            if (sanPham != null &&
                sanPham.LoaiSP == "Giày")
            {
                comboBox1.Items.Add("38");
                comboBox1.Items.Add("38.5");
                comboBox1.Items.Add("39");
                comboBox1.Items.Add("39.5");
                comboBox1.Items.Add("40");
                comboBox1.Items.Add("40.5");
                comboBox1.Items.Add("41");
                comboBox1.Items.Add("41.5");
                comboBox1.Items.Add("42");
                comboBox1.Items.Add("42.5");
                comboBox1.Items.Add("43");
                comboBox1.Items.Add("44");
                comboBox1.Items.Add("45");
            }
            else
            {
                // Size quần áo / sản phẩm khác
                comboBox1.Items.Add("S");
                comboBox1.Items.Add("M");
                comboBox1.Items.Add("L");
                comboBox1.Items.Add("XL");
                comboBox1.Items.Add("XXL");
            }

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        // =========================================================
        // GIẢM SỐ LƯỢNG
        // =========================================================

        private void button1_Click(object sender, EventArgs e)
        {
            if (soLuong > 1)
            {
                soLuong--;
            }

            button2.Text = soLuong.ToString();
        }

        // =========================================================
        // TĂNG SỐ LƯỢNG
        // =========================================================

        private void button3_Click(object sender, EventArgs e)
        {
            if (soLuong < 99)
            {
                soLuong++;
            }

            button2.Text = soLuong.ToString();
        }

        // =========================================================
        // THÊM VÀO GIỎ HÀNG
        // =========================================================

        private bool ThemSanPhamVaoGio()
        {
            if (sanPham == null)
            {
                MessageBox.Show(
                    "Không xác định được sản phẩm.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            string size = comboBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(size))
            {
                MessageBox.Show(
                    "Vui lòng chọn size.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                comboBox1.Focus();
                return false;
            }

            if (soLuong <= 0)
                soLuong = 1;

            // GioHangManager hiện tại nhận 3 tham số:
            // Sản phẩm + Size + Số lượng
            GioHangManager.Them(
            sanPham,
            size,
            sanPham.MauSac,
            soLuong);

            return true;
        }

        // =========================================================
        // NÚT GIỎ HÀNG
        // =========================================================

        private void button4_Click(object sender, EventArgs e)
        {
            if (!ThemSanPhamVaoGio())
                return;

            MessageBox.Show(
                "Đã thêm sản phẩm vào giỏ hàng!\n\n"
                + "Bạn có thể tiếp tục chọn sản phẩm khác.",
                "SPORTSHOP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================
        // MUA NGAY
        // =========================================================

        private void button5_Click(object sender, EventArgs e)
        {
            if (!ThemSanPhamVaoGio())
                return;

            Giohang formGioHang = new Giohang();

            formGioHang.StartPosition =
                FormStartPosition.CenterParent;

            formGioHang.ShowDialog(this);
        }

        // =========================================================
        // PANEL PAINT
        // =========================================================

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        // Event cũ của Designer nếu đang tồn tại
        private void chitietsanpham_Load_1(object sender, EventArgs e)
        {
        }
    }
}
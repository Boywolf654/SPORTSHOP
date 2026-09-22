using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    public partial class chitietsanpham : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        private SanPhamTam sanPham;
        private int soLuong = 1;
        private int maBienTheDangChon = 0;
        private int tonKhoDangChon = 0;

        // Combo màu tạo bằng code, không sửa Designer.
        private ComboBox cboMauSac;
        private Label lblTonKho;
        private Label lblMaBienThe;

        public chitietsanpham()
        {
            InitializeComponent();

            button1.Click -= button1_Click;
            button1.Click += button1_Click;

            button3.Click -= button3_Click;
            button3.Click += button3_Click;

            button4.Click -= button4_Click;
            button4.Click += button4_Click;

            button5.Click -= button5_Click;
            button5.Click += button5_Click;

            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            this.Load -= chitietsanpham_Load;
            this.Load += chitietsanpham_Load;
        }

        public chitietsanpham(SanPhamTam sanPham)
            : this()
        {
            this.sanPham = sanPham;
        }

        private void chitietsanpham_Load(object sender, EventArgs e)
        {
            if (sanPham == null)
                return;

            soLuong = 1;

            DecorFormChiTiet();
            TaoControlMauVaTon();
            HienThiSanPham();
        }

        // =========================================================
        // DECOR FORM
        // =========================================================

        private void DecorFormChiTiet()
        {
            this.Text = "SPORTSHOP - Chi tiết sản phẩm";
            this.BackColor = Color.FromArgb(245, 245, 247);
            this.StartPosition = FormStartPosition.CenterParent;

            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;

            label1.ForeColor = Color.FromArgb(190, 20, 35);
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);

            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(220, 30, 45);

            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            label8.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            label8.MaximumSize = new Size(980, 0);

            comboBox1.Font = new Font("Segoe UI", 11F);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            button1.BackColor = Color.FromArgb(235, 235, 235);
            button2.BackColor = Color.White;
            button3.BackColor = Color.FromArgb(235, 235, 235);

            button4.BackColor = Color.FromArgb(35, 35, 35);
            button4.ForeColor = Color.White;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;

            button5.BackColor = Color.FromArgb(220, 30, 45);
            button5.ForeColor = Color.White;
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;

            pictureBox1.BackColor = Color.White;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void TaoControlMauVaTon()
        {
            if (cboMauSac != null)
                return;

            // Label màu đã có sẵn ở Designer.
            label5.Text = "Màu sắc:";

            cboMauSac = new ComboBox();
            cboMauSac.Name = "cboMauSac";
            cboMauSac.Font = new Font("Segoe UI", 11F);
            cboMauSac.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMauSac.Location = new Point(656, 334);
            cboMauSac.Size = new Size(180, 33);
            cboMauSac.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            cboMauSac.SelectedIndexChanged += cboMauSac_SelectedIndexChanged;

            panel1.Controls.Add(cboMauSac);
            cboMauSac.BringToFront();

            // Tồn kho đặt giữa Size và Số lượng.
            lblTonKho = new Label();
            lblTonKho.Name = "lblTonKho";
            lblTonKho.AutoSize = true;
            lblTonKho.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTonKho.ForeColor = Color.FromArgb(30, 150, 70);
            lblTonKho.Location = new Point(535, 465);
            lblTonKho.Text = "Tồn kho: Đang tải...";
            panel1.Controls.Add(lblTonKho);
            lblTonKho.BringToFront();

            // Mã biến thể để debug/kiểm tra, ẩn mặc định.
            lblMaBienThe = new Label();
            lblMaBienThe.Name = "lblMaBienThe";
            lblMaBienThe.AutoSize = true;
            lblMaBienThe.Font = new Font("Segoe UI", 8.5F);
            lblMaBienThe.ForeColor = Color.Gray;
            lblMaBienThe.Location = new Point(850, 465);
            lblMaBienThe.Visible = false;
            panel1.Controls.Add(lblMaBienThe);
        }

        // =========================================================
        // HIỂN THỊ SẢN PHẨM
        // =========================================================

        private void HienThiSanPham()
        {
            this.Text = "SPORTSHOP - " + sanPham.TenSP;

            label1.Text = "CHI TIẾT SẢN PHẨM";
            label2.Text = "Tên sản phẩm: " + sanPham.TenSP;

            label4.Text =
                "Thương hiệu: " +
                (string.IsNullOrWhiteSpace(sanPham.ThuongHieu)
                    ? "Đang cập nhật"
                    : sanPham.ThuongHieu);

            label8.Text =
                "Mô tả: " +
                (string.IsNullOrWhiteSpace(sanPham.MoTa)
                    ? "Sản phẩm thể thao chính hãng."
                    : sanPham.MoTa);

            button2.Text = soLuong.ToString();

            if (sanPham.Anh != null)
            {
                pictureBox1.Image = sanPham.Anh;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }

            LoadBienThe();
        }

        // =========================================================
        // LOAD BIẾN THỂ THẬT
        // =========================================================

        private DataTable LoadTatCaBienThe()
        {
            string sql = @"
                SELECT
                    bt.MaBienThe,
                    bt.MaSP,
                    s.TenSize,
                    m.TenMau,
                    bt.GiaBan,
                    bt.SoLuong
                FROM BienTheSanPham bt
                INNER JOIN Size s
                    ON s.MaSize = bt.MaSize
                INNER JOIN MauSac m
                    ON m.MaMau = bt.MaMau
                WHERE bt.MaSP = @MaSP
                  AND bt.TrangThai = 1
                ORDER BY bt.MaBienThe;";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaSP", sanPham.MaSP)
            };

            return kt.GetData(sql, parameters);
        }

        private void LoadBienThe()
        {
            try
            {
                DataTable dt = LoadTatCaBienThe();

                if (dt.Rows.Count == 0)
                {
                    comboBox1.Items.Clear();
                    cboMauSac.Items.Clear();

                    label3.Text = "Giá: Chưa có biến thể";
                    lblTonKho.Text = "Tồn kho: 0";
                    lblTonKho.ForeColor = Color.FromArgb(210, 30, 45);

                    button4.Enabled = false;
                    button5.Enabled = false;
                    return;
                }

                // Load Size đúng theo DB, không còn hard-code.
                comboBox1.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    string size = Convert.ToString(row["TenSize"]);

                    if (!string.IsNullOrWhiteSpace(size) &&
                        !comboBox1.Items.Contains(size))
                    {
                        comboBox1.Items.Add(size);
                    }
                }

                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;

                // Load màu theo Size đầu tiên.
                LoadMauTheoSize(dt, comboBox1.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải biến thể sản phẩm.\n\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadMauTheoSize(DataTable dt, string size)
        {
            if (cboMauSac == null)
                return;

            string mauDangChon = cboMauSac.Text.Trim();

            cboMauSac.SelectedIndexChanged -= cboMauSac_SelectedIndexChanged;
            cboMauSac.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                string rowSize = Convert.ToString(row["TenSize"]);
                string mau = Convert.ToString(row["TenMau"]);

                if (rowSize == size &&
                    !string.IsNullOrWhiteSpace(mau) &&
                    !cboMauSac.Items.Contains(mau))
                {
                    cboMauSac.Items.Add(mau);
                }
            }

            if (cboMauSac.Items.Count == 0)
            {
                cboMauSac.SelectedIndexChanged += cboMauSac_SelectedIndexChanged;
                CapNhatBienTheDangChon(dt);
                return;
            }

            int index = cboMauSac.Items.IndexOf(mauDangChon);
            cboMauSac.SelectedIndex = index >= 0 ? index : 0;

            cboMauSac.SelectedIndexChanged += cboMauSac_SelectedIndexChanged;

            CapNhatBienTheDangChon(dt);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sanPham == null || cboMauSac == null)
                return;

            try
            {
                DataTable dt = LoadTatCaBienThe();
                LoadMauTheoSize(dt, comboBox1.Text.Trim());
            }
            catch
            {
                // Không spam MessageBox khi ComboBox thay đổi.
            }
        }

        private void cboMauSac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sanPham == null)
                return;

            try
            {
                DataTable dt = LoadTatCaBienThe();
                CapNhatBienTheDangChon(dt);
            }
            catch
            {
            }
        }

        // =========================================================
        // CẬP NHẬT GIÁ + TỒN + MaBienThe THEO SIZE/MÀU
        // =========================================================

        private void CapNhatBienTheDangChon(DataTable dt)
        {
            string size = comboBox1.Text.Trim();
            string mau = cboMauSac == null
                ? ""
                : cboMauSac.Text.Trim();

            DataRow selected = null;

            foreach (DataRow row in dt.Rows)
            {
                string rowSize = Convert.ToString(row["TenSize"]);
                string rowMau = Convert.ToString(row["TenMau"]);

                if (rowSize == size && rowMau == mau)
                {
                    selected = row;
                    break;
                }
            }

            if (selected == null)
            {
                maBienTheDangChon = 0;
                tonKhoDangChon = 0;

                label3.Text = "Giá: Không có";
                lblTonKho.Text = "Tồn kho: 0";
                lblTonKho.ForeColor = Color.FromArgb(210, 30, 45);

                button4.Enabled = false;
                button5.Enabled = false;
                return;
            }

            maBienTheDangChon =
                Convert.ToInt32(selected["MaBienThe"]);

            decimal giaBan = 0;
            decimal.TryParse(
                Convert.ToString(selected["GiaBan"]),
                out giaBan);

            tonKhoDangChon =
                Convert.ToInt32(selected["SoLuong"]);

            // Cập nhật SanPhamTam để giỏ hàng lấy đúng giá của biến thể.
            sanPham.Gia = giaBan;

            label3.Text = "Giá: " + giaBan.ToString("N0") + " Đ";

            if (tonKhoDangChon > 0)
            {
                lblTonKho.Text =
                    "Tồn kho: " + tonKhoDangChon + " sản phẩm";
                lblTonKho.ForeColor = Color.FromArgb(30, 150, 70);

                button4.Enabled = true;
                button5.Enabled = true;
            }
            else
            {
                lblTonKho.Text = "Tồn kho: HẾT HÀNG";
                lblTonKho.ForeColor = Color.FromArgb(210, 30, 45);

                button4.Enabled = false;
                button5.Enabled = false;
            }

            lblMaBienThe.Text = "MaBienThe: " + maBienTheDangChon;

            if (soLuong > Math.Max(1, tonKhoDangChon))
                soLuong = Math.Max(1, tonKhoDangChon);

            button2.Text = soLuong.ToString();
        }

        // =========================================================
        // SỐ LƯỢNG
        // =========================================================

        private void button1_Click(object sender, EventArgs e)
        {
            if (soLuong > 1)
                soLuong--;

            button2.Text = soLuong.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tonKhoDangChon <= 0)
                return;

            if (soLuong < tonKhoDangChon)
                soLuong++;

            button2.Text = soLuong.ToString();
        }

        // =========================================================
        // THÊM VÀO GIỎ
        // =========================================================

        private bool ThemSanPhamVaoGio()
        {
            if (sanPham == null)
                return false;

            string size = comboBox1.Text.Trim();
            string mauSac = cboMauSac == null
                ? ""
                : cboMauSac.Text.Trim();

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

            if (string.IsNullOrWhiteSpace(mauSac))
            {
                MessageBox.Show(
                    "Vui lòng chọn màu.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cboMauSac.Focus();
                return false;
            }

            if (maBienTheDangChon <= 0)
            {
                MessageBox.Show(
                    "Không tìm thấy biến thể Size + Màu đã chọn.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (tonKhoDangChon <= 0)
            {
                MessageBox.Show(
                    "Biến thể này đã hết hàng.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (soLuong > tonKhoDangChon)
                soLuong = tonKhoDangChon;

            // Tương thích với GioHangManager hiện tại.
            // Sau khi manager được nâng cấp MaBienThe, dùng overload 5 tham số.
            GioHangManager.Them(
                sanPham,
                size,
                mauSac,
                soLuong);

            return true;
        }

        // =========================================================
        // GIỎ HÀNG / MUA NGAY
        // =========================================================

        private void button4_Click(object sender, EventArgs e)
        {
            if (!ThemSanPhamVaoGio())
                return;

            MessageBox.Show(
                "Đã thêm sản phẩm vào giỏ hàng!",
                "SPORTSHOP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!ThemSanPhamVaoGio())
                return;

            using (Giohang formGioHang = new Giohang())
            {
                formGioHang.StartPosition = FormStartPosition.CenterParent;
                formGioHang.ShowDialog(this);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void chitietsanpham_Load_1(object sender, EventArgs e)
        {
        }
    }
}

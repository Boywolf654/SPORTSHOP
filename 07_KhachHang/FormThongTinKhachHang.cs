using SPORTSHOP._06_BanHang;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;

namespace SPORTSHOP._07_KhachHang
{
    public partial class FormThongTinKhachHang : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        private int maKH = 0;

        private TextBox txtHoTen;
        private TextBox txtSDT;
        private TextBox txtEmail;

        private bool dangChinhSua = false;
        private Button btnThoat;
        private Button btnQuanLyDiaChi;
        private string loaiKhachHang = "Cá nhân";

        public FormThongTinKhachHang()
        {
            InitializeComponent();

            btnChinhsua.Click += btnChinhsua_Click;
            btnNgunggiaodich.Click += btnNgunggiaodich_Click;

            btn_canhan.Click += btn_canhan_Click;
            btn_dntc.Click += btn_dntc_Click;

            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;

            CauHinhGiaoDienSPORTSHOP();
            TaoNutThoat();
            TaoNutQuanLyDiaChi();
            BoTriGiaoDien();
            Resize += (s, e) => BoTriGiaoDien();
            KeyPreview = true;
            KeyDown += FormThongTinKhachHang_KeyDown;
        }

        // =========================================================
        // GIAO DIỆN SPORTSHOP - DARK / RED
        // =========================================================

        private void CauHinhGiaoDienSPORTSHOP()
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(10, 10, 12);
            DoubleBuffered = true;

            pnlKhungChinh.BackColor = Color.FromArgb(10, 10, 12);
            pnlHeader.FillColor = Color.FromArgb(18, 18, 20);
            pnlHeader.BorderColor = Color.FromArgb(55, 55, 60);
            pnlHeader.ShadowDecoration.Enabled = false;

            lbthongtinkhachhang.ForeColor = Color.White;
            lbMakh.ForeColor = Color.FromArgb(170, 170, 178);

            btnDaiDienAvatar.FillColor = Color.FromArgb(220, 30, 45);
            btnDaiDienAvatar.ForeColor = Color.White;

            btnChinhsua.FillColor = Color.FromArgb(220, 30, 45);
            btnChinhsua.ForeColor = Color.White;
            btnChinhsua.HoverState.FillColor = Color.FromArgb(190, 25, 38);

            btnNgunggiaodich.FillColor = Color.FromArgb(35, 35, 39);
            btnNgunggiaodich.ForeColor = Color.FromArgb(255, 105, 115);
            btnNgunggiaodich.BorderColor = Color.FromArgb(130, 35, 45);
            btnNgunggiaodich.HoverState.FillColor = Color.FromArgb(55, 35, 39);

            tab_dieuhuong.TabMenuBackColor = Color.FromArgb(18, 18, 20);
            tab_dieuhuong.TabButtonIdleState.FillColor = Color.FromArgb(18, 18, 20);
            tab_dieuhuong.TabButtonIdleState.InnerColor = Color.FromArgb(18, 18, 20);
            tab_dieuhuong.TabButtonIdleState.ForeColor = Color.FromArgb(155, 155, 165);
            tab_dieuhuong.TabButtonHoverState.FillColor = Color.FromArgb(38, 38, 42);
            tab_dieuhuong.TabButtonHoverState.InnerColor = Color.FromArgb(38, 38, 42);
            tab_dieuhuong.TabButtonHoverState.ForeColor = Color.White;
            tab_dieuhuong.TabButtonSelectedState.FillColor = Color.FromArgb(220, 30, 45);
            tab_dieuhuong.TabButtonSelectedState.InnerColor = Color.FromArgb(220, 30, 45);
            tab_dieuhuong.TabButtonSelectedState.ForeColor = Color.White;

            Color bg = Color.FromArgb(15, 15, 17);
            Color card = Color.FromArgb(28, 28, 31);
            Color border = Color.FromArgb(52, 52, 58);
            Color title = Color.White;
            Color sub = Color.FromArgb(155, 155, 165);
            Color value = Color.FromArgb(238, 238, 242);

            foreach (TabPage page in new[] { tabPage3, tabPage4, tabPage5, tabPage6 })
            {
                page.BackColor = bg;
                page.ForeColor = title;
            }

            foreach (Guna.UI2.WinForms.Guna2Panel panel in new[]
            {
                pnlDinhDanh, pnlChonloaikhachhang, pnlGoiY,
                pnlLienHe, pnlHang, pnlDiem, pnlCongNo, pnlThanhToan
            })
            {
                panel.FillColor = card;
                panel.BorderColor = border;
                panel.ShadowDecoration.Enabled = false;
            }

            foreach (Label label in new[]
            {
                label1, label2, label16, label28, label30
            })
                label.ForeColor = title;

            foreach (Label label in new[]
            {
                label4, label6, label8, label10, label12, label14,
                label17, label18, label20, label22, label24, label26,
                label29, label31, label32, label34, label36, label38, label40
            })
                label.ForeColor = sub;

            foreach (Label label in new[]
            {
                label5, label7, label9, label11, label13, label15,
                label19, label21, label23, label25, label27, label33, label35
            })
                label.ForeColor = value;

            label37.ForeColor = Color.FromArgb(255, 190, 70);
            label39.ForeColor = Color.FromArgb(255, 100, 110);
            label41.ForeColor = Color.FromArgb(255, 85, 95);

            lbGoiY.ForeColor = Color.FromArgb(255, 185, 190);
            pnlGoiY.FillColor = Color.FromArgb(45, 20, 24);
            pnlGoiY.BorderColor = Color.FromArgb(110, 35, 45);

            btn_canhan.FillColor = Color.FromArgb(220, 30, 45);
            btn_canhan.ForeColor = Color.White;
            btn_dntc.FillColor = Color.FromArgb(40, 40, 44);
            btn_dntc.ForeColor = Color.FromArgb(180, 180, 188);

            dataGridView1.BackgroundColor = Color.FromArgb(28, 28, 31);
            dataGridView1.GridColor = Color.FromArgb(50, 50, 55);
            dataGridView1.ThemeStyle.BackColor = Color.FromArgb(28, 28, 31);
            dataGridView1.ThemeStyle.GridColor = Color.FromArgb(50, 50, 55);
            dataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(38, 38, 42);
            dataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dataGridView1.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(28, 28, 31);
            dataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(235, 235, 238);
            dataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(32, 32, 35);
            dataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(85, 25, 32);
            dataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
        }

        private void TaoNutThoat()
        {
            btnThoat = new Button
            {
                Name = "btnThoat",
                Text = "✕",
                Size = new Size(46, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(35, 35, 39),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TabStop = false
            };

            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.MouseEnter += (s, e) => btnThoat.BackColor = Color.FromArgb(220, 30, 45);
            btnThoat.MouseLeave += (s, e) => btnThoat.BackColor = Color.FromArgb(35, 35, 39);
            btnThoat.Click += (s, e) => Close();

            pnlHeader.Controls.Add(btnThoat);
            btnThoat.BringToFront();
        }

        private void TaoNutQuanLyDiaChi()
        {
            btnQuanLyDiaChi = new Button
            {
                Name = "btnQuanLyDiaChi",
                Text = "⌖  QUẢN LÝ ĐỊA CHỈ",
                Size = new Size(190, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(40, 40, 44),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            btnQuanLyDiaChi.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 76);
            btnQuanLyDiaChi.FlatAppearance.BorderSize = 1;
            btnQuanLyDiaChi.Click += btnQuanLyDiaChi_Click;

            tabPage4.Controls.Add(btnQuanLyDiaChi);
            btnQuanLyDiaChi.BringToFront();
        }

        private void BoTriGiaoDien()
        {
            if (btnThoat == null)
                return;

            btnThoat.Location = new Point(
                Math.Max(10, pnlHeader.ClientSize.Width - btnThoat.Width - 14), 14);

            btnChinhsua.Location = new Point(
                Math.Max(250, pnlHeader.ClientSize.Width - btnThoat.Width - btnChinhsua.Width - 28), 18);

            btnNgunggiaodich.Location = new Point(
                Math.Max(80, btnChinhsua.Left - btnNgunggiaodich.Width - 12), 18);

            if (btnQuanLyDiaChi != null)
            {
                btnQuanLyDiaChi.Location = new Point(
                    Math.Max(24, tabPage4.ClientSize.Width - btnQuanLyDiaChi.Width - 24),
                    18);
            }
        }

        private void btnQuanLyDiaChi_Click(object sender, EventArgs e)
        {
            if (maKH <= 0)
            {
                MessageBox.Show("Không xác định được khách hàng.", "Địa chỉ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (FormQuanLyDiaChi frm = new FormQuanLyDiaChi(maKH))
                {
                    frm.ShowDialog(this);
                }

                LoadDiaChiHienTai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở quản lý địa chỉ.\n\n" + ex.Message,
                    "Địa chỉ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // ĐỊA CHỈ / LIÊN HỆ
        // =========================================================

        private void LoadDiaChiHienTai()
        {
            if (maKH <= 0)
                return;

            try
            {
                string sql = @"
SELECT TOP 1
    DiaChiCuThe,
    PhuongXa,
    QuanHuyen,
    TinhThanh
FROM DiaChiKhachHang
WHERE MaKH = @MaKH
ORDER BY MacDinh DESC, MaDiaChi DESC";

                DataTable dt = kt.GetData(sql, new SqlParameter[]
                {
                    new SqlParameter("@MaKH", maKH)
                });

                if (dt.Rows.Count == 0)
                {
                    label19.Text = "Chưa cập nhật địa chỉ";
                    return;
                }

                DataRow r = dt.Rows[0];
                string diaChi = "";

                foreach (string col in new[] { "DiaChiCuThe", "PhuongXa", "QuanHuyen", "TinhThanh" })
                {
                    if (dt.Columns.Contains(col) && r[col] != DBNull.Value &&
                        !string.IsNullOrWhiteSpace(r[col].ToString()))
                    {
                        if (diaChi.Length > 0)
                            diaChi += ", ";
                        diaChi += r[col].ToString();
                    }
                }

                label19.Text = string.IsNullOrWhiteSpace(diaChi)
                    ? "Chưa cập nhật địa chỉ"
                    : diaChi;
            }
            catch
            {
                label19.Text = "Chưa cập nhật địa chỉ";
            }
        }

        private void FormThongTinKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                return;
            }

            if (e.Control && e.KeyCode == Keys.S && dangChinhSua)
            {
                LuuThongTinKhachHang();
                e.SuppressKeyPress = true;
            }
        }

        // =========================================================
        // LOAD FORM
        // =========================================================

        private void FormThongTinKhachHang_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                if (Session.MaTK <= 0)
                {
                    MessageBox.Show(
                        "Không xác định được tài khoản đang đăng nhập.",
                        "SPORTSHOP",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                LoadThongTinKhachHang();
                LoadDiaChiHienTai();
                LoadLichSuMuaHang();
                LoadThongTinThanhToan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải thông tin khách hàng.\n\n"
                    + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LOAD THÔNG TIN KHÁCH HÀNG
        // =========================================================

        private void LoadThongTinKhachHang()
        {
            string sql = @"
                SELECT
                    MaKH,
                    HoTen,
                    SDT,
                    Email,
                    DiemTichLuy,
                    HangThanhVien,
                    TrangThai
                FROM KhachHang
                WHERE MaTK = @MaTK";

            DataTable dt = kt.GetData(
                sql,
                new SqlParameter[]
                {
                    new SqlParameter("@MaTK", Session.MaTK)
                });

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Tài khoản hiện tại chưa có thông tin khách hàng.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DataRow row = dt.Rows[0];

            maKH = Convert.ToInt32(row["MaKH"]);

            string hoTen =
                row["HoTen"] == DBNull.Value
                    ? ""
                    : row["HoTen"].ToString();

            string sdt =
                row["SDT"] == DBNull.Value
                    ? ""
                    : row["SDT"].ToString();

            string email =
                row["Email"] == DBNull.Value
                    ? ""
                    : row["Email"].ToString();

            int diem =
                row["DiemTichLuy"] == DBNull.Value
                    ? 0
                    : Convert.ToInt32(row["DiemTichLuy"]);

            string hang =
                row["HangThanhVien"] == DBNull.Value
                    ? "Thường"
                    : row["HangThanhVien"].ToString();

            bool trangThai =
                row["TrangThai"] == DBNull.Value ||
                Convert.ToBoolean(row["TrangThai"]);

            // ==============================
            // HEADER
            // ==============================

            lbthongtinkhachhang.Text =
                string.IsNullOrWhiteSpace(hoTen)
                    ? "Khách hàng"
                    : hoTen;

            lbMakh.Text = "KH-" + maKH.ToString("D5");

            btnDaiDienAvatar.Text = LayChuCaiDaiDien(hoTen);

            // Trạng thái đặt lại vị trí ngay sau mã KH
            lbTrangthai.Left = lbMakh.Right + 18;

            if (trangThai)
            {
                lbTrangthai.Text = "• Đang giao dịch";
                lbTrangthai.ForeColor =
                    Color.FromArgb(16, 185, 129);

                btnNgunggiaodich.Text = "Ngừng giao dịch";

                btnNgunggiaodich.FillColor =
                    Color.FromArgb(254, 242, 242);
                btnNgunggiaodich.ForeColor =
                    Color.FromArgb(220, 38, 38);
                btnNgunggiaodich.BorderColor =
                    Color.FromArgb(252, 165, 165);
            }
            else
            {
                lbTrangthai.Text = "• Ngừng giao dịch";
                lbTrangthai.ForeColor =
                    Color.FromArgb(220, 38, 38);

                btnNgunggiaodich.Text = "Mở lại giao dịch";

                btnNgunggiaodich.FillColor =
                    Color.FromArgb(236, 253, 245);
                btnNgunggiaodich.ForeColor =
                    Color.FromArgb(5, 150, 105);
                btnNgunggiaodich.BorderColor =
                    Color.FromArgb(167, 243, 208);
            }

            // ==============================
            // THÔNG TIN CHUNG
            // ==============================

            label5.Text = hoTen;

            label11.Text = "KH-" + maKH.ToString("D5");

            label15.Text =
                string.IsNullOrWhiteSpace(sdt)
                    ? "Chưa cập nhật"
                    : sdt;

            // Email
            label21.Text =
                string.IsNullOrWhiteSpace(email)
                    ? "Chưa cập nhật"
                    : email;

            // Hạng thành viên
            label37.Text = hang;
            label37.ForeColor = LayMauTheoHang(hang);

            // Điểm tích lũy
            label41.Text = diem.ToString("N0") + " điểm";

            // Thông tin hiện tại chưa có cột tương ứng trong CSDL
            label7.Text = "Chưa cập nhật";
            label9.Text = "Chưa cập nhật";
            label13.Text = "Chưa cập nhật";
        }

        private void LoadThongTinThanhToan()
        {
            if (maKH <= 0)
                return;

            try
            {
                string sql = @"
SELECT TOP 1
    tt.PhuongThucThanhToan
FROM ThanhToan tt
INNER JOIN HoaDon hd ON hd.MaHD = tt.MaHD
WHERE hd.MaKH = @MaKH
ORDER BY tt.NgayThanhToan DESC";

                DataTable dt = kt.GetData(sql, new SqlParameter[]
                {
                    new SqlParameter("@MaKH", maKH)
                });

                label35.Text = dt.Rows.Count == 0
                    ? "Chưa có dữ liệu"
                    : Convert.ToString(dt.Rows[0]["PhuongThucThanhToan"]);
            }
            catch
            {
                label35.Text = "Chưa có dữ liệu";
            }

            // Database hiện tại không có bảng/cột hạn mức công nợ.
            // Không hiển thị số giả để tránh sai nghiệp vụ.
            label33.Text = "Chưa cấu hình";
            label39.Text = "Chưa theo dõi";
        }

        // =========================================================
        // TIỆN ÍCH HIỂN THỊ
        // =========================================================

        private string LayChuCaiDaiDien(string hoTen)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
                return "KH";

            string[] phan = hoTen.Trim().Split(
                new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            if (phan.Length == 1)
                return phan[0].Substring(0, 1).ToUpper();

            string dau = phan[0].Substring(0, 1);
            string cuoi = phan[phan.Length - 1].Substring(0, 1);

            return (dau + cuoi).ToUpper();
        }

        private Color LayMauTheoHang(string hang)
        {
            string h = (hang ?? "").Trim().ToLower();

            if (h.Contains("kim cương"))
                return Color.FromArgb(14, 165, 233);

            if (h.Contains("vàng"))
                return Color.FromArgb(217, 119, 6);

            if (h.Contains("bạc"))
                return Color.FromArgb(100, 116, 139);

            if (h.Contains("đồng"))
                return Color.FromArgb(180, 83, 9);

            return Color.FromArgb(90, 96, 108);
        }

        // =========================================================
        // CHỈNH SỬA
        // =========================================================

        private void btnChinhsua_Click(
            object sender,
            EventArgs e)
        {
            if (maKH <= 0)
                return;

            if (!dangChinhSua)
            {
                BatCheDoChinhSua();

                btnChinhsua.Text = "Lưu thay đổi";

                btnChinhsua.FillColor =
                    Color.FromArgb(16, 185, 129);

                dangChinhSua = true;

                return;
            }

            LuuThongTinKhachHang();
        }

        // =========================================================
        // TẠO TEXTBOX CHỈ KHI CHỈNH SỬA
        // =========================================================

        private void BatCheDoChinhSua()
        {
            // Họ tên
            txtHoTen = TaoTextBox(
                label5,
                label5.Text);

            // Số điện thoại
            txtSDT = TaoTextBox(
                label15,
                label15.Text == "Chưa cập nhật"
                    ? ""
                    : label15.Text);

            // Email
            txtEmail = TaoTextBox(
                label21,
                label21.Text == "Chưa cập nhật"
                    ? ""
                    : label21.Text);

            txtHoTen.Focus();
        }

        private TextBox TaoTextBox(
            Label label,
            string giaTri)
        {
            TextBox txt = new TextBox();

            txt.Text = giaTri;

            txt.Font = new Font(
                "Segoe UI",
                10.5F);

            txt.Location = new Point(
                label.Location.X,
                label.Location.Y + 1);

            // Giữ nguyên bề rộng của nhãn để không tràn ra ngoài thẻ
            txt.Size = new Size(
                Math.Max(200, label.Width),
                28);

            txt.BorderStyle = BorderStyle.FixedSingle;

            txt.BackColor = Color.FromArgb(22, 22, 25);

            txt.ForeColor = Color.White;

            label.Parent.Controls.Add(txt);

            label.Visible = false;

            txt.BringToFront();

            return txt;
        }

        // =========================================================
        // LƯU THÔNG TIN
        // =========================================================

        private void LuuThongTinKhachHang()
        {
            string hoTen = txtHoTen.Text.Trim();

            string sdt = txtSDT.Text.Trim();

            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show(
                    "Họ tên không được để trống.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtHoTen.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(sdt))
            {
                if (sdt.Length != 10 ||
                    !long.TryParse(sdt, out _))
                {
                    MessageBox.Show(
                        "Số điện thoại phải gồm 10 chữ số.",
                        "SPORTSHOP",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSDT.Focus();
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                try
                {
                    MailAddress mail = new MailAddress(email);
                    if (!mail.Address.Equals(email, StringComparison.OrdinalIgnoreCase))
                        throw new FormatException();
                }
                catch
                {
                    MessageBox.Show(
                        "Email không hợp lệ.",
                        "SPORTSHOP",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtEmail.Focus();
                    return;
                }
            }

            try
            {
                string duplicateSql = @"
SELECT TOP 1 MaKH
FROM KhachHang
WHERE MaKH <> @MaKH
  AND (
        (@SDT <> '' AND SDT = @SDT)
        OR
        (@Email <> '' AND Email = @Email)
      )";

                DataTable duplicate = kt.GetData(
                    duplicateSql,
                    new SqlParameter[]
                    {
                        new SqlParameter("@MaKH", maKH),
                        new SqlParameter("@SDT", sdt),
                        new SqlParameter("@Email", email)
                    });

                if (duplicate.Rows.Count > 0)
                {
                    MessageBox.Show(
                        "Số điện thoại hoặc email đã được sử dụng bởi khách hàng khác.",
                        "SPORTSHOP",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                string sql = @"
                    UPDATE KhachHang
                    SET
                        HoTen = @HoTen,
                        SDT = @SDT,
                        Email = @Email
                    WHERE MaKH = @MaKH";

                kt.Execute(
                sql,
                new SqlParameter[]
                {
                    new SqlParameter("@HoTen", hoTen),

                    new SqlParameter(
                        "@SDT",
                        string.IsNullOrWhiteSpace(sdt)
                            ? (object)DBNull.Value
                            : sdt),

                    new SqlParameter(
                        "@Email",
                        string.IsNullOrWhiteSpace(email)
                            ? (object)DBNull.Value
                            : email),

                    new SqlParameter("@MaKH", maKH)
                });

                XoaTextBoxChinhSua();

                dangChinhSua = false;

                btnChinhsua.Text = "Chỉnh sửa";

                btnChinhsua.FillColor =
                    Color.FromArgb(24, 119, 242);

                LoadThongTinKhachHang();

                MessageBox.Show(
                    "Cập nhật thông tin thành công!",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Không thể cập nhật thông tin.\n\n"
                    + ex.Message,
                    "Lỗi SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // XÓA TEXTBOX SAU KHI LƯU
        // =========================================================

        private void XoaTextBoxChinhSua()
        {
            if (txtHoTen != null)
            {
                txtHoTen.Dispose();
                txtHoTen = null;
            }

            if (txtSDT != null)
            {
                txtSDT.Dispose();
                txtSDT = null;
            }

            if (txtEmail != null)
            {
                txtEmail.Dispose();
                txtEmail = null;
            }

            label5.Visible = true;
            label15.Visible = true;
            label21.Visible = true;
        }

        // =========================================================
        // NGỪNG / MỞ GIAO DỊCH
        // =========================================================

        private void btnNgunggiaodich_Click(
            object sender,
            EventArgs e)
        {
            if (maKH <= 0)
                return;

            bool dangHoatDong =
                lbTrangthai.Text.Contains("Đang giao dịch");

            if (dangHoatDong)
            {
                DialogResult result =
                    MessageBox.Show(
                        "Bạn có chắc muốn ngừng giao dịch với khách hàng này?\n\n" +
                        "Khách hàng sẽ không thể thanh toán hoặc tạo đơn mới cho đến khi được mở lại giao dịch.",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                CapNhatTrangThai(false);
            }
            else
            {
                DialogResult result =
                    MessageBox.Show(
                        "Mở lại giao dịch cho khách hàng này?\n\n" +
                        "Sau khi mở lại, khách hàng có thể thanh toán và tạo đơn mới.",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                CapNhatTrangThai(true);
            }
        }

        private void CapNhatTrangThai(bool trangThai)
        {
            try
            {
                string sql = @"
                    UPDATE KhachHang
                    SET TrangThai = @TrangThai
                    WHERE MaKH = @MaKH";

                kt.Execute(
                sql,
                new SqlParameter[]
                {
                    new SqlParameter("@TrangThai", trangThai),
                    new SqlParameter("@MaKH", maKH)
                });

                LoadThongTinKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể cập nhật trạng thái.\n\n"
                    + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LOẠI KHÁCH HÀNG
        // =========================================================

        private void btn_canhan_Click(
            object sender,
            EventArgs e)
        {
            loaiKhachHang = "Cá nhân";
            btn_canhan.FillColor =
                Color.FromArgb(24, 119, 242);

            btn_canhan.ForeColor = Color.White;

            btn_dntc.FillColor =
                Color.FromArgb(245, 247, 250);

            btn_dntc.ForeColor =
                Color.FromArgb(110, 115, 125);

            label3.Text =
                "Áp dụng khi khách hàng là một cá nhân mua hàng trực tiếp.";
        }

        private void btn_dntc_Click(
            object sender,
            EventArgs e)
        {
            loaiKhachHang = "Doanh nghiệp/Tổ chức";
            btn_dntc.FillColor =
                Color.FromArgb(24, 119, 242);

            btn_dntc.ForeColor = Color.White;

            btn_canhan.FillColor =
                Color.FromArgb(245, 247, 250);

            btn_canhan.ForeColor =
                Color.FromArgb(110, 115, 125);

            label3.Text =
                "Áp dụng khi khách hàng là doanh nghiệp hoặc tổ chức mua hàng.";
        }

        // =========================================================
        // LỊCH SỬ MUA HÀNG
        // =========================================================

        private void LoadLichSuMuaHang()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            try
            {
                string sql = @"
SELECT TOP 100
    hd.MaHD,
    hd.NgayLap,
    hd.TongTien,
    hd.TrangThaiDonHang
FROM HoaDon hd
WHERE hd.MaKH = @MaKH
ORDER BY hd.NgayLap DESC, hd.MaHD DESC";

                DataTable dt = kt.GetData(
                    sql,
                    new SqlParameter[]
                    {
                        new SqlParameter("@MaKH", maKH)
                    });

                if (dt.Rows.Count == 0)
                {
                    TaoCotLichSu();
                    dataGridView1.Rows.Add(
                        "—",
                        "Chưa có đơn hàng",
                        "0 VNĐ",
                        "Chưa có dữ liệu");
                    return;
                }

                dataGridView1.DataSource = dt;

                dataGridView1.Columns["MaHD"].HeaderText = "Mã hóa đơn";
                dataGridView1.Columns["NgayLap"].HeaderText = "Ngày mua";
                dataGridView1.Columns["TongTien"].HeaderText = "Tổng tiền";
                dataGridView1.Columns["TrangThaiDonHang"].HeaderText = "Trạng thái";

                dataGridView1.Columns["MaHD"].Width = 120;
                dataGridView1.Columns["NgayLap"].Width = 180;
                dataGridView1.Columns["TongTien"].Width = 180;
                dataGridView1.Columns["TrangThaiDonHang"].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns["NgayLap"].DefaultCellStyle.Format =
                    "dd/MM/yyyy HH:mm";
                dataGridView1.Columns["TongTien"].DefaultCellStyle.Format =
                    "N0";
            }
            catch (Exception ex)
            {
                TaoCotLichSu();
                dataGridView1.Rows.Add(
                    "—",
                    "Không tải được dữ liệu",
                    "0 VNĐ",
                    ex.Message);
            }

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void TaoCotLichSu()
        {
            dataGridView1.Columns.Add("MaHD", "Mã hóa đơn");
            dataGridView1.Columns.Add("NgayLap", "Ngày mua");
            dataGridView1.Columns.Add("TongTien", "Tổng tiền");
            dataGridView1.Columns.Add("TrangThaiDonHang", "Trạng thái");
        }

        private void dataGridView1_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                dataGridView1.Rows[e.RowIndex].Cells["MaHD"] == null)
                return;

            object value = dataGridView1.Rows[e.RowIndex].Cells["MaHD"].Value;

            int maHD;
            if (value == null ||
                !int.TryParse(Convert.ToString(value), out maHD) ||
                maHD <= 0)
                return;
        

            try
            {
                using (FormChiTietHoaDon frm =
                    new SPORTSHOP._06_BanHang.FormChiTietHoaDon(maHD))
                {
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở chi tiết hóa đơn.\n\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using SPORTSHOP._06_BanHang;
using SPORTSHOP._07_KhachHang;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class formgiaodienbanhang : Form
    {
        // true = nhân viên đang mua hàng cho chính mình.
        // Không thay đổi Session và không tạo tài khoản khách hàng thứ hai.
        private readonly bool cheDoNhanVienMuaHang;
        private int maKHNhanVien;
        // =========================
        // MÀU CHỦ ĐẠO
        // =========================
        private readonly Color MauDo =
            Color.FromArgb(220, 30, 45);

        private readonly Color MauDen =
            Color.FromArgb(18, 18, 18);

        private readonly Color MauTrang =
            Color.White;

        public formgiaodienbanhang() : this(false)
        {
        }

        public formgiaodienbanhang(bool laNhanVienMuaHang)
        {
            cheDoNhanVienMuaHang = laNhanVienMuaHang;

            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;

            // Panel tài khoản được tạo bằng code runtime để không làm hỏng Designer.
            TaoPanelTaiKhoan();

            if (cheDoNhanVienMuaHang)
            {
                maKHNhanVien = LayMaKHTrongTaiKhoan();
                CauHinhCheDoNhanVienMuaHang();
            }
        }

        private void CauHinhCheDoNhanVienMuaHang()
        {
            this.Text = "SPORTSHOP - Mua hàng cá nhân của nhân viên";
        }

        // =========================================================
        // PANEL TÀI KHOẢN KHÁCH HÀNG
        // =========================================================

        private Panel panelTaiKhoan;
        private Panel panelTaiKhoanNoiDung;
        private Label lblTaiKhoanHeader;
        private Label lblTaiKhoanThongTin;
        private bool panelTaiKhoanDangMo = false;

        private void TaoPanelTaiKhoan()
        {
            panelTaiKhoan = new Panel
            {
                Name = "panelTaiKhoan",
                Width = 350,
                BackColor = Color.FromArgb(25, 25, 27),
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right,
                Visible = false
            };

            panelTaiKhoan.Height = this.ClientSize.Height;
            panelTaiKhoan.Left = this.ClientSize.Width - panelTaiKhoan.Width;
            panelTaiKhoan.Top = menuStrip1.Height;

            lblTaiKhoanHeader = new Label
            {
                Text = cheDoNhanVienMuaHang
                    ? "👤  TÀI KHOẢN NHÂN VIÊN - MUA HÀNG CÁ NHÂN"
                    : "👤  TÀI KHOẢN KHÁCH HÀNG",
                Dock = DockStyle.Top,
                Height = 58,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = MauDo
            };

            lblTaiKhoanThongTin = new Label
            {
                Text = "Đang tải thông tin...",
                Dock = DockStyle.Top,
                Height = 72,
                Padding = new Padding(18, 10, 18, 5),
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.Gainsboro,
                BackColor = Color.FromArgb(35, 35, 38)
            };

            panelTaiKhoanNoiDung = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(25, 25, 27),
                Padding = new Padding(15, 12, 15, 12),
                AutoScroll = true
            };

            panelTaiKhoan.Controls.Add(panelTaiKhoanNoiDung);
            panelTaiKhoan.Controls.Add(lblTaiKhoanThongTin);
            panelTaiKhoan.Controls.Add(lblTaiKhoanHeader);

            if (cheDoNhanVienMuaHang)
            {
                Label lblCheDo = new Label
                {
                    Text = "🛒  CHẾ ĐỘ MUA HÀNG CÁ NHÂN",
                    Dock = DockStyle.Top,
                    Height = 34,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(55, 35, 38)
                };
                panelTaiKhoan.Controls.Add(lblCheDo);
                lblCheDo.BringToFront();
            }

            this.Controls.Add(panelTaiKhoan);
            panelTaiKhoan.BringToFront();

            // Tài khoản trên MenuStrip vẫn được giữ nguyên.
            tàiKhoảnToolStripMenuItem.Click += (s, e) => TogglePanelTaiKhoan();

            ThemNutTaiKhoan("👤  Thông tin khách hàng", MoThongTinKhachHang);
            ThemNutTaiKhoan("⭐  Hội viên", MoHoiVien);
            ThemNutTaiKhoan("💰  Ví điện tử", MoViDienTu);
            ThemNutTaiKhoan("🎟  Coupon / Voucher", MoCoupon);
            ThemNutTaiKhoan("📍  Địa chỉ nhận hàng", MoDiaChi);
            ThemNutTaiKhoan("🧾  Đơn hàng của tôi", MoGioHang);
            ThemNutTaiKhoan("🧾  Lịch sử giao dịch", MoLichSuGiaoDich);

            Panel dong = new Panel
            {
                Height = 1,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(70, 70, 70)
            };
            panelTaiKhoanNoiDung.Controls.Add(dong);
            dong.BringToFront();

            Button btnDangXuat = TaoNutTaiKhoan("🚪  Đăng xuất", true);
            btnDangXuat.Click += DangXuat;
            panelTaiKhoanNoiDung.Controls.Add(btnDangXuat);
            btnDangXuat.BringToFront();

            this.Resize += (s, e) =>
            {
                if (panelTaiKhoan != null)
                {
                    panelTaiKhoan.Height = this.ClientSize.Height - menuStrip1.Height;
                    panelTaiKhoan.Top = menuStrip1.Height;
                }
            };
        }

        private void ThemNutTaiKhoan(string text, EventHandler click)
        {
            Button btn = TaoNutTaiKhoan(text, false);
            btn.Click += click;
            panelTaiKhoanNoiDung.Controls.Add(btn);
            btn.BringToFront();
        }

        private Button TaoNutTaiKhoan(string text, bool dangXuat)
        {
            Button btn = new Button
            {
                Text = text,
                Dock = DockStyle.Top,
                Height = 48,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 8, 0),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = dangXuat
                    ? Color.FromArgb(150, 30, 40)
                    : Color.FromArgb(40, 40, 43),
                Cursor = Cursors.Hand,
                FlatAppearance = { BorderSize = 0 }
            };

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = dangXuat
                    ? Color.FromArgb(190, 35, 48)
                    : MauDo;
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = dangXuat
                    ? Color.FromArgb(150, 30, 40)
                    : Color.FromArgb(40, 40, 43);
            };

            return btn;
        }

        private void TogglePanelTaiKhoan()
        {
            panelTaiKhoanDangMo = !panelTaiKhoanDangMo;

            if (panelTaiKhoanDangMo)
            {
                LoadTomTatTaiKhoan();
                panelTaiKhoan.Visible = true;
                panelTaiKhoan.BringToFront();
            }
            else
            {
                panelTaiKhoan.Visible = false;
            }
        }

        private void LoadTomTatTaiKhoan()
        {
            try
            {
                if (Session.MaTK <= 0)
                {
                    lblTaiKhoanThongTin.Text =
                        "Chưa xác định tài khoản khách hàng.";
                    return;
                }

                string sql = @"
                    SELECT TOP 1
                        kh.HoTen,
                        ISNULL(kh.DiemHoiVien, 0) AS DiemHoiVien,
                        ISNULL(kh.HangThanhVien, N'Đồng') AS HangThanhVien,
                        ISNULL(vd.SoDu, 0) AS SoDu
                    FROM KhachHang kh
                    LEFT JOIN ViDienTu vd ON vd.MaKH = kh.MaKH
                    WHERE kh.MaTK = @MaTK";

                DataTable dt = kt.GetData(
                    sql,
                    new SqlParameter[]
                    {
                        new SqlParameter("@MaTK", Session.MaTK)
                    });

                if (dt.Rows.Count == 0)
                {
                    lblTaiKhoanThongTin.Text =
                        "Tài khoản chưa có hồ sơ khách hàng.";
                    return;
                }

                DataRow r = dt.Rows[0];

                string ten = r["HoTen"] == DBNull.Value
                    ? "Khách hàng"
                    : r["HoTen"].ToString();

                int diem = r["DiemHoiVien"] == DBNull.Value
                    ? 0
                    : Convert.ToInt32(r["DiemHoiVien"]);

                string hang = r["HangThanhVien"] == DBNull.Value
                    ? "Đồng"
                    : r["HangThanhVien"].ToString();

                decimal soDu = r["SoDu"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(r["SoDu"]);

                lblTaiKhoanThongTin.Text =
                    "Xin chào, " + ten +
                    "\r\n⭐ " + hang + "  •  " + diem.ToString("N0") + " điểm" +
                    "\r\n💰 Số dư ví: " + soDu.ToString("N0") + " Đ";
            }
            catch
            {
                lblTaiKhoanThongTin.Text =
                    "Không tải được thông tin tài khoản.";
            }
        }

        private int LayMaKHTrongTaiKhoan()
        {
            if (Session.MaTK <= 0)
                return 0;

            object result = kt.ExecuteScalar(
                @"SELECT TOP 1 MaKH
                  FROM KhachHang
                  WHERE MaTK = @MaTK",
                new SqlParameter[]
                {
                    new SqlParameter("@MaTK", Session.MaTK)
                });

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToInt32(result);
        }

        private void MoThongTinKhachHang(object sender, EventArgs e)
        {
            try
            {
                using (FormThongTinKhachHang frm =
                    new FormThongTinKhachHang())
                {
                    frm.ShowDialog(this);
                }

                LoadTomTatTaiKhoan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở thông tin khách hàng.\r\n\r\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MoHoiVien(object sender, EventArgs e)
        {
            try
            {
                using (FormHoiVien frm = new FormHoiVien())
                {
                    frm.ShowDialog(this);
                }

                LoadTomTatTaiKhoan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở phần hội viên.\r\n\r\n" + ex.Message,
                    "Hội viên",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MoViDienTu(object sender, EventArgs e)
        {
            try
            {
                using (FormViDienTu frm = new FormViDienTu())
                {
                    frm.ShowDialog(this);
                }

                LoadTomTatTaiKhoan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở Ví điện tử.\r\n\r\n" + ex.Message,
                    "Ví điện tử",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MoCoupon(object sender, EventArgs e)
        {
            try
            {
                decimal tongTien = GioHangManager.TongTien();

                using (SPORTSHOP._06_BanHang.coupon frm =
                    new SPORTSHOP._06_BanHang.coupon(tongTien))
                {
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở Coupon / Voucher.\r\n\r\n" + ex.Message,
                    "Coupon",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MoDiaChi(object sender, EventArgs e)
        {
            try
            {
                int maKH = LayMaKHTrongTaiKhoan();

                if (maKH <= 0)
                {
                    MessageBox.Show(
                        "Không xác định được khách hàng.",
                        "Địa chỉ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                using (FormQuanLyDiaChi frm =
                    new FormQuanLyDiaChi(maKH))
                {
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở quản lý địa chỉ.\r\n\r\n" + ex.Message,
                    "Địa chỉ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MoGioHang(object sender, EventArgs e)
        {
            try
            {
                using (Giohang frm = new Giohang())
                {
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở giỏ hàng.\r\n\r\n" + ex.Message,
                    "Giỏ hàng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MoLichSuGiaoDich(object sender, EventArgs e)
        {
            try
            {
                // Form tự khóa truy vấn theo Session.MaTK.
                // Khách không được chọn MaKH hay xem lịch sử của người khác.
                using (FormLichSuGiaoDichKhachHang frm =
                    new FormLichSuGiaoDichKhachHang())
                {
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở lịch sử giao dịch.\r\n\r\n" +
                    ex.Message,
                    "Lịch sử giao dịch",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DangXuat(object sender, EventArgs e)
        {
            string thongBao = cheDoNhanVienMuaHang
                ? "Thoát chế độ mua hàng cá nhân?\r\n\r\nTài khoản nhân viên vẫn được giữ nguyên. Bạn sẽ quay lại màn hình trước đó."
                : "Bạn có chắc muốn đăng xuất?";

            DialogResult result = MessageBox.Show(
                thongBao,
                "SPORTSHOP",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (cheDoNhanVienMuaHang)
            {
                // Tuyệt đối không xóa Session: form hóa đơn/menu phía dưới vẫn là
                // phiên làm việc của cùng nhân viên.
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            Session.DangXuat();
            this.Close();
        }

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void formgiaodienbanhang_Load(
            object sender,
            EventArgs e)
        {
            if (cheDoNhanVienMuaHang)
            {
                if (Session.MaTK <= 0 || Session.MaNV <= 0 || maKHNhanVien <= 0)
                {
                    MessageBox.Show(
                        "Không xác định được hồ sơ khách hàng của nhân viên.\r\n\r\nKhông thể mở chế độ mua hàng cá nhân.",
                        "SPORTSHOP",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                    return;
                }
            }

            BoTatCaPictureBox(this);

            DecorForm();
            DecorMenu();
            DecorGroupBox();
            DecorDanhMuc();
            DecorSanPhamNoiBat();
            DecorUuDai();

            GanSuKienDanhMuc();
            GanSuKienSanPham();
        }

        // =========================================================
        // DANH MỤC
        // =========================================================

        private void GanSuKienDanhMuc()
        {
            giaypbx.Click += (s, e) =>
            {
                MoFormDanhMuc("giay");
            };

            quanaopbx.Click += (s, e) =>
            {
                MoFormDanhMuc("ao");
            };

            phukienpbx.Click += (s, e) =>
            {
                MoFormDanhMuc("phukien");
            };
        }

        private void MoFormDanhMuc(string loai)
        {
            Form form = null;

            try
            {
                switch (loai)
                {
                    case "giay":
                        form = new giaodiengiay();
                        break;

                    case "ao":
                        form = new giaodienqao();
                        break;

                    case "phukien":
                        form = new giaodienpkien();
                        break;
                }

                if (form != null)
                {
                    form.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở giao diện danh mục.\n\n"
                    + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SẢN PHẨM
        // =========================================================

        private void GanSuKienSanPham()
        {
            // Không còn lấy tên/giá sản phẩm từ code.
            // Card vẫn giữ nguyên giao diện trong Designer,
            // nhưng dữ liệu được nạp trực tiếp từ SQL Server.
            try
            {
                List<SanPhamDB> danhSach = LayDanhSachSanPham();

                Panel[] cards =
                {
                    giay1pnl, giay2pnl, giay3pnl, giay4pnl,
                    giay5pnl, giay6pnl, giay7pnl, giay8pnl,
                    giay9pnl, giay10pnl, giay11pnl
                };

                for (int i = 0; i < cards.Length; i++)
                {
                    if (i < danhSach.Count)
                    {
                        cards[i].Visible = true;
                        GanDuLieuVaoCard(cards[i], danhSach[i]);
                    }
                    else
                    {
                        cards[i].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải sản phẩm từ CSDL.\n\n" + ex.Message,
                    "SPORTSHOP - CSDL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private List<SanPhamDB> LayDanhSachSanPham()
        {
            string sql = @"
                SELECT TOP 11
                    sp.MaSP,
                    sp.TenSP,
                    ISNULL(th.TenThuongHieu, N'') AS TenThuongHieu,
                    ISNULL(dm.TenDanhMuc, N'') AS TenDanhMuc,
                    ISNULL(MIN(bt.GiaBan), 0) AS GiaBan,
                    ISNULL(SUM(ISNULL(tk.SLTon, 0)), 0) AS SLTon
                FROM SanPham sp
                LEFT JOIN DanhMuc dm
                    ON dm.MaDM = sp.MaDM
                LEFT JOIN ThuongHieu th
                    ON th.MaTH = sp.MaTH
                LEFT JOIN BienTheSanPham bt
                    ON bt.MaSP = sp.MaSP
                LEFT JOIN TonKho tk
                    ON tk.MaBienThe = bt.MaBienThe
                WHERE sp.TrangThai = 1
                GROUP BY
                    sp.MaSP,
                    sp.TenSP,
                    th.TenThuongHieu,
                    dm.TenDanhMuc
                ORDER BY sp.MaSP;";

            DataTable dt = kt.GetData(sql);

            List<SanPhamDB> result = new List<SanPhamDB>();

            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SanPhamDB
                {
                    MaSP = Convert.ToInt32(row["MaSP"]),
                    TenSP = row["TenSP"]?.ToString() ?? "",
                    ThuongHieu = row["TenThuongHieu"]?.ToString() ?? "",
                    DanhMuc = row["TenDanhMuc"]?.ToString() ?? "",
                    GiaBan = row["GiaBan"] == DBNull.Value
                        ? 0
                        : Convert.ToDecimal(row["GiaBan"]),
                    SLTon = row["SLTon"] == DBNull.Value
                        ? 0
                        : Convert.ToInt32(row["SLTon"])
                });
            }

            return result;
        }

        private void GanDuLieuVaoCard(
            Panel card,
            SanPhamDB data)
        {
            PictureBox pictureBox = TimPictureBox(card);

            Image anhMacDinh = pictureBox?.Image ?? pictureBox?.BackgroundImage;
            Image anhDB = LayAnhChinhTheoMaSP(data.MaSP, anhMacDinh);

            if (pictureBox != null && anhDB != null)
            {
                pictureBox.Image = anhDB;
                pictureBox.BackgroundImage = null;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }

            // Ẩn text hard-code trong Designer.
            foreach (Control control in card.Controls)
            {
                if (control is Label label &&
                    !label.Name.StartsWith("lblDB_"))
                {
                    label.Visible = false;
                }
            }

            Label lblTen = LayHoacTaoLabel(
                card,
                "lblDB_Ten",
                new Font("Segoe UI", 8.5F, FontStyle.Bold));

            Label lblGia = LayHoacTaoLabel(
                card,
                "lblDB_Gia",
                new Font("Segoe UI", 10F, FontStyle.Bold));

            Label lblTon = LayHoacTaoLabel(
                card,
                "lblDB_Ton",
                new Font("Segoe UI", 7.5F, FontStyle.Regular));

            int topTen = card.Width <= 120 ? 98 : 92;
            int topGia = card.Width <= 120 ? 132 : 142;
            int topTon = card.Width <= 120 ? 154 : 169;

            lblTen.Location = new Point(5, topTen);
            lblTen.Size = new Size(card.Width - 10, 34);
            lblTen.Text = RutGonTen(data.TenSP, card.Width <= 120 ? 28 : 42);
            lblTen.TextAlign = ContentAlignment.TopCenter;
            lblTen.ForeColor = Color.White;
            lblTen.Visible = true;

            lblGia.Location = new Point(5, topGia);
            lblGia.Size = new Size(card.Width - 10, 22);
            lblGia.Text = data.GiaBan > 0
                ? data.GiaBan.ToString("N0") + " Đ"
                : "Liên hệ";
            lblGia.TextAlign = ContentAlignment.TopCenter;
            lblGia.ForeColor = data.GiaBan > 0
                ? Color.FromArgb(255, 70, 70)
                : Color.White;
            lblGia.Visible = true;

            lblTon.Location = new Point(5, topTon);
            lblTon.Size = new Size(card.Width - 10, 18);
            lblTon.Text = data.SLTon > 0
                ? "Còn " + data.SLTon.ToString("N0")
                : "HẾT HÀNG";
            lblTon.TextAlign = ContentAlignment.TopCenter;
            lblTon.ForeColor = data.SLTon > 0
                ? Color.FromArgb(180, 255, 180)
                : Color.FromArgb(255, 100, 100);
            lblTon.Visible = true;

            SanPhamTam sanPham = new SanPhamTam
            {
                MaSP = data.MaSP,
                TenSP = data.TenSP,
                Gia = data.GiaBan,
                GiaCu = 0,
                Anh = anhDB ?? anhMacDinh,
                ThuongHieu = data.ThuongHieu,
                MauSac = "",
                MoTa = data.TenSP
            };

            // Gán lại Tag/click để mọi thành phần của card dùng đúng dữ liệu DB.
            card.Tag = sanPham;
            card.Cursor = Cursors.Hand;
            card.Click += SanPham_Click;

            GanClickControlCon(card, sanPham);
        }

        private PictureBox TimPictureBox(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is PictureBox pictureBox)
                    return pictureBox;

                if (control.HasChildren)
                {
                    PictureBox nested = TimPictureBox(control);
                    if (nested != null)
                        return nested;
                }
            }

            return null;
        }

        private Label LayHoacTaoLabel(
            Panel card,
            string name,
            Font font)
        {
            Label label = card.Controls[name] as Label;

            if (label == null)
            {
                label = new Label
                {
                    Name = name,
                    BackColor = Color.Transparent,
                    ForeColor = Color.White,
                    Font = font,
                    AutoEllipsis = true,
                    AutoSize = false
                };

                card.Controls.Add(label);
                label.BringToFront();
            }

            label.Font = font;
            label.BackColor = Color.Transparent;
            label.AutoSize = false;
            label.AutoEllipsis = true;

            return label;
        }

        private string RutGonTen(string ten, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(ten))
                return "Sản phẩm";

            ten = ten.Trim();

            if (ten.Length <= maxLength)
                return ten;

            return ten.Substring(0, Math.Max(1, maxLength - 3)) + "...";
        }

        private sealed class SanPhamDB
        {
            public int MaSP { get; set; }
            public string TenSP { get; set; }
            public string ThuongHieu { get; set; }
            public string DanhMuc { get; set; }
            public decimal GiaBan { get; set; }
            public int SLTon { get; set; }
        }

        private void GanClickCard(
            Panel card,
            int maSP,
            string tenSP,
            decimal gia,
            decimal giaCu,
            PictureBox pictureBox,
            string thuongHieu,
            string mauSac,
            string moTa)
        {
            SanPhamTam sanPham =
                new SanPhamTam
                {
                    MaSP = LayMaSPTheoTen(tenSP, maSP),
                    TenSP = tenSP,
                    Gia = gia,
                    GiaCu = giaCu,
                    Anh = LayAnhChinhTheoMaSP(
                         LayMaSPTheoTen(tenSP, maSP),
                         pictureBox.Image ?? pictureBox.BackgroundImage),
                    ThuongHieu = thuongHieu,
                    MauSac = mauSac,
                    MoTa = moTa
                };

            card.Tag = sanPham;
            card.Cursor = Cursors.Hand;

            card.Click += SanPham_Click;

            GanClickControlCon(
                card,
                sanPham);
        }

        private void GanClickControlCon(
            Control parent,
            SanPhamTam sanPham)
        {
            foreach (Control control in parent.Controls)
            {
                control.Tag = sanPham;
                control.Cursor = Cursors.Hand;

                control.Click += SanPham_Click;

                if (control.HasChildren)
                {
                    GanClickControlCon(
                        control,
                        sanPham);
                }
            }
        }

        // =========================================================
        // CLICK SẢN PHẨM → CHI TIẾT
        // =========================================================

        private void SanPham_Click(
            object sender,
            EventArgs e)
        {
            Control control =
                sender as Control;

            if (control == null)
                return;

            SanPhamTam sanPham =
                control.Tag as SanPhamTam;

            if (sanPham == null)
                return;

            try
            {
                chitietsanpham formChiTiet =
                    new chitietsanpham(sanPham);

                formChiTiet.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở chi tiết sản phẩm.\n\n"
                    + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // FORM
        // =========================================================

        private void DecorForm()
        {
            this.Text =
                "SPORTSHOP - Cửa hàng thể thao";

            this.BackColor = MauDen;

            pictureBox1.SizeMode =
                PictureBoxSizeMode.Zoom;

            pictureBox1.BackColor =
                Color.Transparent;
        }

        // =========================================================
        // MENU
        // =========================================================

        private void DecorMenu()
        {
            // Thanh menu chính
            menuStrip1.BackColor = Color.FromArgb(18, 18, 18);
            menuStrip1.ForeColor = Color.White;
            menuStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            menuStrip1.Renderer = new ModernMenuRenderer();

            foreach (ToolStripItem item in menuStrip1.Items)
            {
                item.ForeColor = Color.White;
                item.BackColor = Color.FromArgb(18, 18, 18);
                item.Padding = new Padding(14, 8, 14, 8);

                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.DropDown.BackColor = Color.White;
                    menuItem.DropDown.ForeColor = Color.FromArgb(35, 35, 35);
                    menuItem.DropDown.Padding = new Padding(5);

                    foreach (ToolStripItem child in menuItem.DropDownItems)
                    {
                        child.ForeColor = Color.FromArgb(35, 35, 35);
                        child.BackColor = Color.White;
                        child.Padding = new Padding(12, 8, 24, 8);
                        child.Margin = new Padding(0);
                    }
                }
            }
        }

        // =========================================================
        // GROUPBOX
        // =========================================================

        private void DecorGroupBox()
        {
            DecorGroupBoxStyle(groupBox1);
            DecorGroupBoxStyle(groupBox2);
            DecorGroupBoxStyle(groupBox3);
        }

        private void DecorGroupBoxStyle(
            GroupBox box)
        {
            box.BackColor =
                Color.FromArgb(
                    35,
                    35,
                    37);

            box.ForeColor = MauTrang;

            box.Font =
                new Font(
                    "Segoe UI",
                    13F,
                    FontStyle.Bold);

            box.Padding =
                new Padding(10);
        }

        // =========================================================
        // DANH MỤC
        // =========================================================

        private void DecorDanhMuc()
        {
            DecorCategoryPicture(giaypbx);
            DecorCategoryPicture(quanaopbx);
            DecorCategoryPicture(phukienpbx);
        }

        private void DecorCategoryPicture(
            PictureBox pic)
        {
            pic.BackColor = MauTrang;

            pic.Cursor =
                Cursors.Hand;

            pic.SizeMode =
                PictureBoxSizeMode.Zoom;

            pic.MouseEnter +=
                Category_MouseEnter;

            pic.MouseLeave +=
                Category_MouseLeave;
        }

        private void Category_MouseEnter(
            object sender,
            EventArgs e)
        {
            PictureBox pic =
                sender as PictureBox;

            if (pic == null)
                return;

            pic.BackColor =
                Color.FromArgb(
                    245,
                    245,
                    245);

            pic.Cursor =
                Cursors.Hand;
        }

        private void Category_MouseLeave(
            object sender,
            EventArgs e)
        {
            PictureBox pic =
                sender as PictureBox;

            if (pic == null)
                return;

            pic.BackColor =
                MauTrang;
        }

        // =========================================================
        // SẢN PHẨM NỔI BẬT
        // =========================================================

        private void DecorSanPhamNoiBat()
        {
            DecorCard(giay1pnl);
            DecorCard(giay2pnl);
            DecorCard(giay3pnl);
            DecorCard(giay4pnl);
        }

        // =========================================================
        // ƯU ĐÃI
        // =========================================================

        private void DecorUuDai()
        {
            DecorCard(giay5pnl);
            DecorCard(giay6pnl);
            DecorCard(giay7pnl);
            DecorCard(giay8pnl);
            DecorCard(giay9pnl);
            DecorCard(giay10pnl);
            DecorCard(giay11pnl);
        }

        // =========================================================
        // PRODUCT CARD
        // =========================================================

        private void DecorCard(
            Panel card)
        {
            card.BackColor =
                Color.FromArgb(
                    35,
                    35,
                    38);

            card.BorderStyle =
                BorderStyle.None;

            card.Cursor =
                Cursors.Hand;

            BoGocPanel(card, 12);

            card.MouseEnter +=
                Card_MouseEnter;

            card.MouseLeave +=
                Card_MouseLeave;

            foreach (Control control
                in card.Controls)
            {
                control.MouseEnter +=
                    Child_MouseEnter;

                control.MouseLeave +=
                    Child_MouseLeave;

                if (control is PictureBox pic)
                {
                    pic.BackColor =
                        MauTrang;

                    pic.SizeMode =
                        PictureBoxSizeMode.Zoom;

                    pic.Padding =
                        new Padding(6);
                }

                if (control is Label label)
                {
                    label.BackColor =
                        Color.Transparent;

                    label.ForeColor =
                        MauTrang;

                    label.Font =
                        new Font(
                            "Segoe UI",
                            8.5F,
                            FontStyle.Regular);
                }
            }

            // Xử lý màu giá
            foreach (Control control
                in card.Controls)
            {
                if (control is Label label)
                {
                    if (label.Font.Strikeout)
                    {
                        label.ForeColor =
                            Color.FromArgb(
                                150,
                                150,
                                150);

                        label.Font =
                            new Font(
                                "Segoe UI",
                                8F,
                                FontStyle.Strikeout);
                    }
                    else if (
                        label.Text.Contains("Đ"))
                    {
                        label.ForeColor =
                            Color.FromArgb(
                                255,
                                70,
                                70);

                        label.Font =
                            new Font(
                                "Segoe UI",
                                10F,
                                FontStyle.Bold);
                    }
                }
            }
        }

        // =========================================================
        // BO GÓC PANEL
        // =========================================================

        private void BoGocPanel(
            Panel panel,
            int radius)
        {
            if (panel.Width <= radius ||
                panel.Height <= radius)
                return;

            GraphicsPath path =
                new GraphicsPath();

            path.AddArc(
                0,
                0,
                radius,
                radius,
                180,
                90);

            path.AddArc(
                panel.Width - radius,
                0,
                radius,
                radius,
                270,
                90);

            path.AddArc(
                panel.Width - radius,
                panel.Height - radius,
                radius,
                radius,
                0,
                90);

            path.AddArc(
                0,
                panel.Height - radius,
                radius,
                radius,
                90,
                90);

            path.CloseFigure();

            panel.Region =
                new Region(path);
        }

        // =========================================================
        // HOVER CARD
        // =========================================================

        private void Card_MouseEnter(
            object sender,
            EventArgs e)
        {
            Panel card =
                sender as Panel;

            if (card == null)
                return;

            card.BackColor =
                Color.FromArgb(
                    50,
                    50,
                    54);
        }

        private void Card_MouseLeave(
            object sender,
            EventArgs e)
        {
            Panel card =
                sender as Panel;

            if (card == null)
                return;

            card.BackColor =
                Color.FromArgb(
                    32,
                    32,
                    34);
        }

        private void Child_MouseEnter(
            object sender,
            EventArgs e)
        {
            Control control =
                sender as Control;

            if (control?.Parent is Panel card)
            {
                card.BackColor =
                    Color.FromArgb(
                        45,
                        45,
                        48);
            }
        }

        private void Child_MouseLeave(
            object sender,
            EventArgs e)
        {
            Control control =
                sender as Control;

            if (control?.Parent is Panel card)
            {
                card.BackColor =
                    Color.FromArgb(
                        32,
                        32,
                        34);
            }
        }

        // =========================================================
        // BO GÓC PICTUREBOX
        // =========================================================

        private void BoGocPictureBox(
            PictureBox pic,
            int radius)
        {
            if (pic.Width <= radius ||
                pic.Height <= radius)
                return;

            GraphicsPath path =
                new GraphicsPath();

            path.AddArc(
                0,
                0,
                radius,
                radius,
                180,
                90);

            path.AddArc(
                pic.Width - radius,
                0,
                radius,
                radius,
                270,
                90);

            path.AddArc(
                pic.Width - radius,
                pic.Height - radius,
                radius,
                radius,
                0,
                90);

            path.AddArc(
                0,
                pic.Height - radius,
                radius,
                radius,
                90,
                90);

            path.CloseFigure();

            pic.Region =
                new Region(path);
        }

        private void BoTatCaPictureBox(
            Control parent)
        {
            foreach (Control control
                in parent.Controls)
            {
                if (control is PictureBox pic)
                {
                    BoGocPictureBox(
                        pic,
                        20);
                }

                if (control.HasChildren)
                {
                    BoTatCaPictureBox(
                        control);
                }
            }
        }

        // =========================================================
        // EVENT CŨ - GIỮ ĐỂ DESIGNER KHÔNG LỖI
        // =========================================================

        private void tấtCảToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
        }

        private void baloToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
        }

        private void panel1_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void label3_Click(
            object sender,
            EventArgs e)
        {
        }

        private void pictureBox15_Click(
            object sender,
            EventArgs e)
        {
        }

        private void label14_Click(
            object sender,
            EventArgs e)
        {
        }

        private void thôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanelTaiKhoan();
        }
        // =========================================================
        // ĐỒNG BỘ CARD CLONE VỚI CSDL
        // =========================================================

        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        private int LayMaSPTheoTen(string tenSP, int maSPCu)
        {
            try
            {
                string sql = @"
                    SELECT TOP 1 MaSP
                    FROM SanPham
                    WHERE TenSP = @TenSP
                      AND TrangThai = 1
                    ORDER BY MaSP";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@TenSP", tenSP)
                };

                DataTable dt = kt.GetData(sql, parameters);

                if (dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0]["MaSP"]);

                return 0;
            }
            catch
            {
                // Nếu CSDL chưa sẵn sàng, vẫn cho form mở để không làm vỡ UI.
                return 0;
            }
        }

        private Image LayAnhChinhTheoMaSP(int maSP, Image anhMacDinh)
        {
            if (maSP <= 0)
                return anhMacDinh;

            try
            {
                string sql = @"
                    SELECT TOP 1 UrlAnh
                    FROM HinhAnhSanPham
                    WHERE MaSP = @MaSP
                      AND AnhChinh = 1
                    ORDER BY MaAnh";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaSP", maSP)
                };

                DataTable dt = kt.GetData(sql, parameters);

                if (dt.Rows.Count == 0)
                    return anhMacDinh;

                string urlAnh = dt.Rows[0]["UrlAnh"]?.ToString();

                if (string.IsNullOrWhiteSpace(urlAnh))
                    return anhMacDinh;

                string duongDan = urlAnh.Replace("/", Path.DirectorySeparatorChar.ToString());

                if (!Path.IsPathRooted(duongDan))
                    duongDan = Path.Combine(Application.StartupPath, duongDan);

                if (!File.Exists(duongDan))
                    return anhMacDinh;

                using (Image temp = Image.FromFile(duongDan))
                {
                    return new Bitmap(temp);
                }
            }
            catch
            {
                return anhMacDinh;
            }
        }

        private void giỏHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Giohang formGioHang = new Giohang();
            formGioHang.ShowDialog();
        }
    }

    // =============================================================
    // MENU RENDERER
    // =============================================================

    public class ModernMenuRenderer :
        ToolStripProfessionalRenderer
    {
        public ModernMenuRenderer()
            : base(new ModernMenuColorTable())
        {
        }

        protected override void OnRenderItemText(
            ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item.Selected)
                e.TextColor = Color.White;
            else if (e.Item.OwnerItem != null)
                e.TextColor = Color.FromArgb(35, 35, 35);
            else
                e.TextColor = Color.White;

            base.OnRenderItemText(e);
        }
    }

    public class ModernMenuColorTable :
        ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get
            {
                return Color.FromArgb(
                    220,
                    30,
                    45);
            }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return Color.FromArgb(
                    220,
                    30,
                    45);
            }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return Color.FromArgb(
                    180,
                    20,
                    35);
            }
        }

        public override Color ToolStripDropDownBackground
        {
            get
            {
                return Color.White;
            }
        }

        public override Color MenuBorder
        {
            get
            {
                return Color.FromArgb(220, 220, 220);
            }
        }

        public override Color MenuItemBorder
        {
            get
            {
                return Color.Transparent;
            }
        }


    }
}
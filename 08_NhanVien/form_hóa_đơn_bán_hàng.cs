using SPORTSHOP._06_BanHang;
using SPORTSHOP._07_KhachHang;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class form_hóa_đơn_bán_hàng : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        private int maHoaDonHienTai = 0;
        private int maKhachHangHienTai = 0;
        private int maNhanVienHienTai = 0;
        private int maCaHienTai = 0;
        private decimal tongTienHang = 0;
        private decimal giamGia = 0;
        private decimal tongThanhToan = 0;

        private Button btn_ThoatTrang;

        public form_hóa_đơn_bán_hàng()
        {
            InitializeComponent();
            CauHinhForm();
        }

        public form_hóa_đơn_bán_hàng(int maKH)
        {
            InitializeComponent();
            CauHinhForm();
            maKhachHangHienTai = maKH;
        }

        private void CauHinhForm()
        {
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            cmb_PhuongThuc.SelectedIndex = 0;
            TaoThanhTieuDe();
            CauHinhGiaoDienTheoMenu();

            dgv_ChiTietHoaDon.CellContentClick += dgv_ChiTietHoaDon_CellContentClick;
            btn_TimKhachHang.Click += btn_TimKhachHang_Click;
            btn_ThemSanPham.Click += btn_ThemSanPham_Click;
            btn_XoaSanPham.Click += btn_XoaSanPham_Click;
            btn_SuaSoLuong.Click += btn_SuaSoLuong_Click;
            btn_TaoHoaDon.Click += btn_TaoHoaDon_Click;
            btn_ThanhToan.Click += btn_ThanhToan_Click;
            btn_InHoaDon.Click += btn_InHoaDon_Click;
            btn_menu.Click += btn_menu_Click;
            btn_Voucher.Click += btn_Voucher_Click;
            cmb_PhuongThuc.SelectedIndexChanged += cmb_PhuongThuc_SelectedIndexChanged;
        }

        private void TaoThanhTieuDe()
        {
            // Nút thoát đồng bộ với phong cách menu, đặt cạnh nút MENU.
            btn_ThoatTrang = new Button
            {
                Name = "btn_ThoatTrang",
                Text = "✕  THOÁT",
                BackColor = Color.FromArgb(220, 30, 45),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                Size = new Size(112, 40),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Cursor = Cursors.Hand
            };

            btn_ThoatTrang.FlatAppearance.BorderSize = 0;
            btn_ThoatTrang.Click += (sender, e) => Close();

            Controls.Add(btn_ThoatTrang);
            btn_ThoatTrang.BringToFront();

            btn_menu.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            Resize += (sender, e) => BoTriNutGocPhai();
            BoTriNutGocPhai();
        }

        private void BoTriNutGocPhai()
        {
            if (btn_ThoatTrang == null)
                return;

            btn_menu.Left = ClientSize.Width - btn_menu.Width - 24;
            btn_menu.Top = 5;

            btn_ThoatTrang.Left =
                btn_menu.Left - btn_ThoatTrang.Width - 8;
            btn_ThoatTrang.Top = 12;
        }

        private void CauHinhGiaoDienTheoMenu()
        {
            BackColor = Color.FromArgb(10, 10, 12);

            Color panelColor = Color.FromArgb(28, 28, 31);
            Color inputColor = Color.FromArgb(22, 22, 25);
            Color red = Color.FromArgb(220, 30, 45);

            pnl_ThongTin.BackColor = panelColor;
            pnl_ChiTietHoaDon.BackColor = panelColor;
            pnl_ghichu.BackColor = panelColor;
            pnl_TongTien.BackColor = panelColor;

            foreach (Control parent in new Control[]
            {
                pnl_ThongTin,
                pnl_ChiTietHoaDon,
                pnl_ghichu,
                pnl_TongTien
            })
            {
                foreach (Control child in parent.Controls)
                {
                    if (child is TextBox)
                    {
                        TextBox tb = (TextBox)child;
                        tb.BackColor = inputColor;
                        tb.ForeColor = Color.White;
                    }
                    else if (child is RichTextBox)
                    {
                        RichTextBox rt = (RichTextBox)child;
                        rt.BackColor = inputColor;
                        rt.ForeColor = Color.White;
                    }
                    else if (child is Label)
                    {
                        child.ForeColor = Color.White;
                    }
                }
            }

            lb_TieuDe.ForeColor = Color.White;
            lb_TieuDe.Font = new Font("Segoe UI", 23F, FontStyle.Bold);

            CauHinhNut(ref btn_TaoHoaDon, red);
            CauHinhNut(ref btn_ThanhToan, red);
            CauHinhNut(ref btn_InHoaDon, Color.FromArgb(55, 55, 60));

            btn_menu.BackColor = Color.FromArgb(35, 35, 38);
            btn_menu.FlatStyle = FlatStyle.Flat;
            btn_menu.FlatAppearance.BorderSize = 0;
            btn_menu.ForeColor = Color.White;
            btn_menu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_menu.Text = "☰  MENU";
            btn_menu.Cursor = Cursors.Hand;
        }

        private void CauHinhNut(ref Button button, Color backColor)
        {
            button.BackColor = backColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }

        private void form_hóa_đơn_bán_hàng_Load(object sender, EventArgs e)
        {
            try
            {
                dtp_NgayLap.Value = DateTime.Now;
                txt_MaHoaDon.Text = "Tự động tạo";
                HienThiNhanVienDangNhapVaCa();
                CapNhatTongTien();

                if (maKhachHangHienTai > 0)
                    LoadKhachHang(maKhachHangHienTai);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể khởi tạo hóa đơn.\n\n" + ex.Message,
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HienThiNhanVienDangNhapVaCa()
        {
            try
            {
                if (Session.MaNV <= 0)
                {
                    maNhanVienHienTai = 0;
                    maCaHienTai = 0;
                    txt_NhanVien.Text = "Chưa đăng nhập";
                    txt_Ca.Text = "Chưa vào ca";
                    return;
                }

                maNhanVienHienTai = Session.MaNV;

                string sql = @"
SELECT TOP 1
    nv.MaNV,
    nv.HoTen,
    c.MaCa,
    c.GioBatDau,
    c.GioKetThuc,
    c.DoanhThu,
    c.SoHoaDon,
    c.TrangThai
FROM NhanVien nv
LEFT JOIN CaLamViec c
    ON c.MaNV = nv.MaNV
    AND c.TrangThai = N'Đang làm'
    AND c.GioKetThuc IS NULL
WHERE nv.MaNV = @MaNV
ORDER BY c.MaCa DESC;";

                DataTable dt = kt.GetData(sql, new SqlParameter[]
                {
                    new SqlParameter("@MaNV", maNhanVienHienTai)
                });

                if (dt.Rows.Count == 0)
                {
                    txt_NhanVien.Text = maNhanVienHienTai + " - Không tìm thấy";
                    txt_Ca.Text = "Chưa vào ca";
                    maCaHienTai = 0;
                    return;
                }

                DataRow r = dt.Rows[0];

                string hoTen = r["HoTen"] == DBNull.Value
                    ? "Nhân viên"
                    : r["HoTen"].ToString();

                txt_NhanVien.Text = maNhanVienHienTai + " - " + hoTen;

                if (r["MaCa"] == DBNull.Value)
                {
                    maCaHienTai = 0;
                    txt_Ca.Text = "CHƯA VÀO CA";
                }
                else
                {
                    maCaHienTai = Convert.ToInt32(r["MaCa"]);

                    DateTime batDau = r["GioBatDau"] == DBNull.Value
                        ? DateTime.MinValue
                        : Convert.ToDateTime(r["GioBatDau"]);

                    txt_Ca.Text = batDau == DateTime.MinValue
                        ? "CA #" + maCaHienTai + " - ĐANG LÀM"
                        : "CA #" + maCaHienTai + " - " + batDau.ToString("HH:mm");
                }
            }
            catch (Exception ex)
            {
                maCaHienTai = 0;
                txt_NhanVien.Text = Session.MaNV > 0
                    ? Session.MaNV.ToString()
                    : "Chưa đăng nhập";
                txt_Ca.Text = "Không xác định";

                MessageBox.Show(
                    "Không thể kiểm tra ca làm việc.\n\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void LoadKhachHang(int maKH)
        {
            try
            {
                string sql = @"
SELECT TOP 1 MaKH, HoTen, SDT
FROM KhachHang
WHERE MaKH=@MaKH";

                DataTable dt = kt.GetData(sql,
                    new SqlParameter[] { new SqlParameter("@MaKH", maKH) });

                if (dt.Rows.Count == 0)
                    return;

                DataRow r = dt.Rows[0];
                maKhachHangHienTai = Convert.ToInt32(r["MaKH"]);
                txt_KhachHang.Text = r["HoTen"] == DBNull.Value ? "" : r["HoTen"].ToString();
                txt_SDT.Text = r["SDT"] == DBNull.Value ? "" : r["SDT"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được khách hàng.\n" + ex.Message,
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_TimKhachHang_Click(object sender, EventArgs e)
        {
            string sdt = txt_SDT.Text.Trim();

            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Nhập số điện thoại khách hàng để tìm.",
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_SDT.Focus();
                return;
            }

            try
            {
                string sql = @"
SELECT TOP 1 MaKH, HoTen, SDT
FROM KhachHang
WHERE SDT=@SDT
ORDER BY MaKH";

                DataTable dt = kt.GetData(sql,
                    new SqlParameter[] { new SqlParameter("@SDT", sdt) });

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng với số điện thoại này.",
                        "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataRow r = dt.Rows[0];
                maKhachHangHienTai = Convert.ToInt32(r["MaKH"]);
                txt_KhachHang.Text = r["HoTen"] == DBNull.Value ? "" : r["HoTen"].ToString();
                txt_SDT.Text = r["SDT"] == DBNull.Value ? "" : r["SDT"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm khách hàng.\n" + ex.Message,
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ThemSanPham_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Hãy chọn sản phẩm từ giao diện bán hàng rồi thêm vào giỏ.\n\n" +
                "Form hóa đơn này giữ vai trò kiểm tra và hoàn tất đơn bán.",
                "SPORTSHOP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btn_XoaSanPham_Click(object sender, EventArgs e)
        {
            if (dgv_ChiTietHoaDon.CurrentRow == null)
                return;

            if (dgv_ChiTietHoaDon.CurrentRow.IsNewRow)
                return;

            DialogResult dr = MessageBox.Show(
                "Bạn có chắc muốn xóa sản phẩm khỏi hóa đơn?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
                return;

            dgv_ChiTietHoaDon.Rows.Remove(dgv_ChiTietHoaDon.CurrentRow);
            CapNhatTongTien();
        }

        private void btn_SuaSoLuong_Click(object sender, EventArgs e)
        {
            if (dgv_ChiTietHoaDon.CurrentRow == null)
                return;

            int row = dgv_ChiTietHoaDon.CurrentRow.Index;
            if (row < 0 || row >= dgv_ChiTietHoaDon.Rows.Count)
                return;

            string oldValue = Convert.ToString(dgv_ChiTietHoaDon.Rows[row].Cells["SoLuong"].Value);
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập số lượng mới:",
                "Sửa số lượng",
                oldValue);

            if (string.IsNullOrWhiteSpace(input))
                return;

            int sl;
            if (!int.TryParse(input, out sl) || sl <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên lớn hơn 0.",
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgv_ChiTietHoaDon.Rows[row].Cells["SoLuong"].Value = sl;

            decimal donGia = LayDecimal(row, "DonGia");
            decimal giam = LayDecimal(row, "GiamGia");
            dgv_ChiTietHoaDon.Rows[row].Cells["ThanhTien"].Value =
                ((donGia * sl) - giam).ToString("N0");

            CapNhatTongTien();
        }

        private void dgv_ChiTietHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgv_ChiTietHoaDon.Columns["Sua"].Index)
                btn_SuaSoLuong_Click(sender, EventArgs.Empty);
            else if (e.ColumnIndex == dgv_ChiTietHoaDon.Columns["Xoa"].Index)
                btn_XoaSanPham_Click(sender, EventArgs.Empty);
        }

        private decimal LayDecimal(int row, string column)
        {
            object value = dgv_ChiTietHoaDon.Rows[row].Cells[column].Value;
            decimal result;
            return decimal.TryParse(Convert.ToString(value), out result) ? result : 0;
        }

        private void CapNhatTongTien()
        {
            tongTienHang = 0;

            foreach (DataGridViewRow r in dgv_ChiTietHoaDon.Rows)
            {
                if (r.IsNewRow)
                    continue;

                int sl = 0;
                int.TryParse(Convert.ToString(r.Cells["SoLuong"].Value), out sl);

                decimal gia = LayDecimal(r.Index, "DonGia");
                decimal giam = LayDecimal(r.Index, "GiamGia");

                decimal thanhTien = gia * sl - giam;
                if (thanhTien < 0)
                    thanhTien = 0;

                r.Cells["ThanhTien"].Value = thanhTien.ToString("N0");
                tongTienHang += thanhTien;
            }

            if (giamGia > tongTienHang)
                giamGia = tongTienHang;

            tongThanhToan = tongTienHang - giamGia;

            lb_TongTienHang.Text = tongTienHang.ToString("N0") + " VNĐ";
            lb_GiamGia.Text = giamGia.ToString("N0") + " VNĐ";
            lb_ThanhToan.Text = tongThanhToan.ToString("N0") + " VNĐ";
        }

        private void cmb_PhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_PhuongThuc.SelectedItem != null)
                lb_PhuongThuc.Text = "💰 Thanh toán: " + cmb_PhuongThuc.SelectedItem.ToString();
        }

        private void btn_Voucher_Click(object sender, EventArgs e)
        {
            using (FormQuanLyVoucher f = new FormQuanLyVoucher())
            {
                f.ShowDialog(this);
            }
        }


        private void btn_TaoHoaDon_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieuHoaDon())
                return;

            try
            {
                maHoaDonHienTai = TaoHoaDon(false);
                txt_MaHoaDon.Text = maHoaDonHienTai.ToString();

                MessageBox.Show(
                    "Đã tạo hóa đơn #" + maHoaDonHienTai + ".",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tạo hóa đơn.\n\n" + ex.Message,
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieuHoaDon())
                return;

            try
            {
                if (maHoaDonHienTai <= 0)
                    maHoaDonHienTai = TaoHoaDon(false);

                // Form thanh toán online riêng sẽ xử lý DonOnline.
                // Hóa đơn bán tại quầy được ghi nhận tại đây.
                GhiNhanThanhToan();

                MessageBox.Show(
                    "Thanh toán thành công!\nMã hóa đơn: #" + maHoaDonHienTai +
                    "\nTổng tiền: " + tongThanhToan.ToString("N0") + " VNĐ",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thanh toán không thành công.\n\n" + ex.Message,
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool KiemTraDuLieuHoaDon()
        {
            // Nhân viên phải đăng nhập và đang có ca Đang làm.
            HienThiNhanVienDangNhapVaCa();

            if (maNhanVienHienTai <= 0 || maCaHienTai <= 0)
            {
                MessageBox.Show(
                    "Nhân viên chưa vào ca hoặc ca đã kết thúc.\nKhông thể lập/thanh toán hóa đơn.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (maKhachHangHienTai <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.",
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgv_ChiTietHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn chưa có sản phẩm.",
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (tongThanhToan <= 0)
            {
                MessageBox.Show("Tổng thanh toán phải lớn hơn 0.",
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private int TaoHoaDon(bool daThanhToan)
        {
            // Tạo hóa đơn tối thiểu theo các trường đang dùng trong project.
            // Nếu database có thêm cột bắt buộc, SQL Server sẽ trả thông báo cụ thể.
            string sql = @"
INSERT INTO HoaDon(MaKH, MaNV, NgayLap, TongTien)
OUTPUT INSERTED.MaHD
VALUES(@MaKH, @MaNV, @NgayLap, @TongTien);";

            int maNV = maNhanVienHienTai;

            if (maNV <= 0)
                throw new Exception("Nhân viên chưa đăng nhập.");

            DataTable dt = kt.GetData(sql, new SqlParameter[]
            {
                new SqlParameter("@MaKH", maKhachHangHienTai),
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@NgayLap", dtp_NgayLap.Value),
                new SqlParameter("@TongTien", tongThanhToan)
            });

            if (dt.Rows.Count == 0)
                throw new Exception("Không nhận được mã hóa đơn mới.");

            int maHD = Convert.ToInt32(dt.Rows[0]["MaHD"]);
            txt_MaHoaDon.Text = maHD.ToString();

            LuuChiTietHoaDon(maHD);

            return maHD;
        }

        private void LuuChiTietHoaDon(int maHD)
        {
            foreach (DataGridViewRow r in dgv_ChiTietHoaDon.Rows)
            {
                if (r.IsNewRow)
                    continue;

                int maSP;
                int sl;

                if (!int.TryParse(Convert.ToString(r.Cells["MaSP"].Value), out maSP))
                    continue;

                if (!int.TryParse(Convert.ToString(r.Cells["SoLuong"].Value), out sl) || sl <= 0)
                    continue;

                decimal gia = LayDecimal(r.Index, "DonGia");
                decimal giam = LayDecimal(r.Index, "GiamGia");

                string sql = @"
INSERT INTO ChiTietHoaDon(MaHD, MaSP, SoLuong, DonGia, GiamGia)
VALUES(@MaHD, @MaSP, @SoLuong, @DonGia, @GiamGia);";

                kt.Execute(sql, new SqlParameter[]
                {
                    new SqlParameter("@MaHD", maHD),
                    new SqlParameter("@MaSP", maSP),
                    new SqlParameter("@SoLuong", sl),
                    new SqlParameter("@DonGia", gia),
                    new SqlParameter("@GiamGia", giam)
                });
            }
        }

        private void GhiNhanThanhToan()
        {
            string phuongThuc = cmb_PhuongThuc.SelectedItem == null
                ? "Tiền mặt"
                : cmb_PhuongThuc.SelectedItem.ToString();

            // Không tạo bản ghi thanh toán trùng nếu nút được bấm lại.
            string checkSql = "SELECT COUNT(*) FROM ThanhToan WHERE MaHD=@MaHD";
            DataTable check = kt.GetData(checkSql,
                new SqlParameter[] { new SqlParameter("@MaHD", maHoaDonHienTai) });

            int daCo = check.Rows.Count > 0 ? Convert.ToInt32(check.Rows[0][0]) : 0;

            if (daCo == 0)
            {
                string sql = @"
INSERT INTO ThanhToan(MaHD, PhuongThucThanhToan, SoTien, NgayThanhToan)
VALUES(@MaHD, @PhuongThuc, @SoTien, GETDATE());";

                kt.Execute(sql, new SqlParameter[]
                {
                    new SqlParameter("@MaHD", maHoaDonHienTai),
                    new SqlParameter("@PhuongThuc", phuongThuc),
                    new SqlParameter("@SoTien", tongThanhToan)
                });
            }
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            using (FormMenuNV menu = new FormMenuNV())
            {
                if (menu.ShowDialog(this) == DialogResult.OK)
                {
                    if (menu.YeuCauDangXuat)
                    {
                        // Đóng màn hình bán hàng để quay về màn hình đăng nhập/main.
                        this.Close();
                        return;
                    }

                    if (menu.YeuCauKhoaManHinh)
                    {
                        MoManHinhKhoa();
                    }
                }
            }
        }

        private void MoManHinhKhoa()
        {
            // Giữ form bán hàng ẩn trong lúc khóa để không có cửa sổ bán hàng
            // nằm phía sau màn hình khóa. Sau khi đăng nhập ID thành công,
            // mở một phiên Form Hóa Đơn mới với trạng thái full màn hình.
            this.Hide();

            DialogResult ketQua;
            using (FormManHinhKhoa frm = new FormManHinhKhoa(this))
            {
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.FormBorderStyle = FormBorderStyle.None;
                ketQua = frm.ShowDialog();
            }

            if (ketQua == DialogResult.OK)
            {
                using (form_hóa_đơn_bán_hàng formMoi = new form_hóa_đơn_bán_hàng())
                {
                    formMoi.WindowState = FormWindowState.Maximized;
                    formMoi.FormBorderStyle = FormBorderStyle.None;
                    formMoi.ShowDialog();
                }

                // Phiên cũ không dùng lại nữa.
                Close();
                return;
            }

            // Nếu đóng màn hình khóa mà chưa đăng nhập thì quay lại phiên bán hàng.
            Show();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            Activate();
        }

        private void btn_InHoaDon_Click(object sender, EventArgs e)
        {
            if (maHoaDonHienTai <= 0)
            {
                MessageBox.Show("Chưa có hóa đơn để in.",
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (FormChiTietHoaDon f = new FormChiTietHoaDon(maHoaDonHienTai))
                {
                    f.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở chi tiết hóa đơn.\n" + ex.Message,
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}

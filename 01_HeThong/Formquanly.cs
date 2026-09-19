using SPORTSHOP._03_QuanLyKho;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SPORTSHOP
{
    /// <summary>
    /// Giao diện dành cho QUẢN LÝ.
    /// Có đầy đủ nghiệp vụ kinh doanh: sản phẩm, kho, bán hàng,
    /// nhà cung cấp và báo cáo.
    /// Có thêm nhóm Hệ thống dành riêng cho Admin: quản lý tài khoản,
    /// lịch sử đăng nhập và quản lý chấm công.
    /// </summary>
    public partial class FormQuanLy : Form
    {
        public TaiKhoan tk;

        private KetNoiDuLieu kt = new KetNoiDuLieu();

        private Form formHienTai = null;

        private List<Control> controlsTongQuan = new List<Control>();

        private DataTable bangSanPham = null;

        public FormQuanLy(TaiKhoan tk)
        {
            InitializeComponent();

            this.tk = tk;

            CauHinhQuyenAdmin();

            controlsTongQuan.AddRange(
                panel1.Controls.Cast<Control>().ToArray());

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            panel1.Dock = DockStyle.Fill;

            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            LoadThongKe();
            LoadDanhSachSanPham();
        }

        private void FormQuanLy_Load(object sender, EventArgs e)
        {
        }

        // =========================================================
        // THỐNG KÊ
        // =========================================================

        private void LoadThongKe()
        {
            try
            {
                object doanhThu = kt.ExecuteScalar(
                    "SELECT ISNULL(SUM(TongTien), 0) FROM HoaDon");

                lbDoanhThu.Text =
                    Convert.ToDecimal(doanhThu).ToString("N0") + " đ";

                object donHang = kt.ExecuteScalar(@"
                    SELECT COUNT(*)
                    FROM HoaDon
                    WHERE CAST(NgayLap AS DATE) = CAST(GETDATE() AS DATE)");

                lbDonHang.Text =
                    Convert.ToInt32(donHang) + " đơn";

                object sanPham = kt.ExecuteScalar(@"
                    SELECT COUNT(*)
                    FROM SanPham
                    WHERE TrangThai = 1");

                lbSanPham.Text =
                    Convert.ToInt32(sanPham) + " sản phẩm";

                object tonKho = kt.ExecuteScalar(
                    "SELECT ISNULL(SUM(SLTon), 0) FROM TonKho");

                lbTonKho.Text =
                    Convert.ToInt32(tonKho).ToString("N0") + " sản phẩm";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải thống kê.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // DANH SÁCH SẢN PHẨM
        // =========================================================

        private void LoadDanhSachSanPham()
        {
            try
            {
                string sql = @"
                    SELECT
                        sp.MaSP,
                        sp.TenSP,
                        dm.TenDanhMuc,
                        th.TenThuongHieu,
                        CASE
                            WHEN sp.TrangThai = 1 THEN N'Đang hoạt động'
                            ELSE N'Ngừng hoạt động'
                        END AS TrangThai,
                        sp.NgayTao
                    FROM SanPham sp
                    INNER JOIN DanhMuc dm
                        ON dm.MaDM = sp.MaDM
                    INNER JOIN ThuongHieu th
                        ON th.MaTH = sp.MaTH
                    ORDER BY sp.MaSP DESC";

                bangSanPham = kt.GetData(sql);

                dgv_ql.DataSource = bangSanPham;

                DatTieuDeCot("MaSP", "Mã SP");
                DatTieuDeCot("TenSP", "Tên sản phẩm");
                DatTieuDeCot("TenDanhMuc", "Danh mục");
                DatTieuDeCot("TenThuongHieu", "Thương hiệu");
                DatTieuDeCot("TrangThai", "Trạng thái");

                if (dgv_ql.Columns["NgayTao"] != null)
                {
                    dgv_ql.Columns["NgayTao"].HeaderText = "Ngày tạo";

                    dgv_ql.Columns["NgayTao"].DefaultCellStyle.Format =
                        "dd/MM/yyyy";
                }

                dgv_ql.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgv_ql.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgv_ql.MultiSelect = false;
                dgv_ql.ReadOnly = true;
                dgv_ql.AllowUserToAddRows = false;

                ApDungTimKiem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách sản phẩm.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DatTieuDeCot(string tenCot, string tieuDe)
        {
            if (dgv_ql.Columns[tenCot] != null)
                dgv_ql.Columns[tenCot].HeaderText = tieuDe;
        }

        // =========================================================
        // TÌM KIẾM
        // =========================================================

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            ApDungTimKiem();
        }

        private void ApDungTimKiem()
        {
            if (bangSanPham == null)
                return;

            string tuKhoa = txtTimKiem.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(tuKhoa))
            {
                bangSanPham.DefaultView.RowFilter = "";
                return;
            }

            bangSanPham.DefaultView.RowFilter =
                "TenSP LIKE '%" + tuKhoa + "%'"
                + " OR TenDanhMuc LIKE '%" + tuKhoa + "%'"
                + " OR TenThuongHieu LIKE '%" + tuKhoa + "%'";
        }

        // =========================================================
        // QUYỀN ADMIN
        // =========================================================

        private void CauHinhQuyenAdmin()
        {
            bool laAdmin = Session.MaVaiTro == PhanQuyen.ADMIN;

            btn_admin.Visible = laAdmin;

            if (!laAdmin)
            {
                panelMenuAdmin.Visible = false;
            }
            else
            {
                lbVaiTro.Text = "Quản lý / Admin";
            }
        }

        private void btn_admin_Click(object sender, EventArgs e)
        {
            if (Session.MaVaiTro != PhanQuyen.ADMIN)
                return;

            MoDongMenu(panelMenuAdmin);
        }

        private void btn_qltaikhoan_Click(object sender, EventArgs e)
        {
            if (Session.MaVaiTro != PhanQuyen.ADMIN)
                return;

            MoFormTrongPanel(new FormQLTK());
        }

        private void btn_lichsudangnhap_Click(object sender, EventArgs e)
        {
            if (Session.MaVaiTro != PhanQuyen.ADMIN)
                return;

            MoFormTheoTen("SPORTSHOP.FormLichSuDangNhap", "Lịch sử đăng nhập");
        }

        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            if (Session.MaVaiTro != PhanQuyen.ADMIN)
                return;

            MoFormTheoTen("SPORTSHOP._08_NhanSu.FormQuanLyChamCong", "Quản lý chấm công");
        }

        private void MoFormTheoTen(string tenDayDu, string tenHienThi)
        {
            try
            {
                Type type = Type.GetType(tenDayDu);

                if (type == null)
                {
                    ChuaPhatTrien(tenHienThi);
                    return;
                }

                Form form = Activator.CreateInstance(type) as Form;

                if (form == null)
                {
                    ChuaPhatTrien(tenHienThi);
                    return;
                }

                MoFormTrongPanel(form);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở " + tenHienThi + ".\n\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // MENU BÊN TRÁI
        // =========================================================

        private void DongTatCaMenu()
        {
            panelMenuSanPham.Visible = false;
            panelMenuKho.Visible = false;
            PanelMenuBanHang.Visible = false;
            PanelMenuNCC.Visible = false;
            panelMenuBaoCao.Visible = false;
            panelMenuAdmin.Visible = false;
        }

        private void MoDongMenu(Guna.UI2.WinForms.Guna2Panel menu)
        {
            bool dangMo = menu.Visible;

            DongTatCaMenu();

            menu.Visible = !dangMo;

            if (menu.Visible)
                menu.BringToFront();
        }

        private void btn_sanpham_Click(object sender, EventArgs e)
        {
            MoDongMenu(panelMenuSanPham);
        }

        private void btn_kho_Click(object sender, EventArgs e)
        {
            MoDongMenu(panelMenuKho);
        }

        private void btn_banhangcha_Click(object sender, EventArgs e)
        {
            MoDongMenu(PanelMenuBanHang);
        }

        private void btn_nhacungcap_Click(object sender, EventArgs e)
        {
            MoDongMenu(PanelMenuNCC);
        }

        private void btn_baocao_Click(object sender, EventArgs e)
        {
            MoDongMenu(panelMenuBaoCao);
        }

        private void btn_tongquan_Click(object sender, EventArgs e)
        {
            DongTatCaMenu();

            if (formHienTai != null)
            {
                formHienTai.Close();
                formHienTai.Dispose();
                formHienTai = null;
            }

            panel1.Controls.Clear();
            panel1.Controls.AddRange(controlsTongQuan.ToArray());

            LoadThongKe();
            LoadDanhSachSanPham();
        }

        // =========================================================
        // MỞ FORM CON TRONG PANEL
        // =========================================================

        private void MoFormTrongPanel(Form form)
        {
            DongTatCaMenu();

            if (formHienTai != null)
            {
                formHienTai.Close();
                formHienTai.Dispose();
                formHienTai = null;
            }

            panel1.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.AutoSize = false;
            form.AutoScroll = true;
            form.Margin = new Padding(0);
            form.Padding = new Padding(0);

            panel1.Controls.Add(form);

            formHienTai = form;

            form.BringToFront();
            form.Show();
        }

        private void ChuaPhatTrien(string tenChucNang)
        {
            DongTatCaMenu();

            MessageBox.Show(
                "Chức năng \"" + tenChucNang + "\" đang được phát triển.",
                "SPORTSHOP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================
        // MENU SẢN PHẨM
        // =========================================================

        private void btn_sp_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new Quản_lí_sản_phẩm_FormSanPham());
        }

        private void btn_danhmuc1_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormDanhMuc());
        }

        private void btn_size_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormSize());
        }

        private void btn_mausac_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormMauSac());
        }

        private void btn_thuonghieu_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormThuongHieu());
        }

        // =========================================================
        // MENU KHO
        // =========================================================

        private void btn_quanlykho_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FromKho());
        }

        private void btn_tonkho_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormTonKho());
        }

        private void btn_lichsuton_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormLStonkho());
        }

        private void btn_nhaphang_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormNhapHang());
        }

        private void btn_phieunhap_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FrmPhieuNhap());
        }

        private void btn_phieukho_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FrmPhieuKho());
        }

        // =========================================================
        // MENU BÁN HÀNG
        // =========================================================

        private void btn_banhang_Click(object sender, EventArgs e)
        {
            DongTatCaMenu();

            formgiaodienbanhang form = new formgiaodienbanhang();

            form.ShowDialog(this);
        }

        private void btn_donhang_Click(object sender, EventArgs e)
        {
            // Khi module đơn hàng hoàn thiện, thay dòng này bằng:
            // MoFormTrongPanel(new FormDonHang());
            ChuaPhatTrien("Đơn hàng");
        }

        private void btn_khachhang_Click(object sender, EventArgs e)
        {
            // Khi có form danh sách khách hàng, thay dòng này bằng:
            // MoFormTrongPanel(new FormHoiVien());
            ChuaPhatTrien("Khách hàng");
        }

        // =========================================================
        // MENU NHÀ CUNG CẤP
        // =========================================================

        private void btn_NCC_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormNhaCungCap());
        }

        private void btn_themNCC_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormThemNhaCungCap());
        }

        // =========================================================
        // MENU BÁO CÁO
        // =========================================================

        private void btn_doanhthu_Click(object sender, EventArgs e)
        {
            // Khi có form báo cáo doanh thu, thay dòng này bằng:
            // MoFormTrongPanel(new FormBaoCaoDoanhThu());
            ChuaPhatTrien("Báo cáo doanh thu");
        }

        // =========================================================
        // THAO TÁC TRÊN LƯỚI SẢN PHẨM
        // =========================================================

        private void btn_them_Click(object sender, EventArgs e)
        {
            Quản_lí_sản_phẩm_FormSanPham form =
                new Quản_lí_sản_phẩm_FormSanPham();

            form.ShowDialog();

            LoadDanhSachSanPham();
            LoadThongKe();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (dgv_ql.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần sửa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int maSP = Convert.ToInt32(
                dgv_ql.CurrentRow.Cells["MaSP"].Value);

            Quản_lí_sản_phẩm_FormSanPham form =
                new Quản_lí_sản_phẩm_FormSanPham(maSP);

            form.ShowDialog();

            LoadDanhSachSanPham();
            LoadThongKe();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_ql.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int maSP = Convert.ToInt32(
                dgv_ql.CurrentRow.Cells["MaSP"].Value);

            string tenSP =
                dgv_ql.CurrentRow.Cells["TenSP"].Value.ToString();

            DialogResult result = MessageBox.Show(
                "Bạn có muốn chuyển sản phẩm:\n\n"
                + tenSP
                + "\n\nsang trạng thái Ngừng hoạt động không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                string sql = @"
                    UPDATE SanPham
                    SET TrangThai = 0
                    WHERE MaSP = @MaSP";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaSP", maSP)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show(
                    "Sản phẩm đã chuyển sang Ngừng hoạt động.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadDanhSachSanPham();
                LoadThongKe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể cập nhật trạng thái sản phẩm.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_xemct_Click(object sender, EventArgs e)
        {
            if (dgv_ql.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int maSP = Convert.ToInt32(
                dgv_ql.CurrentRow.Cells["MaSP"].Value);

            MoFormTrongPanel(new FormChiTietSanPham1(maSP));
        }

        // =========================================================
        // ĐĂNG XUẤT
        // =========================================================

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất không?",
                "Đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                string sql = @"
                    UPDATE LichSuDangNhap
                    SET ThoiGianRa = GETDATE()
                    WHERE MaTK = @MaTK
                      AND ThoiGianRa IS NULL";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaTK", Session.MaTK)
                };

                kt.Execute(sql, parameters);

                Session.DangXuat();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi ghi nhận thời gian đăng xuất:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
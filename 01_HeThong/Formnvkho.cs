using SPORTSHOP._03_QuanLyKho;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SPORTSHOP
{
    /// <summary>
    /// Giao diện dành cho NHÂN VIÊN KHO.
    /// Chỉ gồm các nghiệp vụ kho: tồn kho, nhập hàng, phiếu nhập,
    /// phiếu kho, lịch sử tồn và nhà cung cấp.
    /// Không có quản lý tài khoản, bán hàng hay báo cáo doanh thu.
    /// </summary>
    public partial class FormNVKho : Form
    {
        public TaiKhoan tk;

        private KetNoiDuLieu kt = new KetNoiDuLieu();

        private Form formHienTai = null;

        private List<Control> controlsTongQuan = new List<Control>();

        private DataTable bangTonKho = null;

        public FormNVKho(TaiKhoan tk)
        {
            InitializeComponent();

            this.tk = tk;

            controlsTongQuan.AddRange(
                panel1.Controls.Cast<Control>().ToArray());

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            panel1.Dock = DockStyle.Fill;

            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            LoadThongKe();
            LoadDanhSachTonKho();
            TaoNutChamCong();
            TaoNutChucNangKhoMoi();
        }

        private void FormNVKho_Load(object sender, EventArgs e)
        {
        }

        // =========================================================
        // THỐNG KÊ
        // =========================================================

        private void LoadThongKe()
        {
            lbTongSanPham.Text =
                DocSo("SELECT COUNT(*) FROM SanPham WHERE TrangThai = 1")
                + " sản phẩm";

            lbTongTonKho.Text =
                DocSo("SELECT ISNULL(SUM(SLTon), 0) FROM TonKho")
                + " sản phẩm";

            lbSapHet.Text =
                DocSo(@"SELECT COUNT(*)
                        FROM TonKho
                        WHERE SLTon > 0
                          AND SLTon <= SLToiThieu")
                + " mục";

            lbTongNCC.Text =
                DocSo("SELECT COUNT(*) FROM NhaCungCap")
                + " đơn vị";
        }

        /// <summary>
        /// Đọc một con số từ CSDL. Nếu câu lệnh lỗi (bảng/cột chưa có)
        /// thì trả về "--" thay vì làm hỏng cả màn hình tổng quan.
        /// </summary>
        private string DocSo(string sql)
        {
            try
            {
                object kq = kt.ExecuteScalar(sql);

                if (kq == null || kq == DBNull.Value)
                    return "0";

                return Convert.ToDecimal(kq).ToString("N0");
            }
            catch
            {
                return "--";
            }
        }

        // =========================================================
        // DANH SÁCH TỒN KHO
        // =========================================================

        private void LoadDanhSachTonKho()
        {
            // Câu lệnh chính: sản phẩm kèm tổng tồn kho.
            // Nếu bảng TonKho của bạn không liên kết trực tiếp qua MaSP,
            // chỉ cần sửa đúng một dòng subquery bên dưới.
            string sqlKemTon = @"
                SELECT
                    sp.MaSP,
                    sp.TenSP,
                    dm.TenDanhMuc,
                    th.TenThuongHieu,
                    ISNULL((
                        SELECT SUM(t.SLTon)
                        FROM TonKho t
                        INNER JOIN BienTheSanPham bt
                            ON bt.MaBienThe = t.MaBienThe
                        WHERE bt.MaSP = sp.MaSP
                    ), 0) AS SLTon,
                    CASE
                        WHEN sp.TrangThai = 1 THEN N'Đang hoạt động'
                        ELSE N'Ngừng hoạt động'
                    END AS TrangThai
                FROM SanPham sp
                INNER JOIN DanhMuc dm
                    ON dm.MaDM = sp.MaDM
                INNER JOIN ThuongHieu th
                    ON th.MaTH = sp.MaTH
                ORDER BY sp.MaSP DESC";

            // Phương án dự phòng nếu không lấy được cột tồn kho
            string sqlDuPhong = @"
                SELECT
                    sp.MaSP,
                    sp.TenSP,
                    dm.TenDanhMuc,
                    th.TenThuongHieu,
                    CASE
                        WHEN sp.TrangThai = 1 THEN N'Đang hoạt động'
                        ELSE N'Ngừng hoạt động'
                    END AS TrangThai
                FROM SanPham sp
                INNER JOIN DanhMuc dm
                    ON dm.MaDM = sp.MaDM
                INNER JOIN ThuongHieu th
                    ON th.MaTH = sp.MaTH
                ORDER BY sp.MaSP DESC";

            try
            {
                try
                {
                    bangTonKho = kt.GetData(sqlKemTon);
                }
                catch
                {
                    bangTonKho = kt.GetData(sqlDuPhong);
                }

                dgv_kho.DataSource = bangTonKho;

                DinhDangLuoi();

                ApDungTimKiem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách tồn kho.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DinhDangLuoi()
        {
            if (dgv_kho.Columns.Count == 0)
                return;

            DatTieuDeCot("MaSP", "Mã SP");
            DatTieuDeCot("TenSP", "Tên sản phẩm");
            DatTieuDeCot("TenDanhMuc", "Danh mục");
            DatTieuDeCot("TenThuongHieu", "Thương hiệu");
            DatTieuDeCot("SLTon", "Tồn kho");
            DatTieuDeCot("TrangThai", "Trạng thái");

            if (dgv_kho.Columns["SLTon"] != null)
            {
                dgv_kho.Columns["SLTon"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

                dgv_kho.Columns["SLTon"].DefaultCellStyle.Format = "N0";
            }

            dgv_kho.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv_kho.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv_kho.MultiSelect = false;
            dgv_kho.ReadOnly = true;
            dgv_kho.AllowUserToAddRows = false;
        }

        private void DatTieuDeCot(string tenCot, string tieuDe)
        {
            if (dgv_kho.Columns[tenCot] != null)
                dgv_kho.Columns[tenCot].HeaderText = tieuDe;
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
            if (bangTonKho == null)
                return;

            string tuKhoa = txtTimKiem.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(tuKhoa))
            {
                bangTonKho.DefaultView.RowFilter = "";
                return;
            }

            bangTonKho.DefaultView.RowFilter =
                "TenSP LIKE '%" + tuKhoa + "%'"
                + " OR TenDanhMuc LIKE '%" + tuKhoa + "%'"
                + " OR TenThuongHieu LIKE '%" + tuKhoa + "%'";
        }

        // =========================================================
        // MENU BÊN TRÁI
        // =========================================================

        private void DongTatCaMenu()
        {
            panelMenuKho.Visible = false;
            PanelMenuNCC.Visible = false;
        }

        private void btn_kho_Click(object sender, EventArgs e)
        {
            bool dangMo = panelMenuKho.Visible;

            DongTatCaMenu();

            panelMenuKho.Visible = !dangMo;

            if (panelMenuKho.Visible)
                panelMenuKho.BringToFront();
        }

        private void btn_nhacungcap_Click(object sender, EventArgs e)
        {
            bool dangMo = PanelMenuNCC.Visible;

            DongTatCaMenu();

            PanelMenuNCC.Visible = !dangMo;

            if (PanelMenuNCC.Visible)
                PanelMenuNCC.BringToFront();
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
            LoadDanhSachTonKho();
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

        // =========================================================
        // CÁC CHỨC NĂNG KHO
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
        // NHÀ CUNG CẤP
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
        // THAO TÁC TRÊN LƯỚI
        // =========================================================

        private void btn_xemct_Click(object sender, EventArgs e)
        {
            if (dgv_kho.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần xem chi tiết.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int maSP = Convert.ToInt32(
                dgv_kho.CurrentRow.Cells["MaSP"].Value);

            FormChiTietSanPham1 form =
                new FormChiTietSanPham1(maSP);

            form.ShowDialog();
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            LoadThongKe();
            LoadDanhSachTonKho();
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
        // =========================================================
        // CHẤM CÔNG NHÂN VIÊN KHO
        // =========================================================
        private void TaoNutChamCong()
        {
            var btn = new Guna.UI2.WinForms.Guna2Button();
            btn.BorderRadius = 10;
            btn.FillColor = Color.Transparent;
            btn.FocusedColor = Color.Transparent;
            btn.Font = new Font("Segoe UI", 12F);
            btn.ForeColor = Color.White;
            btn.HoverState.FillColor = Color.FromArgb(40, 52, 70);
            btn.HoverState.ForeColor = Color.White;
            btn.Location = new Point(1, 306);
            btn.Size = new Size(217, 45);
            btn.Text = "🕐 CHẤM CÔNG";
            btn.TextAlign = HorizontalAlignment.Left;
            btn.TextOffset = new Point(10, 0);
            btn.Click += (s, e) =>
            {
                using (Form f = new D(true))
                {
                    f.ShowDialog(this);
                }
            };
            panelSidebar.Controls.Add(btn);
            btn.BringToFront();
        }

        // =========================================================
        // 3 CHỨC NĂNG KHO MỚI - TẠO ĐỘNG
        // Không đặt trong Designer để tránh Visual Studio Designer
        // lỗi khi khởi tạo Guna2Button.
        // =========================================================
        private void TaoNutChucNangKhoMoi()
        {
            if (panelMenuKho == null)
                return;

            // Mở rộng menu kho từ 6 lên 9 chức năng.
            panelMenuKho.Height = 473;

            Guna.UI2.WinForms.Guna2Button btnCanhBao =
                TaoButtonMenuKho(
                    "⚠ Cảnh báo kho",
                    309,
                    btn_canhbao_Click);

            Guna.UI2.WinForms.Guna2Button btnDieuChuyen =
                TaoButtonMenuKho(
                    "↔ Điều chuyển kho",
                    360,
                    btn_dieuchuyen_Click);

            Guna.UI2.WinForms.Guna2Button btnPhieuXuat =
                TaoButtonMenuKho(
                    "📤 Phiếu xuất kho",
                    411,
                    btn_phieuxuat_Click);

            // Giữ reference bằng Controls của panel.
            panelMenuKho.Controls.Add(btnCanhBao);
            panelMenuKho.Controls.Add(btnDieuChuyen);
            panelMenuKho.Controls.Add(btnPhieuXuat);
        }

        private Guna.UI2.WinForms.Guna2Button TaoButtonMenuKho(
            string text,
            int y,
            EventHandler click)
        {
            var btn = new Guna.UI2.WinForms.Guna2Button();

            btn.BorderRadius = 10;
            btn.FillColor = Color.Transparent;
            btn.FocusedColor = Color.Transparent;
            btn.Font = new Font("Segoe UI", 12F);
            btn.ForeColor = Color.White;
            btn.HoverState.FillColor = Color.FromArgb(40, 52, 70);
            btn.HoverState.ForeColor = Color.White;
            btn.Location = new Point(1, y);
            btn.Size = new Size(220, 45);
            btn.Text = text;
            btn.TextAlign = HorizontalAlignment.Left;
            btn.TextOffset = new Point(10, 0);
            btn.Click += click;

            return btn;
        }

        // =========================================================
        // CẢNH BÁO KHO
        // =========================================================
        private void btn_canhbao_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new CanhBaoKho());
        }

        // =========================================================
        // ĐIỀU CHUYỂN KHO
        // =========================================================
        private void btn_dieuchuyen_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new DieuChuyenKho());
        }

        // =========================================================
        // PHIẾU XUẤT KHO
        // =========================================================
        private void btn_phieuxuat_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new PhieuXuatKho());
        }

    }
}
using SPORTSHOP._03_QuanLyKho;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPORTSHOP;

namespace SPORTSHOP
{
    public partial class FormAdmin : Form
    {
        public TaiKhoan tk;

        private KetNoiDuLieu kt = new KetNoiDuLieu();

        private Form formHienTai = null;
        private List<Control> controlsTongQuan = new List<Control>();

        public FormAdmin(TaiKhoan tk)
        {
            InitializeComponent();
            this.tk = tk;

            // Tất cả các nút đã được gắn sự kiện Click trong Designer.cs (InitializeComponent).
            // KHÔNG gắn lại ở đây nữa để tránh bị gọi 2 lần (double-fire) khi click.

            controlsTongQuan.AddRange(panel1.Controls.Cast<Control>().ToArray());
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            panel1.Dock = DockStyle.Fill;
            LoadThongKe();
            LoadDanhSachSanPham();


        }

        private void btn_chitiet_Click(object sender, EventArgs e)
        {
            if (dgv_admin.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần xem chi tiết.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int maSP = Convert.ToInt32(
                dgv_admin.CurrentRow.Cells["MaSP"].Value);

            FormChiTietSanPham1 form =
                new FormChiTietSanPham1(maSP);

            form.ShowDialog();
        }
        private void LoadThongKe()
        {
            try
            {
                // Tổng doanh thu
                string sqlDoanhThu = @"
            SELECT ISNULL(SUM(TongTien), 0)
            FROM HoaDon";

                object doanhThu = kt.ExecuteScalar(sqlDoanhThu);

                decimal tongDoanhThu = Convert.ToDecimal(doanhThu);

                label2.Text = tongDoanhThu.ToString("N0") + " đ";


                // Đơn hàng hôm nay
                string sqlDonHang = @"
            SELECT COUNT(*)
            FROM HoaDon
            WHERE CAST(NgayLap AS DATE) = CAST(GETDATE() AS DATE)";

                object donHang = kt.ExecuteScalar(sqlDonHang);

                int soDonHang = Convert.ToInt32(donHang);

                label4.Text = soDonHang + " đơn";


                // Tổng số sản phẩm
                string sqlSanPham = @"
            SELECT COUNT(*)
            FROM SanPham
            WHERE TrangThai = 1";

                object sanPham = kt.ExecuteScalar(sqlSanPham);

                int soSanPham = Convert.ToInt32(sanPham);

                label6.Text = soSanPham + " sản phẩm";


                // Tổng số lượng tồn kho
                string sqlTonKho = @"
            SELECT ISNULL(SUM(SLTon), 0)
            FROM TonKho";

                object tonKho = kt.ExecuteScalar(sqlTonKho);

                int tongTonKho = Convert.ToInt32(tonKho);

                label8.Text = tongTonKho.ToString("N0") + " sản phẩm";
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

        private void btn_nhacungcap_Click(object sender, EventArgs e)
        {
            bool dangMo = PanelMenuNCC.Visible;

            DongTatCaMenu();

            PanelMenuNCC.Visible = !dangMo;
            if (PanelMenuNCC.Visible) PanelMenuNCC.BringToFront();
        }

        private void btn_baocao_Click(object sender, EventArgs e)
        {
            bool dangMo = panelMenuBaoCao.Visible;

            DongTatCaMenu();

            panelMenuBaoCao.Visible = !dangMo;
            if (panelMenuBaoCao.Visible) panelMenuBaoCao.BringToFront();
        }

        private void btn_tongquan_Click(object sender, EventArgs e)
        {
            DongTatCaMenu();

            // Đóng Form con hiện tại
            if (formHienTai != null)
            {
                formHienTai.Close();
                formHienTai.Dispose();
                formHienTai = null;
            }

            // Xóa Form con khỏi panel
            panel1.Controls.Clear();

            // Khôi phục giao diện Tổng quan ban đầu
            panel1.Controls.AddRange(controlsTongQuan.ToArray());

            // Cập nhật lại dữ liệu
            LoadThongKe();
            LoadDanhSachSanPham();
        }

        private void btn_taikhoan_Click(object sender, EventArgs e)
        {
            DongTatCaMenu();

            MoFormTrongPanel(new FormQLTK());
        }

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
                // Chỉ cập nhật phiên đăng nhập của Admin / Quản lý
                if (Session.MaVaiTro == PhanQuyen.ADMIN ||
                    Session.MaVaiTro == PhanQuyen.QUAN_LY)
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

                    KetNoiDuLieu kt = new KetNoiDuLieu();
                    kt.Execute(sql, parameters);
                }

                // Xóa phiên đăng nhập
                Session.DangXuat();

                // Đóng form hiện tại
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

        // Chỉ còn btn_nhaphang trỏ vào hàm này (xem InitializeComponent).
        // Các nút khác đã có handler riêng, không còn gọi vào đây nữa.
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn =
       sender as Guna.UI2.WinForms.Guna2Button;

            if (btn == null)
                return;

            switch (btn.Name)
            {
                case "btn_nhaphang":
                    {
                        bool dangMo = panelMenuKho.Visible;
                        DongTatCaMenu();
                        panelMenuKho.Visible = !dangMo;
                        break;
                    }
            }

        }
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

                DataTable dt = kt.GetData(sql);

                dgv_admin.DataSource = dt;

                if (dgv_admin.Columns["MaSP"] != null)
                    dgv_admin.Columns["MaSP"].HeaderText = "Mã SP";

                if (dgv_admin.Columns["TenSP"] != null)
                    dgv_admin.Columns["TenSP"].HeaderText = "Tên sản phẩm";

                if (dgv_admin.Columns["TenDanhMuc"] != null)
                    dgv_admin.Columns["TenDanhMuc"].HeaderText = "Danh mục";

                if (dgv_admin.Columns["TenThuongHieu"] != null)
                    dgv_admin.Columns["TenThuongHieu"].HeaderText = "Thương hiệu";

                if (dgv_admin.Columns["TrangThai"] != null)
                    dgv_admin.Columns["TrangThai"].HeaderText = "Trạng thái";

                if (dgv_admin.Columns["NgayTao"] != null)
                {
                    dgv_admin.Columns["NgayTao"].HeaderText = "Ngày tạo";
                    dgv_admin.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                dgv_admin.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgv_admin.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgv_admin.MultiSelect = false;
                dgv_admin.ReadOnly = true;
                dgv_admin.AllowUserToAddRows = false;
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
        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            Quản_lí_sản_phẩm_FormSanPham form =
        new Quản_lí_sản_phẩm_FormSanPham();

            form.ShowDialog();

            LoadDanhSachSanPham();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (dgv_admin.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần sửa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int maSP = Convert.ToInt32(
                dgv_admin.CurrentRow.Cells["MaSP"].Value);

            Quản_lí_sản_phẩm_FormSanPham form =
                new Quản_lí_sản_phẩm_FormSanPham(maSP);

            form.ShowDialog();

            LoadDanhSachSanPham();
            LoadThongKe();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_admin.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int maSP = Convert.ToInt32(
                dgv_admin.CurrentRow.Cells["MaSP"].Value);

            string tenSP = dgv_admin.CurrentRow.Cells["TenSP"].Value.ToString();

            DialogResult result = MessageBox.Show(
                "Bạn có muốn chuyển sản phẩm:\n\n" +
                tenSP +
                "\n\nsang trạng thái Ngừng hoạt động không?",
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
            if (dgv_admin.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm.");
                return;
            }

            int maSP = Convert.ToInt32(
                dgv_admin.CurrentRow.Cells["MaSP"].Value
            );

            MoFormTrongPanel(new FormChiTietSanPham1(maSP));
        }

        private void btn_sanpham_Click(object sender, EventArgs e)
        {
            bool dangMo = panelMenuSanPham.Visible;

            DongTatCaMenu();

            panelMenuSanPham.Visible = !dangMo;
            if (panelMenuSanPham.Visible) panelMenuSanPham.BringToFront();

        }

        private void dgv_admin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DongTatCaMenu()
        {
            panelMenuSanPham.Visible = false;
            PanelMenuBanHang.Visible = false;
            PanelMenuNCC.Visible = false;
            panelMenuBaoCao.Visible = false;
            panelMenuKho.Visible = false;
        }

        private void btn_danhmuc_Click(object sender, EventArgs e)
        {
            bool dangMo = panelMenuKho.Visible;

            DongTatCaMenu();

            panelMenuKho.Visible = !dangMo;
            if (panelMenuKho.Visible) panelMenuKho.BringToFront();
        }

        private void btn_banhangcha_Click(object sender, EventArgs e)
        {
            bool dangMo = PanelMenuBanHang.Visible;

            DongTatCaMenu();

            PanelMenuBanHang.Visible = !dangMo;
            if (PanelMenuBanHang.Visible) PanelMenuBanHang.BringToFront();
        }

        private void MoFormTrongPanel(Form form)
        {
            // Đóng form con cũ
            if (formHienTai != null)
            {
                formHienTai.Close();
                formHienTai.Dispose();
                formHienTai = null;
            }

            // Xóa form cũ trong panel
            panel1.Controls.Clear();

            // Cấu hình form con
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;

            // QUAN TRỌNG
            form.Dock = DockStyle.Fill;
            form.AutoSize = false;
            form.AutoScroll = true;

            // Đảm bảo form con chiếm toàn bộ panel
            form.Margin = new Padding(0);
            form.Padding = new Padding(0);

            panel1.Controls.Add(form);

            formHienTai = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.AutoSize = false;
            form.AutoScroll = true;

            form.BringToFront();
            form.Show();
        }

        private void btn_mausac_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormMauSac());
        }

        private void btn_size_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormSize());
        }

        private void btn_phieunhap_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FrmPhieuNhap());
        }

        private void ButtonNhapHang(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormNhapHang());
        }

        private void btn_danhmuc1_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormDanhMuc());
        }

        private void btn_NCC_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormNhaCungCap());
        }

        private void btn_themNCC_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormThemNhaCungCap());
        }

        private void btn_kho_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FromKho());
        }

        private void btn_thuonghieu_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormThuongHieu());
        }

        private void btn_sp_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new Quản_lí_sản_phẩm_FormSanPham());
        }

        private void btn_tonkho_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormTonKho());
        }

        private void btn_lichsuton_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormLStonkho());
        }

        private void btn_phieukho_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FrmPhieuKho());
        }

        private void FormChiTietNCC_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_BaoCaoCHamCong_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FormQuanLyChamCong());
        }
    }
}
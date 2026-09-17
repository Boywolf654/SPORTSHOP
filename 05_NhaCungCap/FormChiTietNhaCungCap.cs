using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._05_NhaCungCap
{
    public partial class FormChiTietNhaCungCap : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        private int maNCC;

        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public FormChiTietNhaCungCap()
        {
            InitializeComponent();

            btn_chinhsua.Click += btn_chinhsua_Click;
            btn_nht.Click += btn_nht_Click;
        }

        // Constructor dùng khi mở từ danh sách nhà cung cấp
        public FormChiTietNhaCungCap(int maNCC) : this()
        {
            this.maNCC = maNCC;
        }

        // =========================================================
        // LOAD FORM
        // =========================================================

        private void FormChiTietNhaCungCap_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                if (maNCC <= 0)
                {
                    MessageBox.Show(
                        "Không xác định được nhà cung cấp.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                LoadThongTinNhaCungCap();
                LoadLichSuGiaoDich();
                CauHinhGiaoDien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải thông tin nhà cung cấp.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // CẤU HÌNH GIAO DIỆN
        // =========================================================

        private void CauHinhGiaoDien()
        {
            dgv_lsgd.AllowUserToAddRows = false;
            dgv_lsgd.AllowUserToDeleteRows = false;
            dgv_lsgd.ReadOnly = true;

            dgv_lsgd.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv_lsgd.MultiSelect = false;
            dgv_lsgd.RowHeadersVisible = false;

            dgv_lsgd.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv_lsgd.RowTemplate.Height = 30;
        }

        // =========================================================
        // LOAD THÔNG TIN NHÀ CUNG CẤP
        // =========================================================

        private void LoadThongTinNhaCungCap()
        {
            string sql = @"
                SELECT
                    MaNCC,
                    TenNCC,
                    SDT,
                    DiaChi,
                    TrangThai,
                    Email
                FROM NhaCungCap
                WHERE MaNCC = @MaNCC";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNCC", maNCC)
            };

            DataTable dt = kt.GetData(sql, parameters);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy nhà cung cấp.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataRow row = dt.Rows[0];

            string tenNCC = row["TenNCC"] == DBNull.Value
                ? "Chưa cập nhật"
                : row["TenNCC"].ToString();

            string sdt = row["SDT"] == DBNull.Value
                ? "Chưa cập nhật"
                : row["SDT"].ToString();

            string diaChi = row["DiaChi"] == DBNull.Value
                ? "Chưa cập nhật"
                : row["DiaChi"].ToString();

            string email = row["Email"] == DBNull.Value
                ? "Chưa cập nhật"
                : row["Email"].ToString();

            bool trangThai =
                row["TrangThai"] != DBNull.Value &&
                Convert.ToBoolean(row["TrangThai"]);

            // =====================================================
            // HEADER
            // =====================================================

            label1.Text = "SPORT SHOP";
            btn_mancc.Text = "NCC-" + maNCC.ToString("D5");

            if (trangThai)
            {
                btn_dhd.Text = "●  Đang hoạt động";
                btn_dhd.ForeColor =
                    Color.FromArgb(46, 125, 50);

                btn_nht.Text = "Ngừng hợp tác";
            }
            else
            {
                btn_dhd.Text = "●  Ngừng hợp tác";
                btn_dhd.ForeColor =
                    Color.FromArgb(180, 70, 60);

                btn_nht.Text = "Mở lại hợp tác";
            }

            // =====================================================
            // TAB 1 - THÔNG TIN CHUNG
            // =====================================================

            // Tên nhà cung cấp
            label7.Text = tenNCC;

            // Địa chỉ
            label13.Text = diaChi;

            // Mã NCC
            label19.Text = "NCC-" + maNCC.ToString("D5");

            // Số điện thoại
            label21.Text = sdt;

            // Trạng thái
            label23.Text = trangThai
                ? "Đang hoạt động"
                : "Ngừng hợp tác";

            // Những trường DB hiện chưa có
            label11.Text = "Chưa cập nhật";
            label15.Text = "Chưa cập nhật";
            label17.Text = "Chưa cập nhật";
            label25.Text = "Chưa cập nhật";

            // =====================================================
            // TAB 2 - LIÊN HỆ & NGÂN HÀNG
            // =====================================================

            // Người liên hệ - DB hiện chưa có cột riêng
            label27.Text = tenNCC;

            // Số điện thoại
            label29.Text = sdt;

            // Email
            label37.Text = email;

            // Các trường chưa có trong DB
            label31.Text = "Chưa cập nhật";
            label33.Text = tenNCC;
            label35.Text = "Chưa cập nhật";
            label39.Text = "Chưa cập nhật";
        }

        // =========================================================
        // LỊCH SỬ GIAO DỊCH
        // =========================================================

        private void LoadLichSuGiaoDich()
        {
            string sql = @"
                SELECT
                    pn.MaPN AS [Mã phiếu nhập],
                    pn.NgayNhap AS [Ngày nhập],
                    ISNULL(nv.HoTen, N'Chưa xác định') AS [Nhân viên],
                    ISNULL(k.TenKho, N'Chưa xác định') AS [Kho],
                    pn.TrangThai AS [Trạng thái]
                FROM PhieuNhap pn
                LEFT JOIN NhanVien nv
                    ON pn.MaNV = nv.MaNV
                LEFT JOIN Kho k
                    ON pn.MaKho = k.MaKho
                WHERE pn.MaNCC = @MaNCC
                ORDER BY pn.NgayNhap DESC";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNCC", maNCC)
            };

            DataTable dt = kt.GetData(sql, parameters);

            dgv_lsgd.DataSource = dt;

            if (dgv_lsgd.Columns.Contains("Ngày nhập"))
            {
                dgv_lsgd.Columns["Ngày nhập"]
                    .DefaultCellStyle.Format =
                    "dd/MM/yyyy HH:mm";
            }

            if (dgv_lsgd.Columns.Contains("Mã phiếu nhập"))
            {
                dgv_lsgd.Columns["Mã phiếu nhập"].FillWeight = 80;
            }

            if (dgv_lsgd.Columns.Contains("Ngày nhập"))
            {
                dgv_lsgd.Columns["Ngày nhập"].FillWeight = 120;
            }

            if (dgv_lsgd.Columns.Contains("Nhân viên"))
            {
                dgv_lsgd.Columns["Nhân viên"].FillWeight = 150;
            }

            if (dgv_lsgd.Columns.Contains("Kho"))
            {
                dgv_lsgd.Columns["Kho"].FillWeight = 120;
            }

            if (dgv_lsgd.Columns.Contains("Trạng thái"))
            {
                dgv_lsgd.Columns["Trạng thái"].FillWeight = 110;
            }
        }

        // =========================================================
        // NGỪNG / MỞ LẠI HỢP TÁC
        // =========================================================

        private void btn_nht_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlCheck = @"
                    SELECT TrangThai
                    FROM NhaCungCap
                    WHERE MaNCC = @MaNCC";

                SqlParameter[] pCheck =
                {
                    new SqlParameter("@MaNCC", maNCC)
                };

                object result = kt.ExecuteScalar(
                    sqlCheck,
                    pCheck);

                if (result == null || result == DBNull.Value)
                {
                    MessageBox.Show(
                        "Không tìm thấy nhà cung cấp.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                bool dangHoatDong =
                    Convert.ToBoolean(result);

                string hanhDong = dangHoatDong
                    ? "ngừng hợp tác"
                    : "mở lại hợp tác";

                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc muốn " + hanhDong +
                    " với nhà cung cấp này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                string sql = @"
                    UPDATE NhaCungCap
                    SET TrangThai = @TrangThai
                    WHERE MaNCC = @MaNCC";

                SqlParameter[] parameters =
                {
                    new SqlParameter(
                        "@TrangThai",
                        !dangHoatDong),

                    new SqlParameter(
                        "@MaNCC",
                        maNCC)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show(
                    dangHoatDong
                        ? "Đã ngừng hợp tác với nhà cung cấp."
                        : "Đã mở lại hợp tác với nhà cung cấp.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadThongTinNhaCungCap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể cập nhật trạng thái.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // CHỈNH SỬA
        // =========================================================

        private void btn_chinhsua_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Chức năng chỉnh sửa thông tin nhà cung cấp sẽ thực hiện tại form quản lý nhà cung cấp.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
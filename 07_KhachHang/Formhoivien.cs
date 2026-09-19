using SPORTSHOP._06_BanHang;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._07_KhachHang
{
    public partial class FormHoiVien : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        // Mã hội viên đang được chọn trên lưới
        private int maKHDangChon = 0;

        private bool trangThaiDangChon = true;

        // =========================================================
        // NGƯỠNG ĐIỂM XÉT HẠNG
        // Chỉnh lại các mốc này nếu chính sách cửa hàng khác đi.
        // =========================================================
        private const int NGUONG_BAC = 1000;
        private const int NGUONG_VANG = 3000;
        private const int NGUONG_KIM_CUONG = 7000;

        public FormHoiVien()
        {
            InitializeComponent();

            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            cboHang.SelectedIndexChanged += cboHang_SelectedIndexChanged;

            dgvHoiVien.SelectionChanged += dgvHoiVien_SelectionChanged;
            dgvHoiVien.CellFormatting += dgvHoiVien_CellFormatting;

            btnCongDiem.Click += btnCongDiem_Click;
            btnTinhLaiHang.Click += btnTinhLaiHang_Click;
            btnDoiTrangThai.Click += btnDoiTrangThai_Click;
        }

        // =========================================================
        // LOAD FORM
        // =========================================================

        private void FormHoiVien_Load(object sender, EventArgs e)
        {
            cboHang.SelectedIndex = 0;

            CapNhatTrangThaiNut();

            LoadDanhSach();
            LoadThongKe();
        }

        // =========================================================
        // DANH SÁCH HỘI VIÊN
        // =========================================================

        private void LoadDanhSach()
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim();

                string hang =
                    cboHang.SelectedItem == null
                        ? "Tất cả hạng"
                        : cboHang.SelectedItem.ToString();

                string sql = @"
                    SELECT
                        MaKH,
                        HoTen,
                        SDT,
                        Email,
                        ISNULL(DiemTichLuy, 0)          AS DiemTichLuy,
                        ISNULL(HangThanhVien, N'Thường') AS HangThanhVien,
                        CASE WHEN ISNULL(TrangThai, 1) = 1
                             THEN N'Đang hoạt động'
                             ELSE N'Ngừng giao dịch'
                        END                             AS TrangThai,
                        ISNULL(TrangThai, 1)            AS TrangThaiGoc
                    FROM KhachHang
                    WHERE
                        (
                            @TuKhoa = ''
                            OR HoTen LIKE '%' + @TuKhoa + '%'
                            OR ISNULL(SDT, '') LIKE '%' + @TuKhoa + '%'
                            OR ISNULL(Email, '') LIKE '%' + @TuKhoa + '%'
                        )
                        AND
                        (
                            @Hang = N'Tất cả hạng'
                            OR ISNULL(HangThanhVien, N'Thường') = @Hang
                        )
                    ORDER BY ISNULL(DiemTichLuy, 0) DESC, HoTen ASC";

                DataTable dt = kt.GetData(
                    sql,
                    new SqlParameter[]
                    {
                        new SqlParameter("@TuKhoa", tuKhoa),
                        new SqlParameter("@Hang", hang)
                    });

                dgvHoiVien.DataSource = dt;

                DinhDangCotLuoi();

                maKHDangChon = 0;

                lbHoiVienDangChon.Text =
                    dt.Rows.Count == 0
                        ? "Không có hội viên nào phù hợp."
                        : "Chưa chọn hội viên nào.";

                CapNhatTrangThaiNut();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách hội viên.\n\n"
                    + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DinhDangCotLuoi()
        {
            if (dgvHoiVien.Columns.Count == 0 ||
                !dgvHoiVien.Columns.Contains("MaKH"))
                return;

            dgvHoiVien.Columns["MaKH"].HeaderText = "Mã KH";
            dgvHoiVien.Columns["HoTen"].HeaderText = "Họ và tên";
            dgvHoiVien.Columns["SDT"].HeaderText = "Số điện thoại";
            dgvHoiVien.Columns["Email"].HeaderText = "Email";
            dgvHoiVien.Columns["DiemTichLuy"].HeaderText = "Điểm tích lũy";
            dgvHoiVien.Columns["HangThanhVien"].HeaderText = "Hạng thành viên";
            dgvHoiVien.Columns["TrangThai"].HeaderText = "Trạng thái";

            dgvHoiVien.Columns["MaKH"].FillWeight = 60;
            dgvHoiVien.Columns["HoTen"].FillWeight = 150;
            dgvHoiVien.Columns["SDT"].FillWeight = 100;
            dgvHoiVien.Columns["Email"].FillWeight = 160;
            dgvHoiVien.Columns["DiemTichLuy"].FillWeight = 100;
            dgvHoiVien.Columns["HangThanhVien"].FillWeight = 110;
            dgvHoiVien.Columns["TrangThai"].FillWeight = 110;

            dgvHoiVien.Columns["DiemTichLuy"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvHoiVien.Columns["DiemTichLuy"].DefaultCellStyle.Format = "N0";

            dgvHoiVien.Columns["MaKH"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvHoiVien.Columns["HangThanhVien"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvHoiVien.Columns["TrangThai"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvHoiVien.Columns["TrangThaiGoc"].Visible = false;

            dgvHoiVien.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Tô màu hạng thành viên và trạng thái cho dễ nhìn
        private void dgvHoiVien_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string tenCot = dgvHoiVien.Columns[e.ColumnIndex].Name;

            if (tenCot == "HangThanhVien" && e.Value != null)
            {
                e.CellStyle.ForeColor =
                    LayMauTheoHang(e.Value.ToString());

                e.CellStyle.Font = new Font(
                    "Segoe UI Semibold",
                    9.75F);
            }

            if (tenCot == "TrangThai" && e.Value != null)
            {
                bool con = e.Value.ToString().Contains("Đang");

                e.CellStyle.ForeColor = con
                    ? Color.FromArgb(16, 185, 129)
                    : Color.FromArgb(220, 38, 38);

                e.CellStyle.Font = new Font(
                    "Segoe UI Semibold",
                    9.75F);
            }
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
        // THỐNG KÊ
        // =========================================================

        private void LoadThongKe()
        {
            try
            {
                string sql = @"
                    SELECT
                        COUNT(*) AS TongHoiVien,

                        SUM(CASE WHEN ISNULL(TrangThai, 1) = 1
                                 THEN 1 ELSE 0 END) AS DangHoatDong,

                        SUM(ISNULL(DiemTichLuy, 0)) AS TongDiem,

                        SUM(CASE WHEN ISNULL(HangThanhVien, N'Thường')
                                      IN (N'Vàng', N'Kim cương')
                                 THEN 1 ELSE 0 END) AS HangCao
                    FROM KhachHang";

                DataTable dt = kt.GetData(
                    sql,
                    new SqlParameter[] { });

                if (dt.Rows.Count == 0)
                    return;

                DataRow r = dt.Rows[0];

                lbTongHoiVien.Text = DocSo(r["TongHoiVien"]).ToString("N0");
                lbDangHoatDong.Text = DocSo(r["DangHoatDong"]).ToString("N0");
                lbTongDiem.Text = DocSo(r["TongDiem"]).ToString("N0");
                lbHangCao.Text = DocSo(r["HangCao"]).ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải số liệu thống kê.\n\n"
                    + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private long DocSo(object giaTri)
        {
            if (giaTri == null || giaTri == DBNull.Value)
                return 0;

            return Convert.ToInt64(giaTri);
        }

        // =========================================================
        // TÌM KIẾM & LỌC
        // =========================================================

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        private void cboHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        // =========================================================
        // CHỌN HỘI VIÊN TRÊN LƯỚI
        // =========================================================

        private void dgvHoiVien_SelectionChanged(object sender, EventArgs e)
        {
            // Lưới có thể chưa có cột khi DataSource vừa được gán
            if (!dgvHoiVien.Columns.Contains("MaKH") ||
                !dgvHoiVien.Columns.Contains("TrangThaiGoc"))
            {
                return;
            }

            if (dgvHoiVien.CurrentRow == null ||
                dgvHoiVien.CurrentRow.Index < 0)
            {
                maKHDangChon = 0;
                CapNhatTrangThaiNut();
                return;
            }

            DataGridViewRow dong = dgvHoiVien.CurrentRow;

            if (dong.Cells["MaKH"].Value == null)
                return;

            maKHDangChon =
                Convert.ToInt32(dong.Cells["MaKH"].Value);

            string hoTen =
                dong.Cells["HoTen"].Value == null
                    ? ""
                    : dong.Cells["HoTen"].Value.ToString();

            int diem =
                dong.Cells["DiemTichLuy"].Value == null
                    ? 0
                    : Convert.ToInt32(dong.Cells["DiemTichLuy"].Value);

            string hang =
                dong.Cells["HangThanhVien"].Value == null
                    ? "Thường"
                    : dong.Cells["HangThanhVien"].Value.ToString();

            object tt = dong.Cells["TrangThaiGoc"].Value;

            trangThaiDangChon =
                tt == null || tt == DBNull.Value ||
                Convert.ToBoolean(tt);

            lbHoiVienDangChon.Text =
                "Đang chọn: " + hoTen
                + "  •  " + hang
                + "  •  " + diem.ToString("N0") + " điểm";

            btnDoiTrangThai.Text =
                trangThaiDangChon
                    ? "Ngừng giao dịch"
                    : "Mở lại giao dịch";

            CapNhatTrangThaiNut();
        }

        private void CapNhatTrangThaiNut()
        {
            bool coChon = maKHDangChon > 0;

            btnCongDiem.Enabled = coChon;
            btnDoiTrangThai.Enabled = coChon;
            numDiem.Enabled = coChon;
        }

        // =========================================================
        // CỘNG ĐIỂM TÍCH LŨY
        // =========================================================

        private void btnCongDiem_Click(object sender, EventArgs e)
        {
            if (maKHDangChon <= 0)
                return;

            int diemCong = (int)numDiem.Value;

            if (diemCong <= 0)
            {
                MessageBox.Show(
                    "Số điểm cộng phải lớn hơn 0.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Cộng " + diemCong.ToString("N0")
                + " điểm cho hội viên đang chọn?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            try
            {
                string sql = @"
                    UPDATE KhachHang
                    SET DiemTichLuy = ISNULL(DiemTichLuy, 0) + @Diem
                    WHERE MaKH = @MaKH";

                kt.Execute(
                    sql,
                    new SqlParameter[]
                    {
                        new SqlParameter("@Diem", diemCong),
                        new SqlParameter("@MaKH", maKHDangChon)
                    });

                LoadDanhSach();
                LoadThongKe();

                MessageBox.Show(
                    "Đã cộng điểm cho hội viên.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể cộng điểm.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // TÍNH LẠI HẠNG THÀNH VIÊN THEO ĐIỂM TÍCH LŨY
        // =========================================================

        private void btnTinhLaiHang_Click(object sender, EventArgs e)
        {
            DialogResult xacNhan = MessageBox.Show(
                "Tính lại hạng thành viên cho toàn bộ hội viên "
                + "dựa trên điểm tích lũy hiện tại?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            try
            {
                string sql = @"
                    UPDATE KhachHang
                    SET HangThanhVien =
                        CASE
                            WHEN ISNULL(DiemTichLuy, 0) >= @KimCuong
                                THEN N'Kim cương'
                            WHEN ISNULL(DiemTichLuy, 0) >= @Vang
                                THEN N'Vàng'
                            WHEN ISNULL(DiemTichLuy, 0) >= @Bac
                                THEN N'Bạc'
                            WHEN ISNULL(DiemTichLuy, 0) > 0
                                THEN N'Đồng'
                            ELSE N'Thường'
                        END";

                kt.Execute(
                    sql,
                    new SqlParameter[]
                    {
                        new SqlParameter("@KimCuong", NGUONG_KIM_CUONG),
                        new SqlParameter("@Vang", NGUONG_VANG),
                        new SqlParameter("@Bac", NGUONG_BAC)
                    });

                LoadDanhSach();
                LoadThongKe();

                MessageBox.Show(
                    "Đã cập nhật lại hạng thành viên.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tính lại hạng thành viên.\n\n"
                    + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // ĐỔI TRẠNG THÁI GIAO DỊCH
        // =========================================================

        private void btnDoiTrangThai_Click(object sender, EventArgs e)
        {
            if (maKHDangChon <= 0)
                return;

            bool trangThaiMoi = !trangThaiDangChon;

            string thongBao =
                trangThaiMoi
                    ? "Mở lại giao dịch cho hội viên này?"
                    : "Ngừng giao dịch với hội viên này?";

            DialogResult xacNhan = MessageBox.Show(
                thongBao,
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (xacNhan != DialogResult.Yes)
                return;

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
                        new SqlParameter("@TrangThai", trangThaiMoi),
                        new SqlParameter("@MaKH", maKHDangChon)
                    });

                LoadDanhSach();
                LoadThongKe();
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
    }
}
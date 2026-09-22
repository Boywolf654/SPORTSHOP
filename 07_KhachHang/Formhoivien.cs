using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SPORTSHOP._07_KhachHang
{
    public partial class FormHoiVien : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        private int maKH;
        private int diemHienTai;
        private int maHangHienTai;
        private string tenHangHienTai = "Đồng";
        private decimal tyLeUuDaiHienTai = 0;

        public FormHoiVien()
        {
            InitializeComponent();
        }

        private void FormHoiVien_Load(object sender, EventArgs e)
        {
            LoadDuLieuHoiVien();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDuLieuHoiVien();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadDuLieuHoiVien()
        {
            try
            {
                if (Session.MaTK <= 0)
                {
                    HienThiChuaDangNhap();
                    return;
                }

                maKH = LayMaKH();
                if (maKH <= 0)
                {
                    HienThiChuaCoHoSo();
                    return;
                }

                LoadThongTinTongQuan();
                LoadDanhSachHang();
                TinhTienDoHang();
                LoadLichSuDiem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải thông tin hội viên.\r\n\r\n" + ex.Message,
                    "SPORTSHOP - Hội viên",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private int LayMaKH()
        {
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

        private void LoadThongTinTongQuan()
        {
            string sql = @"
                SELECT TOP 1
                    kh.MaKH,
                    ISNULL(kh.HoTen, N'Khách hàng') AS HoTen,
                    ISNULL(kh.DiemHoiVien, 0) AS DiemHoiVien,
                    ISNULL(kh.MaHangHoiVien, 0) AS MaHangHoiVien,
                    ISNULL(hv.TenHang, ISNULL(kh.HangThanhVien, N'Đồng')) AS TenHang,
                    ISNULL(hv.TyLeUuDai, 0) AS TyLeUuDai
                FROM KhachHang kh
                LEFT JOIN HangHoiVien hv
                    ON hv.MaHangHoiVien = kh.MaHangHoiVien
                WHERE kh.MaKH = @MaKH";

            DataTable dt = kt.GetData(
                sql,
                new SqlParameter[]
                {
                    new SqlParameter("@MaKH", maKH)
                });

            if (dt.Rows.Count == 0)
            {
                HienThiChuaCoHoSo();
                return;
            }

            DataRow r = dt.Rows[0];

            string hoTen = r["HoTen"] == DBNull.Value
                ? "Khách hàng"
                : r["HoTen"].ToString();

            diemHienTai = r["DiemHoiVien"] == DBNull.Value
                ? 0
                : Convert.ToInt32(r["DiemHoiVien"]);

            maHangHienTai = r["MaHangHoiVien"] == DBNull.Value
                ? 0
                : Convert.ToInt32(r["MaHangHoiVien"]);

            tenHangHienTai = r["TenHang"] == DBNull.Value
                ? "Đồng"
                : r["TenHang"].ToString();

            tyLeUuDaiHienTai = r["TyLeUuDai"] == DBNull.Value
                ? 0
                : Convert.ToDecimal(r["TyLeUuDai"]);

            lblXinChao.Text = "Xin chào, " + hoTen;
            lblHang.Text = tenHangHienTai;
            lblDiem.Text = diemHienTai.ToString("N0") + " điểm";
            lblUuDai.Text = "Ưu đãi hạng: " + tyLeUuDaiHienTai.ToString("0.##") + "%";

            lblMaKH.Text = "Mã khách hàng: KH" + maKH.ToString("D4");
            lblQuyDoi.Text = "Quy đổi: 1 điểm / 10.000 VNĐ";

            Color mau = LayMauHang(tenHangHienTai);
            lblHang.ForeColor = mau;
            pnlHang.BackColor = Color.FromArgb(32, 32, 35);
        }

        private void LoadDanhSachHang()
        {
            dgvHang.Rows.Clear();

            DataTable dt = null;

            try
            {
                // Đọc trực tiếp bảng HangHoiVien.
                // Dùng SELECT * để form không phụ thuộc tuyệt đối vào tên
                // cột ngưỡng điểm của từng phiên bản DB.
                dt = kt.GetData(
                    "SELECT * FROM HangHoiVien ORDER BY MaHangHoiVien");
            }
            catch
            {
                dt = null;
            }

            if (dt == null || dt.Rows.Count == 0)
            {
                // Fallback đúng theo rule đã thống nhất của SPORTSHOP.
                ThemHangFallback(1, "Đồng", 0, 0);
                ThemHangFallback(2, "Bạc", 500, 2);
                ThemHangFallback(3, "Vàng", 1000, 5);
                ThemHangFallback(4, "Kim cương", 3000, 10);
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                int maHang = LayInt(row, "MaHangHoiVien", 0);
                string tenHang = LayString(row, "TenHang", "Hạng");

                decimal uuDai = LayDecimal(row, "TyLeUuDai", 0);

                int mocDiem = LayMocDiem(row);

                int index = dgvHang.Rows.Add();
                DataGridViewRow r = dgvHang.Rows[index];

                r.Cells["colHang"].Value = tenHang;
                r.Cells["colMocDiem"].Value =
                    mocDiem.ToString("N0") + " điểm";
                r.Cells["colUuDai"].Value =
                    uuDai.ToString("0.##") + "%";
                r.Cells["colTrangThai"].Value =
                    maHang == maHangHienTai
                        ? "ĐANG LÀ HẠNG CỦA BẠN"
                        : diemHienTai >= mocDiem
                            ? "Đã đạt"
                            : "Chưa đạt";

                r.Tag = new HangInfo
                {
                    MaHang = maHang,
                    TenHang = tenHang,
                    MocDiem = mocDiem,
                    UuDai = uuDai
                };

                r.DefaultCellStyle.BackColor =
                    maHang == maHangHienTai
                        ? Color.FromArgb(255, 242, 242)
                        : Color.White;

                r.DefaultCellStyle.ForeColor =
                    Color.FromArgb(45, 45, 50);

                r.DefaultCellStyle.Font =
                    new Font("Segoe UI", 9.5F, FontStyle.Regular);
            }

            if (dgvHang.Rows.Count == 0)
            {
                ThemHangFallback(1, "Đồng", 0, 0);
                ThemHangFallback(2, "Bạc", 500, 2);
                ThemHangFallback(3, "Vàng", 1000, 5);
                ThemHangFallback(4, "Kim cương", 3000, 10);
            }
        }

        private void ThemHangFallback(
            int maHang,
            string tenHang,
            int mocDiem,
            decimal uuDai)
        {
            int index = dgvHang.Rows.Add();
            DataGridViewRow r = dgvHang.Rows[index];

            r.Cells["colHang"].Value = tenHang;
            r.Cells["colMocDiem"].Value = mocDiem.ToString("N0") + " điểm";
            r.Cells["colUuDai"].Value = uuDai.ToString("0.##") + "%";
            r.Cells["colTrangThai"].Value =
                tenHang.Equals(
                    tenHangHienTai,
                    StringComparison.OrdinalIgnoreCase)
                    ? "ĐANG LÀ HẠNG CỦA BẠN"
                    : diemHienTai >= mocDiem
                        ? "Đã đạt"
                        : "Chưa đạt";

            r.Tag = new HangInfo
            {
                MaHang = maHang,
                TenHang = tenHang,
                MocDiem = mocDiem,
                UuDai = uuDai
            };

            r.DefaultCellStyle.BackColor =
                tenHang.Equals(
                    tenHangHienTai,
                    StringComparison.OrdinalIgnoreCase)
                    ? Color.FromArgb(255, 242, 242)
                    : Color.White;
        }

        private int LayMocDiem(DataRow row)
        {
            string[] tenCot =
            {
                "DiemToiThieu",
                "DiemCan",
                "DiemYeuCau",
                "SoDiemToiThieu",
                "Diem"
            };

            foreach (string tenCotCanTim in tenCot)
            {
                if (!row.Table.Columns.Contains(tenCotCanTim))
                    continue;

                if (row[tenCotCanTim] == DBNull.Value)
                    continue;

                int diem;
                if (int.TryParse(
                    row[tenCotCanTim].ToString(),
                    out diem))
                    return diem;
            }

            // Fallback theo MaHangHoiVien của seed SPORTSHOP.
            int maHang = LayInt(row, "MaHangHoiVien", 0);

            switch (maHang)
            {
                case 1: return 0;
                case 2: return 500;
                case 3: return 1000;
                case 4: return 3000;
                default: return 0;
            }
        }

        private void LoadLichSuDiem()
        {
            dgvLichSu.Rows.Clear();

            string sql = @"
                SELECT TOP 100
                    ls.ThoiGian,
                    ls.SoDiem,
                    ls.LyDo,
                    ls.MaHD
                FROM LichSuDiemThuong ls
                WHERE ls.MaKH = @MaKH
                ORDER BY ls.ThoiGian DESC, ls.MaLSDiem DESC";

            DataTable dt = kt.GetData(
                sql,
                new SqlParameter[]
                {
                    new SqlParameter("@MaKH", maKH)
                });

            foreach (DataRow row in dt.Rows)
            {
                int index = dgvLichSu.Rows.Add();

                DateTime thoiGian =
                    row["ThoiGian"] == DBNull.Value
                        ? DateTime.MinValue
                        : Convert.ToDateTime(row["ThoiGian"]);

                int soDiem =
                    row["SoDiem"] == DBNull.Value
                        ? 0
                        : Convert.ToInt32(row["SoDiem"]);

                string lyDo =
                    row["LyDo"] == DBNull.Value
                        ? ""
                        : row["LyDo"].ToString();

                string maHD =
                    row["MaHD"] == DBNull.Value
                        ? "-"
                        : "HD" + Convert.ToInt32(row["MaHD"]).ToString("D4");

                DataGridViewRow r = dgvLichSu.Rows[index];

                r.Cells["colNgay"].Value =
                    thoiGian == DateTime.MinValue
                        ? "-"
                        : thoiGian.ToString("dd/MM/yyyy HH:mm");

                r.Cells["colDiemLS"].Value =
                    (soDiem >= 0 ? "+" : "") +
                    soDiem.ToString("N0");

                r.Cells["colLyDo"].Value = lyDo;
                r.Cells["colMaHD"].Value = maHD;

                r.Cells["colDiemLS"].Style.ForeColor =
                    soDiem >= 0
                        ? Color.FromArgb(25, 145, 85)
                        : Color.FromArgb(210, 45, 55);
            }

            if (dgvLichSu.Rows.Count == 0)
            {
                int index = dgvLichSu.Rows.Add();
                dgvLichSu.Rows[index].Cells["colNgay"].Value = "-";
                dgvLichSu.Rows[index].Cells["colDiemLS"].Value = "0";
                dgvLichSu.Rows[index].Cells["colLyDo"].Value =
                    "Chưa có lịch sử điểm";
                dgvLichSu.Rows[index].Cells["colMaHD"].Value = "-";
            }
        }

        private void TinhTienDoHang()
        {
            int mocHienTai = LayMocHangHienTai();

            HangInfo hangKeTiep = LayHangKeTiep();

            if (hangKeTiep == null)
            {
                progressHang.Value = 100;
                lblTienDo.Text =
                    "🎉 Bạn đang ở hạng cao nhất của hệ thống.";
                lblConThieu.Text = "Đã đạt hạng tối đa";
                lblNextHang.Text = "Hạng cao nhất";
                return;
            }

            int mocKeTiep = hangKeTiep.MocDiem;

            int max = Math.Max(mocKeTiep, mocHienTai + 1);
            int value = Math.Max(0, Math.Min(diemHienTai, max));

            progressHang.Maximum = max;
            progressHang.Value = value;

            int conThieu =
                Math.Max(0, mocKeTiep - diemHienTai);

            lblNextHang.Text =
                "Mục tiêu tiếp theo: " + hangKeTiep.TenHang;

            lblConThieu.Text =
                conThieu > 0
                    ? "Còn " + conThieu.ToString("N0") +
                      " điểm để lên " + hangKeTiep.TenHang
                    : "Bạn đã đủ điểm để đạt " + hangKeTiep.TenHang;

            lblTienDo.Text =
                diemHienTai.ToString("N0") +
                " / " +
                mocKeTiep.ToString("N0") +
                " điểm";
        }

        private int LayMocHangHienTai()
        {
            foreach (DataGridViewRow row in dgvHang.Rows)
            {
                HangInfo info = row.Tag as HangInfo;

                if (info == null)
                    continue;

                if (info.MaHang == maHangHienTai ||
                    info.TenHang.Equals(
                        tenHangHienTai,
                        StringComparison.OrdinalIgnoreCase))
                    return info.MocDiem;
            }

            if (tenHangHienTai.Equals(
                "Bạc",
                StringComparison.OrdinalIgnoreCase))
                return 500;

            if (tenHangHienTai.Equals(
                "Vàng",
                StringComparison.OrdinalIgnoreCase))
                return 1000;

            if (tenHangHienTai.Equals(
                "Kim cương",
                StringComparison.OrdinalIgnoreCase))
                return 3000;

            return 0;
        }

        private HangInfo LayHangKeTiep()
        {
            HangInfo ketQua = null;

            foreach (DataGridViewRow row in dgvHang.Rows)
            {
                HangInfo info = row.Tag as HangInfo;

                if (info == null)
                    continue;

                if (info.MocDiem <= LayMocHangHienTai())
                    continue;

                if (info.MocDiem <= diemHienTai)
                    continue;

                if (ketQua == null ||
                    info.MocDiem < ketQua.MocDiem)
                    ketQua = info;
            }

            return ketQua;
        }

        private void HienThiChuaDangNhap()
        {
            lblXinChao.Text = "Chưa đăng nhập";
            lblHang.Text = "—";
            lblDiem.Text = "0 điểm";
            lblUuDai.Text = "Vui lòng đăng nhập tài khoản khách hàng.";
            lblMaKH.Text = "";
            lblQuyDoi.Text = "";
            lblNextHang.Text = "Chưa có dữ liệu";
            lblConThieu.Text = "";
            lblTienDo.Text = "";
            progressHang.Value = 0;

            dgvHang.Rows.Clear();
            dgvLichSu.Rows.Clear();
        }

        private void HienThiChuaCoHoSo()
        {
            lblXinChao.Text = "Chưa có hồ sơ khách hàng";
            lblHang.Text = "—";
            lblDiem.Text = "0 điểm";
            lblUuDai.Text = "Tài khoản chưa có hồ sơ hội viên.";
            lblMaKH.Text = "";
            lblQuyDoi.Text = "";
            lblNextHang.Text = "Chưa có dữ liệu";
            lblConThieu.Text = "";
            lblTienDo.Text = "";
            progressHang.Value = 0;

            dgvHang.Rows.Clear();
            dgvLichSu.Rows.Clear();
        }

        private static int LayInt(
            DataRow row,
            string tenCot,
            int macDinh)
        {
            if (!row.Table.Columns.Contains(tenCot) ||
                row[tenCot] == DBNull.Value)
                return macDinh;

            int value;
            return int.TryParse(
                row[tenCot].ToString(),
                out value)
                ? value
                : macDinh;
        }

        private static decimal LayDecimal(
            DataRow row,
            string tenCot,
            decimal macDinh)
        {
            if (!row.Table.Columns.Contains(tenCot) ||
                row[tenCot] == DBNull.Value)
                return macDinh;

            decimal value;
            return decimal.TryParse(
                row[tenCot].ToString(),
                out value)
                ? value
                : macDinh;
        }

        private static string LayString(
            DataRow row,
            string tenCot,
            string macDinh)
        {
            if (!row.Table.Columns.Contains(tenCot) ||
                row[tenCot] == DBNull.Value)
                return macDinh;

            string value = row[tenCot].ToString();
            return string.IsNullOrWhiteSpace(value)
                ? macDinh
                : value;
        }

        private Color LayMauHang(string tenHang)
        {
            if (tenHang.IndexOf(
                "Kim",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return Color.FromArgb(155, 90, 220);

            if (tenHang.IndexOf(
                "Vàng",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return Color.FromArgb(210, 155, 35);

            if (tenHang.IndexOf(
                "Bạc",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return Color.FromArgb(115, 125, 140);

            return Color.FromArgb(180, 105, 55);
        }

        private sealed class HangInfo
        {
            public int MaHang { get; set; }
            public string TenHang { get; set; }
            public int MocDiem { get; set; }
            public decimal UuDai { get; set; }
        }
    }
}

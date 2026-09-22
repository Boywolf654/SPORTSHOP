using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormChuyenCa : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        private int maCa;
        private int maNV;
        private DateTime gioBatDau;
        private decimal doanhThu;
        private int soHoaDon;

        public bool DaChuyenCaThanhCong { get; private set; }

        public FormChuyenCa()
        {
            InitializeComponent();
        }

        private void FormChuyenCa_Load(object sender, EventArgs e)
        {
            maNV = Session.MaNV;

            if (maNV <= 0)
            {
                MessageBox.Show(
                    "Không xác định được nhân viên đang đăng nhập.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            LoadThongTinCa();
        }

        private void LoadThongTinCa()
        {
            try
            {
                string sql = @"
SELECT TOP 1
    c.MaCa,
    c.MaNV,
    c.GioBatDau,
    c.DoanhThu,
    c.SoHoaDon,
    c.TrangThai,
    ISNULL(nv.HoTen, N'Nhân viên') AS TenNV
FROM CaLamViec c
LEFT JOIN NhanVien nv ON nv.MaNV = c.MaNV
WHERE c.MaNV = @MaNV
  AND c.TrangThai = N'Đang làm'
ORDER BY c.MaCa DESC;";

                DataTable dt = kt.GetData(
                    sql,
                    new SqlParameter[]
                    {
                        new SqlParameter("@MaNV", maNV)
                    });

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Nhân viên hiện không có ca đang làm.",
                        "SPORTSHOP",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Close();
                    return;
                }

                DataRow r = dt.Rows[0];

                maCa = Convert.ToInt32(r["MaCa"]);
                gioBatDau = Convert.ToDateTime(r["GioBatDau"]);

                lblMaCaValue.Text = "CA" + maCa.ToString("D4");
                lblNhanVienValue.Text = r["TenNV"].ToString();
                lblMaNVValue.Text = maNV.ToString();
                lblBatDauValue.Text = gioBatDau.ToString("dd/MM/yyyy HH:mm:ss");

                TimeSpan tg = DateTime.Now - gioBatDau;
                lblThoiGianValue.Text =
                    Math.Max(0, (int)tg.TotalHours) + " giờ " +
                    tg.Minutes + " phút";

                LoadTongKet();
                LoadDonChoXuLy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải thông tin ca.\n\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadTongKet()
        {
            try
            {
                // Ưu tiên MaCa. Đây là ca thực tế đang mở.
                string sql = @"
SELECT
    COUNT(DISTINCT hd.MaHD) AS SoHoaDon,
    ISNULL(SUM(hd.TongTien), 0) AS DoanhThu
FROM HoaDon hd
WHERE hd.MaCa = @MaCa
  AND hd.MaNV = @MaNV
  AND hd.TrangThaiDonHang = N'Hoàn thành';";

                DataTable dt;

                try
                {
                    dt = kt.GetData(
                        sql,
                        new SqlParameter[]
                        {
                            new SqlParameter("@MaCa", maCa),
                            new SqlParameter("@MaNV", maNV)
                        });
                }
                catch
                {
                    // Fallback cho DB chưa có MaCa trong HoaDon.
                    string sqlFallback = @"
SELECT
    COUNT(*) AS SoHoaDon,
    ISNULL(SUM(hd.TongTien), 0) AS DoanhThu
FROM HoaDon hd
WHERE hd.MaNV = @MaNV
  AND hd.NgayLap >= @GioBatDau
  AND hd.NgayLap <= GETDATE()
  AND hd.TrangThaiDonHang = N'Hoàn thành';";

                    dt = kt.GetData(
                        sqlFallback,
                        new SqlParameter[]
                        {
                            new SqlParameter("@MaNV", maNV),
                            new SqlParameter("@GioBatDau", gioBatDau)
                        });
                }

                if (dt.Rows.Count > 0)
                {
                    soHoaDon = Convert.ToInt32(dt.Rows[0]["SoHoaDon"]);
                    doanhThu = Convert.ToDecimal(dt.Rows[0]["DoanhThu"]);
                }

                lblDoanhThuValue.Text = doanhThu.ToString("N0") + " đ";
                lblSoHoaDonValue.Text = soHoaDon.ToString();

                LoadPhuongThucThanhToan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tổng hợp doanh thu ca.\n\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadPhuongThucThanhToan()
        {
            decimal tienMat = 0;
            decimal the = 0;
            decimal chuyenKhoan = 0;
            decimal vi = 0;

            try
            {
                string sql = @"
SELECT
    tt.PhuongThuc,
    ISNULL(SUM(tt.SoTien), 0) AS TongTien
FROM ThanhToan tt
INNER JOIN HoaDon hd ON hd.MaHD = tt.MaHD
WHERE hd.MaCa = @MaCa
  AND hd.MaNV = @MaNV
  AND hd.TrangThaiDonHang = N'Hoàn thành'
  AND (tt.TrangThai IS NULL OR tt.TrangThai = N'Đã thanh toán')
GROUP BY tt.PhuongThuc;";

                DataTable dt = kt.GetData(
                    sql,
                    new SqlParameter[]
                    {
                        new SqlParameter("@MaCa", maCa),
                        new SqlParameter("@MaNV", maNV)
                    });

                foreach (DataRow r in dt.Rows)
                {
                    string pt = r["PhuongThuc"] == DBNull.Value
                        ? ""
                        : r["PhuongThuc"].ToString();

                    decimal tien = Convert.ToDecimal(r["TongTien"]);

                    if (pt.Equals("Tiền mặt", StringComparison.OrdinalIgnoreCase))
                        tienMat += tien;
                    else if (pt.Equals("Thẻ", StringComparison.OrdinalIgnoreCase))
                        the += tien;
                    else if (pt.Equals("Chuyển khoản", StringComparison.OrdinalIgnoreCase))
                        chuyenKhoan += tien;
                    else if (pt.Equals("Ví điện tử", StringComparison.OrdinalIgnoreCase))
                        vi += tien;
                }
            }
            catch
            {
                // Không làm hỏng chức năng chuyển ca nếu bảng thanh toán
                // chưa có đủ dữ liệu.
            }

            lblTienMatValue.Text = tienMat.ToString("N0") + " đ";
            lblTheValue.Text = the.ToString("N0") + " đ";
            lblChuyenKhoanValue.Text = chuyenKhoan.ToString("N0") + " đ";
            lblViValue.Text = vi.ToString("N0") + " đ";
        }

        private void LoadDonChoXuLy()
        {
            try
            {
                string sql = @"
SELECT COUNT(*)
FROM DonOnline
WHERE TrangThai IN
(
    N'Chờ xử lý',
    N'Chờ thanh toán',
    N'Đã thanh toán'
);";

                object result = kt.ExecuteScalar(sql, null);
                int soDon = result == null || result == DBNull.Value
                    ? 0
                    : Convert.ToInt32(result);

                lblDonChoValue.Text = soDon.ToString();
            }
            catch
            {
                lblDonChoValue.Text = "—";
            }
        }

        private void chkXacNhan_CheckedChanged(object sender, EventArgs e)
        {
            btnChuyenCa.Enabled = chkXacNhan.Checked;
        }

        private void btnChuyenCa_Click(object sender, EventArgs e)
        {
            if (!chkXacNhan.Checked)
            {
                MessageBox.Show(
                    "Hãy xác nhận tổng kết ca trước khi chuyển ca.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Xác nhận kết thúc CA" + maCa.ToString("D4") + "?\n\n" +
                "Doanh thu: " + doanhThu.ToString("N0") + " đ\n" +
                "Số hóa đơn: " + soHoaDon + "\n\n" +
                "Sau khi chuyển ca, màn hình sẽ bị khóa và " +
                "nhân viên tiếp theo phải đăng nhập.",
                "XÁC NHẬN CHUYỂN CA",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                DateTime gioKetThuc = DateTime.Now;

                using (SqlConnection conn = kt.GetConnection())
                {
                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            // Tính lại ngay tại thời điểm chốt để số liệu
                            // không phụ thuộc giá trị đang hiển thị trên form.
                            decimal doanhThuChot = 0;
                            int soHoaDonChot = 0;

                            string sqlTongKet = @"
SELECT
    COUNT(DISTINCT hd.MaHD) AS SoHoaDon,
    ISNULL(SUM(hd.TongTien), 0) AS DoanhThu
FROM HoaDon hd
WHERE hd.MaCa = @MaCa
  AND hd.MaNV = @MaNV
  AND hd.TrangThaiDonHang = N'Hoàn thành';";

                            try
                            {
                                using (SqlCommand cmd =
                                    new SqlCommand(sqlTongKet, conn, tran))
                                {
                                    cmd.Parameters.Add(
                                        "@MaCa", SqlDbType.Int).Value = maCa;
                                    cmd.Parameters.Add(
                                        "@MaNV", SqlDbType.Int).Value = maNV;

                                    using (SqlDataReader rd = cmd.ExecuteReader())
                                    {
                                        if (rd.Read())
                                        {
                                            soHoaDonChot = Convert.ToInt32(rd["SoHoaDon"]);
                                            doanhThuChot = Convert.ToDecimal(rd["DoanhThu"]);
                                        }
                                    }
                                }
                            }
                            catch
                            {
                                // DB cũ chưa có MaCa trong HoaDon.
                                string sqlFallback = @"
SELECT
    COUNT(*) AS SoHoaDon,
    ISNULL(SUM(hd.TongTien), 0) AS DoanhThu
FROM HoaDon hd
WHERE hd.MaNV = @MaNV
  AND hd.NgayLap >= @GioBatDau
  AND hd.NgayLap <= @GioKetThuc
  AND hd.TrangThaiDonHang = N'Hoàn thành';";

                                using (SqlCommand cmd =
                                    new SqlCommand(sqlFallback, conn, tran))
                                {
                                    cmd.Parameters.Add(
                                        "@MaNV", SqlDbType.Int).Value = maNV;
                                    cmd.Parameters.Add(
                                        "@GioBatDau", SqlDbType.DateTime).Value = gioBatDau;
                                    cmd.Parameters.Add(
                                        "@GioKetThuc", SqlDbType.DateTime).Value = gioKetThuc;

                                    using (SqlDataReader rd = cmd.ExecuteReader())
                                    {
                                        if (rd.Read())
                                        {
                                            soHoaDonChot = Convert.ToInt32(rd["SoHoaDon"]);
                                            doanhThuChot = Convert.ToDecimal(rd["DoanhThu"]);
                                        }
                                    }
                                }
                            }

                            string sqlDongCa = @"
UPDATE CaLamViec
SET
    GioKetThuc = @GioKetThuc,
    DoanhThu = @DoanhThu,
    SoHoaDon = @SoHoaDon,
    TrangThai = N'Đã kết thúc'
WHERE MaCa = @MaCa
  AND MaNV = @MaNV
  AND TrangThai = N'Đang làm';";

                            int affected;

                            using (SqlCommand cmd =
                                new SqlCommand(sqlDongCa, conn, tran))
                            {
                                cmd.Parameters.Add(
                                    "@GioKetThuc", SqlDbType.DateTime).Value = gioKetThuc;
                                cmd.Parameters.Add(
                                    "@DoanhThu", SqlDbType.Decimal).Value = doanhThuChot;
                                cmd.Parameters["@DoanhThu"].Precision = 18;
                                cmd.Parameters["@DoanhThu"].Scale = 2;
                                cmd.Parameters.Add(
                                    "@SoHoaDon", SqlDbType.Int).Value = soHoaDonChot;
                                cmd.Parameters.Add(
                                    "@MaCa", SqlDbType.Int).Value = maCa;
                                cmd.Parameters.Add(
                                    "@MaNV", SqlDbType.Int).Value = maNV;

                                affected = cmd.ExecuteNonQuery();
                            }

                            if (affected == 0)
                                throw new Exception(
                                    "Ca làm việc không còn ở trạng thái Đang làm.");

                            tran.Commit();

                            // Xóa ca hiện tại khỏi Session.
                            Session.MaCa = 0;
                            DaChuyenCaThanhCong = true;

                            MessageBox.Show(
                                "Đã kết thúc ca thành công.\n\n" +
                                "CA" + maCa.ToString("D4") + "\n" +
                                "Doanh thu: " + doanhThuChot.ToString("N0") + " đ\n" +
                                "Số hóa đơn: " + soHoaDonChot + "\n\n" +
                                "Hệ thống sẽ chuyển sang màn hình khóa.",
                                "CHUYỂN CA THÀNH CÔNG",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        catch
                        {
                            try { tran.Rollback(); } catch { }
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể kết thúc ca.\n\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

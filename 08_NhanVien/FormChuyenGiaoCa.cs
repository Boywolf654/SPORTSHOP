using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormChuyenGiaoCa : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        private int maCa;
        private DateTime gioBatDau;
        private DateTime gioKetThucDuKien;
        private string tenCa = "";
        private Timer timer = new Timer();

        public FormChuyenGiaoCa()
        {
            InitializeComponent();

            timer.Interval = 1000;
            timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            CapNhatTrangThaiTheoGio();
        }

        private void FormChuyenGiaoCa_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
        }

        private void chkXacNhan_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatTrangThaiTheoGio();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormChuyenGiaoCa_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDuLieuCa();
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải ca hiện tại.\r\n\r\n" + ex.Message,
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDuLieuCa()
        {
            if (!QuanLyCa1.LayCaHienTai(
                out maCa,
                out gioBatDau,
                out gioKetThucDuKien,
                out tenCa,
                out _,
                out _))
            {
                lblCa.Text = "KHÔNG CÓ CA";
                lblNhanVien.Text = "—";
                lblMaNV.Text = "MÃ NV  —";
                lblBatDau.Text = "—";
                lblKetThucDuKien.Text = "—";
                lblThoiGian.Text = "—";
                lblDoanhThu.Text = "0 đ";
                lblSoHoaDon.Text = "0";
                lblCho.Text = "0";
                lblTrangThai.Text = "Chưa có ca đang làm.";
                btnChotCa.Enabled = false;
                return;
            }

            lblCa.Text = tenCa;
            lblMaNV.Text = "MÃ NV  " + Session.MaNV.ToString("D4");

            LoadTenNhanVien();
            CapNhatTongKet();
            CapNhatTrangThaiTheoGio();
        }

        private void LoadTenNhanVien()
        {
            try
            {
                using (SqlConnection conn = kt.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT HoTen FROM NhanVien WHERE MaNV=@MaNV", conn))
                    {
                        cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = Session.MaNV;
                        object v = cmd.ExecuteScalar();
                        lblNhanVien.Text = v == null || v == DBNull.Value ? "Nhân viên" : v.ToString();
                    }
                }
            }
            catch
            {
                lblNhanVien.Text = "Nhân viên";
            }
        }

        private void CapNhatTongKet()
        {
            lblBatDau.Text = gioBatDau.ToString("dd/MM/yyyy HH:mm:ss");
            lblKetThucDuKien.Text = gioKetThucDuKien.ToString("dd/MM/yyyy HH:mm");

            TimeSpan ts = DateTime.Now - gioBatDau;
            if (ts.TotalSeconds < 0) ts = TimeSpan.Zero;
            lblThoiGian.Text = string.Format("{0:00} giờ {1:00} phút", (int)ts.TotalHours, ts.Minutes);

            using (SqlConnection conn = kt.GetConnection())
            {
                conn.Open();

                string sql = @"
SELECT
    ISNULL(SUM(hd.TongTien),0) AS DoanhThu,
    COUNT(hd.MaHD) AS SoHoaDon
FROM HoaDon hd
WHERE hd.MaNV=@MaNV
  AND hd.NgayLap >= @BatDau
  AND hd.NgayLap <= GETDATE()
  AND hd.TrangThaiDonHang=N'Hoàn thành';";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = Session.MaNV;
                    cmd.Parameters.Add("@BatDau", SqlDbType.DateTime).Value = gioBatDau;

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            lblDoanhThu.Text = Convert.ToDecimal(rd["DoanhThu"]).ToString("N0") + " đ";
                            lblSoHoaDon.Text = Convert.ToInt32(rd["SoHoaDon"]).ToString();
                        }
                    }
                }

                LoadDoanhThuPhuongThuc(conn);
                LoadDonOnlineCho(conn);
            }
        }

        private void LoadDoanhThuPhuongThuc(SqlConnection conn)
        {
            lblTienMat.Text = "0 đ";
            lblThe.Text = "0 đ";
            lblChuyenKhoan.Text = "0 đ";
            lblVi.Text = "0 đ";

            string sql = @"
SELECT
    ISNULL(tt.PhuongThuc, N'Khác') AS PhuongThuc,
    ISNULL(SUM(hd.TongTien),0) AS Tong
FROM HoaDon hd
OUTER APPLY
(
    SELECT TOP 1 t.PhuongThuc
    FROM ThanhToan t
    WHERE t.MaHD=hd.MaHD
    ORDER BY t.MaTT DESC
) tt
WHERE hd.MaNV=@MaNV
  AND hd.NgayLap >= @BatDau
  AND hd.NgayLap <= GETDATE()
  AND hd.TrangThaiDonHang=N'Hoàn thành'
GROUP BY tt.PhuongThuc;";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = Session.MaNV;
                cmd.Parameters.Add("@BatDau", SqlDbType.DateTime).Value = gioBatDau;

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        string p = Convert.ToString(rd["PhuongThuc"]).Trim();
                        decimal v = Convert.ToDecimal(rd["Tong"]);

                        if (p.IndexOf("Tiền", StringComparison.OrdinalIgnoreCase) >= 0)
                            lblTienMat.Text = v.ToString("N0") + " đ";
                        else if (p.IndexOf("Thẻ", StringComparison.OrdinalIgnoreCase) >= 0)
                            lblThe.Text = v.ToString("N0") + " đ";
                        else if (p.IndexOf("Chuyển", StringComparison.OrdinalIgnoreCase) >= 0)
                            lblChuyenKhoan.Text = v.ToString("N0") + " đ";
                        else if (p.IndexOf("Ví", StringComparison.OrdinalIgnoreCase) >= 0)
                            lblVi.Text = v.ToString("N0") + " đ";
                    }
                }
            }
        }

        private void LoadDonOnlineCho(SqlConnection conn)
        {
            string sql = @"
SELECT COUNT(*)
FROM DonOnline
WHERE TrangThai IN (N'Chờ thanh toán', N'Đã thanh toán', N'NV tiếp nhận');";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                object v = cmd.ExecuteScalar();
                lblCho.Text = Convert.ToInt32(v).ToString();
            }
        }

        private void CapNhatTrangThaiTheoGio()
        {
            if (maCa <= 0)
                return;

            TimeSpan ts = DateTime.Now - gioBatDau;
            if (ts.TotalSeconds < 0)
                ts = TimeSpan.Zero;

            lblTrangThai.Text =
                "Ca linh hoạt đang hoạt động. Bạn có thể chuyển ca bất cứ lúc nào.";
            lblTrangThai.ForeColor = Color.FromArgb(20, 145, 75);

            btnChotCa.Enabled = chkXacNhan.Checked;
        }

        private void BtnChotCa_Click(object sender, EventArgs e)
        {
            if (!chkXacNhan.Checked)
                return;

            DialogResult confirm = MessageBox.Show(
                "Xác nhận chuyển giao ca ngay bây giờ?\r\n\r\n" +
                "Mã ca: " + maCa + "\r\n" +
                "Bắt đầu: " + gioBatDau.ToString("dd/MM/yyyy HH:mm:ss") + "\r\n" +
                "Doanh thu: " + lblDoanhThu.Text + "\r\n" +
                "Số hóa đơn: " + lblSoHoaDon.Text + "\r\n\r\n" +
                "Sau khi chốt, hệ thống sẽ mở một ca mới ngay lập tức.",
                "XÁC NHẬN CHUYỂN GIAO CA",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            string msg;
            if (!QuanLyCa1.ChotCaHienTai(out msg, true))
            {
                MessageBox.Show(
                    msg,
                    "Không thể chốt ca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                LoadDuLieuCa();
                return;
            }

            int maCaMoi;
            string msgMoCa;

            if (!QuanLyCa1.MoCaMoi(out maCaMoi, out msgMoCa))
            {
                MessageBox.Show(
                    msg + "\r\n\r\n" +
                    "Tuy nhiên không thể mở ca mới.\r\n" +
                    msgMoCa,
                    "Chuyển giao ca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            MessageBox.Show(
                msg + "\r\n\r\n" +
                "Đã mở ca mới.\r\n" +
                "Mã ca mới: " + maCaMoi + "\r\n" +
                "Thời điểm bắt đầu: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                "CHUYỂN GIAO CA THÀNH CÔNG",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

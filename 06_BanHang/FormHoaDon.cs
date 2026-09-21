using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    public partial class FormHoaDon : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private readonly int maHD;
        private DataTable dtChiTiet = new DataTable();

        public FormHoaDon() : this(0) { }

        public FormHoaDon(int maHoaDon)
        {
            maHD = maHoaDon;
            InitializeComponent();
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            btnDong.Click += btnDong_Click;
            btnInHoaDon.Click += btnInHoaDon_Click;
            LoadHoaDon();
        }

        private void LoadHoaDon()
        {
            try
            {
                string sql = @"
SELECT TOP 1
    hd.MaHD,
    hd.NgayLap,
    hd.TongTien,
    hd.TrangThaiDonHang,
    hd.MaKH,
    hd.MaNV,
    hd.MaDonOnline,
    kh.HoTen,
    kh.SDT,
    kh.Email,
    nv.HoTen AS TenNV,
    tt.PhuongThuc AS PhuongThucThanhToan
FROM HoaDon hd
LEFT JOIN KhachHang kh ON kh.MaKH = hd.MaKH
LEFT JOIN NhanVien nv ON nv.MaNV = hd.MaNV
OUTER APPLY
(
    SELECT TOP 1 PhuongThuc
    FROM ThanhToan
    WHERE MaHD = hd.MaHD
    ORDER BY MaTT DESC
) tt
WHERE hd.MaHD = @MaHD;";

                DataTable dt = kt.GetData(sql, new SqlParameter[] { new SqlParameter("@MaHD", maHD) });

                if (dt.Rows.Count == 0)
                    throw new Exception("Không tìm thấy hóa đơn.");

                DataRow r = dt.Rows[0];

                lblMaHD.Text = "HD" + maHD.ToString("D5");
                lblNgay.Text = Convert.ToDateTime(r["NgayLap"]).ToString("dd/MM/yyyy HH:mm");

                lblKhachHang.Text = r["HoTen"] == DBNull.Value
                    ? "Khách lẻ"
                    : r["HoTen"].ToString();

                lblSDT.Text = r["SDT"] == DBNull.Value ? "—" : r["SDT"].ToString();
                lblEmail.Text = r["Email"] == DBNull.Value ? "—" : r["Email"].ToString();

                lblNhanVien.Text = r["TenNV"] == DBNull.Value
                    ? "—"
                    : r["TenNV"].ToString();

                lblMaDon.Text = r["MaDonOnline"] == DBNull.Value
                    ? "Bán tại quầy"
                    : "DO" + Convert.ToInt32(r["MaDonOnline"]).ToString("D5");

                lblPhuongThuc.Text = r["PhuongThucThanhToan"] == DBNull.Value
                    ? "—"
                    : r["PhuongThucThanhToan"].ToString();

                decimal tongThanhToan = Convert.ToDecimal(r["TongTien"]);

                // ThanhToan hiện tại lưu phương thức + trạng thái,
                // còn số tiền thanh toán lấy trực tiếp từ HoaDon.TongTien.
                lblTongTien.Text = tongThanhToan.ToString("N0") + " đ";
                lblThanhToan.Text = tongThanhToan.ToString("N0") + " đ";

                string trangThai = r["TrangThaiDonHang"] == DBNull.Value
                    ? "Hoàn thành"
                    : r["TrangThaiDonHang"].ToString();

                lblTrangThai.Text = trangThai;
                lblTrangThai.BackColor =
                    trangThai.Equals("Đã hủy", StringComparison.OrdinalIgnoreCase)
                    ? Color.FromArgb(255, 231, 231)
                    : Color.FromArgb(226, 248, 235);

                lblTrangThai.ForeColor =
                    trangThai.Equals("Đã hủy", StringComparison.OrdinalIgnoreCase)
                    ? Color.FromArgb(190, 45, 45)
                    : Color.FromArgb(25, 145, 78);

                LoadChiTiet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải hóa đơn.\n\n" + ex.Message,
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChiTiet()
        {
            string sql = @"
SELECT
    cthd.MaBienThe,
    sp.TenSP,
    sz.TenSize,
    ms.TenMau,
    cthd.SoLuong,
    cthd.DonGia,
    cthd.SoLuong * cthd.DonGia AS ThanhTien
FROM ChiTietHoaDon cthd
INNER JOIN BienTheSanPham bt ON bt.MaBienThe = cthd.MaBienThe
INNER JOIN SanPham sp ON sp.MaSP = bt.MaSP
LEFT JOIN Size sz ON sz.MaSize = bt.MaSize
LEFT JOIN MauSac ms ON ms.MaMau = bt.MaMau
WHERE cthd.MaHD = @MaHD
ORDER BY cthd.MaBienThe;";

            dtChiTiet = kt.GetData(sql, new SqlParameter[] { new SqlParameter("@MaHD", maHD) });
            dgvSanPham.Rows.Clear();

            decimal tienHang = 0;
            int tongSL = 0;

            foreach (DataRow r in dtChiTiet.Rows)
            {
                int i = dgvSanPham.Rows.Add();

                int bt = Convert.ToInt32(r["MaBienThe"]);
                int sl = Convert.ToInt32(r["SoLuong"]);
                decimal donGia = Convert.ToDecimal(r["DonGia"]);
                decimal thanhTien = Convert.ToDecimal(r["ThanhTien"]);

                dgvSanPham.Rows[i].Cells["colSTT"].Value = i + 1;
                dgvSanPham.Rows[i].Cells["colSanPham"].Value = r["TenSP"].ToString();
                dgvSanPham.Rows[i].Cells["colBienThe"].Value = "BT" + bt.ToString("D4");
                dgvSanPham.Rows[i].Cells["colPhanLoai"].Value =
                    (r["TenSize"] == DBNull.Value ? "" : r["TenSize"].ToString())
                    + " / " +
                    (r["TenMau"] == DBNull.Value ? "" : r["TenMau"].ToString());
                dgvSanPham.Rows[i].Cells["colSL"].Value = sl;
                dgvSanPham.Rows[i].Cells["colDonGia"].Value = donGia.ToString("N0");
                dgvSanPham.Rows[i].Cells["colThanhTien"].Value = thanhTien.ToString("N0");

                tienHang += thanhTien;
                tongSL += sl;
            }

            lblTongSoLuong.Text = tongSL + " sản phẩm";
            lblTienHang.Text = tienHang.ToString("N0") + " đ";

            decimal tong = 0;
            if (dtChiTiet.Rows.Count > 0)
                tong = Convert.ToDecimal(dtChiTiet.Compute("SUM(ThanhTien)", ""));

            // Hóa đơn lưu TongTien là giá trị thanh toán cuối cùng.
            decimal thanhToan = 0;
            string sqlTong = "SELECT TongTien FROM HoaDon WHERE MaHD=@MaHD";
            DataTable dtt = kt.GetData(sqlTong, new SqlParameter[] { new SqlParameter("@MaHD", maHD) });
            if (dtt.Rows.Count > 0)
                thanhToan = Convert.ToDecimal(dtt.Rows[0]["TongTien"]);

            lblTienHang.Text = tong.ToString("N0") + " đ";
            lblTongTien.Text = thanhToan.ToString("N0") + " đ";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Mẫu hóa đơn đã sẵn sàng để in.\nCó thể nối PrintDocument vào bước tiếp theo.",
                "SPORTSHOP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}

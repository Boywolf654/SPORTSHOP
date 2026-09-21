using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    public partial class FormChiTietHoaDon : Form
    {
        private readonly KetNoiDuLieu kt =
            new KetNoiDuLieu();

        private readonly int maHD;

        private PrintDocument printDocument =
            new PrintDocument();

        private int dongDangIn = 0;

        public FormChiTietHoaDon(int maHoaDon)
        {
            maHD = maHoaDon;

            InitializeComponent();

            printDocument.BeginPrint +=
                printDocument_BeginPrint;

            printDocument.PrintPage +=
                printDocument_PrintPage;
        }

        private void FormChiTietHoaDon_Load(
            object sender,
            EventArgs e)
        {
            btnDong.Click += btnDong_Click;

            btnInHoaDon.Click +=
                btnInHoaDon_Click;

            LoadChiTiet();
        }

        private void LoadChiTiet()
        {
            try
            {
                LoadThongTinHoaDon();
                LoadSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải chi tiết hóa đơn.\r\n\r\n" +
                    ex.Message,
                    "SPORTSHOP - Chi tiết hóa đơn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadThongTinHoaDon()
        {
            string sql = @"
SELECT TOP 1

    hd.MaHD,
    hd.NgayLap,
    hd.TongTien,
    hd.TrangThaiDonHang,
    hd.MaKH,
    hd.MaNV,
    hd.MaVoucher,
    hd.MaDiaChi,
    hd.MaDonOnline,

    kh.HoTen,
    kh.SDT,
    kh.Email,

    dc.NguoiNhan,
    dc.SDT AS SDTNhan,
    dc.DiaChiCuThe,
    dc.TinhThanh,

    nv.HoTen AS TenNV,

    tt.PhuongThuc,
    tt.TrangThai AS TrangThaiThanhToan

FROM HoaDon hd

LEFT JOIN KhachHang kh
    ON kh.MaKH = hd.MaKH

LEFT JOIN DiaChiKhachHang dc
    ON dc.MaDiaChi = hd.MaDiaChi

LEFT JOIN NhanVien nv
    ON nv.MaNV = hd.MaNV

OUTER APPLY
(
    SELECT TOP 1
        t.PhuongThuc,
        t.TrangThai
    FROM ThanhToan t
    WHERE t.MaHD = hd.MaHD
    ORDER BY t.MaTT DESC
) tt

WHERE hd.MaHD = @MaHD;";

            SqlParameter[] p =
            {
                new SqlParameter(
                    "@MaHD",
                    maHD)
            };

            DataTable dt =
                kt.GetData(sql, p);

            if (dt.Rows.Count == 0)
            {
                throw new Exception(
                    "Không tìm thấy hóa đơn HD" +
                    maHD.ToString("D5") +
                    ".");
            }

            DataRow r =
                dt.Rows[0];

            lblMaHDValue.Text =
                "HD" + maHD.ToString("D5");

            lblMaDonValue.Text =
                r["MaDonOnline"] == DBNull.Value
                    ? "Bán tại quầy"
                    : "DO" +
                      Convert.ToInt32(
                          r["MaDonOnline"])
                      .ToString("D5");

            lblNgayValue.Text =
                Convert.ToDateTime(
                    r["NgayLap"])
                .ToString(
                    "dd/MM/yyyy HH:mm");

            lblKhachValue.Text =
                r["HoTen"] == DBNull.Value
                    ? "Khách lẻ"
                    : r["HoTen"].ToString();

            lblSDTValue.Text =
                r["SDT"] == DBNull.Value
                    ? "—"
                    : r["SDT"].ToString();

            lblEmailValue.Text =
                r["Email"] == DBNull.Value
                    ? "—"
                    : r["Email"].ToString();

            string diaChi = "";

            if (r["NguoiNhan"] != DBNull.Value)
            {
                diaChi +=
                    r["NguoiNhan"].ToString();
            }

            if (r["SDTNhan"] != DBNull.Value)
            {
                if (!string.IsNullOrWhiteSpace(diaChi))
                    diaChi += " - ";

                diaChi +=
                    r["SDTNhan"].ToString();
            }

            if (r["DiaChiCuThe"] != DBNull.Value)
            {
                if (!string.IsNullOrWhiteSpace(diaChi))
                    diaChi += "\r\n";

                diaChi +=
                    r["DiaChiCuThe"].ToString();
            }

            if (r["TinhThanh"] != DBNull.Value &&
                !string.IsNullOrWhiteSpace(
                    r["TinhThanh"].ToString()))
            {
                if (!string.IsNullOrWhiteSpace(diaChi))
                    diaChi += ", ";

                diaChi +=
                    r["TinhThanh"].ToString();
            }

            lblDiaChiValue.Text =
                string.IsNullOrWhiteSpace(diaChi)
                    ? "—"
                    : diaChi;

            lblNhanVienValue.Text =
                r["TenNV"] == DBNull.Value
                    ? "—"
                    : r["TenNV"].ToString();

            lblPhuongThucValue.Text =
                r["PhuongThuc"] == DBNull.Value
                    ? "—"
                    : r["PhuongThuc"].ToString();

            decimal tong =
                Convert.ToDecimal(
                    r["TongTien"]);

            lblTongThanhToanValue.Text =
                tong.ToString("N0") +
                " đ";

            lblSoTienValue.Text =
                tong.ToString("N0") +
                " đ";

            string trangThai =
                r["TrangThaiDonHang"] ==
                DBNull.Value
                    ? "Hoàn thành"
                    : r["TrangThaiDonHang"]
                        .ToString();

            lblTrangThaiValue.Text =
                trangThai;

            if (trangThai.Equals(
                "Đã hủy",
                StringComparison.OrdinalIgnoreCase))
            {
                lblTrangThaiValue.ForeColor =
                    Color.FromArgb(
                        194,
                        45,
                        45);
            }
            else
            {
                lblTrangThaiValue.ForeColor =
                    Color.FromArgb(
                        26,
                        145,
                        78);
            }
        }

        private void LoadSanPham()
        {
            string sql = @"
SELECT
    cthd.MaBienThe,
    sp.MaSP,
    sp.TenSP,

    sz.TenSize,
    ms.TenMau,

    cthd.SoLuong,
    cthd.DonGia,

    cthd.SoLuong *
    cthd.DonGia AS ThanhTien

FROM ChiTietHoaDon cthd

INNER JOIN BienTheSanPham bt
    ON bt.MaBienThe =
       cthd.MaBienThe

INNER JOIN SanPham sp
    ON sp.MaSP =
       bt.MaSP

LEFT JOIN Size sz
    ON sz.MaSize =
       bt.MaSize

LEFT JOIN MauSac ms
    ON ms.MaMau =
       bt.MaMau

WHERE cthd.MaHD = @MaHD

ORDER BY cthd.MaBienThe;";

            SqlParameter[] p =
            {
                new SqlParameter(
                    "@MaHD",
                    maHD)
            };

            DataTable dt =
                kt.GetData(sql, p);

            dgvChiTiet.Rows.Clear();

            decimal tienHang = 0;
            int tongSL = 0;

            foreach (DataRow r
                in dt.Rows)
            {
                int index =
                    dgvChiTiet.Rows.Add();

                int maBienThe =
                    Convert.ToInt32(
                        r["MaBienThe"]);

                int soLuong =
                    Convert.ToInt32(
                        r["SoLuong"]);

                decimal donGia =
                    Convert.ToDecimal(
                        r["DonGia"]);

                decimal thanhTien =
                    Convert.ToDecimal(
                        r["ThanhTien"]);

                dgvChiTiet.Rows[index]
                    .Cells["colSTT"]
                    .Value =
                    index + 1;

                dgvChiTiet.Rows[index]
                    .Cells["colMaBienThe"]
                    .Value =
                    "BT" +
                    maBienThe.ToString("D4");

                dgvChiTiet.Rows[index]
                    .Cells["colMaSP"]
                    .Value =
                    "SP" +
                    Convert.ToInt32(
                        r["MaSP"])
                    .ToString("D3");

                dgvChiTiet.Rows[index]
                    .Cells["colSanPham"]
                    .Value =
                    r["TenSP"].ToString();

                dgvChiTiet.Rows[index]
                    .Cells["colSize"]
                    .Value =
                    r["TenSize"] ==
                    DBNull.Value
                        ? "—"
                        : r["TenSize"]
                            .ToString();

                dgvChiTiet.Rows[index]
                    .Cells["colMau"]
                    .Value =
                    r["TenMau"] ==
                    DBNull.Value
                        ? "—"
                        : r["TenMau"]
                            .ToString();

                dgvChiTiet.Rows[index]
                    .Cells["colSL"]
                    .Value =
                    soLuong;

                dgvChiTiet.Rows[index]
                    .Cells["colDonGia"]
                    .Value =
                    donGia.ToString("N0") +
                    " đ";

                dgvChiTiet.Rows[index]
                    .Cells["colThanhTien"]
                    .Value =
                    thanhTien.ToString("N0") +
                    " đ";

                tienHang +=
                    thanhTien;

                tongSL +=
                    soLuong;
            }

            lblTongSL.Text =
                tongSL +
                " sản phẩm";

            lblTienHangValue.Text =
                tienHang.ToString("N0") +
                " đ";

            decimal tongThanhToan = 0;

            string sqlTong = @"
SELECT TongTien
FROM HoaDon
WHERE MaHD = @MaHD;";

            SqlParameter[] pTong =
            {
    new SqlParameter("@MaHD", maHD)
};

            DataTable dtTong =
                kt.GetData(sqlTong, pTong);

            if (dtTong.Rows.Count > 0)
            {
                tongThanhToan =
                    Convert.ToDecimal(
                        dtTong.Rows[0]["TongTien"]);
            }

            lblGiamValue.Text = "0 đ";
            lblShipValue.Text = "0 đ";

            lblTongThanhToanValue.Text =
                tongThanhToan.ToString("N0") + " đ";
        }

        private void btnDong_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        // =========================================================
        // IN HÓA ĐƠN
        // =========================================================

        private void btnInHoaDon_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using (PrintPreviewDialog preview =
                    new PrintPreviewDialog())
                {
                    preview.Document =
                        printDocument;

                    preview.Width = 1000;
                    preview.Height = 700;

                    preview.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở bản xem trước hóa đơn.\r\n\r\n" +
                    ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void printDocument_BeginPrint(
            object sender,
            PrintEventArgs e)
        {
            dongDangIn = 0;
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Display;

            using (Font title = new Font("Arial", 18, FontStyle.Bold))
            using (Font bold = new Font("Arial", 8.5F, FontStyle.Bold))
            using (Font normal = new Font("Arial", 8.5F, FontStyle.Regular))
            using (Font small = new Font("Arial", 8F, FontStyle.Regular))
            {
                float x = 45;
                float y = 38;
                float right = 790;

                g.DrawString("SPORTSHOP", title, Brushes.Black, x, y);
                y += 30;
                g.DrawString("HÓA ĐƠN BÁN HÀNG", bold, Brushes.Black, x, y);
                y += 23;
                g.DrawString("Mã hóa đơn: HD" + maHD.ToString("D5"), normal, Brushes.Black, x, y);
                y += 18;
                g.DrawString("Khách hàng: " + lblKhachValue.Text, normal, Brushes.Black, x, y);
                y += 18;
                g.DrawString("Nhân viên: " + lblNhanVienValue.Text, normal, Brushes.Black, x, y);
                y += 18;
                g.DrawString("Ngày lập: " + lblNgayValue.Text, normal, Brushes.Black, x, y);
                y += 18;
                g.DrawString("Thanh toán: " + lblPhuongThucValue.Text, normal, Brushes.Black, x, y);
                y += 25;

                g.DrawLine(Pens.Black, x, y, right, y);
                y += 10;

                float cStt = x;
                float cSp = x + 32;
                float cSize = x + 330;
                float cMau = x + 380;
                float cSl = x + 445;
                float cGia = x + 490;
                float cTien = x + 620;
                float wSp = cSize - cSp - 5;
                float wGia = cTien - cGia - 8;
                float wTien = right - cTien;

                g.DrawString("STT", bold, Brushes.Black, cStt, y);
                g.DrawString("Sản phẩm", bold, Brushes.Black, cSp, y);
                g.DrawString("Size", bold, Brushes.Black, cSize, y);
                g.DrawString("Màu", bold, Brushes.Black, cMau, y);
                g.DrawString("SL", bold, Brushes.Black, cSl, y);
                g.DrawString("Đơn giá", bold, Brushes.Black, cGia, y);
                g.DrawString("Thành tiền", bold, Brushes.Black, cTien, y);
                y += 20;
                g.DrawLine(Pens.Gray, x, y, right, y);
                y += 7;

                for (; dongDangIn < dgvChiTiet.Rows.Count; dongDangIn++)
                {
                    DataGridViewRow row = dgvChiTiet.Rows[dongDangIn];
                    string stt = Convert.ToString(row.Cells["colSTT"].Value);
                    string tenSP = Convert.ToString(row.Cells["colSanPham"].Value);
                    string size = Convert.ToString(row.Cells["colSize"].Value);
                    string mau = Convert.ToString(row.Cells["colMau"].Value);
                    string sl = Convert.ToString(row.Cells["colSL"].Value);
                    string donGia = Convert.ToString(row.Cells["colDonGia"].Value);
                    string thanhTien = Convert.ToString(row.Cells["colThanhTien"].Value);

                    SizeF measured = g.MeasureString(tenSP, small, new SizeF(wSp, 1000));
                    float rowHeight = Math.Max(19, measured.Height + 3);

                    if (y + rowHeight > e.MarginBounds.Bottom - 100)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Near,
                        Trimming = StringTrimming.EllipsisWord
                    };
                    g.DrawString(stt, small, Brushes.Black, new RectangleF(cStt, y, 28, rowHeight), sf);
                    g.DrawString(tenSP, small, Brushes.Black, new RectangleF(cSp, y, wSp, rowHeight), sf);
                    g.DrawString(size, small, Brushes.Black, new RectangleF(cSize, y, 45, rowHeight), sf);
                    g.DrawString(mau, small, Brushes.Black, new RectangleF(cMau, y, 60, rowHeight), sf);
                    g.DrawString(sl, small, Brushes.Black, new RectangleF(cSl, y, 38, rowHeight), sf);
                    g.DrawString(donGia, small, Brushes.Black, new RectangleF(cGia, y, wGia, rowHeight), sf);
                    g.DrawString(thanhTien, small, Brushes.Black, new RectangleF(cTien, y, wTien, rowHeight), sf);
                    sf.Dispose();

                    y += rowHeight + 4;
                }

                g.DrawLine(Pens.Black, x, y, right, y);
                y += 15;

                float labelX = cGia - 90;
                g.DrawString("Tạm tính:", bold, Brushes.Black, labelX, y);
                g.DrawString(lblTienHangValue.Text, bold, Brushes.Black, cTien, y);
                y += 20;
                g.DrawString("Giảm giá:", normal, Brushes.Black, labelX, y);
                g.DrawString(lblGiamValue.Text, normal, Brushes.Black, cTien, y);
                y += 20;
                g.DrawString("Phí vận chuyển:", normal, Brushes.Black, labelX, y);
                g.DrawString(lblShipValue.Text, normal, Brushes.Black, cTien, y);
                y += 24;
                g.DrawString("TỔNG THANH TOÁN:", bold, Brushes.Black, cSize + 30, y);
                g.DrawString(lblTongThanhToanValue.Text, bold, Brushes.Black, cTien, y);
                y += 40;
                g.DrawString("Cảm ơn quý khách đã mua hàng!", normal, Brushes.Black, x + 230, y);

                e.HasMorePages = false;
            }
        }
    }
}
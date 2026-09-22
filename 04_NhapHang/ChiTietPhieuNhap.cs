using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace SPORTSHOP
{
    public partial class ChiTietPhieuNhap : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private readonly int maPN;

        public ChiTietPhieuNhap(int maPN)
        {
            InitializeComponent();
            this.maPN = maPN;
            Load += ChiTietPhieuNhap_Load;
            btnDong.Click += btnDong_Click;
        }

        private void ChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadThongTinPhieu();
            LoadChiTietHangHoa();
        }

        private void LoadThongTinPhieu()
        {
            string sql = @"
SELECT TOP 1
    pn.MaPN,
    pn.NgayNhap,
    nv.HoTen AS TenNhanVien,
    ncc.TenNCC,
    k.TenKho,
    pn.TrangThai
FROM PhieuNhap pn
INNER JOIN NhanVien nv ON nv.MaNV = pn.MaNV
INNER JOIN NhaCungCap ncc ON ncc.MaNCC = pn.MaNCC
LEFT JOIN Kho k ON k.MaKho = pn.MaKho
WHERE pn.MaPN = @MaPN";

            DataTable dt = kt.GetData(sql, new SqlParameter[]
            {
                new SqlParameter("@MaPN", maPN)
            });

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy phiếu nhập PN" + maPN.ToString("D4") + ".",
                    "Không tìm thấy phiếu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                Close();
                return;
            }

            DataRow r = dt.Rows[0];

            lblMaPhieu.Text = "PN" + Convert.ToInt32(r["MaPN"]).ToString("D4");
            lblNgayNhap.Text = r["NgayNhap"] == DBNull.Value
                ? "-"
                : Convert.ToDateTime(r["NgayNhap"]).ToString("dd/MM/yyyy HH:mm");
            lblNhanVien.Text = r["TenNhanVien"]?.ToString() ?? "-";
            lblNhaCungCap.Text = r["TenNCC"]?.ToString() ?? "-";
            lblKho.Text = r["TenKho"]?.ToString() ?? "Chưa xác định";
            HienThiTrangThai(r["TrangThai"]?.ToString() ?? "");
        }

        private void LoadChiTietHangHoa()
        {
            string sql = @"
SELECT
    ct.MaBienThe,
    ISNULL(bt.SKU, N'Không có SKU') AS SKU,
    ISNULL(sp.TenSP, N'Không xác định') AS TenSP,
    ISNULL(sz.TenSize, N'') AS TenSize,
    ISNULL(ms.TenMau, N'') AS TenMau,
    ct.SoLuong,
    ct.DonGia,
    ct.SoLuong * ct.DonGia AS ThanhTien
FROM ChiTietPhieuNhap ct
LEFT JOIN BienTheSanPham bt ON bt.MaBienThe = ct.MaBienThe
LEFT JOIN SanPham sp ON sp.MaSP = bt.MaSP
LEFT JOIN Size sz ON sz.MaSize = bt.MaSize
LEFT JOIN MauSac ms ON ms.MaMau = bt.MaMau
WHERE ct.MaPN = @MaPN
ORDER BY sp.TenSP, bt.SKU";

            DataTable dt = kt.GetData(sql, new SqlParameter[]
            {
                new SqlParameter("@MaPN", maPN)
            });

            dgvChiTiet.DataSource = dt;
            DinhDangBang();

            int tongSoLuong = 0;
            decimal tongTien = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["SoLuong"] != DBNull.Value)
                    tongSoLuong += Convert.ToInt32(row["SoLuong"]);

                if (row["ThanhTien"] != DBNull.Value)
                    tongTien += Convert.ToDecimal(row["ThanhTien"]);
            }

            lblTongSoLuong.Text = "Tổng số lượng: " + tongSoLuong.ToString("N0");
            lblTongTien.Text = "Tổng tiền nhập: " + tongTien.ToString("N0") + " VNĐ";
            lblSoDong.Text = "Số mặt hàng: " + dt.Rows.Count.ToString("N0");
        }

        private void DinhDangBang()
        {
            if (dgvChiTiet.Columns["MaBienThe"] != null)
                dgvChiTiet.Columns["MaBienThe"].Visible = false;

            if (dgvChiTiet.Columns["SKU"] != null)
                dgvChiTiet.Columns["SKU"].HeaderText = "SKU";

            if (dgvChiTiet.Columns["TenSP"] != null)
                dgvChiTiet.Columns["TenSP"].HeaderText = "Sản phẩm";

            if (dgvChiTiet.Columns["TenSize"] != null)
                dgvChiTiet.Columns["TenSize"].HeaderText = "Size";

            if (dgvChiTiet.Columns["TenMau"] != null)
                dgvChiTiet.Columns["TenMau"].HeaderText = "Màu";

            if (dgvChiTiet.Columns["SoLuong"] != null)
            {
                dgvChiTiet.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvChiTiet.Columns["SoLuong"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvChiTiet.Columns["DonGia"] != null)
            {
                dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }

            if (dgvChiTiet.Columns["ThanhTien"] != null)
            {
                dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }

            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void HienThiTrangThai(string trangThai)
        {
            lblTrangThai.Text = string.IsNullOrWhiteSpace(trangThai)
                ? "Không xác định"
                : trangThai;

            switch (trangThai)
            {
                case "Chờ duyệt":
                    lblTrangThai.FillColor = Color.FromArgb(255, 243, 205);
                    lblTrangThai.ForeColor = Color.FromArgb(180, 120, 0);
                    break;

                case "Chờ xuất kho":
                    lblTrangThai.FillColor = Color.FromArgb(220, 235, 255);
                    lblTrangThai.ForeColor = Color.FromArgb(45, 90, 170);
                    break;

                case "Đã xuất kho":
                    lblTrangThai.FillColor = Color.FromArgb(225, 235, 255);
                    lblTrangThai.ForeColor = Color.FromArgb(40, 90, 160);
                    break;

                case "Hoàn tất":
                    lblTrangThai.FillColor = Color.FromArgb(220, 245, 228);
                    lblTrangThai.ForeColor = Color.FromArgb(35, 130, 70);
                    break;

                case "Đã hủy":
                    lblTrangThai.FillColor = Color.FromArgb(252, 225, 225);
                    lblTrangThai.ForeColor = Color.FromArgb(190, 50, 50);
                    break;

                default:
                    lblTrangThai.FillColor = Color.FromArgb(235, 235, 240);
                    lblTrangThai.ForeColor = Color.DimGray;
                    break;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

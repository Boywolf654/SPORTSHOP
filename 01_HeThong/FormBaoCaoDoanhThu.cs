using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormBaoCaoDoanhThu : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private DataTable dtDoanhThu = new DataTable();
        private DataTable dtTopSP = new DataTable();

        public FormBaoCaoDoanhThu()
        {
            InitializeComponent();
            Load += FormBaoCaoDoanhThu_Load;
            btnLoc.Click += btnLoc_Click;
            btnHomNay.Click += (s, e) => { dtpTu.Value = DateTime.Today; dtpDen.Value = DateTime.Today; LoadBaoCao(); };
            btnThang.Click += (s, e) => { dtpTu.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); dtpDen.Value = DateTime.Today; LoadBaoCao(); };
            btnQuy.Click += (s, e) => { int q = (DateTime.Today.Month - 1) / 3; dtpTu.Value = new DateTime(DateTime.Today.Year, q * 3 + 1, 1); dtpDen.Value = DateTime.Today; LoadBaoCao(); };
            btnNam.Click += (s, e) => { dtpTu.Value = new DateTime(DateTime.Today.Year, 1, 1); dtpDen.Value = DateTime.Today; LoadBaoCao(); };
            btnXuat.Click += btnXuat_Click;
        }

        private void FormBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            dtpTu.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDen.Value = DateTime.Today;
            LoadBaoCao();
        }

        private void LoadBaoCao()
        {
            if (dtpTu.Value.Date > dtpDen.Value.Date) { MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc."); return; }
            try
            {
                DateTime from = dtpTu.Value.Date, to = dtpDen.Value.Date.AddDays(1);
                object revenue = kt.ExecuteScalar(@"SELECT ISNULL(SUM(TongTien),0) FROM HoaDon WHERE NgayLap>=@Tu AND NgayLap<@Den AND TrangThaiDonHang IN (N'Hoàn thành',N'Đang giao')", new[] { new SqlParameter("@Tu", from), new SqlParameter("@Den", to) });
                object orders = kt.ExecuteScalar(@"SELECT COUNT(*) FROM HoaDon WHERE NgayLap>=@Tu AND NgayLap<@Den AND TrangThaiDonHang IN (N'Hoàn thành',N'Đang giao')", new[] { new SqlParameter("@Tu", from), new SqlParameter("@Den", to) });
                object items = kt.ExecuteScalar(@"SELECT ISNULL(SUM(ct.SoLuong),0) FROM ChiTietHoaDon ct INNER JOIN HoaDon hd ON hd.MaHD=ct.MaHD WHERE hd.NgayLap>=@Tu AND hd.NgayLap<@Den AND hd.TrangThaiDonHang IN (N'Hoàn thành',N'Đang giao')", new[] { new SqlParameter("@Tu", from), new SqlParameter("@Den", to) });
                object customers = kt.ExecuteScalar(@"SELECT COUNT(DISTINCT MaKH) FROM HoaDon WHERE NgayLap>=@Tu AND NgayLap<@Den AND MaKH IS NOT NULL AND TrangThaiDonHang IN (N'Hoàn thành',N'Đang giao')", new[] { new SqlParameter("@Tu", from), new SqlParameter("@Den", to) });
                lblDoanhThu.Text = Convert.ToDecimal(revenue).ToString("N0") + " đ";
                lblSoHoaDon.Text = Convert.ToInt32(orders).ToString("N0");
                lblSoSanPham.Text = Convert.ToInt32(items).ToString("N0");
                lblSoKhach.Text = Convert.ToInt32(customers).ToString("N0");

                dtDoanhThu = kt.GetData(@"
SELECT CAST(hd.NgayLap AS DATE) AS Ngay,
       COUNT(*) AS SoHoaDon,
       ISNULL(SUM(hd.TongTien),0) AS DoanhThu,
       ISNULL(SUM(ct.SoLuong),0) AS SoSanPham
FROM HoaDon hd
LEFT JOIN ChiTietHoaDon ct ON ct.MaHD=hd.MaHD
WHERE hd.NgayLap>=@Tu AND hd.NgayLap<@Den
  AND hd.TrangThaiDonHang IN (N'Hoàn thành',N'Đang giao')
GROUP BY CAST(hd.NgayLap AS DATE)
ORDER BY Ngay DESC", new[] { new SqlParameter("@Tu", from), new SqlParameter("@Den", to) });
                dgvNgay.DataSource = dtDoanhThu;
                if (dgvNgay.Columns.Count > 0) { dgvNgay.Columns["Ngay"].HeaderText = "Ngày"; dgvNgay.Columns["SoHoaDon"].HeaderText = "Hóa đơn"; dgvNgay.Columns["DoanhThu"].HeaderText = "Doanh thu"; dgvNgay.Columns["SoSanPham"].HeaderText = "Sản phẩm"; dgvNgay.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy"; dgvNgay.Columns["DoanhThu"].DefaultCellStyle.Format = "N0"; }

                dtTopSP = kt.GetData(@"
SELECT TOP 20 sp.MaSP,sp.TenSP,SUM(ct.SoLuong) AS SoLuongBan,SUM(ct.SoLuong*ct.DonGia) AS DoanhThu
FROM ChiTietHoaDon ct
INNER JOIN HoaDon hd ON hd.MaHD=ct.MaHD
INNER JOIN BienTheSanPham bt ON bt.MaBienThe=ct.MaBienThe
INNER JOIN SanPham sp ON sp.MaSP=bt.MaSP
WHERE hd.NgayLap>=@Tu AND hd.NgayLap<@Den
  AND hd.TrangThaiDonHang IN (N'Hoàn thành',N'Đang giao')
GROUP BY sp.MaSP,sp.TenSP
ORDER BY SoLuongBan DESC,DoanhThu DESC", new[] { new SqlParameter("@Tu", from), new SqlParameter("@Den", to) });
                dgvTopSP.DataSource = dtTopSP;
                if (dgvTopSP.Columns.Count > 0) { dgvTopSP.Columns["MaSP"].HeaderText = "Mã SP"; dgvTopSP.Columns["TenSP"].HeaderText = "Sản phẩm"; dgvTopSP.Columns["SoLuongBan"].HeaderText = "SL bán"; dgvTopSP.Columns["DoanhThu"].HeaderText = "Doanh thu"; dgvTopSP.Columns["DoanhThu"].DefaultCellStyle.Format = "N0"; }
            }
            catch (Exception ex) { MessageBox.Show("Không thể tải báo cáo doanh thu.\n\n" + ex.Message, "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnLoc_Click(object sender, EventArgs e) { LoadBaoCao(); }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "CSV (*.csv)|*.csv"; dlg.FileName = "BaoCaoDoanhThu_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("BÁO CÁO DOANH THU");
                    sb.AppendLine("Từ;" + dtpTu.Value.ToString("dd/MM/yyyy") + ";Đến;" + dtpDen.Value.ToString("dd/MM/yyyy"));
                    sb.AppendLine("Tổng doanh thu;" + lblDoanhThu.Text + ";Số hóa đơn;" + lblSoHoaDon.Text + ";Số sản phẩm;" + lblSoSanPham.Text + ";Số khách;" + lblSoKhach.Text);
                    sb.AppendLine(); sb.AppendLine("THEO NGÀY"); sb.AppendLine("Ngày;Hóa đơn;Doanh thu;Sản phẩm");
                    foreach (DataRow r in dtDoanhThu.Rows) sb.AppendLine(Convert.ToDateTime(r["Ngay"]).ToString("dd/MM/yyyy") + ";" + r["SoHoaDon"] + ";" + Convert.ToDecimal(r["DoanhThu"]).ToString("0.##") + ";" + r["SoSanPham"]);
                    sb.AppendLine(); sb.AppendLine("TOP SẢN PHẨM"); sb.AppendLine("Mã SP;Tên sản phẩm;SL bán;Doanh thu");
                    foreach (DataRow r in dtTopSP.Rows) sb.AppendLine(r["MaSP"] + ";" + r["TenSP"] + ";" + r["SoLuongBan"] + ";" + Convert.ToDecimal(r["DoanhThu"]).ToString("0.##"));
                    File.WriteAllText(dlg.FileName, "\uFEFF" + sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Đã xuất báo cáo CSV.", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("Không thể xuất báo cáo.\n\n" + ex.Message); }
            }
        }
    }
}

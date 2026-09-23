using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SPORTSHOP._06_BanHang;

namespace SPORTSHOP
{
    public partial class FormBaoCaoDoanhThu : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private DataTable dtHoaDon = new DataTable();
        private DataTable dtTopSP = new DataTable();
        private bool dangNapCa = false;

        public FormBaoCaoDoanhThu()
        {
            InitializeComponent();

            Load += FormBaoCaoDoanhThu_Load;
            btnLoc.Click += btnLoc_Click;
            btnHomNay.Click += (s, e) =>
            {
                dtpTu.Value = DateTime.Today;
                dtpDen.Value = DateTime.Today;
                LoadBaoCao();
            };
            btnThang.Click += (s, e) =>
            {
                dtpTu.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                dtpDen.Value = DateTime.Today;
                LoadBaoCao();
            };
            btnQuy.Click += (s, e) =>
            {
                int q = (DateTime.Today.Month - 1) / 3;
                dtpTu.Value = new DateTime(DateTime.Today.Year, q * 3 + 1, 1);
                dtpDen.Value = DateTime.Today;
                LoadBaoCao();
            };
            btnNam.Click += (s, e) =>
            {
                dtpTu.Value = new DateTime(DateTime.Today.Year, 1, 1);
                dtpDen.Value = DateTime.Today;
                LoadBaoCao();
            };
            btnXuat.Click += btnXuat_Click;
            dgvNgay.CellClick += dgvNgay_CellClick;
            dtpTu.ValueChanged += BoLocNgayThayDoi;
            dtpDen.ValueChanged += BoLocNgayThayDoi;
        }

        private void FormBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            dtpTu.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDen.Value = DateTime.Today;
            CauHinhGrid();
            LoadBaoCao();
        }

        private void CauHinhGrid()
        {
            foreach (DataGridView dgv in new[] { dgvNgay, dgvTopSP })
            {
                dgv.ReadOnly = true;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.AllowUserToResizeRows = false;
                dgv.MultiSelect = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.RowHeadersVisible = false;
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor =
                    System.Drawing.Color.FromArgb(38, 42, 48);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font =
                    new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
                dgv.ColumnHeadersHeight = 40;
                dgv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
                dgv.DefaultCellStyle.SelectionBackColor =
                    System.Drawing.Color.FromArgb(74, 31, 36);
                dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                dgv.GridColor = System.Drawing.Color.FromArgb(58, 62, 70);
            }
        }

        private void LoadDanhSachCa(DateTime from, DateTime to)
        {
            dangNapCa = true;
            try
            {
                DataTable dtCa = kt.GetData(@"
SELECT
    c.MaCa,
    c.MaNV,
    c.GioBatDau,
    c.GioKetThuc,
    N'CA' + RIGHT('0000' + CAST(c.MaCa AS varchar(10)), 4)
        + N' - ' + ISNULL(nv.HoTen, N'Nhân viên')
        + N' | ' + CONVERT(varchar(16), c.GioBatDau, 103)
        + N' ' + CONVERT(varchar(5), c.GioBatDau, 108) AS HienThi
FROM CaLamViec c
LEFT JOIN NhanVien nv ON nv.MaNV = c.MaNV
WHERE c.GioBatDau >= @Tu
  AND c.GioBatDau < @Den
ORDER BY c.GioBatDau DESC",
                    new[]
                    {
                        new SqlParameter("@Tu", from),
                        new SqlParameter("@Den", to)
                    });

                DataTable source = dtCa.Clone();
                DataRow all = source.NewRow();
                all["MaCa"] = 0;
                all["MaNV"] = 0;
                all["GioBatDau"] = from;
                all["GioKetThuc"] = to;
                all["HienThi"] = "TẤT CẢ CÁC CA";
                source.Rows.Add(all);

                foreach (DataRow r in dtCa.Rows)
                    source.ImportRow(r);

                cboCa.DisplayMember = "HienThi";
                cboCa.ValueMember = "MaCa";
                cboCa.DataSource = source;
                cboCa.SelectedValue = 0;
            }
            finally
            {
                dangNapCa = false;
            }
        }

        private bool LayBoLocCa(out int maCa, out int maNV, out DateTime gioVao, out DateTime gioRa)
        {
            maCa = 0;
            maNV = 0;
            gioVao = dtpTu.Value.Date;
            gioRa = dtpDen.Value.Date.AddDays(1);

            if (cboCa.SelectedValue == null)
                return true;

            if (!int.TryParse(Convert.ToString(cboCa.SelectedValue), out maCa))
                maCa = 0;

            if (maCa <= 0)
                return true;

            DataRowView row = cboCa.SelectedItem as DataRowView;
            if (row == null)
                return true;

            maNV = Convert.ToInt32(row["MaNV"]);
            gioVao = Convert.ToDateTime(row["GioBatDau"]);
            gioRa = row["GioKetThuc"] == DBNull.Value
                ? dtpDen.Value.Date.AddDays(1)
                : Convert.ToDateTime(row["GioKetThuc"]);

            return true;
        }

        private SqlParameter[] TaoParams(int maCa, DateTime from, DateTime to, int maNV, DateTime gioVao, DateTime gioRa)
        {
            if (maCa > 0)
            {
                return new[]
                {
                    new SqlParameter("@Tu", from),
                    new SqlParameter("@Den", to),
                    new SqlParameter("@MaCa", maCa),
                    new SqlParameter("@MaNV", maNV),
                    new SqlParameter("@GioVao", gioVao),
                    new SqlParameter("@GioRa", gioRa)
                };
            }

            return new[]
            {
                new SqlParameter("@Tu", from),
                new SqlParameter("@Den", to)
            };
        }

        private void BoLocNgayThayDoi(object sender, EventArgs e)
        {
            if (dtpTu.Value.Date > dtpDen.Value.Date)
                return;

            LoadBaoCao();
        }

        private void LoadBaoCao()
        {
            if (dtpTu.Value.Date > dtpDen.Value.Date)
            {
                MessageBox.Show(
                    "Ngày bắt đầu không được lớn hơn ngày kết thúc.",
                    "Báo cáo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DateTime from = dtpTu.Value.Date;
                DateTime to = dtpDen.Value.Date.AddDays(1);

                LoadDanhSachCa(from, to);

                int maCa, maNV;
                DateTime gioVao, gioRa;
                LayBoLocCa(out maCa, out maNV, out gioVao, out gioRa);

                string filterCa = "";
                if (maCa > 0)
                {
                    // Hóa đơn mới có MaCa sẽ lọc trực tiếp.
                    // Hóa đơn cũ chưa có MaCa được đối chiếu theo NV + thời gian ca.
                    filterCa = @"
  AND (
        hd.MaCa = @MaCa
        OR (
            hd.MaCa IS NULL
            AND hd.MaNV = @MaNV
            AND hd.NgayLap >= @GioVao
            AND hd.NgayLap <= @GioRa
        )
      )";
                }

                SqlParameter[] pBase =
                    maCa > 0
                    ? new[]
                    {
                        new SqlParameter("@Tu", from),
                        new SqlParameter("@Den", to),
                        new SqlParameter("@MaCa", maCa),
                        new SqlParameter("@MaNV", maNV),
                        new SqlParameter("@GioVao", gioVao),
                        new SqlParameter("@GioRa", gioRa)
                    }
                    : new[]
                    {
                        new SqlParameter("@Tu", from),
                        new SqlParameter("@Den", to)
                    };

                string sqlSummary = @"
SELECT
    ISNULL(SUM(hd.TongTien), 0)
FROM HoaDon hd
WHERE hd.NgayLap >= @Tu
  AND hd.NgayLap < @Den
  AND hd.TrangThaiDonHang IN (N'Hoàn thành', N'Đang giao')" + filterCa;

                string sqlOrders = @"
SELECT COUNT(*)
FROM HoaDon hd
WHERE hd.NgayLap >= @Tu
  AND hd.NgayLap < @Den
  AND hd.TrangThaiDonHang IN (N'Hoàn thành', N'Đang giao')" + filterCa;

                string sqlItems = @"
SELECT ISNULL(SUM(ct.SoLuong), 0)
FROM ChiTietHoaDon ct
INNER JOIN HoaDon hd ON hd.MaHD = ct.MaHD
WHERE hd.NgayLap >= @Tu
  AND hd.NgayLap < @Den
  AND hd.TrangThaiDonHang IN (N'Hoàn thành', N'Đang giao')" + filterCa;

                string sqlCustomers = @"
SELECT COUNT(DISTINCT hd.MaKH)
FROM HoaDon hd
WHERE hd.NgayLap >= @Tu
  AND hd.NgayLap < @Den
  AND hd.MaKH IS NOT NULL
  AND hd.TrangThaiDonHang IN (N'Hoàn thành', N'Đang giao')" + filterCa;

                lblDoanhThu.Text = Convert.ToDecimal(kt.ExecuteScalar(sqlSummary, TaoParams(maCa, from, to, maNV, gioVao, gioRa))).ToString("N0") + " đ";
                lblSoHoaDon.Text = Convert.ToInt32(kt.ExecuteScalar(sqlOrders, TaoParams(maCa, from, to, maNV, gioVao, gioRa))).ToString("N0");
                lblSoSanPham.Text = Convert.ToInt32(kt.ExecuteScalar(sqlItems, TaoParams(maCa, from, to, maNV, gioVao, gioRa))).ToString("N0");
                lblSoKhach.Text = Convert.ToInt32(kt.ExecuteScalar(sqlCustomers, TaoParams(maCa, from, to, maNV, gioVao, gioRa))).ToString("N0");

                dtHoaDon = kt.GetData(@"
SELECT
    hd.MaHD,
    hd.NgayLap,
    ISNULL(kh.HoTen, N'Khách lẻ') AS KhachHang,
    ISNULL(nv.HoTen, N'—') AS NhanVien,
    CASE
        WHEN hd.MaCa IS NULL THEN N'—'
        ELSE N'CA' + RIGHT('0000' + CAST(hd.MaCa AS varchar(10)), 4)
    END AS Ca,
    hd.TongTien,
    hd.TrangThaiDonHang
FROM HoaDon hd
LEFT JOIN KhachHang kh ON kh.MaKH = hd.MaKH
LEFT JOIN NhanVien nv ON nv.MaNV = hd.MaNV
WHERE hd.NgayLap >= @Tu
  AND hd.NgayLap < @Den
  AND hd.TrangThaiDonHang IN (N'Hoàn thành', N'Đang giao')" + filterCa + @"
ORDER BY hd.NgayLap DESC, hd.MaHD DESC",
                    TaoParams(maCa, from, to, maNV, gioVao, gioRa));

                dgvNgay.DataSource = dtHoaDon;
                if (dgvNgay.Columns.Count > 0)
                {
                    dgvNgay.Columns["MaHD"].HeaderText = "Mã HĐ";
                    dgvNgay.Columns["NgayLap"].HeaderText = "Ngày lập";
                    dgvNgay.Columns["KhachHang"].HeaderText = "Khách hàng";
                    dgvNgay.Columns["NhanVien"].HeaderText = "Nhân viên";
                    dgvNgay.Columns["Ca"].HeaderText = "Ca";
                    dgvNgay.Columns["TongTien"].HeaderText = "Tổng tiền";
                    dgvNgay.Columns["TrangThaiDonHang"].HeaderText = "Trạng thái";
                    dgvNgay.Columns["MaHD"].Width = 75;
                    dgvNgay.Columns["NgayLap"].Width = 130;
                    dgvNgay.Columns["KhachHang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvNgay.Columns["NhanVien"].Width = 145;
                    dgvNgay.Columns["Ca"].Width = 70;
                    dgvNgay.Columns["TongTien"].Width = 125;
                    dgvNgay.Columns["TrangThaiDonHang"].Width = 110;
                    dgvNgay.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvNgay.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                }

                dtTopSP = kt.GetData(@"
SELECT TOP 20
    sp.MaSP,
    sp.TenSP,
    SUM(ct.SoLuong) AS SoLuongBan,
    SUM(ct.SoLuong * ct.DonGia) AS DoanhThu
FROM ChiTietHoaDon ct
INNER JOIN HoaDon hd ON hd.MaHD = ct.MaHD
INNER JOIN BienTheSanPham bt ON bt.MaBienThe = ct.MaBienThe
INNER JOIN SanPham sp ON sp.MaSP = bt.MaSP
WHERE hd.NgayLap >= @Tu
  AND hd.NgayLap < @Den
  AND hd.TrangThaiDonHang IN (N'Hoàn thành', N'Đang giao')" + filterCa + @"
GROUP BY sp.MaSP, sp.TenSP
ORDER BY SoLuongBan DESC, DoanhThu DESC",
                    TaoParams(maCa, from, to, maNV, gioVao, gioRa));

                dgvTopSP.DataSource = dtTopSP;
                if (dgvTopSP.Columns.Count > 0)
                {
                    dgvTopSP.Columns["MaSP"].HeaderText = "Mã SP";
                    dgvTopSP.Columns["TenSP"].HeaderText = "Sản phẩm";
                    dgvTopSP.Columns["SoLuongBan"].HeaderText = "SL bán";
                    dgvTopSP.Columns["DoanhThu"].HeaderText = "Doanh thu";
                    dgvTopSP.Columns["MaSP"].Width = 70;
                    dgvTopSP.Columns["TenSP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvTopSP.Columns["SoLuongBan"].Width = 80;
                    dgvTopSP.Columns["DoanhThu"].Width = 120;
                    dgvTopSP.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
                }

                lblPhu.Text = maCa > 0
                    ? "ĐANG LỌC THEO " + cboCa.Text
                    : "TỔNG HỢP THEO KHOẢNG THỜI GIAN";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải báo cáo doanh thu.\n\n" + ex.Message,
                    "Báo cáo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadBaoCao();
        }

        private void dgvNgay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvNgay.Rows[e.RowIndex].IsNewRow)
                return;

            object value = dgvNgay.Rows[e.RowIndex].Cells["MaHD"].Value;
            int maHD;
            if (value == null || !int.TryParse(Convert.ToString(value), out maHD) || maHD <= 0)
                return;

            try
            {
                using (FormChiTietHoaDon frm = new FormChiTietHoaDon(maHD))
                {
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở chi tiết hóa đơn.\n\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "CSV (*.csv)|*.csv";
                dlg.FileName = "BaoCaoDoanhThu_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("BÁO CÁO DOANH THU");
                    sb.AppendLine(
                        "Từ;" + dtpTu.Value.ToString("dd/MM/yyyy") +
                        ";Đến;" + dtpDen.Value.ToString("dd/MM/yyyy"));
                    sb.AppendLine("Bộ lọc ca;" + (cboCa.SelectedValue != null ? cboCa.Text : "Tất cả các ca"));
                    sb.AppendLine(
                        "Tổng doanh thu;" + lblDoanhThu.Text +
                        ";Số hóa đơn;" + lblSoHoaDon.Text +
                        ";Số sản phẩm;" + lblSoSanPham.Text +
                        ";Số khách;" + lblSoKhach.Text);

                    sb.AppendLine();
                    sb.AppendLine("DANH SÁCH HÓA ĐƠN");
                    sb.AppendLine("Mã HĐ;Ngày lập;Khách hàng;Nhân viên;Ca;Tổng tiền;Trạng thái");

                    foreach (DataRow r in dtHoaDon.Rows)
                    {
                        sb.AppendLine(
                            r["MaHD"] + ";" +
                            Convert.ToDateTime(r["NgayLap"]).ToString("dd/MM/yyyy HH:mm") + ";" +
                            CSV(r["KhachHang"]) + ";" +
                            CSV(r["NhanVien"]) + ";" +
                            CSV(r["Ca"]) + ";" +
                            Convert.ToDecimal(r["TongTien"]).ToString("0.##") + ";" +
                            CSV(r["TrangThaiDonHang"]));
                    }

                    sb.AppendLine();
                    sb.AppendLine("TOP SẢN PHẨM");
                    sb.AppendLine("Mã SP;Tên sản phẩm;SL bán;Doanh thu");

                    foreach (DataRow r in dtTopSP.Rows)
                    {
                        sb.AppendLine(
                            r["MaSP"] + ";" +
                            CSV(r["TenSP"]) + ";" +
                            r["SoLuongBan"] + ";" +
                            Convert.ToDecimal(r["DoanhThu"]).ToString("0.##"));
                    }

                    File.WriteAllText(dlg.FileName, "\uFEFF" + sb.ToString(), Encoding.UTF8);

                    MessageBox.Show(
                        "Đã xuất báo cáo CSV thành công.",
                        "Báo cáo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Không thể xuất báo cáo.\n\n" + ex.Message,
                        "Báo cáo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private static string CSV(object value)
        {
            string s = Convert.ToString(value) ?? "";
            if (s.Contains(";") || s.Contains("\"") || s.Contains("\r") || s.Contains("\n"))
                return "\"" + s.Replace("\"", "\"\"") + "\"";
            return s;
        }
    }
}

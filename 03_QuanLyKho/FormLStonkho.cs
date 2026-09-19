using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SPORTSHOP._03_QuanLyKho
{
    public partial class FormLStonkho : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private DataTable dtLichSu;

        public FormLStonkho()
        {
            InitializeComponent();

            LoadLoai();
            LoadNam();
            LoadLichSu();

            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            cmbLoai.SelectedIndexChanged += cmbLoai_SelectedIndexChanged;
            cboKyBaoCao.SelectedIndexChanged += BoLocChanged;
            cboNam.SelectedIndexChanged += BoLocChanged;
            cboQuy.SelectedIndexChanged += BoLocChanged;
            cboThang.SelectedIndexChanged += BoLocChanged;
            dtpTuNgay.ValueChanged += BoLocChanged;
            dtpDenNgay.ValueChanged += BoLocChanged;
            btnLamMoi.Click += btnLamMoi_Click;
            btnXuatBaoCao.Click += btnXuatBaoCao_Click;
        }

        private void FormLStonkho_Load(object sender, EventArgs e)
        {
            // Chọn năm hiện tại
            if (cboNam.Items.Count > 0)
            {
                int namHienTai = DateTime.Now.Year;

                string namHienTaiText = namHienTai.ToString();

                if (cboNam.Items.Contains(namHienTaiText))
                    cboNam.SelectedItem = namHienTaiText;
                else
                    cboNam.SelectedIndex = 0;
            }

            // Chọn Quý 1 mặc định
            if (cboQuy.Items.Count > 0)
            {
                cboQuy.SelectedIndex = 0;
            }

            // Chọn tháng hiện tại
            if (cboThang.Items.Count > 0)
            {
                cboThang.SelectedIndex = DateTime.Now.Month - 1;
            }
        }

        private void LoadLoai()
        {
            cmbLoai.Items.Clear();
            cmbLoai.Items.Add("Tất cả loại");
            cmbLoai.Items.Add("Nhập hàng");
            cmbLoai.Items.Add("Bán hàng");
            cmbLoai.Items.Add("Điều chỉnh");
            cmbLoai.SelectedIndex = 0;
        }

        private void LoadNam(string namCanGiu = null)
        {
            cboNam.Items.Clear();
            int namHienTai = DateTime.Now.Year;

            // Luôn có năm hiện tại + các năm xuất hiện trong dữ liệu.
            cboNam.Items.Add(namHienTai.ToString());

            if (dtLichSu != null && dtLichSu.Columns.Contains("ThoiGian"))
            {
                foreach (DataRow row in dtLichSu.Rows)
                {
                    if (row["ThoiGian"] == DBNull.Value) continue;
                    int nam = Convert.ToDateTime(row["ThoiGian"]).Year;
                    bool daCo = false;
                    foreach (object item in cboNam.Items)
                        if (Convert.ToInt32(item) == nam) { daCo = true; break; }
                    if (!daCo) cboNam.Items.Add(nam.ToString());
                }
            }

            cboNam.Items.Add((namHienTai - 1).ToString());
            cboNam.Items.Add((namHienTai - 2).ToString());

            // Sắp xếp năm giảm dần
            for (int i = 0; i < cboNam.Items.Count; i++)
                for (int j = i + 1; j < cboNam.Items.Count; j++)
                    if (Convert.ToInt32(cboNam.Items[j]) > Convert.ToInt32(cboNam.Items[i]))
                    {
                        object tmp = cboNam.Items[i];
                        cboNam.Items[i] = cboNam.Items[j];
                        cboNam.Items[j] = tmp;
                    }

            if (cboNam.Items.Count > 0)
            {
                if (!string.IsNullOrEmpty(namCanGiu) && cboNam.Items.Contains(namCanGiu))
                    cboNam.SelectedItem = namCanGiu;
                else
                    cboNam.SelectedIndex = 0;
            }
        }

        private void LoadLichSu(bool giuBoLoc = false)
        {
            try
            {
                string namDangChon = null;

                if (giuBoLoc && cboNam.SelectedItem != null)
                    namDangChon = cboNam.SelectedItem.ToString();

                string sql = @"
SELECT
    ls.MaLS,
    ls.MaBienThe,
    sp.TenSP,
    bt.SKU,
    sz.TenSize AS Size,
    ms.TenMau AS Mau,
    ls.ThayDoi,
    ls.Loai,
    ls.MaTK,
    ISNULL(tk.TenDangNhap, N'Không xác định') AS TenDangNhap,
    ISNULL(vt.TenVaiTro, N'Không xác định') AS TenVaiTro,
    ls.ThoiGian
FROM LichSuTonKho ls
INNER JOIN BienTheSanPham bt ON ls.MaBienThe = bt.MaBienThe
INNER JOIN SanPham sp ON bt.MaSP = sp.MaSP
INNER JOIN Size sz ON bt.MaSize = sz.MaSize
INNER JOIN MauSac ms ON bt.MaMau = ms.MaMau
LEFT JOIN TaiKhoan tk ON ls.MaTK = tk.MaTK
LEFT JOIN VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro
ORDER BY ls.ThoiGian DESC, ls.MaLS DESC;";

                dtLichSu = kt.GetData(sql);

                LoadNam(namDangChon);

                if (giuBoLoc)
                {
                    // Giữ nguyên toàn bộ bộ lọc hiện tại.
                    // Không đổi kỳ báo cáo, năm, quý, tháng hay khoảng ngày.
                    LocDuLieu();
                }
                else
                {
                    HienThiDuLieu(dtLichSu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải lịch sử tồn kho!\n\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DatTenCot()
        {
            if (dgvLichSuTonKho.Columns.Count == 0) return;

            SetHeader("MaLS", "Mã LS");
            SetHeader("MaBienThe", "Mã biến thể");
            SetHeader("TenSP", "Sản phẩm");
            SetHeader("SKU", "SKU");
            SetHeader("Size", "Size");
            SetHeader("Mau", "Màu");
            SetHeader("ThayDoi", "Thay đổi");
            SetHeader("Loai", "Loại");
            SetHeader("MaTK", "Mã TK");
            SetHeader("TenDangNhap", "Người thực hiện");
            SetHeader("TenVaiTro", "Vai trò");
            SetHeader("ThoiGian", "Thời gian chính xác");

            if (dgvLichSuTonKho.Columns.Contains("ThoiGian"))
                dgvLichSuTonKho.Columns["ThoiGian"].DefaultCellStyle.Format =
                    "dd/MM/yyyy HH:mm:ss";

            if (dgvLichSuTonKho.Columns.Contains("ThayDoi"))
            {
                dgvLichSuTonKho.Columns["ThayDoi"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                dgvLichSuTonKho.Columns["ThayDoi"].DefaultCellStyle.Format = "+#;-#;0";
            }
        }

        private void SetHeader(string name, string header)
        {
            if (dgvLichSuTonKho.Columns.Contains(name))
                dgvLichSuTonKho.Columns[name].HeaderText = header;
        }

        private void CauHinhDataGridView()
        {
            dgvLichSuTonKho.AllowUserToAddRows = false;
            dgvLichSuTonKho.AllowUserToDeleteRows = false;
            dgvLichSuTonKho.ReadOnly = true;
            dgvLichSuTonKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLichSuTonKho.MultiSelect = false;
            dgvLichSuTonKho.RowHeadersVisible = false;
            dgvLichSuTonKho.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvLichSuTonKho.RowTemplate.Height = 34;
            dgvLichSuTonKho.ColumnHeadersVisible = true;
            dgvLichSuTonKho.EnableHeadersVisualStyles = false;
            dgvLichSuTonKho.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLichSuTonKho.ColumnHeadersHeight = 42;

            dgvLichSuTonKho.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(34, 87, 122);
            dgvLichSuTonKho.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLichSuTonKho.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvLichSuTonKho.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvLichSuTonKho.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvLichSuTonKho.DefaultCellStyle.ForeColor = Color.FromArgb(45, 55, 65);
            dgvLichSuTonKho.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(221, 235, 247);
            dgvLichSuTonKho.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 45, 60);
            dgvLichSuTonKho.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 250, 252);

            SetWidth("MaLS", 65);
            SetWidth("MaBienThe", 90);
            SetWidth("TenSP", 180);
            SetWidth("SKU", 125);
            SetWidth("Size", 65);
            SetWidth("Mau", 80);
            SetWidth("ThayDoi", 80);
            SetWidth("Loai", 105);
            SetWidth("MaTK", 65);
            SetWidth("TenDangNhap", 125);
            SetWidth("TenVaiTro", 100);
            SetWidth("ThoiGian", 155);
        }

        private void SetWidth(string name, int width)
        {
            if (dgvLichSuTonKho.Columns.Contains(name))
                dgvLichSuTonKho.Columns[name].Width = width;
        }

        private void HienThiDuLieu(DataTable data)
        {
            dgvLichSuTonKho.DataSource = data;
            DatTenCot();
            CauHinhDataGridView();
            CapNhatMauThayDoi();
            CapNhatThongKe(data);
        }

        private void CapNhatMauThayDoi()
        {
            if (!dgvLichSuTonKho.Columns.Contains("ThayDoi")) return;

            foreach (DataGridViewRow row in dgvLichSuTonKho.Rows)
            {
                if (row.Cells["ThayDoi"].Value == null) continue;
                decimal value;
                if (!decimal.TryParse(row.Cells["ThayDoi"].Value.ToString(), out value))
                    continue;

                row.Cells["ThayDoi"].Style.Font =
                    new Font("Segoe UI", 9F, FontStyle.Bold);
                row.Cells["ThayDoi"].Style.ForeColor =
                    value > 0 ? Color.FromArgb(25, 150, 90) :
                    value < 0 ? Color.FromArgb(210, 65, 65) :
                    Color.DimGray;
            }
        }

        private void CapNhatThongKe(DataTable data)
        {
            int soDong = data == null ? 0 : data.Rows.Count;
            decimal tang = 0, giam = 0, rong = 0;

            if (data != null && data.Columns.Contains("ThayDoi"))
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ThayDoi"] == DBNull.Value) continue;
                    decimal x = Convert.ToDecimal(row["ThayDoi"]);
                    if (x > 0) tang += x;
                    else if (x < 0) giam += Math.Abs(x);
                    rong += x;
                }
            }

            lblTongDong.Text = "Số giao dịch: " + soDong.ToString("N0");
            lblTang.Text = "Nhập/tăng: +" + tang.ToString("N0");
            lblGiam.Text = "Xuất/giảm: -" + giam.ToString("N0");
            lblRong.Text = "Chênh lệch ròng: " + (rong >= 0 ? "+" : "") + rong.ToString("N0");
        }

        private void LocDuLieu()
        {
            if (dtLichSu == null) return;

            string tuKhoa = txtTimKiem.Text.Trim();
            string loai = cmbLoai.SelectedIndex > 0
                ? cmbLoai.SelectedItem.ToString() : "";

            DateTime? tuNgay = null;
            DateTime? denNgayExclusive = null;

            string ky = cboKyBaoCao.SelectedItem?.ToString() ?? "Tất cả thời gian";
            int nam = cboNam.SelectedItem == null ? DateTime.Now.Year :
                Convert.ToInt32(cboNam.SelectedItem);

            if (ky == "Theo năm")
            {
                tuNgay = new DateTime(nam, 1, 1);
                denNgayExclusive = tuNgay.Value.AddYears(1);
            }
            else if (ky == "Theo quý")
            {
                int quy = cboQuy.SelectedIndex + 1;

                // Nếu chưa chọn quý thì mặc định Quý 1
                if (quy < 1 || quy > 4)
                {
                    quy = 1;
                    cboQuy.SelectedIndex = 0;
                }

                int thangBatDau = (quy - 1) * 3 + 1;

                DateTime start = new DateTime(nam, thangBatDau, 1);

                tuNgay = start;
                denNgayExclusive = start.AddMonths(3);
            }
            else if (ky == "Theo tháng")
            {
                int thang = cboThang.SelectedIndex + 1;
                DateTime start = new DateTime(nam, thang, 1);
                tuNgay = start;
                denNgayExclusive = start.AddMonths(1);
            }
            else if (ky == "Khoảng ngày")
            {
                DateTime start = dtpTuNgay.Value.Date;
                DateTime end = dtpDenNgay.Value.Date;

                if (end < start)
                {
                    DateTime tmp = start;
                    start = end;
                    end = tmp;
                }

                tuNgay = start;
                denNgayExclusive = end.AddDays(1);
            }

            DataTable result = dtLichSu.Clone();

            foreach (DataRow row in dtLichSu.Rows)
            {
                bool ok = true;

                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    string ten = row["TenSP"]?.ToString() ?? "";
                    string sku = row["SKU"]?.ToString() ?? "";
                    string nguoi = row["TenDangNhap"]?.ToString() ?? "";
                    string maBT = row["MaBienThe"]?.ToString() ?? "";

                    ok = ten.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0
                      || sku.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0
                      || nguoi.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0
                      || maBT.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                if (ok && !string.IsNullOrEmpty(loai))
                    ok = string.Equals(row["Loai"]?.ToString(), loai,
                        StringComparison.OrdinalIgnoreCase);

                if (ok && tuNgay.HasValue)
                {
                    if (row["ThoiGian"] == DBNull.Value)
                        ok = false;
                    else
                    {
                        DateTime tg = Convert.ToDateTime(row["ThoiGian"]);
                        ok = tg >= tuNgay.Value && tg < denNgayExclusive.Value;
                    }
                }

                if (ok)
                    result.ImportRow(row);
            }

            HienThiDuLieu(result);
            CapNhatTrangThaiLoc();
        }

        private void CapNhatTrangThaiLoc()
        {
            string ky = cboKyBaoCao.SelectedItem?.ToString() ?? "Tất cả thời gian";
            bool theoQuy = ky == "Theo quý";
            bool theoThang = ky == "Theo tháng";
            bool khoangNgay = ky == "Khoảng ngày";

            cboNam.Enabled = theoQuy || theoThang || ky == "Theo năm";
            cboQuy.Enabled = theoQuy;
            cboThang.Enabled = theoThang;
            dtpTuNgay.Enabled = khoangNgay;
            dtpDenNgay.Enabled = khoangNgay;

            lblQuy.Enabled = theoQuy;
            lblThang.Enabled = theoThang;
            lblNam.Enabled = cboNam.Enabled;
            lblTuNgay.Enabled = khoangNgay;
            lblDenNgay.Enabled = khoangNgay;
        }

        private void BoLocChanged(object sender, EventArgs e)
        {
            if (cboKyBaoCao.SelectedIndex < 0) return;
            CapNhatTrangThaiLoc();
            LocDuLieu();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void cmbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Nút Làm mới chỉ tải lại dữ liệu từ SQL.
            // Giữ nguyên toàn bộ bộ lọc người dùng đang chọn:
            // từ khóa, loại, kỳ báo cáo, năm, quý, tháng, từ ngày, đến ngày.
            LoadLichSu(true);
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            DataTable data = dgvLichSuTonKho.DataSource as DataTable;
            if (data == null || data.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trong kỳ đang lọc để xuất báo cáo.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string ky = cboKyBaoCao.SelectedItem?.ToString() ?? "Tất cả thời gian";
            string goiY = "BaoCao_LichSuTonKho_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Filter = "Excel CSV (*.csv)|*.csv";
                save.FileName = goiY;
                save.Title = "Xuất báo cáo lịch sử tồn kho";

                if (save.ShowDialog() != DialogResult.OK) return;

                try
                {
                    Encoding utf8Bom = new UTF8Encoding(true);

                    using (StreamWriter sw = new StreamWriter(
                        save.FileName, false, utf8Bom))
                    {
                        sw.WriteLine("BÁO CÁO SAO KÊ LỊCH SỬ TỒN KHO");
                        sw.WriteLine("Kỳ báo cáo," + Csv(ky));
                        sw.WriteLine("Thời gian xuất," +
                            Csv(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));

                        decimal tang = 0, giam = 0, rong = 0;
                        foreach (DataRow row in data.Rows)
                        {
                            if (row["ThayDoi"] == DBNull.Value) continue;
                            decimal x = Convert.ToDecimal(row["ThayDoi"]);
                            if (x > 0) tang += x;
                            if (x < 0) giam += Math.Abs(x);
                            rong += x;
                        }

                        sw.WriteLine("Số giao dịch," + data.Rows.Count);
                        sw.WriteLine("Tổng tăng," + tang.ToString(CultureInfo.InvariantCulture));
                        sw.WriteLine("Tổng giảm," + giam.ToString(CultureInfo.InvariantCulture));
                        sw.WriteLine("Chênh lệch ròng," + rong.ToString(CultureInfo.InvariantCulture));
                        sw.WriteLine();

                        sw.WriteLine(
                            "Mã LS,Mã biến thể,Sản phẩm,SKU,Size,Màu,Thay đổi,Loại,Mã TK,Người thực hiện,Vai trò,Thời gian");

                        foreach (DataRow row in data.Rows)
                        {
                            sw.WriteLine(string.Join(",",
                                Csv(row["MaLS"]),
                                Csv(row["MaBienThe"]),
                                Csv(row["TenSP"]),
                                Csv(row["SKU"]),
                                Csv(row["Size"]),
                                Csv(row["Mau"]),
                                Csv(row["ThayDoi"]),
                                Csv(row["Loai"]),
                                Csv(row["MaTK"]),
                                Csv(row["TenDangNhap"]),
                                Csv(row["TenVaiTro"]),
                                Csv(Convert.ToDateTime(row["ThoiGian"])
                                    .ToString("dd/MM/yyyy HH:mm:ss"))
                            ));
                        }
                    }

                    MessageBox.Show(
                        "Đã xuất báo cáo sao kê chính xác theo dữ liệu đang lọc.\n\n" +
                        "File: " + Path.GetFileName(save.FileName),
                        "Xuất báo cáo thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xuất báo cáo!\n\n" + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string Csv(object value)
        {
            if (value == null || value == DBNull.Value) return "\"\"";
            string text = value.ToString().Replace("\"", "\"\"");
            return "\"" + text + "\"";
        }
    }
}

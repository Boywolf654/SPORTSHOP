using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace SPORTSHOP._03_QuanLyKho
{

    public partial class FormTonKho : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        private DataTable dtTonKho;
        public FormTonKho()
        {
            InitializeComponent();
            TaoNutXuatExcel();

            LoadDanhMuc();
            LoadTrangThai();
            LoadTonKho();
            CauHinhDataGridView1();

            // Sự kiện tìm kiếm
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            // Sự kiện lọc
            cmbDanhMuc.SelectedIndexChanged += cmbDanhMuc_SelectedIndexChanged;
            cmbTrangThai.SelectedIndexChanged += cmbTrangThai_SelectedIndexChanged;
        }

        private void FormTonKho_Load(object sender, EventArgs e)
        {

        }

        private void LoadTonKho()
        {
            string sql = @"
                SELECT
                    tk.MaTonKho,
                    sp.MaSP,
                    sp.TenSP,
                    dm.MaDM,
                    bt.SKU,
                    sz.TenSize AS Size,
                    ms.TenMau AS Mau,
                    tk.SLTon,
                    tk.SLToiThieu,
                    bt.GiaBan,

                    CASE
                        WHEN tk.SLTon = 0 THEN N'Hết hàng'
                        WHEN tk.SLTon <= tk.SLToiThieu THEN N'Sắp hết hàng'
                        ELSE N'Còn hàng'
                    END AS TrangThai

                FROM TonKho tk

                INNER JOIN BienTheSanPham bt
                    ON tk.MaBienThe = bt.MaBienThe

                INNER JOIN SanPham sp
                    ON bt.MaSP = sp.MaSP

                INNER JOIN DanhMuc dm
                    ON sp.MaDM = dm.MaDM

                INNER JOIN Size sz
                    ON bt.MaSize = sz.MaSize

                INNER JOIN MauSac ms
                    ON bt.MaMau = ms.MaMau

                ORDER BY sp.TenSP;
            ";

            dtTonKho = kt.GetData(sql);

            dgvTonKho.DataSource = dtTonKho;

            DatTenCot();
            CauHinhDataGridView();
            CapNhatThongKe();
        }

        private void DatTenCot()
        {
            if (dgvTonKho.Columns.Count == 0)
                return;

            dgvTonKho.Columns["MaTonKho"].HeaderText = "Mã tồn";
            dgvTonKho.Columns["MaSP"].Visible = false;
            dgvTonKho.Columns["MaDM"].Visible = false;

            dgvTonKho.Columns["TenSP"].HeaderText = "Sản phẩm";
            dgvTonKho.Columns["SKU"].HeaderText = "SKU";
            dgvTonKho.Columns["Size"].HeaderText = "Size";
            dgvTonKho.Columns["Mau"].HeaderText = "Màu";
            dgvTonKho.Columns["SLTon"].HeaderText = "Tồn kho";
            dgvTonKho.Columns["SLToiThieu"].HeaderText = "Tối thiểu";
            dgvTonKho.Columns["GiaBan"].HeaderText = "Giá bán";
            dgvTonKho.Columns["TrangThai"].HeaderText = "Trạng thái";

            dgvTonKho.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
        }


        // =========================================================
        // 3. CẤU HÌNH DATAGRIDVIEW
        // =========================================================
        private void CauHinhDataGridView()
        {
            dgvTonKho.AllowUserToAddRows = false;
            dgvTonKho.AllowUserToDeleteRows = false;
            dgvTonKho.ReadOnly = true;

            dgvTonKho.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvTonKho.MultiSelect = false;

            dgvTonKho.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvTonKho.ColumnHeadersHeight = 35;

            dgvTonKho.ScrollBars = ScrollBars.Both;

            dgvTonKho.ColumnHeadersDefaultCellStyle.Alignment =
    DataGridViewContentAlignment.MiddleCenter;

            dgvTonKho.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private void LoadDanhMuc()
        {
            string sql = @"
                SELECT MaDM, TenDanhMuc
                FROM DanhMuc
                WHERE TrangThai = 1
                ORDER BY TenDanhMuc;
            ";

            DataTable dt = kt.GetData(sql);

            DataRow row = dt.NewRow();

            row["MaDM"] = 0;
            row["TenDanhMuc"] = "Tất cả danh mục";

            dt.Rows.InsertAt(row, 0);

            cmbDanhMuc.DataSource = dt;
            cmbDanhMuc.DisplayMember = "TenDanhMuc";
            cmbDanhMuc.ValueMember = "MaDM";

            cmbDanhMuc.SelectedIndex = 0;
        }


        private void LoadTrangThai()
        {
            cmbTrangThai.Items.Clear();

            cmbTrangThai.Items.Add("Tất cả trạng thái");
            cmbTrangThai.Items.Add("Còn hàng");
            cmbTrangThai.Items.Add("Sắp hết hàng");
            cmbTrangThai.Items.Add("Hết hàng");

            cmbTrangThai.SelectedIndex = 0;
        }

        private void LocDuLieu()
        {
            if (dtTonKho == null)
                return;

            string tenSP = txtTimKiem.Text.Trim();

            int maDM = 0;

            if (cmbDanhMuc.SelectedValue != null)
            {
                int.TryParse(
                    cmbDanhMuc.SelectedValue.ToString(),
                    out maDM
                );
            }

            string trangThai = "";

            if (cmbTrangThai.SelectedIndex > 0)
            {
                trangThai = cmbTrangThai.SelectedItem.ToString();
            }


            DataView view = new DataView(dtTonKho);

            string filter = "";


            // -------------------------
            // LỌC TÊN SẢN PHẨM
            // -------------------------
            if (!string.IsNullOrEmpty(tenSP))
            {
                // Tránh lỗi khi người dùng nhập dấu '
                tenSP = tenSP.Replace("'", "''");

                filter +=
                    $"TenSP LIKE '%{tenSP}%'";
            }


            // -------------------------
            // LỌC DANH MỤC
            // -------------------------
            if (maDM > 0)
            {
                if (filter != "")
                    filter += " AND ";

                filter += $"MaDM = {maDM}";
            }


            // -------------------------
            // LỌC TRẠNG THÁI
            // -------------------------
            if (!string.IsNullOrEmpty(trangThai))
            {
                if (filter != "")
                    filter += " AND ";

                trangThai = trangThai.Replace("'", "''");

                filter +=
                    $"TrangThai = '{trangThai}'";
            }


            view.RowFilter = filter;

            dgvTonKho.DataSource = view;

            DatTenCot();
        }


        // =========================================================
        // 7. TÌM KIẾM
        // =========================================================
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }


        // =========================================================
        // 8. LỌC DANH MỤC
        // =========================================================
        private void cmbDanhMuc_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LocDuLieu();
        }


        // =========================================================
        // 9. LỌC TRẠNG THÁI
        // =========================================================
        private void cmbTrangThai_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LocDuLieu();
        }


        // =========================================================
        // 10. TÍNH THỐNG KÊ
        // =========================================================
        private void CapNhatThongKe()
        {
            string sql = @"
        SELECT
            COUNT(DISTINCT bt.MaSP) AS TongSanPham,

            SUM(
                CASE
                    WHEN tk.SLTon > 0
                         AND tk.SLTon <= tk.SLToiThieu
                    THEN 1
                    ELSE 0
                END
            ) AS SapHetHang,

            SUM(
                CASE
                    WHEN tk.SLTon = 0
                    THEN 1
                    ELSE 0
                END
            ) AS HetHang,

            ISNULL(
                SUM(tk.SLTon * bt.GiaNhap),
                0
            ) AS GiaTriTonKho

        FROM TonKho tk
        INNER JOIN BienTheSanPham bt
            ON tk.MaBienThe = bt.MaBienThe;
    ";

            DataTable dt = kt.GetData(sql);

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            int tongSanPham = Convert.ToInt32(row["TongSanPham"]);

            int sapHetHang = row["SapHetHang"] == DBNull.Value
                ? 0
                : Convert.ToInt32(row["SapHetHang"]);

            int hetHang = row["HetHang"] == DBNull.Value
                ? 0
                : Convert.ToInt32(row["HetHang"]);

            decimal giaTriTonKho = row["GiaTriTonKho"] == DBNull.Value
                ? 0
                : Convert.ToDecimal(row["GiaTriTonKho"]);


            // =========================
            // HIỂN THỊ
            // =========================

            btnTongSanPham.Text =
                "Tổng sản phẩm\n" +
                tongSanPham.ToString("N0");

            btnSapHetHang.Text =
                "Sắp hết hàng\n" +
                sapHetHang.ToString("N0");

            btnHetHang.Text =
                "Hết hàng\n" +
                hetHang.ToString("N0");

            btnGiaTriTonKho.Text =
                "Giá trị tồn kho\n" +
                FormatTien(giaTriTonKho);
        }

        private string FormatTien(decimal tien)
        {
            if (tien >= 1000000000)
                return (tien / 1000000000m).ToString("0.##") + " tỷ đ";

            if (tien >= 1000000)
                return (tien / 1000000m).ToString("0.##") + " triệu đ";

            if (tien >= 1000)
                return (tien / 1000m).ToString("0.##") + " nghìn đ";

            return tien.ToString("N0") + " đ";
        }


        // =========================================================
        // 11. NÚT LÀM MỚI - NẾU M CÓ NÚT THÌ GẮN HÀM NÀY
        // =========================================================
        private void LamMoi()
        {
            txtTimKiem.Clear();

            if (cmbDanhMuc.Items.Count > 0)
                cmbDanhMuc.SelectedIndex = 0;

            if (cmbTrangThai.Items.Count > 0)
                cmbTrangThai.SelectedIndex = 0;

            LoadTonKho();
        }

        private void CauHinhDataGridView1()
        {
            dgvTonKho.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;

            dgvTonKho.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            dgvTonKho.AllowUserToAddRows = false;
            dgvTonKho.AllowUserToDeleteRows = false;
            dgvTonKho.ReadOnly = true;

            dgvTonKho.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvTonKho.MultiSelect = false;

            dgvTonKho.ScrollBars = ScrollBars.Both;


            dgvTonKho.Columns["MaTonKho"].Width = 70;
            dgvTonKho.Columns["TenSP"].Width = 180;
            dgvTonKho.Columns["SKU"].Width = 130;
            dgvTonKho.Columns["Size"].Width = 70;
            dgvTonKho.Columns["Mau"].Width = 80;
            dgvTonKho.Columns["SLTon"].Width = 80;
            dgvTonKho.Columns["SLToiThieu"].Width = 90;
            dgvTonKho.Columns["GiaBan"].Width = 110;
            dgvTonKho.Columns["TrangThai"].Width = 110;
        }
        // =========================================================
        // XUẤT TỒN KHO RA EXCEL
        // Xuất đúng dữ liệu đang hiển thị sau khi lọc.
        // =========================================================
        private void TaoNutXuatExcel()
        {
            Guna.UI2.WinForms.Guna2Button btn = new Guna.UI2.WinForms.Guna2Button();

            btn.Name = "btnXuatExcel";
            btn.Text = "📊  Xuất Excel";
            btn.Size = new Size(150, 42);
            btn.Location = new Point(625, 24);
            btn.BorderRadius = 8;
            btn.FillColor = Color.FromArgb(25, 135, 84);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            btn.HoverState.FillColor = Color.FromArgb(20, 110, 68);
            btn.Click += btnXuatExcel_Click;

            Controls.Add(btn);
            btn.BringToFront();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = null;

                DataView view = dgvTonKho.DataSource as DataView;

                if (view != null)
                {
                    dt = view.ToTable();
                }
                else
                {
                    DataTable source = dgvTonKho.DataSource as DataTable;
                    if (source != null)
                        dt = source.Copy();
                }

                if (dt == null)
                {
                    MessageBox.Show(
                        "Không có dữ liệu tồn kho để xuất.",
                        "Xuất Excel",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Không có dữ liệu phù hợp với bộ lọc hiện tại.",
                        "Xuất Excel",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog save = new SaveFileDialog())
                {
                    save.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                    save.Title = "Xuất báo cáo tồn kho";
                    save.FileName =
                        "BaoCaoTonKho_" +
                        DateTime.Now.ToString("yyyyMMdd_HHmmss") +
                        ".xlsx";

                    if (save.ShowDialog(this) != DialogResult.OK)
                        return;

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add("Ton Kho");

                        ws.Cell(1, 1).Value = "BÁO CÁO TỒN KHO SPORTSHOP";
                        ws.Range(1, 1, 1, 9).Merge();

                        ws.Cell(1, 1).Style.Font.Bold = true;
                        ws.Cell(1, 1).Style.Font.FontSize = 18;
                        ws.Cell(1, 1).Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Center;

                        ws.Cell(2, 1).Value = "Thời gian xuất:";
                        ws.Cell(2, 2).Value = DateTime.Now;
                        ws.Cell(2, 2).Style.DateFormat.Format =
                            "dd/MM/yyyy HH:mm:ss";

                        string[] headers =
                        {
                            "Mã tồn",
                            "Sản phẩm",
                            "SKU",
                            "Size",
                            "Màu",
                            "Tồn kho",
                            "Tối thiểu",
                            "Giá bán",
                            "Trạng thái"
                        };

                        for (int c = 0; c < headers.Length; c++)
                        {
                            ws.Cell(4, c + 1).Value = headers[c];
                            ws.Cell(4, c + 1).Style.Font.Bold = true;
                            ws.Cell(4, c + 1).Style.Font.FontColor =
                                XLColor.White;
                            ws.Cell(4, c + 1).Style.Fill.BackgroundColor =
                                XLColor.FromArgb(25, 52, 82);
                            ws.Cell(4, c + 1).Style.Alignment.Horizontal =
                                XLAlignmentHorizontalValues.Center;
                        }

                        int excelRow = 5;

                        foreach (DataRow row in dt.Rows)
                        {
                            ws.Cell(excelRow, 1).Value = row[0]?.ToString() ?? "";
                            ws.Cell(excelRow, 2).Value = row[1]?.ToString() ?? "";
                            ws.Cell(excelRow, 3).Value = row[2]?.ToString() ?? "";
                            ws.Cell(excelRow, 4).Value = row[3]?.ToString() ?? "";
                            ws.Cell(excelRow, 5).Value = row[4]?.ToString() ?? "";
                            ws.Cell(excelRow, 6).Value = row[5]?.ToString() ?? "";
                            ws.Cell(excelRow, 7).Value = row[6]?.ToString() ?? "";
                            ws.Cell(excelRow, 8).Value = row[7]?.ToString() ?? "";
                            ws.Cell(excelRow, 9).Value = row[8]?.ToString() ?? "";

                            excelRow++;
                        }

                        ws.Column(8).Style.NumberFormat.Format = "#,##0";
                        ws.Column(1).Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Center;
                        ws.Column(3).Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Center;
                        ws.Column(4).Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Center;
                        ws.Column(5).Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Center;
                        ws.Column(6).Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Center;
                        ws.Column(7).Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Center;
                        ws.Column(8).Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Right;

                        ws.Range(4, 1, excelRow - 1, 9).Style.Border.OutsideBorder =
                            XLBorderStyleValues.Thin;
                        ws.Range(4, 1, excelRow - 1, 9).Style.Border.InsideBorder =
                            XLBorderStyleValues.Thin;

                        ws.SheetView.FreezeRows(4);
                        ws.Range(4, 1, excelRow - 1, 9).SetAutoFilter();

                        ws.Column(1).Width = 10;
                        ws.Column(2).Width = 30;
                        ws.Column(3).Width = 18;
                        ws.Column(4).Width = 12;
                        ws.Column(5).Width = 15;
                        ws.Column(6).Width = 12;
                        ws.Column(7).Width = 12;
                        ws.Column(8).Width = 16;
                        ws.Column(9).Width = 18;

                        wb.SaveAs(save.FileName);
                    }

                    MessageBox.Show(
                        "Xuất Excel thành công!\n\n" +
                        "Đã xuất " + dt.Rows.Count.ToString("N0") +
                        " dòng tồn kho.",
                        "Xuất Excel",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xuất Excel.\n\n" + ex.Message,
                    "Xuất Excel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


    }
}

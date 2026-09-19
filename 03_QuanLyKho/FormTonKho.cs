using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._03_QuanLyKho
{
    public partial class FormTonKho : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private DataTable dtTonKho;

        public FormTonKho()
        {
            InitializeComponent();

            LoadKho();
            LoadDanhMuc();
            LoadTrangThai();
            LoadTonKho();

            txtTimKiem.TextChanged += (s, e) => LocDuLieu();
            cmbKho.SelectedIndexChanged += (s, e) => { if (IsHandleCreated) { LocDuLieu(); CapNhatThongKe(); } };
            cmbDanhMuc.SelectedIndexChanged += (s, e) => LocDuLieu();
            cmbTrangThai.SelectedIndexChanged += (s, e) => LocDuLieu();
            btnLamMoi.Click += btnLamMoi_Click;
        }

        private void LoadKho()
        {
            string sql = "SELECT MaKho, TenKho FROM Kho ORDER BY TenKho;";
            DataTable dt = kt.GetData(sql);
            DataRow all = dt.NewRow();
            all["MaKho"] = 0;
            all["TenKho"] = "Tất cả kho";
            dt.Rows.InsertAt(all, 0);

            cmbKho.DataSource = dt;
            cmbKho.DisplayMember = "TenKho";
            cmbKho.ValueMember = "MaKho";
            cmbKho.SelectedIndex = 0;
        }

        private void LoadDanhMuc()
        {
            string sql = @"
                SELECT MaDM, TenDanhMuc
                FROM DanhMuc
                WHERE TrangThai = 1
                ORDER BY TenDanhMuc;";
            DataTable dt = kt.GetData(sql);

            DataRow all = dt.NewRow();
            all["MaDM"] = 0;
            all["TenDanhMuc"] = "Tất cả danh mục";
            dt.Rows.InsertAt(all, 0);

            cmbDanhMuc.DataSource = dt;
            cmbDanhMuc.DisplayMember = "TenDanhMuc";
            cmbDanhMuc.ValueMember = "MaDM";
            cmbDanhMuc.SelectedIndex = 0;
        }

        private void LoadTrangThai()
        {
            cmbTrangThai.Items.Clear();
            cmbTrangThai.Items.AddRange(new object[] {
                "Tất cả trạng thái", "Còn hàng", "Sắp hết hàng", "Hết hàng"
            });
            cmbTrangThai.SelectedIndex = 0;
        }

        private int GetMaKhoFilter()
        {
            int maKho;
            return cmbKho.SelectedValue != null &&
                   int.TryParse(cmbKho.SelectedValue.ToString(), out maKho)
                ? maKho : 0;
        }

        private int GetMaDMFilter()
        {
            int maDM;
            return cmbDanhMuc.SelectedValue != null &&
                   int.TryParse(cmbDanhMuc.SelectedValue.ToString(), out maDM)
                ? maDM : 0;
        }

        private void LoadTonKho()
        {
            string sql = @"
                SELECT
                    tk.MaTonKho,
                    tk.MaKho,
                    k.TenKho,
                    sp.MaSP,
                    sp.TenSP,
                    dm.MaDM,
                    bt.SKU,
                    sz.TenSize AS Size,
                    ms.TenMau AS Mau,
                    tk.SLTon,
                    tk.SLToiThieu,
                    bt.GiaNhap,
                    bt.GiaBan,
                    CASE
                        WHEN tk.SLTon = 0 THEN N'Hết hàng'
                        WHEN tk.SLTon <= tk.SLToiThieu THEN N'Sắp hết hàng'
                        ELSE N'Còn hàng'
                    END AS TrangThai
                FROM TonKho tk
                INNER JOIN Kho k ON k.MaKho = tk.MaKho
                INNER JOIN BienTheSanPham bt ON bt.MaBienThe = tk.MaBienThe
                INNER JOIN SanPham sp ON sp.MaSP = bt.MaSP
                INNER JOIN DanhMuc dm ON dm.MaDM = sp.MaDM
                INNER JOIN Size sz ON sz.MaSize = bt.MaSize
                INNER JOIN MauSac ms ON ms.MaMau = bt.MaMau
                ORDER BY k.TenKho, sp.TenSP, bt.SKU;";

            dtTonKho = kt.GetData(sql);
            dgvTonKho.DataSource = dtTonKho;
            DatTenCot();
            CauHinhDataGridView();
            CapNhatThongKe();
        }

        private void DatTenCot()
        {
            if (dgvTonKho.Columns.Count == 0) return;

            dgvTonKho.Columns["MaTonKho"].HeaderText = "Mã tồn";
            dgvTonKho.Columns["MaKho"].Visible = false;
            dgvTonKho.Columns["MaSP"].Visible = false;
            dgvTonKho.Columns["MaDM"].Visible = false;

            dgvTonKho.Columns["TenKho"].HeaderText = "Kho";
            dgvTonKho.Columns["TenSP"].HeaderText = "Sản phẩm";
            dgvTonKho.Columns["SKU"].HeaderText = "SKU";
            dgvTonKho.Columns["Size"].HeaderText = "Size";
            dgvTonKho.Columns["Mau"].HeaderText = "Màu";
            dgvTonKho.Columns["SLTon"].HeaderText = "Tồn";
            dgvTonKho.Columns["SLToiThieu"].HeaderText = "Tối thiểu";
            dgvTonKho.Columns["GiaNhap"].HeaderText = "Giá nhập";
            dgvTonKho.Columns["GiaBan"].HeaderText = "Giá bán";
            dgvTonKho.Columns["TrangThai"].HeaderText = "Trạng thái";

            dgvTonKho.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
            dgvTonKho.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
        }

        private void CauHinhDataGridView()
        {
            dgvTonKho.AllowUserToAddRows = false;
            dgvTonKho.AllowUserToDeleteRows = false;
            dgvTonKho.ReadOnly = true;
            dgvTonKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTonKho.MultiSelect = false;
            dgvTonKho.RowHeadersVisible = false;
            dgvTonKho.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvTonKho.ColumnHeadersHeight = 40;
            dgvTonKho.RowTemplate.Height = 34;
            dgvTonKho.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTonKho.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvTonKho.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvTonKho.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            if (dgvTonKho.Columns.Count > 0)
            {
                dgvTonKho.Columns["MaTonKho"].Width = 70;
                dgvTonKho.Columns["TenKho"].Width = 125;
                dgvTonKho.Columns["TenSP"].Width = 190;
                dgvTonKho.Columns["SKU"].Width = 125;
                dgvTonKho.Columns["Size"].Width = 65;
                dgvTonKho.Columns["Mau"].Width = 85;
                dgvTonKho.Columns["SLTon"].Width = 75;
                dgvTonKho.Columns["SLToiThieu"].Width = 85;
                dgvTonKho.Columns["GiaNhap"].Width = 105;
                dgvTonKho.Columns["GiaBan"].Width = 105;
                dgvTonKho.Columns["TrangThai"].Width = 115;
            }
        }

        private string EscapeRowFilter(string value)
        {
            return value.Replace("'", "''")
                        .Replace("[", "[[]")
                        .Replace("%", "[%]")
                        .Replace("*", "[*]");
        }

        private void LocDuLieu()
        {
            if (dtTonKho == null) return;

            DataView view = new DataView(dtTonKho);
            string filter = "";

            string ten = EscapeRowFilter(txtTimKiem.Text.Trim());
            if (!string.IsNullOrWhiteSpace(ten))
                filter = "TenSP LIKE '%" + ten + "%' OR SKU LIKE '%" + ten + "%'";

            int maKho = GetMaKhoFilter();
            if (maKho > 0)
                filter = AddAnd(filter, "MaKho = " + maKho);

            int maDM = GetMaDMFilter();
            if (maDM > 0)
                filter = AddAnd(filter, "MaDM = " + maDM);

            if (cmbTrangThai.SelectedIndex > 0)
            {
                string tt = EscapeRowFilter(cmbTrangThai.SelectedItem.ToString());
                filter = AddAnd(filter, "TrangThai = '" + tt + "'");
            }

            view.RowFilter = filter;
            dgvTonKho.DataSource = view;
            DatTenCot();
        }

        private string AddAnd(string current, string next)
        {
            if (string.IsNullOrEmpty(current)) return next;
            if (current.Contains(" OR ")) return "(" + current + ") AND " + next;
            return current + " AND " + next;
        }

        private void CapNhatThongKe()
        {
            string sql = @"
                SELECT
                    COUNT(*) AS TongBienThe,
                    SUM(CASE WHEN tk.SLTon > 0 AND tk.SLTon <= tk.SLToiThieu THEN 1 ELSE 0 END) AS SapHet,
                    SUM(CASE WHEN tk.SLTon = 0 THEN 1 ELSE 0 END) AS Het,
                    ISNULL(SUM(tk.SLTon * bt.GiaNhap), 0) AS GiaTri
                FROM TonKho tk
                INNER JOIN BienTheSanPham bt ON bt.MaBienThe = tk.MaBienThe
                WHERE (@MaKho = 0 OR tk.MaKho = @MaKho);";

            DataTable dt = kt.GetData(
            sql,
            new SqlParameter[]
            {
                new SqlParameter("@MaKho", GetMaKhoFilter())
            }
                );

            DataRow r = dt.Rows[0];
            int tong = r["TongBienThe"] == DBNull.Value ? 0 : Convert.ToInt32(r["TongBienThe"]);
            int sap = r["SapHet"] == DBNull.Value ? 0 : Convert.ToInt32(r["SapHet"]);
            int het = r["Het"] == DBNull.Value ? 0 : Convert.ToInt32(r["Het"]);
            decimal giaTri = r["GiaTri"] == DBNull.Value ? 0 : Convert.ToDecimal(r["GiaTri"]);

            btnTongSanPham.Text = "📦 Tổng biến thể\n" + tong.ToString("N0");
            btnSapHetHang.Text = "⚠ Sắp hết hàng\n" + sap.ToString("N0");
            btnHetHang.Text = "⛔ Hết hàng\n" + het.ToString("N0");
            btnGiaTriTonKho.Text = "💰 Giá trị vốn tồn\n" + FormatTien(giaTri);
        }

        private string FormatTien(decimal tien)
        {
            if (tien >= 1000000000m) return (tien / 1000000000m).ToString("0.##") + " tỷ đ";
            if (tien >= 1000000m) return (tien / 1000000m).ToString("0.##") + " triệu đ";
            if (tien >= 1000m) return (tien / 1000m).ToString("0.##") + " nghìn đ";
            return tien.ToString("N0") + " đ";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cmbKho.SelectedIndex = 0;
            cmbDanhMuc.SelectedIndex = 0;
            cmbTrangThai.SelectedIndex = 0;
            LoadTonKho();
        }
    }
}
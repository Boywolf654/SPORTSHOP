using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    public partial class FormDanhSachHoaDon : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private int maHDCanChon = 0;
        private Label lblTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnLocNgay;
        private Button btnThoat;

        public FormDanhSachHoaDon() : this(0)
        {
        }

        public FormDanhSachHoaDon(int maHD)
        {
            InitializeComponent();
            maHDCanChon = maHD;
            CauHinhBoLocNgay();
            CauHinhCuaSo();
            CauHinhNutThoat();
        }

        private void CauHinhCuaSo()
        {
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.Sizable;
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1400, 800);
            MinimumSize = new Size(1100, 650);
            MaximizeBox = true;
            MinimizeBox = true;
            ControlBox = true;
            BackColor = Color.FromArgb(244, 247, 251);
        }

        private void CauHinhNutThoat()
        {
            btnThoat = new Button
            {
                Name = "btnThoat",
                Text = "✕  THOÁT",
                BackColor = Color.FromArgb(220, 30, 45),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                Size = new Size(112, 38),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Cursor = Cursors.Hand
            };

            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.Location = new Point(
                pnlHeader.ClientSize.Width - btnThoat.Width - 22,
                31);

            btnThoat.Click += (sender, e) => Close();
            pnlHeader.Controls.Add(btnThoat);
            btnThoat.BringToFront();

            pnlHeader.Resize += (sender, e) =>
            {
                if (btnThoat != null)
                {
                    btnThoat.Left =
                        pnlHeader.ClientSize.Width - btnThoat.Width - 22;
                    btnThoat.Top = 31;
                }
            };
        }

        private void CauHinhBoLocNgay()
        {
            lblTuNgay = new Label
            {
                AutoSize = true,
                Text = "Từ ngày",
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(62, 73, 89)
            };

            dtpTuNgay = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Font = new Font("Segoe UI", 9F),
                Size = new Size(120, 25),
                Value = DateTime.Today.AddDays(-30)
            };

            lblDenNgay = new Label
            {
                AutoSize = true,
                Text = "Đến ngày",
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(62, 73, 89)
            };

            dtpDenNgay = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Font = new Font("Segoe UI", 9F),
                Size = new Size(120, 25),
                Value = DateTime.Today
            };

            btnLocNgay = new Button
            {
                Text = "▣  Lọc ngày",
                BackColor = Color.FromArgb(220, 30, 45),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                Size = new Size(115, 30),
                Cursor = Cursors.Hand
            };

            btnLocNgay.FlatAppearance.BorderSize = 0;

            pnlTools.Controls.Add(lblTuNgay);
            pnlTools.Controls.Add(dtpTuNgay);
            pnlTools.Controls.Add(lblDenNgay);
            pnlTools.Controls.Add(dtpDenNgay);
            pnlTools.Controls.Add(btnLocNgay);

            pnlTools.Resize += (sender, e) => BoTriBoLocNgay();
            BoTriBoLocNgay();

            btnLocNgay.Click += (sender, e) => LoadHoaDon();
        }

        private void BoTriBoLocNgay()
        {
            if (pnlTools == null || btnLocNgay == null)
                return;

            int right = pnlTools.ClientSize.Width - 22;

            lblTongSo.AutoSize = true;
            lblTongSo.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            int tongWidth = TextRenderer.MeasureText(
                lblTongSo.Text,
                lblTongSo.Font).Width;

            lblTongSo.Left = right - tongWidth;
            lblTongSo.Top = 43;

            right = lblTongSo.Left - 22;

            btnLocNgay.Left = right - btnLocNgay.Width;
            btnLocNgay.Top = 36;

            right = btnLocNgay.Left - 18;

            dtpDenNgay.Left = right - dtpDenNgay.Width;
            dtpDenNgay.Top = 38;
            lblDenNgay.Left = dtpDenNgay.Left;
            lblDenNgay.Top = 15;

            right = dtpDenNgay.Left - 18;

            dtpTuNgay.Left = right - dtpTuNgay.Width;
            dtpTuNgay.Top = 38;
            lblTuNgay.Left = dtpTuNgay.Left;
            lblTuNgay.Top = 15;
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                txtTimKiem.TextChanged += txtTimKiem_TextChanged;
                btnLamMoi.Click += btnLamMoi_Click;
                btnXemChiTiet.Click += btnXemChiTiet_Click;
                dgvHoaDon.CellDoubleClick += dgvHoaDon_CellDoubleClick;

                CauHinhGrid();
                LoadHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể khởi tạo danh sách hóa đơn.\r\n\r\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CauHinhGrid()
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.ReadOnly = true;

            dgvHoaDon.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvHoaDon.MultiSelect = false;
            dgvHoaDon.RowHeadersVisible = false;
            dgvHoaDon.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            dgvHoaDon.RowTemplate.Height = 44;
            dgvHoaDon.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvHoaDon.Columns["colSTT"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvHoaDon.Columns["colMaHD"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvHoaDon.Columns["colMaDon"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvHoaDon.Columns["colNgayLap"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvHoaDon.Columns["colTongTien"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvHoaDon.Columns["colPhuongThuc"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvHoaDon.Columns["colTrangThai"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }

        private void LoadHoaDon()
        {
            try
            {
                string sql = @"
SELECT
    hd.MaHD,
    hd.NgayLap,
    hd.MaKH,
    hd.MaNV,
    hd.TongTien,
    hd.TrangThaiDonHang,
    kh.HoTen,
    kh.SDT,

    tt.PhuongThuc AS PhuongThucThanhToan,
    tt.TrangThai AS TrangThaiThanhToan,

    hd.MaDonOnline

FROM HoaDon hd

LEFT JOIN KhachHang kh
    ON kh.MaKH = hd.MaKH

OUTER APPLY
(
    SELECT TOP 1
        t.PhuongThuc,
        t.TrangThai
    FROM ThanhToan t
    WHERE t.MaHD = hd.MaHD
    ORDER BY t.MaTT DESC
) tt

WHERE hd.NgayLap >= @TuNgay
  AND hd.NgayLap < @DenNgay
ORDER BY hd.MaHD DESC;";

                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

                if (tuNgay >= denNgay)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Lọc hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = kt.GetData(sql, new SqlParameter[]
                {
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay)
                });

                dgvHoaDon.Rows.Clear();

                int stt = 1;

                foreach (DataRow row in dt.Rows)
                {
                    int maHD = Convert.ToInt32(row["MaHD"]);

                    int index = dgvHoaDon.Rows.Add();

                    dgvHoaDon.Rows[index].Cells["colSTT"].Value =
                        stt++;

                    dgvHoaDon.Rows[index].Cells["colMaHD"].Value =
                        "HD" + maHD.ToString("D5");

                    object maDonOnline =
                        row["MaDonOnline"];

                    dgvHoaDon.Rows[index].Cells["colMaDon"].Value =
                        maDonOnline == DBNull.Value
                            ? "Bán tại quầy"
                            : "DO" +
                              Convert.ToInt32(maDonOnline)
                              .ToString("D5");

                    dgvHoaDon.Rows[index].Cells["colKhachHang"].Value =
                        row["HoTen"] == DBNull.Value
                            ? "Khách lẻ"
                            : row["HoTen"].ToString();

                    dgvHoaDon.Rows[index].Cells["colSDT"].Value =
                        row["SDT"] == DBNull.Value
                            ? ""
                            : row["SDT"].ToString();

                    dgvHoaDon.Rows[index].Cells["colNgayLap"].Value =
                        Convert.ToDateTime(
                            row["NgayLap"])
                        .ToString("dd/MM/yyyy HH:mm");

                    dgvHoaDon.Rows[index].Cells["colTongTien"].Value =
                        Convert.ToDecimal(
                            row["TongTien"])
                        .ToString("N0") + " đ";

                    dgvHoaDon.Rows[index].Cells["colPhuongThuc"].Value =
                        row["PhuongThucThanhToan"] == DBNull.Value
                            ? "—"
                            : row["PhuongThucThanhToan"].ToString();

                    string trangThai =
                        row["TrangThaiDonHang"] == DBNull.Value
                            ? "Hoàn thành"
                            : row["TrangThaiDonHang"].ToString();

                    dgvHoaDon.Rows[index].Cells["colTrangThai"].Value =
                        trangThai;

                    dgvHoaDon.Rows[index].Tag = maHD;

                    GanMauTrangThai(
                        dgvHoaDon.Rows[index],
                        trangThai);

                    if (maHDCanChon == maHD)
                    {
                        dgvHoaDon.ClearSelection();

                        dgvHoaDon.Rows[index].Selected = true;

                        dgvHoaDon.CurrentCell =
                            dgvHoaDon.Rows[index]
                            .Cells["colMaHD"];

                        if (index >= 0 &&
                            index < dgvHoaDon.RowCount)
                        {
                            dgvHoaDon.FirstDisplayedScrollingRowIndex =
                                index;
                        }
                    }
                }

                lblTongSo.Text =
                    dt.Rows.Count + " hóa đơn";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách hóa đơn.\r\n\r\n" +
                    ex.Message,
                    "SPORTSHOP - Hóa đơn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void GanMauTrangThai(
            DataGridViewRow row,
            string trangThai)
        {
            row.Cells["colTrangThai"]
                .Style.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            if (trangThai.Equals(
                "Đã hủy",
                StringComparison.OrdinalIgnoreCase))
            {
                row.Cells["colTrangThai"]
                    .Style.ForeColor =
                    Color.FromArgb(190, 45, 45);

                row.Cells["colTrangThai"]
                    .Style.BackColor =
                    Color.FromArgb(255, 232, 232);
            }
            else
            {
                row.Cells["colTrangThai"]
                    .Style.ForeColor =
                    Color.FromArgb(26, 145, 78);

                row.Cells["colTrangThai"]
                    .Style.BackColor =
                    Color.FromArgb(226, 248, 235);
            }
        }

        private void txtTimKiem_TextChanged(
            object sender,
            EventArgs e)
        {
            string key =
                txtTimKiem.Text.Trim();

            foreach (DataGridViewRow row
                in dgvHoaDon.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string maHD =
                    Convert.ToString(
                        row.Cells["colMaHD"].Value);

                string maDon =
                    Convert.ToString(
                        row.Cells["colMaDon"].Value);

                string khach =
                    Convert.ToString(
                        row.Cells["colKhachHang"].Value);

                string sdt =
                    Convert.ToString(
                        row.Cells["colSDT"].Value);

                row.Visible =
                    string.IsNullOrWhiteSpace(key)
                    || maHD.IndexOf(
                        key,
                        StringComparison.OrdinalIgnoreCase) >= 0
                    || maDon.IndexOf(
                        key,
                        StringComparison.OrdinalIgnoreCase) >= 0
                    || khach.IndexOf(
                        key,
                        StringComparison.OrdinalIgnoreCase) >= 0
                    || sdt.IndexOf(
                        key,
                        StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }

        private int LayMaHDDangChon()
        {
            if (dgvHoaDon.CurrentRow == null)
                return 0;

            if (dgvHoaDon.CurrentRow.Tag == null)
                return 0;

            return Convert.ToInt32(
                dgvHoaDon.CurrentRow.Tag);
        }

        private void btnXemChiTiet_Click(
            object sender,
            EventArgs e)
        {
            int maHD =
                LayMaHDDangChon();

            if (maHD <= 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn một hóa đơn.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using (FormChiTietHoaDon form =
                new FormChiTietHoaDon(maHD))
            {
                form.ShowDialog(this);
            }
        }

        private void dgvHoaDon_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnXemChiTiet_Click(
                    sender,
                    EventArgs.Empty);
            }
        }

        private void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            txtTimKiem.Clear();
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today;
            LoadHoaDon();
        }
    }
}
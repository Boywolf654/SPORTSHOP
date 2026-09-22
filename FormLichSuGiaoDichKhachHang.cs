using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SPORTSHOP._06_BanHang;

namespace SPORTSHOP
{
    public partial class FormLichSuGiaoDichKhachHang : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        public FormLichSuGiaoDichKhachHang()
        {
            InitializeComponent();

            this.Load += FormLichSuGiaoDichKhachHang_Load;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            btnLamMoi.Click += btnLamMoi_Click;
            btnXemChiTiet.Click += btnXemChiTiet_Click;
            dgvGiaoDich.CellDoubleClick += dgvGiaoDich_CellDoubleClick;
        }

        private void FormLichSuGiaoDichKhachHang_Load(object sender, EventArgs e)
        {
            CauHinhGrid();
            LoadGiaoDichCuaToi();
        }

        private void CauHinhGrid()
        {
            dgvGiaoDich.ReadOnly = true;
            dgvGiaoDich.AllowUserToAddRows = false;
            dgvGiaoDich.AllowUserToDeleteRows = false;
            dgvGiaoDich.MultiSelect = false;
            dgvGiaoDich.RowHeadersVisible = false;
            dgvGiaoDich.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGiaoDich.AutoGenerateColumns = false;
            dgvGiaoDich.RowTemplate.Height = 40;

            dgvGiaoDich.Columns["colSTT"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvGiaoDich.Columns["colMaGD"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvGiaoDich.Columns["colNgay"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvGiaoDich.Columns["colTongTien"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            dgvGiaoDich.Columns["colPhuongThuc"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvGiaoDich.Columns["colTrangThai"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }

        private void LoadGiaoDichCuaToi()
        {
            try
            {
                if (Session.MaTK <= 0)
                {
                    MessageBox.Show(
                        "Không xác định được tài khoản khách hàng.",
                        "Lịch sử giao dịch",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                /*
                 * QUAN TRỌNG:
                 * Không có ô chọn MaKH và không nhận MaKH từ người dùng.
                 * Luôn lọc trực tiếp theo Session.MaTK.
                 * Vì vậy khách chỉ nhìn được hóa đơn thuộc chính tài khoản của mình.
                 */
                string sql = @"
SELECT
    hd.MaHD,
    hd.MaDonOnline,
    hd.NgayLap,
    hd.TongTien,
    ISNULL(hd.TrangThaiDonHang, N'Hoàn thành') AS TrangThaiDonHang,
    ISNULL(tt.PhuongThucThanhToan, N'—') AS PhuongThucThanhToan
FROM dbo.HoaDon hd
INNER JOIN dbo.KhachHang kh
    ON kh.MaKH = hd.MaKH
OUTER APPLY
(
    SELECT TOP 1
        t.PhuongThucThanhToan,
        t.TrangThai
    FROM dbo.ThanhToan t
    WHERE t.MaHD = hd.MaHD
    ORDER BY t.MaThanhToan DESC
) tt
WHERE kh.MaTK = @MaTK
ORDER BY hd.NgayLap DESC, hd.MaHD DESC;";

                DataTable dt = kt.GetData(
                    sql,
                    new SqlParameter[]
                    {
                        new SqlParameter("@MaTK", Session.MaTK)
                    });

                dgvGiaoDich.Rows.Clear();

                int stt = 1;

                foreach (DataRow row in dt.Rows)
                {
                    int maHD = Convert.ToInt32(row["MaHD"]);
                    int index = dgvGiaoDich.Rows.Add();

                    dgvGiaoDich.Rows[index].Cells["colSTT"].Value = stt++;
                    dgvGiaoDich.Rows[index].Cells["colMaGD"].Value =
                        "HD" + maHD.ToString("D5");

                    dgvGiaoDich.Rows[index].Cells["colLoai"].Value =
                        row["MaDonOnline"] == DBNull.Value
                            ? "Bán tại quầy"
                            : "Đơn online";

                    dgvGiaoDich.Rows[index].Cells["colNgay"].Value =
                        Convert.ToDateTime(row["NgayLap"])
                            .ToString("dd/MM/yyyy HH:mm");

                    dgvGiaoDich.Rows[index].Cells["colTongTien"].Value =
                        Convert.ToDecimal(row["TongTien"])
                            .ToString("N0") + " đ";

                    dgvGiaoDich.Rows[index].Cells["colPhuongThuc"].Value =
                        Convert.ToString(row["PhuongThucThanhToan"]);

                    string trangThai =
                        Convert.ToString(row["TrangThaiDonHang"]);

                    dgvGiaoDich.Rows[index].Cells["colTrangThai"].Value =
                        trangThai;

                    dgvGiaoDich.Rows[index].Tag = maHD;

                    GanMauTrangThai(
                        dgvGiaoDich.Rows[index],
                        trangThai);
                }

                lblTongSo.Text =
                    "Có " + dt.Rows.Count.ToString("N0") + " giao dịch";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải lịch sử giao dịch.\r\n\r\n" +
                    ex.Message,
                    "Lịch sử giao dịch",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void GanMauTrangThai(
            DataGridViewRow row,
            string trangThai)
        {
            row.Cells["colTrangThai"].Style.Font =
                new Font("Segoe UI Semibold", 9F, FontStyle.Bold);

            if (trangThai.Equals(
                "Đã hủy",
                StringComparison.OrdinalIgnoreCase))
            {
                row.Cells["colTrangThai"].Style.ForeColor =
                    Color.FromArgb(190, 45, 45);
                row.Cells["colTrangThai"].Style.BackColor =
                    Color.FromArgb(255, 232, 232);
            }
            else
            {
                row.Cells["colTrangThai"].Style.ForeColor =
                    Color.FromArgb(26, 145, 78);
                row.Cells["colTrangThai"].Style.BackColor =
                    Color.FromArgb(226, 248, 235);
            }
        }

        private void txtTimKiem_TextChanged(
            object sender,
            EventArgs e)
        {
            string key = txtTimKiem.Text.Trim();

            foreach (DataGridViewRow row in dgvGiaoDich.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string ma =
                    Convert.ToString(row.Cells["colMaGD"].Value);
                string loai =
                    Convert.ToString(row.Cells["colLoai"].Value);
                string ngay =
                    Convert.ToString(row.Cells["colNgay"].Value);
                string phuongThuc =
                    Convert.ToString(row.Cells["colPhuongThuc"].Value);
                string trangThai =
                    Convert.ToString(row.Cells["colTrangThai"].Value);

                row.Visible =
                    string.IsNullOrWhiteSpace(key)
                    || ma.IndexOf(
                        key,
                        StringComparison.OrdinalIgnoreCase) >= 0
                    || loai.IndexOf(
                        key,
                        StringComparison.OrdinalIgnoreCase) >= 0
                    || ngay.IndexOf(
                        key,
                        StringComparison.OrdinalIgnoreCase) >= 0
                    || phuongThuc.IndexOf(
                        key,
                        StringComparison.OrdinalIgnoreCase) >= 0
                    || trangThai.IndexOf(
                        key,
                        StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }

        private int LayMaHDDangChon()
        {
            if (dgvGiaoDich.CurrentRow == null ||
                dgvGiaoDich.CurrentRow.Tag == null)
                return 0;

            return Convert.ToInt32(
                dgvGiaoDich.CurrentRow.Tag);
        }

        private void btnXemChiTiet_Click(
            object sender,
            EventArgs e)
        {
            int maHD = LayMaHDDangChon();

            if (maHD <= 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn một giao dịch.",
                    "Lịch sử giao dịch",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            /*
             * FormChiTietHoaDon chỉ nhận MaHD.
             * MaHD này đã được lấy từ danh sách được khóa theo Session.MaTK.
             */
            using (FormChiTietHoaDon frm =
                new FormChiTietHoaDon(maHD))
            {
                frm.ShowDialog(this);
            }
        }

        private void dgvGiaoDich_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnXemChiTiet_Click(
                    sender,
                    EventArgs.Empty);
        }

        private void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            txtTimKiem.Clear();
            LoadGiaoDichCuaToi();
        }
    }
}

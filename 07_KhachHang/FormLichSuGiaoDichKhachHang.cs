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
                 * Lấy 2 loại giao dịch:
                 * 1. Hóa đơn đã được tạo trong HoaDon.
                 * 2. Đơn online vẫn đang chờ xử lý / thanh toán và chưa tạo HoaDon.
                 *
                 * Luôn lọc theo Session.MaTK để khách chỉ thấy dữ liệu của mình.
                 */
                string sql = @"
-- =========================================================
-- 1. HÓA ĐƠN ĐÃ TẠO
-- =========================================================
SELECT
    hd.MaHD,
    hd.MaDonOnline,
    hd.NgayLap AS ThoiGian,
    hd.TongTien,
    ISNULL(hd.TrangThaiDonHang, N'Hoàn thành') AS TrangThaiDonHang,
    ISNULL(tt.PhuongThuc, N'—') AS PhuongThucThanhToan,
    N'HD' AS LoaiMa
FROM dbo.HoaDon hd
INNER JOIN dbo.KhachHang kh
    ON kh.MaKH = hd.MaKH
OUTER APPLY
(
    SELECT TOP 1
        t.PhuongThuc,
        t.TrangThai
    FROM dbo.ThanhToan t
    WHERE t.MaHD = hd.MaHD
    ORDER BY t.MaTT DESC
) tt
WHERE kh.MaTK = @MaTK

UNION ALL

-- =========================================================
-- 2. ĐƠN ONLINE CHƯA TẠO HÓA ĐƠN - ĐANG CHỜ XỬ LÝ
-- =========================================================
SELECT
    CAST(0 AS INT) AS MaHD,
    d.MaDonOnline,
    d.NgayTao AS ThoiGian,
    (
        ISNULL(d.TongTienHang, 0)
        - ISNULL(d.TienGiam, 0)
        + ISNULL(d.PhiVanChuyen, 0)
    ) AS TongTien,
    d.TrangThai AS TrangThaiDonHang,
    ISNULL(d.PhuongThucThanhToan, N'—') AS PhuongThucThanhToan,
    N'DO' AS LoaiMa
FROM dbo.DonOnline d
INNER JOIN dbo.KhachHang kh
    ON kh.MaKH = d.MaKH
WHERE kh.MaTK = @MaTK
  AND d.TrangThai IN
  (
      N'Chờ thanh toán',
      N'Đã thanh toán',
      N'NV tiếp nhận'
  )
  -- Không hiển thị lại đơn online nếu đơn đó đã được tạo HoaDon.
  AND NOT EXISTS
  (
      SELECT 1
      FROM dbo.HoaDon hd2
      WHERE hd2.MaDonOnline = d.MaDonOnline
  )

ORDER BY ThoiGian DESC, MaHD DESC, MaDonOnline DESC;";

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
                    int maDonOnline =
                        row["MaDonOnline"] == DBNull.Value
                            ? 0
                            : Convert.ToInt32(row["MaDonOnline"]);

                    string loaiMa =
                        Convert.ToString(row["LoaiMa"]);

                    int index = dgvGiaoDich.Rows.Add();

                    dgvGiaoDich.Rows[index].Cells["colSTT"].Value = stt++;

                    // Hóa đơn: HD00001
                    // Đơn online đang chờ: DO0001
                    dgvGiaoDich.Rows[index].Cells["colMaGD"].Value =
                        loaiMa == "DO"
                            ? "DO" + maDonOnline.ToString("D4")
                            : "HD" + maHD.ToString("D5");

                    dgvGiaoDich.Rows[index].Cells["colLoai"].Value =
                        loaiMa == "DO"
                            ? "Đơn online - Chờ xử lý"
                            : row["MaDonOnline"] == DBNull.Value
                                ? "Bán tại quầy"
                                : "Đơn online";

                    dgvGiaoDich.Rows[index].Cells["colNgay"].Value =
                        Convert.ToDateTime(row["ThoiGian"])
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

                    // Lưu cả loại + mã để nút "Xem chi tiết" biết đây là HD hay DO.
                    dgvGiaoDich.Rows[index].Tag =
                        loaiMa + "|" +
                        (loaiMa == "DO"
                            ? maDonOnline.ToString()
                            : maHD.ToString());

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

        private string LayGiaoDichDangChon()
        {
            if (dgvGiaoDich.CurrentRow == null ||
                dgvGiaoDich.CurrentRow.Tag == null)
                return "";

            return Convert.ToString(
                dgvGiaoDich.CurrentRow.Tag);
        }

        private void btnXemChiTiet_Click(
            object sender,
            EventArgs e)
        {
            string giaoDich = LayGiaoDichDangChon();

            if (string.IsNullOrWhiteSpace(giaoDich))
            {
                MessageBox.Show(
                    "Vui lòng chọn một giao dịch.",
                    "Lịch sử giao dịch",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string[] parts = giaoDich.Split('|');

            if (parts.Length != 2 ||
                !int.TryParse(parts[1], out int ma))
            {
                MessageBox.Show(
                    "Không xác định được giao dịch đã chọn.",
                    "Lịch sử giao dịch",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Hóa đơn đã tạo -> mở FormChiTietHoaDon như cũ.
            if (parts[0] == "HD")
            {
                using (FormChiTietHoaDon frm =
                    new FormChiTietHoaDon(ma))
                {
                    frm.ShowDialog(this);
                }

                return;
            }

            // Đơn online chưa tạo HoaDon -> hiện thông báo trạng thái.
            if (parts[0] == "DO")
            {
                MessageBox.Show(
                    "Đơn online DO" + ma.ToString("D4") +
                    " hiện vẫn đang được xử lý.\r\n\r\n" +
                    "Trạng thái: " +
                    Convert.ToString(
                        dgvGiaoDich.CurrentRow.Cells["colTrangThai"].Value) +
                    "\r\n" +
                    "Đơn sẽ xuất hiện dưới dạng hóa đơn sau khi được tiếp nhận/thanh toán.",
                    "Đơn online",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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

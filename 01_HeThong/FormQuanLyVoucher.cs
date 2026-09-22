using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SPORTSHOP._06_BanHang;

namespace SPORTSHOP
{
    public partial class FormQuanLyVoucher : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        public FormQuanLyVoucher()
        {
            InitializeComponent();
        }

        private void FormQuanLyVoucher_Load(object sender, EventArgs e)
        {
            CauHinh();
            TaiDanhSach();
        }

        private void CauHinh()
        {
            dgvVoucher.ReadOnly = true;
            dgvVoucher.AllowUserToAddRows = false;
            dgvVoucher.RowHeadersVisible = false;
            dgvVoucher.MultiSelect = false;
            dgvVoucher.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVoucher.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVoucher.RowTemplate.Height = 36;
            dgvVoucher.ColumnHeadersHeight = 42;

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Tất cả");
            cboTrangThai.Items.Add("Đang hoạt động");
            cboTrangThai.Items.Add("Đã ngừng");
            cboTrangThai.SelectedIndex = 0;
        }

        // =========================================================
        // TẢI DANH SÁCH VOUCHER
        // =========================================================
        private void TaiDanhSach()
        {
            try
            {
                string sql = @"
                    SELECT
                        MaVoucher,
                        MaCode,
                        LoaiGiam,
                        GiaTri,
                        GiaTriDonToiThieu,
                        SoLuongToiDa,
                        DaSuDung,
                        NgayBatDau,
                        NgayHetHan,
                        CASE 
                            WHEN TrangThai = 1 
                                THEN N'Đang hoạt động'
                            ELSE N'Đã ngừng'
                        END AS TrangThaiText
                    FROM Voucher
                    WHERE 
                        @TT = 0
                        OR TrangThai = CASE 
                            WHEN @TT = 1 THEN 1 
                            ELSE 0 
                        END
                    ORDER BY MaVoucher DESC";

                DataTable dt = kt.GetData(
                    sql,
                    new SqlParameter[]
                    {
                        new SqlParameter("@TT", cboTrangThai.SelectedIndex)
                    });

                dgvVoucher.DataSource = dt;

                if (dgvVoucher.Columns.Count == 0)
                    return;

                // =================================================
                // ĐẶT TÊN CỘT
                // =================================================

                dgvVoucher.Columns["MaVoucher"].HeaderText = "Mã";

                dgvVoucher.Columns["MaCode"].HeaderText = "Mã voucher";

                dgvVoucher.Columns["LoaiGiam"].HeaderText = "Loại giảm";

                dgvVoucher.Columns["GiaTri"].HeaderText = "Giá trị";

                dgvVoucher.Columns["GiaTriDonToiThieu"].HeaderText =
                    "Đơn tối thiểu";

                dgvVoucher.Columns["SoLuongToiDa"].HeaderText =
                    "Số lượt";

                dgvVoucher.Columns["DaSuDung"].HeaderText =
                    "Đã dùng";

                dgvVoucher.Columns["NgayBatDau"].HeaderText =
                    "Bắt đầu";

                dgvVoucher.Columns["NgayHetHan"].HeaderText =
                    "Kết thúc";

                dgvVoucher.Columns["TrangThaiText"].HeaderText =
                    "Trạng thái";

                // =================================================
                // FORMAT
                // =================================================

                dgvVoucher.Columns["GiaTri"]
                    .DefaultCellStyle.Format = "N0";

                dgvVoucher.Columns["GiaTriDonToiThieu"]
                    .DefaultCellStyle.Format = "N0";

                dgvVoucher.Columns["NgayBatDau"]
                    .DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvVoucher.Columns["NgayHetHan"]
                    .DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải voucher.\n\n" + ex.Message,
                    "Voucher",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LẤY MÃ VOUCHER ĐANG CHỌN
        // =========================================================
        private int LayMa()
        {
            if (dgvVoucher.CurrentRow == null)
                return 0;

            object v =
                dgvVoucher.CurrentRow.Cells["MaVoucher"].Value;

            return v == null || v == DBNull.Value
                ? 0
                : Convert.ToInt32(v);
        }

        // =========================================================
        // TÌM KIẾM
        // =========================================================
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.Trim();

            foreach (DataGridViewRow row in dgvVoucher.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string code =
                    Convert.ToString(
                        row.Cells["MaCode"].Value);

                row.Visible =
                    string.IsNullOrWhiteSpace(key)
                    || code.IndexOf(
                        key,
                        StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }

        // =========================================================
        // LỌC TRẠNG THÁI
        // =========================================================
        private void cboTrangThai_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            TaiDanhSach();
        }

        // =========================================================
        // THÊM VOUCHER
        // =========================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            using (themcoupon frm = new themcoupon())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    TaiDanhSach();
                }
            }
        }

        // =========================================================
        // NGỪNG VOUCHER
        // =========================================================
        private void btnNgung_Click(object sender, EventArgs e)
        {
            int ma = LayMa();

            if (ma <= 0)
            {
                MessageBox.Show(
                    "Hãy chọn voucher cần ngừng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (MessageBox.Show(
                "Ngừng voucher đang chọn?\n\n" +
                "Lịch sử sử dụng vẫn được giữ.",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
                != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string sql = @"
                    UPDATE Voucher
                    SET TrangThai = 0
                    WHERE MaVoucher = @MaVoucher";

                kt.Execute(
                    sql,
                    new SqlParameter[]
                    {
                        new SqlParameter(
                            "@MaVoucher",
                            ma)
                    });

                TaiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể ngừng voucher.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LÀM MỚI
        // =========================================================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();

            cboTrangThai.SelectedIndex = 0;

            TaiDanhSach();
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    public partial class coupon : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private readonly decimal tongTienDonHang;

        public int MaVoucherDuocChon { get; private set; }
        public decimal SoTienGiam { get; private set; }
        public string MaCodeDuocChon { get; private set; }

        public coupon() : this(0m) { }

        public coupon(decimal tongTien)
        {
            tongTienDonHang = tongTien;
            InitializeComponent();
        }

        private void coupon_Load(object sender, EventArgs e)
        {
            LoadVoucher();
        }

        private void LoadVoucher()
        {
            try
            {
                DataTable dt = kt.GetData(@"
                    SELECT MaVoucher, MaCode, GiaTri, LoaiGiam,
                           GiaTriDonToiThieu, SoLuongToiDa, DaSuDung,
                           NgayBatDau, NgayHetHan
                    FROM Voucher
                    WHERE TrangThai=1
                      AND DaSuDung < SoLuongToiDa
                      AND NgayBatDau <= CAST(GETDATE() AS DATE)
                      AND (NgayHetHan IS NULL OR NgayHetHan >= CAST(GETDATE() AS DATE))
                    ORDER BY MaVoucher DESC");

                dgvVoucher.DataSource = dt;

                if (dgvVoucher.Columns.Count > 0)
                {
                    dgvVoucher.Columns["MaVoucher"].HeaderText = "Mã";
                    dgvVoucher.Columns["MaCode"].HeaderText = "Voucher";
                    dgvVoucher.Columns["GiaTri"].HeaderText = "Giá trị";
                    dgvVoucher.Columns["LoaiGiam"].HeaderText = "Loại";
                    dgvVoucher.Columns["GiaTriDonToiThieu"].HeaderText = "Đơn tối thiểu";
                    dgvVoucher.Columns["SoLuongToiDa"].HeaderText = "Lượt";
                    dgvVoucher.Columns["DaSuDung"].HeaderText = "Đã dùng";
                    dgvVoucher.Columns["NgayBatDau"].HeaderText = "Bắt đầu";
                    dgvVoucher.Columns["NgayHetHan"].HeaderText = "Kết thúc";

                    dgvVoucher.Columns["GiaTri"].DefaultCellStyle.Format = "N0";
                    dgvVoucher.Columns["GiaTriDonToiThieu"].DefaultCellStyle.Format = "N0";
                    dgvVoucher.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvVoucher.Columns["NgayHetHan"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                lblTongDon.Text = "Tổng đơn: " + tongTienDonHang.ToString("N0") + " đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải voucher.\n\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.Trim();

            foreach (DataGridViewRow row in dgvVoucher.Rows)
            {
                string code = Convert.ToString(row.Cells["MaCode"].Value);
                row.Visible = string.IsNullOrWhiteSpace(key) ||
                    code.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            if (dgvVoucher.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một voucher.", "Voucher",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int ma = Convert.ToInt32(dgvVoucher.CurrentRow.Cells["MaVoucher"].Value);
            string code = Convert.ToString(dgvVoucher.CurrentRow.Cells["MaCode"].Value);
            decimal giaTri = Convert.ToDecimal(dgvVoucher.CurrentRow.Cells["GiaTri"].Value);
            decimal toiThieu = Convert.ToDecimal(dgvVoucher.CurrentRow.Cells["GiaTriDonToiThieu"].Value);
            string loai = Convert.ToString(dgvVoucher.CurrentRow.Cells["LoaiGiam"].Value);

            if (tongTienDonHang < toiThieu)
            {
                MessageBox.Show("Đơn hàng chưa đạt tối thiểu " + toiThieu.ToString("N0") + " đ.",
                    "Voucher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal giam = loai.Equals("PhanTram", StringComparison.OrdinalIgnoreCase)
                ? tongTienDonHang * giaTri / 100m
                : giaTri;

            if (giam > tongTienDonHang) giam = tongTienDonHang;

            MaVoucherDuocChon = ma;
            MaCodeDuocChon = code;
            SoTienGiam = Math.Max(0m, giam);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnBoChon_Click(object sender, EventArgs e)
        {
            MaVoucherDuocChon = 0;
            MaCodeDuocChon = null;
            SoTienGiam = 0;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadVoucher();
        }
    }
}

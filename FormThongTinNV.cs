using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormThongTinNV : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private readonly int maTK;
        private readonly string tenDangNhap;
        private readonly string vaiTro;

        public int MaNVMoi { get; private set; }

        public FormThongTinNV(int maTK, string tenDangNhap, string vaiTro)
        {
            InitializeComponent();
            this.maTK = maTK;
            this.tenDangNhap = tenDangNhap ?? "";
            this.vaiTro = vaiTro ?? "";

            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;
            cboChucVu.SelectedIndexChanged += cboChucVu_SelectedIndexChanged;
        }

        private void FormThongTinNV_Load(object sender, EventArgs e)
        {
            try
            {
                lblMaTKValue.Text = maTK.ToString();
                lblTaiKhoanValue.Text = tenDangNhap;

                cboChucVu.Items.Clear();
                cboChucVu.Items.Add("Nhân viên bán hàng");
                cboChucVu.Items.Add("Nhân viên kho");

                cboGioiTinh.Items.Clear();
                cboGioiTinh.Items.Add("Nam");
                cboGioiTinh.Items.Add("Nữ");
                cboGioiTinh.Items.Add("Khác");
                cboGioiTinh.SelectedIndex = 0;

                cboKho.Items.Clear();
                cboKho.Items.Add(new KhoItem(0, "-- Không chọn kho --"));

                DataTable dt = kt.GetData(@"
SELECT MaKho, TenKho
FROM dbo.Kho
WHERE ISNULL(TrangThai,1)=1
ORDER BY MaKho;");

                foreach (DataRow r in dt.Rows)
                    cboKho.Items.Add(new KhoItem(
                        Convert.ToInt32(r["MaKho"]),
                        r["TenKho"] == DBNull.Value ? "" : r["TenKho"].ToString()));

                cboKho.SelectedIndex = 0;

                int i = cboChucVu.FindStringExact(vaiTro);
                cboChucVu.SelectedIndex = i >= 0 ? i : 0;

                dtpNgaySinh.Value = DateTime.Today.AddYears(-20);
                chkTrangThai.Checked = true;
                txtHoTen.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu hồ sơ nhân viên.\r\n\r\n" + ex.Message,
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLuu.Enabled = false;
            }
        }

        private void cboChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool laKho = cboChucVu.Text == "Nhân viên kho";
            cboKho.Enabled = laKho;
            lblKhoHint.Text = laKho
                ? "Chọn kho mà nhân viên kho phụ trách."
                : "Kho chỉ áp dụng cho Nhân viên kho.";
            if (!laKho && cboKho.Items.Count > 0)
                cboKho.SelectedIndex = 0;
        }

        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                return Loi("Vui lòng nhập họ tên.", txtHoTen);

            if (cboChucVu.SelectedIndex < 0)
                return Loi("Vui lòng chọn chức vụ.", cboChucVu);

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                return Loi("Email bắt buộc vì Email trong NhanVien đang UNIQUE.", txtEmail);

            string email = txtEmail.Text.Trim();
            if (!email.Contains("@") || !email.Contains("."))
                return Loi("Email chưa đúng định dạng.", txtEmail);

            if (dtpNgaySinh.Value.Date > DateTime.Today)
                return Loi("Ngày sinh không được lớn hơn hôm nay.", dtpNgaySinh);

            if (!string.IsNullOrWhiteSpace(txtSDT.Text) &&
                (txtSDT.Text.Trim().Length < 9 || txtSDT.Text.Trim().Length > 15))
                return Loi("Số điện thoại phải từ 9 đến 15 ký tự.", txtSDT);

            decimal luong;
            if (!decimal.TryParse(txtLuong.Text.Trim(), out luong) || luong < 0)
                return Loi("Lương phải là số >= 0.", txtLuong);

            if (cboChucVu.Text == "Nhân viên kho" &&
                (cboKho.SelectedItem as KhoItem == null ||
                 ((KhoItem)cboKho.SelectedItem).MaKho <= 0))
                return Loi("Nhân viên kho phải được chọn kho phụ trách.", cboKho);

            return true;
        }

        private bool Loi(string msg, Control c)
        {
            MessageBox.Show(msg, "Dữ liệu chưa hợp lệ",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            c.Focus();
            return false;
        }

        private object GioiTinhValue()
        {
            if (cboGioiTinh.Text == "Nam") return true;
            if (cboGioiTinh.Text == "Nữ") return false;
            return DBNull.Value;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTra()) return;

            try
            {
                using (SqlConnection conn = kt.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand check = new SqlCommand(@"
SELECT COUNT(*) FROM dbo.NhanVien WHERE MaTK=@MaTK;", conn, tran))
                            {
                                check.Parameters.Add("@MaTK", SqlDbType.Int).Value = maTK;
                                if (Convert.ToInt32(check.ExecuteScalar()) > 0)
                                    throw new Exception("Tài khoản này đã có hồ sơ NhanVien.");
                            }

                            using (SqlCommand check = new SqlCommand(@"
SELECT COUNT(*) FROM dbo.NhanVien WHERE Email=@Email;", conn, tran))
                            {
                                check.Parameters.Add("@Email", SqlDbType.VarChar, 255).Value = txtEmail.Text.Trim();
                                if (Convert.ToInt32(check.ExecuteScalar()) > 0)
                                    throw new Exception("Email này đã tồn tại trong NhanVien.");
                            }

                            KhoItem kho = cboKho.SelectedItem as KhoItem;
                            object maKho = (cboChucVu.Text == "Nhân viên kho" && kho != null && kho.MaKho > 0)
                                ? (object)kho.MaKho : DBNull.Value;

                            using (SqlCommand cmd = new SqlCommand(@"
INSERT INTO dbo.NhanVien
(HoTen,ChucVu,GioiTinh,NgaySinh,SDT,Email,DiaChi,Luong,TrangThai,MaTK,MaKho)
OUTPUT INSERTED.MaNV
VALUES
(@HoTen,@ChucVu,@GioiTinh,@NgaySinh,@SDT,@Email,@DiaChi,@Luong,@TrangThai,@MaTK,@MaKho);",
                                conn, tran))
                            {
                                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = txtHoTen.Text.Trim();
                                cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar, 100).Value = cboChucVu.Text.Trim();
                                cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = GioiTinhValue();
                                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtpNgaySinh.Value.Date;
                                cmd.Parameters.Add("@SDT", SqlDbType.VarChar, 30).Value =
                                    string.IsNullOrWhiteSpace(txtSDT.Text) ? (object)DBNull.Value : txtSDT.Text.Trim();
                                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 255).Value = txtEmail.Text.Trim();
                                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 255).Value =
                                    string.IsNullOrWhiteSpace(txtDiaChi.Text) ? (object)DBNull.Value : txtDiaChi.Text.Trim();

                                decimal luong;
                                decimal.TryParse(txtLuong.Text.Trim(), out luong);
                                SqlParameter pLuong = cmd.Parameters.Add("@Luong", SqlDbType.Decimal);
                                pLuong.Precision = 18; pLuong.Scale = 2; pLuong.Value = luong;

                                cmd.Parameters.Add("@TrangThai", SqlDbType.Bit).Value = chkTrangThai.Checked;
                                cmd.Parameters.Add("@MaTK", SqlDbType.Int).Value = maTK;
                                cmd.Parameters.Add("@MaKho", SqlDbType.Int).Value = maKho;

                                MaNVMoi = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            tran.Commit();
                        }
                        catch
                        {
                            try { tran.Rollback(); } catch { }
                            throw;
                        }
                    }
                }

                MessageBox.Show(
                    "Tạo hồ sơ nhân viên thành công!\r\n\r\n" +
                    "Mã NV: NV" + MaNVMoi.ToString("D4") +
                    "\r\nTài khoản: " + tenDangNhap +
                    "\r\nChức vụ: " + cboChucVu.Text,
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể lưu hồ sơ nhân viên.\r\n\r\n" + ex.Message,
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát mà không lưu hồ sơ?",
                "Xác nhận", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private sealed class KhoItem
        {
            public int MaKho { get; private set; }
            public string TenKho { get; private set; }

            public KhoItem(int maKho, string tenKho)
            {
                MaKho = maKho;
                TenKho = tenKho;
            }

            public override string ToString()
            {
                return MaKho <= 0 ? TenKho : "Kho " + MaKho + " - " + TenKho;
            }
        }
    }
}

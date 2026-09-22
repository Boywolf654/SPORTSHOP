using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormThongTinNV : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private readonly int maTK;
        private readonly string tenDangNhap;
        private readonly string vaiTro;

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

                LoadComboBox();

                DataTable dt = kt.GetData(@"
SELECT TOP 1
    MaNV,
    HoTen,
    ChucVu,
    GioiTinh,
    NgaySinh,
    SDT,
    Email,
    DiaChi,
    Luong,
    TrangThai,
    MaKho
FROM dbo.NhanVien
WHERE MaTK = @MaTK;",
                    new SqlParameter[]
                    {
                        new SqlParameter("@MaTK", maTK)
                    });

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Không tìm thấy hồ sơ nhân viên của tài khoản này.",
                        "SPORTSHOP",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    btnLuu.Enabled = false;
                    return;
                }

                DataRow row = dt.Rows[0];

                txtHoTen.Text = GetString(row, "HoTen");
                txtSDT.Text = GetString(row, "SDT");
                txtEmail.Text = GetString(row, "Email");
                txtDiaChi.Text = GetString(row, "DiaChi");
                txtLuong.Text = GetString(row, "Luong");

                SetComboText(cboChucVu, GetString(row, "ChucVu"));

                if (row["GioiTinh"] == DBNull.Value)
                    cboGioiTinh.SelectedItem = "Khác";
                else
                    cboGioiTinh.SelectedItem =
                        Convert.ToBoolean(row["GioiTinh"]) ? "Nam" : "Nữ";

                if (row["NgaySinh"] != DBNull.Value)
                {
                    DateTime ngaySinh = Convert.ToDateTime(row["NgaySinh"]);

                    if (ngaySinh >= dtpNgaySinh.MinDate &&
                        ngaySinh <= dtpNgaySinh.MaxDate)
                    {
                        dtpNgaySinh.Value = ngaySinh;
                    }
                }

                chkTrangThai.Checked =
                    row["TrangThai"] != DBNull.Value &&
                    Convert.ToBoolean(row["TrangThai"]);

                int maKho = row["MaKho"] == DBNull.Value
                    ? 0
                    : Convert.ToInt32(row["MaKho"]);

                SelectKho(maKho);

                // Nhân viên chỉ chỉnh thông tin cá nhân.
                // Chức vụ, lương và trạng thái do quản lý quản lý.
                cboChucVu.Enabled = false;
                txtLuong.ReadOnly = true;
                chkTrangThai.Enabled = false;

                cboKho.Enabled = cboChucVu.Text == "Nhân viên kho";
                lblKhoHint.Text = cboKho.Enabled
                    ? "Kho mà nhân viên kho đang phụ trách."
                    : "Kho do quản lý thiết lập.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải thông tin nhân viên.\r\n\r\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                btnLuu.Enabled = false;
            }
        }

        private void LoadComboBox()
        {
            cboChucVu.Items.Clear();
            cboChucVu.Items.Add("Nhân viên bán hàng");
            cboChucVu.Items.Add("Nhân viên kho");

            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.Items.Add("Khác");

            cboKho.Items.Clear();
            cboKho.Items.Add(new KhoItem(0, "-- Không chọn kho --"));

            DataTable dt = kt.GetData(@"
SELECT MaKho, TenKho
FROM dbo.Kho
WHERE ISNULL(TrangThai,1) = 1
ORDER BY MaKho;");

            foreach (DataRow r in dt.Rows)
            {
                cboKho.Items.Add(
                    new KhoItem(
                        Convert.ToInt32(r["MaKho"]),
                        r["TenKho"] == DBNull.Value
                            ? ""
                            : r["TenKho"].ToString()));
            }
        }

        private string GetString(DataRow row, string columnName)
        {
            return row[columnName] == DBNull.Value
                ? ""
                : row[columnName].ToString();
        }

        private void SetComboText(ComboBox combo, string value)
        {
            int index = combo.FindStringExact(value);

            if (index >= 0)
                combo.SelectedIndex = index;
            else if (combo.Items.Count > 0)
                combo.SelectedIndex = 0;
        }

        private void SelectKho(int maKho)
        {
            for (int i = 0; i < cboKho.Items.Count; i++)
            {
                KhoItem item = cboKho.Items[i] as KhoItem;

                if (item != null && item.MaKho == maKho)
                {
                    cboKho.SelectedIndex = i;
                    return;
                }
            }

            if (cboKho.Items.Count > 0)
                cboKho.SelectedIndex = 0;
        }

        private void cboChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool laKho = cboChucVu.Text == "Nhân viên kho";

            cboKho.Enabled = laKho;

            lblKhoHint.Text = laKho
                ? "Kho mà nhân viên kho đang phụ trách."
                : "Kho do quản lý thiết lập.";
        }

        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                return Loi("Vui lòng nhập họ tên.", txtHoTen);

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                return Loi("Email không được để trống.", txtEmail);

            string email = txtEmail.Text.Trim();

            if (!email.Contains("@") || !email.Contains("."))
                return Loi("Email chưa đúng định dạng.", txtEmail);

            if (dtpNgaySinh.Value.Date > DateTime.Today)
                return Loi("Ngày sinh không được lớn hơn hôm nay.", dtpNgaySinh);

            string sdt = txtSDT.Text.Trim();

            if (!string.IsNullOrWhiteSpace(sdt) &&
                (sdt.Length < 9 || sdt.Length > 15))
            {
                return Loi(
                    "Số điện thoại phải từ 9 đến 15 ký tự.",
                    txtSDT);
            }

            return true;
        }

        private bool Loi(string msg, Control control)
        {
            MessageBox.Show(
                msg,
                "Dữ liệu chưa hợp lệ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            control.Focus();
            return false;
        }

        private object GioiTinhValue()
        {
            if (cboGioiTinh.Text == "Nam")
                return true;

            if (cboGioiTinh.Text == "Nữ")
                return false;

            return DBNull.Value;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTra())
                return;

            try
            {
                using (SqlConnection conn = kt.GetConnection())
                {
                    conn.Open();

                    using (SqlCommand check = new SqlCommand(@"
SELECT COUNT(*)
FROM dbo.NhanVien
WHERE Email = @Email
  AND MaTK <> @MaTK;", conn))
                    {
                        check.Parameters.Add(
                            "@Email",
                            SqlDbType.VarChar,
                            255).Value = txtEmail.Text.Trim();

                        check.Parameters.Add(
                            "@MaTK",
                            SqlDbType.Int).Value = maTK;

                        if (Convert.ToInt32(check.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show(
                                "Email này đã được sử dụng bởi nhân viên khác.",
                                "SPORTSHOP",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            txtEmail.Focus();
                            return;
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(@"
UPDATE dbo.NhanVien
SET
    HoTen = @HoTen,
    GioiTinh = @GioiTinh,
    NgaySinh = @NgaySinh,
    SDT = @SDT,
    Email = @Email,
    DiaChi = @DiaChi
WHERE MaTK = @MaTK;", conn))
                    {
                        cmd.Parameters.Add(
                            "@HoTen",
                            SqlDbType.NVarChar,
                            100).Value = txtHoTen.Text.Trim();

                        cmd.Parameters.Add(
                            "@GioiTinh",
                            SqlDbType.Bit).Value = GioiTinhValue();

                        cmd.Parameters.Add(
                            "@NgaySinh",
                            SqlDbType.Date).Value = dtpNgaySinh.Value.Date;

                        cmd.Parameters.Add(
                            "@SDT",
                            SqlDbType.VarChar,
                            30).Value =
                            string.IsNullOrWhiteSpace(txtSDT.Text)
                                ? (object)DBNull.Value
                                : txtSDT.Text.Trim();

                        cmd.Parameters.Add(
                            "@Email",
                            SqlDbType.VarChar,
                            255).Value = txtEmail.Text.Trim();

                        cmd.Parameters.Add(
                            "@DiaChi",
                            SqlDbType.NVarChar,
                            255).Value =
                            string.IsNullOrWhiteSpace(txtDiaChi.Text)
                                ? (object)DBNull.Value
                                : txtDiaChi.Text.Trim();

                        cmd.Parameters.Add(
                            "@MaTK",
                            SqlDbType.Int).Value = maTK;

                        int affected = cmd.ExecuteNonQuery();

                        if (affected <= 0)
                        {
                            MessageBox.Show(
                                "Không tìm thấy hồ sơ để cập nhật.",
                                "SPORTSHOP",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Cập nhật thông tin nhân viên thành công!",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Không thể cập nhật thông tin nhân viên.\r\n\r\n" +
                    ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể cập nhật thông tin nhân viên.\r\n\r\n" +
                    ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
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
                return MaKho <= 0
                    ? TenKho
                    : "Kho " + MaKho + " - " + TenKho;
            }
        }
    }
}

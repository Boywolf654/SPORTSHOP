using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormDangNhapID : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        public FormDangNhapID()
        {
            InitializeComponent();

            btnDangNhap.Click += btnDangNhap_Click;
            btnHuy.Click += btnHuy_Click;

            txtID.KeyDown += txtID_KeyDown;
            txtMatKhau.KeyDown += txtMatKhau_KeyDown;

            chkHienMatKhau.CheckedChanged +=
                chkHienMatKhau_CheckedChanged;
        }
        private void FormDangNhapID_Load(object sender, EventArgs e)
        {
        }
        private void btnDangNhap_Click(
            object sender,
            EventArgs e)
        {
            DangNhap();
        }

        private void txtID_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                DangNhap();
            }
        }

        private void txtMatKhau_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                DangNhap();
            }
        }

        private void chkHienMatKhau_CheckedChanged(
            object sender,
            EventArgs e)
        {
            txtMatKhau.PasswordChar =
                chkHienMatKhau.Checked
                    ? '\0'
                    : '●';
        }

        private void btnHuy_Click(
            object sender,
            EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DangNhap()
        {
            string thongTinDangNhap =
                txtID.Text.Trim();

            string matKhau =
                txtMatKhau.Text;

            if (string.IsNullOrWhiteSpace(thongTinDangNhap))
            {
                lblTrangThai.Text =
                    "Vui lòng nhập ID nhân viên hoặc tài khoản.";

                txtID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                lblTrangThai.Text =
                    "Vui lòng nhập mật khẩu.";

                txtMatKhau.Focus();
                return;
            }

            try
            {
                string sql = @"
                    SELECT TOP 1
                        tk.MaTK,
                        tk.TenDangNhap,
                        tk.MatKhau,
                        tk.MaVaiTro,
                        tk.TrangThai AS TrangThaiTK,
                        nv.MaNV,
                        nv.HoTen,
                        nv.TrangThai AS TrangThaiNV
                    FROM TaiKhoan tk
                    INNER JOIN NhanVien nv
                        ON nv.MaTK = tk.MaTK
                    WHERE
                    (
                        CONVERT(VARCHAR(20), nv.MaNV)
                            = @ThongTinDangNhap
                        OR
                        tk.TenDangNhap
                            = @ThongTinDangNhap
                    )
                    AND tk.MatKhau = @MatKhau
                    AND ISNULL(tk.TrangThai, 1) = 1
                    AND ISNULL(nv.TrangThai, 1) = 1
                    AND tk.MaVaiTro = @MaVaiTro";

                SqlParameter[] parameters =
                {
                    new SqlParameter(
                        "@ThongTinDangNhap",
                        thongTinDangNhap),

                    new SqlParameter(
                        "@MatKhau",
                        matKhau),

                    new SqlParameter(
                        "@MaVaiTro",
                        PhanQuyen.NV_BAN_HANG)
                };

                DataTable dt =
                    kt.GetData(
                        sql,
                        parameters);

                if (dt.Rows.Count == 0)
                {
                    lblTrangThai.Text =
                        "ID/Tài khoản hoặc mật khẩu không đúng.";

                    txtMatKhau.SelectAll();
                    txtMatKhau.Focus();

                    return;
                }

                DataRow row = dt.Rows[0];

                int maTK =
                    Convert.ToInt32(row["MaTK"]);

                string tenDangNhap =
                    Convert.ToString(row["TenDangNhap"]);

                int maVaiTro =
                    Convert.ToInt32(row["MaVaiTro"]);

                int maNV =
                    Convert.ToInt32(row["MaNV"]);

                string hoTen =
                    Convert.ToString(row["HoTen"]);

                // ==========================================
                // CẬP NHẬT SESSION
                // ==========================================

                Session.MaTK = maTK;
                Session.TenDangNhap = tenDangNhap;
                Session.MaVaiTro = maVaiTro;
                Session.MaNV = maNV;

                try
                {
                    Session.TenVaiTro =
                        "Nhân viên bán hàng";
                }
                catch
                {
                }

                // ==========================================
                // RESET SỐ LẦN SAI
                // ==========================================

                string sqlReset = @"
                    UPDATE TaiKhoan
                    SET
                        SoLanSaiMatKhau = 0,
                        LanDangNhapCuoi = GETDATE()
                    WHERE MaTK = @MaTK";

                SqlParameter[] pReset =
                {
                    new SqlParameter(
                        "@MaTK",
                        maTK)
                };

                kt.Execute(
                    sqlReset,
                    pReset);

                MessageBox.Show(
                    "Đăng nhập thành công!\n\n" +
                    "Nhân viên: " + hoTen,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // ==========================================
                // BÁO CHO FORM MÀN HÌNH KHÓA:
                // ĐĂNG NHẬP THÀNH CÔNG
                // ==========================================

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (SqlException ex)
            {
                lblTrangThai.Text =
                    "Không thể kết nối CSDL.";

                MessageBox.Show(
                    "Lỗi SQL:\n\n" +
                    ex.Message,
                    "Lỗi đăng nhập",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                lblTrangThai.Text =
                    "Có lỗi xảy ra.";

                MessageBox.Show(
                    ex.Message,
                    "Lỗi đăng nhập",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void pnlMain_Paint(
            object sender,
            PaintEventArgs e)
        {
            using (
                var pen =
                    new System.Drawing.Pen(
                        System.Drawing.Color.FromArgb(
                            80,
                            80,
                            80),
                        1))
            {
                e.Graphics.DrawRectangle(
                    pen,
                    0,
                    0,
                    pnlMain.Width - 1,
                    pnlMain.Height - 1);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormDangKy : Form
    {
        KetNoiDuLieu kt = new KetNoiDuLieu();
        public FormDangKy()
        {
            InitializeComponent();
        }

        private void FormDangKy_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn_DangKy.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn_DangKy.Width - radius, btn_DangKy.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn_DangKy.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            btn_DangKy.Region = new Region(path);
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string nhapLaiPassword = txtNhapLaiPassword.Text;

            // 1. Kiểm tra rỗng
            if (string.IsNullOrEmpty(hoTen) ||
                string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(nhapLaiPassword))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 2. Kiểm tra mật khẩu nhập lại
            if (password != nhapLaiPassword)
            {
                MessageBox.Show(
                    "Mật khẩu nhập lại không khớp!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNhapLaiPassword.Clear();
                txtNhapLaiPassword.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = kt.GetConnection())
                {
                    conn.Open();

                    // Bắt đầu SqlTransaction cho toàn bộ quá trình đăng ký
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 3. Kiểm tra tên đăng nhập đã tồn tại chưa
                            string checkSql = @"
                                SELECT COUNT(*)
                                FROM dbo.TaiKhoan
                                WHERE TenDangNhap = @TenDangNhap";

                            using (SqlCommand cmdCheck = new SqlCommand(checkSql, conn, transaction))
                            {
                                cmdCheck.Parameters.AddWithValue("@TenDangNhap", username);

                                int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

                                if (count > 0)
                                {
                                    MessageBox.Show(
                                        "Tên đăng nhập đã tồn tại!",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning
                                    );

                                    txtUsername.Focus();
                                    transaction.Rollback();
                                    return;
                                }
                            }

                            // 4. Thêm tài khoản với vai trò Khách hàng (PhanQuyen.KHACH_HANG)
                            string insertTaiKhoanSql = @"
                                INSERT INTO dbo.TaiKhoan (TenDangNhap, MatKhau, MaVaiTro)
                                VALUES (@TenDangNhap, @MatKhau, @MaVaiTro);
                                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                            int maTK;

                            using (SqlCommand cmdTaiKhoan = new SqlCommand(insertTaiKhoanSql, conn, transaction))
                            {
                                cmdTaiKhoan.Parameters.AddWithValue("@TenDangNhap", username);
                                cmdTaiKhoan.Parameters.AddWithValue("@MatKhau", password);
                                cmdTaiKhoan.Parameters.AddWithValue("@MaVaiTro", PhanQuyen.KHACH_HANG);

                                // Lấy chính xác MaTK vừa tạo bằng SELECT CAST(SCOPE_IDENTITY() AS INT)
                                object result = cmdTaiKhoan.ExecuteScalar();
                                if (result == null || result == DBNull.Value)
                                {
                                    throw new Exception("Không thể lấy mã tài khoản vừa tạo.");
                                }
                                maTK = Convert.ToInt32(result);
                            }

                            // 5. Thêm thông tin khách hàng tương ứng (dbo.KhachHang)
                            string insertKhachHangSql = @"
                                INSERT INTO dbo.KhachHang (HoTen, MaTK)
                                VALUES (@HoTen, @MaTK)";

                            using (SqlCommand cmdKhachHang = new SqlCommand(insertKhachHangSql, conn, transaction))
                            {
                                cmdKhachHang.Parameters.AddWithValue("@HoTen", hoTen);
                                cmdKhachHang.Parameters.AddWithValue("@MaTK", maTK);

                                cmdKhachHang.ExecuteNonQuery();
                            }

                            // 6. Chỉ Commit khi cả hai INSERT thành công
                            transaction.Commit();

                            MessageBox.Show(
                                "Đăng ký tài khoản thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                            // 7. Quay về form đăng nhập
                            Formdangnhap frm = new Formdangnhap();
                            frm.Show();
                            this.Hide();
                        }
                        catch
                        {
                            // Nếu một trong hai INSERT lỗi -> Rollback cả TaiKhoan và KhachHang
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi đăng ký: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}

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

                    // Bắt đầu transaction
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 3. Kiểm tra tên đăng nhập đã tồn tại chưa
                            string checkSql = @"
                        SELECT COUNT(*)
                        FROM TAIKHOAN
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

                            // 4. Thêm tài khoản
                            // MaVaiTro = 4 => Khách hàng
                            string insertTaiKhoanSql = @"
                        INSERT INTO TAIKHOAN
                            (TenDangNhap, MatKhau, MaVaiTro)
                        OUTPUT INSERTED.MaTK
                        VALUES
                            (@TenDangNhap, @MatKhau, 4)";

                            int maTK;

                            using (SqlCommand cmdTaiKhoan =
                                   new SqlCommand(insertTaiKhoanSql, conn, transaction))
                            {
                                cmdTaiKhoan.Parameters.AddWithValue("@TenDangNhap", username);
                                cmdTaiKhoan.Parameters.AddWithValue("@MatKhau", password);

                                // Lấy MaTK vừa tạo
                                maTK = Convert.ToInt32(cmdTaiKhoan.ExecuteScalar());
                            }

                            // 5. Thêm khách hàng
                            string insertKhachHangSql = @"
                        INSERT INTO KHACHHANG
                            (TenKH, MaTK)
                        VALUES
                            (@TenKH, @MaTK)";

                            using (SqlCommand cmdKhachHang =
                                   new SqlCommand(insertKhachHangSql, conn, transaction))
                            {
                                cmdKhachHang.Parameters.AddWithValue("@TenKH", hoTen);
                                cmdKhachHang.Parameters.AddWithValue("@MaTK", maTK);

                                cmdKhachHang.ExecuteNonQuery();
                            }

                            // 6. Xác nhận transaction
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
                            // Nếu một trong hai INSERT lỗi
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

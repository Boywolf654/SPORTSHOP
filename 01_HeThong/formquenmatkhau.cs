using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class formquenmatkhau : Form
    {
        KetNoiDuLieu kt = new KetNoiDuLieu();

        public formquenmatkhau()
        {
            InitializeComponent();
            txt_matkhaumoi.PasswordChar = '*';
            txt_xacnhan.PasswordChar = '*';
        }

        private void btn_doipass_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text.Trim();
            string matKhauMoi = txt_matkhaumoi.Text;
            string xacNhan = txt_xacnhan.Text;

            // Kiểm tra bỏ trống
            if (username == "" || matKhauMoi == "" || xacNhan == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Kiểm tra mật khẩu xác nhận
            if (matKhauMoi != xacNhan)
            {
                MessageBox.Show(
                    "Mật khẩu xác nhận không khớp!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Kiểm tra tài khoản có tồn tại không
            string sqlCheck = @"
                SELECT COUNT(*)
                FROM TaiKhoan
                WHERE TenDangNhap = @username
                  AND TrangThai = 1";

            SqlParameter[] checkParams =
            {
                new SqlParameter("@username", username)
            };

            int count = Convert.ToInt32(
                kt.ExecuteScalar(sqlCheck, checkParams)
            );

            if (count == 0)
            {
                MessageBox.Show(
                    "Tên đăng nhập không tồn tại!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            // Đổi mật khẩu
            string sqlUpdate = @"
                UPDATE TaiKhoan
                SET MatKhau = @matkhau
                WHERE TenDangNhap = @username
                  AND TrangThai = 1";

            SqlParameter[] updateParams =
            {
                new SqlParameter("@matkhau", matKhauMoi),
                new SqlParameter("@username", username)
            };

            int result = kt.Execute(sqlUpdate, updateParams);

            if (result > 0)
            {
                MessageBox.Show(
                    "Đổi mật khẩu thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Đóng form quên mật khẩu
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Đổi mật khẩu thất bại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

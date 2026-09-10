using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPORTSHOP
  
{
    
    public partial class Formdangnhap : Form
    {
        KetNoiDuLieu kt = new KetNoiDuLieu();
        public Formdangnhap()
        {

            InitializeComponent();

            // Ẩn mật khẩu mặc định
            txt_pass.PasswordChar = '*';

            // Thứ tự Tab
            txt_username.TabIndex = 0;
            txt_pass.TabIndex = 1;
            pass_check.TabIndex = 2;

            // Tự động focus vào ô tên đăng nhập
            this.Shown += Formdangnhap_Shown;

            // Checkbox hiện mật khẩu
            pass_check.CheckedChanged += pass_check_CheckedChanged;
        }
        private void Formdangnhap_Shown(object sender, EventArgs e)
        {
            txt_username.Focus();
            txt_username.SelectAll();
        }

        private void pass_check_CheckedChanged(
    object sender,
    EventArgs e)
        {
            if (pass_check.Checked)
            {
                // Hiện mật khẩu
                txt_pass.PasswordChar = '\0';
            }
            else
            {
                // Ẩn mật khẩu
                txt_pass.PasswordChar = '*';
            }
        }
        private void Formdangnhap_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
            using (Pen pen = new Pen(Color.Gold, 2))
            {
                e.Graphics.DrawRectangle(
                    pen,
                    0,
                    0,
                    panel1.Width - 1,
                    panel1.Height - 1
                );
            }
        }

        public class RoundedTextBox : TextBox
        {
            public int BorderRadius { get; set; } = 12;
            public Color BorderColor { get; set; } = Color.Gold;

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
            }
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu người dùng nhập
            string username = txt_username.Text.Trim();
            string password = txt_pass.Text;

            // Kiểm tra bỏ trống
            if (username == "" || password == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ tài khoản và mật khẩu!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Kiểm tra tài khoản + mật khẩu + trạng thái
            string sql = @"
                        SELECT 
                            tk.MaTK,
                            tk.TenDangNhap,
                            tk.MatKhau,
                            tk.MaVaiTro,
                            tk.TrangThai,
                            vt.TenVaiTro
                        FROM TaiKhoan tk
                        INNER JOIN VaiTro vt
                            ON tk.MaVaiTro = vt.MaVaiTro
                        WHERE tk.TenDangNhap = @username
                          AND tk.MatKhau = @password
                          AND tk.TrangThai = 1";

            SqlParameter[] parameters =
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };

            DataTable dt = kt.GetData(sql, parameters);

            // Không tìm thấy tài khoản
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Tài khoản hoặc mật khẩu không chính xác!",
                    "Đăng nhập thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txt_pass.Clear();
                txt_pass.Focus();

                return;
            }

            // ==========================
            // ĐĂNG NHẬP THÀNH CÔNG
            // ==========================

            TaiKhoan tk = new TaiKhoan();

            tk.MaTK = Convert.ToInt32(dt.Rows[0]["MaTK"]);
            tk.TenDangNhap = dt.Rows[0]["TenDangNhap"].ToString();
            tk.MatKhau = dt.Rows[0]["MatKhau"].ToString();
            tk.MaVaiTro = Convert.ToInt32(dt.Rows[0]["MaVaiTro"]);
            tk.TrangThai = Convert.ToBoolean(dt.Rows[0]["TrangThai"]);

            // ==========================
            // LƯU THÔNG TIN ĐĂNG NHẬP
            // ==========================

            Session.MaTK = tk.MaTK;
            Session.TenDangNhap = tk.TenDangNhap;
            Session.MaVaiTro = tk.MaVaiTro;
            Session.TenVaiTro = dt.Rows[0]["TenVaiTro"].ToString();

            

            // ==========================
            // THÔNG BÁO
            // ==========================

            MessageBox.Show(
                "Đăng nhập thành công!\n\n" +
                "Tài khoản: " + Session.TenDangNhap + "\n" +
                "Vai trò: " + Session.TenVaiTro,
                "Đăng nhập",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // ==========================
            // MỞ FORM CHÍNH
            // ==========================

            FromKho frm = new FromKho();
            frm.Show();

            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formquenmatkhau frm = new formquenmatkhau();
            frm.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDangKy frm = new FormDangKy();
            frm.ShowDialog();
        }
    }
 }


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
            txt_pass.PasswordChar = '*';
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
                    MaTK,
                    TenDangNhap,
                    MatKhau,
                    MaVaiTro,
                    TrangThai
                FROM TaiKhoan
                WHERE TenDangNhap = @username
                  AND MatKhau = @password
                  AND TrangThai = 1";

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
            // PHÂN QUYỀN
            // ==========================

            if (tk.MaVaiTro == 1)
            {
                MessageBox.Show("Đăng nhập thành công!\nQuyền: Admin");

                // TODO: mở Form Admin
                 //FormAdmin frm = new FormAdmin(tk);
                // frm.Show();
            }
            else if (tk.MaVaiTro == 2)
            {
                MessageBox.Show("Đăng nhập thành công!\nQuyền: Quản lý");

                // TODO: mở Form Quản lý
            }
            else if (tk.MaVaiTro == 3)
            {
                MessageBox.Show("Đăng nhập thành công!\nQuyền: Nhân viên");

                // TODO: mở Form Nhân viên
            }
            else
            {
                MessageBox.Show(
                    "Tài khoản chưa được cấp quyền!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }
        }
    }
 }


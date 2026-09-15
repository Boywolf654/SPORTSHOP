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
    public partial class FormThemNhaCungCap : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();
        public FormThemNhaCungCap()
        {
            InitializeComponent();
            // Gắn sự kiện nút
        }

        private void FormThemNhaCungCap_Load(object sender, EventArgs e)
        {

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string tenNCC = txt_TenNCC.Text.Trim();
            string sdt = txt_SDT.Text.Trim();
            string email = txt_email.Text.Trim();
            string diaChi = txt_diachi.Text.Trim();

            // -------------------------
            // KIỂM TRA TÊN NCC
            // -------------------------
            if (string.IsNullOrWhiteSpace(tenNCC))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên nhà cung cấp.",
                    "Thiếu thông tin",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txt_TenNCC.Focus();
                return;
            }

            // -------------------------
            // KIỂM TRA SĐT
            // -------------------------
            if (!string.IsNullOrWhiteSpace(sdt))
            {
                if (sdt.Length != 10)
                {
                    MessageBox.Show(
                        "Số điện thoại phải gồm 10 số.",
                        "Dữ liệu không hợp lệ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txt_SDT.Focus();
                    return;
                }

                foreach (char c in sdt)
                {
                    if (!char.IsDigit(c))
                    {
                        MessageBox.Show(
                            "Số điện thoại chỉ được chứa số.",
                            "Dữ liệu không hợp lệ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txt_SDT.Focus();
                        return;
                    }
                }
            }

            // -------------------------
            // KIỂM TRA EMAIL
            // -------------------------
            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!email.Contains("@") || !email.Contains("."))
                {
                    MessageBox.Show(
                        "Email không hợp lệ.",
                        "Dữ liệu không hợp lệ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txt_email.Focus();
                    return;
                }
            }

            try
            {
                string sql = @"
                    INSERT INTO NhaCungCap
                    (
                        TenNCC,
                        SDT,
                        Email,
                        DiaChi,
                        TrangThai
                    )
                    VALUES
                    (
                        @TenNCC,
                        @SDT,
                        @Email,
                        @DiaChi,
                        1
                    )";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@TenNCC", tenNCC),

                    new SqlParameter("@SDT",
                        string.IsNullOrWhiteSpace(sdt)
                            ? (object)DBNull.Value
                            : sdt),

                    new SqlParameter("@Email",
                        string.IsNullOrWhiteSpace(email)
                            ? (object)DBNull.Value
                            : email),

                    new SqlParameter("@DiaChi",
                        string.IsNullOrWhiteSpace(diaChi)
                            ? (object)DBNull.Value
                            : diaChi)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show(
                    "Thêm nhà cung cấp thành công!",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Báo cho FormNhaCungCap biết đã thêm thành công
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể thêm nhà cung cấp.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

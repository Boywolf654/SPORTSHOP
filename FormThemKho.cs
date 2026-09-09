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
    public partial class FormThemKho : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        public FormThemKho()
        {
            InitializeComponent();
        }

        private void FormThemKho_Load(object sender, EventArgs e)
        {

        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string tenKho = txt_tenkho.Text.Trim();
            string diaChi = txt_diachi.Text.Trim();
            string moTa = txt_mota.Text.Trim();

            // Kiểm tra tên kho
            if (string.IsNullOrWhiteSpace(tenKho))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên kho!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txt_tenkho.Focus();
                return;
            }

            // Kiểm tra trùng tên kho
            string sqlKiemTra = @"
                SELECT COUNT(*)
                FROM Kho
                WHERE TenKho = @TenKho";

            SqlParameter[] pKiemTra =
            {
                new SqlParameter("@TenKho", tenKho)
            };

            int soLuong = Convert.ToInt32(
                kt.ExecuteScalar(sqlKiemTra, pKiemTra));

            if (soLuong > 0)
            {
                MessageBox.Show(
                    "Tên kho này đã tồn tại!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txt_tenkho.Focus();
                return;
            }

            // Thêm kho
            string sql = @"
                INSERT INTO Kho
                (
                    TenKho,
                    DiaChi,
                    MoTa,
                    TongHangNhap,
                    TrangThai
                )
                VALUES
                (
                    @TenKho,
                    @DiaChi,
                    @MoTa,
                    0,
                    1
                )";

            SqlParameter[] parameters =
            {
                new SqlParameter("@TenKho", tenKho),
                new SqlParameter("@DiaChi",
                    string.IsNullOrWhiteSpace(diaChi)
                        ? (object)DBNull.Value
                        : diaChi),
                new SqlParameter("@MoTa",
                    string.IsNullOrWhiteSpace(moTa)
                        ? (object)DBNull.Value
                        : moTa)
            };

            try
            {
                int ketQua = kt.Execute(sql, parameters);

                if (ketQua > 0)
                {
                    MessageBox.Show(
                        "Thêm kho thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Không thể thêm kho!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi thêm kho:\n\n" + ex.Message,
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

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
    public partial class FormCapNhatKho : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        private int maKho;

        public FormCapNhatKho(int maKho)
        {
            InitializeComponent();

            this.maKho = maKho;

            cmb_trangthai.Items.Clear();
            cmb_trangthai.Items.Add("Đang Hoạt Động");
            cmb_trangthai.Items.Add("Tạm Ngưng");

            LoadThongTinKho();
        }

        private void LoadThongTinKho()
        {
            string sql = @"
                SELECT
                    TenKho,
                    DiaChi,
                    MoTa,
                    TrangThai
                FROM Kho
                WHERE MaKho = @MaKho";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaKho", maKho)
            };

            DataTable dt = kt.GetData(sql, parameters);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy kho!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                this.Close();
                return;
            }

            DataRow row = dt.Rows[0];

            txt_tenkho.Text = row["TenKho"].ToString();

            txt_diachi.Text =
                row["DiaChi"] == DBNull.Value
                    ? ""
                    : row["DiaChi"].ToString();

            txt_mota.Text =
                row["MoTa"] == DBNull.Value
                    ? ""
                    : row["MoTa"].ToString();

            bool trangThai =
                Convert.ToBoolean(row["TrangThai"]);

            cmb_trangthai.SelectedIndex =
                trangThai ? 0 : 1;
        }
        private void FormCapNhatKho_Load(object sender, EventArgs e)
        {

        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string tenKho = txt_tenkho.Text.Trim();
            string diaChi = txt_diachi.Text.Trim();
            string moTa = txt_mota.Text.Trim();

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

            if (cmb_trangthai.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn trạng thái kho!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmb_trangthai.Focus();
                return;
            }

            // Kiểm tra trùng tên kho
            string sqlKiemTra = @"
                SELECT COUNT(*)
                FROM Kho
                WHERE TenKho = @TenKho
                  AND MaKho <> @MaKho";

            SqlParameter[] pKiemTra =
            {
                new SqlParameter("@TenKho", tenKho),
                new SqlParameter("@MaKho", maKho)
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

            bool trangThaiMoi =
                cmb_trangthai.SelectedIndex == 0;

            string sql = @"
                UPDATE Kho
                SET
                    TenKho = @TenKho,
                    DiaChi = @DiaChi,
                    MoTa = @MoTa,
                    TrangThai = @TrangThai
                WHERE MaKho = @MaKho";

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
                        : moTa),

                new SqlParameter("@TrangThai", trangThaiMoi),

                new SqlParameter("@MaKho", maKho)
            };

            try
            {
                int ketQua = kt.Execute(sql, parameters);

                if (ketQua > 0)
                {
                    MessageBox.Show(
                        "Cập nhật kho thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Không có dữ liệu nào được cập nhật!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi cập nhật kho:\n\n" + ex.Message,
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

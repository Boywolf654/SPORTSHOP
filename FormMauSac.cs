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
    public partial class FormMauSac : Form
    {
        KetNoiDuLieu kt = new KetNoiDuLieu();
        private int _selectedMaMau = 0; // 0 nghĩa là chưa chọn dòng nào (đang ở chế độ Thêm mới)
        public FormMauSac()
        {
            InitializeComponent();
        }

        private void FormMauSac_Load(object sender, EventArgs e)
        {
            LoadMauSac();
        }

        // ================= LOAD DỮ LIỆU =================
        private void LoadMauSac()
        {
            string sql = "SELECT MaMau, TenMau FROM MauSac ORDER BY MaMau";
            DataTable dt = kt.GetData(sql);
            dgvMauSac.DataSource = dt;

            if (dgvMauSac.Columns.Contains("MaMau"))
                dgvMauSac.Columns["MaMau"].HeaderText = "Mã";
            if (dgvMauSac.Columns.Contains("TenMau"))
                dgvMauSac.Columns["TenMau"].HeaderText = "Tên màu";

            ClearForm();
        }

        private void dgvMauSac_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMauSac.CurrentRow == null) return;

            _selectedMaMau = Convert.ToInt32(dgvMauSac.CurrentRow.Cells["MaMau"].Value);
            txt_TenMau.Text = dgvMauSac.CurrentRow.Cells["TenMau"].Value.ToString();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string sql = "INSERT INTO MauSac (TenMau) VALUES (@TenMau)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenMau", txt_TenMau.Text.Trim())
                };

                kt.Execute(sql, parameters);

                MessageBox.Show("Thêm màu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadMauSac();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (_selectedMaMau == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 màu trong bảng để sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            try
            {
                string sql = "UPDATE MauSac SET TenMau = @TenMau WHERE MaMau = @MaMau";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenMau", txt_TenMau.Text.Trim()),
                    new SqlParameter("@MaMau", _selectedMaMau)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadMauSac();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaMau == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 màu trong bảng để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa màu này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                string sql = "DELETE FROM MauSac WHERE MaMau = @MaMau";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaMau", _selectedMaMau)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show("Xóa thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadMauSac();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Không thể xóa. Có thể màu này đang được biến thể sản phẩm nào đó sử dụng.\n\n" +
                    "Chi tiết lỗi: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            LoadMauSac();
        }
        private void ClearForm()
        {
            _selectedMaMau = 0;
            txt_TenMau.Clear();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txt_TenMau.Text))
            {
                MessageBox.Show("Vui lòng nhập tên màu.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenMau.Focus();
                return false;
            }
            return true;
        }
    }
}

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
    public partial class FormSize : Form
    {
        KetNoiDuLieu kt = new KetNoiDuLieu();
        private int _selectedMaSize = 0; // 0 nghĩa là chưa chọn dòng nào (đang ở chế độ Thêm mới)
        public FormSize()
        {
            InitializeComponent();
        }

        private void FormSize_Load(object sender, EventArgs e)
        {
            LoadSize();
        }

        // ================= LOAD DỮ LIỆU =================
        private void LoadSize()
        {
            string sql = "SELECT MaSize, TenSize FROM Size ORDER BY MaSize";
            DataTable dt = kt.GetData(sql);
            dgvSize.DataSource = dt;

            if (dgvSize.Columns.Contains("MaSize"))
                dgvSize.Columns["MaSize"].HeaderText = "Mã";
            if (dgvSize.Columns.Contains("TenSize"))
                dgvSize.Columns["TenSize"].HeaderText = "Tên size";

            ClearForm();
        }

        private void dgvSize_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSize.CurrentRow == null) return;

            _selectedMaSize = Convert.ToInt32(dgvSize.CurrentRow.Cells["MaSize"].Value);
            txt_TenSize.Text = dgvSize.CurrentRow.Cells["TenSize"].Value.ToString();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string sql = "INSERT INTO Size (TenSize) VALUES (@TenSize)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenSize", txt_TenSize.Text.Trim())
                };

                kt.Execute(sql, parameters);

                MessageBox.Show("Thêm size thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadSize();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (_selectedMaSize == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 size trong bảng để sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            try
            {
                string sql = "UPDATE Size SET TenSize = @TenSize WHERE MaSize = @MaSize";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenSize", txt_TenSize.Text.Trim()),
                    new SqlParameter("@MaSize", _selectedMaSize)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadSize();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaSize == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 size trong bảng để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa size này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                string sql = "DELETE FROM Size WHERE MaSize = @MaSize";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaSize", _selectedMaSize)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show("Xóa thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadSize();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Không thể xóa. Có thể size này đang được biến thể sản phẩm nào đó sử dụng.\n\n" +
                    "Chi tiết lỗi: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            LoadSize();
        }

        // ================= HÀM PHỤ =================
        private void ClearForm()
        {
            _selectedMaSize = 0;
            txt_TenSize.Clear();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txt_TenSize.Text))
            {
                MessageBox.Show("Vui lòng nhập tên size.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenSize.Focus();
                return false;
            }
            return true;
        }
    }
}

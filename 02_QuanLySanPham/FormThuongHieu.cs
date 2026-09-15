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
    public partial class FormThuongHieu : Form
    {
        KetNoiDuLieu kt = new KetNoiDuLieu();
        private int _selectedMaTH = 0; // 0 nghĩa là chưa chọn dòng nào (đang ở chế độ Thêm mới)
        public FormThuongHieu()
        {
            InitializeComponent();
        }

        private void FormThuongHieu_Load(object sender, EventArgs e)
        {
            LoadThuongHieu();
        }

        private void LoadThuongHieu()
        {
            string sql = "SELECT MaTH, TenThuongHieu, TrangThai FROM ThuongHieu ORDER BY MaTH";
            DataTable dt = kt.GetData(sql);
            dgvThuongHieu.DataSource = dt;

            if (dgvThuongHieu.Columns.Contains("MaTH"))
                dgvThuongHieu.Columns["MaTH"].HeaderText = "Mã";
            if (dgvThuongHieu.Columns.Contains("TenThuongHieu"))
                dgvThuongHieu.Columns["TenThuongHieu"].HeaderText = "Tên thương hiệu";
            if (dgvThuongHieu.Columns.Contains("TrangThai"))
                dgvThuongHieu.Columns["TrangThai"].HeaderText = "Đang hoạt động";

            ClearForm();
        }

        private void dgvThuongHieu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvThuongHieu.CurrentRow == null) return;

            _selectedMaTH = Convert.ToInt32(dgvThuongHieu.CurrentRow.Cells["MaTH"].Value);
            txt_TenThuongHieu.Text = dgvThuongHieu.CurrentRow.Cells["TenThuongHieu"].Value.ToString();
            chk_TrangThai.Checked = Convert.ToBoolean(dgvThuongHieu.CurrentRow.Cells["TrangThai"].Value);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string sql = @"INSERT INTO ThuongHieu (TenThuongHieu, TrangThai) 
                                VALUES (@TenThuongHieu, @TrangThai)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenThuongHieu", txt_TenThuongHieu.Text.Trim()),
                    new SqlParameter("@TrangThai", chk_TrangThai.Checked)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show("Thêm thương hiệu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadThuongHieu();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (_selectedMaTH == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 thương hiệu trong bảng để sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            try
            {
                string sql = @"UPDATE ThuongHieu 
                                SET TenThuongHieu = @TenThuongHieu, TrangThai = @TrangThai 
                                WHERE MaTH = @MaTH";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenThuongHieu", txt_TenThuongHieu.Text.Trim()),
                    new SqlParameter("@TrangThai", chk_TrangThai.Checked),
                    new SqlParameter("@MaTH", _selectedMaTH)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadThuongHieu();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaTH == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 thương hiệu trong bảng để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa thương hiệu này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                string sql = "DELETE FROM ThuongHieu WHERE MaTH = @MaTH";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaTH", _selectedMaTH)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show("Xóa thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadThuongHieu();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Không thể xóa. Có thể thương hiệu này đang được sản phẩm nào đó sử dụng.\n\n" +
                    "Chi tiết lỗi: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            LoadThuongHieu();
        }
        private void ClearForm()
        {
            _selectedMaTH = 0;
            txt_TenThuongHieu.Clear();
            chk_TrangThai.Checked = true;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txt_TenThuongHieu.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thương hiệu.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenThuongHieu.Focus();
                return false;
            }
            return true;
        }
    }
}


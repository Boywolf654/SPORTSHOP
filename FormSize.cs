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
            if (dgvSize.Columns.Contains("TrangThai"))
                dgvSize.Columns["TrangThai"].HeaderText = "Trạng thái";
            string sql = @"
            SELECT MaSize, TenSize, TrangThai
            FROM Size
            WHERE TrangThai = 1
            ORDER BY TenSize";
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

            _selectedMaSize = Convert.ToInt32(
                dgvSize.CurrentRow.Cells["MaSize"].Value);

            txt_TenSize.Text =
                dgvSize.CurrentRow.Cells["TenSize"].Value.ToString();

            chk_TrangThai.Checked =
                Convert.ToBoolean(
                    dgvSize.CurrentRow.Cells["TrangThai"].Value);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string sql = @"
                INSERT INTO Size (TenSize, TrangThai)
                VALUES (@TenSize, @TrangThai)";

                
                

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenSize", txt_TenSize.Text.Trim()),
                    new SqlParameter("@TrangThai", chk_TrangThai.Checked)
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
                string sql = @"
                UPDATE Size
                SET TenSize = @TenSize,
                    TrangThai = @TrangThai
                WHERE MaSize = @MaSize";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenSize", txt_TenSize.Text.Trim()),
                    new SqlParameter("@TrangThai", chk_TrangThai.Checked),
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
                MessageBox.Show(
                    "Vui lòng chọn size cần ngừng hoạt động!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn ngừng hoạt động size này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            string sql = @"
        UPDATE Size
        SET TrangThai = 0
        WHERE MaSize = @MaSize";

            SqlParameter[] parameters =
            {
        new SqlParameter("@MaSize", _selectedMaSize)
    };

            try
            {
                kt.Execute(sql, parameters);

                MessageBox.Show(
                    "Đã ngừng hoạt động size này!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadSize();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể ngừng hoạt động size!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
            chk_TrangThai.Checked = true;
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

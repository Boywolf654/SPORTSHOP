using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormDanhMuc : Form
    {
        KetNoiDuLieu kt = new KetNoiDuLieu();
        private int _selectedMaDM = 0; // 0 nghĩa là chưa chọn dòng nào (đang ở chế độ Thêm mới)
        public FormDanhMuc()
        {
            InitializeComponent();
            LoadDanhMuc();
        }

        private void FormDanhMuc_Load(object sender, EventArgs e)
        {

        }

        // ================= LOAD DỮ LIỆU =================
        private void LoadDanhMuc()
        {
            string sql = "SELECT MaDM, TenDanhMuc, TrangThai FROM DanhMuc ORDER BY MaDM";

            DataTable dt = kt.GetData(sql);

            dgvDanhMuc.DataSource = dt;

            // Đổi tên cột hiển thị cho dễ nhìn
            if (dgvDanhMuc.Columns.Contains("MaDM"))
                dgvDanhMuc.Columns["MaDM"].HeaderText = "Mã";

            if (dgvDanhMuc.Columns.Contains("TenDanhMuc"))
                dgvDanhMuc.Columns["TenDanhMuc"].HeaderText = "Tên danh mục";

            if (dgvDanhMuc.Columns.Contains("TrangThai"))
                dgvDanhMuc.Columns["TrangThai"].HeaderText = "Đang hoạt động";

            ClearForm();
        }

        private void ClearForm()
        {
            _selectedMaDM = 0;
            txt_TenDanhMuc.Clear();
            chk_TrangThai.Checked = true;
        }

        private void dgvDanhMuc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhMuc.CurrentRow == null) return;

            _selectedMaDM = Convert.ToInt32(dgvDanhMuc.CurrentRow.Cells["MaDM"].Value);
            txt_TenDanhMuc.Text = dgvDanhMuc.CurrentRow.Cells["TenDanhMuc"].Value.ToString();
            chk_TrangThai.Checked = Convert.ToBoolean(dgvDanhMuc.CurrentRow.Cells["TrangThai"].Value);
        }

        // ================= THÊM MỚI =================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string sql = @"INSERT INTO DanhMuc (TenDanhMuc, TrangThai) 
                                VALUES (@TenDanhMuc, @TrangThai)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenDanhMuc", txt_TenDanhMuc.Text.Trim()),
                    new SqlParameter("@TrangThai", chk_TrangThai.Checked)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show("Thêm danh mục thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDanhMuc();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (_selectedMaDM == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 danh mục trong bảng để sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            try
            {
                string sql = @"UPDATE DanhMuc 
                                SET TenDanhMuc = @TenDanhMuc, TrangThai = @TrangThai 
                                WHERE MaDM = @MaDM";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenDanhMuc", txt_TenDanhMuc.Text.Trim()),
                    new SqlParameter("@TrangThai", chk_TrangThai.Checked),
                    new SqlParameter("@MaDM", _selectedMaDM)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDanhMuc();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaDM == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 danh mục trong bảng để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa danh mục này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                string sql = "DELETE FROM DanhMuc WHERE MaDM = @MaDM";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaDM", _selectedMaDM)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show("Xóa thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDanhMuc();
            }
            catch (SqlException ex)
            {
                // Lỗi thường gặp: đang có SanPham tham chiếu tới danh mục này (khóa ngoại)
                MessageBox.Show(
                    "Không thể xóa. Có thể danh mục này đang được sản phẩm nào đó sử dụng.\n\n" +
                    "Chi tiết lỗi: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            LoadDanhMuc();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txt_TenDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenDanhMuc.Focus();
                return false;
            }
            return true;
        }
    }
}

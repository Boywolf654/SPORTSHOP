using System;
using System.Data;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormNhaCungCap : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        public FormNhaCungCap()
        {
            InitializeComponent();

            // Gắn sự kiện vì Designer hiện tại chưa có
            txt_TimKiem.TextChanged += txt_TimKiem_TextChanged;
            btn_ThemMoi.Click += btn_ThemMoi_Click;
            dgv_NCC.CellDoubleClick += guna2DataGridView1_CellDoubleClick;
        }

        private void FormNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
            CauHinhDataGridView();
        }

        // =====================================================
        // LOAD DANH SÁCH NHÀ CUNG CẤP
        // =====================================================
        private void LoadDanhSach()
        {
            try
            {
                string tuKhoa = txt_TimKiem.Text.Trim();

                string sql = @"
                    SELECT
                        MaNCC,
                        TenNCC,
                        SDT,
                        DiaChi,
                        TrangThai,
                        Email
                    FROM NhaCungCap
                    WHERE TenNCC LIKE '%' + @TuKhoa + '%'
                       OR SDT LIKE '%' + @TuKhoa + '%'
                       OR Email LIKE '%' + @TuKhoa + '%'
                    ORDER BY MaNCC DESC";

                System.Data.SqlClient.SqlParameter[] parameters =
                {
                    new System.Data.SqlClient.SqlParameter("@TuKhoa", tuKhoa)
                };

                DataTable dt = kt.GetData(sql, parameters);

                dgv_NCC.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách nhà cung cấp.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // CẤU HÌNH DATAGRIDVIEW
        // =====================================================
        private void CauHinhDataGridView()
        {
            if (dgv_NCC.Columns["MaNCC"] != null)
            {
                dgv_NCC.Columns["MaNCC"].HeaderText =
                    "Mã nhà cung cấp";
            }

            if (dgv_NCC.Columns["TenNCC"] != null)
            {
                dgv_NCC.Columns["TenNCC"].HeaderText =
                    "Tên nhà cung cấp";
            }

            if (dgv_NCC.Columns["SDT"] != null)
            {
                dgv_NCC.Columns["SDT"].HeaderText =
                    "Số điện thoại";
            }

            if (dgv_NCC.Columns["DiaChi"] != null)
            {
                dgv_NCC.Columns["DiaChi"].HeaderText =
                    "Địa chỉ";
            }

            if (dgv_NCC.Columns["TrangThai"] != null)
            {
                dgv_NCC.Columns["TrangThai"].HeaderText =
                    "Trạng thái";
            }

            if (dgv_NCC.Columns["Email"] != null)
            {
                dgv_NCC.Columns["Email"].HeaderText =
                    "Email";
            }
        }

        // =====================================================
        // TÌM KIẾM
        // =====================================================
        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        // =====================================================
        // NÚT THÊM MỚI
        // =====================================================
        private void btn_ThemMoi_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Phần form thêm nhà cung cấp sẽ được mở ở bước tiếp theo.",
                "Thêm nhà cung cấp",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =====================================================
        // DOUBLE CLICK XEM / SỬA
        // =====================================================
        private void guna2DataGridView1_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgv_NCC.Rows[e.RowIndex];

            int maNCC =
                Convert.ToInt32(row.Cells["MaNCC"].Value);

            string tenNCC =
                row.Cells["TenNCC"].Value?.ToString() ?? "";

            string sdt =
                row.Cells["SDT"].Value?.ToString() ?? "";

            string email =
                row.Cells["Email"].Value?.ToString() ?? "";

            string diaChi =
                row.Cells["DiaChi"].Value?.ToString() ?? "";

            MessageBox.Show(
                "Mã NCC: " + maNCC +
                "\nTên: " + tenNCC +
                "\nSĐT: " + sdt +
                "\nEmail: " + email +
                "\nĐịa chỉ: " + diaChi,
                "Thông tin nhà cung cấp",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btn_ThemMoi_Click_1(object sender, EventArgs e)
        {
            using (FormThemNhaCungCap form = new FormThemNhaCungCap())
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Thêm thành công → load lại danh sách
                    LoadDanhSach();
                }
            }
        }
    }
}
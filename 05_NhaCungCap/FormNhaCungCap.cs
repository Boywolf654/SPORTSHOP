using SPORTSHOP._05_NhaCungCap;
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

            DataGridViewRow row = dgv_NCC.Rows[e.RowIndex];

            int maNCC = Convert.ToInt32(
                row.Cells["MaNCC"].Value);

            using (FormChiTietNhaCungCap form =
                new FormChiTietNhaCungCap(maNCC))
            {
                form.ShowDialog();
            }

            LoadDanhSach();
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

        private void btn_Vohieuhoa(object sender, EventArgs e)
        {
            if (dgv_NCC.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhà cung cấp cần vô hiệu hóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int maNCC = Convert.ToInt32(
                    dgv_NCC.CurrentRow.Cells["MaNCC"].Value);

                string tenNCC =
                    dgv_NCC.CurrentRow.Cells["TenNCC"].Value?.ToString() ?? "";

                bool trangThai = Convert.ToBoolean(
                    dgv_NCC.CurrentRow.Cells["TrangThai"].Value);

                // Nếu đã vô hiệu hóa rồi thì không cho vô hiệu hóa tiếp
                if (!trangThai)
                {
                    MessageBox.Show(
                        "Nhà cung cấp này đã được vô hiệu hóa.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn vô hiệu hóa nhà cung cấp:\n\n" +
                    "Mã NCC: " + maNCC + "\n" +
                    "Tên NCC: " + tenNCC + "\n\n" +
                    "Nhà cung cấp sẽ không bị xóa khỏi hệ thống.",
                    "Xác nhận vô hiệu hóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                string sql = @"
            UPDATE NhaCungCap
            SET TrangThai = 0
            WHERE MaNCC = @MaNCC";

                System.Data.SqlClient.SqlParameter[] parameters =
                {
            new System.Data.SqlClient.SqlParameter("@MaNCC", maNCC)
        };

                int affected = kt.Execute(sql, parameters);

                if (affected > 0)
                {
                    MessageBox.Show(
                        "Đã vô hiệu hóa nhà cung cấp thành công.",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadDanhSach();
                }
                else
                {
                    MessageBox.Show(
                        "Không thể vô hiệu hóa nhà cung cấp.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi vô hiệu hóa nhà cung cấp.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_xemchitiet(object sender, EventArgs e)
        {
            if (dgv_NCC.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhà cung cấp cần xem chi tiết.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                int maNCC = Convert.ToInt32(
                    dgv_NCC.CurrentRow.Cells["MaNCC"].Value);

                using (FormChiTietNhaCungCap form =
                    new FormChiTietNhaCungCap(maNCC))
                {
                    form.ShowDialog();
                }

                // Sau khi đóng form chi tiết → load lại danh sách
                LoadDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở thông tin chi tiết nhà cung cấp.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormQuanLyKhuyenMai : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        public FormQuanLyKhuyenMai()
        {
            InitializeComponent();
        }

        private void FormQuanLyKhuyenMai_Load(object sender, EventArgs e)
        {
            CauHinhGiaoDien();
            TaiDanhSachKhuyenMai();
        }

        private void CauHinhGiaoDien()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Tất cả trạng thái");
            cboTrangThai.Items.Add("Đang áp dụng");
            cboTrangThai.Items.Add("Đã ngừng");
            cboTrangThai.SelectedIndex = 0;

            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            cboTrangThai.SelectedIndexChanged += cboTrangThai_SelectedIndexChanged;
            dgvKhuyenMai.CellDoubleClick += dgvKhuyenMai_CellDoubleClick;

            dgvKhuyenMai.ReadOnly = true;
            dgvKhuyenMai.AllowUserToAddRows = false;
            dgvKhuyenMai.AllowUserToDeleteRows = false;
            dgvKhuyenMai.MultiSelect = false;
            dgvKhuyenMai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhuyenMai.RowHeadersVisible = false;
            dgvKhuyenMai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhuyenMai.RowTemplate.Height = 36;
            dgvKhuyenMai.ColumnHeadersHeight = 42;
        }

        private void TaiDanhSachKhuyenMai()
        {
            try
            {
                string sql = @"
                    SELECT
                        ctkm.MaCTKM,
                        ctkm.TenChuongTrinh,
                        ctkm.LoaiKhuyenMai,
                        ctkm.GiaTri,
                        ctkm.SoLuongToiThieu,
                        ctkm.NgayBatDau,
                        ctkm.NgayKetThuc,
                        CASE WHEN ctkm.TrangThai = 1
                             THEN N'Đang áp dụng'
                             ELSE N'Đã ngừng' END AS TrangThai,
                        STUFF((
                            SELECT N', ' + sp.TenSP
                            FROM ChiTietCTKM ct
                            INNER JOIN SanPham sp ON sp.MaSP = ct.MaSP
                            WHERE ct.MaCTKM = ctkm.MaCTKM
                            FOR XML PATH(''), TYPE
                        ).value('.', 'NVARCHAR(MAX)'), 1, 2, N'') AS SanPhamApDung
                    FROM ChuongTrinhKhuyenMai ctkm
                    WHERE
                        (@TrangThai = 0)
                        OR (@TrangThai = 1 AND ctkm.TrangThai = 1)
                        OR (@TrangThai = 2 AND ctkm.TrangThai = 0)
                    ORDER BY ctkm.NgayBatDau DESC, ctkm.MaCTKM DESC;";

                DataTable dt = kt.GetData(sql, new SqlParameter[]
                {
                    new SqlParameter("@TrangThai", cboTrangThai.SelectedIndex)
                });

                dgvKhuyenMai.DataSource = dt;

                if (dgvKhuyenMai.Columns.Count == 0)
                    return;

                dgvKhuyenMai.Columns["MaCTKM"].HeaderText = "Mã";
                dgvKhuyenMai.Columns["TenChuongTrinh"].HeaderText = "Tên chương trình";
                dgvKhuyenMai.Columns["LoaiKhuyenMai"].HeaderText = "Loại";
                dgvKhuyenMai.Columns["GiaTri"].HeaderText = "Giá trị";
                dgvKhuyenMai.Columns["SoLuongToiThieu"].HeaderText = "SL tối thiểu";
                dgvKhuyenMai.Columns["NgayBatDau"].HeaderText = "Bắt đầu";
                dgvKhuyenMai.Columns["NgayKetThuc"].HeaderText = "Kết thúc";
                dgvKhuyenMai.Columns["TrangThai"].HeaderText = "Trạng thái";
                dgvKhuyenMai.Columns["SanPhamApDung"].HeaderText = "Sản phẩm áp dụng";

                dgvKhuyenMai.Columns["GiaTri"].DefaultCellStyle.Format = "N0";
                dgvKhuyenMai.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvKhuyenMai.Columns["NgayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách khuyến mãi.\n\n" + ex.Message,
                    "Quản lý khuyến mãi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int LayMaDangChon()
        {
            if (dgvKhuyenMai.CurrentRow == null ||
                dgvKhuyenMai.CurrentRow.Cells["MaCTKM"].Value == null)
                return 0;

            return Convert.ToInt32(dgvKhuyenMai.CurrentRow.Cells["MaCTKM"].Value);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.Trim().Replace("'", "''");

            foreach (DataGridViewRow row in dgvKhuyenMai.Rows)
            {
                bool show = string.IsNullOrEmpty(key);

                if (!show)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        string value = Convert.ToString(row.Cells[i].Value);
                        if (value.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            show = true;
                            break;
                        }
                    }
                }

                row.Visible = show;
            }
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiDanhSachKhuyenMai();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (FormTaoKhuyenMai frm = new FormTaoKhuyenMai())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    TaiDanhSachKhuyenMai();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int ma = LayMaDangChon();

            if (ma <= 0)
            {
                MessageBox.Show("Hãy chọn chương trình cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (FormTaoKhuyenMai frm = new FormTaoKhuyenMai(ma))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    TaiDanhSachKhuyenMai();
            }
        }

        private void btnNgung_Click(object sender, EventArgs e)
        {
            int ma = LayMaDangChon();

            if (ma <= 0)
            {
                MessageBox.Show("Hãy chọn chương trình cần ngừng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Ngừng chương trình khuyến mãi đang chọn?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                kt.Execute(@"UPDATE ChuongTrinhKhuyenMai
                             SET TrangThai = 0
                             WHERE MaCTKM = @MaCTKM",
                    new SqlParameter[] { new SqlParameter("@MaCTKM", ma) });

                TaiDanhSachKhuyenMai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể ngừng chương trình.\n\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboTrangThai.SelectedIndex = 0;
            TaiDanhSachKhuyenMai();
        }

        private void dgvKhuyenMai_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnSua_Click(sender, EventArgs.Empty);
        }
    }
}

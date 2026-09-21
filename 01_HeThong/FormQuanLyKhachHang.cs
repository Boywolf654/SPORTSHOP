using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormQuanLyKhachHang : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private int maKHDangChon = 0;

        public FormQuanLyKhachHang()
        {
            InitializeComponent();
            Load += FormQuanLyKhachHang_Load;
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;
            btnTim.Click += btnTim_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnNgung.Click += btnNgung_Click;
            btnMoi.Click += btnMoi_Click;
        }

        private void FormQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Tất cả");
            cboTrangThai.Items.Add("Đang hoạt động");
            cboTrangThai.Items.Add("Đã khóa");
            cboTrangThai.SelectedIndex = 0;
            LoadDanhSach();
        }

        private void LoadDanhSach(string tuKhoa = "")
        {
            try
            {
                string sql = @"
SELECT kh.MaKH,kh.HoTen,kh.SDT,kh.Email,
       ISNULL(kh.DiemHoiVien,0) AS DiemHoiVien,
       ISNULL(kh.HangThanhVien,N'Chưa xếp hạng') AS HangThanhVien,
       CASE WHEN kh.TrangThai=1 THEN N'Đang hoạt động' ELSE N'Đã khóa' END AS TrangThai,
       kh.NgayTao,kh.MaTK
FROM KhachHang kh
WHERE (@TuKhoa='' OR kh.HoTen LIKE N'%'+@TuKhoa+N'%' OR kh.SDT LIKE '%'+@TuKhoa+'%' OR kh.Email LIKE '%'+@TuKhoa+'%')
  AND (@TrangThai=0 OR (@TrangThai=1 AND kh.TrangThai=1) OR (@TrangThai=2 AND kh.TrangThai=0))
ORDER BY kh.MaKH DESC";
                DataTable dt = kt.GetData(sql, new[]{
                    new SqlParameter("@TuKhoa",tuKhoa.Trim()),
                    new SqlParameter("@TrangThai",cboTrangThai.SelectedIndex)
                });
                dgvKhachHang.DataSource = dt;
                if (dgvKhachHang.Columns.Count > 0)
                {
                    dgvKhachHang.Columns["MaKH"].HeaderText = "Mã KH";
                    dgvKhachHang.Columns["HoTen"].HeaderText = "Họ tên";
                    dgvKhachHang.Columns["SDT"].HeaderText = "SĐT";
                    dgvKhachHang.Columns["Email"].HeaderText = "Email";
                    dgvKhachHang.Columns["DiemHoiVien"].HeaderText = "Điểm";
                    dgvKhachHang.Columns["HangThanhVien"].HeaderText = "Hạng";
                    dgvKhachHang.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dgvKhachHang.Columns["NgayTao"].HeaderText = "Ngày tạo";
                    dgvKhachHang.Columns["MaTK"].HeaderText = "Mã TK";
                    dgvKhachHang.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvKhachHang.Columns["MaKH"].Width = 70;
                    dgvKhachHang.Columns["DiemHoiVien"].Width = 70;
                    dgvKhachHang.Columns["TrangThai"].Width = 120;
                    dgvKhachHang.Columns["MaTK"].Width = 70;
                }
                dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách khách hàng.\n\n" + ex.Message, "Khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgvKhachHang.Rows[e.RowIndex];
            maKHDangChon = Convert.ToInt32(r.Cells["MaKH"].Value);
            txtHoTen.Text = r.Cells["HoTen"].Value?.ToString() ?? "";
            txtSDT.Text = r.Cells["SDT"].Value?.ToString() ?? "";
            txtEmail.Text = r.Cells["Email"].Value?.ToString() ?? "";
            lblDiem.Text = "Điểm: " + (r.Cells["DiemHoiVien"].Value?.ToString() ?? "0") + " | " + (r.Cells["HangThanhVien"].Value?.ToString() ?? "");
        }

        private bool KiemTra(out string loi)
        {
            loi = "";
            if (string.IsNullOrWhiteSpace(txtHoTen.Text)) { loi = "Chưa nhập họ tên."; return false; }
            if (string.IsNullOrWhiteSpace(txtSDT.Text)) { loi = "Chưa nhập số điện thoại."; return false; }
            if (txtSDT.Text.Trim().Length < 9) { loi = "Số điện thoại không hợp lệ."; return false; }
            return true;
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            maKHDangChon = 0; txtHoTen.Clear(); txtSDT.Clear(); txtEmail.Clear(); lblDiem.Text = "Điểm: 0"; txtHoTen.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTra(out string loi)) { MessageBox.Show(loi, "Khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                object exists = kt.ExecuteScalar("SELECT COUNT(*) FROM KhachHang WHERE SDT=@SDT", new[] { new SqlParameter("@SDT", txtSDT.Text.Trim()) });
                if (Convert.ToInt32(exists) > 0) { MessageBox.Show("Số điện thoại đã tồn tại.", "Khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                kt.Execute(@"
INSERT INTO KhachHang(HoTen,SDT,Email,DiemTichLuy,HangThanhVien,TrangThai,NgayTao,DiemHoiVien,MaHangHoiVien)
SELECT @HoTen,@SDT,@Email,0,h.TenHang,1,GETDATE(),0,h.MaHangHoiVien
FROM HangHoiVien h
WHERE h.DiemToiThieu=(SELECT MIN(DiemToiThieu) FROM HangHoiVien)", new[]{
                    new SqlParameter("@HoTen",txtHoTen.Text.Trim()),
                    new SqlParameter("@SDT",txtSDT.Text.Trim()),
                    new SqlParameter("@Email",string.IsNullOrWhiteSpace(txtEmail.Text)?(object)DBNull.Value:txtEmail.Text.Trim())
                });
                MessageBox.Show("Đã thêm khách hàng.", "Khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information); LoadDanhSach(); btnMoi_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show("Không thể thêm khách hàng.\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maKHDangChon <= 0) { MessageBox.Show("Chọn khách hàng cần sửa."); return; }
            if (!KiemTra(out string loi)) { MessageBox.Show(loi); return; }
            try
            {
                kt.Execute(@"UPDATE KhachHang SET HoTen=@HoTen,SDT=@SDT,Email=@Email WHERE MaKH=@MaKH", new[]{
                    new SqlParameter("@HoTen",txtHoTen.Text.Trim()),new SqlParameter("@SDT",txtSDT.Text.Trim()),new SqlParameter("@Email",string.IsNullOrWhiteSpace(txtEmail.Text)?(object)DBNull.Value:txtEmail.Text.Trim()),new SqlParameter("@MaKH",maKHDangChon)
                });
                MessageBox.Show("Đã cập nhật khách hàng.", "Khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information); LoadDanhSach();
            }
            catch (Exception ex) { MessageBox.Show("Không thể cập nhật.\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnNgung_Click(object sender, EventArgs e)
        {
            if (maKHDangChon <= 0) { MessageBox.Show("Chọn khách hàng."); return; }
            bool dangHoatDong = true;
            if (dgvKhachHang.CurrentRow != null)
                dangHoatDong = (dgvKhachHang.CurrentRow.Cells["TrangThai"].Value?.ToString() ?? "") == "Đang hoạt động";
            bool trangThaiMoi = !dangHoatDong;
            string thongBao = trangThaiMoi ? "Kích hoạt lại khách hàng này?" : "Chuyển khách hàng này sang trạng thái Đã khóa?";
            if (MessageBox.Show(thongBao, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try { kt.Execute("UPDATE KhachHang SET TrangThai=@TrangThai WHERE MaKH=@MaKH", new[] { new SqlParameter("@TrangThai", trangThaiMoi), new SqlParameter("@MaKH", maKHDangChon) }); LoadDanhSach(); MessageBox.Show(trangThaiMoi ? "Đã kích hoạt khách hàng." : "Đã khóa khách hàng."); }
            catch (Exception ex) { MessageBox.Show("Không thể cập nhật trạng thái.\n\n" + ex.Message); }
        }

        private void btnTim_Click(object sender, EventArgs e) { LoadDanhSach(txtTimKiem.Text); }
        private void btnLamMoi_Click(object sender, EventArgs e) { txtTimKiem.Clear(); LoadDanhSach(); }
    }
}

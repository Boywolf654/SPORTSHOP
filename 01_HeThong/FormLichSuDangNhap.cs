using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormLichSuDangNhap : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        public FormLichSuDangNhap() { InitializeComponent(); }

        private void FormLichSuDangNhap_Load(object sender, EventArgs e)
        {
            dtp_tungay.Value = DateTime.Today.AddDays(-30);
            dtp_denngay.Value = DateTime.Today;
            Cmb_LoaiTK.Items.Clear(); Cmb_LoaiTK.Items.AddRange(new object[] { "Tất cả", "Admin", "Quản lý", "Nhân viên", "Kho", "Khách hàng" }); Cmb_LoaiTK.SelectedIndex = 0;
            cmb_TrangThai.Items.Clear(); cmb_TrangThai.Items.AddRange(new object[] { "Tất cả", "Thành công", "Thất bại" }); cmb_TrangThai.SelectedIndex = 0;
            btn_Loc.Click += btn_Loc_Click; btn_LamMoi.Click += btn_LamMoi_Click;
            dgv_LichSu.ColumnHeadersHeight = 38; dgv_LichSu.ThemeStyle.HeaderStyle.Height = 38; dgv_LichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; dgv_LichSu.RowHeadersVisible = false; dgv_LichSu.ReadOnly = true; dgv_LichSu.AllowUserToAddRows = false;
            LoadDuLieu();
        }

        private void LoadDuLieu()
        {
            if (dtp_tungay.Value.Date > dtp_denngay.Value.Date) { MessageBox.Show("Từ ngày không được lớn hơn đến ngày."); return; }
            try
            {
                string role = "";
                switch (Cmb_LoaiTK.SelectedIndex) { case 1: role = "Admin"; break; case 2: role = "Quản lý"; break; case 3: role = "Nhân viên"; break; case 4: role = "Kho"; break; case 5: role = "Khách hàng"; break; }
                string ketQua = ""; if (cmb_TrangThai.SelectedIndex == 1) ketQua = "Thành công"; else if (cmb_TrangThai.SelectedIndex == 2) ketQua = "Thất bại";
                DataTable dt = kt.GetData(@"
SELECT ls.MaLichSu,tk.TenDangNhap,vt.TenVaiTro,ls.ThoiGianVao,ls.ThoiGianRa,ls.KetQua,ls.LyDo
FROM LichSuDangNhap ls
INNER JOIN TaiKhoan tk ON tk.MaTK=ls.MaTK
INNER JOIN VaiTro vt ON vt.MaVaiTro=tk.MaVaiTro
WHERE ls.ThoiGianVao>=@Tu
  AND ls.ThoiGianVao<DATEADD(DAY,1,@Den)
  AND (@TK='' OR tk.TenDangNhap LIKE '%'+@TK+'%')
  AND (@Role='' OR vt.TenVaiTro=@Role OR (@Role='Nhân viên' AND vt.TenVaiTro LIKE N'%Nhân viên%') OR (@Role='Kho' AND vt.TenVaiTro LIKE N'%Kho%'))
  AND (@KetQua='' OR ls.KetQua=@KetQua)
ORDER BY ls.ThoiGianVao DESC", new[]{
                    new SqlParameter("@Tu",dtp_tungay.Value.Date),new SqlParameter("@Den",dtp_denngay.Value.Date),new SqlParameter("@TK",txt_TK.Text.Trim()),new SqlParameter("@Role",role),new SqlParameter("@KetQua",ketQua)});
                dgv_LichSu.DataSource = dt;
                if (dgv_LichSu.Columns.Count > 0) { dgv_LichSu.Columns["MaLichSu"].HeaderText = "Mã"; dgv_LichSu.Columns["TenDangNhap"].HeaderText = "Tài khoản"; dgv_LichSu.Columns["TenVaiTro"].HeaderText = "Vai trò"; dgv_LichSu.Columns["ThoiGianVao"].HeaderText = "Thời gian vào"; dgv_LichSu.Columns["ThoiGianRa"].HeaderText = "Thời gian ra"; dgv_LichSu.Columns["KetQua"].HeaderText = "Kết quả"; dgv_LichSu.Columns["LyDo"].HeaderText = "Lý do"; dgv_LichSu.Columns["ThoiGianVao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"; dgv_LichSu.Columns["ThoiGianRa"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"; }
            }
            catch (Exception ex) { MessageBox.Show("Không thể tải lịch sử đăng nhập.\n\n" + ex.Message, "Lịch sử đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btn_Loc_Click(object sender, EventArgs e) { LoadDuLieu(); }
        private void btn_LamMoi_Click(object sender, EventArgs e) { txt_TK.Clear(); Cmb_LoaiTK.SelectedIndex = 0; cmb_TrangThai.SelectedIndex = 0; dtp_tungay.Value = DateTime.Today.AddDays(-30); dtp_denngay.Value = DateTime.Today; LoadDuLieu(); }
    }
}

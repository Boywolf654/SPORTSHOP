using System;
using System.Windows.Forms;
using System.Drawing;
using SPORTSHOP._07_KhachHang;

namespace SPORTSHOP
{
    public partial class FormMenuNV : Form
    {
        public bool YeuCauKhoaManHinh { get; private set; }
        public bool YeuCauDangXuat { get; private set; }

        public FormMenuNV()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;

            if (btn_hoadon != null)
                btn_hoadon.Visible = false;

            TaoNutNhanVienBoSung();
        }


        // =========================================================
        // CHỨC NĂNG CÁ NHÂN CỦA NHÂN VIÊN
        // =========================================================
        private void TaoNutNhanVienBoSung()
        {
            if (flpMenu == null)
                return;

            Guna.UI2.WinForms.Guna2Button btnHoiVien = TaoNutMenuBoSung(
                "⭐  HỘI VIÊN CỦA TÔI");
            btnHoiVien.Click += btnHoiVien_Click;

            Guna.UI2.WinForms.Guna2Button btnMuaHang = TaoNutMenuBoSung(
                "🛒  MUA HÀNG CHO TÔI");
            btnMuaHang.Click += btnMuaHang_Click;

            // Chèn trước nút Đăng xuất để hai chức năng cá nhân nằm cùng nhóm.
            int viTriDangXuat = flpMenu.Controls.IndexOf(btn_dangxuat);
            if (viTriDangXuat < 0)
                viTriDangXuat = flpMenu.Controls.Count;

            flpMenu.Controls.Add(btnHoiVien);
            flpMenu.Controls.SetChildIndex(btnHoiVien, viTriDangXuat);

            viTriDangXuat = flpMenu.Controls.IndexOf(btn_dangxuat);
            flpMenu.Controls.Add(btnMuaHang);
            flpMenu.Controls.SetChildIndex(btnMuaHang, viTriDangXuat);
        }

        private Guna.UI2.WinForms.Guna2Button TaoNutMenuBoSung(string text)
        {
            return new Guna.UI2.WinForms.Guna2Button
            {
                Width = 250,
                Height = 112,
                Margin = new Padding(12),
                BorderRadius = 14,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(55, 59, 68),
                FillColor = Color.FromArgb(22, 25, 31),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Text = text,
                TextAlign = System.Windows.Forms.HorizontalAlignment.Left,
                Cursor = Cursors.Hand
            };
        }

        private void btnHoiVien_Click(object sender, EventArgs e)
        {
            if (!KiemTraHoSoKhachHangNhanVien())
                return;

            using (FormHoiVien frm = new FormHoiVien())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnMuaHang_Click(object sender, EventArgs e)
        {
            if (!KiemTraVaYeuCauCa())
                return;

            if (!KiemTraHoSoKhachHangNhanVien())
                return;

            using (formgiaodienbanhang frm = new formgiaodienbanhang(true))
            {
                frm.ShowDialog(this);
            }
        }

        private bool KiemTraHoSoKhachHangNhanVien()
        {
            if (Session.MaTK <= 0 || Session.MaNV <= 0)
            {
                MessageBox.Show(
                    "Không xác định được tài khoản hoặc nhân viên đang đăng nhập.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            int maKH = LayMaKHTheoMaTK(Session.MaTK);
            if (maKH <= 0)
            {
                MessageBox.Show(
                    "Nhân viên chưa có hồ sơ khách hàng/hội viên dùng chung tài khoản.\r\n\r\n" +
                    "Vui lòng đăng nhập lại để hệ thống đồng bộ hồ sơ.",
                    "Hồ sơ khách hàng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private int LayMaKHTheoMaTK(int maTK)
        {
            try
            {
                KetNoiDuLieu kt = new KetNoiDuLieu();
                object result = kt.ExecuteScalar(
                    @"SELECT TOP 1 MaKH FROM KhachHang WHERE MaTK = @MaTK",
                    new System.Data.SqlClient.SqlParameter[]
                    {
                        new System.Data.SqlClient.SqlParameter("@MaTK", maTK)
                    });

                if (result == null || result == DBNull.Value)
                    return 0;

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không kiểm tra được hồ sơ khách hàng của nhân viên.\n\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return 0;
            }
        }

        private void FormMenuNV_Load(object sender, EventArgs e)
        {
            // Chỉ cập nhật thông tin hiển thị trên menu, không thay đổi nghiệp vụ.
            if (!string.IsNullOrWhiteSpace(Session.TenDangNhap))
                lblSideUser.Text = Session.TenDangNhap;
            else
                lblSideUser.Text = "Nhân viên";

            if (!string.IsNullOrWhiteSpace(Session.TenVaiTro))
                lblSideRole.Text = Session.TenVaiTro.ToUpper();
            else
                lblSideRole.Text = "NHÂN VIÊN";
        }

        private void btn_thongtinNV_Click(object sender, EventArgs e)
        {
            if (Session.MaTK <= 0)
            {
                MessageBox.Show(
                    "Không xác định được tài khoản đang đăng nhập.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (FormThongTinNV frm = new FormThongTinNV(
                Session.MaTK,
                Session.TenDangNhap,
                Session.TenVaiTro))
            {
                frm.ShowDialog(this);
            }
        }

        private void btn_chuyenca_Click(object sender, EventArgs e)
        {
            if (Session.MaNV <= 0)
            {
                MessageBox.Show(
                    "Không xác định được nhân viên đang đăng nhập.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (FormChuyenGiaoCa frm = new FormChuyenGiaoCa())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    YeuCauKhoaManHinh = true;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void btn_moket_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "MỞ KÉT THÀNH CÔNG",
                "SPORTSHOP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btn_dononline_Click(object sender, EventArgs e)
        {
            if (!KiemTraVaYeuCauCa())
                return;

            using (FormDonOnline frm = new FormDonOnline())
            {
                frm.ShowDialog(this);
            }
        }

        private bool KiemTraVaYeuCauCa()
        {
            if (Session.MaNV <= 0)
            {
                MessageBox.Show(
                    "Không xác định được nhân viên đang đăng nhập.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!QuanLyCa1.KiemTraCaDangLam())
            {
                MessageBox.Show(
                    QuanLyCa1.ThongBaoChuaCoCa() +
                    "\n\nBạn phải vào ca trước khi thực hiện bán hàng/ra đơn.",
                    "CHƯA VÀO CA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool YeuCauChuyenCaNeuDangLam()
        {
            if (!QuanLyCa1.KiemTraCaDangLam())
                return true;

            DialogResult confirm = MessageBox.Show(
                "Bạn đang trong ca làm việc.\n\n" +
                "Muốn ra ca, bạn bắt buộc phải thực hiện CHUYỂN CA trước.\n\n" +
                "Bạn có muốn mở chức năng Chuyển ca ngay không?",
                "ĐANG TRONG CA",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return false;

            using (FormChuyenGiaoCa frm = new FormChuyenGiaoCa())
            {
                return frm.ShowDialog(this) == DialogResult.OK;
            }
        }

        private void btn_khoamanhinh_Click(object sender, EventArgs e)
        {
            YeuCauKhoaManHinh = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            using (D frm = new D())
            {
                frm.ShowDialog(this);
            }
        }

        private void btn_giaodich_Click(object sender, EventArgs e)
        {
            using (SPORTSHOP._06_BanHang.FormDanhSachHoaDon frm =
                   new SPORTSHOP._06_BanHang.FormDanhSachHoaDon())
            {
                frm.ShowDialog(this);
            }
        }

        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            // Nút legacy đang được ẩn.
        }

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất tài khoản nhân viên hiện tại không?",
                "ĐĂNG XUẤT",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            // Không cho thoát tài khoản khi vẫn còn ca đang hoạt động.
            if (!YeuCauChuyenCaNeuDangLam())
                return;

            YeuCauDangXuat = true;
            DialogResult = DialogResult.OK;
            Close();
        }


        // Designer đang đăng ký sự kiện Paint cho pnlHeader.
        // Không cần vẽ thêm, nhưng phải có handler để tránh CS1061.
        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
        }


        private void btn_thoat_Click(object sender, EventArgs e)
        {
            // Nút X cũng phải tuân thủ quy trình ra ca.
            if (!YeuCauChuyenCaNeuDangLam())
                return;

            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

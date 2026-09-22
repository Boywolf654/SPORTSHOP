using System;
using System.Windows.Forms;

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

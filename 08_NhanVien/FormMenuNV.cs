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

            // Không cần nút HÓA ĐƠN riêng.
            // Lịch sử hóa đơn sẽ quản lý toàn bộ hóa đơn.
            if (btn_hoadon != null)
            {
                btn_hoadon.Visible = false;
            }
        }

        private void btn_chuyenca_Click(
            object sender,
            EventArgs e)
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

            using (FormChuyenGiaoCa frm =
                new FormChuyenGiaoCa())
            {
                if (frm.ShowDialog(this) ==
                    DialogResult.OK)
                {
                    YeuCauKhoaManHinh = true;

                    DialogResult =
                        DialogResult.OK;

                    Close();
                }
            }
        }

        private void btn_moket_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "MỞ KÉT THÀNH CÔNG",
                "SPORTSHOP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btn_dononline_Click(
            object sender,
            EventArgs e)
        {
            using (FormDonOnline frm =
                new FormDonOnline())
            {
                frm.ShowDialog(this);
            }
        }

        private void btn_khoamanhinh_Click(
            object sender,
            EventArgs e)
        {
            YeuCauKhoaManHinh = true;

            DialogResult =
                DialogResult.OK;

            Close();
        }

        private void btn_chamcong_Click(
            object sender,
            EventArgs e)
        {
            using (D frm = new D())
            {
                frm.ShowDialog(this);
            }
        }

        // =========================================================
        // LỊCH SỬ HÓA ĐƠN
        // =========================================================

        private void btn_giaodich_Click(
            object sender,
            EventArgs e)
        {
            using (
                SPORTSHOP._06_BanHang.FormDanhSachHoaDon frm =
                new SPORTSHOP._06_BanHang.FormDanhSachHoaDon())
            {
                frm.ShowDialog(this);
            }
        }

        // =========================================================
        // HÓA ĐƠN - KHÔNG DÙNG NỮA
        // =========================================================

        private void btn_hoadon_Click(
            object sender,
            EventArgs e)
        {
            // Không làm gì.
            // Nút đã được ẩn trong constructor.
        }

        // =========================================================
        // ĐĂNG XUẤT
        // =========================================================

        private void btn_dangxuat_Click(
            object sender,
            EventArgs e)
        {
            DialogResult confirm =
                MessageBox.Show(
                    "Bạn có chắc chắn muốn đăng xuất " +
                    "tài khoản nhân viên hiện tại không?",
                    "ĐĂNG XUẤT",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            YeuCauDangXuat = true;

            DialogResult =
                DialogResult.OK;

            Close();
        }

        // =========================================================
        // ĐÓNG MENU
        // =========================================================

        private void btn_thoat_Click(
            object sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        private void FormMenuNV_Load(
            object sender,
            EventArgs e)
        {
        }
    }
}
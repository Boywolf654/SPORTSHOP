using System;
using System.Drawing;
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

            // Giao diện menu đồng bộ theo phong cách SPORTSHOP:
            // nền tối + viền đỏ + chữ trắng + hover nổi bật.
            CauHinhGiaoDienMenu();

            // Tự căn giữa cụm nút khi đổi kích thước màn hình.
            Resize += FormMenuNV_Resize;

            // Không cần nút HÓA ĐƠN riêng.
            // Lịch sử hóa đơn sẽ quản lý toàn bộ hóa đơn.
            if (btn_hoadon != null)
            {
                btn_hoadon.Visible = false;
            }
        }


        // =========================================================
        // GIAO DIỆN MENU SPORTSHOP
        // =========================================================

        private void CauHinhGiaoDienMenu()
        {
            Guna.UI2.WinForms.Guna2Button[] buttons =
            {
                btn_chuyenca,
                btn_moket,
                btn_khoamanhinh,
                btn_dononline,
                btn_chamcong,
                btn_giaodich,
                btn_tracuu,
                btn_timSPP,
                btn_dangxuat
            };

            foreach (var btn in buttons)
            {
                if (btn == null) continue;

                btn.Size = new Size(220, 88);
                btn.BorderRadius = 16;
                btn.BorderThickness = 2;
                btn.BorderColor = Color.FromArgb(230, 35, 45);
                btn.FillColor = Color.FromArgb(24, 24, 28);
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                btn.TextAlign = HorizontalAlignment.Center;
                btn.Cursor = Cursors.Hand;
                btn.PressedColor = Color.FromArgb(170, 20, 28);

                btn.HoverState.FillColor = Color.FromArgb(225, 35, 45);
                btn.HoverState.ForeColor = Color.White;
                btn.HoverState.BorderColor = Color.White;
                btn.HoverState.CustomBorderColor = Color.White;
            }

            // Các nút có tính chất đặc biệt.
            btn_dangxuat.FillColor = Color.FromArgb(75, 20, 24);
            btn_dangxuat.BorderColor = Color.FromArgb(255, 70, 70);
            btn_dangxuat.HoverState.FillColor = Color.FromArgb(210, 30, 40);

            // Nút đóng menu: nhỏ, gọn, nổi bật ở góc phải.
            btn_thoat.Size = new Size(68, 58);
            btn_thoat.Location = new Point(
                ClientSize.Width - btn_thoat.Width - 22, 20);
            btn_thoat.BorderRadius = 16;
            btn_thoat.BorderThickness = 1;
            btn_thoat.BorderColor = Color.FromArgb(230, 35, 45);
            btn_thoat.FillColor = Color.FromArgb(35, 35, 40);
            btn_thoat.ForeColor = Color.White;
            btn_thoat.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn_thoat.Cursor = Cursors.Hand;
            btn_thoat.HoverState.FillColor = Color.FromArgb(225, 35, 45);
            btn_thoat.HoverState.ForeColor = Color.White;

            // Nút HÓA ĐƠN cũ không dùng.
            btn_hoadon.Visible = false;

            CanGiuaCacNut();
        }

        private void FormMenuNV_Resize(object sender, EventArgs e)
        {
            CanGiuaCacNut();
        }

        private void CanGiuaCacNut()
        {
            if (btn_chuyenca == null) return;

            Guna.UI2.WinForms.Guna2Button[] buttons =
            {
                btn_chuyenca,
                btn_moket,
                btn_khoamanhinh,
                btn_dononline,
                btn_chamcong,
                btn_giaodich,
                btn_tracuu,
                btn_timSPP,
                btn_dangxuat
            };

            const int columns = 3;
            const int gapX = 24;
            const int gapY = 22;
            const int top = 155;

            int totalWidth =
                columns * 220 + (columns - 1) * gapX;

            int startX =
                Math.Max(20, (ClientSize.Width - totalWidth) / 2);

            for (int i = 0; i < buttons.Length; i++)
            {
                int row = i / columns;
                int col = i % columns;

                buttons[i].Location = new Point(
                    startX + col * (220 + gapX),
                    top + row * (88 + gapY)
                );
            }

            if (btn_thoat != null)
            {
                btn_thoat.Location = new Point(
                    Math.Max(10, ClientSize.Width - btn_thoat.Width - 22),
                    20
                );
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
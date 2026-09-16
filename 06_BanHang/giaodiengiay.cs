using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    public partial class giaodiengiay : Form
    {
        public giaodiengiay()
        {
            InitializeComponent();

            // Gắn sự kiện click cho toàn bộ card sản phẩm
            GanSuKienClickSanPham();
        }

        private void giaodiengiay_Load(object sender, EventArgs e)
        {
        }

        // =========================================================
        // GẮN CLICK CHO CÁC CARD SẢN PHẨM
        // =========================================================

        private void GanSuKienClickSanPham()
        {
            GanClickCard(
                pnl_giay1,
                1,
                "Nike Tiempo Ligera Pro FG Hồng Phấn World Cup 2026 IO4400-901",
                4400000,
                4750000,
                pictureBox2);

            GanClickCard(
                pnl_giay2,
                2,
                "Nike Tiempo Maestro Academy MG/FG Hồng Phấn World Cup 2026 IQ2385-901",
                8900000,
                9300000,
                pictureBox3);

            GanClickCard(
                pnl_giay3,
                3,
                "Adidas F50 Hyperfast League TF màu đen/blue KJ3436",
                4500000,
                4800000,
                pictureBox4);

            GanClickCard(
                pnl_giay4,
                4,
                "Nike Tiempo Ligera Pro Heritage",
                3000000,
                3500000,
                pictureBox5);

            GanClickCard(
                pnl_giay5,
                5,
                "Adidas Hyperfast Pro LL TF trắng/đỏ Chaos vs Control KK1043",
                1945000,
                2000000,
                pictureBox6);

            GanClickCard(
                pnl_giay6,
                6,
                "NMS Maestri 1.0 FG màu trắng/blue MAEFG1100",
                745000,
                1000000,
                pictureBox7);

            GanClickCard(
                pnl_giay7,
                7,
                "Giày Nike Air Zoom Fly 6 Bright Crimson FN8454-601",
                2790000,
                3000000,
                pictureBox8);

            GanClickCard(
                pnl_giay8,
                8,
                "Kelme V-Mach 3.0.3 TF Light Green 8621ZX1425-305",
                3500000,
                0,
                pictureBox9);

            GanClickCard(
                pnl_giay9,
                9,
                "Nike Phantom 6 Pro TF màu đen/xanh lá HJ4123-001",
                3900000,
                0,
                pictureBox10);

            GanClickCard(
                pnl_giay10,
                10,
                "Tiempo Ligera Pro TF màu vàng IB4477-100",
                725000,
                0,
                pictureBox11);

            GanClickCard(
                pnl_giay11,
                11,
                "Tiempo Ligera Pro TF màu trắng sữa IB4477-100",
                580000,
                0,
                pictureBox12);

            GanClickCard(
                pnl_giay12,
                12,
                "Adidas Predator League FT TF màu đỏ/trắng Chaos vs Control IH7213",
                580000,
                0,
                pictureBox13);

            GanClickCard(
                pnl_giay13,
                13,
                "Nike Mercurial Vapor 17 ProTF màu xanh lam IM5811-001",
                470000,
                0,
                pictureBox14);

            GanClickCard(
                pnl_giay14,
                14,
                "Jogarbola Kumo TF màu hồng ngọc lam JG-221106-1GY",
                450000,
                550000,
                pictureBox15);
        }

        // =========================================================
        // GẮN CLICK CHO CARD + TẤT CẢ CONTROL BÊN TRONG
        // =========================================================

        private void GanClickCard(
            Panel card,
            int maSP,
            string tenSP,
            decimal gia,
            decimal giaCu,
            PictureBox picture)
        {
            if (card == null)
                return;

            SanPhamTam sanPham = new SanPhamTam
            {
                MaSP = maSP,
                TenSP = tenSP,
                Gia = gia,
                GiaCu = giaCu,
                Anh = picture != null ? picture.BackgroundImage : null,
                LoaiSP = "Giày",
                ThuongHieu = LayThuongHieu(tenSP),
                MauSac = LayMauSac(tenSP),
                MoTa = "Sản phẩm giày thể thao SPORTSHOP."
            };

            // Lưu sản phẩm vào Tag của card
            card.Tag = sanPham;

            // Click được cả card
            card.Cursor = Cursors.Hand;
            card.Click += SanPham_Click;

            // Click được ảnh, tên, giá...
            GanClickChoControlCon(card, sanPham);
        }

        private void GanClickChoControlCon(
            Control parent,
            SanPhamTam sanPham)
        {
            foreach (Control control in parent.Controls)
            {
                control.Cursor = Cursors.Hand;
                control.Tag = sanPham;

                control.Click += SanPham_Click;

                // Nếu bên trong còn control con thì tiếp tục gắn
                if (control.Controls.Count > 0)
                {
                    GanClickChoControlCon(control, sanPham);
                }
            }
        }

        // =========================================================
        // CLICK SẢN PHẨM
        // =========================================================

        private void SanPham_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;

            if (control == null)
                return;

            SanPhamTam sanPham = control.Tag as SanPhamTam;

            if (sanPham == null)
                return;

            chitietsanpham formChiTiet =
                new chitietsanpham(sanPham);

            formChiTiet.StartPosition =
                FormStartPosition.CenterParent;

            formChiTiet.ShowDialog(this);
        }

        // =========================================================
        // LẤY THƯƠNG HIỆU
        // =========================================================

        private string LayThuongHieu(string tenSP)
        {
            if (string.IsNullOrWhiteSpace(tenSP))
                return "";

            if (tenSP.IndexOf(
                "Nike",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "Nike";

            if (tenSP.IndexOf(
                "Adidas",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "Adidas";

            if (tenSP.IndexOf(
                "Kelme",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "Kelme";

            if (tenSP.IndexOf(
                "Jogarbola",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "Jogarbola";

            if (tenSP.IndexOf(
                "NMS",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "NMS";

            return "Khác";
        }

        // =========================================================
        // LẤY MÀU TỪ TÊN SẢN PHẨM
        // =========================================================

        private string LayMauSac(string tenSP)
        {
            if (string.IsNullOrWhiteSpace(tenSP))
                return "";

            string[] mauSac =
            {
                "đen",
                "Đen",
                "trắng",
                "Trắng",
                "hồng",
                "Hồng",
                "đỏ",
                "Đỏ",
                "xanh",
                "Xanh",
                "vàng",
                "Vàng"
            };

            foreach (string mau in mauSac)
            {
                if (tenSP.Contains(mau))
                    return mau.ToLower();
            }

            return "";
        }
    }
}
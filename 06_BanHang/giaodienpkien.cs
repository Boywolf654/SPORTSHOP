using System;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    public partial class giaodienpkien : Form
    {
        public giaodienpkien()
        {
            InitializeComponent();

            GanSuKienClickSanPham();
        }

        private void giaodienpkien_Load(object sender, EventArgs e)
        {
        }

        // =========================================================
        // GẮN CLICK CHO 14 SẢN PHẨM
        // =========================================================

        private void GanSuKienClickSanPham()
        {
            GanClickCard(
                pnl_phukien1,
                101,
                "Găng tay thủ môn Nike Grip 3 màu vàng đen GK Gloves HQ0256-702",
                1500000,
                1800000,
                pictureBox2);

            GanClickCard(
                pnl_phukien2,
                102,
                "Găng tay thủ môn Nike Dynamic Fit núi lửa IF8194-830",
                2045000,
                0,
                pictureBox3);

            GanClickCard(
                pnl_phukien3,
                103,
                "Găng tay thủ môn Adidas X Pro xanh blue IA0836",
                2486000,
                0,
                pictureBox4);

            GanClickCard(
                pnl_phukien4,
                104,
                "Găng tay thủ môn Adidas X Pro màu xanh chuối IA0837",
                2800000,
                0,
                pictureBox5);

            GanClickCard(
                pnl_phukien5,
                105,
                "Quả bóng đá Adidas Bundesliga Torfabrik Pro 26/27 KG6037",
                3300000,
                0,
                pictureBox6);

            GanClickCard(
                pnl_phukien6,
                106,
                "Balo thể thao Kelme Basic 22L 9876004-010",
                1320000,
                0,
                pictureBox7);

            GanClickCard(
                pnl_phukien7,
                107,
                "Tất Nike Strike Crew màu đen trắng DH6620-010",
                300000,
                0,
                pictureBox8);

            GanClickCard(
                pnl_phukien8,
                108,
                "Tất Nike Strike Crew màu trắng DH6620-100",
                400000,
                450000,
                pictureBox9);

            GanClickCard(
                pnl_phukien9,
                109,
                "Bọc ống đồng Nike Mercurial Lite Shinguard màu xanh xám DN3611-395",
                675000,
                750000,
                pictureBox10);

            GanClickCard(
                pnl_phukien10,
                110,
                "Hộp Cầu Lông Chuyên Dụng",
                50000,
                0,
                pictureBox11);

            GanClickCard(
                pnl_phukien11,
                111,
                "Combo 2 bó gối thể thao Spinnix Virex màu đen",
                250000,
                0,
                pictureBox12);

            GanClickCard(
                pnl_phukien12,
                112,
                "Bình nước Adidas Tiro Bottle 0.5L xanh cửu long IW8158",
                100000,
                0,
                pictureBox13);

            GanClickCard(
                pnl_phukien13,
                113,
                "Chai xịt nóng hỗ trợ khởi động Ligpro 200ml",
                50000,
                0,
                pictureBox14);

            GanClickCard(
                pnl_phukien14,
                114,
                "Áo giữ nhiệt Wika màu xanh dương",
                140000,
                0,
                pictureBox15);
        }

        // =========================================================
        // GẮN CLICK CHO CARD
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
                Anh = picture != null
                    ? picture.BackgroundImage
                    : null,

                LoaiSP = "Phụ kiện",
                ThuongHieu = LayThuongHieu(tenSP),
                MauSac = LayMauSac(tenSP),
                MoTa = "Sản phẩm phụ kiện thể thao SPORTSHOP."
            };

            card.Tag = sanPham;
            card.Cursor = Cursors.Hand;

            card.Click += SanPham_Click;

            // Cho phép click vào ảnh + tên + giá
            GanClickControlCon(card, sanPham);
        }

        // =========================================================
        // CLICK CẢ CONTROL BÊN TRONG CARD
        // =========================================================

        private void GanClickControlCon(
            Control parent,
            SanPhamTam sanPham)
        {
            foreach (Control control in parent.Controls)
            {
                control.Tag = sanPham;
                control.Cursor = Cursors.Hand;

                control.Click += SanPham_Click;

                if (control.Controls.Count > 0)
                {
                    GanClickControlCon(control, sanPham);
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

            SanPhamTam sanPham =
                control.Tag as SanPhamTam;

            if (sanPham == null)
                return;

            chitietsanpham formChiTiet =
                new chitietsanpham(sanPham);

            formChiTiet.StartPosition =
                FormStartPosition.CenterParent;

            formChiTiet.ShowDialog(this);
        }

        // =========================================================
        // THƯƠNG HIỆU
        // =========================================================

        private string LayThuongHieu(string tenSP)
        {
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
                "Wika",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "Wika";

            if (tenSP.IndexOf(
                "Spinnix",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "Spinnix";

            if (tenSP.IndexOf(
                "Ligpro",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "Ligpro";

            return "Khác";
        }

        // =========================================================
        // MÀU SẮC
        // =========================================================

        private string LayMauSac(string tenSP)
        {
            string[] mauSac =
            {
                "đen",
                "trắng",
                "hồng",
                "đỏ",
                "xanh",
                "vàng",
                "xám",
                "xanh dương"
            };

            foreach (string mau in mauSac)
            {
                if (tenSP.IndexOf(
                    mau,
                    StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return mau;
                }
            }

            return "";
        }
    }
}
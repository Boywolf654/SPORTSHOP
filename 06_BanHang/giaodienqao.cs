using System.IO;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    public partial class giaodienqao : Form
    {
        public giaodienqao()
        {
            InitializeComponent();

            GanSuKienClickSanPham();
        }

        // =========================================================
        // GẮN SỰ KIỆN CHO 14 SẢN PHẨM
        // =========================================================

        private void GanSuKienClickSanPham()
        {
            GanClickCard(
                pnl_qao1,
                201,
                "Bộ quần áo CLB Arsenal màu đỏ trắng ARS26",
                300000,
                0,
                pictureBox2);

            GanClickCard(
                pnl_qao2,
                202,
                "Bộ quần áo bóng đá CLB Manchester United màu đỏ",
                250000,
                0,
                pictureBox3);

            GanClickCard(
                pnl_qao3,
                203,
                "Bộ quần áo ĐTQG Anh màu trắng 2026 ENG26",
                300000,
                0,
                pictureBox4);

            GanClickCard(
                pnl_qao4,
                204,
                "Bộ quần áo ĐTQG Pháp màu xanh FRA26J",
                300000,
                0,
                pictureBox5);

            GanClickCard(
                pnl_qao5,
                205,
                "Bộ quần áo ĐTQG Bồ Đào Nha màu POR26J",
                300000,
                0,
                pictureBox6);

            GanClickCard(
                pnl_qao6,
                206,
                "Quần áo bóng đá CLB Real Madrid màu trắng",
                250000,
                0,
                pictureBox7);

            GanClickCard(
                pnl_qao7,
                207,
                "Quần áo bóng đá CLB Arsenal màu đỏ - trắng",
                250000,
                0,
                pictureBox8);

            GanClickCard(
                pnl_qao8,
                208,
                "Bộ quần áo bóng đá CLB Liverpool màu đỏ 2025-2026",
                250000,
                0,
                pictureBox9);

            GanClickCard(
                pnl_qao9,
                209,
                "Bộ quần áo bóng đá CLB Barcelona màu xanh đỏ",
                250000,
                0,
                pictureBox10);

            GanClickCard(
                pnl_qao10,
                210,
                "Bộ quần áo đội tuyển Đức Euro 2024 màu trắng / đen",
                250000,
                0,
                pictureBox11);

            GanClickCard(
                pnl_qao11,
                211,
                "Bộ quần áo bóng đá CLB Chelsea màu xanh 2025",
                250000,
                0,
                pictureBox12);

            GanClickCard(
                pnl_qao12,
                212,
                "Bộ quần áo trẻ em CLB Al Nassr màu vàng NAS26J",
                300000,
                0,
                pictureBox13);

            GanClickCard(
                pnl_qao13,
                213,
                "Bộ quần áo bóng đá Kelme 2026 V1 series xanh lá 8651 ZB12489-339",
                250000,
                0,
                pictureBox14);

            GanClickCard(
                pnl_qao14,
                214,
                "Bộ quần áo bóng đá Kelme 2026 V2 series màu đỏ 8651 ZB12490-600",
                250000,
                0,
                pictureBox15);
        }

        // =========================================================
        // GẮN THÔNG TIN CHO CARD
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
                MaSP = LayMaSPTheoTen(tenSP, maSP),
                TenSP = tenSP,
                Gia = gia,
                GiaCu = giaCu,
                Anh = LayAnhChinhTheoMaSP(
                         LayMaSPTheoTen(tenSP, maSP),
                         picture != null ? picture.BackgroundImage : null),
                LoaiSP = "Quần áo",
                ThuongHieu = LayThuongHieu(tenSP),
                MauSac = LayMauSac(tenSP),
                MoTa = "Sản phẩm quần áo thể thao SPORTSHOP."
            };

            // Lưu sản phẩm vào Tag của card
            card.Tag = sanPham;
            card.Cursor = Cursors.Hand;

            // Click vào card
            card.Click += SanPham_Click;

            // Click vào ảnh, tên, giá cũng mở chi tiết
            GanClickControlCon(card, sanPham);
        }

        // =========================================================
        // GẮN CLICK CHO CONTROL BÊN TRONG CARD
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
        // CLICK SẢN PHẨM → MỞ CHI TIẾT
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
        // XÁC ĐỊNH THƯƠNG HIỆU
        // =========================================================

        private string LayThuongHieu(string tenSP)
        {
            if (tenSP.IndexOf(
                "Arsenal",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "Arsenal";

            if (tenSP.IndexOf(
                "Manchester United",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "Manchester United";

            if (tenSP.IndexOf(
                "Real Madrid",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "Real Madrid";

            if (tenSP.IndexOf(
                "Barcelona",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "Barcelona";

            if (tenSP.IndexOf(
                "Liverpool",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "Liverpool";

            if (tenSP.IndexOf(
                "Chelsea",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "Chelsea";

            if (tenSP.IndexOf(
                "Kelme",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "Kelme";

            if (tenSP.IndexOf(
                "Adidas",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "Adidas";

            if (tenSP.IndexOf(
                "Nike",
                StringComparison.OrdinalIgnoreCase) >= 0)
                return "Nike";

            return "Khác";
        }

        // =========================================================
        // XÁC ĐỊNH MÀU
        // =========================================================

        private string LayMauSac(string tenSP)
        {
            string[] mauSac =
            {
                "đỏ",
                "trắng",
                "xanh",
                "đen",
                "vàng",
                "xám"
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

        private void giaodienqao_Load(object sender, EventArgs e)
        {
        }
        // =========================================================
        // ĐỒNG BỘ CARD CLONE VỚI CSDL
        // =========================================================

        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        private int LayMaSPTheoTen(string tenSP, int maSPCu)
        {
            try
            {
                string sql = @"
                    SELECT TOP 1 MaSP
                    FROM SanPham
                    WHERE TenSP = @TenSP
                      AND TrangThai = 1
                    ORDER BY MaSP";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@TenSP", tenSP)
                };

                DataTable dt = kt.GetData(sql, parameters);

                if (dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0]["MaSP"]);

                return 0;
            }
            catch
            {
                // Nếu CSDL chưa sẵn sàng, vẫn cho form mở để không làm vỡ UI.
                return 0;
            }
        }

        private Image LayAnhChinhTheoMaSP(int maSP, Image anhMacDinh)
        {
            if (maSP <= 0)
                return anhMacDinh;

            try
            {
                string sql = @"
                    SELECT TOP 1 UrlAnh
                    FROM HinhAnhSanPham
                    WHERE MaSP = @MaSP
                      AND AnhChinh = 1
                    ORDER BY MaAnh";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaSP", maSP)
                };

                DataTable dt = kt.GetData(sql, parameters);

                if (dt.Rows.Count == 0)
                    return anhMacDinh;

                string urlAnh = dt.Rows[0]["UrlAnh"]?.ToString();

                if (string.IsNullOrWhiteSpace(urlAnh))
                    return anhMacDinh;

                string duongDan = urlAnh.Replace("/", Path.DirectorySeparatorChar.ToString());

                if (!Path.IsPathRooted(duongDan))
                    duongDan = Path.Combine(Application.StartupPath, duongDan);

                if (!File.Exists(duongDan))
                    return anhMacDinh;

                using (Image temp = Image.FromFile(duongDan))
                {
                    return new Bitmap(temp);
                }
            }
            catch
            {
                return anhMacDinh;
            }
        }

    }
}
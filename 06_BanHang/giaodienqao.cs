using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    public partial class giaodienqao : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        public giaodienqao()
        {
            InitializeComponent();
            LoadSanPhamTuCSDL();
        }

        private void giaodienqao_Load(object sender, EventArgs e)
        {
            // Dữ liệu đã được load trong constructor.
        }

        // =========================================================
        // LOAD SẢN PHẨM THẬT TỪ DATABASE
        // =========================================================
        private void LoadSanPhamTuCSDL()
        {
            Panel[] cards =
            {
                pnl_qao1,
                pnl_qao2,
                pnl_qao3,
                pnl_qao4,
                pnl_qao5,
                pnl_qao6,
                pnl_qao7,
                pnl_qao8,
                pnl_qao9,
                pnl_qao10,
                pnl_qao11,
                pnl_qao12,
                pnl_qao13,
                pnl_qao14
            };

            PictureBox[] pictures =
            {
                pictureBox2,
                pictureBox3,
                pictureBox4,
                pictureBox5,
                pictureBox6,
                pictureBox7,
                pictureBox8,
                pictureBox9,
                pictureBox10,
                pictureBox11,
                pictureBox12,
                pictureBox13,
                pictureBox14,
                pictureBox15
            };

            // Mặc định ẩn toàn bộ card. Card nào có sản phẩm sẽ được bật lại.
            foreach (Panel card in cards)
            {
                if (card != null)
                {
                    card.Tag = null;
                    card.Visible = false;
                    XoaSuKienClickCu(card);
                }
            }

            try
            {
                string sql = @"
                    SELECT TOP 14
                        sp.MaSP,
                        sp.TenSP,
                        ISNULL(sp.MoTa, '') AS MoTa,
                        ISNULL(dm.TenDanhMuc, '') AS TenDanhMuc,
                        ISNULL(th.TenThuongHieu, '') AS TenThuongHieu,
                        MIN(bt.GiaBan) AS GiaBan,
                        ISNULL(SUM(bt.SoLuong), 0) AS TonKho
                    FROM SanPham sp
                    LEFT JOIN DanhMuc dm
                        ON dm.MaDM = sp.MaDM
                    LEFT JOIN ThuongHieu th
                        ON th.MaTH = sp.MaTH
                    LEFT JOIN BienTheSanPham bt
                        ON bt.MaSP = sp.MaSP
                       AND bt.TrangThai = 1
                    WHERE sp.TrangThai = 1
                      AND (sp.MaDM = 7)
                    GROUP BY
                        sp.MaSP,
                        sp.TenSP,
                        sp.MoTa,
                        dm.TenDanhMuc,
                        th.TenThuongHieu
                    ORDER BY sp.MaSP;";

                DataTable dt = kt.GetData(sql);

                for (int i = 0; i < cards.Length && i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];

                    int maSP = Convert.ToInt32(row["MaSP"]);
                    string tenSP = row["TenSP"]?.ToString() ?? "";
                    string moTa = row["MoTa"]?.ToString() ?? "";
                    string tenDM = row["TenDanhMuc"]?.ToString() ?? "Quần áo";
                    string tenTH = row["TenThuongHieu"]?.ToString() ?? "";

                    decimal gia = 0;
                    if (row["GiaBan"] != DBNull.Value)
                        decimal.TryParse(row["GiaBan"].ToString(), out gia);

                    int tonKho = 0;
                    if (row["TonKho"] != DBNull.Value)
                        int.TryParse(row["TonKho"].ToString(), out tonKho);

                    SanPhamTam sanPham = new SanPhamTam
                    {
                        MaSP = maSP,
                        TenSP = tenSP,
                        Gia = gia,
                        GiaCu = 0,
                        Anh = LayAnhChinhTheoMaSP(
                            maSP,
                            pictures[i] != null ? pictures[i].BackgroundImage : null),
                        LoaiSP = tenDM,
                        ThuongHieu = tenTH,
                        // Không lấy màu từ tên sản phẩm nữa.
                        // Màu thật sẽ được xử lý từ BienTheSanPham ở form chi tiết.
                        MauSac = "",
                        MoTa = moTa
                    };

                    GanDuLieuVaoCard(cards[i], pictures[i], sanPham, tonKho);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách sản phẩm từ CSDL.\n\n" + ex.Message,
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // ĐƯA DỮ LIỆU DB VÀO CARD
        // =========================================================
        private void GanDuLieuVaoCard(
            Panel card,
            PictureBox picture,
            SanPhamTam sanPham,
            int tonKho)
        {
            if (card == null || sanPham == null)
                return;

            card.Visible = true;
            card.Tag = sanPham;
            card.Cursor = Cursors.Hand;

            if (picture != null && sanPham.Anh != null)
                picture.BackgroundImage = sanPham.Anh;

            // Các Label trong card đang có cấu trúc:
            // - Label ở khoảng Y 110-170: tên sản phẩm
            // - Label thấp nhất: giá hiện tại
            // - Các label giá cũ (nếu có) sẽ được ẩn.
            Label[] labels = card.Controls
                .OfType<Label>()
                .OrderBy(x => x.Location.Y)
                .ToArray();

            Label labelTen = labels.FirstOrDefault(
                x => x.Location.Y >= 100 && x.Location.Y <= 175);

            if (labelTen != null)
            {
                labelTen.Text = CatTenSanPham(sanPham.TenSP);
                labelTen.Visible = true;
            }

            Label labelGia = labels
                .Where(x => x.Location.Y >= 170)
                .OrderByDescending(x => x.Location.Y)
                .FirstOrDefault();

            if (labelGia != null)
            {
                labelGia.Text = sanPham.Gia > 0
                    ? sanPham.Gia.ToString("N0") + " Đ"
                    : "Liên hệ";
                labelGia.Visible = true;
            }

            // Ẩn các label giá cũ / label thừa.
            foreach (Label label in labels)
            {
                if (label != labelTen && label != labelGia && label.Location.Y >= 170)
                    label.Visible = false;
            }

            // Hiển thị trạng thái hết hàng nhưng không làm mất sản phẩm.
            // Khi vào chi tiết, người dùng vẫn có thể xem các biến thể.
            card.AccessibleDescription = tonKho > 0
                ? "Còn hàng: " + tonKho
                : "Hết hàng";

            GanClickCard(card, sanPham);
        }

        private string CatTenSanPham(string ten)
        {
            if (string.IsNullOrWhiteSpace(ten))
                return "";

            return ten.Trim();
        }

        // =========================================================
        // CLICK CARD
        // =========================================================
        private void GanClickCard(Panel card, SanPhamTam sanPham)
        {
            if (card == null)
                return;

            card.Tag = sanPham;
            card.Cursor = Cursors.Hand;

            card.Click -= SanPham_Click;
            card.Click += SanPham_Click;

            GanClickChoControlCon(card, sanPham);
        }

        private void GanClickChoControlCon(Control parent, SanPhamTam sanPham)
        {
            foreach (Control control in parent.Controls)
            {
                control.Tag = sanPham;
                control.Cursor = Cursors.Hand;

                control.Click -= SanPham_Click;
                control.Click += SanPham_Click;

                if (control.Controls.Count > 0)
                    GanClickChoControlCon(control, sanPham);
            }
        }

        private void XoaSuKienClickCu(Control parent)
        {
            parent.Click -= SanPham_Click;

            foreach (Control control in parent.Controls)
            {
                control.Click -= SanPham_Click;

                if (control.Controls.Count > 0)
                    XoaSuKienClickCu(control);
            }
        }

        private void SanPham_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;

            if (control == null)
                return;

            SanPhamTam sanPham = control.Tag as SanPhamTam;

            if (sanPham == null || sanPham.MaSP <= 0)
                return;

            using (chitietsanpham formChiTiet = new chitietsanpham(sanPham))
            {
                formChiTiet.StartPosition = FormStartPosition.CenterParent;
                formChiTiet.ShowDialog(this);
            }
        }

        // =========================================================
        // LẤY ẢNH CHÍNH THEO MaSP
        // =========================================================
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
                    ORDER BY MaAnh;";

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

                string duongDan = urlAnh.Replace(
                    "/",
                    Path.DirectorySeparatorChar.ToString());

                if (!Path.IsPathRooted(duongDan))
                    duongDan = Path.Combine(
                        Application.StartupPath,
                        duongDan);

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

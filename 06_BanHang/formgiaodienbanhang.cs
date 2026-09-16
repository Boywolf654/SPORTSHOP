using SPORTSHOP._06_BanHang;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class formgiaodienbanhang : Form
    {
        // =========================
        // MÀU CHỦ ĐẠO
        // =========================
        private readonly Color MauDo =
            Color.FromArgb(220, 30, 45);

        private readonly Color MauDen =
            Color.FromArgb(18, 18, 18);

        private readonly Color MauTrang =
            Color.White;

        public formgiaodienbanhang()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void formgiaodienbanhang_Load(
            object sender,
            EventArgs e)
        {
            BoTatCaPictureBox(this);

            DecorForm();
            DecorMenu();
            DecorGroupBox();
            DecorDanhMuc();
            DecorSanPhamNoiBat();
            DecorUuDai();

            GanSuKienDanhMuc();
            GanSuKienSanPham();
        }

        // =========================================================
        // DANH MỤC
        // =========================================================

        private void GanSuKienDanhMuc()
        {
            giaypbx.Click += (s, e) =>
            {
                MoFormDanhMuc("giay");
            };

            quanaopbx.Click += (s, e) =>
            {
                MoFormDanhMuc("ao");
            };

            phukienpbx.Click += (s, e) =>
            {
                MoFormDanhMuc("phukien");
            };
        }

        private void MoFormDanhMuc(string loai)
        {
            Form form = null;

            try
            {
                switch (loai)
                {
                    case "giay":
                        form = new giaodiengiay();
                        break;

                    case "ao":
                        form = new giaodienqao();
                        break;

                    case "phukien":
                        form = new giaodienpkien();
                        break;
                }

                if (form != null)
                {
                    form.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở giao diện danh mục.\n\n"
                    + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SẢN PHẨM
        // =========================================================

        private void GanSuKienSanPham()
        {
            GanClickCard(
                giay1pnl,
                1,
                "Giày thể thao Nike",
                1949000,
                2000000,
                pictureBox5,
                "Nike",
                "Đen",
                "Giày thể thao Nike");

            GanClickCard(
                giay2pnl,
                2,
                "Giày thể thao Adidas",
                745000,
                1000000,
                pictureBox6,
                "Adidas",
                "Trắng",
                "Giày thể thao Adidas");

            GanClickCard(
                giay3pnl,
                3,
                "Giày Nike Air Zoom",
                2790000,
                3000000,
                pictureBox7,
                "Nike",
                "Cam",
                "Giày Nike Air Zoom");

            GanClickCard(
                giay4pnl,
                4,
                "Giày thể thao",
                3900000,
                0,
                pictureBox8,
                "Nike",
                "Đen",
                "Giày thể thao");

            GanClickCard(
                giay5pnl,
                5,
                "Nike Tiempo Ligera Pro Heritage",
                3000000,
                3500000,
                pictureBox15,
                "Nike",
                "Hồng",
                "Nike Tiempo Ligera Pro Heritage");

            GanClickCard(
                giay6pnl,
                6,
                "Adidas F50 Hyperfast League TF Jr",
                3950000,
                4739000,
                pictureBox14,
                "Adidas",
                "Đen",
                "Adidas F50 Hyperfast League TF Jr");

            GanClickCard(
                giay7pnl,
                7,
                "Jogarbola Kumo TF màu hồng",
                450000,
                550000,
                pictureBox13,
                "Jogarbola",
                "Hồng",
                "Jogarbola Kumo TF");

            GanClickCard(
                giay8pnl,
                8,
                "Giày Nike Air Zoom Fly 6",
                2790000,
                3000000,
                pictureBox12,
                "Nike",
                "Đỏ",
                "Giày Nike Air Zoom Fly 6");

            GanClickCard(
                giay9pnl,
                9,
                "NMS Maestri 1.0 FG",
                800000,
                1142000,
                pictureBox11,
                "Adidas",
                "Trắng",
                "NMS Maestri 1.0 FG");

            GanClickCard(
                giay10pnl,
                10,
                "Nike Tiempo Ligera Pro FG",
                4400000,
                4750000,
                pictureBox10,
                "Nike",
                "Hồng",
                "Nike Tiempo Ligera Pro FG");

            GanClickCard(
                giay11pnl,
                11,
                "Nike Tiempo Maestro Academy",
                8900000,
                9300000,
                pictureBox9,
                "Nike",
                "Hồng",
                "Nike Tiempo Maestro Academy");
        }

        private void GanClickCard(
            Panel card,
            int maSP,
            string tenSP,
            decimal gia,
            decimal giaCu,
            PictureBox pictureBox,
            string thuongHieu,
            string mauSac,
            string moTa)
        {
            SanPhamTam sanPham =
                new SanPhamTam
                {
                    MaSP = maSP,
                    TenSP = tenSP,
                    Gia = gia,
                    GiaCu = giaCu,
                    Anh = pictureBox.Image ??
                          pictureBox.BackgroundImage,
                    ThuongHieu = thuongHieu,
                    MauSac = mauSac,
                    MoTa = moTa
                };

            card.Tag = sanPham;
            card.Cursor = Cursors.Hand;

            card.Click += SanPham_Click;

            GanClickControlCon(
                card,
                sanPham);
        }

        private void GanClickControlCon(
            Control parent,
            SanPhamTam sanPham)
        {
            foreach (Control control in parent.Controls)
            {
                control.Tag = sanPham;
                control.Cursor = Cursors.Hand;

                control.Click += SanPham_Click;

                if (control.HasChildren)
                {
                    GanClickControlCon(
                        control,
                        sanPham);
                }
            }
        }

        // =========================================================
        // CLICK SẢN PHẨM → CHI TIẾT
        // =========================================================

        private void SanPham_Click(
            object sender,
            EventArgs e)
        {
            Control control =
                sender as Control;

            if (control == null)
                return;

            SanPhamTam sanPham =
                control.Tag as SanPhamTam;

            if (sanPham == null)
                return;

            try
            {
                chitietsanpham formChiTiet =
                    new chitietsanpham(sanPham);

                formChiTiet.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở chi tiết sản phẩm.\n\n"
                    + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // FORM
        // =========================================================

        private void DecorForm()
        {
            this.Text =
                "SPORTSHOP - Cửa hàng thể thao";

            this.BackColor = MauDen;

            pictureBox1.SizeMode =
                PictureBoxSizeMode.Zoom;

            pictureBox1.BackColor =
                Color.Transparent;
        }

        // =========================================================
        // MENU
        // =========================================================

        private void DecorMenu()
        {
            menuStrip1.BackColor =
                Color.Transparent;

            menuStrip1.ForeColor =
                MauTrang;

            menuStrip1.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            menuStrip1.Renderer =
                new ModernMenuRenderer();

            foreach (ToolStripItem item
                in menuStrip1.Items)
            {
                item.ForeColor = MauTrang;
                item.BackColor =
                    Color.Transparent;

                item.Padding =
                    new Padding(
                        14,
                        8,
                        14,
                        8);
            }
        }

        // =========================================================
        // GROUPBOX
        // =========================================================

        private void DecorGroupBox()
        {
            DecorGroupBoxStyle(groupBox1);
            DecorGroupBoxStyle(groupBox2);
            DecorGroupBoxStyle(groupBox3);
        }

        private void DecorGroupBoxStyle(
            GroupBox box)
        {
            box.BackColor =
                Color.FromArgb(
                    35,
                    35,
                    37);

            box.ForeColor = MauTrang;

            box.Font =
                new Font(
                    "Segoe UI",
                    13F,
                    FontStyle.Bold);

            box.Padding =
                new Padding(10);
        }

        // =========================================================
        // DANH MỤC
        // =========================================================

        private void DecorDanhMuc()
        {
            DecorCategoryPicture(giaypbx);
            DecorCategoryPicture(quanaopbx);
            DecorCategoryPicture(phukienpbx);
        }

        private void DecorCategoryPicture(
            PictureBox pic)
        {
            pic.BackColor = MauTrang;

            pic.Cursor =
                Cursors.Hand;

            pic.SizeMode =
                PictureBoxSizeMode.Zoom;

            pic.MouseEnter +=
                Category_MouseEnter;

            pic.MouseLeave +=
                Category_MouseLeave;
        }

        private void Category_MouseEnter(
            object sender,
            EventArgs e)
        {
            PictureBox pic =
                sender as PictureBox;

            if (pic == null)
                return;

            pic.BackColor =
                Color.FromArgb(
                    245,
                    245,
                    245);

            pic.Cursor =
                Cursors.Hand;
        }

        private void Category_MouseLeave(
            object sender,
            EventArgs e)
        {
            PictureBox pic =
                sender as PictureBox;

            if (pic == null)
                return;

            pic.BackColor =
                MauTrang;
        }

        // =========================================================
        // SẢN PHẨM NỔI BẬT
        // =========================================================

        private void DecorSanPhamNoiBat()
        {
            DecorCard(giay1pnl);
            DecorCard(giay2pnl);
            DecorCard(giay3pnl);
            DecorCard(giay4pnl);
        }

        // =========================================================
        // ƯU ĐÃI
        // =========================================================

        private void DecorUuDai()
        {
            DecorCard(giay5pnl);
            DecorCard(giay6pnl);
            DecorCard(giay7pnl);
            DecorCard(giay8pnl);
            DecorCard(giay9pnl);
            DecorCard(giay10pnl);
            DecorCard(giay11pnl);
        }

        // =========================================================
        // PRODUCT CARD
        // =========================================================

        private void DecorCard(
            Panel card)
        {
            card.BackColor =
                Color.FromArgb(
                    35,
                    35,
                    38);

            card.BorderStyle =
                BorderStyle.None;

            card.Cursor =
                Cursors.Hand;

            BoGocPanel(card, 12);

            card.MouseEnter +=
                Card_MouseEnter;

            card.MouseLeave +=
                Card_MouseLeave;

            foreach (Control control
                in card.Controls)
            {
                control.MouseEnter +=
                    Child_MouseEnter;

                control.MouseLeave +=
                    Child_MouseLeave;

                if (control is PictureBox pic)
                {
                    pic.BackColor =
                        MauTrang;

                    pic.SizeMode =
                        PictureBoxSizeMode.Zoom;

                    pic.Padding =
                        new Padding(6);
                }

                if (control is Label label)
                {
                    label.BackColor =
                        Color.Transparent;

                    label.ForeColor =
                        MauTrang;

                    label.Font =
                        new Font(
                            "Segoe UI",
                            8.5F,
                            FontStyle.Regular);
                }
            }

            // Xử lý màu giá
            foreach (Control control
                in card.Controls)
            {
                if (control is Label label)
                {
                    if (label.Font.Strikeout)
                    {
                        label.ForeColor =
                            Color.FromArgb(
                                150,
                                150,
                                150);

                        label.Font =
                            new Font(
                                "Segoe UI",
                                8F,
                                FontStyle.Strikeout);
                    }
                    else if (
                        label.Text.Contains("Đ"))
                    {
                        label.ForeColor =
                            Color.FromArgb(
                                255,
                                70,
                                70);

                        label.Font =
                            new Font(
                                "Segoe UI",
                                10F,
                                FontStyle.Bold);
                    }
                }
            }
        }

        // =========================================================
        // BO GÓC PANEL
        // =========================================================

        private void BoGocPanel(
            Panel panel,
            int radius)
        {
            if (panel.Width <= radius ||
                panel.Height <= radius)
                return;

            GraphicsPath path =
                new GraphicsPath();

            path.AddArc(
                0,
                0,
                radius,
                radius,
                180,
                90);

            path.AddArc(
                panel.Width - radius,
                0,
                radius,
                radius,
                270,
                90);

            path.AddArc(
                panel.Width - radius,
                panel.Height - radius,
                radius,
                radius,
                0,
                90);

            path.AddArc(
                0,
                panel.Height - radius,
                radius,
                radius,
                90,
                90);

            path.CloseFigure();

            panel.Region =
                new Region(path);
        }

        // =========================================================
        // HOVER CARD
        // =========================================================

        private void Card_MouseEnter(
            object sender,
            EventArgs e)
        {
            Panel card =
                sender as Panel;

            if (card == null)
                return;

            card.BackColor =
                Color.FromArgb(
                    50,
                    50,
                    54);
        }

        private void Card_MouseLeave(
            object sender,
            EventArgs e)
        {
            Panel card =
                sender as Panel;

            if (card == null)
                return;

            card.BackColor =
                Color.FromArgb(
                    32,
                    32,
                    34);
        }

        private void Child_MouseEnter(
            object sender,
            EventArgs e)
        {
            Control control =
                sender as Control;

            if (control?.Parent is Panel card)
            {
                card.BackColor =
                    Color.FromArgb(
                        45,
                        45,
                        48);
            }
        }

        private void Child_MouseLeave(
            object sender,
            EventArgs e)
        {
            Control control =
                sender as Control;

            if (control?.Parent is Panel card)
            {
                card.BackColor =
                    Color.FromArgb(
                        32,
                        32,
                        34);
            }
        }

        // =========================================================
        // BO GÓC PICTUREBOX
        // =========================================================

        private void BoGocPictureBox(
            PictureBox pic,
            int radius)
        {
            if (pic.Width <= radius ||
                pic.Height <= radius)
                return;

            GraphicsPath path =
                new GraphicsPath();

            path.AddArc(
                0,
                0,
                radius,
                radius,
                180,
                90);

            path.AddArc(
                pic.Width - radius,
                0,
                radius,
                radius,
                270,
                90);

            path.AddArc(
                pic.Width - radius,
                pic.Height - radius,
                radius,
                radius,
                0,
                90);

            path.AddArc(
                0,
                pic.Height - radius,
                radius,
                radius,
                90,
                90);

            path.CloseFigure();

            pic.Region =
                new Region(path);
        }

        private void BoTatCaPictureBox(
            Control parent)
        {
            foreach (Control control
                in parent.Controls)
            {
                if (control is PictureBox pic)
                {
                    BoGocPictureBox(
                        pic,
                        20);
                }

                if (control.HasChildren)
                {
                    BoTatCaPictureBox(
                        control);
                }
            }
        }

        // =========================================================
        // EVENT CŨ - GIỮ ĐỂ DESIGNER KHÔNG LỖI
        // =========================================================

        private void tấtCảToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
        }

        private void baloToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
        }

        private void panel1_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void label3_Click(
            object sender,
            EventArgs e)
        {
        }

        private void pictureBox15_Click(
            object sender,
            EventArgs e)
        {
        }

        private void label14_Click(
            object sender,
            EventArgs e)
        {
        }
    }

    // =============================================================
    // MENU RENDERER
    // =============================================================

    public class ModernMenuRenderer :
        ToolStripProfessionalRenderer
    {
        public ModernMenuRenderer()
            : base(new ModernMenuColorTable())
        {
        }

        protected override void OnRenderItemText(
            ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.TextColor = Color.White;
            }

            base.OnRenderItemText(e);
        }
    }

    public class ModernMenuColorTable :
        ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get
            {
                return Color.FromArgb(
                    220,
                    30,
                    45);
            }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return Color.FromArgb(
                    220,
                    30,
                    45);
            }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return Color.FromArgb(
                    180,
                    20,
                    35);
            }
        }

        public override Color ToolStripDropDownBackground
        {
            get
            {
                return Color.FromArgb(
                    28,
                    28,
                    30);
            }
        }

        public override Color MenuBorder
        {
            get
            {
                return Color.FromArgb(
                    60,
                    60,
                    60);
            }
        }

        public override Color MenuItemBorder
        {
            get
            {
                return Color.Transparent;
            }
        }
    }
}
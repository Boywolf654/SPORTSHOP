namespace SPORTSHOP
{
    partial class FormNVKho
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.lbLogo = new System.Windows.Forms.Label();
            this.lbVaiTro = new System.Windows.Forms.Label();
            this.btn_tongquan = new Guna.UI2.WinForms.Guna2Button();
            this.btn_kho = new Guna.UI2.WinForms.Guna2Button();
            this.btn_nhacungcap = new Guna.UI2.WinForms.Guna2Button();
            this.btn_dangxuat = new Guna.UI2.WinForms.Guna2Button();

            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();

            this.pnl_sanpham = new System.Windows.Forms.Panel();
            this.lbIconSanPham = new System.Windows.Forms.Label();
            this.lbCaptionSanPham = new System.Windows.Forms.Label();
            this.lbTongSanPham = new System.Windows.Forms.Label();

            this.pnl_tonkho = new System.Windows.Forms.Panel();
            this.lbIconTonKho = new System.Windows.Forms.Label();
            this.lbCaptionTonKho = new System.Windows.Forms.Label();
            this.lbTongTonKho = new System.Windows.Forms.Label();

            this.pnl_saphet = new System.Windows.Forms.Panel();
            this.lbIconSapHet = new System.Windows.Forms.Label();
            this.lbCaptionSapHet = new System.Windows.Forms.Label();
            this.lbSapHet = new System.Windows.Forms.Label();

            this.pnl_ncc = new System.Windows.Forms.Panel();
            this.lbIconNCC = new System.Windows.Forms.Label();
            this.lbCaptionNCC = new System.Windows.Forms.Label();
            this.lbTongNCC = new System.Windows.Forms.Label();

            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgv_kho = new System.Windows.Forms.DataGridView();
            this.btn_xemct = new System.Windows.Forms.Button();
            this.btn_lammoi = new System.Windows.Forms.Button();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();

            this.panelMenuKho = new Guna.UI2.WinForms.Guna2Panel();
            this.btn_quanlykho = new Guna.UI2.WinForms.Guna2Button();
            this.btn_tonkho = new Guna.UI2.WinForms.Guna2Button();
            this.btn_lichsuton = new Guna.UI2.WinForms.Guna2Button();
            this.btn_nhaphang = new Guna.UI2.WinForms.Guna2Button();
            this.btn_phieunhap = new Guna.UI2.WinForms.Guna2Button();
            this.btn_phieukho = new Guna.UI2.WinForms.Guna2Button();

            this.PanelMenuNCC = new Guna.UI2.WinForms.Guna2Panel();
            this.btn_NCC = new Guna.UI2.WinForms.Guna2Button();
            this.btn_themNCC = new Guna.UI2.WinForms.Guna2Button();

            this.panelSidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnl_sanpham.SuspendLayout();
            this.pnl_tonkho.SuspendLayout();
            this.pnl_saphet.SuspendLayout();
            this.pnl_ncc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kho)).BeginInit();
            this.panelMenuKho.SuspendLayout();
            this.PanelMenuNCC.SuspendLayout();
            this.SuspendLayout();

            // =========================================================
            // panelSidebar
            // =========================================================
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panelSidebar.Controls.Add(this.lbLogo);
            this.panelSidebar.Controls.Add(this.lbVaiTro);
            this.panelSidebar.Controls.Add(this.btn_tongquan);
            this.panelSidebar.Controls.Add(this.btn_kho);
            this.panelSidebar.Controls.Add(this.btn_nhacungcap);
            this.panelSidebar.Controls.Add(this.btn_dangxuat);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(218, 768);
            this.panelSidebar.TabIndex = 0;

            this.lbLogo.AutoSize = true;
            this.lbLogo.BackColor = System.Drawing.Color.Transparent;
            this.lbLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lbLogo.ForeColor = System.Drawing.Color.White;
            this.lbLogo.Location = new System.Drawing.Point(30, 45);
            this.lbLogo.Name = "lbLogo";
            this.lbLogo.Size = new System.Drawing.Size(170, 29);
            this.lbLogo.TabIndex = 0;
            this.lbLogo.Text = "SPORT SHOP";

            this.lbVaiTro.AutoSize = true;
            this.lbVaiTro.BackColor = System.Drawing.Color.Transparent;
            this.lbVaiTro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(165)))), ((int)(((byte)(200)))));
            this.lbVaiTro.Location = new System.Drawing.Point(33, 80);
            this.lbVaiTro.Name = "lbVaiTro";
            this.lbVaiTro.Size = new System.Drawing.Size(120, 19);
            this.lbVaiTro.TabIndex = 1;
            this.lbVaiTro.Text = "Nhân viên kho";

            // ---- Nút điều hướng ----
            this.btn_tongquan.BorderRadius = 10;
            this.btn_tongquan.FillColor = System.Drawing.Color.Transparent;
            this.btn_tongquan.FocusedColor = System.Drawing.Color.Transparent;
            this.btn_tongquan.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_tongquan.ForeColor = System.Drawing.Color.White;
            this.btn_tongquan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.btn_tongquan.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_tongquan.Location = new System.Drawing.Point(1, 153);
            this.btn_tongquan.Name = "btn_tongquan";
            this.btn_tongquan.Size = new System.Drawing.Size(217, 45);
            this.btn_tongquan.TabIndex = 2;
            this.btn_tongquan.Text = " 🏠 TỔNG QUAN";
            this.btn_tongquan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_tongquan.TextOffset = new System.Drawing.Point(10, 0);
            this.btn_tongquan.Click += new System.EventHandler(this.btn_tongquan_Click);

            this.btn_kho.BorderRadius = 10;
            this.btn_kho.FillColor = System.Drawing.Color.Transparent;
            this.btn_kho.FocusedColor = System.Drawing.Color.Transparent;
            this.btn_kho.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_kho.ForeColor = System.Drawing.Color.White;
            this.btn_kho.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.btn_kho.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_kho.Location = new System.Drawing.Point(1, 204);
            this.btn_kho.Name = "btn_kho";
            this.btn_kho.Size = new System.Drawing.Size(217, 45);
            this.btn_kho.TabIndex = 3;
            this.btn_kho.Text = " 📦 KHO HÀNG";
            this.btn_kho.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_kho.TextOffset = new System.Drawing.Point(10, 0);
            this.btn_kho.Click += new System.EventHandler(this.btn_kho_Click);

            this.btn_nhacungcap.BorderRadius = 10;
            this.btn_nhacungcap.FillColor = System.Drawing.Color.Transparent;
            this.btn_nhacungcap.FocusedColor = System.Drawing.Color.Transparent;
            this.btn_nhacungcap.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_nhacungcap.ForeColor = System.Drawing.Color.White;
            this.btn_nhacungcap.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.btn_nhacungcap.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_nhacungcap.Location = new System.Drawing.Point(1, 255);
            this.btn_nhacungcap.Name = "btn_nhacungcap";
            this.btn_nhacungcap.Size = new System.Drawing.Size(217, 45);
            this.btn_nhacungcap.TabIndex = 4;
            this.btn_nhacungcap.Text = " 🏭 NHÀ CUNG CẤP";
            this.btn_nhacungcap.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_nhacungcap.TextOffset = new System.Drawing.Point(10, 0);
            this.btn_nhacungcap.Click += new System.EventHandler(this.btn_nhacungcap_Click);

            this.btn_dangxuat.BorderRadius = 10;
            this.btn_dangxuat.FillColor = System.Drawing.Color.Transparent;
            this.btn_dangxuat.FocusedColor = System.Drawing.Color.Transparent;
            this.btn_dangxuat.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_dangxuat.ForeColor = System.Drawing.Color.White;
            this.btn_dangxuat.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.btn_dangxuat.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_dangxuat.Location = new System.Drawing.Point(1, 603);
            this.btn_dangxuat.Name = "btn_dangxuat";
            this.btn_dangxuat.Size = new System.Drawing.Size(217, 45);
            this.btn_dangxuat.TabIndex = 5;
            this.btn_dangxuat.Text = " 🚪 Đăng Xuất";
            this.btn_dangxuat.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_dangxuat.TextOffset = new System.Drawing.Point(10, 0);
            this.btn_dangxuat.Click += new System.EventHandler(this.btn_dangxuat_Click);

            // =========================================================
            // panel1 - vùng nội dung
            // =========================================================
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.btn_xemct);
            this.panel1.Controls.Add(this.btn_lammoi);
            this.panel1.Controls.Add(this.dgv_kho);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(218, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 768);
            this.panel1.TabIndex = 1;

            // ---- panel2 : các thẻ thống kê ----
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.panel2.Controls.Add(this.pnl_sanpham);
            this.panel2.Controls.Add(this.pnl_tonkho);
            this.panel2.Controls.Add(this.pnl_saphet);
            this.panel2.Controls.Add(this.pnl_ncc);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1112, 131);
            this.panel2.TabIndex = 0;

            // Thẻ 1 : Sản phẩm
            this.pnl_sanpham.BackColor = System.Drawing.Color.White;
            this.pnl_sanpham.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_sanpham.Controls.Add(this.lbIconSanPham);
            this.pnl_sanpham.Controls.Add(this.lbCaptionSanPham);
            this.pnl_sanpham.Controls.Add(this.lbTongSanPham);
            this.pnl_sanpham.Location = new System.Drawing.Point(5, 34);
            this.pnl_sanpham.Name = "pnl_sanpham";
            this.pnl_sanpham.Size = new System.Drawing.Size(259, 68);
            this.pnl_sanpham.TabIndex = 0;

            this.lbIconSanPham.BackColor = System.Drawing.Color.Transparent;
            this.lbIconSanPham.Font = new System.Drawing.Font("Segoe UI Emoji", 20F);
            this.lbIconSanPham.Location = new System.Drawing.Point(12, 10);
            this.lbIconSanPham.Name = "lbIconSanPham";
            this.lbIconSanPham.Size = new System.Drawing.Size(58, 48);
            this.lbIconSanPham.TabIndex = 0;
            this.lbIconSanPham.Text = "🛍";
            this.lbIconSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lbCaptionSanPham.AutoSize = true;
            this.lbCaptionSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbCaptionSanPham.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(115)))), ((int)(((byte)(125)))));
            this.lbCaptionSanPham.Location = new System.Drawing.Point(77, 6);
            this.lbCaptionSanPham.Name = "lbCaptionSanPham";
            this.lbCaptionSanPham.Size = new System.Drawing.Size(84, 20);
            this.lbCaptionSanPham.TabIndex = 1;
            this.lbCaptionSanPham.Text = "Sản phẩm";

            this.lbTongSanPham.AutoSize = false;
            this.lbTongSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbTongSanPham.Location = new System.Drawing.Point(77, 32);
            this.lbTongSanPham.Name = "lbTongSanPham";
            this.lbTongSanPham.Size = new System.Drawing.Size(174, 28);
            this.lbTongSanPham.TabIndex = 2;
            this.lbTongSanPham.Text = "0 sản phẩm";

            // Thẻ 2 : Tồn kho
            this.pnl_tonkho.BackColor = System.Drawing.Color.White;
            this.pnl_tonkho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_tonkho.Controls.Add(this.lbIconTonKho);
            this.pnl_tonkho.Controls.Add(this.lbCaptionTonKho);
            this.pnl_tonkho.Controls.Add(this.lbTongTonKho);
            this.pnl_tonkho.Location = new System.Drawing.Point(295, 34);
            this.pnl_tonkho.Name = "pnl_tonkho";
            this.pnl_tonkho.Size = new System.Drawing.Size(254, 68);
            this.pnl_tonkho.TabIndex = 1;

            this.lbIconTonKho.BackColor = System.Drawing.Color.Transparent;
            this.lbIconTonKho.Font = new System.Drawing.Font("Segoe UI Emoji", 20F);
            this.lbIconTonKho.Location = new System.Drawing.Point(12, 10);
            this.lbIconTonKho.Name = "lbIconTonKho";
            this.lbIconTonKho.Size = new System.Drawing.Size(58, 48);
            this.lbIconTonKho.TabIndex = 0;
            this.lbIconTonKho.Text = "📦";
            this.lbIconTonKho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lbCaptionTonKho.AutoSize = true;
            this.lbCaptionTonKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbCaptionTonKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(115)))), ((int)(((byte)(125)))));
            this.lbCaptionTonKho.Location = new System.Drawing.Point(77, 6);
            this.lbCaptionTonKho.Name = "lbCaptionTonKho";
            this.lbCaptionTonKho.Size = new System.Drawing.Size(68, 20);
            this.lbCaptionTonKho.TabIndex = 1;
            this.lbCaptionTonKho.Text = "Tồn kho";

            this.lbTongTonKho.AutoSize = false;
            this.lbTongTonKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbTongTonKho.Location = new System.Drawing.Point(77, 32);
            this.lbTongTonKho.Name = "lbTongTonKho";
            this.lbTongTonKho.Size = new System.Drawing.Size(169, 28);
            this.lbTongTonKho.TabIndex = 2;
            this.lbTongTonKho.Text = "0 sản phẩm";

            // Thẻ 3 : Sắp hết hàng
            this.pnl_saphet.BackColor = System.Drawing.Color.White;
            this.pnl_saphet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_saphet.Controls.Add(this.lbIconSapHet);
            this.pnl_saphet.Controls.Add(this.lbCaptionSapHet);
            this.pnl_saphet.Controls.Add(this.lbSapHet);
            this.pnl_saphet.Location = new System.Drawing.Point(581, 34);
            this.pnl_saphet.Name = "pnl_saphet";
            this.pnl_saphet.Size = new System.Drawing.Size(254, 68);
            this.pnl_saphet.TabIndex = 2;

            this.lbIconSapHet.BackColor = System.Drawing.Color.Transparent;
            this.lbIconSapHet.Font = new System.Drawing.Font("Segoe UI Emoji", 20F);
            this.lbIconSapHet.Location = new System.Drawing.Point(12, 10);
            this.lbIconSapHet.Name = "lbIconSapHet";
            this.lbIconSapHet.Size = new System.Drawing.Size(58, 48);
            this.lbIconSapHet.TabIndex = 0;
            this.lbIconSapHet.Text = "⚠";
            this.lbIconSapHet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lbCaptionSapHet.AutoSize = true;
            this.lbCaptionSapHet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbCaptionSapHet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(115)))), ((int)(((byte)(125)))));
            this.lbCaptionSapHet.Location = new System.Drawing.Point(77, 6);
            this.lbCaptionSapHet.Name = "lbCaptionSapHet";
            this.lbCaptionSapHet.Size = new System.Drawing.Size(120, 20);
            this.lbCaptionSapHet.TabIndex = 1;
            this.lbCaptionSapHet.Text = "Sắp hết hàng";

            this.lbSapHet.AutoSize = false;
            this.lbSapHet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbSapHet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lbSapHet.Location = new System.Drawing.Point(77, 32);
            this.lbSapHet.Name = "lbSapHet";
            this.lbSapHet.Size = new System.Drawing.Size(169, 28);
            this.lbSapHet.TabIndex = 2;
            this.lbSapHet.Text = "0 mục";

            // Thẻ 4 : Nhà cung cấp
            this.pnl_ncc.BackColor = System.Drawing.Color.White;
            this.pnl_ncc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_ncc.Controls.Add(this.lbIconNCC);
            this.pnl_ncc.Controls.Add(this.lbCaptionNCC);
            this.pnl_ncc.Controls.Add(this.lbTongNCC);
            this.pnl_ncc.Location = new System.Drawing.Point(854, 34);
            this.pnl_ncc.Name = "pnl_ncc";
            this.pnl_ncc.Size = new System.Drawing.Size(252, 68);
            this.pnl_ncc.TabIndex = 3;

            this.lbIconNCC.BackColor = System.Drawing.Color.Transparent;
            this.lbIconNCC.Font = new System.Drawing.Font("Segoe UI Emoji", 20F);
            this.lbIconNCC.Location = new System.Drawing.Point(12, 10);
            this.lbIconNCC.Name = "lbIconNCC";
            this.lbIconNCC.Size = new System.Drawing.Size(58, 48);
            this.lbIconNCC.TabIndex = 0;
            this.lbIconNCC.Text = "🏭";
            this.lbIconNCC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lbCaptionNCC.AutoSize = true;
            this.lbCaptionNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbCaptionNCC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(115)))), ((int)(((byte)(125)))));
            this.lbCaptionNCC.Location = new System.Drawing.Point(77, 6);
            this.lbCaptionNCC.Name = "lbCaptionNCC";
            this.lbCaptionNCC.Size = new System.Drawing.Size(124, 20);
            this.lbCaptionNCC.TabIndex = 1;
            this.lbCaptionNCC.Text = "Nhà cung cấp";

            this.lbTongNCC.AutoSize = false;
            this.lbTongNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbTongNCC.Location = new System.Drawing.Point(77, 32);
            this.lbTongNCC.Name = "lbTongNCC";
            this.lbTongNCC.Size = new System.Drawing.Size(167, 28);
            this.lbTongNCC.TabIndex = 2;
            this.lbTongNCC.Text = "0 đơn vị";

            // ---- Tiêu đề bảng ----
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(30, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(290, 36);
            this.label9.TabIndex = 1;
            this.label9.Text = "Tồn kho sản phẩm";

            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(115)))), ((int)(((byte)(125)))));
            this.label10.Location = new System.Drawing.Point(360, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(330, 24);
            this.label10.TabIndex = 2;
            this.label10.Text = "(Chọn một dòng rồi nhấn Xem chi tiết)";

            // ---- Lưới dữ liệu ----
            this.dgv_kho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_kho.BackgroundColor = System.Drawing.Color.White;
            this.dgv_kho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_kho.Location = new System.Drawing.Point(0, 192);
            this.dgv_kho.Name = "dgv_kho";
            this.dgv_kho.RowHeadersWidth = 62;
            this.dgv_kho.RowTemplate.Height = 28;
            this.dgv_kho.Size = new System.Drawing.Size(1108, 379);
            this.dgv_kho.TabIndex = 3;

            // ---- Nút thao tác ----
            this.btn_xemct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_xemct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_xemct.Location = new System.Drawing.Point(36, 605);
            this.btn_xemct.Name = "btn_xemct";
            this.btn_xemct.Size = new System.Drawing.Size(210, 45);
            this.btn_xemct.TabIndex = 4;
            this.btn_xemct.Text = "Xem chi tiết (F5)";
            this.btn_xemct.UseVisualStyleBackColor = true;
            this.btn_xemct.Click += new System.EventHandler(this.btn_xemct_Click);

            this.btn_lammoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_lammoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_lammoi.Location = new System.Drawing.Point(262, 605);
            this.btn_lammoi.Name = "btn_lammoi";
            this.btn_lammoi.Size = new System.Drawing.Size(160, 45);
            this.btn_lammoi.TabIndex = 5;
            this.btn_lammoi.Text = "Làm mới (F5)";
            this.btn_lammoi.UseVisualStyleBackColor = true;
            this.btn_lammoi.Click += new System.EventHandler(this.btn_lammoi_Click);

            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtTimKiem.BorderRadius = 15;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Location = new System.Drawing.Point(789, 605);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(141)))), ((int)(((byte)(147)))));
            this.txtTimKiem.PlaceholderText = "Tìm sản phẩm...";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(252, 43);
            this.txtTimKiem.TabIndex = 6;

            // =========================================================
            // panelMenuKho
            // =========================================================
            this.panelMenuKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panelMenuKho.Controls.Add(this.btn_quanlykho);
            this.panelMenuKho.Controls.Add(this.btn_tonkho);
            this.panelMenuKho.Controls.Add(this.btn_lichsuton);
            this.panelMenuKho.Controls.Add(this.btn_nhaphang);
            this.panelMenuKho.Controls.Add(this.btn_phieunhap);
            this.panelMenuKho.Controls.Add(this.btn_phieukho);
            this.panelMenuKho.Location = new System.Drawing.Point(218, 204);
            this.panelMenuKho.Name = "panelMenuKho";
            this.panelMenuKho.Size = new System.Drawing.Size(222, 320);
            this.panelMenuKho.TabIndex = 2;
            this.panelMenuKho.Visible = false;

            this.btn_quanlykho.BorderRadius = 10;
            this.btn_quanlykho.FillColor = System.Drawing.Color.Transparent;
            this.btn_quanlykho.FocusedColor = System.Drawing.Color.Transparent;
            this.btn_quanlykho.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_quanlykho.ForeColor = System.Drawing.Color.White;
            this.btn_quanlykho.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.btn_quanlykho.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_quanlykho.Location = new System.Drawing.Point(1, 3);
            this.btn_quanlykho.Name = "btn_quanlykho";
            this.btn_quanlykho.Size = new System.Drawing.Size(220, 45);
            this.btn_quanlykho.TabIndex = 0;
            this.btn_quanlykho.Text = "Quản lý kho";
            this.btn_quanlykho.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_quanlykho.TextOffset = new System.Drawing.Point(10, 0);
            this.btn_quanlykho.Click += new System.EventHandler(this.btn_quanlykho_Click);

            this.btn_tonkho.BorderRadius = 10;
            this.btn_tonkho.FillColor = System.Drawing.Color.Transparent;
            this.btn_tonkho.FocusedColor = System.Drawing.Color.Transparent;
            this.btn_tonkho.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_tonkho.ForeColor = System.Drawing.Color.White;
            this.btn_tonkho.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.btn_tonkho.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_tonkho.Location = new System.Drawing.Point(1, 54);
            this.btn_tonkho.Name = "btn_tonkho";
            this.btn_tonkho.Size = new System.Drawing.Size(220, 45);
            this.btn_tonkho.TabIndex = 1;
            this.btn_tonkho.Text = "Tồn kho";
            this.btn_tonkho.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_tonkho.TextOffset = new System.Drawing.Point(10, 0);
            this.btn_tonkho.Click += new System.EventHandler(this.btn_tonkho_Click);

            this.btn_lichsuton.BorderRadius = 10;
            this.btn_lichsuton.FillColor = System.Drawing.Color.Transparent;
            this.btn_lichsuton.FocusedColor = System.Drawing.Color.Transparent;
            this.btn_lichsuton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_lichsuton.ForeColor = System.Drawing.Color.White;
            this.btn_lichsuton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.btn_lichsuton.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_lichsuton.Location = new System.Drawing.Point(1, 105);
            this.btn_lichsuton.Name = "btn_lichsuton";
            this.btn_lichsuton.Size = new System.Drawing.Size(220, 45);
            this.btn_lichsuton.TabIndex = 2;
            this.btn_lichsuton.Text = "Lịch sử tồn kho";
            this.btn_lichsuton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_lichsuton.TextOffset = new System.Drawing.Point(10, 0);
            this.btn_lichsuton.Click += new System.EventHandler(this.btn_lichsuton_Click);

            this.btn_nhaphang.BorderRadius = 10;
            this.btn_nhaphang.FillColor = System.Drawing.Color.Transparent;
            this.btn_nhaphang.FocusedColor = System.Drawing.Color.Transparent;
            this.btn_nhaphang.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_nhaphang.ForeColor = System.Drawing.Color.White;
            this.btn_nhaphang.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.btn_nhaphang.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_nhaphang.Location = new System.Drawing.Point(1, 156);
            this.btn_nhaphang.Name = "btn_nhaphang";
            this.btn_nhaphang.Size = new System.Drawing.Size(220, 45);
            this.btn_nhaphang.TabIndex = 3;
            this.btn_nhaphang.Text = "Nhập hàng";
            this.btn_nhaphang.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_nhaphang.TextOffset = new System.Drawing.Point(10, 0);
            this.btn_nhaphang.Click += new System.EventHandler(this.btn_nhaphang_Click);

            this.btn_phieunhap.BorderRadius = 10;
            this.btn_phieunhap.FillColor = System.Drawing.Color.Transparent;
            this.btn_phieunhap.FocusedColor = System.Drawing.Color.Transparent;
            this.btn_phieunhap.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_phieunhap.ForeColor = System.Drawing.Color.White;
            this.btn_phieunhap.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.btn_phieunhap.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_phieunhap.Location = new System.Drawing.Point(1, 207);
            this.btn_phieunhap.Name = "btn_phieunhap";
            this.btn_phieunhap.Size = new System.Drawing.Size(220, 45);
            this.btn_phieunhap.TabIndex = 4;
            this.btn_phieunhap.Text = "Phiếu nhập";
            this.btn_phieunhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_phieunhap.TextOffset = new System.Drawing.Point(10, 0);
            this.btn_phieunhap.Click += new System.EventHandler(this.btn_phieunhap_Click);

            this.btn_phieukho.BorderRadius = 10;
            this.btn_phieukho.FillColor = System.Drawing.Color.Transparent;
            this.btn_phieukho.FocusedColor = System.Drawing.Color.Transparent;
            this.btn_phieukho.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_phieukho.ForeColor = System.Drawing.Color.White;
            this.btn_phieukho.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.btn_phieukho.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_phieukho.Location = new System.Drawing.Point(1, 258);
            this.btn_phieukho.Name = "btn_phieukho";
            this.btn_phieukho.Size = new System.Drawing.Size(220, 45);
            this.btn_phieukho.TabIndex = 5;
            this.btn_phieukho.Text = "Phiếu kho";
            this.btn_phieukho.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_phieukho.TextOffset = new System.Drawing.Point(10, 0);
            this.btn_phieukho.Click += new System.EventHandler(this.btn_phieukho_Click);

            // =========================================================
            // PanelMenuNCC
            // =========================================================
            this.PanelMenuNCC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.PanelMenuNCC.Controls.Add(this.btn_NCC);
            this.PanelMenuNCC.Controls.Add(this.btn_themNCC);
            this.PanelMenuNCC.Location = new System.Drawing.Point(218, 255);
            this.PanelMenuNCC.Name = "PanelMenuNCC";
            this.PanelMenuNCC.Size = new System.Drawing.Size(222, 116);
            this.PanelMenuNCC.TabIndex = 3;
            this.PanelMenuNCC.Visible = false;

            this.btn_NCC.BorderRadius = 10;
            this.btn_NCC.FillColor = System.Drawing.Color.Transparent;
            this.btn_NCC.FocusedColor = System.Drawing.Color.Transparent;
            this.btn_NCC.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_NCC.ForeColor = System.Drawing.Color.White;
            this.btn_NCC.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.btn_NCC.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_NCC.Location = new System.Drawing.Point(1, 3);
            this.btn_NCC.Name = "btn_NCC";
            this.btn_NCC.Size = new System.Drawing.Size(220, 45);
            this.btn_NCC.TabIndex = 0;
            this.btn_NCC.Text = "Nhà cung cấp";
            this.btn_NCC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_NCC.TextOffset = new System.Drawing.Point(10, 0);
            this.btn_NCC.Click += new System.EventHandler(this.btn_NCC_Click);

            this.btn_themNCC.BorderRadius = 10;
            this.btn_themNCC.FillColor = System.Drawing.Color.Transparent;
            this.btn_themNCC.FocusedColor = System.Drawing.Color.Transparent;
            this.btn_themNCC.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_themNCC.ForeColor = System.Drawing.Color.White;
            this.btn_themNCC.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.btn_themNCC.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_themNCC.Location = new System.Drawing.Point(1, 54);
            this.btn_themNCC.Name = "btn_themNCC";
            this.btn_themNCC.Size = new System.Drawing.Size(220, 45);
            this.btn_themNCC.TabIndex = 1;
            this.btn_themNCC.Text = "Thêm nhà cung cấp";
            this.btn_themNCC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_themNCC.TextOffset = new System.Drawing.Point(10, 0);
            this.btn_themNCC.Click += new System.EventHandler(this.btn_themNCC_Click);

            // =========================================================
            // FormNVKho
            // =========================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1330, 768);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelMenuKho);
            this.Controls.Add(this.PanelMenuNCC);
            this.Name = "FormNVKho";
            this.Text = "SPORTSHOP - Nhân viên kho";
            this.Load += new System.EventHandler(this.FormNVKho_Load);

            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnl_sanpham.ResumeLayout(false);
            this.pnl_sanpham.PerformLayout();
            this.pnl_tonkho.ResumeLayout(false);
            this.pnl_tonkho.PerformLayout();
            this.pnl_saphet.ResumeLayout(false);
            this.pnl_saphet.PerformLayout();
            this.pnl_ncc.ResumeLayout(false);
            this.pnl_ncc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kho)).EndInit();
            this.panelMenuKho.ResumeLayout(false);
            this.PanelMenuNCC.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelSidebar;
        private System.Windows.Forms.Label lbLogo;
        private System.Windows.Forms.Label lbVaiTro;
        private Guna.UI2.WinForms.Guna2Button btn_tongquan;
        private Guna.UI2.WinForms.Guna2Button btn_kho;
        private Guna.UI2.WinForms.Guna2Button btn_nhacungcap;
        private Guna.UI2.WinForms.Guna2Button btn_dangxuat;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.Panel pnl_sanpham;
        private System.Windows.Forms.Label lbIconSanPham;
        private System.Windows.Forms.Label lbCaptionSanPham;
        private System.Windows.Forms.Label lbTongSanPham;

        private System.Windows.Forms.Panel pnl_tonkho;
        private System.Windows.Forms.Label lbIconTonKho;
        private System.Windows.Forms.Label lbCaptionTonKho;
        private System.Windows.Forms.Label lbTongTonKho;

        private System.Windows.Forms.Panel pnl_saphet;
        private System.Windows.Forms.Label lbIconSapHet;
        private System.Windows.Forms.Label lbCaptionSapHet;
        private System.Windows.Forms.Label lbSapHet;

        private System.Windows.Forms.Panel pnl_ncc;
        private System.Windows.Forms.Label lbIconNCC;
        private System.Windows.Forms.Label lbCaptionNCC;
        private System.Windows.Forms.Label lbTongNCC;

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgv_kho;
        private System.Windows.Forms.Button btn_xemct;
        private System.Windows.Forms.Button btn_lammoi;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;

        private Guna.UI2.WinForms.Guna2Panel panelMenuKho;
        private Guna.UI2.WinForms.Guna2Button btn_quanlykho;
        private Guna.UI2.WinForms.Guna2Button btn_tonkho;
        private Guna.UI2.WinForms.Guna2Button btn_lichsuton;
        private Guna.UI2.WinForms.Guna2Button btn_nhaphang;
        private Guna.UI2.WinForms.Guna2Button btn_phieunhap;
        private Guna.UI2.WinForms.Guna2Button btn_phieukho;

        private Guna.UI2.WinForms.Guna2Panel PanelMenuNCC;
        private Guna.UI2.WinForms.Guna2Button btn_NCC;
        private Guna.UI2.WinForms.Guna2Button btn_themNCC;
    }
}
namespace SPORTSHOP
{
    partial class FormDonOnline
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();

            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblDanhSach = new System.Windows.Forms.Label();
            this.lblSoDon = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvDonOnline = new System.Windows.Forms.DataGridView();

            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlDetailHeader = new System.Windows.Forms.Panel();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();

            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaDonCaption = new System.Windows.Forms.Label();
            this.lblMaDon = new System.Windows.Forms.Label();
            this.lblKhachHangCaption = new System.Windows.Forms.Label();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.lblSDTCaption = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblDiaChiCaption = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblThanhToanCaption = new System.Windows.Forms.Label();
            this.lblThanhToan = new System.Windows.Forms.Label();
            this.lblNgayCaption = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();

            this.grpSanPham = new System.Windows.Forms.GroupBox();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();

            this.pnlTongKet = new System.Windows.Forms.Panel();
            this.lblTienHangCaption = new System.Windows.Forms.Label();
            this.lblTienHang = new System.Windows.Forms.Label();
            this.lblGiamCaption = new System.Windows.Forms.Label();
            this.lblGiam = new System.Windows.Forms.Label();
            this.lblShipCaption = new System.Windows.Forms.Label();
            this.lblShip = new System.Windows.Forms.Label();
            this.lblThanhTienCaption = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();

            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnXoaDon = new System.Windows.Forms.Button();
            this.btnInDon = new System.Windows.Forms.Button();
            this.btnRaDon = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonOnline)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlDetailHeader.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.grpSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlTongKet.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();

            // FORM
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(1380, 820);
            this.MinimumSize = new System.Drawing.Size(1150, 700);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn Online - SPORTSHOP";
            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            // HEADER
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(27, 42, 65);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 86;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(28, 14, 28, 10);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 23F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(27, 10);
            this.lblTitle.Text = "ĐƠN ONLINE";

            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(205, 216, 231);
            this.lblSubTitle.Location = new System.Drawing.Point(31, 53);
            this.lblSubTitle.Text = "Danh sách đơn hàng đã thanh toán đang chờ nhân viên xử lý";

            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);

            // LEFT
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Width = 560;
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(22, 18, 14, 18);

            this.lblDanhSach.AutoSize = true;
            this.lblDanhSach.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblDanhSach.ForeColor = System.Drawing.Color.FromArgb(35, 43, 54);
            this.lblDanhSach.Location = new System.Drawing.Point(22, 18);
            this.lblDanhSach.Text = "Đơn đang chờ xử lý";

            this.lblSoDon.AutoSize = true;
            this.lblSoDon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSoDon.ForeColor = System.Drawing.Color.FromArgb(110, 120, 135);
            this.lblSoDon.Location = new System.Drawing.Point(25, 50);
            this.lblSoDon.Text = "0 đơn đã thanh toán";

            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.FromArgb(70, 78, 90);
            this.txtTimKiem.Location = new System.Drawing.Point(25, 83);
            this.txtTimKiem.Size = new System.Drawing.Size(365, 31);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(232, 238, 247);
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(39, 76, 119);
            this.btnLamMoi.Location = new System.Drawing.Point(401, 83);
            this.btnLamMoi.Size = new System.Drawing.Size(112, 31);
            this.btnLamMoi.Text = "↻  Làm mới";
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.dgvDonOnline.AllowUserToAddRows = false;
            this.dgvDonOnline.AllowUserToDeleteRows = false;
            this.dgvDonOnline.AllowUserToResizeRows = false;
            this.dgvDonOnline.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.dgvDonOnline.BackgroundColor = System.Drawing.Color.White;
            this.dgvDonOnline.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDonOnline.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDonOnline.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDonOnline.ColumnHeadersHeight = 42;
            this.dgvDonOnline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDonOnline.EnableHeadersVisualStyles = false;
            this.dgvDonOnline.GridColor = System.Drawing.Color.FromArgb(232, 235, 240);
            this.dgvDonOnline.Location = new System.Drawing.Point(22, 128);
            this.dgvDonOnline.MultiSelect = false;
            this.dgvDonOnline.ReadOnly = true;
            this.dgvDonOnline.RowHeadersVisible = false;
            this.dgvDonOnline.RowTemplate.Height = 52;
            this.dgvDonOnline.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDonOnline.Size = new System.Drawing.Size(516, 630);
            this.dgvDonOnline.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvDonOnline.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvDonOnline.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(65, 74, 87);
            this.dgvDonOnline.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.dgvDonOnline.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvDonOnline.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(45, 52, 62);
            this.dgvDonOnline.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(225, 236, 250);
            this.dgvDonOnline.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(25, 55, 90);
            this.dgvDonOnline.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonOnline_CellClick);

            this.pnlLeft.Controls.Add(this.lblDanhSach);
            this.pnlLeft.Controls.Add(this.lblSoDon);
            this.pnlLeft.Controls.Add(this.txtTimKiem);
            this.pnlLeft.Controls.Add(this.btnLamMoi);
            this.pnlLeft.Controls.Add(this.dgvDonOnline);

            // RIGHT
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Padding = new System.Windows.Forms.Padding(14, 18, 22, 18);

            this.pnlDetailHeader.BackColor = System.Drawing.Color.FromArgb(44, 96, 157);
            this.pnlDetailHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetailHeader.Height = 70;

            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.White;
            this.lblDetailTitle.Location = new System.Drawing.Point(22, 17);
            this.lblDetailTitle.Text = "CHI TIẾT ĐƠN ONLINE";

            this.lblTrangThai.AutoSize = false;
            this.lblTrangThai.BackColor = System.Drawing.Color.FromArgb(218, 244, 226);
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(31, 111, 62);
            this.lblTrangThai.Location = new System.Drawing.Point(370, 17);
            this.lblTrangThai.Size = new System.Drawing.Size(170, 36);
            this.lblTrangThai.Text = "ĐÃ THANH TOÁN";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.pnlDetailHeader.Controls.Add(this.lblDetailTitle);
            this.pnlDetailHeader.Controls.Add(this.lblTrangThai);

            // INFO
            this.grpThongTin.BackColor = System.Drawing.Color.White;
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTin.Height = 154;
            this.grpThongTin.Text = "  Thông tin khách hàng  ";
            this.grpThongTin.ForeColor = System.Drawing.Color.FromArgb(55, 64, 78);
            this.grpThongTin.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);

            this.lblMaDonCaption.AutoSize = true;
            this.lblMaDonCaption.Location = new System.Drawing.Point(18, 31);
            this.lblMaDonCaption.Text = "Mã đơn:";
            this.lblMaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaDon.Location = new System.Drawing.Point(112, 31);
            this.lblMaDon.Size = new System.Drawing.Size(170, 22);
            this.lblMaDon.Text = "—";

            this.lblKhachHangCaption.AutoSize = true;
            this.lblKhachHangCaption.Location = new System.Drawing.Point(18, 62);
            this.lblKhachHangCaption.Text = "Khách hàng:";
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblKhachHang.Location = new System.Drawing.Point(112, 62);
            this.lblKhachHang.Size = new System.Drawing.Size(220, 22);
            this.lblKhachHang.Text = "—";

            this.lblSDTCaption.AutoSize = true;
            this.lblSDTCaption.Location = new System.Drawing.Point(360, 31);
            this.lblSDTCaption.Text = "Số điện thoại:";
            this.lblSDT.Location = new System.Drawing.Point(468, 31);
            this.lblSDT.Size = new System.Drawing.Size(180, 22);
            this.lblSDT.Text = "—";

            this.lblDiaChiCaption.AutoSize = true;
            this.lblDiaChiCaption.Location = new System.Drawing.Point(360, 62);
            this.lblDiaChiCaption.Text = "Địa chỉ:";
            this.lblDiaChi.Location = new System.Drawing.Point(425, 62);
            this.lblDiaChi.Size = new System.Drawing.Size(260, 22);
            this.lblDiaChi.Text = "—";
            this.lblDiaChi.AutoEllipsis = true;

            this.lblThanhToanCaption.AutoSize = true;
            this.lblThanhToanCaption.Location = new System.Drawing.Point(18, 93);
            this.lblThanhToanCaption.Text = "Thanh toán:";
            this.lblThanhToan.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblThanhToan.ForeColor = System.Drawing.Color.FromArgb(31, 111, 62);
            this.lblThanhToan.Location = new System.Drawing.Point(112, 93);
            this.lblThanhToan.Size = new System.Drawing.Size(220, 22);
            this.lblThanhToan.Text = "—";

            this.lblNgayCaption.AutoSize = true;
            this.lblNgayCaption.Location = new System.Drawing.Point(360, 93);
            this.lblNgayCaption.Text = "Ngày đặt:";
            this.lblNgay.Location = new System.Drawing.Point(425, 93);
            this.lblNgay.Size = new System.Drawing.Size(220, 22);
            this.lblNgay.Text = "—";

            this.grpThongTin.Controls.Add(this.lblMaDonCaption);
            this.grpThongTin.Controls.Add(this.lblMaDon);
            this.grpThongTin.Controls.Add(this.lblKhachHangCaption);
            this.grpThongTin.Controls.Add(this.lblKhachHang);
            this.grpThongTin.Controls.Add(this.lblSDTCaption);
            this.grpThongTin.Controls.Add(this.lblSDT);
            this.grpThongTin.Controls.Add(this.lblDiaChiCaption);
            this.grpThongTin.Controls.Add(this.lblDiaChi);
            this.grpThongTin.Controls.Add(this.lblThanhToanCaption);
            this.grpThongTin.Controls.Add(this.lblThanhToan);
            this.grpThongTin.Controls.Add(this.lblNgayCaption);
            this.grpThongTin.Controls.Add(this.lblNgay);

            // PRODUCTS
            this.grpSanPham.BackColor = System.Drawing.Color.White;
            this.grpSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSanPham.Text = "  Sản phẩm trong đơn  ";
            this.grpSanPham.ForeColor = System.Drawing.Color.FromArgb(55, 64, 78);
            this.grpSanPham.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);

            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AllowUserToResizeRows = false;
            this.dgvChiTiet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTiet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTiet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvChiTiet.ColumnHeadersHeight = 38;
            this.dgvChiTiet.EnableHeadersVisualStyles = false;
            this.dgvChiTiet.GridColor = System.Drawing.Color.FromArgb(232, 235, 240);
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowTemplate.Height = 44;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(65, 74, 87);
            this.dgvChiTiet.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvChiTiet.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(235, 241, 249);
            this.dgvChiTiet.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(40, 50, 65);

            this.grpSanPham.Controls.Add(this.dgvChiTiet);

            // SUMMARY
            this.pnlTongKet.BackColor = System.Drawing.Color.White;
            this.pnlTongKet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTongKet.Height = 126;
            this.pnlTongKet.Padding = new System.Windows.Forms.Padding(18, 9, 18, 9);

            this.lblTienHangCaption.AutoSize = true;
            this.lblTienHangCaption.Location = new System.Drawing.Point(18, 10);
            this.lblTienHangCaption.Text = "Tiền hàng:";

            this.lblTienHang.AutoSize = true;
            this.lblTienHang.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTienHang.Location = new System.Drawing.Point(150, 10);
            this.lblTienHang.Text = "0 đ";

            this.lblGiamCaption.AutoSize = true;
            this.lblGiamCaption.Location = new System.Drawing.Point(18, 37);
            this.lblGiamCaption.Text = "Giảm giá:";

            this.lblGiam.AutoSize = true;
            this.lblGiam.ForeColor = System.Drawing.Color.FromArgb(190, 55, 55);
            this.lblGiam.Location = new System.Drawing.Point(150, 37);
            this.lblGiam.Text = "0 đ";

            this.lblShipCaption.AutoSize = true;
            this.lblShipCaption.Location = new System.Drawing.Point(18, 64);
            this.lblShipCaption.Text = "Phí vận chuyển:";

            this.lblShip.AutoSize = true;
            this.lblShip.Location = new System.Drawing.Point(150, 64);
            this.lblShip.Text = "0 đ";

            this.lblThanhTienCaption.AutoSize = true;
            this.lblThanhTienCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblThanhTienCaption.ForeColor = System.Drawing.Color.FromArgb(27, 42, 65);
            this.lblThanhTienCaption.Location = new System.Drawing.Point(370, 46);
            this.lblThanhTienCaption.Text = "THÀNH TIỀN:";

            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblThanhTien.ForeColor = System.Drawing.Color.FromArgb(207, 49, 49);
            this.lblThanhTien.Location = new System.Drawing.Point(485, 42);
            this.lblThanhTien.Text = "0 đ";

            this.pnlTongKet.Controls.Add(this.lblTienHangCaption);
            this.pnlTongKet.Controls.Add(this.lblTienHang);
            this.pnlTongKet.Controls.Add(this.lblGiamCaption);
            this.pnlTongKet.Controls.Add(this.lblGiam);
            this.pnlTongKet.Controls.Add(this.lblShipCaption);
            this.pnlTongKet.Controls.Add(this.lblShip);
            this.pnlTongKet.Controls.Add(this.lblThanhTienCaption);
            this.pnlTongKet.Controls.Add(this.lblThanhTien);

            // ACTIONS
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Height = 72;
            this.pnlActions.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);

            this.btnXoaDon.BackColor = System.Drawing.Color.FromArgb(198, 52, 52);
            this.btnXoaDon.FlatAppearance.BorderSize = 0;
            this.btnXoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoaDon.ForeColor = System.Drawing.Color.White;
            this.btnXoaDon.Location = new System.Drawing.Point(0, 10);
            this.btnXoaDon.Size = new System.Drawing.Size(145, 48);
            this.btnXoaDon.Text = "XÓA ĐƠN";
            this.btnXoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaDon.Click += new System.EventHandler(this.btnXoaDon_Click);

            this.btnInDon.BackColor = System.Drawing.Color.FromArgb(77, 126, 211);
            this.btnInDon.FlatAppearance.BorderSize = 0;
            this.btnInDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInDon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnInDon.ForeColor = System.Drawing.Color.White;
            this.btnInDon.Location = new System.Drawing.Point(160, 10);
            this.btnInDon.Size = new System.Drawing.Size(145, 48);
            this.btnInDon.Text = "IN ĐƠN";
            this.btnInDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInDon.Click += new System.EventHandler(this.btnInDon_Click);

            this.btnRaDon.BackColor = System.Drawing.Color.FromArgb(27, 142, 62);
            this.btnRaDon.FlatAppearance.BorderSize = 0;
            this.btnRaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRaDon.ForeColor = System.Drawing.Color.White;
            this.btnRaDon.Location = new System.Drawing.Point(320, 10);
            this.btnRaDon.Size = new System.Drawing.Size(145, 48);
            this.btnRaDon.Text = "RA ĐƠN";
            this.btnRaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRaDon.Click += new System.EventHandler(this.btnRaDon_Click);

            this.pnlActions.Controls.Add(this.btnXoaDon);
            this.pnlActions.Controls.Add(this.btnInDon);
            this.pnlActions.Controls.Add(this.btnRaDon);

            // RIGHT ORDER
            this.pnlRight.Controls.Add(this.grpSanPham);
            this.pnlRight.Controls.Add(this.pnlTongKet);
            this.pnlRight.Controls.Add(this.pnlActions);
            this.pnlRight.Controls.Add(this.grpThongTin);
            this.pnlRight.Controls.Add(this.pnlDetailHeader);

            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonOnline)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlDetailHeader.ResumeLayout(false);
            this.pnlDetailHeader.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpSanPham.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlTongKet.ResumeLayout(false);
            this.pnlTongKet.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblDanhSach;
        private System.Windows.Forms.Label lblSoDon;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvDonOnline;

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlDetailHeader;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblTrangThai;

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaDonCaption;
        private System.Windows.Forms.Label lblMaDon;
        private System.Windows.Forms.Label lblKhachHangCaption;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.Label lblSDTCaption;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblDiaChiCaption;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblThanhToanCaption;
        private System.Windows.Forms.Label lblThanhToan;
        private System.Windows.Forms.Label lblNgayCaption;
        private System.Windows.Forms.Label lblNgay;

        private System.Windows.Forms.GroupBox grpSanPham;
        private System.Windows.Forms.DataGridView dgvChiTiet;

        private System.Windows.Forms.Panel pnlTongKet;
        private System.Windows.Forms.Label lblTienHangCaption;
        private System.Windows.Forms.Label lblTienHang;
        private System.Windows.Forms.Label lblGiamCaption;
        private System.Windows.Forms.Label lblGiam;
        private System.Windows.Forms.Label lblShipCaption;
        private System.Windows.Forms.Label lblShip;
        private System.Windows.Forms.Label lblThanhTienCaption;
        private System.Windows.Forms.Label lblThanhTien;

        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnXoaDon;
        private System.Windows.Forms.Button btnInDon;
        private System.Windows.Forms.Button btnRaDon;
    }
}

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.pnlDetailHeader = new System.Windows.Forms.Panel();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonOnline)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.grpSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlTongKet.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.pnlDetailHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(28, 14, 28, 10);
            this.pnlHeader.Size = new System.Drawing.Size(1380, 86);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 23F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(27, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 52);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐƠN ONLINE";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(216)))), ((int)(((byte)(231)))));
            this.lblSubTitle.Location = new System.Drawing.Point(31, 53);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(430, 21);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Danh sách đơn hàng đã thanh toán đang chờ nhân viên xử lý";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.lblDanhSach);
            this.pnlLeft.Controls.Add(this.lblSoDon);
            this.pnlLeft.Controls.Add(this.txtTimKiem);
            this.pnlLeft.Controls.Add(this.btnLamMoi);
            this.pnlLeft.Controls.Add(this.dgvDonOnline);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 86);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(22, 18, 14, 18);
            this.pnlLeft.Size = new System.Drawing.Size(560, 734);
            this.pnlLeft.TabIndex = 1;
            // 
            // lblDanhSach
            // 
            this.lblDanhSach.AutoSize = true;
            this.lblDanhSach.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblDanhSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.lblDanhSach.Location = new System.Drawing.Point(22, 18);
            this.lblDanhSach.Name = "lblDanhSach";
            this.lblDanhSach.Size = new System.Drawing.Size(257, 37);
            this.lblDanhSach.TabIndex = 0;
            this.lblDanhSach.Text = "Đơn đang chờ xử lý";
            // 
            // lblSoDon
            // 
            this.lblSoDon.AutoSize = true;
            this.lblSoDon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSoDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblSoDon.Location = new System.Drawing.Point(25, 50);
            this.lblSoDon.Name = "lblSoDon";
            this.lblSoDon.Size = new System.Drawing.Size(151, 21);
            this.lblSoDon.TabIndex = 1;
            this.lblSoDon.Text = "0 đơn đã thanh toán";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.txtTimKiem.Location = new System.Drawing.Point(25, 83);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(365, 31);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(238)))), ((int)(((byte)(247)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.btnLamMoi.Location = new System.Drawing.Point(401, 83);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(112, 31);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "↻  Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // dgvDonOnline
            // 
            this.dgvDonOnline.AllowUserToAddRows = false;
            this.dgvDonOnline.AllowUserToDeleteRows = false;
            this.dgvDonOnline.AllowUserToResizeRows = false;
            this.dgvDonOnline.BackgroundColor = System.Drawing.Color.White;
            this.dgvDonOnline.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDonOnline.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDonOnline.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(74)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDonOnline.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDonOnline.ColumnHeadersHeight = 42;
            this.dgvDonOnline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(236)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(55)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDonOnline.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDonOnline.EnableHeadersVisualStyles = false;
            this.dgvDonOnline.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.dgvDonOnline.Location = new System.Drawing.Point(22, 128);
            this.dgvDonOnline.MultiSelect = false;
            this.dgvDonOnline.Name = "dgvDonOnline";
            this.dgvDonOnline.ReadOnly = true;
            this.dgvDonOnline.RowHeadersVisible = false;
            this.dgvDonOnline.RowHeadersWidth = 51;
            this.dgvDonOnline.RowTemplate.Height = 52;
            this.dgvDonOnline.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDonOnline.Size = new System.Drawing.Size(516, 630);
            this.dgvDonOnline.TabIndex = 4;
            this.dgvDonOnline.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonOnline_CellClick);
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlRight.Controls.Add(this.grpSanPham);
            this.pnlRight.Controls.Add(this.pnlTongKet);
            this.pnlRight.Controls.Add(this.pnlActions);
            this.pnlRight.Controls.Add(this.grpThongTin);
            this.pnlRight.Controls.Add(this.pnlDetailHeader);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(560, 86);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(14, 18, 22, 18);
            this.pnlRight.Size = new System.Drawing.Size(820, 734);
            this.pnlRight.TabIndex = 0;
            // 
            // grpSanPham
            // 
            this.grpSanPham.BackColor = System.Drawing.Color.White;
            this.grpSanPham.Controls.Add(this.dgvChiTiet);
            this.grpSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSanPham.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.grpSanPham.Location = new System.Drawing.Point(14, 242);
            this.grpSanPham.Name = "grpSanPham";
            this.grpSanPham.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.grpSanPham.Size = new System.Drawing.Size(784, 276);
            this.grpSanPham.TabIndex = 0;
            this.grpSanPham.TabStop = false;
            this.grpSanPham.Text = "  Sản phẩm trong đơn  ";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AllowUserToResizeRows = false;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTiet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTiet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(74)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChiTiet.ColumnHeadersHeight = 38;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(241)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.EnableHeadersVisualStyles = false;
            this.dgvChiTiet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.dgvChiTiet.Location = new System.Drawing.Point(15, 33);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.RowTemplate.Height = 44;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(754, 233);
            this.dgvChiTiet.TabIndex = 0;
            // 
            // pnlTongKet
            // 
            this.pnlTongKet.BackColor = System.Drawing.Color.White;
            this.pnlTongKet.Controls.Add(this.lblTienHangCaption);
            this.pnlTongKet.Controls.Add(this.lblTienHang);
            this.pnlTongKet.Controls.Add(this.lblGiamCaption);
            this.pnlTongKet.Controls.Add(this.lblGiam);
            this.pnlTongKet.Controls.Add(this.lblShipCaption);
            this.pnlTongKet.Controls.Add(this.lblShip);
            this.pnlTongKet.Controls.Add(this.lblThanhTienCaption);
            this.pnlTongKet.Controls.Add(this.lblThanhTien);
            this.pnlTongKet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTongKet.Location = new System.Drawing.Point(14, 518);
            this.pnlTongKet.Name = "pnlTongKet";
            this.pnlTongKet.Padding = new System.Windows.Forms.Padding(18, 9, 18, 9);
            this.pnlTongKet.Size = new System.Drawing.Size(784, 126);
            this.pnlTongKet.TabIndex = 1;
            // 
            // lblTienHangCaption
            // 
            this.lblTienHangCaption.AutoSize = true;
            this.lblTienHangCaption.Location = new System.Drawing.Point(18, 10);
            this.lblTienHangCaption.Name = "lblTienHangCaption";
            this.lblTienHangCaption.Size = new System.Drawing.Size(90, 23);
            this.lblTienHangCaption.TabIndex = 0;
            this.lblTienHangCaption.Text = "Tiền hàng:";
            // 
            // lblTienHang
            // 
            this.lblTienHang.AutoSize = true;
            this.lblTienHang.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTienHang.Location = new System.Drawing.Point(150, 10);
            this.lblTienHang.Name = "lblTienHang";
            this.lblTienHang.Size = new System.Drawing.Size(34, 23);
            this.lblTienHang.TabIndex = 1;
            this.lblTienHang.Text = "0 đ";
            // 
            // lblGiamCaption
            // 
            this.lblGiamCaption.AutoSize = true;
            this.lblGiamCaption.Location = new System.Drawing.Point(18, 37);
            this.lblGiamCaption.Name = "lblGiamCaption";
            this.lblGiamCaption.Size = new System.Drawing.Size(82, 23);
            this.lblGiamCaption.TabIndex = 2;
            this.lblGiamCaption.Text = "Giảm giá:";
            // 
            // lblGiam
            // 
            this.lblGiam.AutoSize = true;
            this.lblGiam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.lblGiam.Location = new System.Drawing.Point(150, 37);
            this.lblGiam.Name = "lblGiam";
            this.lblGiam.Size = new System.Drawing.Size(34, 23);
            this.lblGiam.TabIndex = 3;
            this.lblGiam.Text = "0 đ";
            // 
            // lblShipCaption
            // 
            this.lblShipCaption.AutoSize = true;
            this.lblShipCaption.Location = new System.Drawing.Point(18, 64);
            this.lblShipCaption.Name = "lblShipCaption";
            this.lblShipCaption.Size = new System.Drawing.Size(130, 23);
            this.lblShipCaption.TabIndex = 4;
            this.lblShipCaption.Text = "Phí vận chuyển:";
            // 
            // lblShip
            // 
            this.lblShip.AutoSize = true;
            this.lblShip.Location = new System.Drawing.Point(150, 64);
            this.lblShip.Name = "lblShip";
            this.lblShip.Size = new System.Drawing.Size(34, 23);
            this.lblShip.TabIndex = 5;
            this.lblShip.Text = "0 đ";
            // 
            // lblThanhTienCaption
            // 
            this.lblThanhTienCaption.AutoSize = true;
            this.lblThanhTienCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblThanhTienCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.lblThanhTienCaption.Location = new System.Drawing.Point(370, 46);
            this.lblThanhTienCaption.Name = "lblThanhTienCaption";
            this.lblThanhTienCaption.Size = new System.Drawing.Size(134, 28);
            this.lblThanhTienCaption.TabIndex = 6;
            this.lblThanhTienCaption.Text = "THÀNH TIỀN:";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblThanhTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.lblThanhTien.Location = new System.Drawing.Point(502, 42);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(55, 37);
            this.lblThanhTien.TabIndex = 7;
            this.lblThanhTien.Text = "0 đ";
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlActions.Controls.Add(this.btnXoaDon);
            this.pnlActions.Controls.Add(this.btnInDon);
            this.pnlActions.Controls.Add(this.btnRaDon);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(14, 644);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlActions.Size = new System.Drawing.Size(784, 72);
            this.pnlActions.TabIndex = 2;
            // 
            // btnXoaDon
            // 
            this.btnXoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnXoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaDon.FlatAppearance.BorderSize = 0;
            this.btnXoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoaDon.ForeColor = System.Drawing.Color.White;
            this.btnXoaDon.Location = new System.Drawing.Point(0, 10);
            this.btnXoaDon.Name = "btnXoaDon";
            this.btnXoaDon.Size = new System.Drawing.Size(145, 48);
            this.btnXoaDon.TabIndex = 0;
            this.btnXoaDon.Text = "XÓA ĐƠN";
            this.btnXoaDon.UseVisualStyleBackColor = false;
            this.btnXoaDon.Click += new System.EventHandler(this.btnXoaDon_Click);
            // 
            // btnInDon
            // 
            this.btnInDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(126)))), ((int)(((byte)(211)))));
            this.btnInDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInDon.FlatAppearance.BorderSize = 0;
            this.btnInDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInDon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnInDon.ForeColor = System.Drawing.Color.White;
            this.btnInDon.Location = new System.Drawing.Point(160, 10);
            this.btnInDon.Name = "btnInDon";
            this.btnInDon.Size = new System.Drawing.Size(145, 48);
            this.btnInDon.TabIndex = 1;
            this.btnInDon.Text = "IN ĐƠN";
            this.btnInDon.UseVisualStyleBackColor = false;
            this.btnInDon.Click += new System.EventHandler(this.btnInDon_Click);
            // 
            // btnRaDon
            // 
            this.btnRaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(142)))), ((int)(((byte)(62)))));
            this.btnRaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRaDon.FlatAppearance.BorderSize = 0;
            this.btnRaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRaDon.ForeColor = System.Drawing.Color.White;
            this.btnRaDon.Location = new System.Drawing.Point(320, 10);
            this.btnRaDon.Name = "btnRaDon";
            this.btnRaDon.Size = new System.Drawing.Size(145, 48);
            this.btnRaDon.TabIndex = 2;
            this.btnRaDon.Text = "RA ĐƠN";
            this.btnRaDon.UseVisualStyleBackColor = false;
            this.btnRaDon.Click += new System.EventHandler(this.btnRaDon_Click);
            // 
            // grpThongTin
            // 
            this.grpThongTin.BackColor = System.Drawing.Color.White;
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
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.grpThongTin.Location = new System.Drawing.Point(14, 88);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.grpThongTin.Size = new System.Drawing.Size(784, 154);
            this.grpThongTin.TabIndex = 3;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "  Thông tin khách hàng  ";
            // 
            // lblMaDonCaption
            // 
            this.lblMaDonCaption.AutoSize = true;
            this.lblMaDonCaption.Location = new System.Drawing.Point(18, 31);
            this.lblMaDonCaption.Name = "lblMaDonCaption";
            this.lblMaDonCaption.Size = new System.Drawing.Size(73, 23);
            this.lblMaDonCaption.TabIndex = 0;
            this.lblMaDonCaption.Text = "Mã đơn:";
            // 
            // lblMaDon
            // 
            this.lblMaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaDon.Location = new System.Drawing.Point(112, 31);
            this.lblMaDon.Name = "lblMaDon";
            this.lblMaDon.Size = new System.Drawing.Size(170, 22);
            this.lblMaDon.TabIndex = 1;
            this.lblMaDon.Text = "—";
            // 
            // lblKhachHangCaption
            // 
            this.lblKhachHangCaption.AutoSize = true;
            this.lblKhachHangCaption.Location = new System.Drawing.Point(18, 62);
            this.lblKhachHangCaption.Name = "lblKhachHangCaption";
            this.lblKhachHangCaption.Size = new System.Drawing.Size(105, 23);
            this.lblKhachHangCaption.TabIndex = 2;
            this.lblKhachHangCaption.Text = "Khách hàng:";
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblKhachHang.Location = new System.Drawing.Point(112, 62);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(220, 22);
            this.lblKhachHang.TabIndex = 3;
            this.lblKhachHang.Text = "—";
            // 
            // lblSDTCaption
            // 
            this.lblSDTCaption.AutoSize = true;
            this.lblSDTCaption.Location = new System.Drawing.Point(360, 31);
            this.lblSDTCaption.Name = "lblSDTCaption";
            this.lblSDTCaption.Size = new System.Drawing.Size(115, 23);
            this.lblSDTCaption.TabIndex = 4;
            this.lblSDTCaption.Text = "Số điện thoại:";
            // 
            // lblSDT
            // 
            this.lblSDT.Location = new System.Drawing.Point(468, 31);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(180, 22);
            this.lblSDT.TabIndex = 5;
            this.lblSDT.Text = "—";
            // 
            // lblDiaChiCaption
            // 
            this.lblDiaChiCaption.AutoSize = true;
            this.lblDiaChiCaption.Location = new System.Drawing.Point(360, 62);
            this.lblDiaChiCaption.Name = "lblDiaChiCaption";
            this.lblDiaChiCaption.Size = new System.Drawing.Size(66, 23);
            this.lblDiaChiCaption.TabIndex = 6;
            this.lblDiaChiCaption.Text = "Địa chỉ:";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoEllipsis = true;
            this.lblDiaChi.Location = new System.Drawing.Point(425, 62);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(260, 22);
            this.lblDiaChi.TabIndex = 7;
            this.lblDiaChi.Text = "—";
            // 
            // lblThanhToanCaption
            // 
            this.lblThanhToanCaption.AutoSize = true;
            this.lblThanhToanCaption.Location = new System.Drawing.Point(18, 93);
            this.lblThanhToanCaption.Name = "lblThanhToanCaption";
            this.lblThanhToanCaption.Size = new System.Drawing.Size(102, 23);
            this.lblThanhToanCaption.TabIndex = 8;
            this.lblThanhToanCaption.Text = "Thanh toán:";
            // 
            // lblThanhToan
            // 
            this.lblThanhToan.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(111)))), ((int)(((byte)(62)))));
            this.lblThanhToan.Location = new System.Drawing.Point(112, 93);
            this.lblThanhToan.Name = "lblThanhToan";
            this.lblThanhToan.Size = new System.Drawing.Size(220, 22);
            this.lblThanhToan.TabIndex = 9;
            this.lblThanhToan.Text = "—";
            // 
            // lblNgayCaption
            // 
            this.lblNgayCaption.AutoSize = true;
            this.lblNgayCaption.Location = new System.Drawing.Point(360, 93);
            this.lblNgayCaption.Name = "lblNgayCaption";
            this.lblNgayCaption.Size = new System.Drawing.Size(84, 23);
            this.lblNgayCaption.TabIndex = 10;
            this.lblNgayCaption.Text = "Ngày đặt:";
            // 
            // lblNgay
            // 
            this.lblNgay.Location = new System.Drawing.Point(425, 93);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(220, 22);
            this.lblNgay.TabIndex = 11;
            this.lblNgay.Text = "—";
            // 
            // pnlDetailHeader
            // 
            this.pnlDetailHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(96)))), ((int)(((byte)(157)))));
            this.pnlDetailHeader.Controls.Add(this.lblDetailTitle);
            this.pnlDetailHeader.Controls.Add(this.lblTrangThai);
            this.pnlDetailHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetailHeader.Location = new System.Drawing.Point(14, 18);
            this.pnlDetailHeader.Name = "pnlDetailHeader";
            this.pnlDetailHeader.Size = new System.Drawing.Size(784, 70);
            this.pnlDetailHeader.TabIndex = 4;
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.White;
            this.lblDetailTitle.Location = new System.Drawing.Point(22, 17);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(311, 40);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "CHI TIẾT ĐƠN ONLINE";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(244)))), ((int)(((byte)(226)))));
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(111)))), ((int)(((byte)(62)))));
            this.lblTrangThai.Location = new System.Drawing.Point(370, 17);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(170, 36);
            this.lblTrangThai.TabIndex = 1;
            this.lblTrangThai.Text = "ĐÃ THANH TOÁN";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormDonOnline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1380, 820);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1150, 700);
            this.Name = "FormDonOnline";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn Online - SPORTSHOP";
            this.Load += new System.EventHandler(this.FormDonOnline_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonOnline)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.grpSanPham.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlTongKet.ResumeLayout(false);
            this.pnlTongKet.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.pnlDetailHeader.ResumeLayout(false);
            this.pnlDetailHeader.PerformLayout();
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

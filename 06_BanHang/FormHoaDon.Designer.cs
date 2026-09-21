using System;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    partial class FormHoaDon
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop, pnlReceipt, pnlHeadInfo, pnlSummary, pnlFooter;
        private System.Windows.Forms.Label lblLogo, lblStore, lblTitle, lblSubTitle;
        private System.Windows.Forms.Label lblMaHD, lblNgay, lblKhachHang, lblSDT, lblEmail, lblNhanVien, lblMaDon;
        private System.Windows.Forms.Label lblPhuongThuc, lblTrangThai, lblTongSoLuong;
        private System.Windows.Forms.Label lblTienHang, lblTongTien, lblThanhToan;
        private System.Windows.Forms.Label lblLine1, lblLine2, lblLine3;
        private System.Windows.Forms.Button btnInHoaDon, btnDong;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT, colSanPham, colBienThe, colPhanLoai, colSL, colDonGia, colThanhTien;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblStore = new System.Windows.Forms.Label();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlReceipt = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.pnlHeadInfo = new System.Windows.Forms.Panel();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.lblMaDon = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBienThe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhanLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblTongSoLuong = new System.Windows.Forms.Label();
            this.lblPhuongThuc = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTienHang = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblThanhToan = new System.Windows.Forms.Label();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.lblLine2 = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblLine3 = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlReceipt.SuspendLayout();
            this.pnlHeadInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.pnlSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(35)))), ((int)(((byte)(58)))));
            this.pnlTop.Controls.Add(this.lblLogo);
            this.pnlTop.Controls.Add(this.lblStore);
            this.pnlTop.Controls.Add(this.btnInHoaDon);
            this.pnlTop.Controls.Add(this.btnDong);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1120, 81);
            this.pnlTop.TabIndex = 1;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(29, 19);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(214, 46);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "SPORTSHOP";
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(210)))), ((int)(((byte)(226)))));
            this.lblStore.Location = new System.Drawing.Point(203, 27);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(290, 20);
            this.lblStore.TabIndex = 1;
            this.lblStore.Text = "SPORTSWEAR • FOOTBALL • ACCESSORIES";
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(120)))), ((int)(((byte)(220)))));
            this.btnInHoaDon.FlatAppearance.BorderSize = 0;
            this.btnInHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInHoaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnInHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnInHoaDon.Location = new System.Drawing.Point(817, 21);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(126, 38);
            this.btnInHoaDon.TabIndex = 2;
            this.btnInHoaDon.Text = "In hóa đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = false;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnDong.Location = new System.Drawing.Point(960, 21);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 38);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // pnlReceipt
            // 
            this.pnlReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReceipt.BackColor = System.Drawing.Color.White;
            this.pnlReceipt.Controls.Add(this.lblTitle);
            this.pnlReceipt.Controls.Add(this.lblSubTitle);
            this.pnlReceipt.Controls.Add(this.pnlHeadInfo);
            this.pnlReceipt.Controls.Add(this.lblKhachHang);
            this.pnlReceipt.Controls.Add(this.lblSDT);
            this.pnlReceipt.Controls.Add(this.lblEmail);
            this.pnlReceipt.Controls.Add(this.dgvSanPham);
            this.pnlReceipt.Controls.Add(this.pnlSummary);
            this.pnlReceipt.Controls.Add(this.lblThanhToan);
            this.pnlReceipt.Controls.Add(this.lblLine1);
            this.pnlReceipt.Controls.Add(this.lblLine2);
            this.pnlReceipt.Location = new System.Drawing.Point(63, 98);
            this.pnlReceipt.Name = "pnlReceipt";
            this.pnlReceipt.Padding = new System.Windows.Forms.Padding(40, 27, 40, 21);
            this.pnlReceipt.Size = new System.Drawing.Size(994, 672);
            this.pnlReceipt.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(35)))), ((int)(((byte)(58)))));
            this.lblTitle.Location = new System.Drawing.Point(40, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(365, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HÓA ĐƠN BÁN HÀNG";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblSubTitle.Location = new System.Drawing.Point(43, 64);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(327, 20);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Cảm ơn quý khách đã mua hàng tại SPORTSHOP";
            // 
            // pnlHeadInfo
            // 
            this.pnlHeadInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.pnlHeadInfo.Controls.Add(this.lblMaHD);
            this.pnlHeadInfo.Controls.Add(this.lblNgay);
            this.pnlHeadInfo.Controls.Add(this.lblMaDon);
            this.pnlHeadInfo.Controls.Add(this.lblNhanVien);
            this.pnlHeadInfo.Location = new System.Drawing.Point(40, 87);
            this.pnlHeadInfo.Name = "pnlHeadInfo";
            this.pnlHeadInfo.Size = new System.Drawing.Size(914, 98);
            this.pnlHeadInfo.TabIndex = 2;
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMaHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(80)))));
            this.lblMaHD.Location = new System.Drawing.Point(23, 16);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(119, 20);
            this.lblMaHD.TabIndex = 0;
            this.lblMaHD.Text = "Mã hóa đơn:  —";
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(80)))));
            this.lblNgay.Location = new System.Drawing.Point(23, 46);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(95, 20);
            this.lblNgay.TabIndex = 1;
            this.lblNgay.Text = "Ngày lập:  —";
            // 
            // lblMaDon
            // 
            this.lblMaDon.AutoSize = true;
            this.lblMaDon.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(80)))));
            this.lblMaDon.Location = new System.Drawing.Point(469, 16);
            this.lblMaDon.Name = "lblMaDon";
            this.lblMaDon.Size = new System.Drawing.Size(89, 20);
            this.lblMaDon.TabIndex = 2;
            this.lblMaDon.Text = "Mã đơn:  —";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(80)))));
            this.lblNhanVien.Location = new System.Drawing.Point(469, 46);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(101, 20);
            this.lblNhanVien.TabIndex = 3;
            this.lblNhanVien.Text = "Nhân viên:  —";
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblKhachHang.Location = new System.Drawing.Point(40, 198);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(117, 20);
            this.lblKhachHang.TabIndex = 3;
            this.lblKhachHang.Text = "Khách hàng:  —";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(343, 198);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(52, 16);
            this.lblSDT.TabIndex = 4;
            this.lblSDT.Text = "SĐT:  —";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(571, 198);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(59, 16);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email:  —";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvSanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(52)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSanPham.ColumnHeadersHeight = 38;
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colSanPham,
            this.colBienThe,
            this.colPhanLoai,
            this.colSL,
            this.colDonGia,
            this.colThanhTien});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(52)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSanPham.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSanPham.EnableHeadersVisualStyles = false;
            this.dgvSanPham.Location = new System.Drawing.Point(40, 229);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersVisible = false;
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(914, 277);
            this.dgvSanPham.TabIndex = 6;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 6;
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 42;
            // 
            // colSanPham
            // 
            this.colSanPham.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSanPham.FillWeight = 170F;
            this.colSanPham.HeaderText = "Sản phẩm";
            this.colSanPham.MinimumWidth = 6;
            this.colSanPham.Name = "colSanPham";
            this.colSanPham.ReadOnly = true;
            // 
            // colBienThe
            // 
            this.colBienThe.HeaderText = "Biến thể";
            this.colBienThe.MinimumWidth = 6;
            this.colBienThe.Name = "colBienThe";
            this.colBienThe.ReadOnly = true;
            this.colBienThe.Width = 82;
            // 
            // colPhanLoai
            // 
            this.colPhanLoai.HeaderText = "Size / Màu";
            this.colPhanLoai.MinimumWidth = 6;
            this.colPhanLoai.Name = "colPhanLoai";
            this.colPhanLoai.ReadOnly = true;
            this.colPhanLoai.Width = 110;
            // 
            // colSL
            // 
            this.colSL.HeaderText = "SL";
            this.colSL.MinimumWidth = 6;
            this.colSL.Name = "colSL";
            this.colSL.ReadOnly = true;
            this.colSL.Width = 48;
            // 
            // colDonGia
            // 
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.MinimumWidth = 6;
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // 
            // colThanhTien
            // 
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.MinimumWidth = 6;
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            this.colThanhTien.Width = 115;
            // 
            // pnlSummary
            // 
            this.pnlSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.pnlSummary.Controls.Add(this.lblTongSoLuong);
            this.pnlSummary.Controls.Add(this.lblPhuongThuc);
            this.pnlSummary.Controls.Add(this.lblTrangThai);
            this.pnlSummary.Controls.Add(this.lblTienHang);
            this.pnlSummary.Controls.Add(this.lblTongTien);
            this.pnlSummary.Location = new System.Drawing.Point(40, 523);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(914, 91);
            this.pnlSummary.TabIndex = 7;
            // 
            // lblTongSoLuong
            // 
            this.lblTongSoLuong.AutoSize = true;
            this.lblTongSoLuong.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTongSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(80)))));
            this.lblTongSoLuong.Location = new System.Drawing.Point(21, 13);
            this.lblTongSoLuong.Name = "lblTongSoLuong";
            this.lblTongSoLuong.Size = new System.Drawing.Size(188, 20);
            this.lblTongSoLuong.TabIndex = 0;
            this.lblTongSoLuong.Text = "Tổng số lượng: 0 sản phẩm";
            // 
            // lblPhuongThuc
            // 
            this.lblPhuongThuc.AutoSize = true;
            this.lblPhuongThuc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPhuongThuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(80)))));
            this.lblPhuongThuc.Location = new System.Drawing.Point(21, 45);
            this.lblPhuongThuc.Name = "lblPhuongThuc";
            this.lblPhuongThuc.Size = new System.Drawing.Size(109, 20);
            this.lblPhuongThuc.TabIndex = 1;
            this.lblPhuongThuc.Text = "Thanh toán:  —";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(80)))));
            this.lblTrangThai.Location = new System.Drawing.Point(720, 13);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(91, 20);
            this.lblTrangThai.TabIndex = 2;
            this.lblTrangThai.Text = "Hoàn thành";
            // 
            // lblTienHang
            // 
            this.lblTienHang.AutoSize = true;
            this.lblTienHang.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTienHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(80)))));
            this.lblTienHang.Location = new System.Drawing.Point(503, 45);
            this.lblTienHang.Name = "lblTienHang";
            this.lblTienHang.Size = new System.Drawing.Size(102, 20);
            this.lblTienHang.TabIndex = 3;
            this.lblTienHang.Text = "Tiền hàng: 0 đ";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(44)))), ((int)(((byte)(54)))));
            this.lblTongTien.Location = new System.Drawing.Point(697, 41);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(51, 35);
            this.lblTongTien.TabIndex = 4;
            this.lblTongTien.Text = "0 đ";
            // 
            // lblThanhToan
            // 
            this.lblThanhToan.AutoSize = true;
            this.lblThanhToan.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(145)))), ((int)(((byte)(78)))));
            this.lblThanhToan.Location = new System.Drawing.Point(40, 631);
            this.lblThanhToan.Name = "lblThanhToan";
            this.lblThanhToan.Size = new System.Drawing.Size(130, 20);
            this.lblThanhToan.TabIndex = 8;
            this.lblThanhToan.Text = "ĐÃ THANH TOÁN";
            // 
            // lblLine1
            // 
            this.lblLine1.AutoSize = true;
            this.lblLine1.ForeColor = System.Drawing.Color.LightGray;
            this.lblLine1.Location = new System.Drawing.Point(286, 631);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(247, 16);
            this.lblLine1.TabIndex = 9;
            this.lblLine1.Text = "------------------------------------------------------------";
            // 
            // lblLine2
            // 
            this.lblLine2.AutoSize = true;
            this.lblLine2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.lblLine2.Location = new System.Drawing.Point(40, 654);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(239, 20);
            this.lblLine2.TabIndex = 10;
            this.lblLine2.Text = "SPORTSHOP • Cảm ơn quý khách!";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Location = new System.Drawing.Point(0, 0);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(200, 100);
            this.pnlFooter.TabIndex = 0;
            // 
            // lblLine3
            // 
            this.lblLine3.Location = new System.Drawing.Point(0, 0);
            this.lblLine3.Name = "lblLine3";
            this.lblLine3.Size = new System.Drawing.Size(100, 23);
            this.lblLine3.TabIndex = 0;
            // 
            // FormHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(235)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1120, 811);
            this.Controls.Add(this.pnlReceipt);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize = new System.Drawing.Size(1026, 744);
            this.Name = "FormHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORTSHOP - Hóa đơn";
            this.Load += new System.EventHandler(this.FormHoaDon_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlReceipt.ResumeLayout(false);
            this.pnlReceipt.PerformLayout();
            this.pnlHeadInfo.ResumeLayout(false);
            this.pnlHeadInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}

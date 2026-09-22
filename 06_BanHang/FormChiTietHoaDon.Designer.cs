namespace SPORTSHOP._06_BanHang
{
    partial class FormChiTietHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnInHoaDon;

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlHoaDon;
        private System.Windows.Forms.Panel pnlKhach;
        private System.Windows.Forms.Panel pnlThanhToan;

        private System.Windows.Forms.Label lblMaHD, lblMaHDValue;
        private System.Windows.Forms.Label lblMaDon, lblMaDonValue;
        private System.Windows.Forms.Label lblNgay, lblNgayValue;
        private System.Windows.Forms.Label lblNhanVien, lblNhanVienValue;
        private System.Windows.Forms.Label lblTrangThai, lblTrangThaiValue;

        private System.Windows.Forms.Label lblKhach, lblKhachValue;
        private System.Windows.Forms.Label lblSDT, lblSDTValue;
        private System.Windows.Forms.Label lblEmail, lblEmailValue;
        private System.Windows.Forms.Label lblDiaChi, lblDiaChiValue;

        private System.Windows.Forms.Label lblPhuongThuc, lblPhuongThucValue;
        private System.Windows.Forms.Label lblSoTien, lblSoTienValue;

        private System.Windows.Forms.Panel pnlProducts;
        private System.Windows.Forms.Label lblProductsTitle, lblTongSL;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaBienThe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMau;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblTienHang, lblTienHangValue;
        private System.Windows.Forms.Label lblGiam, lblGiamValue;
        private System.Windows.Forms.Label lblShip, lblShipValue;
        private System.Windows.Forms.Label lblTongThanhToan, lblTongThanhToanValue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnInHoaDon = new System.Windows.Forms.Button();

            this.pnlInfo = new System.Windows.Forms.Panel();
            this.pnlHoaDon = new System.Windows.Forms.Panel();
            this.pnlKhach = new System.Windows.Forms.Panel();
            this.pnlThanhToan = new System.Windows.Forms.Panel();

            this.lblMaHD = new System.Windows.Forms.Label();
            this.lblMaHDValue = new System.Windows.Forms.Label();
            this.lblMaDon = new System.Windows.Forms.Label();
            this.lblMaDonValue = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.lblNgayValue = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblNhanVienValue = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTrangThaiValue = new System.Windows.Forms.Label();

            this.lblKhach = new System.Windows.Forms.Label();
            this.lblKhachValue = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblSDTValue = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblEmailValue = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblDiaChiValue = new System.Windows.Forms.Label();

            this.lblPhuongThuc = new System.Windows.Forms.Label();
            this.lblPhuongThucValue = new System.Windows.Forms.Label();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.lblSoTienValue = new System.Windows.Forms.Label();

            this.pnlProducts = new System.Windows.Forms.Panel();
            this.lblProductsTitle = new System.Windows.Forms.Label();
            this.lblTongSL = new System.Windows.Forms.Label();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();

            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaBienThe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblTienHang = new System.Windows.Forms.Label();
            this.lblTienHangValue = new System.Windows.Forms.Label();
            this.lblGiam = new System.Windows.Forms.Label();
            this.lblGiamValue = new System.Windows.Forms.Label();
            this.lblShip = new System.Windows.Forms.Label();
            this.lblShipValue = new System.Windows.Forms.Label();
            this.lblTongThanhToan = new System.Windows.Forms.Label();
            this.lblTongThanhToanValue = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // FORM
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.ClientSize = new System.Drawing.Size(1320, 820);
            this.MinimumSize = new System.Drawing.Size(1120, 700);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "FormChiTietHoaDon";
            this.Text = "SPORTSHOP - Chi tiết hóa đơn";
            this.Load += new System.EventHandler(this.FormChiTietHoaDon_Load);

            // HEADER
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(18, 35, 58);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 94;

            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(28, 15);
            this.lblLogo.Text = "SPORTSHOP";

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(218, 16);
            this.lblTitle.Text = "Chi tiết hóa đơn";

            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(196, 210, 226);
            this.lblSubTitle.Location = new System.Drawing.Point(220, 48);
            this.lblSubTitle.Text = "Thông tin hóa đơn, khách hàng, thanh toán và sản phẩm";

            this.btnInHoaDon.BackColor = System.Drawing.Color.FromArgb(27, 120, 220);
            this.btnInHoaDon.FlatAppearance.BorderSize = 0;
            this.btnInHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInHoaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnInHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnInHoaDon.Location = new System.Drawing.Point(1050, 27);
            this.btnInHoaDon.Size = new System.Drawing.Size(118, 34);
            this.btnInHoaDon.Text = "In hóa đơn";

            this.btnDong.BackColor = System.Drawing.Color.FromArgb(230, 235, 243);
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.FromArgb(35, 52, 73);
            this.btnDong.Location = new System.Drawing.Point(1180, 27);
            this.btnDong.Size = new System.Drawing.Size(105, 34);
            this.btnDong.Text = "Đóng";

            this.pnlHeader.Controls.Add(this.lblLogo);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.btnInHoaDon);
            this.pnlHeader.Controls.Add(this.btnDong);

            // INFO
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Height = 205;
            this.pnlInfo.Padding = new System.Windows.Forms.Padding(18, 14, 18, 8);

            this.pnlHoaDon.BackColor = System.Drawing.Color.White;
            this.pnlHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHoaDon.Location = new System.Drawing.Point(18, 14);
            this.pnlHoaDon.Size = new System.Drawing.Size(405, 180);

            this.pnlKhach.BackColor = System.Drawing.Color.White;
            this.pnlKhach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKhach.Location = new System.Drawing.Point(435, 14);
            this.pnlKhach.Size = new System.Drawing.Size(450, 180);

            this.pnlThanhToan.BackColor = System.Drawing.Color.White;
            this.pnlThanhToan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThanhToan.Location = new System.Drawing.Point(897, 14);
            this.pnlThanhToan.Size = new System.Drawing.Size(405, 180);

            // section titles
            System.Windows.Forms.Label title1 =
     new System.Windows.Forms.Label();
            title1.AutoSize = true;
            title1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            title1.ForeColor = System.Drawing.Color.FromArgb(25, 52, 82);
            title1.Location = new System.Drawing.Point(14, 12);
            title1.Text = "Thông tin hóa đơn";
            this.pnlHoaDon.Controls.Add(title1);

            System.Windows.Forms.Label title2 =
     new System.Windows.Forms.Label();
            title2.AutoSize = true;
            title2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            title2.ForeColor = System.Drawing.Color.FromArgb(25, 52, 82);
            title2.Location = new System.Drawing.Point(14, 12);
            title2.Text = "Thông tin khách hàng";
            this.pnlKhach.Controls.Add(title2);

            System.Windows.Forms.Label title3 =
    new System.Windows.Forms.Label();
            title3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            title3.ForeColor = System.Drawing.Color.FromArgb(25, 52, 82);
            title3.Location = new System.Drawing.Point(14, 12);
            title3.Text = "Thông tin thanh toán";
            this.pnlThanhToan.Controls.Add(title3);

            // Invoice labels
            this.lblMaHD.AutoSize = true; this.lblMaHD.Text = "Mã hóa đơn";
            this.lblMaHD.Location = new System.Drawing.Point(15, 44);
            this.lblMaHD.ForeColor = System.Drawing.Color.FromArgb(105, 116, 132);
            this.lblMaHD.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);

            this.lblMaHDValue.AutoSize = true; this.lblMaHDValue.Text = "—";
            this.lblMaHDValue.Location = new System.Drawing.Point(125, 42);
            this.lblMaHDValue.ForeColor = System.Drawing.Color.FromArgb(38, 49, 64);

            this.lblMaDon.AutoSize = true; this.lblMaDon.Text = "Mã đơn";
            this.lblMaDon.Location = new System.Drawing.Point(15, 70);
            this.lblMaDon.ForeColor = System.Drawing.Color.FromArgb(105, 116, 132);

            this.lblMaDonValue.AutoSize = true; this.lblMaDonValue.Text = "—";
            this.lblMaDonValue.Location = new System.Drawing.Point(125, 68);

            this.lblNgay.AutoSize = true; this.lblNgay.Text = "Ngày lập";
            this.lblNgay.Location = new System.Drawing.Point(15, 96);
            this.lblNgay.ForeColor = System.Drawing.Color.FromArgb(105, 116, 132);

            this.lblNgayValue.AutoSize = true; this.lblNgayValue.Text = "—";
            this.lblNgayValue.Location = new System.Drawing.Point(125, 94);

            this.lblNhanVien.AutoSize = true; this.lblNhanVien.Text = "Nhân viên";
            this.lblNhanVien.Location = new System.Drawing.Point(15, 122);
            this.lblNhanVien.ForeColor = System.Drawing.Color.FromArgb(105, 116, 132);

            this.lblNhanVienValue.AutoSize = true; this.lblNhanVienValue.Text = "—";
            this.lblNhanVienValue.Location = new System.Drawing.Point(125, 120);

            this.lblTrangThai.AutoSize = true; this.lblTrangThai.Text = "Trạng thái";
            this.lblTrangThai.Location = new System.Drawing.Point(15, 148);
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(105, 116, 132);

            this.lblTrangThaiValue.AutoSize = true; this.lblTrangThaiValue.Text = "—";
            this.lblTrangThaiValue.Location = new System.Drawing.Point(125, 146);

            this.pnlHoaDon.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMaHD,this.lblMaHDValue,this.lblMaDon,this.lblMaDonValue,
                this.lblNgay,this.lblNgayValue,this.lblNhanVien,this.lblNhanVienValue,
                this.lblTrangThai,this.lblTrangThaiValue
            });

            // Customer
            this.lblKhach.AutoSize = true; this.lblKhach.Text = "Họ tên";
            this.lblKhach.Location = new System.Drawing.Point(15, 44);
            this.lblKhach.ForeColor = System.Drawing.Color.FromArgb(105, 116, 132);
            this.lblKhachValue.AutoSize = true; this.lblKhachValue.Text = "—";
            this.lblKhachValue.Location = new System.Drawing.Point(125, 42);

            this.lblSDT.AutoSize = true; this.lblSDT.Text = "Số điện thoại";
            this.lblSDT.Location = new System.Drawing.Point(15, 70);
            this.lblSDT.ForeColor = System.Drawing.Color.FromArgb(105, 116, 132);
            this.lblSDTValue.AutoSize = true; this.lblSDTValue.Text = "—";
            this.lblSDTValue.Location = new System.Drawing.Point(125, 68);

            this.lblEmail.AutoSize = true; this.lblEmail.Text = "Email";
            this.lblEmail.Location = new System.Drawing.Point(15, 96);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(105, 116, 132);
            this.lblEmailValue.AutoSize = true; this.lblEmailValue.Text = "—";
            this.lblEmailValue.Location = new System.Drawing.Point(125, 94);

            this.lblDiaChi.AutoSize = true; this.lblDiaChi.Text = "Địa chỉ";
            this.lblDiaChi.Location = new System.Drawing.Point(15, 124);
            this.lblDiaChi.ForeColor = System.Drawing.Color.FromArgb(105, 116, 132);
            this.lblDiaChiValue.Text = "—";
            this.lblDiaChiValue.Location = new System.Drawing.Point(125, 121);
            this.lblDiaChiValue.Size = new System.Drawing.Size(300, 45);
            this.lblDiaChiValue.AutoEllipsis = true;

            this.pnlKhach.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblKhach,this.lblKhachValue,this.lblSDT,this.lblSDTValue,
                this.lblEmail,this.lblEmailValue,this.lblDiaChi,this.lblDiaChiValue
            });

            // Payment
            this.lblPhuongThuc.AutoSize = true; this.lblPhuongThuc.Text = "Phương thức";
            this.lblPhuongThuc.Location = new System.Drawing.Point(15, 50);
            this.lblPhuongThuc.ForeColor = System.Drawing.Color.FromArgb(105, 116, 132);
            this.lblPhuongThucValue.AutoSize = true; this.lblPhuongThucValue.Text = "—";
            this.lblPhuongThucValue.Location = new System.Drawing.Point(125, 48);

            this.lblSoTien.AutoSize = true; this.lblSoTien.Text = "Số tiền";
            this.lblSoTien.Location = new System.Drawing.Point(15, 84);
            this.lblSoTien.ForeColor = System.Drawing.Color.FromArgb(105, 116, 132);
            this.lblSoTienValue.AutoSize = true; this.lblSoTienValue.Text = "0 đ";
            this.lblSoTienValue.Location = new System.Drawing.Point(125, 82);
            this.lblSoTienValue.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);

            this.pnlThanhToan.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblPhuongThuc,this.lblPhuongThucValue,this.lblSoTien,this.lblSoTienValue
            });

            this.pnlInfo.Controls.Add(this.pnlHoaDon);
            this.pnlInfo.Controls.Add(this.pnlKhach);
            this.pnlInfo.Controls.Add(this.pnlThanhToan);

            // PRODUCTS
            this.pnlProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProducts.Padding = new System.Windows.Forms.Padding(18, 5, 18, 8);
            this.lblProductsTitle.AutoSize = true;
            this.lblProductsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductsTitle.ForeColor = System.Drawing.Color.FromArgb(25, 52, 82);
            this.lblProductsTitle.Location = new System.Drawing.Point(18, 4);
            this.lblProductsTitle.Text = "Danh sách sản phẩm";

            this.lblTongSL.AutoSize = true;
            this.lblTongSL.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongSL.ForeColor = System.Drawing.Color.FromArgb(93, 105, 121);
            this.lblTongSL.Location = new System.Drawing.Point(1160, 8);
            this.lblTongSL.Text = "0 sản phẩm";

            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Location = new System.Drawing.Point(18, 35);
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTiet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTiet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvChiTiet.ColumnHeadersHeight = 40;
            this.dgvChiTiet.EnableHeadersVisualStyles = false;
            this.dgvChiTiet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvChiTiet.GridColor = System.Drawing.Color.FromArgb(226, 231, 238);
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(25, 52, 82);
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.dgvChiTiet.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 239, 255);
            this.dgvChiTiet.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(25, 52, 82);
            this.dgvChiTiet.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);

            this.colSTT.HeaderText = "STT"; this.colSTT.Name = "colSTT"; this.colSTT.Width = 48;
            this.colMaBienThe.HeaderText = "Mã biến thể"; this.colMaBienThe.Name = "colMaBienThe"; this.colMaBienThe.Width = 100;
            this.colMaSP.HeaderText = "Mã SP"; this.colMaSP.Name = "colMaSP"; this.colMaSP.Width = 80;
            this.colSanPham.HeaderText = "Sản phẩm"; this.colSanPham.Name = "colSanPham"; this.colSanPham.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill; this.colSanPham.FillWeight = 180;
            this.colSize.HeaderText = "Size"; this.colSize.Name = "colSize"; this.colSize.Width = 65;
            this.colMau.HeaderText = "Màu"; this.colMau.Name = "colMau"; this.colMau.Width = 100;
            this.colSL.HeaderText = "Số lượng"; this.colSL.Name = "colSL"; this.colSL.Width = 85;
            this.colDonGia.HeaderText = "Đơn giá"; this.colDonGia.Name = "colDonGia"; this.colDonGia.Width = 125;
            this.colThanhTien.HeaderText = "Thành tiền"; this.colThanhTien.Name = "colThanhTien"; this.colThanhTien.Width = 135;

            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colSTT,this.colMaBienThe,this.colMaSP,this.colSanPham,
                this.colSize,this.colMau,this.colSL,this.colDonGia,this.colThanhTien
            });

            this.pnlProducts.Controls.Add(this.dgvChiTiet);
            this.pnlProducts.Controls.Add(this.lblTongSL);
            this.pnlProducts.Controls.Add(this.lblProductsTitle);

            // BOTTOM
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 118;

            this.lblTienHang.AutoSize = true; this.lblTienHang.Text = "Tiền hàng";
            this.lblTienHang.Location = new System.Drawing.Point(30, 15);
            this.lblTienHangValue.AutoSize = true; this.lblTienHangValue.Text = "0 đ";
            this.lblTienHangValue.Location = new System.Drawing.Point(180, 15);

            this.lblGiam.AutoSize = true; this.lblGiam.Text = "Giảm giá";
            this.lblGiam.Location = new System.Drawing.Point(30, 41);
            this.lblGiamValue.AutoSize = true; this.lblGiamValue.Text = "0 đ";
            this.lblGiamValue.Location = new System.Drawing.Point(180, 41);

            this.lblShip.AutoSize = true; this.lblShip.Text = "Vận chuyển";
            this.lblShip.Location = new System.Drawing.Point(30, 67);
            this.lblShipValue.AutoSize = true; this.lblShipValue.Text = "0 đ";
            this.lblShipValue.Location = new System.Drawing.Point(180, 67);

            this.lblTongThanhToan.AutoSize = true;
            this.lblTongThanhToan.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongThanhToan.ForeColor = System.Drawing.Color.FromArgb(25, 52, 82);
            this.lblTongThanhToan.Location = new System.Drawing.Point(850, 72);
            this.lblTongThanhToan.Text = "TỔNG THANH TOÁN";

            this.lblTongThanhToanValue.AutoSize = true;
            this.lblTongThanhToanValue.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTongThanhToanValue.ForeColor = System.Drawing.Color.FromArgb(220, 44, 54);
            this.lblTongThanhToanValue.Location = new System.Drawing.Point(1040, 66);
            this.lblTongThanhToanValue.Text = "0 đ";

            this.pnlBottom.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTienHang,this.lblTienHangValue,
                this.lblGiam,this.lblGiamValue,
                this.lblShip,this.lblShipValue,
                this.lblTongThanhToan,this.lblTongThanhToanValue
            });

            this.Controls.Add(this.pnlProducts);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlHeader);

            this.ResumeLayout(false);
        }
    }
}

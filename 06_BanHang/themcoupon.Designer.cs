namespace SPORTSHOP._06_BanHang
{
    partial class themcoupon
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTieuDe;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHuongDan;

        private Guna.UI2.WinForms.Guna2TextBox txt_macoupon;
        private Guna.UI2.WinForms.Guna2TextBox txt_ten;
        private Guna.UI2.WinForms.Guna2ComboBox txt_loai;
        private Guna.UI2.WinForms.Guna2TextBox txt_giatri;
        private Guna.UI2.WinForms.Guna2TextBox txt_dontoithieu;
        private Guna.UI2.WinForms.Guna2TextBox txt_soluong;

        private Guna.UI2.WinForms.Guna2DateTimePicker dt_ngaybatdau;
        private Guna.UI2.WinForms.Guna2DateTimePicker dt_ketthuc;

        private Guna.UI2.WinForms.Guna2Button btn_them;
        private Guna.UI2.WinForms.Guna2Button btn_huy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTieuDe = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblHuongDan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txt_macoupon = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_ten = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_loai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txt_giatri = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_dontoithieu = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_soluong = new Guna.UI2.WinForms.Guna2TextBox();
            this.dt_ngaybatdau = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dt_ketthuc = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btn_them = new Guna.UI2.WinForms.Guna2Button();
            this.btn_huy = new Guna.UI2.WinForms.Guna2Button();
            this.lblMaVoucher = new System.Windows.Forms.Label();
            this.lblTenChuongTrinh = new System.Windows.Forms.Label();
            this.lblLoaiGiam = new System.Windows.Forms.Label();
            this.lblGiaTri = new System.Windows.Forms.Label();
            this.lblDonToiThieu = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.lblNgayKetThuc = new System.Windows.Forms.Label();
            this.lblBatBuoc = new System.Windows.Forms.Label();
            this.lblGiaTriHint = new System.Windows.Forms.Label();
            this.lblHeThong = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(823, 115);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(32, 18);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(262, 43);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "🎟  TẠO VOUCHER";
            // 
            // lblHuongDan
            // 
            this.lblHuongDan.BackColor = System.Drawing.Color.Transparent;
            this.lblHuongDan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHuongDan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(220)))));
            this.lblHuongDan.Location = new System.Drawing.Point(35, 61);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new System.Drawing.Size(485, 23);
            this.lblHuongDan.TabIndex = 1;
            this.lblHuongDan.Text = "Tạo mã giảm giá mới • Hệ thống tự quản lý lượt sử dụng và trạng thái";
            // 
            // txt_macoupon
            // 
            this.txt_macoupon.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(220)))));
            this.txt_macoupon.BorderRadius = 8;
            this.txt_macoupon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_macoupon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_macoupon.DefaultText = "";
            this.txt_macoupon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txt_macoupon.Location = new System.Drawing.Point(40, 161);
            this.txt_macoupon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_macoupon.MaxLength = 30;
            this.txt_macoupon.Name = "txt_macoupon";
            this.txt_macoupon.PlaceholderText = "VD: VOUCHER10";
            this.txt_macoupon.SelectedText = "";
            this.txt_macoupon.Size = new System.Drawing.Size(360, 43);
            this.txt_macoupon.TabIndex = 1;
            // 
            // txt_ten
            // 
            this.txt_ten.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(220)))));
            this.txt_ten.BorderRadius = 8;
            this.txt_ten.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ten.DefaultText = "";
            this.txt_ten.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txt_ten.Location = new System.Drawing.Point(417, 161);
            this.txt_ten.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_ten.MaxLength = 200;
            this.txt_ten.Name = "txt_ten";
            this.txt_ten.PlaceholderText = "VD: Voucher khách hàng mới";
            this.txt_ten.SelectedText = "";
            this.txt_ten.Size = new System.Drawing.Size(366, 43);
            this.txt_ten.TabIndex = 2;
            // 
            // txt_loai
            // 
            this.txt_loai.BackColor = System.Drawing.Color.Transparent;
            this.txt_loai.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(220)))));
            this.txt_loai.BorderRadius = 8;
            this.txt_loai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txt_loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_loai.FocusedColor = System.Drawing.Color.Empty;
            this.txt_loai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txt_loai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.txt_loai.ItemHeight = 30;
            this.txt_loai.Location = new System.Drawing.Point(40, 255);
            this.txt_loai.Name = "txt_loai";
            this.txt_loai.Size = new System.Drawing.Size(359, 36);
            this.txt_loai.TabIndex = 3;
            // 
            // txt_giatri
            // 
            this.txt_giatri.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(220)))));
            this.txt_giatri.BorderRadius = 8;
            this.txt_giatri.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_giatri.DefaultText = "";
            this.txt_giatri.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txt_giatri.Location = new System.Drawing.Point(417, 255);
            this.txt_giatri.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_giatri.Name = "txt_giatri";
            this.txt_giatri.PlaceholderText = "VD: 10 hoặc 50000";
            this.txt_giatri.SelectedText = "";
            this.txt_giatri.Size = new System.Drawing.Size(366, 43);
            this.txt_giatri.TabIndex = 4;
            // 
            // txt_dontoithieu
            // 
            this.txt_dontoithieu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(220)))));
            this.txt_dontoithieu.BorderRadius = 8;
            this.txt_dontoithieu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_dontoithieu.DefaultText = "";
            this.txt_dontoithieu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txt_dontoithieu.Location = new System.Drawing.Point(40, 349);
            this.txt_dontoithieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_dontoithieu.Name = "txt_dontoithieu";
            this.txt_dontoithieu.PlaceholderText = "VD: 200000";
            this.txt_dontoithieu.SelectedText = "";
            this.txt_dontoithieu.Size = new System.Drawing.Size(360, 43);
            this.txt_dontoithieu.TabIndex = 5;
            // 
            // txt_soluong
            // 
            this.txt_soluong.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(220)))));
            this.txt_soluong.BorderRadius = 8;
            this.txt_soluong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_soluong.DefaultText = "";
            this.txt_soluong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txt_soluong.Location = new System.Drawing.Point(417, 349);
            this.txt_soluong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_soluong.Name = "txt_soluong";
            this.txt_soluong.PlaceholderText = "VD: 100";
            this.txt_soluong.SelectedText = "";
            this.txt_soluong.Size = new System.Drawing.Size(366, 43);
            this.txt_soluong.TabIndex = 6;
            // 
            // dt_ngaybatdau
            // 
            this.dt_ngaybatdau.BorderRadius = 8;
            this.dt_ngaybatdau.Checked = true;
            this.dt_ngaybatdau.CustomFormat = "dd/MM/yyyy";
            this.dt_ngaybatdau.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dt_ngaybatdau.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dt_ngaybatdau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.dt_ngaybatdau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_ngaybatdau.Location = new System.Drawing.Point(40, 443);
            this.dt_ngaybatdau.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dt_ngaybatdau.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dt_ngaybatdau.Name = "dt_ngaybatdau";
            this.dt_ngaybatdau.Size = new System.Drawing.Size(360, 43);
            this.dt_ngaybatdau.TabIndex = 7;
            this.dt_ngaybatdau.Value = new System.DateTime(2026, 9, 21, 0, 0, 0, 0);
            // 
            // dt_ketthuc
            // 
            this.dt_ketthuc.BorderRadius = 8;
            this.dt_ketthuc.Checked = true;
            this.dt_ketthuc.CustomFormat = "dd/MM/yyyy";
            this.dt_ketthuc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dt_ketthuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dt_ketthuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.dt_ketthuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_ketthuc.Location = new System.Drawing.Point(417, 443);
            this.dt_ketthuc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dt_ketthuc.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dt_ketthuc.Name = "dt_ketthuc";
            this.dt_ketthuc.Size = new System.Drawing.Size(366, 43);
            this.dt_ketthuc.TabIndex = 8;
            this.dt_ketthuc.Value = new System.DateTime(2026, 10, 21, 0, 0, 0, 0);
            // 
            // btn_them
            // 
            this.btn_them.BorderRadius = 9;
            this.btn_them.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(180)))), ((int)(((byte)(126)))));
            this.btn_them.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn_them.ForeColor = System.Drawing.Color.White;
            this.btn_them.Location = new System.Drawing.Point(40, 571);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(360, 47);
            this.btn_them.TabIndex = 9;
            this.btn_them.Text = "✓  TẠO VOUCHER";
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.BorderRadius = 9;
            this.btn_huy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_huy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(115)))));
            this.btn_huy.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn_huy.ForeColor = System.Drawing.Color.White;
            this.btn_huy.Location = new System.Drawing.Point(417, 571);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(366, 47);
            this.btn_huy.TabIndex = 10;
            this.btn_huy.Text = "HỦY";
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // lblMaVoucher
            // 
            this.lblMaVoucher.AutoSize = true;
            this.lblMaVoucher.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMaVoucher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblMaVoucher.Location = new System.Drawing.Point(43, 139);
            this.lblMaVoucher.Name = "lblMaVoucher";
            this.lblMaVoucher.Size = new System.Drawing.Size(111, 21);
            this.lblMaVoucher.TabIndex = 0;
            this.lblMaVoucher.Text = "Mã voucher *";
            // 
            // lblTenChuongTrinh
            // 
            this.lblTenChuongTrinh.AutoSize = true;
            this.lblTenChuongTrinh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTenChuongTrinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblTenChuongTrinh.Location = new System.Drawing.Point(421, 139);
            this.lblTenChuongTrinh.Name = "lblTenChuongTrinh";
            this.lblTenChuongTrinh.Size = new System.Drawing.Size(152, 21);
            this.lblTenChuongTrinh.TabIndex = 1;
            this.lblTenChuongTrinh.Text = "Tên chương trình *";
            // 
            // lblLoaiGiam
            // 
            this.lblLoaiGiam.AutoSize = true;
            this.lblLoaiGiam.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLoaiGiam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblLoaiGiam.Location = new System.Drawing.Point(43, 233);
            this.lblLoaiGiam.Name = "lblLoaiGiam";
            this.lblLoaiGiam.Size = new System.Drawing.Size(96, 21);
            this.lblLoaiGiam.TabIndex = 2;
            this.lblLoaiGiam.Text = "Loại giảm *";
            // 
            // lblGiaTri
            // 
            this.lblGiaTri.AutoSize = true;
            this.lblGiaTri.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblGiaTri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblGiaTri.Location = new System.Drawing.Point(421, 233);
            this.lblGiaTri.Name = "lblGiaTri";
            this.lblGiaTri.Size = new System.Drawing.Size(110, 21);
            this.lblGiaTri.TabIndex = 3;
            this.lblGiaTri.Text = "Giá trị giảm *";
            // 
            // lblDonToiThieu
            // 
            this.lblDonToiThieu.AutoSize = true;
            this.lblDonToiThieu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDonToiThieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblDonToiThieu.Location = new System.Drawing.Point(43, 326);
            this.lblDonToiThieu.Name = "lblDonToiThieu";
            this.lblDonToiThieu.Size = new System.Drawing.Size(111, 21);
            this.lblDonToiThieu.TabIndex = 4;
            this.lblDonToiThieu.Text = "Đơn tối thiểu";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblSoLuong.Location = new System.Drawing.Point(421, 326);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(142, 21);
            this.lblSoLuong.TabIndex = 5;
            this.lblSoLuong.Text = "Số lượt sử dụng *";
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.AutoSize = true;
            this.lblNgayBatDau.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNgayBatDau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblNgayBatDau.Location = new System.Drawing.Point(43, 420);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(124, 21);
            this.lblNgayBatDau.TabIndex = 6;
            this.lblNgayBatDau.Text = "Ngày bắt đầu *";
            // 
            // lblNgayKetThuc
            // 
            this.lblNgayKetThuc.AutoSize = true;
            this.lblNgayKetThuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNgayKetThuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblNgayKetThuc.Location = new System.Drawing.Point(421, 420);
            this.lblNgayKetThuc.Name = "lblNgayKetThuc";
            this.lblNgayKetThuc.Size = new System.Drawing.Size(128, 21);
            this.lblNgayKetThuc.TabIndex = 7;
            this.lblNgayKetThuc.Text = "Ngày kết thúc *";
            // 
            // lblBatBuoc
            // 
            this.lblBatBuoc.AutoSize = true;
            this.lblBatBuoc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBatBuoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblBatBuoc.Location = new System.Drawing.Point(43, 506);
            this.lblBatBuoc.Name = "lblBatBuoc";
            this.lblBatBuoc.Size = new System.Drawing.Size(145, 20);
            this.lblBatBuoc.TabIndex = 8;
            this.lblBatBuoc.Text = "* Thông tin bắt buộc";
            // 
            // lblGiaTriHint
            // 
            this.lblGiaTriHint.AutoSize = true;
            this.lblGiaTriHint.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblGiaTriHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblGiaTriHint.Location = new System.Drawing.Point(421, 300);
            this.lblGiaTriHint.Name = "lblGiaTriHint";
            this.lblGiaTriHint.Size = new System.Drawing.Size(220, 20);
            this.lblGiaTriHint.TabIndex = 9;
            this.lblGiaTriHint.Text = "Phần trăm: nhập 10 = giảm 10%";
            // 
            // lblHeThong
            // 
            this.lblHeThong.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHeThong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblHeThong.Location = new System.Drawing.Point(421, 506);
            this.lblHeThong.Name = "lblHeThong";
            this.lblHeThong.Size = new System.Drawing.Size(360, 36);
            this.lblHeThong.TabIndex = 10;
            this.lblHeThong.Text = "Mã sẽ được tạo ở trạng thái hoạt động và lượt đã dùng = 0.";
            // 
            // themcoupon
            // 
            this.AcceptButton = this.btn_them;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.CancelButton = this.btn_huy;
            this.ClientSize = new System.Drawing.Size(823, 704);
            this.Controls.Add(this.lblMaVoucher);
            this.Controls.Add(this.lblTenChuongTrinh);
            this.Controls.Add(this.lblLoaiGiam);
            this.Controls.Add(this.lblGiaTri);
            this.Controls.Add(this.lblDonToiThieu);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.lblNgayBatDau);
            this.Controls.Add(this.lblNgayKetThuc);
            this.Controls.Add(this.lblBatBuoc);
            this.Controls.Add(this.lblGiaTriHint);
            this.Controls.Add(this.lblHeThong);
            this.Controls.Add(this.txt_macoupon);
            this.Controls.Add(this.txt_ten);
            this.Controls.Add(this.txt_loai);
            this.Controls.Add(this.txt_giatri);
            this.Controls.Add(this.txt_dontoithieu);
            this.Controls.Add(this.txt_soluong);
            this.Controls.Add(this.dt_ngaybatdau);
            this.Controls.Add(this.dt_ketthuc);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "themcoupon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo Voucher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblMaVoucher;
        private System.Windows.Forms.Label lblTenChuongTrinh;
        private System.Windows.Forms.Label lblLoaiGiam;
        private System.Windows.Forms.Label lblGiaTri;
        private System.Windows.Forms.Label lblDonToiThieu;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.Label lblNgayKetThuc;
        private System.Windows.Forms.Label lblBatBuoc;
        private System.Windows.Forms.Label lblGiaTriHint;
        private System.Windows.Forms.Label lblHeThong;
    }
}

namespace SPORTSHOP._06_BanHang
{
    partial class Giohang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle bodyStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblKHValue = new System.Windows.Forms.Label();
            this.btn_thongTinKH = new System.Windows.Forms.Button();
            this.btn_doiDiaChi = new System.Windows.Forms.Button();
            this.lblHangDiem = new System.Windows.Forms.Label();
            this.lblViInfo = new System.Windows.Forms.Label();
            this.btn_moVi = new System.Windows.Forms.Button();
            this.lblVoucherInfo = new System.Windows.Forms.Label();
            this.lblKhuyenMaiInfo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_giamgia = new System.Windows.Forms.ComboBox();
            this.btn_giamgia = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_vanchuyen = new System.Windows.Forms.ComboBox();
            this.btn_vanchuyen = new System.Windows.Forms.Button();
            this.lblPhiVanChuyen = new System.Windows.Forms.Label();
            this.lblDiaChiNhan = new System.Windows.Forms.Label();
            this.lblDiaChiValue = new System.Windows.Forms.Label();
            this.lblPhuongThuc = new System.Windows.Forms.Label();
            this.rdoThe = new System.Windows.Forms.RadioButton();
            this.rdoChuyenKhoan = new System.Windows.Forms.RadioButton();
            this.rdoViDienTu = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_thanhtoan = new System.Windows.Forms.Button();
            this.btn_dong = new System.Windows.Forms.Button();

            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_giohang = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_xoa = new System.Windows.Forms.Button();

            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_giohang)).BeginInit();
            this.SuspendLayout();

            // FORM
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(10, 10, 12);
            this.ClientSize = new System.Drawing.Size(1360, 900);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1180, 780);
            this.Name = "Giohang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORTSHOP - Giỏ hàng";
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Load += new System.EventHandler(this.Giohang_Load);

            // LEFT PANEL
            this.panel1.BackColor = System.Drawing.Color.FromArgb(20, 20, 23);
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgv_giohang);
            this.panel1.Controls.Add(this.btn_xoa);
            this.panel1.Location = new System.Drawing.Point(18, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(735, 850);
            this.panel1.TabIndex = 0;

            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 45);
            this.label2.Text = "GIỎ HÀNG";

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(155, 155, 165);
            this.label1.Location = new System.Drawing.Point(26, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 19);
            this.label1.Text = "KIỂM TRA SẢN PHẨM TRƯỚC KHI THANH TOÁN";

            this.dgv_giohang.AllowUserToAddRows = false;
            this.dgv_giohang.AllowUserToDeleteRows = false;
            this.dgv_giohang.AllowUserToResizeRows = false;
            this.dgv_giohang.BackgroundColor = System.Drawing.Color.FromArgb(28, 28, 31);
            this.dgv_giohang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_giohang.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_giohang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(220, 30, 45);
            headerStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(220, 30, 45);
            headerStyle.SelectionForeColor = System.Drawing.Color.White;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_giohang.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgv_giohang.ColumnHeadersHeight = 44;

            this.dgv_giohang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.Column1, this.Column2, this.Column3,
                this.Column4, this.Column5, this.Column6});

            bodyStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            bodyStyle.BackColor = System.Drawing.Color.FromArgb(28, 28, 31);
            bodyStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            bodyStyle.ForeColor = System.Drawing.Color.FromArgb(235, 235, 238);
            bodyStyle.SelectionBackColor = System.Drawing.Color.FromArgb(58, 30, 34);
            bodyStyle.SelectionForeColor = System.Drawing.Color.White;
            bodyStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_giohang.DefaultCellStyle = bodyStyle;
            this.dgv_giohang.EnableHeadersVisualStyles = false;
            this.dgv_giohang.GridColor = System.Drawing.Color.FromArgb(52, 52, 57);
            this.dgv_giohang.Location = new System.Drawing.Point(22, 94);
            this.dgv_giohang.MultiSelect = false;
            this.dgv_giohang.Name = "dgv_giohang";
            this.dgv_giohang.ReadOnly = true;
            this.dgv_giohang.RowHeadersVisible = false;
            this.dgv_giohang.RowHeadersWidth = 51;
            this.dgv_giohang.RowTemplate.Height = 58;
            this.dgv_giohang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_giohang.Size = new System.Drawing.Size(689, 670);
            this.dgv_giohang.TabIndex = 2;

            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Sản phẩm";
            this.Column1.MinimumWidth = 230;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;

            this.Column2.HeaderText = "Giá";
            this.Column2.MinimumWidth = 90;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 110;

            this.Column3.HeaderText = "+";
            this.Column3.MinimumWidth = 35;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 38;

            this.Column4.HeaderText = "SL";
            this.Column4.MinimumWidth = 45;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 48;

            this.Column5.HeaderText = "-";
            this.Column5.MinimumWidth = 35;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 38;

            this.Column6.HeaderText = "Thành tiền";
            this.Column6.MinimumWidth = 110;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 130;

            this.btn_xoa.BackColor = System.Drawing.Color.FromArgb(220, 30, 45);
            this.btn_xoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_xoa.FlatAppearance.BorderSize = 0;
            this.btn_xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xoa.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_xoa.ForeColor = System.Drawing.Color.White;
            this.btn_xoa.Location = new System.Drawing.Point(22, 786);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(175, 46);
            this.btn_xoa.TabIndex = 3;
            this.btn_xoa.Text = "XÓA TẤT CẢ";
            this.btn_xoa.UseVisualStyleBackColor = false;

            // RIGHT PANEL
            this.panel3.BackColor = System.Drawing.Color.FromArgb(20, 20, 23);
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lblKHValue);
            this.panel3.Controls.Add(this.btn_thongTinKH);
            this.panel3.Controls.Add(this.btn_doiDiaChi);
            this.panel3.Controls.Add(this.lblHangDiem);
            this.panel3.Controls.Add(this.lblViInfo);
            this.panel3.Controls.Add(this.btn_moVi);
            this.panel3.Controls.Add(this.lblVoucherInfo);
            this.panel3.Controls.Add(this.lblKhuyenMaiInfo);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cmb_giamgia);
            this.panel3.Controls.Add(this.btn_giamgia);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cmb_vanchuyen);
            this.panel3.Controls.Add(this.btn_vanchuyen);
            this.panel3.Controls.Add(this.lblPhiVanChuyen);
            this.panel3.Controls.Add(this.lblDiaChiNhan);
            this.panel3.Controls.Add(this.lblDiaChiValue);
            this.panel3.Controls.Add(this.lblPhuongThuc);
            this.panel3.Controls.Add(this.rdoThe);
            this.panel3.Controls.Add(this.rdoChuyenKhoan);
            this.panel3.Controls.Add(this.rdoViDienTu);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.btn_thanhtoan);
            this.panel3.Controls.Add(this.btn_dong);
            this.panel3.Location = new System.Drawing.Point(771, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(571, 850);
            this.panel3.TabIndex = 1;

            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 18);
            this.label3.Name = "label3";
            this.label3.Text = "THÔNG TIN KHÁCH & ĐƠN HÀNG";

            this.lblKHValue.AutoEllipsis = true;
            this.lblKHValue.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblKHValue.ForeColor = System.Drawing.Color.FromArgb(230, 230, 235);
            this.lblKHValue.Location = new System.Drawing.Point(25, 57);
            this.lblKHValue.Name = "lblKHValue";
            this.lblKHValue.Size = new System.Drawing.Size(500, 28);
            this.lblKHValue.Text = "Đang tải thông tin khách hàng...";

            this.btn_thongTinKH.BackColor = System.Drawing.Color.FromArgb(35, 35, 39);
            this.btn_thongTinKH.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(70, 70, 76);
            this.btn_thongTinKH.FlatAppearance.BorderSize = 1;
            this.btn_thongTinKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_thongTinKH.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btn_thongTinKH.ForeColor = System.Drawing.Color.FromArgb(225, 225, 230);
            this.btn_thongTinKH.Location = new System.Drawing.Point(25, 92);
            this.btn_thongTinKH.Size = new System.Drawing.Size(145, 36);
            this.btn_thongTinKH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_thongTinKH.UseVisualStyleBackColor = false;
            this.btn_thongTinKH.Name = "btn_thongTinKH";
            this.btn_thongTinKH.Text = "👤 HỒ SƠ KH";

            this.btn_doiDiaChi.BackColor = System.Drawing.Color.FromArgb(35, 35, 39);
            this.btn_doiDiaChi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(70, 70, 76);
            this.btn_doiDiaChi.FlatAppearance.BorderSize = 1;
            this.btn_doiDiaChi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_doiDiaChi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btn_doiDiaChi.ForeColor = System.Drawing.Color.FromArgb(225, 225, 230);
            this.btn_doiDiaChi.Location = new System.Drawing.Point(178, 92);
            this.btn_doiDiaChi.Size = new System.Drawing.Size(145, 36);
            this.btn_doiDiaChi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_doiDiaChi.UseVisualStyleBackColor = false;
            this.btn_doiDiaChi.Name = "btn_doiDiaChi";
            this.btn_doiDiaChi.Text = "📍 ĐỔI ĐỊA CHỈ";

            this.btn_moVi.BackColor = System.Drawing.Color.FromArgb(35, 35, 39);
            this.btn_moVi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(70, 70, 76);
            this.btn_moVi.FlatAppearance.BorderSize = 1;
            this.btn_moVi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_moVi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btn_moVi.ForeColor = System.Drawing.Color.FromArgb(225, 225, 230);
            this.btn_moVi.Location = new System.Drawing.Point(331, 92);
            this.btn_moVi.Size = new System.Drawing.Size(125, 36);
            this.btn_moVi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_moVi.UseVisualStyleBackColor = false;
            this.btn_moVi.Name = "btn_moVi";
            this.btn_moVi.Text = "💳 MỞ VÍ";

            this.lblHangDiem.AutoSize = true;
            this.lblHangDiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHangDiem.ForeColor = System.Drawing.Color.FromArgb(190, 190, 198);
            this.lblHangDiem.Location = new System.Drawing.Point(26, 137);
            this.lblHangDiem.Name = "lblHangDiem";
            this.lblHangDiem.Text = "Hạng Đồng • 0 điểm";

            this.lblViInfo.AutoSize = true;
            this.lblViInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblViInfo.ForeColor = System.Drawing.Color.FromArgb(90, 210, 145);
            this.lblViInfo.Location = new System.Drawing.Point(26, 161);
            this.lblViInfo.Name = "lblViInfo";
            this.lblViInfo.Text = "Ví điện tử: 0 Đ";

            this.lblVoucherInfo.AutoEllipsis = true;
            this.lblVoucherInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblVoucherInfo.ForeColor = System.Drawing.Color.FromArgb(255, 90, 100);
            this.lblVoucherInfo.Location = new System.Drawing.Point(26, 185);
            this.lblVoucherInfo.Name = "lblVoucherInfo";
            this.lblVoucherInfo.Size = new System.Drawing.Size(500, 23);
            this.lblVoucherInfo.Text = "Voucher: Chưa áp dụng";

            this.lblKhuyenMaiInfo.AutoEllipsis = true;
            this.lblKhuyenMaiInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKhuyenMaiInfo.ForeColor = System.Drawing.Color.FromArgb(160, 160, 170);
            this.lblKhuyenMaiInfo.Location = new System.Drawing.Point(26, 208);
            this.lblKhuyenMaiInfo.Name = "lblKhuyenMaiInfo";
            this.lblKhuyenMaiInfo.Size = new System.Drawing.Size(500, 22);
            this.lblKhuyenMaiInfo.Text = "Khuyến mãi sản phẩm: theo giá hiện tại";

            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(205, 205, 212);
            this.label4.Location = new System.Drawing.Point(26, 244);
            this.label4.Name = "label4";
            this.label4.Text = "GIẢM GIÁ / VOUCHER";

            this.cmb_giamgia.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.cmb_giamgia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmb_giamgia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_giamgia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_giamgia.ForeColor = System.Drawing.Color.White;
            this.cmb_giamgia.Location = new System.Drawing.Point(26, 270);
            this.cmb_giamgia.Name = "cmb_giamgia";
            this.cmb_giamgia.Size = new System.Drawing.Size(335, 31);
            this.cmb_giamgia.TabIndex = 10;

            this.btn_giamgia.BackColor = System.Drawing.Color.FromArgb(35, 35, 39);
            this.btn_giamgia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(70, 70, 76);
            this.btn_giamgia.FlatAppearance.BorderSize = 1;
            this.btn_giamgia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_giamgia.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btn_giamgia.ForeColor = System.Drawing.Color.FromArgb(225, 225, 230);
            this.btn_giamgia.Location = new System.Drawing.Point(371, 269);
            this.btn_giamgia.Size = new System.Drawing.Size(125, 36);
            this.btn_giamgia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_giamgia.UseVisualStyleBackColor = false;
            this.btn_giamgia.Name = "btn_giamgia";
            this.btn_giamgia.Text = "ÁP DỤNG";

            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(205, 205, 212);
            this.label5.Location = new System.Drawing.Point(26, 314);
            this.label5.Name = "label5";
            this.label5.Text = "VẬN CHUYỂN";

            this.cmb_vanchuyen.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.cmb_vanchuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_vanchuyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_vanchuyen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_vanchuyen.ForeColor = System.Drawing.Color.White;
            this.cmb_vanchuyen.Items.AddRange(new object[] {
                "Tiêu chuẩn • 30.000 Đ",
                "Nhanh • 40.000 Đ"});
            this.cmb_vanchuyen.Location = new System.Drawing.Point(26, 340);
            this.cmb_vanchuyen.Name = "cmb_vanchuyen";
            this.cmb_vanchuyen.Size = new System.Drawing.Size(335, 31);
            this.cmb_vanchuyen.TabIndex = 11;

            this.btn_vanchuyen.BackColor = System.Drawing.Color.FromArgb(35, 35, 39);
            this.btn_vanchuyen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(70, 70, 76);
            this.btn_vanchuyen.FlatAppearance.BorderSize = 1;
            this.btn_vanchuyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_vanchuyen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btn_vanchuyen.ForeColor = System.Drawing.Color.FromArgb(225, 225, 230);
            this.btn_vanchuyen.Location = new System.Drawing.Point(371, 339);
            this.btn_vanchuyen.Size = new System.Drawing.Size(125, 36);
            this.btn_vanchuyen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_vanchuyen.UseVisualStyleBackColor = false;
            this.btn_vanchuyen.Name = "btn_vanchuyen";
            this.btn_vanchuyen.Text = "ÁP DỤNG";

            this.lblPhiVanChuyen.AutoSize = true;
            this.lblPhiVanChuyen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhiVanChuyen.ForeColor = System.Drawing.Color.FromArgb(190, 190, 198);
            this.lblPhiVanChuyen.Location = new System.Drawing.Point(26, 377);
            this.lblPhiVanChuyen.Name = "lblPhiVanChuyen";
            this.lblPhiVanChuyen.Text = "Vận chuyển: 0 Đ";

            this.lblDiaChiNhan.AutoSize = true;
            this.lblDiaChiNhan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDiaChiNhan.ForeColor = System.Drawing.Color.White;
            this.lblDiaChiNhan.Location = new System.Drawing.Point(26, 410);
            this.lblDiaChiNhan.Name = "lblDiaChiNhan";
            this.lblDiaChiNhan.Text = "📍 ĐỊA CHỈ NHẬN HÀNG";

            this.lblDiaChiValue.AutoEllipsis = false;
            this.lblDiaChiValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiaChiValue.ForeColor = System.Drawing.Color.FromArgb(185, 185, 195);
            this.lblDiaChiValue.Location = new System.Drawing.Point(26, 435);
            this.lblDiaChiValue.Name = "lblDiaChiValue";
            this.lblDiaChiValue.Size = new System.Drawing.Size(500, 55);
            this.lblDiaChiValue.Text = "Chưa có địa chỉ.";

            this.lblPhuongThuc.AutoSize = true;
            this.lblPhuongThuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPhuongThuc.ForeColor = System.Drawing.Color.White;
            this.lblPhuongThuc.Location = new System.Drawing.Point(26, 505);
            this.lblPhuongThuc.Name = "lblPhuongThuc";
            this.lblPhuongThuc.Text = "PHƯƠNG THỨC THANH TOÁN";

            this.rdoThe.AutoSize = true;
            this.rdoThe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rdoThe.ForeColor = System.Drawing.Color.FromArgb(220, 220, 225);
            this.rdoThe.Location = new System.Drawing.Point(26, 535);
            this.rdoThe.Name = "rdoThe";
            this.rdoThe.Text = "💳 Thẻ";
            this.rdoThe.UseVisualStyleBackColor = true;

            this.rdoChuyenKhoan.AutoSize = true;
            this.rdoChuyenKhoan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rdoChuyenKhoan.ForeColor = System.Drawing.Color.FromArgb(220, 220, 225);
            this.rdoChuyenKhoan.Location = new System.Drawing.Point(145, 535);
            this.rdoChuyenKhoan.Name = "rdoChuyenKhoan";
            this.rdoChuyenKhoan.Text = "🏦 Chuyển khoản";
            this.rdoChuyenKhoan.UseVisualStyleBackColor = true;

            this.rdoViDienTu.AutoSize = true;
            this.rdoViDienTu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rdoViDienTu.ForeColor = System.Drawing.Color.FromArgb(220, 220, 225);
            this.rdoViDienTu.Location = new System.Drawing.Point(305, 535);
            this.rdoViDienTu.Name = "rdoViDienTu";
            this.rdoViDienTu.Text = "💰 Ví điện tử";
            this.rdoViDienTu.UseVisualStyleBackColor = true;

            this.label7.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(255, 75, 90);
            this.label7.Location = new System.Drawing.Point(26, 579);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(500, 42);
            this.label7.Text = "TỔNG: 0 Đ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.btn_thanhtoan.BackColor = System.Drawing.Color.FromArgb(220, 30, 45);
            this.btn_thanhtoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_thanhtoan.FlatAppearance.BorderSize = 0;
            this.btn_thanhtoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_thanhtoan.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btn_thanhtoan.ForeColor = System.Drawing.Color.White;
            this.btn_thanhtoan.Location = new System.Drawing.Point(26, 636);
            this.btn_thanhtoan.Name = "btn_thanhtoan";
            this.btn_thanhtoan.Size = new System.Drawing.Size(500, 58);
            this.btn_thanhtoan.TabIndex = 15;
            this.btn_thanhtoan.Text = "THANH TOÁN & ĐẶT ĐƠN";
            this.btn_thanhtoan.UseVisualStyleBackColor = false;

            this.btn_dong.BackColor = System.Drawing.Color.FromArgb(35, 35, 39);
            this.btn_dong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_dong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(75, 75, 82);
            this.btn_dong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dong.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn_dong.ForeColor = System.Drawing.Color.White;
            this.btn_dong.Location = new System.Drawing.Point(26, 714);
            this.btn_dong.Name = "btn_dong";
            this.btn_dong.Size = new System.Drawing.Size(500, 44);
            this.btn_dong.TabIndex = 16;
            this.btn_dong.Text = "ĐÓNG GIỎ HÀNG";
            this.btn_dong.UseVisualStyleBackColor = false;

            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_giohang)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panel3, panel1;
        private System.Windows.Forms.Label label3, label4, label5, label7, label1, label2;
        private System.Windows.Forms.Label lblKHValue, lblHangDiem, lblViInfo, lblVoucherInfo, lblKhuyenMaiInfo, lblPhiVanChuyen, lblPhuongThuc, lblDiaChiNhan, lblDiaChiValue;
        private System.Windows.Forms.Button btn_thongTinKH, btn_doiDiaChi, btn_moVi, btn_vanchuyen, btn_giamgia, btn_thanhtoan, btn_xoa, btn_dong;
        private System.Windows.Forms.ComboBox cmb_vanchuyen, cmb_giamgia;
        private System.Windows.Forms.RadioButton rdoThe, rdoChuyenKhoan, rdoViDienTu;
        private System.Windows.Forms.DataGridView dgv_giohang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1, Column2, Column3, Column4, Column5, Column6;
    }
}

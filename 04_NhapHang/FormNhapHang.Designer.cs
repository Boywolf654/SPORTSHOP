namespace SPORTSHOP._04_NhapHang
{
    partial class FormNhapHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMaPhieuHuongDan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_NhaCungCap = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmb_Kho = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_NhanVien = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtp_NgayNhap = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.GNc_ChoDuyet = new Guna.UI2.WinForms.Guna2Chip();
            this.guna2Separator4 = new Guna.UI2.WinForms.Guna2Separator();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.lblThanhTien2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblThanhTien1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btn_timSP = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgv_SanPham = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btn_ThemPhieu = new Guna.UI2.WinForms.Guna2Button();
            this.dgv_chitietSP = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btn_xoadong = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chitietSP)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(24, 12);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(206, 33);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Phiếu nhập hàng";
            // 
            // lblMaPhieuHuongDan
            // 
            this.lblMaPhieuHuongDan.BackColor = System.Drawing.Color.Transparent;
            this.lblMaPhieuHuongDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhieuHuongDan.Location = new System.Drawing.Point(24, 51);
            this.lblMaPhieuHuongDan.Name = "lblMaPhieuHuongDan";
            this.lblMaPhieuHuongDan.Size = new System.Drawing.Size(272, 27);
            this.lblMaPhieuHuongDan.TabIndex = 0;
            this.lblMaPhieuHuongDan.Text = "Mã phiếu tự sinh sau khi lưu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(633, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhà cung cấp";
            // 
            // cmb_NhaCungCap
            // 
            this.cmb_NhaCungCap.BackColor = System.Drawing.Color.Transparent;
            this.cmb_NhaCungCap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_NhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_NhaCungCap.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_NhaCungCap.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_NhaCungCap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_NhaCungCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmb_NhaCungCap.ItemHeight = 30;
            this.cmb_NhaCungCap.Location = new System.Drawing.Point(633, 108);
            this.cmb_NhaCungCap.Name = "cmb_NhaCungCap";
            this.cmb_NhaCungCap.Size = new System.Drawing.Size(191, 36);
            this.cmb_NhaCungCap.TabIndex = 2;
            // 
            // cmb_Kho
            // 
            this.cmb_Kho.BackColor = System.Drawing.Color.Transparent;
            this.cmb_Kho.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_Kho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Kho.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_Kho.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_Kho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_Kho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmb_Kho.ItemHeight = 30;
            this.cmb_Kho.Location = new System.Drawing.Point(914, 109);
            this.cmb_Kho.Name = "cmb_Kho";
            this.cmb_Kho.Size = new System.Drawing.Size(252, 36);
            this.cmb_Kho.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(911, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kho nhận hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(633, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nhân viên lập phiếu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(911, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ngày nhập";
            // 
            // cmb_NhanVien
            // 
            this.cmb_NhanVien.BackColor = System.Drawing.Color.Transparent;
            this.cmb_NhanVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_NhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_NhanVien.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_NhanVien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_NhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_NhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmb_NhanVien.ItemHeight = 30;
            this.cmb_NhanVien.Location = new System.Drawing.Point(633, 181);
            this.cmb_NhanVien.Name = "cmb_NhanVien";
            this.cmb_NhanVien.Size = new System.Drawing.Size(191, 36);
            this.cmb_NhanVien.TabIndex = 2;
            // 
            // dtp_NgayNhap
            // 
            this.dtp_NgayNhap.BorderColor = System.Drawing.Color.LightGray;
            this.dtp_NgayNhap.Checked = true;
            this.dtp_NgayNhap.FillColor = System.Drawing.Color.White;
            this.dtp_NgayNhap.FocusedColor = System.Drawing.Color.White;
            this.dtp_NgayNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_NgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtp_NgayNhap.Location = new System.Drawing.Point(914, 181);
            this.dtp_NgayNhap.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_NgayNhap.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_NgayNhap.Name = "dtp_NgayNhap";
            this.dtp_NgayNhap.Size = new System.Drawing.Size(252, 35);
            this.dtp_NgayNhap.TabIndex = 3;
            this.dtp_NgayNhap.Value = new System.DateTime(2026, 8, 21, 9, 9, 23, 951);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(602, 240);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(187, 31);
            this.guna2HtmlLabel3.TabIndex = 0;
            this.guna2HtmlLabel3.Text = "Chi tiết sản phẩm";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.Gainsboro;
            this.guna2Separator1.Location = new System.Drawing.Point(602, 223);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(506, 21);
            this.guna2Separator1.TabIndex = 6;
            // 
            // GNc_ChoDuyet
            // 
            this.GNc_ChoDuyet.BackColor = System.Drawing.Color.Transparent;
            this.GNc_ChoDuyet.BorderRadius = 15;
            this.GNc_ChoDuyet.BorderThickness = 0;
            this.GNc_ChoDuyet.Enabled = false;
            this.GNc_ChoDuyet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(237)))), ((int)(((byte)(203)))));
            this.GNc_ChoDuyet.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.GNc_ChoDuyet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(110)))), ((int)(((byte)(0)))));
            this.GNc_ChoDuyet.IsClosable = false;
            this.GNc_ChoDuyet.Location = new System.Drawing.Point(1089, 12);
            this.GNc_ChoDuyet.Name = "GNc_ChoDuyet";
            this.GNc_ChoDuyet.Size = new System.Drawing.Size(130, 40);
            this.GNc_ChoDuyet.TabIndex = 7;
            this.GNc_ChoDuyet.Text = "chipTrangThai";
            // 
            // guna2Separator4
            // 
            this.guna2Separator4.FillColor = System.Drawing.Color.Gainsboro;
            this.guna2Separator4.Location = new System.Drawing.Point(9, 574);
            this.guna2Separator4.Name = "guna2Separator4";
            this.guna2Separator4.Size = new System.Drawing.Size(1126, 10);
            this.guna2Separator4.TabIndex = 6;
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 12;
            this.btnLuu.BorderThickness = 1;
            this.btnLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuu.FillColor = System.Drawing.Color.Transparent;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLuu.ForeColor = System.Drawing.Color.Black;
            this.btnLuu.Location = new System.Drawing.Point(233, 702);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(128, 36);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu Phiếu";
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 12;
            this.btnHuy.BorderThickness = 1;
            this.btnHuy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHuy.FillColor = System.Drawing.Color.Transparent;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHuy.ForeColor = System.Drawing.Color.Black;
            this.btnHuy.Location = new System.Drawing.Point(691, 702);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(128, 36);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Hủy";
            // 
            // lblThanhTien2
            // 
            this.lblThanhTien2.BackColor = System.Drawing.Color.Transparent;
            this.lblThanhTien2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThanhTien2.Location = new System.Drawing.Point(49, 653);
            this.lblThanhTien2.Name = "lblThanhTien2";
            this.lblThanhTien2.Size = new System.Drawing.Size(169, 24);
            this.lblThanhTien2.TabIndex = 10;
            this.lblThanhTien2.Text = "Thành tiền: 0 VNĐ";
            // 
            // lblThanhTien1
            // 
            this.lblThanhTien1.BackColor = System.Drawing.Color.Transparent;
            this.lblThanhTien1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThanhTien1.Location = new System.Drawing.Point(49, 603);
            this.lblThanhTien1.Name = "lblThanhTien1";
            this.lblThanhTien1.Size = new System.Drawing.Size(95, 24);
            this.lblThanhTien1.TabIndex = 10;
            this.lblThanhTien1.Text = "Tổng Tiền";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(31, 94);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(113, 31);
            this.guna2HtmlLabel2.TabIndex = 0;
            this.guna2HtmlLabel2.Text = "Sản Phẩm";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(31, 131);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(101, 20);
            this.guna2HtmlLabel4.TabIndex = 0;
            this.guna2HtmlLabel4.Text = "Tìm Sản Phẩm";
            // 
            // btn_timSP
            // 
            this.btn_timSP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btn_timSP.DefaultText = "";
            this.btn_timSP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.btn_timSP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btn_timSP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.btn_timSP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.btn_timSP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btn_timSP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_timSP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btn_timSP.Location = new System.Drawing.Point(29, 162);
            this.btn_timSP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_timSP.Name = "btn_timSP";
            this.btn_timSP.PlaceholderText = "Tìm Sản Phẩm....";
            this.btn_timSP.SelectedText = "";
            this.btn_timSP.Size = new System.Drawing.Size(350, 32);
            this.btn_timSP.TabIndex = 11;
            // 
            // dgv_SanPham
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_SanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_SanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_SanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_SanPham.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_SanPham.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_SanPham.Location = new System.Drawing.Point(29, 220);
            this.dgv_SanPham.Name = "dgv_SanPham";
            this.dgv_SanPham.RowHeadersVisible = false;
            this.dgv_SanPham.RowHeadersWidth = 51;
            this.dgv_SanPham.RowTemplate.Height = 24;
            this.dgv_SanPham.Size = new System.Drawing.Size(525, 264);
            this.dgv_SanPham.TabIndex = 12;
            this.dgv_SanPham.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_SanPham.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgv_SanPham.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SanPham.ThemeStyle.HeaderStyle.Height = 4;
            this.dgv_SanPham.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgv_SanPham.ThemeStyle.RowsStyle.Height = 24;
            // 
            // btn_ThemPhieu
            // 
            this.btn_ThemPhieu.BorderRadius = 12;
            this.btn_ThemPhieu.BorderThickness = 1;
            this.btn_ThemPhieu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThemPhieu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThemPhieu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_ThemPhieu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_ThemPhieu.FillColor = System.Drawing.Color.Transparent;
            this.btn_ThemPhieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_ThemPhieu.ForeColor = System.Drawing.Color.Black;
            this.btn_ThemPhieu.Location = new System.Drawing.Point(31, 516);
            this.btn_ThemPhieu.Name = "btn_ThemPhieu";
            this.btn_ThemPhieu.Size = new System.Drawing.Size(164, 36);
            this.btn_ThemPhieu.TabIndex = 8;
            this.btn_ThemPhieu.Text = "Thêm Vào Phiếu";
            // 
            // dgv_chitietSP
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgv_chitietSP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_chitietSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_chitietSP.ColumnHeadersHeight = 4;
            this.dgv_chitietSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_chitietSP.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_chitietSP.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_chitietSP.Location = new System.Drawing.Point(602, 277);
            this.dgv_chitietSP.Name = "dgv_chitietSP";
            this.dgv_chitietSP.RowHeadersVisible = false;
            this.dgv_chitietSP.RowHeadersWidth = 51;
            this.dgv_chitietSP.RowTemplate.Height = 24;
            this.dgv_chitietSP.Size = new System.Drawing.Size(576, 207);
            this.dgv_chitietSP.TabIndex = 12;
            this.dgv_chitietSP.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_chitietSP.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgv_chitietSP.ThemeStyle.HeaderStyle.Height = 4;
            this.dgv_chitietSP.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgv_chitietSP.ThemeStyle.RowsStyle.Height = 24;
            // 
            // btn_xoadong
            // 
            this.btn_xoadong.BorderRadius = 12;
            this.btn_xoadong.BorderThickness = 1;
            this.btn_xoadong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_xoadong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_xoadong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_xoadong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_xoadong.FillColor = System.Drawing.Color.Transparent;
            this.btn_xoadong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_xoadong.ForeColor = System.Drawing.Color.Black;
            this.btn_xoadong.Location = new System.Drawing.Point(602, 516);
            this.btn_xoadong.Name = "btn_xoadong";
            this.btn_xoadong.Size = new System.Drawing.Size(128, 36);
            this.btn_xoadong.TabIndex = 8;
            this.btn_xoadong.Text = "- Xóa Dòng";
            // 
            // FormNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 750);
            this.Controls.Add(this.dgv_chitietSP);
            this.Controls.Add(this.dgv_SanPham);
            this.Controls.Add(this.btn_timSP);
            this.Controls.Add(this.lblThanhTien1);
            this.Controls.Add(this.lblThanhTien2);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btn_ThemPhieu);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btn_xoadong);
            this.Controls.Add(this.GNc_ChoDuyet);
            this.Controls.Add(this.guna2Separator4);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.dtp_NgayNhap);
            this.Controls.Add(this.cmb_NhanVien);
            this.Controls.Add(this.cmb_Kho);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_NhaCungCap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMaPhieuHuongDan);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Name = "FormNhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormNhapHang";
            this.Load += new System.EventHandler(this.FormNhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chitietSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMaPhieuHuongDan;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmb_NhaCungCap;
        private Guna.UI2.WinForms.Guna2ComboBox cmb_Kho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cmb_NhanVien;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_NgayNhap;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Chip GNc_ChoDuyet;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator4;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblThanhTien2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblThanhTien1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2TextBox btn_timSP;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_SanPham;
        private Guna.UI2.WinForms.Guna2Button btn_ThemPhieu;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_chitietSP;
        private Guna.UI2.WinForms.Guna2Button btn_xoadong;
    }
}
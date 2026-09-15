namespace SPORTSHOP._03_QuanLyKho
{
    partial class FormTonKho
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnGiaTriTonKho = new Guna.UI2.WinForms.Guna2Button();
            this.btnHetHang = new Guna.UI2.WinForms.Guna2Button();
            this.btnSapHetHang = new Guna.UI2.WinForms.Guna2Button();
            this.btnTongSanPham = new Guna.UI2.WinForms.Guna2Button();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbDanhMuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvTonKho = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Orange;
            this.guna2Panel1.Controls.Add(this.btnGiaTriTonKho);
            this.guna2Panel1.Controls.Add(this.btnHetHang);
            this.guna2Panel1.Controls.Add(this.btnSapHetHang);
            this.guna2Panel1.Controls.Add(this.btnTongSanPham);
            this.guna2Panel1.Location = new System.Drawing.Point(22, 83);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(757, 123);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnGiaTriTonKho
            // 
            this.btnGiaTriTonKho.BorderRadius = 5;
            this.btnGiaTriTonKho.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGiaTriTonKho.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGiaTriTonKho.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGiaTriTonKho.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGiaTriTonKho.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGiaTriTonKho.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGiaTriTonKho.ForeColor = System.Drawing.Color.White;
            this.btnGiaTriTonKho.Location = new System.Drawing.Point(562, 15);
            this.btnGiaTriTonKho.Name = "btnGiaTriTonKho";
            this.btnGiaTriTonKho.Padding = new System.Windows.Forms.Padding(0, 0, 0, 40);
            this.btnGiaTriTonKho.Size = new System.Drawing.Size(162, 90);
            this.btnGiaTriTonKho.TabIndex = 0;
            this.btnGiaTriTonKho.Text = "Giá Trị Tồn Kho";
            // 
            // btnHetHang
            // 
            this.btnHetHang.BorderRadius = 5;
            this.btnHetHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHetHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHetHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHetHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHetHang.FillColor = System.Drawing.Color.Brown;
            this.btnHetHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHetHang.ForeColor = System.Drawing.Color.White;
            this.btnHetHang.Location = new System.Drawing.Point(381, 15);
            this.btnHetHang.Name = "btnHetHang";
            this.btnHetHang.Padding = new System.Windows.Forms.Padding(0, 0, 0, 40);
            this.btnHetHang.Size = new System.Drawing.Size(162, 90);
            this.btnHetHang.TabIndex = 0;
            this.btnHetHang.Text = "Hết Hàng";
            // 
            // btnSapHetHang
            // 
            this.btnSapHetHang.BorderRadius = 5;
            this.btnSapHetHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSapHetHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSapHetHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSapHetHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSapHetHang.FillColor = System.Drawing.Color.PaleGoldenrod;
            this.btnSapHetHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSapHetHang.ForeColor = System.Drawing.Color.White;
            this.btnSapHetHang.Location = new System.Drawing.Point(202, 15);
            this.btnSapHetHang.Name = "btnSapHetHang";
            this.btnSapHetHang.Padding = new System.Windows.Forms.Padding(0, 0, 0, 40);
            this.btnSapHetHang.Size = new System.Drawing.Size(162, 90);
            this.btnSapHetHang.TabIndex = 0;
            this.btnSapHetHang.Text = "Sắp Hết Hàng";
            // 
            // btnTongSanPham
            // 
            this.btnTongSanPham.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnTongSanPham.BorderRadius = 5;
            this.btnTongSanPham.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTongSanPham.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTongSanPham.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTongSanPham.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTongSanPham.FillColor = System.Drawing.Color.Black;
            this.btnTongSanPham.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTongSanPham.ForeColor = System.Drawing.Color.White;
            this.btnTongSanPham.Location = new System.Drawing.Point(24, 15);
            this.btnTongSanPham.Name = "btnTongSanPham";
            this.btnTongSanPham.Padding = new System.Windows.Forms.Padding(0, 0, 0, 40);
            this.btnTongSanPham.Size = new System.Drawing.Size(162, 90);
            this.btnTongSanPham.TabIndex = 0;
            this.btnTongSanPham.Text = "Tổng Sản Phẩm";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderRadius = 4;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Location = new System.Drawing.Point(46, 223);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "  🔍 Tìm sản phẩm...    ";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(340, 36);
            this.txtTimKiem.TabIndex = 1;
            // 
            // cmbDanhMuc
            // 
            this.cmbDanhMuc.BackColor = System.Drawing.Color.Transparent;
            this.cmbDanhMuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDanhMuc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbDanhMuc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbDanhMuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDanhMuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbDanhMuc.ItemHeight = 30;
            this.cmbDanhMuc.Location = new System.Drawing.Point(403, 223);
            this.cmbDanhMuc.Name = "cmbDanhMuc";
            this.cmbDanhMuc.Size = new System.Drawing.Size(144, 36);
            this.cmbDanhMuc.TabIndex = 2;
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.cmbTrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangThai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTrangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbTrangThai.ItemHeight = 30;
            this.cmbTrangThai.Location = new System.Drawing.Point(571, 223);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(112, 36);
            this.cmbTrangThai.TabIndex = 2;
            // 
            // dgvTonKho
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvTonKho.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTonKho.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTonKho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTonKho.ColumnHeadersHeight = 35;
            this.dgvTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTonKho.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTonKho.GridColor = System.Drawing.Color.DarkGray;
            this.dgvTonKho.Location = new System.Drawing.Point(22, 282);
            this.dgvTonKho.Name = "dgvTonKho";
            this.dgvTonKho.RowHeadersVisible = false;
            this.dgvTonKho.RowHeadersWidth = 51;
            this.dgvTonKho.RowTemplate.Height = 24;
            this.dgvTonKho.Size = new System.Drawing.Size(757, 224);
            this.dgvTonKho.TabIndex = 3;
            this.dgvTonKho.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTonKho.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTonKho.ThemeStyle.GridColor = System.Drawing.Color.DarkGray;
            this.dgvTonKho.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvTonKho.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvTonKho.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvTonKho.ThemeStyle.RowsStyle.Height = 24;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(233, 27);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(332, 31);
            this.guna2HtmlLabel1.TabIndex = 4;
            this.guna2HtmlLabel1.Text = "FORM QUẢN LÝ TỒN KHO";
            // 
            // FormTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuText;
            this.ClientSize = new System.Drawing.Size(800, 556);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.dgvTonKho);
            this.Controls.Add(this.cmbTrangThai);
            this.Controls.Add(this.cmbDanhMuc);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "FormTonKho";
            this.Text = "FormTonKho";
            this.Load += new System.EventHandler(this.FormTonKho_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnTongSanPham;
        private Guna.UI2.WinForms.Guna2Button btnGiaTriTonKho;
        private Guna.UI2.WinForms.Guna2Button btnHetHang;
        private Guna.UI2.WinForms.Guna2Button btnSapHetHang;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2ComboBox cmbDanhMuc;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTrangThai;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTonKho;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}
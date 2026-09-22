namespace SPORTSHOP._03_QuanLyKho
{
    partial class FormTonKho
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTieuDe;
        private Guna.UI2.WinForms.Guna2Panel pnlThongKe;
        private Guna.UI2.WinForms.Guna2Button btnTongSanPham;
        private Guna.UI2.WinForms.Guna2Button btnSapHetHang;
        private Guna.UI2.WinForms.Guna2Button btnHetHang;
        private Guna.UI2.WinForms.Guna2Button btnGiaTriTonKho;
        private Guna.UI2.WinForms.Guna2Panel pnlLoc;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2ComboBox cmbKho;
        private Guna.UI2.WinForms.Guna2ComboBox cmbDanhMuc;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTrangThai;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTonKho;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTieuDe = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlThongKe = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTongSanPham = new Guna.UI2.WinForms.Guna2Button();
            this.btnSapHetHang = new Guna.UI2.WinForms.Guna2Button();
            this.btnHetHang = new Guna.UI2.WinForms.Guna2Button();
            this.btnGiaTriTonKho = new Guna.UI2.WinForms.Guna2Button();
            this.pnlLoc = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbKho = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbDanhMuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.dgvTonKho = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlThongKe.SuspendLayout();
            this.pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(30, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(326, 43);
            this.lblTieuDe.TabIndex = 3;
            this.lblTieuDe.Text = "📦 QUẢN LÝ TỒN KHO";
            // 
            // pnlThongKe
            // 
            this.pnlThongKe.BorderRadius = 12;
            this.pnlThongKe.Controls.Add(this.btnTongSanPham);
            this.pnlThongKe.Controls.Add(this.btnSapHetHang);
            this.pnlThongKe.Controls.Add(this.btnHetHang);
            this.pnlThongKe.Controls.Add(this.btnGiaTriTonKho);
            this.pnlThongKe.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(42)))));
            this.pnlThongKe.Location = new System.Drawing.Point(28, 72);
            this.pnlThongKe.Name = "pnlThongKe";
            this.pnlThongKe.Size = new System.Drawing.Size(1240, 105);
            this.pnlThongKe.TabIndex = 2;
            // 
            // btnTongSanPham
            // 
            this.btnTongSanPham.BorderRadius = 10;
            this.btnTongSanPham.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.btnTongSanPham.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnTongSanPham.ForeColor = System.Drawing.Color.White;
            this.btnTongSanPham.Location = new System.Drawing.Point(18, 12);
            this.btnTongSanPham.Name = "btnTongSanPham";
            this.btnTongSanPham.Size = new System.Drawing.Size(285, 80);
            this.btnTongSanPham.TabIndex = 0;
            this.btnTongSanPham.Text = "📦 Tổng biến thể\n0";
            // 
            // btnSapHetHang
            // 
            this.btnSapHetHang.BorderRadius = 10;
            this.btnSapHetHang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(105)))), ((int)(((byte)(25)))));
            this.btnSapHetHang.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnSapHetHang.ForeColor = System.Drawing.Color.White;
            this.btnSapHetHang.Location = new System.Drawing.Point(322, 12);
            this.btnSapHetHang.Name = "btnSapHetHang";
            this.btnSapHetHang.Size = new System.Drawing.Size(285, 80);
            this.btnSapHetHang.TabIndex = 1;
            this.btnSapHetHang.Text = "⚠ Sắp hết hàng\n0";
            // 
            // btnHetHang
            // 
            this.btnHetHang.BorderRadius = 10;
            this.btnHetHang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnHetHang.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnHetHang.ForeColor = System.Drawing.Color.White;
            this.btnHetHang.Location = new System.Drawing.Point(626, 12);
            this.btnHetHang.Name = "btnHetHang";
            this.btnHetHang.Size = new System.Drawing.Size(285, 80);
            this.btnHetHang.TabIndex = 2;
            this.btnHetHang.Text = "⛔ Hết hàng\n0";
            // 
            // btnGiaTriTonKho
            // 
            this.btnGiaTriTonKho.BorderRadius = 10;
            this.btnGiaTriTonKho.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(85)))), ((int)(((byte)(65)))));
            this.btnGiaTriTonKho.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnGiaTriTonKho.ForeColor = System.Drawing.Color.White;
            this.btnGiaTriTonKho.Location = new System.Drawing.Point(930, 12);
            this.btnGiaTriTonKho.Name = "btnGiaTriTonKho";
            this.btnGiaTriTonKho.Size = new System.Drawing.Size(285, 80);
            this.btnGiaTriTonKho.TabIndex = 3;
            this.btnGiaTriTonKho.Text = "💰 Giá trị vốn tồn\n0";
            // 
            // pnlLoc
            // 
            this.pnlLoc.BorderRadius = 12;
            this.pnlLoc.Controls.Add(this.txtTimKiem);
            this.pnlLoc.Controls.Add(this.cmbKho);
            this.pnlLoc.Controls.Add(this.cmbDanhMuc);
            this.pnlLoc.Controls.Add(this.cmbTrangThai);
            this.pnlLoc.Controls.Add(this.btnLamMoi);
            this.pnlLoc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(42)))));
            this.pnlLoc.Location = new System.Drawing.Point(28, 190);
            this.pnlLoc.Name = "pnlLoc";
            this.pnlLoc.Size = new System.Drawing.Size(1240, 82);
            this.pnlLoc.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderRadius = 8;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(18, 20);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "🔍 Tìm tên sản phẩm hoặc SKU...";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(310, 42);
            this.txtTimKiem.TabIndex = 0;
            // 
            // cmbKho
            // 
            this.cmbKho.BackColor = System.Drawing.Color.Transparent;
            this.cmbKho.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKho.FocusedColor = System.Drawing.Color.Empty;
            this.cmbKho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbKho.ItemHeight = 30;
            this.cmbKho.Location = new System.Drawing.Point(345, 20);
            this.cmbKho.Name = "cmbKho";
            this.cmbKho.Size = new System.Drawing.Size(210, 36);
            this.cmbKho.TabIndex = 1;
            // 
            // cmbDanhMuc
            // 
            this.cmbDanhMuc.BackColor = System.Drawing.Color.Transparent;
            this.cmbDanhMuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDanhMuc.FocusedColor = System.Drawing.Color.Empty;
            this.cmbDanhMuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDanhMuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbDanhMuc.ItemHeight = 30;
            this.cmbDanhMuc.Location = new System.Drawing.Point(570, 20);
            this.cmbDanhMuc.Name = "cmbDanhMuc";
            this.cmbDanhMuc.Size = new System.Drawing.Size(210, 36);
            this.cmbDanhMuc.TabIndex = 2;
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.cmbTrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangThai.FocusedColor = System.Drawing.Color.Empty;
            this.cmbTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbTrangThai.ItemHeight = 30;
            this.cmbTrangThai.Location = new System.Drawing.Point(795, 20);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(190, 36);
            this.cmbTrangThai.TabIndex = 3;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BorderRadius = 8;
            this.btnLamMoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(88)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(1000, 20);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(220, 42);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "🔄 LÀM MỚI";
            // 
            // dgvTonKho
            // 
            this.dgvTonKho.AllowUserToAddRows = false;
            this.dgvTonKho.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTonKho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTonKho.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTonKho.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTonKho.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTonKho.Location = new System.Drawing.Point(28, 285);
            this.dgvTonKho.MultiSelect = false;
            this.dgvTonKho.Name = "dgvTonKho";
            this.dgvTonKho.ReadOnly = true;
            this.dgvTonKho.RowHeadersVisible = false;
            this.dgvTonKho.RowHeadersWidth = 51;
            this.dgvTonKho.RowTemplate.Height = 34;
            this.dgvTonKho.Size = new System.Drawing.Size(1240, 430);
            this.dgvTonKho.TabIndex = 0;
            this.dgvTonKho.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvTonKho.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTonKho.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvTonKho.ThemeStyle.ReadOnly = true;
            this.dgvTonKho.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvTonKho.ThemeStyle.RowsStyle.Height = 34;
            // 
            // FormTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1300, 740);
            this.Controls.Add(this.dgvTonKho);
            this.Controls.Add(this.pnlLoc);
            this.Controls.Add(this.pnlThongKe);
            this.Controls.Add(this.lblTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTonKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tồn kho";
            this.Load += new System.EventHandler(this.FormTonKho_Load);
            this.pnlThongKe.ResumeLayout(false);
            this.pnlLoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
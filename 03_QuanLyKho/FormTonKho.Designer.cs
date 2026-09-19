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
            this.components = new System.ComponentModel.Container();
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

            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(30, 20);
            this.lblTieuDe.Size = new System.Drawing.Size(370, 42);
            this.lblTieuDe.Text = "📦 QUẢN LÝ TỒN KHO";

            this.pnlThongKe.BorderRadius = 12;
            this.pnlThongKe.FillColor = System.Drawing.Color.FromArgb(38, 38, 42);
            this.pnlThongKe.Location = new System.Drawing.Point(28, 72);
            this.pnlThongKe.Size = new System.Drawing.Size(1240, 105);

            // ===== CARD 1 =====
            this.btnTongSanPham.BorderRadius = 10;
            this.btnTongSanPham.FillColor = System.Drawing.Color.FromArgb(45, 45, 50);
            this.btnTongSanPham.Font = new System.Drawing.Font(
                "Segoe UI", 10.5F,
                System.Drawing.FontStyle.Bold);
            this.btnTongSanPham.ForeColor = System.Drawing.Color.White;
            this.btnTongSanPham.Location = new System.Drawing.Point(18, 12);
            this.btnTongSanPham.Size = new System.Drawing.Size(285, 80);
            this.btnTongSanPham.Text = "📦 Tổng biến thể\n0";

            // ===== CARD 2 =====
            this.btnSapHetHang.BorderRadius = 10;
            this.btnSapHetHang.FillColor = System.Drawing.Color.FromArgb(130, 105, 25);
            this.btnSapHetHang.Font = new System.Drawing.Font(
                "Segoe UI", 10.5F,
                System.Drawing.FontStyle.Bold);
            this.btnSapHetHang.ForeColor = System.Drawing.Color.White;
            this.btnSapHetHang.Location = new System.Drawing.Point(322, 12);
            this.btnSapHetHang.Size = new System.Drawing.Size(285, 80);
            this.btnSapHetHang.Text = "⚠ Sắp hết hàng\n0";

            // ===== CARD 3 =====
            this.btnHetHang.BorderRadius = 10;
            this.btnHetHang.FillColor = System.Drawing.Color.FromArgb(120, 55, 55);
            this.btnHetHang.Font = new System.Drawing.Font(
                "Segoe UI", 10.5F,
                System.Drawing.FontStyle.Bold);
            this.btnHetHang.ForeColor = System.Drawing.Color.White;
            this.btnHetHang.Location = new System.Drawing.Point(626, 12);
            this.btnHetHang.Size = new System.Drawing.Size(285, 80);
            this.btnHetHang.Text = "⛔ Hết hàng\n0";

            // ===== CARD 4 =====
            this.btnGiaTriTonKho.BorderRadius = 10;
            this.btnGiaTriTonKho.FillColor = System.Drawing.Color.FromArgb(45, 85, 65);
            this.btnGiaTriTonKho.Font = new System.Drawing.Font(
                "Segoe UI", 10.5F,
                System.Drawing.FontStyle.Bold);
            this.btnGiaTriTonKho.ForeColor = System.Drawing.Color.White;
            this.btnGiaTriTonKho.Location = new System.Drawing.Point(930, 12);
            this.btnGiaTriTonKho.Size = new System.Drawing.Size(285, 80);
            this.btnGiaTriTonKho.Text = "💰 Giá trị vốn tồn\n0";

            this.pnlThongKe.Controls.Add(this.btnTongSanPham);
            this.pnlThongKe.Controls.Add(this.btnSapHetHang);
            this.pnlThongKe.Controls.Add(this.btnHetHang);
            this.pnlThongKe.Controls.Add(this.btnGiaTriTonKho);

            this.pnlLoc.BorderRadius = 12;
            this.pnlLoc.FillColor = System.Drawing.Color.FromArgb(38, 38, 42);
            this.pnlLoc.Location = new System.Drawing.Point(28, 190);
            this.pnlLoc.Size = new System.Drawing.Size(1240, 82);

            this.txtTimKiem.BorderRadius = 8;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.PlaceholderText = "🔍 Tìm tên sản phẩm hoặc SKU...";
            this.txtTimKiem.Location = new System.Drawing.Point(18, 20);
            this.txtTimKiem.Size = new System.Drawing.Size(310, 42);

            this.cmbKho.BackColor = System.Drawing.Color.Transparent;
            this.cmbKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbKho.ItemHeight = 30;
            this.cmbKho.Location = new System.Drawing.Point(345, 20);
            this.cmbKho.Size = new System.Drawing.Size(210, 42);

            this.cmbDanhMuc.BackColor = System.Drawing.Color.Transparent;
            this.cmbDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDanhMuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDanhMuc.ItemHeight = 30;
            this.cmbDanhMuc.Location = new System.Drawing.Point(570, 20);
            this.cmbDanhMuc.Size = new System.Drawing.Size(210, 42);

            this.cmbTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTrangThai.ItemHeight = 30;
            this.cmbTrangThai.Location = new System.Drawing.Point(795, 20);
            this.cmbTrangThai.Size = new System.Drawing.Size(190, 42);

            this.btnLamMoi.BorderRadius = 8;
            this.btnLamMoi.FillColor = System.Drawing.Color.FromArgb(80, 80, 88);
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(1000, 20);
            this.btnLamMoi.Size = new System.Drawing.Size(220, 42);
            this.btnLamMoi.Text = "🔄 LÀM MỚI";

            this.pnlLoc.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.txtTimKiem,this.cmbKho,this.cmbDanhMuc,this.cmbTrangThai,this.btnLamMoi});

            this.dgvTonKho.AllowUserToAddRows = false;
            this.dgvTonKho.AllowUserToDeleteRows = false;
            this.dgvTonKho.BackgroundColor = System.Drawing.Color.White;
            this.dgvTonKho.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTonKho.ColumnHeadersHeight = 40;
            this.dgvTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTonKho.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTonKho.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvTonKho.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvTonKho.RowHeadersVisible = false;
            this.dgvTonKho.RowTemplate.Height = 34;
            this.dgvTonKho.ReadOnly = true;
            this.dgvTonKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTonKho.MultiSelect = false;
            this.dgvTonKho.Location = new System.Drawing.Point(28, 285);
            this.dgvTonKho.Size = new System.Drawing.Size(1240, 430);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(22, 22, 25);
            this.ClientSize = new System.Drawing.Size(1300, 740);
            this.Controls.Add(this.dgvTonKho);
            this.Controls.Add(this.pnlLoc);
            this.Controls.Add(this.pnlThongKe);
            this.Controls.Add(this.lblTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTonKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tồn kho";
            this.pnlThongKe.ResumeLayout(false);
            this.pnlLoc.ResumeLayout(false);
            this.pnlLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
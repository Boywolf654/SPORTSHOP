namespace SPORTSHOP
{
    partial class FormQuanLyKhachHang
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTieuDe, lblDiem, lblHoTen, lblSDT, lblEmail;
        private System.Windows.Forms.TextBox txtTimKiem, txtHoTen, txtSDT, txtEmail;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button btnTim, btnLamMoi, btnMoi, btnThem, btnSua, btnNgung;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label(); this.lblDiem = new System.Windows.Forms.Label(); this.lblHoTen = new System.Windows.Forms.Label(); this.lblSDT = new System.Windows.Forms.Label(); this.lblEmail = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox(); this.txtHoTen = new System.Windows.Forms.TextBox(); this.txtSDT = new System.Windows.Forms.TextBox(); this.txtEmail = new System.Windows.Forms.TextBox();
            this.cboTrangThai = new System.Windows.Forms.ComboBox(); this.btnTim = new System.Windows.Forms.Button(); this.btnLamMoi = new System.Windows.Forms.Button(); this.btnMoi = new System.Windows.Forms.Button(); this.btnThem = new System.Windows.Forms.Button(); this.btnSua = new System.Windows.Forms.Button(); this.btnNgung = new System.Windows.Forms.Button(); this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit(); this.SuspendLayout();
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250); this.ClientSize = new System.Drawing.Size(1100, 700); this.Text = "Quản lý khách hàng";
            this.lblTieuDe.Text = "QUẢN LÝ KHÁCH HÀNG"; this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold); this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(24, 79, 119); this.lblTieuDe.Location = new System.Drawing.Point(25, 20); this.lblTieuDe.AutoSize = true;
            this.txtTimKiem.Location = new System.Drawing.Point(25, 65); this.txtTimKiem.Size = new System.Drawing.Size(310, 34);
            this.btnTim.Location = new System.Drawing.Point(345, 65); this.btnTim.Size = new System.Drawing.Size(90, 34); this.btnTim.Text = "🔎 Tìm"; this.btnTim.BackColor = System.Drawing.Color.FromArgb(37, 99, 235); this.btnTim.ForeColor = System.Drawing.Color.White; this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Location = new System.Drawing.Point(445, 65); this.btnLamMoi.Size = new System.Drawing.Size(105, 34); this.btnLamMoi.Text = "↻ Làm mới"; this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(90, 100, 115); this.btnLamMoi.ForeColor = System.Drawing.Color.White; this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboTrangThai.Location = new System.Drawing.Point(565, 65); this.cboTrangThai.Size = new System.Drawing.Size(180, 34);
            this.btnMoi.Location = new System.Drawing.Point(760, 65); this.btnMoi.Size = new System.Drawing.Size(90, 34); this.btnMoi.Text = "＋ Mới"; this.btnMoi.BackColor = System.Drawing.Color.FromArgb(108, 117, 125); this.btnMoi.ForeColor = System.Drawing.Color.White; this.btnMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Location = new System.Drawing.Point(860, 65); this.btnThem.Size = new System.Drawing.Size(105, 34); this.btnThem.Text = "＋ Thêm"; this.btnThem.BackColor = System.Drawing.Color.FromArgb(46, 180, 126); this.btnThem.ForeColor = System.Drawing.Color.White; this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Location = new System.Drawing.Point(975, 65); this.btnSua.Size = new System.Drawing.Size(100, 34); this.btnSua.Text = "✎ Sửa"; this.btnSua.BackColor = System.Drawing.Color.FromArgb(76, 114, 176); this.btnSua.ForeColor = System.Drawing.Color.White; this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHoTen.Text = "Họ tên"; this.lblHoTen.AutoSize = true; this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); this.lblHoTen.Location = new System.Drawing.Point(25, 120);
            this.lblSDT.Text = "SĐT"; this.lblSDT.AutoSize = true; this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); this.lblSDT.Location = new System.Drawing.Point(300, 120);
            this.lblEmail.Text = "Email"; this.lblEmail.AutoSize = true; this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); this.lblEmail.Location = new System.Drawing.Point(500, 120);
            this.txtHoTen.Location = new System.Drawing.Point(25, 143); this.txtHoTen.Size = new System.Drawing.Size(250, 34); this.txtSDT.Location = new System.Drawing.Point(300, 143); this.txtSDT.Size = new System.Drawing.Size(180, 34); this.txtEmail.Location = new System.Drawing.Point(500, 143); this.txtEmail.Size = new System.Drawing.Size(300, 34);
            this.lblDiem.Text = "Điểm: 0"; this.lblDiem.Location = new System.Drawing.Point(820, 143); this.lblDiem.AutoSize = true; this.lblDiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); this.lblDiem.ForeColor = System.Drawing.Color.FromArgb(180, 120, 0);
            this.btnNgung.Location = new System.Drawing.Point(850, 180); this.btnNgung.Size = new System.Drawing.Size(225, 36); this.btnNgung.Text = "⛔ Khóa khách hàng"; this.btnNgung.BackColor = System.Drawing.Color.FromArgb(220, 75, 75); this.btnNgung.ForeColor = System.Drawing.Color.White; this.btnNgung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvKhachHang.Location = new System.Drawing.Point(25, 230); this.dgvKhachHang.Size = new System.Drawing.Size(1050, 430); this.dgvKhachHang.ReadOnly = true; this.dgvKhachHang.AllowUserToAddRows = false; this.dgvKhachHang.AllowUserToDeleteRows = false; this.dgvKhachHang.RowHeadersVisible = false; this.dgvKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvKhachHang.BackgroundColor = System.Drawing.Color.White; this.dgvKhachHang.ColumnHeadersHeight = 38;
            this.Controls.AddRange(new System.Windows.Forms.Control[] { lblTieuDe, txtTimKiem, btnTim, btnLamMoi, cboTrangThai, btnMoi, btnThem, btnSua, lblHoTen, lblSDT, lblEmail, txtHoTen, txtSDT, txtEmail, lblDiem, btnNgung, dgvKhachHang });
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit(); this.ResumeLayout(false); this.PerformLayout();
        }
    }
}

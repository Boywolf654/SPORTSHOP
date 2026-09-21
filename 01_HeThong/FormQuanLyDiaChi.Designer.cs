namespace SPORTSHOP._07_KhachHang
{
    partial class FormQuanLyDiaChi
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvDiaChi;
        private System.Windows.Forms.TextBox txtNguoiNhan, txtSDT, txtDiaChi, txtTinhThanh;
        private System.Windows.Forms.CheckBox chkMacDinh;
        private System.Windows.Forms.Button btnThem, btnSua, btnXoa, btnMacDinh, btnLamMoi;
        private System.Windows.Forms.Label lblTitle, lblDangChon, lblNguoiNhan, lblSDT, lblDiaChi, lblTinhThanh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvDiaChi = new System.Windows.Forms.DataGridView();
            this.txtNguoiNhan = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTinhThanh = new System.Windows.Forms.TextBox();
            this.chkMacDinh = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnMacDinh = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDangChon = new System.Windows.Forms.Label();
            this.lblNguoiNhan = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblTinhThanh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiaChi)).BeginInit();
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(1050, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý địa chỉ nhận hàng";
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.lblTitle.AutoSize = true; this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(27, 42, 65); this.lblTitle.Location = new System.Drawing.Point(25, 20); this.lblTitle.Text = "📍 ĐỊA CHỈ NHẬN HÀNG";
            this.lblDangChon.AutoSize = true; this.lblDangChon.ForeColor = System.Drawing.Color.DimGray; this.lblDangChon.Location = new System.Drawing.Point(28, 58); this.lblDangChon.Text = "Chưa chọn địa chỉ";

            this.dgvDiaChi.Location = new System.Drawing.Point(25, 90); this.dgvDiaChi.Size = new System.Drawing.Size(1000, 260);
            this.dgvDiaChi.ReadOnly = true; this.dgvDiaChi.AllowUserToAddRows = false; this.dgvDiaChi.AllowUserToDeleteRows = false;
            this.dgvDiaChi.AllowUserToResizeRows = false; this.dgvDiaChi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiaChi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvDiaChi.RowHeadersVisible = false;
            this.dgvDiaChi.BackgroundColor = System.Drawing.Color.White; this.dgvDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDiaChi.RowTemplate.Height = 34;

            this.lblNguoiNhan.AutoSize = true; this.lblNguoiNhan.Location = new System.Drawing.Point(25, 380); this.lblNguoiNhan.Text = "Người nhận";
            this.txtNguoiNhan.Location = new System.Drawing.Point(25, 405); this.txtNguoiNhan.Size = new System.Drawing.Size(300, 32);
            this.lblSDT.AutoSize = true; this.lblSDT.Location = new System.Drawing.Point(345, 380); this.lblSDT.Text = "Số điện thoại";
            this.txtSDT.Location = new System.Drawing.Point(345, 405); this.txtSDT.Size = new System.Drawing.Size(230, 32);
            this.lblTinhThanh.AutoSize = true; this.lblTinhThanh.Location = new System.Drawing.Point(620, 380); this.lblTinhThanh.Text = "Tỉnh / Thành";
            this.txtTinhThanh.Location = new System.Drawing.Point(620, 405); this.txtTinhThanh.Size = new System.Drawing.Size(230, 32);
            this.chkMacDinh.AutoSize = true; this.chkMacDinh.Location = new System.Drawing.Point(875, 407); this.chkMacDinh.Text = "Đặt mặc định";
            this.lblDiaChi.AutoSize = true; this.lblDiaChi.Location = new System.Drawing.Point(25, 455); this.lblDiaChi.Text = "Địa chỉ cụ thể";
            this.txtDiaChi.Location = new System.Drawing.Point(25, 480); this.txtDiaChi.Size = new System.Drawing.Size(825, 32);

            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(27, 142, 62);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(25, 545);
            this.btnThem.Size = new System.Drawing.Size(115, 42);
            this.btnThem.Text = "＋ Thêm";
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(27, 142, 62);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSua.Location = new System.Drawing.Point(155, 545);
            this.btnSua.Size = new System.Drawing.Size(115, 42);
            this.btnSua.Text = "✎ Sửa";
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(198, 52, 52);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXoa.Location = new System.Drawing.Point(285, 545);
            this.btnXoa.Size = new System.Drawing.Size(115, 42);
            this.btnXoa.Text = "🗑 Xóa";
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnMacDinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMacDinh.FlatAppearance.BorderSize = 0;
            this.btnMacDinh.BackColor = System.Drawing.Color.FromArgb(39, 76, 119);
            this.btnMacDinh.ForeColor = System.Drawing.Color.White;
            this.btnMacDinh.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnMacDinh.Location = new System.Drawing.Point(415, 545);
            this.btnMacDinh.Size = new System.Drawing.Size(160, 42);
            this.btnMacDinh.Text = "★ Đặt mặc định";
            this.btnMacDinh.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.BackColor = System.Drawing.Color.Gray;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.Location = new System.Drawing.Point(595, 545);
            this.btnLamMoi.Size = new System.Drawing.Size(115, 42);
            this.btnLamMoi.Text = "↻ Làm mới";
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;

            this.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, lblDangChon, dgvDiaChi, lblNguoiNhan, txtNguoiNhan, lblSDT, txtSDT, lblTinhThanh, txtTinhThanh, chkMacDinh, lblDiaChi, txtDiaChi, btnThem, btnSua, btnXoa, btnMacDinh, btnLamMoi });
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiaChi)).EndInit();
            this.ResumeLayout(false); this.PerformLayout();
        }
    }
}

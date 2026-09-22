namespace SPORTSHOP
{
    partial class ChiTietPhieuNhap
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMaPhieu = new System.Windows.Forms.Label();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblNhaCungCap = new System.Windows.Forms.Label();
            this.lblKho = new System.Windows.Forms.Label();
            this.lblTrangThai = new Guna.UI2.WinForms.Guna2Button();
            this.grpChiTiet = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvChiTiet = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSoDong = new System.Windows.Forms.Label();
            this.lblTongSoLuong = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader.SuspendLayout();
            this.grpChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BorderRadius = 14;
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.lblMaPhieu);
            this.pnlHeader.Controls.Add(this.lblNgayNhap);
            this.pnlHeader.Controls.Add(this.lblNhanVien);
            this.pnlHeader.Controls.Add(this.lblNhaCungCap);
            this.pnlHeader.Controls.Add(this.lblKho);
            this.pnlHeader.Controls.Add(this.lblTrangThai);
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(25, 28, 35);
            this.pnlHeader.Location = new System.Drawing.Point(20, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1160, 165);
            this.pnlHeader.TabIndex = 0;

            // lblTieuDe
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(28, 18);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(390, 46);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "CHI TIẾT PHIẾU NHẬP";

            // lblMaPhieu
            this.lblMaPhieu.AutoSize = true;
            this.lblMaPhieu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMaPhieu.ForeColor = System.Drawing.Color.FromArgb(230, 35, 50);
            this.lblMaPhieu.Location = new System.Drawing.Point(31, 72);
            this.lblMaPhieu.Name = "lblMaPhieu";
            this.lblMaPhieu.Size = new System.Drawing.Size(90, 28);
            this.lblMaPhieu.TabIndex = 1;
            this.lblMaPhieu.Text = "PN0000";

            // lblNgayNhap
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblNgayNhap.ForeColor = System.Drawing.Color.FromArgb(205, 209, 216);
            this.lblNgayNhap.Location = new System.Drawing.Point(150, 75);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(120, 24);
            this.lblNgayNhap.TabIndex = 2;
            this.lblNgayNhap.Text = "Ngày nhập: -";

            // lblNhanVien
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNhanVien.ForeColor = System.Drawing.Color.FromArgb(220, 223, 229);
            this.lblNhanVien.Location = new System.Drawing.Point(32, 118);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(88, 23);
            this.lblNhanVien.TabIndex = 3;
            this.lblNhanVien.Text = "Nhân viên";

            // lblNhaCungCap
            this.lblNhaCungCap.AutoSize = true;
            this.lblNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNhaCungCap.ForeColor = System.Drawing.Color.FromArgb(220, 223, 229);
            this.lblNhaCungCap.Location = new System.Drawing.Point(300, 118);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(117, 23);
            this.lblNhaCungCap.TabIndex = 4;
            this.lblNhaCungCap.Text = "Nhà cung cấp";

            // lblKho
            this.lblKho.AutoSize = true;
            this.lblKho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKho.ForeColor = System.Drawing.Color.FromArgb(220, 223, 229);
            this.lblKho.Location = new System.Drawing.Point(620, 118);
            this.lblKho.Name = "lblKho";
            this.lblKho.Size = new System.Drawing.Size(40, 23);
            this.lblKho.TabIndex = 5;
            this.lblKho.Text = "Kho";

            // lblTrangThai
            this.lblTrangThai.BorderRadius = 9;
            this.lblTrangThai.Enabled = false;
            this.lblTrangThai.FillColor = System.Drawing.Color.FromArgb(45, 48, 58);
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.ForeColor = System.Drawing.Color.White;
            this.lblTrangThai.Location = new System.Drawing.Point(915, 63);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(210, 42);
            this.lblTrangThai.TabIndex = 6;
            this.lblTrangThai.Text = "Trạng thái";

            // grpChiTiet
            this.grpChiTiet.BorderRadius = 12;
            this.grpChiTiet.Controls.Add(this.dgvChiTiet);
            this.grpChiTiet.CustomBorderColor = System.Drawing.Color.FromArgb(40, 43, 51);
            this.grpChiTiet.FillColor = System.Drawing.Color.FromArgb(24, 27, 34);
            this.grpChiTiet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpChiTiet.ForeColor = System.Drawing.Color.White;
            this.grpChiTiet.Location = new System.Drawing.Point(20, 200);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(1160, 425);
            this.grpChiTiet.TabIndex = 1;
            this.grpChiTiet.Text = "DANH SÁCH HÀNG HÓA";

            // dgvChiTiet
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(205, 25, 42);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(205, 25, 42);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTiet.ColumnHeadersHeight = 42;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(31, 34, 42);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(225, 227, 232);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(70, 35, 42);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.GridColor = System.Drawing.Color.FromArgb(55, 58, 68);
            this.dgvChiTiet.Location = new System.Drawing.Point(0, 40);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.RowTemplate.Height = 38;
            this.dgvChiTiet.Size = new System.Drawing.Size(1160, 385);
            this.dgvChiTiet.TabIndex = 0;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(205, 25, 42);
            this.dgvChiTiet.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvChiTiet.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.Height = 42;
            this.dgvChiTiet.ThemeStyle.ReadOnly = true;
            this.dgvChiTiet.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(31, 34, 42);
            this.dgvChiTiet.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTiet.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvChiTiet.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(225, 227, 232);
            this.dgvChiTiet.ThemeStyle.RowsStyle.Height = 38;

            // pnlFooter
            this.pnlFooter.BorderRadius = 12;
            this.pnlFooter.Controls.Add(this.lblSoDong);
            this.pnlFooter.Controls.Add(this.lblTongSoLuong);
            this.pnlFooter.Controls.Add(this.lblTongTien);
            this.pnlFooter.Controls.Add(this.btnDong);
            this.pnlFooter.FillColor = System.Drawing.Color.FromArgb(25, 28, 35);
            this.pnlFooter.Location = new System.Drawing.Point(20, 645);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1160, 78);
            this.pnlFooter.TabIndex = 2;

            // lblSoDong
            this.lblSoDong.AutoSize = true;
            this.lblSoDong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSoDong.ForeColor = System.Drawing.Color.FromArgb(185, 190, 200);
            this.lblSoDong.Location = new System.Drawing.Point(24, 27);
            this.lblSoDong.Name = "lblSoDong";
            this.lblSoDong.Size = new System.Drawing.Size(126, 23);
            this.lblSoDong.TabIndex = 0;
            this.lblSoDong.Text = "Số mặt hàng: 0";

            // lblTongSoLuong
            this.lblTongSoLuong.AutoSize = true;
            this.lblTongSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongSoLuong.ForeColor = System.Drawing.Color.White;
            this.lblTongSoLuong.Location = new System.Drawing.Point(235, 27);
            this.lblTongSoLuong.Name = "lblTongSoLuong";
            this.lblTongSoLuong.Size = new System.Drawing.Size(146, 23);
            this.lblTongSoLuong.TabIndex = 1;
            this.lblTongSoLuong.Text = "Tổng số lượng: 0";

            // lblTongTien
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(235, 40, 55);
            this.lblTongTien.Location = new System.Drawing.Point(500, 24);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(240, 28);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "Tổng tiền nhập: 0 VNĐ";

            // btnDong
            this.btnDong.BorderRadius = 9;
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FillColor = System.Drawing.Color.FromArgb(205, 25, 42);
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(1025, 19);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 40);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "ĐÓNG";

            // ChiTietPhieuNhap
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 17, 22);
            this.ClientSize = new System.Drawing.Size(1200, 745);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.grpChiTiet);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChiTietPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SPORTSHOP - Chi tiết phiếu nhập";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaPhieu;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblNhaCungCap;
        private System.Windows.Forms.Label lblKho;
        private Guna.UI2.WinForms.Guna2Button lblTrangThai;
        private Guna.UI2.WinForms.Guna2GroupBox grpChiTiet;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChiTiet;
        private Guna.UI2.WinForms.Guna2Panel pnlFooter;
        private System.Windows.Forms.Label lblSoDong;
        private System.Windows.Forms.Label lblTongSoLuong;
        private System.Windows.Forms.Label lblTongTien;
        private Guna.UI2.WinForms.Guna2Button btnDong;
    }
}

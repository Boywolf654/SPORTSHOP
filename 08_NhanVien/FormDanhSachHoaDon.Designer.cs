namespace SPORTSHOP._06_BanHang
{
    partial class FormDanhSachHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Panel pnlTools;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXemChiTiet;
        private System.Windows.Forms.Label lblTongSo;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhuongThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;

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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();

            this.pnlTools = new System.Windows.Forms.Panel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.lblTongSo = new System.Windows.Forms.Label();

            this.pnlTable = new System.Windows.Forms.Panel();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();

            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhuongThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlHeader.SuspendLayout();
            this.pnlTools.SuspendLayout();
            this.pnlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.MinimumSize = new System.Drawing.Size(1100, 650);
            this.Name = "FormHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORTSHOP - Danh sách hóa đơn";
            this.Load += new System.EventHandler(this.FormHoaDon_Load);

            // Header
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 104;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(28, 18, 28, 12);

            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(28, 17);
            this.lblLogo.Text = "SPORTSHOP";

            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(220, 18);
            this.lblTieuDe.Text = "Danh sách hóa đơn";

            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(196, 210, 226);
            this.lblMoTa.Location = new System.Drawing.Point(222, 51);
            this.lblMoTa.Text = "Quản lý và tra cứu hóa đơn bán hàng / đơn online";

            this.pnlHeader.Controls.Add(this.lblLogo);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.lblMoTa);

            // Tools
            this.pnlTools.BackColor = System.Drawing.Color.White;
            this.pnlTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTools.Height = 92;
            this.pnlTools.Padding = new System.Windows.Forms.Padding(22, 16, 22, 12);

            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.ForeColor = System.Drawing.Color.FromArgb(62, 73, 89);
            this.lblTimKiem.Location = new System.Drawing.Point(22, 15);
            this.lblTimKiem.Text = "Tìm kiếm";

            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(22, 38);
            this.txtTimKiem.Size = new System.Drawing.Size(420, 25);

            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(232, 238, 247);
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(37, 76, 126);
            this.btnLamMoi.Location = new System.Drawing.Point(458, 36);
            this.btnLamMoi.Size = new System.Drawing.Size(110, 30);
            this.btnLamMoi.Text = "↻  Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;

            this.btnXemChiTiet.BackColor = System.Drawing.Color.FromArgb(220, 30, 45);
            this.btnXemChiTiet.FlatAppearance.BorderSize = 0;
            this.btnXemChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemChiTiet.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnXemChiTiet.Location = new System.Drawing.Point(580, 36);
            this.btnXemChiTiet.Size = new System.Drawing.Size(150, 30);
            this.btnXemChiTiet.Text = "▣  Xem chi tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = false;

            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongSo.ForeColor = System.Drawing.Color.FromArgb(83, 95, 113);
            this.lblTongSo.Location = new System.Drawing.Point(1040, 43);
            this.lblTongSo.Text = "0 hóa đơn";
            this.lblTongSo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            this.pnlTools.Controls.Add(this.lblTimKiem);
            this.pnlTools.Controls.Add(this.txtTimKiem);
            this.pnlTools.Controls.Add(this.btnLamMoi);
            this.pnlTools.Controls.Add(this.btnXemChiTiet);
            this.pnlTools.Controls.Add(this.lblTongSo);

            // Table
            this.pnlTable.BackColor = System.Drawing.Color.White;
            this.pnlTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTable.Padding = new System.Windows.Forms.Padding(22, 8, 22, 22);

            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHoaDon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHoaDon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHoaDon.ColumnHeadersHeight = 42;
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.EnableHeadersVisualStyles = false;
            this.dgvHoaDon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvHoaDon.GridColor = System.Drawing.Color.FromArgb(226, 231, 238);
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvHoaDon.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(25, 52, 82);
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHoaDon.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoaDon.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(45, 55, 72);
            this.dgvHoaDon.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 239, 255);
            this.dgvHoaDon.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(25, 52, 82);
            this.dgvHoaDon.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);

            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.Width = 50;

            this.colMaHD.HeaderText = "Mã hóa đơn";
            this.colMaHD.Name = "colMaHD";
            this.colMaHD.Width = 105;

            this.colMaDon.HeaderText = "Mã đơn";
            this.colMaDon.Name = "colMaDon";
            this.colMaDon.Width = 120;

            this.colKhachHang.HeaderText = "Khách hàng";
            this.colKhachHang.Name = "colKhachHang";
            this.colKhachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colKhachHang.FillWeight = 135;

            this.colSDT.HeaderText = "SĐT";
            this.colSDT.Name = "colSDT";
            this.colSDT.Width = 110;

            this.colNgayLap.HeaderText = "Ngày lập";
            this.colNgayLap.Name = "colNgayLap";
            this.colNgayLap.Width = 130;

            this.colTongTien.HeaderText = "Tổng tiền";
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.Width = 125;

            this.colPhuongThuc.HeaderText = "Thanh toán";
            this.colPhuongThuc.Name = "colPhuongThuc";
            this.colPhuongThuc.Width = 125;

            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.Width = 120;

            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colSTT,
                this.colMaHD,
                this.colMaDon,
                this.colKhachHang,
                this.colSDT,
                this.colNgayLap,
                this.colTongTien,
                this.colPhuongThuc,
                this.colTrangThai
            });

            this.pnlTable.Controls.Add(this.dgvHoaDon);

            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.pnlTools);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTools.ResumeLayout(false);
            this.pnlTools.PerformLayout();
            this.pnlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

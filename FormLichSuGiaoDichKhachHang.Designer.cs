namespace SPORTSHOP
{
    partial class FormLichSuGiaoDichKhachHang
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
        private System.Windows.Forms.DataGridView dgvGiaoDich;

        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaGD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
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
            this.dgvGiaoDich = new System.Windows.Forms.DataGridView();

            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaGD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhuongThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlHeader.SuspendLayout();
            this.pnlTools.SuspendLayout();
            this.pnlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).BeginInit();
            this.SuspendLayout();

            // FORM
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor =
                System.Drawing.Color.FromArgb(244, 247, 251);
            this.ClientSize =
                new System.Drawing.Size(1180, 680);
            this.MinimumSize =
                new System.Drawing.Size(1000, 600);
            this.Name =
                "FormLichSuGiaoDichKhachHang";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text =
                "SPORTSHOP - Lịch sử giao dịch của tôi";

            // HEADER
            this.pnlHeader.BackColor =
                System.Drawing.Color.FromArgb(18, 35, 58);
            this.pnlHeader.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 112;
            this.pnlHeader.Padding =
                new System.Windows.Forms.Padding(30, 18, 30, 12);

            this.lblLogo.AutoSize = true;
            this.lblLogo.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    18F,
                    System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor =
                System.Drawing.Color.White;
            this.lblLogo.Location =
                new System.Drawing.Point(30, 17);
            this.lblLogo.Text =
                "SPORTSHOP";

            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    17F,
                    System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor =
                System.Drawing.Color.White;
            this.lblTieuDe.Location =
                new System.Drawing.Point(230, 18);
            this.lblTieuDe.Text =
                "Lịch sử giao dịch của tôi";

            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font =
                new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMoTa.ForeColor =
                System.Drawing.Color.FromArgb(196, 210, 226);
            this.lblMoTa.Location =
                new System.Drawing.Point(232, 54);
            this.lblMoTa.Text =
                "Chỉ hiển thị giao dịch thuộc tài khoản khách hàng đang đăng nhập";

            this.pnlHeader.Controls.Add(this.lblLogo);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.lblMoTa);

            // TOOLS
            this.pnlTools.BackColor =
                System.Drawing.Color.White;
            this.pnlTools.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.pnlTools.Height = 92;
            this.pnlTools.Padding =
                new System.Windows.Forms.Padding(22, 15, 22, 12);

            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9F,
                    System.Drawing.FontStyle.Bold);
            this.lblTimKiem.ForeColor =
                System.Drawing.Color.FromArgb(62, 73, 89);
            this.lblTimKiem.Location =
                new System.Drawing.Point(22, 14);
            this.lblTimKiem.Text =
                "Tìm kiếm";

            this.txtTimKiem.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location =
                new System.Drawing.Point(22, 37);
            this.txtTimKiem.Size =
                new System.Drawing.Size(390, 25);

            this.btnLamMoi.BackColor =
                System.Drawing.Color.FromArgb(232, 238, 247);
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9F,
                    System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor =
                System.Drawing.Color.FromArgb(37, 76, 126);
            this.btnLamMoi.Location =
                new System.Drawing.Point(430, 35);
            this.btnLamMoi.Size =
                new System.Drawing.Size(110, 30);
            this.btnLamMoi.Text =
                "↻  Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;

            this.btnXemChiTiet.BackColor =
                System.Drawing.Color.FromArgb(220, 30, 45);
            this.btnXemChiTiet.FlatAppearance.BorderSize = 0;
            this.btnXemChiTiet.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnXemChiTiet.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9F,
                    System.Drawing.FontStyle.Bold);
            this.btnXemChiTiet.ForeColor =
                System.Drawing.Color.White;
            this.btnXemChiTiet.Location =
                new System.Drawing.Point(555, 35);
            this.btnXemChiTiet.Size =
                new System.Drawing.Size(150, 30);
            this.btnXemChiTiet.Text =
                "▣  Xem chi tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = false;

            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;
            this.lblTongSo.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    10F,
                    System.Drawing.FontStyle.Bold);
            this.lblTongSo.ForeColor =
                System.Drawing.Color.FromArgb(83, 95, 113);
            this.lblTongSo.Location =
                new System.Drawing.Point(1010, 40);
            this.lblTongSo.Text =
                "0 giao dịch";

            this.pnlTools.Controls.Add(this.lblTimKiem);
            this.pnlTools.Controls.Add(this.txtTimKiem);
            this.pnlTools.Controls.Add(this.btnLamMoi);
            this.pnlTools.Controls.Add(this.btnXemChiTiet);
            this.pnlTools.Controls.Add(this.lblTongSo);

            // TABLE
            this.pnlTable.BackColor =
                System.Drawing.Color.White;
            this.pnlTable.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.pnlTable.Padding =
                new System.Windows.Forms.Padding(22, 8, 22, 22);

            this.dgvGiaoDich.BackgroundColor =
                System.Drawing.Color.White;
            this.dgvGiaoDich.BorderStyle =
                System.Windows.Forms.BorderStyle.None;
            this.dgvGiaoDich.CellBorderStyle =
                System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvGiaoDich.ColumnHeadersBorderStyle =
                System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvGiaoDich.ColumnHeadersHeight = 42;
            this.dgvGiaoDich.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.dgvGiaoDich.EnableHeadersVisualStyles = false;
            this.dgvGiaoDich.Font =
                new System.Drawing.Font("Segoe UI", 9F);
            this.dgvGiaoDich.GridColor =
                System.Drawing.Color.FromArgb(226, 231, 238);
            this.dgvGiaoDich.RowHeadersVisible = false;
            this.dgvGiaoDich.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGiaoDich.DefaultCellStyle.BackColor =
                System.Drawing.Color.White;
            this.dgvGiaoDich.DefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(45, 55, 72);
            this.dgvGiaoDich.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(224, 239, 255);
            this.dgvGiaoDich.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.FromArgb(25, 52, 82);
            this.dgvGiaoDich.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(248, 250, 253);

            this.dgvGiaoDich.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(25, 52, 82);
            this.dgvGiaoDich.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;
            this.dgvGiaoDich.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9F,
                    System.Drawing.FontStyle.Bold);
            this.dgvGiaoDich.ColumnHeadersDefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.Width = 55;

            this.colMaGD.HeaderText = "Mã giao dịch";
            this.colMaGD.Name = "colMaGD";
            this.colMaGD.Width = 125;

            this.colLoai.HeaderText = "Loại giao dịch";
            this.colLoai.Name = "colLoai";
            this.colLoai.Width = 150;

            this.colNgay.HeaderText = "Thời gian";
            this.colNgay.Name = "colNgay";
            this.colNgay.Width = 155;

            this.colTongTien.HeaderText = "Tổng tiền";
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.Width = 145;

            this.colPhuongThuc.HeaderText = "Thanh toán";
            this.colPhuongThuc.Name = "colPhuongThuc";
            this.colPhuongThuc.Width = 150;

            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.AutoSizeMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            this.dgvGiaoDich.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    this.colSTT,
                    this.colMaGD,
                    this.colLoai,
                    this.colNgay,
                    this.colTongTien,
                    this.colPhuongThuc,
                    this.colTrangThai
                });

            this.pnlTable.Controls.Add(this.dgvGiaoDich);

            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.pnlTools);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTools.ResumeLayout(false);
            this.pnlTools.PerformLayout();
            this.pnlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).EndInit();

            this.ResumeLayout(false);
        }
    }
}

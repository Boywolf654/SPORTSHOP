namespace SPORTSHOP
{
    partial class FormBaoCaoDoanhThu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblPhu;
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.Label lblSoHoaDon;
        private System.Windows.Forms.Label lblSoSanPham;
        private System.Windows.Forms.Label lblSoKhach;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lblTu;
        private System.Windows.Forms.Label lblDen;
        private System.Windows.Forms.Label lblLocCa;
        private System.Windows.Forms.DateTimePicker dtpTu;
        private System.Windows.Forms.DateTimePicker dtpDen;
        private System.Windows.Forms.ComboBox cboCa;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnHomNay;
        private System.Windows.Forms.Button btnThang;
        private System.Windows.Forms.Button btnQuy;
        private System.Windows.Forms.Button btnNam;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.DataGridView dgvNgay;
        private System.Windows.Forms.DataGridView dgvTopSP;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblPhu = new System.Windows.Forms.Label();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.lblSoHoaDon = new System.Windows.Forms.Label();
            this.lblSoSanPham = new System.Windows.Forms.Label();
            this.lblSoKhach = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lblTu = new System.Windows.Forms.Label();
            this.lblDen = new System.Windows.Forms.Label();
            this.lblLocCa = new System.Windows.Forms.Label();
            this.dtpTu = new System.Windows.Forms.DateTimePicker();
            this.dtpDen = new System.Windows.Forms.DateTimePicker();
            this.cboCa = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnHomNay = new System.Windows.Forms.Button();
            this.btnThang = new System.Windows.Forms.Button();
            this.btnQuy = new System.Windows.Forms.Button();
            this.btnNam = new System.Windows.Forms.Button();
            this.btnXuat = new System.Windows.Forms.Button();
            this.dgvNgay = new System.Windows.Forms.DataGridView();
            this.dgvTopSP = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSP)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 20, 24);
            this.ClientSize = new System.Drawing.Size(1450, 900);
            this.MinimumSize = new System.Drawing.Size(1200, 760);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "FormBaoCaoDoanhThu";
            this.Text = "SPORT SHOP - Báo cáo doanh thu";

            // Title
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI Semibold", 25F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(28, 18);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "BÁO CÁO DOANH THU";

            this.lblPhu.AutoSize = true;
            this.lblPhu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhu.ForeColor = System.Drawing.Color.FromArgb(170, 176, 186);
            this.lblPhu.Location = new System.Drawing.Point(32, 60);
            this.lblPhu.Name = "lblPhu";
            this.lblPhu.Text = "TỔNG HỢP THEO KHOẢNG THỜI GIAN";

            // Filter labels
            this.lblTu.AutoSize = true;
            this.lblTu.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTu.ForeColor = System.Drawing.Color.FromArgb(205, 210, 218);
            this.lblTu.Location = new System.Drawing.Point(30, 100);
            this.lblTu.Name = "lblTu";
            this.lblTu.Text = "TỪ NGÀY";

            this.lblDen.AutoSize = true;
            this.lblDen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDen.ForeColor = System.Drawing.Color.FromArgb(205, 210, 218);
            this.lblDen.Location = new System.Drawing.Point(175, 100);
            this.lblDen.Name = "lblDen";
            this.lblDen.Text = "ĐẾN NGÀY";

            this.lblLocCa.AutoSize = true;
            this.lblLocCa.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblLocCa.ForeColor = System.Drawing.Color.FromArgb(205, 210, 218);
            this.lblLocCa.Location = new System.Drawing.Point(320, 100);
            this.lblLocCa.Name = "lblLocCa";
            this.lblLocCa.Text = "LỌC THEO CA";

            this.dtpTu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTu.Location = new System.Drawing.Point(30, 121);
            this.dtpTu.Name = "dtpTu";
            this.dtpTu.Size = new System.Drawing.Size(130, 27);
            this.dtpTu.TabIndex = 0;

            this.dtpDen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDen.Location = new System.Drawing.Point(175, 121);
            this.dtpDen.Name = "dtpDen";
            this.dtpDen.Size = new System.Drawing.Size(130, 27);
            this.dtpDen.TabIndex = 1;

            this.cboCa.BackColor = System.Drawing.Color.FromArgb(31, 34, 40);
            this.cboCa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboCa.ForeColor = System.Drawing.Color.White;
            this.cboCa.FormattingEnabled = true;
            this.cboCa.Location = new System.Drawing.Point(320, 121);
            this.cboCa.Name = "cboCa";
            this.cboCa.Size = new System.Drawing.Size(335, 28);
            this.cboCa.TabIndex = 2;

            // Filter buttons
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(198, 38, 48);
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(670, 118);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(95, 34);
            this.btnLoc.TabIndex = 3;
            this.btnLoc.Text = "⌕  LỌC";
            this.btnLoc.UseVisualStyleBackColor = false;

            this.btnHomNay.BackColor = System.Drawing.Color.FromArgb(40, 43, 49);
            this.btnHomNay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(70, 74, 82);
            this.btnHomNay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHomNay.ForeColor = System.Drawing.Color.White;
            this.btnHomNay.Location = new System.Drawing.Point(775, 118);
            this.btnHomNay.Name = "btnHomNay";
            this.btnHomNay.Size = new System.Drawing.Size(90, 34);
            this.btnHomNay.Text = "Hôm nay";
            this.btnHomNay.UseVisualStyleBackColor = false;

            this.btnThang.BackColor = System.Drawing.Color.FromArgb(40, 43, 49);
            this.btnThang.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(70, 74, 82);
            this.btnThang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThang.ForeColor = System.Drawing.Color.White;
            this.btnThang.Location = new System.Drawing.Point(875, 118);
            this.btnThang.Name = "btnThang";
            this.btnThang.Size = new System.Drawing.Size(85, 34);
            this.btnThang.Text = "Tháng";
            this.btnThang.UseVisualStyleBackColor = false;

            this.btnQuy.BackColor = System.Drawing.Color.FromArgb(40, 43, 49);
            this.btnQuy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(70, 74, 82);
            this.btnQuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuy.ForeColor = System.Drawing.Color.White;
            this.btnQuy.Location = new System.Drawing.Point(970, 118);
            this.btnQuy.Name = "btnQuy";
            this.btnQuy.Size = new System.Drawing.Size(75, 34);
            this.btnQuy.Text = "Quý";
            this.btnQuy.UseVisualStyleBackColor = false;

            this.btnNam.BackColor = System.Drawing.Color.FromArgb(40, 43, 49);
            this.btnNam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(70, 74, 82);
            this.btnNam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNam.ForeColor = System.Drawing.Color.White;
            this.btnNam.Location = new System.Drawing.Point(1055, 118);
            this.btnNam.Name = "btnNam";
            this.btnNam.Size = new System.Drawing.Size(75, 34);
            this.btnNam.Text = "Năm";
            this.btnNam.UseVisualStyleBackColor = false;

            this.btnXuat.BackColor = System.Drawing.Color.FromArgb(45, 150, 88);
            this.btnXuat.FlatAppearance.BorderSize = 0;
            this.btnXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuat.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuat.ForeColor = System.Drawing.Color.White;
            this.btnXuat.Location = new System.Drawing.Point(1140, 118);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(145, 34);
            this.btnXuat.Text = "⇩  XUẤT BÁO CÁO";
            this.btnXuat.UseVisualStyleBackColor = false;

            // Summary cards
            this.lbl1.BackColor = System.Drawing.Color.FromArgb(28, 31, 37);
            this.lbl1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lbl1.ForeColor = System.Drawing.Color.FromArgb(160, 166, 176);
            this.lbl1.Location = new System.Drawing.Point(30, 177);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(335, 27);
            this.lbl1.Text = "  DOANH THU";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblDoanhThu.BackColor = System.Drawing.Color.FromArgb(28, 31, 37);
            this.lblDoanhThu.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThu.ForeColor = System.Drawing.Color.FromArgb(230, 55, 64);
            this.lblDoanhThu.Location = new System.Drawing.Point(30, 204);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(335, 50);
            this.lblDoanhThu.Text = "0 đ";
            this.lblDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDoanhThu.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);

            this.lbl2.BackColor = System.Drawing.Color.FromArgb(28, 31, 37);
            this.lbl2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lbl2.ForeColor = System.Drawing.Color.FromArgb(160, 166, 176);
            this.lbl2.Location = new System.Drawing.Point(380, 177);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(335, 27);
            this.lbl2.Text = "  SỐ HÓA ĐƠN";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblSoHoaDon.BackColor = System.Drawing.Color.FromArgb(28, 31, 37);
            this.lblSoHoaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblSoHoaDon.ForeColor = System.Drawing.Color.White;
            this.lblSoHoaDon.Location = new System.Drawing.Point(380, 204);
            this.lblSoHoaDon.Name = "lblSoHoaDon";
            this.lblSoHoaDon.Size = new System.Drawing.Size(335, 50);
            this.lblSoHoaDon.Text = "0";
            this.lblSoHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSoHoaDon.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);

            this.lbl3.BackColor = System.Drawing.Color.FromArgb(28, 31, 37);
            this.lbl3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lbl3.ForeColor = System.Drawing.Color.FromArgb(160, 166, 176);
            this.lbl3.Location = new System.Drawing.Point(730, 177);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(335, 27);
            this.lbl3.Text = "  SẢN PHẨM BÁN";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblSoSanPham.BackColor = System.Drawing.Color.FromArgb(28, 31, 37);
            this.lblSoSanPham.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblSoSanPham.ForeColor = System.Drawing.Color.White;
            this.lblSoSanPham.Location = new System.Drawing.Point(730, 204);
            this.lblSoSanPham.Name = "lblSoSanPham";
            this.lblSoSanPham.Size = new System.Drawing.Size(335, 50);
            this.lblSoSanPham.Text = "0";
            this.lblSoSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSoSanPham.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);

            this.lbl4.BackColor = System.Drawing.Color.FromArgb(28, 31, 37);
            this.lbl4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lbl4.ForeColor = System.Drawing.Color.FromArgb(160, 166, 176);
            this.lbl4.Location = new System.Drawing.Point(1080, 177);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(305, 27);
            this.lbl4.Text = "  KHÁCH HÀNG";
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblSoKhach.BackColor = System.Drawing.Color.FromArgb(28, 31, 37);
            this.lblSoKhach.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblSoKhach.ForeColor = System.Drawing.Color.White;
            this.lblSoKhach.Location = new System.Drawing.Point(1080, 204);
            this.lblSoKhach.Name = "lblSoKhach";
            this.lblSoKhach.Size = new System.Drawing.Size(305, 50);
            this.lblSoKhach.Text = "0";
            this.lblSoKhach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSoKhach.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);

            // Invoice grid
            this.dgvNgay.AllowUserToAddRows = false;
            this.dgvNgay.AllowUserToDeleteRows = false;
            this.dgvNgay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvNgay.BackgroundColor = System.Drawing.Color.FromArgb(28, 31, 37);
            this.dgvNgay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNgay.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNgay.ColumnHeadersHeight = 40;
            this.dgvNgay.Location = new System.Drawing.Point(30, 285);
            this.dgvNgay.MultiSelect = false;
            this.dgvNgay.Name = "dgvNgay";
            this.dgvNgay.ReadOnly = true;
            this.dgvNgay.RowHeadersVisible = false;
            this.dgvNgay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNgay.Size = new System.Drawing.Size(900, 570);
            this.dgvNgay.TabIndex = 4;

            // Top products
            this.dgvTopSP.AllowUserToAddRows = false;
            this.dgvTopSP.AllowUserToDeleteRows = false;
            this.dgvTopSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvTopSP.BackgroundColor = System.Drawing.Color.FromArgb(28, 31, 37);
            this.dgvTopSP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTopSP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTopSP.ColumnHeadersHeight = 40;
            this.dgvTopSP.Location = new System.Drawing.Point(950, 285);
            this.dgvTopSP.MultiSelect = false;
            this.dgvTopSP.Name = "dgvTopSP";
            this.dgvTopSP.ReadOnly = true;
            this.dgvTopSP.RowHeadersVisible = false;
            this.dgvTopSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopSP.Size = new System.Drawing.Size(435, 570);
            this.dgvTopSP.TabIndex = 5;

            this.Controls.Add(this.dgvTopSP);
            this.Controls.Add(this.dgvNgay);
            this.Controls.Add(this.lblSoKhach);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lblSoSanPham);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lblSoHoaDon);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lblDoanhThu);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.btnNam);
            this.Controls.Add(this.btnQuy);
            this.Controls.Add(this.btnThang);
            this.Controls.Add(this.btnHomNay);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.cboCa);
            this.Controls.Add(this.lblLocCa);
            this.Controls.Add(this.dtpDen);
            this.Controls.Add(this.lblDen);
            this.Controls.Add(this.dtpTu);
            this.Controls.Add(this.lblTu);
            this.Controls.Add(this.lblPhu);
            this.Controls.Add(this.lblTieuDe);

            ((System.ComponentModel.ISupportInitialize)(this.dgvNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

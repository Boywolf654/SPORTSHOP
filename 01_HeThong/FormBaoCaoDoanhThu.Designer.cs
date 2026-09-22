namespace SPORTSHOP
{
    partial class FormBaoCaoDoanhThu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.Label lblSoHoaDon;
        private System.Windows.Forms.Label lblSoSanPham;
        private System.Windows.Forms.Label lblSoKhach;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.DateTimePicker dtpTu;
        private System.Windows.Forms.DateTimePicker dtpDen;
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
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.lblSoHoaDon = new System.Windows.Forms.Label();
            this.lblSoSanPham = new System.Windows.Forms.Label();
            this.lblSoKhach = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.dtpTu = new System.Windows.Forms.DateTimePicker();
            this.dtpDen = new System.Windows.Forms.DateTimePicker();
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
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(1150, 780);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "FormBaoCaoDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo doanh thu";

            // Title
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(24, 79, 119);
            this.lblTieuDe.Location = new System.Drawing.Point(25, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "BÁO CÁO DOANH THU";

            // Date pickers
            this.dtpTu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTu.Location = new System.Drawing.Point(25, 65);
            this.dtpTu.Name = "dtpTu";
            this.dtpTu.Size = new System.Drawing.Size(170, 23);

            this.dtpDen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDen.Location = new System.Drawing.Point(205, 65);
            this.dtpDen.Name = "dtpDen";
            this.dtpDen.Size = new System.Drawing.Size(170, 23);

            // Buttons
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(385, 61);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(85, 32);
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;

            this.btnHomNay.BackColor = System.Drawing.Color.FromArgb(90, 100, 115);
            this.btnHomNay.FlatAppearance.BorderSize = 0;
            this.btnHomNay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHomNay.ForeColor = System.Drawing.Color.White;
            this.btnHomNay.Location = new System.Drawing.Point(480, 61);
            this.btnHomNay.Name = "btnHomNay";
            this.btnHomNay.Size = new System.Drawing.Size(90, 32);
            this.btnHomNay.Text = "Hôm nay";
            this.btnHomNay.UseVisualStyleBackColor = false;

            this.btnThang.BackColor = System.Drawing.Color.FromArgb(90, 100, 115);
            this.btnThang.FlatAppearance.BorderSize = 0;
            this.btnThang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThang.ForeColor = System.Drawing.Color.White;
            this.btnThang.Location = new System.Drawing.Point(580, 61);
            this.btnThang.Name = "btnThang";
            this.btnThang.Size = new System.Drawing.Size(85, 32);
            this.btnThang.Text = "Tháng";
            this.btnThang.UseVisualStyleBackColor = false;

            this.btnQuy.BackColor = System.Drawing.Color.FromArgb(90, 100, 115);
            this.btnQuy.FlatAppearance.BorderSize = 0;
            this.btnQuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuy.ForeColor = System.Drawing.Color.White;
            this.btnQuy.Location = new System.Drawing.Point(675, 61);
            this.btnQuy.Name = "btnQuy";
            this.btnQuy.Size = new System.Drawing.Size(75, 32);
            this.btnQuy.Text = "Quý";
            this.btnQuy.UseVisualStyleBackColor = false;

            this.btnNam.BackColor = System.Drawing.Color.FromArgb(90, 100, 115);
            this.btnNam.FlatAppearance.BorderSize = 0;
            this.btnNam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNam.ForeColor = System.Drawing.Color.White;
            this.btnNam.Location = new System.Drawing.Point(760, 61);
            this.btnNam.Name = "btnNam";
            this.btnNam.Size = new System.Drawing.Size(75, 32);
            this.btnNam.Text = "Năm";
            this.btnNam.UseVisualStyleBackColor = false;

            this.btnXuat.BackColor = System.Drawing.Color.FromArgb(46, 180, 126);
            this.btnXuat.FlatAppearance.BorderSize = 0;
            this.btnXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuat.ForeColor = System.Drawing.Color.White;
            this.btnXuat.Location = new System.Drawing.Point(845, 61);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(130, 32);
            this.btnXuat.Text = "Xuất CSV";
            this.btnXuat.UseVisualStyleBackColor = false;

            // Summary labels
            this.lbl1.BackColor = System.Drawing.Color.White;
            this.lbl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl1.ForeColor = System.Drawing.Color.FromArgb(80, 90, 100);
            this.lbl1.Location = new System.Drawing.Point(25, 120);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(250, 32);
            this.lbl1.Text = "DOANH THU";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lbl2.BackColor = System.Drawing.Color.White;
            this.lbl2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl2.ForeColor = System.Drawing.Color.FromArgb(80, 90, 100);
            this.lbl2.Location = new System.Drawing.Point(290, 120);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(250, 32);
            this.lbl2.Text = "SỐ HÓA ĐƠN";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lbl3.BackColor = System.Drawing.Color.White;
            this.lbl3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl3.ForeColor = System.Drawing.Color.FromArgb(80, 90, 100);
            this.lbl3.Location = new System.Drawing.Point(555, 120);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(250, 32);
            this.lbl3.Text = "SẢN PHẨM BÁN";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lbl4.BackColor = System.Drawing.Color.White;
            this.lbl4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl4.ForeColor = System.Drawing.Color.FromArgb(80, 90, 100);
            this.lbl4.Location = new System.Drawing.Point(820, 120);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(250, 32);
            this.lbl4.Text = "KHÁCH HÀNG";
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblDoanhThu.BackColor = System.Drawing.Color.White;
            this.lblDoanhThu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThu.ForeColor = System.Drawing.Color.FromArgb(31, 111, 62);
            this.lblDoanhThu.Location = new System.Drawing.Point(25, 152);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(250, 45);
            this.lblDoanhThu.Text = "0 đ";
            this.lblDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblSoHoaDon.BackColor = System.Drawing.Color.White;
            this.lblSoHoaDon.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblSoHoaDon.ForeColor = System.Drawing.Color.FromArgb(24, 79, 119);
            this.lblSoHoaDon.Location = new System.Drawing.Point(290, 152);
            this.lblSoHoaDon.Name = "lblSoHoaDon";
            this.lblSoHoaDon.Size = new System.Drawing.Size(250, 45);
            this.lblSoHoaDon.Text = "0";
            this.lblSoHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblSoSanPham.BackColor = System.Drawing.Color.White;
            this.lblSoSanPham.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblSoSanPham.ForeColor = System.Drawing.Color.FromArgb(24, 79, 119);
            this.lblSoSanPham.Location = new System.Drawing.Point(555, 152);
            this.lblSoSanPham.Name = "lblSoSanPham";
            this.lblSoSanPham.Size = new System.Drawing.Size(250, 45);
            this.lblSoSanPham.Text = "0";
            this.lblSoSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblSoKhach.BackColor = System.Drawing.Color.White;
            this.lblSoKhach.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblSoKhach.ForeColor = System.Drawing.Color.FromArgb(24, 79, 119);
            this.lblSoKhach.Location = new System.Drawing.Point(820, 152);
            this.lblSoKhach.Name = "lblSoKhach";
            this.lblSoKhach.Size = new System.Drawing.Size(250, 45);
            this.lblSoKhach.Text = "0";
            this.lblSoKhach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Grid doanh thu theo ngày
            this.dgvNgay.AllowUserToAddRows = false;
            this.dgvNgay.AllowUserToDeleteRows = false;
            this.dgvNgay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNgay.BackgroundColor = System.Drawing.Color.White;
            this.dgvNgay.ColumnHeadersHeight = 38;
            this.dgvNgay.Location = new System.Drawing.Point(25, 240);
            this.dgvNgay.MultiSelect = false;
            this.dgvNgay.Name = "dgvNgay";
            this.dgvNgay.ReadOnly = true;
            this.dgvNgay.RowHeadersVisible = false;
            this.dgvNgay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNgay.Size = new System.Drawing.Size(520, 500);

            // Grid top sản phẩm
            this.dgvTopSP.AllowUserToAddRows = false;
            this.dgvTopSP.AllowUserToDeleteRows = false;
            this.dgvTopSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopSP.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopSP.ColumnHeadersHeight = 38;
            this.dgvTopSP.Location = new System.Drawing.Point(565, 240);
            this.dgvTopSP.MultiSelect = false;
            this.dgvTopSP.Name = "dgvTopSP";
            this.dgvTopSP.ReadOnly = true;
            this.dgvTopSP.RowHeadersVisible = false;
            this.dgvTopSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopSP.Size = new System.Drawing.Size(505, 500);

            // Add controls - explicit, no loops/local arrays
            this.Controls.Add(this.dgvTopSP);
            this.Controls.Add(this.dgvNgay);
            this.Controls.Add(this.lblSoKhach);
            this.Controls.Add(this.lblSoSanPham);
            this.Controls.Add(this.lblSoHoaDon);
            this.Controls.Add(this.lblDoanhThu);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.btnNam);
            this.Controls.Add(this.btnQuy);
            this.Controls.Add(this.btnThang);
            this.Controls.Add(this.btnHomNay);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.dtpDen);
            this.Controls.Add(this.dtpTu);
            this.Controls.Add(this.lblTieuDe);

            ((System.ComponentModel.ISupportInitialize)(this.dgvNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

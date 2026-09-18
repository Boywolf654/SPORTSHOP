namespace SPORTSHOP._06_BanHang
{
    partial class Giohang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPhuongThuc = new System.Windows.Forms.Label();
            this.rdoThe = new System.Windows.Forms.RadioButton();
            this.rdoChuyenKhoan = new System.Windows.Forms.RadioButton();
            this.lblDiaChiNhan = new System.Windows.Forms.Label();
            this.lblDiaChiValue = new System.Windows.Forms.Label();
            this.btn_vanchuyen = new System.Windows.Forms.Button();
            this.cmb_vanchuyen = new System.Windows.Forms.ComboBox();
            this.btn_giamgia = new System.Windows.Forms.Button();
            this.cmb_giamgia = new System.Windows.Forms.ComboBox();
            this.btn_thanhtoan = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();

            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.dgv_giohang = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();

            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_giohang)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            // FORM
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(1180, 735);
            this.MinimumSize = new System.Drawing.Size(1050, 680);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORTSHOP - Giỏ hàng";
            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            // PANEL LEFT
            this.panel1.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.panel1.Location = new System.Drawing.Point(15, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 690);
            this.panel1.TabIndex = 0;

            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 21F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(27, 42, 65);
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Text = "GIỎ HÀNG";

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(110, 120, 135);
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Text = "Kiểm tra sản phẩm trước khi thanh toán";

            this.dgv_giohang.AllowUserToAddRows = false;
            this.dgv_giohang.AllowUserToDeleteRows = false;
            this.dgv_giohang.AllowUserToResizeRows = false;
            this.dgv_giohang.BackgroundColor = System.Drawing.Color.White;
            this.dgv_giohang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_giohang.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_giohang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_giohang.ColumnHeadersHeight = 42;
            this.dgv_giohang.EnableHeadersVisualStyles = false;
            this.dgv_giohang.GridColor = System.Drawing.Color.FromArgb(232, 235, 240);
            this.dgv_giohang.Location = new System.Drawing.Point(12, 82);
            this.dgv_giohang.MultiSelect = false;
            this.dgv_giohang.ReadOnly = true;
            this.dgv_giohang.RowHeadersVisible = false;
            this.dgv_giohang.RowTemplate.Height = 55;
            this.dgv_giohang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_giohang.Size = new System.Drawing.Size(655, 505);
            this.dgv_giohang.TabIndex = 5;
            this.dgv_giohang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.Column1, this.Column2, this.Column3, this.Column4, this.Column5, this.Column6
            });

            this.Column1.HeaderText = "Sản phẩm";
            this.Column1.Name = "Column1";
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.MinimumWidth = 180;

            this.Column2.HeaderText = "Giá";
            this.Column2.Name = "Column2";
            this.Column2.Width = 105;

            this.Column3.HeaderText = "+";
            this.Column3.Name = "Column3";
            this.Column3.Width = 35;

            this.Column4.HeaderText = "SL";
            this.Column4.Name = "Column4";
            this.Column4.Width = 55;

            this.Column5.HeaderText = "-";
            this.Column5.Name = "Column5";
            this.Column5.Width = 35;

            this.Column6.HeaderText = "Thành tiền";
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;

            this.dgv_giohang.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(27, 42, 65);
            this.dgv_giohang.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgv_giohang.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_giohang.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgv_giohang.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(45, 52, 62);
            this.dgv_giohang.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(225, 236, 250);
            this.dgv_giohang.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(25, 55, 90);

            this.btn_xoa.BackColor = System.Drawing.Color.FromArgb(198, 52, 52);
            this.btn_xoa.FlatAppearance.BorderSize = 0;
            this.btn_xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xoa.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_xoa.ForeColor = System.Drawing.Color.White;
            this.btn_xoa.Location = new System.Drawing.Point(12, 607);
            this.btn_xoa.Size = new System.Drawing.Size(160, 48);
            this.btn_xoa.Text = "XÓA TẤT CẢ";
            this.btn_xoa.Cursor = System.Windows.Forms.Cursors.Hand;

            // PANEL RIGHT
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(710, 15);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(455, 690);
            this.panel3.TabIndex = 4;
            this.panel3.Padding = new System.Windows.Forms.Padding(22);

            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(27, 42, 65);
            this.label3.Location = new System.Drawing.Point(22, 18);
            this.label3.Text = "TÓM TẮT ĐƠN HÀNG";

            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(70, 78, 90);
            this.label4.Location = new System.Drawing.Point(25, 75);
            this.label4.Text = "Giá gốc: 0 Đ";

            this.cmb_giamgia.FormattingEnabled = true;
            this.cmb_giamgia.Location = new System.Drawing.Point(25, 132);
            this.cmb_giamgia.Size = new System.Drawing.Size(275, 31);
            this.cmb_giamgia.TabIndex = 6;

            this.btn_giamgia.BackColor = System.Drawing.Color.FromArgb(232, 238, 247);
            this.btn_giamgia.FlatAppearance.BorderSize = 0;
            this.btn_giamgia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_giamgia.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btn_giamgia.ForeColor = System.Drawing.Color.FromArgb(39, 76, 119);
            this.btn_giamgia.Location = new System.Drawing.Point(315, 132);
            this.btn_giamgia.Size = new System.Drawing.Size(100, 31);
            this.btn_giamgia.Text = "ÁP DỤNG";
            this.btn_giamgia.Cursor = System.Windows.Forms.Cursors.Hand;

            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(190, 55, 55);
            this.label5.Location = new System.Drawing.Point(25, 175);
            this.label5.Text = "Giảm giá: 0 Đ";

            this.cmb_vanchuyen.FormattingEnabled = true;
            this.cmb_vanchuyen.Items.AddRange(new object[] {
                "Giao tiêu chuẩn",
                "Giao nhanh"
            });
            this.cmb_vanchuyen.Location = new System.Drawing.Point(25, 222);
            this.cmb_vanchuyen.Size = new System.Drawing.Size(275, 31);
            this.cmb_vanchuyen.TabIndex = 8;

            this.btn_vanchuyen.BackColor = System.Drawing.Color.FromArgb(232, 238, 247);
            this.btn_vanchuyen.FlatAppearance.BorderSize = 0;
            this.btn_vanchuyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_vanchuyen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btn_vanchuyen.ForeColor = System.Drawing.Color.FromArgb(39, 76, 119);
            this.btn_vanchuyen.Location = new System.Drawing.Point(315, 222);
            this.btn_vanchuyen.Size = new System.Drawing.Size(100, 31);
            this.btn_vanchuyen.Text = "ÁP DỤNG";
            this.btn_vanchuyen.Cursor = System.Windows.Forms.Cursors.Hand;

            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(70, 78, 90);
            this.label6.Location = new System.Drawing.Point(25, 265);
            this.label6.Text = "Vận chuyển: 0 Đ";

            this.lblDiaChiNhan.AutoSize = true;
            this.lblDiaChiNhan.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiaChiNhan.ForeColor = System.Drawing.Color.FromArgb(27, 42, 65);
            this.lblDiaChiNhan.Location = new System.Drawing.Point(25, 308);
            this.lblDiaChiNhan.Text = "Địa chỉ nhận hàng";

            this.lblDiaChiValue.AutoEllipsis = true;
            this.lblDiaChiValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDiaChiValue.ForeColor = System.Drawing.Color.FromArgb(95, 103, 115);
            this.lblDiaChiValue.Location = new System.Drawing.Point(25, 333);
            this.lblDiaChiValue.Size = new System.Drawing.Size(390, 39);
            this.lblDiaChiValue.Text = "Đang tải địa chỉ mặc định...";

            this.lblPhuongThuc.AutoSize = true;
            this.lblPhuongThuc.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblPhuongThuc.ForeColor = System.Drawing.Color.FromArgb(27, 42, 65);
            this.lblPhuongThuc.Location = new System.Drawing.Point(25, 382);
            this.lblPhuongThuc.Text = "PHƯƠNG THỨC THANH TOÁN";

            this.rdoThe.AutoSize = true;
            this.rdoThe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdoThe.Location = new System.Drawing.Point(25, 415);
            this.rdoThe.Text = "💳  Thanh toán bằng thẻ";
            this.rdoThe.Checked = true;

            this.rdoChuyenKhoan.AutoSize = true;
            this.rdoChuyenKhoan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdoChuyenKhoan.Location = new System.Drawing.Point(230, 415);
            this.rdoChuyenKhoan.Text = "🏦  Chuyển khoản";

            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(207, 49, 49);
            this.label7.Location = new System.Drawing.Point(25, 458);
            this.label7.Text = "TỔNG: 0 Đ";

            this.btn_thanhtoan.BackColor = System.Drawing.Color.FromArgb(27, 142, 62);
            this.btn_thanhtoan.FlatAppearance.BorderSize = 0;
            this.btn_thanhtoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_thanhtoan.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btn_thanhtoan.ForeColor = System.Drawing.Color.White;
            this.btn_thanhtoan.Location = new System.Drawing.Point(25, 515);
            this.btn_thanhtoan.Size = new System.Drawing.Size(390, 55);
            this.btn_thanhtoan.Text = "THANH TOÁN & ĐẶT ĐƠN";
            this.btn_thanhtoan.Cursor = System.Windows.Forms.Cursors.Hand;

            // CONTROLS
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cmb_giamgia);
            this.panel3.Controls.Add(this.btn_giamgia);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cmb_vanchuyen);
            this.panel3.Controls.Add(this.btn_vanchuyen);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lblDiaChiNhan);
            this.panel3.Controls.Add(this.lblDiaChiValue);
            this.panel3.Controls.Add(this.lblPhuongThuc);
            this.panel3.Controls.Add(this.rdoThe);
            this.panel3.Controls.Add(this.rdoChuyenKhoan);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.btn_thanhtoan);

            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgv_giohang);
            this.panel1.Controls.Add(this.btn_xoa);

            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);

            this.Load += new System.EventHandler(this.Giohang_Load);

            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_giohang)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_vanchuyen;
        private System.Windows.Forms.ComboBox cmb_vanchuyen;
        private System.Windows.Forms.Button btn_giamgia;
        private System.Windows.Forms.ComboBox cmb_giamgia;
        private System.Windows.Forms.Button btn_thanhtoan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPhuongThuc;
        private System.Windows.Forms.RadioButton rdoThe;
        private System.Windows.Forms.RadioButton rdoChuyenKhoan;
        private System.Windows.Forms.Label lblDiaChiNhan;
        private System.Windows.Forms.Label lblDiaChiValue;

        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.DataGridView dgv_giohang;
        private System.Windows.Forms.Panel panel1;
    }
}

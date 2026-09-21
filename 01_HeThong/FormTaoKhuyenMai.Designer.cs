namespace SPORTSHOP
{
    partial class FormTaoKhuyenMai
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTieuDe;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHuongDan;
        private Guna.UI2.WinForms.Guna2TextBox txtTen;
        private Guna.UI2.WinForms.Guna2TextBox txtMoTa;
        private Guna.UI2.WinForms.Guna2ComboBox cboLoai;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudGiaTri;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudSoLuong;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpBatDau;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpKetThuc;
        private System.Windows.Forms.CheckedListBox clbSanPham;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTieuDe = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblHuongDan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMoTa = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboLoai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.nudGiaTri = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.nudSoLuong = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.dtpBatDau = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpKetThuc = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.clbSanPham = new System.Windows.Forms.CheckedListBox();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.l1 = new System.Windows.Forms.Label();
            this.l2 = new System.Windows.Forms.Label();
            this.l3 = new System.Windows.Forms.Label();
            this.l4 = new System.Windows.Forms.Label();
            this.l5 = new System.Windows.Forms.Label();
            this.l6 = new System.Windows.Forms.Label();
            this.l7 = new System.Windows.Forms.Label();
            this.l8 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.lblHuongDan);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(980, 105);
            this.pnlHeader.TabIndex = 8;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(28, 17);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(513, 40);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "＋  TẠO CHƯƠNG TRÌNH KHUYẾN MÃI";
            // 
            // lblHuongDan
            // 
            this.lblHuongDan.BackColor = System.Drawing.Color.Transparent;
            this.lblHuongDan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHuongDan.ForeColor = System.Drawing.Color.LightGray;
            this.lblHuongDan.Location = new System.Drawing.Point(31, 57);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new System.Drawing.Size(408, 22);
            this.lblHuongDan.TabIndex = 1;
            this.lblHuongDan.Text = "Thiết lập mức giảm, thời gian và các sản phẩm được áp dụng";
            // 
            // txtTen
            // 
            this.txtTen.BorderRadius = 8;
            this.txtTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTen.DefaultText = "";
            this.txtTen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTen.Location = new System.Drawing.Point(12, 128);
            this.txtTen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTen.Name = "txtTen";
            this.txtTen.PlaceholderText = "";
            this.txtTen.SelectedText = "";
            this.txtTen.Size = new System.Drawing.Size(484, 38);
            this.txtTen.TabIndex = 9;
            // 
            // txtMoTa
            // 
            this.txtMoTa.BorderRadius = 8;
            this.txtMoTa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMoTa.DefaultText = "";
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMoTa.Location = new System.Drawing.Point(10, 205);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.PlaceholderText = "";
            this.txtMoTa.SelectedText = "";
            this.txtMoTa.Size = new System.Drawing.Size(484, 84);
            this.txtMoTa.TabIndex = 10;
            // 
            // cboLoai
            // 
            this.cboLoai.BackColor = System.Drawing.Color.Transparent;
            this.cboLoai.BorderRadius = 8;
            this.cboLoai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.FocusedColor = System.Drawing.Color.Empty;
            this.cboLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLoai.ItemHeight = 30;
            this.cboLoai.Location = new System.Drawing.Point(500, 130);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(200, 36);
            this.cboLoai.TabIndex = 11;
            // 
            // nudGiaTri
            // 
            this.nudGiaTri.BackColor = System.Drawing.Color.Transparent;
            this.nudGiaTri.BorderRadius = 8;
            this.nudGiaTri.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudGiaTri.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudGiaTri.Location = new System.Drawing.Point(715, 130);
            this.nudGiaTri.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudGiaTri.Name = "nudGiaTri";
            this.nudGiaTri.Size = new System.Drawing.Size(200, 36);
            this.nudGiaTri.TabIndex = 12;
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.BackColor = System.Drawing.Color.Transparent;
            this.nudSoLuong.BorderRadius = 8;
            this.nudSoLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudSoLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudSoLuong.Location = new System.Drawing.Point(500, 205);
            this.nudSoLuong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(200, 36);
            this.nudSoLuong.TabIndex = 13;
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.BorderRadius = 8;
            this.dtpBatDau.Checked = true;
            this.dtpBatDau.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpBatDau.Location = new System.Drawing.Point(715, 205);
            this.dtpBatDau.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpBatDau.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(240, 36);
            this.dtpBatDau.TabIndex = 14;
            this.dtpBatDau.Value = new System.DateTime(2026, 9, 20, 2, 16, 49, 896);
            // 
            // dtpKetThuc
            // 
            this.dtpKetThuc.BorderRadius = 8;
            this.dtpKetThuc.Checked = true;
            this.dtpKetThuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpKetThuc.Location = new System.Drawing.Point(500, 272);
            this.dtpKetThuc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpKetThuc.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpKetThuc.Name = "dtpKetThuc";
            this.dtpKetThuc.Size = new System.Drawing.Size(455, 36);
            this.dtpKetThuc.TabIndex = 15;
            this.dtpKetThuc.Value = new System.DateTime(2026, 9, 20, 2, 16, 49, 927);
            // 
            // clbSanPham
            // 
            this.clbSanPham.BackColor = System.Drawing.Color.White;
            this.clbSanPham.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbSanPham.CheckOnClick = true;
            this.clbSanPham.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.clbSanPham.IntegralHeight = false;
            this.clbSanPham.Location = new System.Drawing.Point(12, 333);
            this.clbSanPham.Name = "clbSanPham";
            this.clbSanPham.Size = new System.Drawing.Size(885, 285);
            this.clbSanPham.TabIndex = 16;
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 9;
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(180)))), ((int)(((byte)(126)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(590, 665);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(184, 40);
            this.btnLuu.TabIndex = 17;
            this.btnLuu.Text = "✓  LƯU CHƯƠNG TRÌNH";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 9;
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(115)))));
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(780, 665);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(135, 40);
            this.btnHuy.TabIndex = 18;
            this.btnHuy.Text = "HỦY";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(0, 0);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(100, 23);
            this.l1.TabIndex = 0;
            // 
            // l2
            // 
            this.l2.Location = new System.Drawing.Point(0, 0);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(100, 23);
            this.l2.TabIndex = 1;
            // 
            // l3
            // 
            this.l3.Location = new System.Drawing.Point(0, 0);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(100, 23);
            this.l3.TabIndex = 2;
            // 
            // l4
            // 
            this.l4.Location = new System.Drawing.Point(0, 0);
            this.l4.Name = "l4";
            this.l4.Size = new System.Drawing.Size(100, 23);
            this.l4.TabIndex = 3;
            // 
            // l5
            // 
            this.l5.Location = new System.Drawing.Point(0, 0);
            this.l5.Name = "l5";
            this.l5.Size = new System.Drawing.Size(100, 23);
            this.l5.TabIndex = 4;
            // 
            // l6
            // 
            this.l6.Location = new System.Drawing.Point(0, 0);
            this.l6.Name = "l6";
            this.l6.Size = new System.Drawing.Size(100, 23);
            this.l6.TabIndex = 5;
            // 
            // l7
            // 
            this.l7.Location = new System.Drawing.Point(0, 0);
            this.l7.Name = "l7";
            this.l7.Size = new System.Drawing.Size(100, 23);
            this.l7.TabIndex = 6;
            // 
            // l8
            // 
            this.l8.Location = new System.Drawing.Point(0, 0);
            this.l8.Name = "l8";
            this.l8.Size = new System.Drawing.Size(100, 23);
            this.l8.TabIndex = 7;
            // 
            // FormTaoKhuyenMai
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(980, 760);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.l2);
            this.Controls.Add(this.l3);
            this.Controls.Add(this.l4);
            this.Controls.Add(this.l5);
            this.Controls.Add(this.l6);
            this.Controls.Add(this.l7);
            this.Controls.Add(this.l8);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.cboLoai);
            this.Controls.Add(this.nudGiaTri);
            this.Controls.Add(this.nudSoLuong);
            this.Controls.Add(this.dtpBatDau);
            this.Controls.Add(this.dtpKetThuc);
            this.Controls.Add(this.clbSanPham);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Name = "FormTaoKhuyenMai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo chương trình khuyến mãi";
            this.Load += new System.EventHandler(this.FormTaoKhuyenMai_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Label l3;
        private System.Windows.Forms.Label l4;
        private System.Windows.Forms.Label l5;
        private System.Windows.Forms.Label l6;
        private System.Windows.Forms.Label l7;
        private System.Windows.Forms.Label l8;
    }
}
namespace SPORTSHOP._06_BanHang
{
    partial class themcoupon
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();

            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();

            this.txt_macoupon = new System.Windows.Forms.TextBox();
            this.txt_ten = new System.Windows.Forms.TextBox();
            this.txt_giatri = new System.Windows.Forms.TextBox();
            this.txt_dontoithieu = new System.Windows.Forms.TextBox();
            this.txt_soluong = new System.Windows.Forms.TextBox();

            this.txt_loai = new System.Windows.Forms.ComboBox();

            this.dt_ngaybatdau = new System.Windows.Forms.DateTimePicker();
            this.dt_ketthuc = new System.Windows.Forms.DateTimePicker();

            this.btn_them = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();

            this.lblNote = new System.Windows.Forms.Label();

            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(35, 47, 62);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(650, 82);
            this.panelHeader.TabIndex = 0;

            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                18F,
                System.Drawing.FontStyle.Bold
            );
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(650, 82);
            this.label1.TabIndex = 0;
            this.label1.Text = "🎟  THÊM MÃ GIẢM GIÁ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                10F,
                System.Drawing.FontStyle.Bold
            );
            this.label2.Location = new System.Drawing.Point(45, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã coupon *";

            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                10F,
                System.Drawing.FontStyle.Bold
            );
            this.label3.Location = new System.Drawing.Point(45, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên chương trình *";

            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                10F,
                System.Drawing.FontStyle.Bold
            );
            this.label4.Location = new System.Drawing.Point(45, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Loại giảm *";

            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                10F,
                System.Drawing.FontStyle.Bold
            );
            this.label5.Location = new System.Drawing.Point(45, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Giá trị giảm *";

            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                10F,
                System.Drawing.FontStyle.Bold
            );
            this.label6.Location = new System.Drawing.Point(45, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Đơn tối thiểu *";

            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                10F,
                System.Drawing.FontStyle.Bold
            );
            this.label7.Location = new System.Drawing.Point(45, 425);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Số lượt tối đa *";

            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                10F,
                System.Drawing.FontStyle.Bold
            );
            this.label8.Location = new System.Drawing.Point(45, 485);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ngày bắt đầu *";

            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                10F,
                System.Drawing.FontStyle.Bold
            );
            this.label9.Location = new System.Drawing.Point(45, 545);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 19);
            this.label9.TabIndex = 8;
            this.label9.Text = "Ngày kết thúc *";

            // 
            // txt_macoupon
            // 
            this.txt_macoupon.Font = new System.Drawing.Font(
                "Segoe UI",
                10.5F
            );
            this.txt_macoupon.Location = new System.Drawing.Point(210, 120);
            this.txt_macoupon.Name = "txt_macoupon";
            this.txt_macoupon.Size = new System.Drawing.Size(365, 26);
            this.txt_macoupon.TabIndex = 9;

            // 
            // txt_ten
            // 
            this.txt_ten.Font = new System.Drawing.Font(
                "Segoe UI",
                10.5F
            );
            this.txt_ten.Location = new System.Drawing.Point(210, 180);
            this.txt_ten.Name = "txt_ten";
            this.txt_ten.Size = new System.Drawing.Size(365, 26);
            this.txt_ten.TabIndex = 10;

            // 
            // txt_loai
            // 
            this.txt_loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_loai.Font = new System.Drawing.Font(
                "Segoe UI",
                10.5F
            );
            this.txt_loai.FormattingEnabled = true;
            this.txt_loai.Items.AddRange(new object[]
            {
                "PhanTram",
                "TienMat"
            });
            this.txt_loai.Location = new System.Drawing.Point(210, 240);
            this.txt_loai.Name = "txt_loai";
            this.txt_loai.Size = new System.Drawing.Size(365, 27);
            this.txt_loai.TabIndex = 11;

            // 
            // txt_giatri
            // 
            this.txt_giatri.Font = new System.Drawing.Font(
                "Segoe UI",
                10.5F
            );
            this.txt_giatri.Location = new System.Drawing.Point(210, 300);
            this.txt_giatri.Name = "txt_giatri";
            this.txt_giatri.Size = new System.Drawing.Size(365, 26);
            this.txt_giatri.TabIndex = 12;

            // 
            // txt_dontoithieu
            // 
            this.txt_dontoithieu.Font = new System.Drawing.Font(
                "Segoe UI",
                10.5F
            );
            this.txt_dontoithieu.Location = new System.Drawing.Point(210, 360);
            this.txt_dontoithieu.Name = "txt_dontoithieu";
            this.txt_dontoithieu.Size = new System.Drawing.Size(365, 26);
            this.txt_dontoithieu.TabIndex = 13;

            // 
            // txt_soluong
            // 
            this.txt_soluong.Font = new System.Drawing.Font(
                "Segoe UI",
                10.5F
            );
            this.txt_soluong.Location = new System.Drawing.Point(210, 420);
            this.txt_soluong.Name = "txt_soluong";
            this.txt_soluong.Size = new System.Drawing.Size(365, 26);
            this.txt_soluong.TabIndex = 14;

            // 
            // dt_ngaybatdau
            // 
            this.dt_ngaybatdau.Font = new System.Drawing.Font(
                "Segoe UI",
                10F
            );
            this.dt_ngaybatdau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_ngaybatdau.Location = new System.Drawing.Point(210, 480);
            this.dt_ngaybatdau.Name = "dt_ngaybatdau";
            this.dt_ngaybatdau.Size = new System.Drawing.Size(365, 25);
            this.dt_ngaybatdau.TabIndex = 15;

            // 
            // dt_ketthuc
            // 
            this.dt_ketthuc.Font = new System.Drawing.Font(
                "Segoe UI",
                10F
            );
            this.dt_ketthuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_ketthuc.Location = new System.Drawing.Point(210, 540);
            this.dt_ketthuc.Name = "dt_ketthuc";
            this.dt_ketthuc.Size = new System.Drawing.Size(365, 25);
            this.dt_ketthuc.TabIndex = 16;

            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.ForeColor = System.Drawing.Color.DimGray;
            this.lblNote.Location = new System.Drawing.Point(210, 585);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(294, 15);
            this.lblNote.TabIndex = 17;
            this.lblNote.Text = "* Giảm %: nhập 1–100 | Giảm tiền: nhập số tiền VNĐ";

            // 
            // btn_them
            // 
            this.btn_them.BackColor = System.Drawing.Color.FromArgb(
                25, 118, 210
            );
            this.btn_them.FlatAppearance.BorderSize = 0;
            this.btn_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_them.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                10.5F,
                System.Drawing.FontStyle.Bold
            );
            this.btn_them.ForeColor = System.Drawing.Color.White;
            this.btn_them.Location = new System.Drawing.Point(210, 625);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(175, 48);
            this.btn_them.TabIndex = 18;
            this.btn_them.Text = "THÊM COUPON";
            this.btn_them.UseVisualStyleBackColor = false;

            // 
            // btn_huy
            // 
            this.btn_huy.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_huy.FlatAppearance.BorderSize = 0;
            this.btn_huy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_huy.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                10.5F,
                System.Drawing.FontStyle.Bold
            );
            this.btn_huy.Location = new System.Drawing.Point(400, 625);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(175, 48);
            this.btn_huy.TabIndex = 19;
            this.btn_huy.Text = "HỦY";
            this.btn_huy.UseVisualStyleBackColor = false;

            // 
            // themcoupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 700);

            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.dt_ketthuc);
            this.Controls.Add(this.dt_ngaybatdau);
            this.Controls.Add(this.txt_soluong);
            this.Controls.Add(this.txt_dontoithieu);
            this.Controls.Add(this.txt_giatri);
            this.Controls.Add(this.txt_loai);
            this.Controls.Add(this.txt_ten);
            this.Controls.Add(this.txt_macoupon);

            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);

            this.Controls.Add(this.panelHeader);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "themcoupon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm mã giảm giá";

            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblNote;

        private System.Windows.Forms.TextBox txt_macoupon;
        private System.Windows.Forms.TextBox txt_ten;
        private System.Windows.Forms.TextBox txt_giatri;
        private System.Windows.Forms.TextBox txt_dontoithieu;
        private System.Windows.Forms.TextBox txt_soluong;

        private System.Windows.Forms.ComboBox txt_loai;

        private System.Windows.Forms.DateTimePicker dt_ngaybatdau;
        private System.Windows.Forms.DateTimePicker dt_ketthuc;

        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_huy;
    }
}
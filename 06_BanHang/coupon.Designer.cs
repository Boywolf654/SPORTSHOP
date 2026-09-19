namespace SPORTSHOP._06_BanHang
{
    partial class coupon
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_giam = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_dontoithieu = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(35, 47, 62);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(560, 82);
            // label1
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Text = "🎟  CHỌN MÃ GIẢM GIÁ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(55, 125);
            this.label2.Text = "Mã giảm giá";
            // comboBox1
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.comboBox1.Location = new System.Drawing.Point(55, 151);
            this.comboBox1.Size = new System.Drawing.Size(450, 33);
            // label3
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(55, 213);
            this.label3.Text = "Mức giảm";
            // txt_giam
            this.txt_giam.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txt_giam.Location = new System.Drawing.Point(55, 239);
            this.txt_giam.Size = new System.Drawing.Size(450, 31);
            // label4
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(55, 289);
            this.label4.Text = "Điều kiện sử dụng";
            // txt_dontoithieu
            this.txt_dontoithieu.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txt_dontoithieu.Location = new System.Drawing.Point(55, 315);
            this.txt_dontoithieu.Size = new System.Drawing.Size(450, 31);
            // lblHuongDan
            this.lblHuongDan.AutoSize = true;
            this.lblHuongDan.ForeColor = System.Drawing.Color.DimGray;
            this.lblHuongDan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHuongDan.Location = new System.Drawing.Point(55, 365);
            this.lblHuongDan.Text = "Voucher chỉ áp dụng khi còn lượt và đang trong thời gian hiệu lực.";
            // button1
            this.button1.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(55, 415);
            this.button1.Size = new System.Drawing.Size(215, 48);
            this.button1.Text = "ÁP DỤNG";
            // btnHuy
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.BackColor = System.Drawing.Color.Gainsboro;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnHuy.Location = new System.Drawing.Point(290, 415);
            this.btnHuy.Size = new System.Drawing.Size(215, 48);
            this.btnHuy.Text = "HỦY";
            // form
            this.AcceptButton = this.button1;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(560, 500);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblHuongDan);
            this.Controls.Add(this.txt_dontoithieu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_giam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelHeader);
            this.Name = "coupon";
            this.Text = "Chọn mã giảm giá";
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label1, label2, label3, label4, lblHuongDan;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txt_giam, txt_dontoithieu;
        private System.Windows.Forms.Button button1, btnHuy;
    }
}

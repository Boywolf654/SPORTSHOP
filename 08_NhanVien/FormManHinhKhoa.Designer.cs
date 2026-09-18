using System;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP
{
    partial class FormManHinhKhoa
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblGio;
        private Label lblNgay;
        private Label lblThongDiep;
        private LinkLabel lnkDangNhapID;
        private LinkLabel lnkChamCong;
        private Label lblIconDangNhap;
        private Label lblIconChamCong;
        private Timer timerClock;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblGio = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.lblThongDiep = new System.Windows.Forms.Label();
            this.lnkDangNhapID = new System.Windows.Forms.LinkLabel();
            this.lnkChamCong = new System.Windows.Forms.LinkLabel();
            this.lblIconDangNhap = new System.Windows.Forms.Label();
            this.lblIconChamCong = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblGio
            // 
            this.lblGio.AutoSize = true;
            this.lblGio.BackColor = System.Drawing.Color.Transparent;
            this.lblGio.Font = new System.Drawing.Font("Segoe UI Light", 72F);
            this.lblGio.ForeColor = System.Drawing.Color.White;
            this.lblGio.Location = new System.Drawing.Point(72, 280);
            this.lblGio.Name = "lblGio";
            this.lblGio.Size = new System.Drawing.Size(342, 159);
            this.lblGio.TabIndex = 0;
            this.lblGio.Text = "00:00";
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.lblNgay.ForeColor = System.Drawing.Color.White;
            this.lblNgay.Location = new System.Drawing.Point(78, 427);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(420, 46);
            this.lblNgay.TabIndex = 1;
            this.lblNgay.Text = "Thứ Năm, 18 tháng 9, 2026";
            // 
            // lblThongDiep
            // 
            this.lblThongDiep.AutoSize = true;
            this.lblThongDiep.BackColor = System.Drawing.Color.Transparent;
            this.lblThongDiep.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblThongDiep.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblThongDiep.Location = new System.Drawing.Point(80, 485);
            this.lblThongDiep.Name = "lblThongDiep";
            this.lblThongDiep.Size = new System.Drawing.Size(311, 60);
            this.lblThongDiep.TabIndex = 2;
            this.lblThongDiep.Text = "Thể thao không chỉ là đam mê,\r\nmà còn là lối sống.";
            // 
            // lnkDangNhapID
            // 
            this.lnkDangNhapID.ActiveLinkColor = System.Drawing.Color.Red;
            this.lnkDangNhapID.AutoSize = true;
            this.lnkDangNhapID.BackColor = System.Drawing.Color.Transparent;
            this.lnkDangNhapID.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lnkDangNhapID.ForeColor = System.Drawing.Color.White;
            this.lnkDangNhapID.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.lnkDangNhapID.LinkColor = System.Drawing.Color.White;
            this.lnkDangNhapID.Location = new System.Drawing.Point(122, 793);
            this.lnkDangNhapID.Name = "lnkDangNhapID";
            this.lnkDangNhapID.Size = new System.Drawing.Size(234, 35);
            this.lnkDangNhapID.TabIndex = 4;
            this.lnkDangNhapID.TabStop = true;
            this.lnkDangNhapID.Text = "Đăng nhập bằng ID";
            // 
            // lnkChamCong
            // 
            this.lnkChamCong.ActiveLinkColor = System.Drawing.Color.Red;
            this.lnkChamCong.AutoSize = true;
            this.lnkChamCong.BackColor = System.Drawing.Color.Transparent;
            this.lnkChamCong.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lnkChamCong.ForeColor = System.Drawing.Color.White;
            this.lnkChamCong.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.lnkChamCong.LinkColor = System.Drawing.Color.White;
            this.lnkChamCong.Location = new System.Drawing.Point(1312, 793);
            this.lnkChamCong.Name = "lnkChamCong";
            this.lnkChamCong.Size = new System.Drawing.Size(142, 35);
            this.lnkChamCong.TabIndex = 6;
            this.lnkChamCong.TabStop = true;
            this.lnkChamCong.Text = "Chấm công";
            // 
            // lblIconDangNhap
            // 
            this.lblIconDangNhap.AutoSize = true;
            this.lblIconDangNhap.BackColor = System.Drawing.Color.Transparent;
            this.lblIconDangNhap.Font = new System.Drawing.Font("Segoe UI Symbol", 27F);
            this.lblIconDangNhap.ForeColor = System.Drawing.Color.White;
            this.lblIconDangNhap.Location = new System.Drawing.Point(58, 780);
            this.lblIconDangNhap.Name = "lblIconDangNhap";
            this.lblIconDangNhap.Size = new System.Drawing.Size(72, 61);
            this.lblIconDangNhap.TabIndex = 3;
            this.lblIconDangNhap.Text = "♙";
            // 
            // lblIconChamCong
            // 
            this.lblIconChamCong.AutoSize = true;
            this.lblIconChamCong.BackColor = System.Drawing.Color.Transparent;
            this.lblIconChamCong.Font = new System.Drawing.Font("Segoe UI Symbol", 25F);
            this.lblIconChamCong.ForeColor = System.Drawing.Color.White;
            this.lblIconChamCong.Location = new System.Drawing.Point(1260, 782);
            this.lblIconChamCong.Name = "lblIconChamCong";
            this.lblIconChamCong.Size = new System.Drawing.Size(61, 57);
            this.lblIconChamCong.TabIndex = 5;
            this.lblIconChamCong.Text = "◷";
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            // 
            // FormManHinhKhoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.BackgroundImage = global::SPORTSHOP.Properties.Resources._0efc2f0c_b840_4b95_958c_66408152fd60;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1536, 864);
            this.Controls.Add(this.lblGio);
            this.Controls.Add(this.lblNgay);
            this.Controls.Add(this.lblThongDiep);
            this.Controls.Add(this.lblIconDangNhap);
            this.Controls.Add(this.lnkDangNhapID);
            this.Controls.Add(this.lblIconChamCong);
            this.Controls.Add(this.lnkChamCong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormManHinhKhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORTSHOP - Màn hình khóa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormManHinhKhoa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

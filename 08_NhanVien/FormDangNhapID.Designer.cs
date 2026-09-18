using System;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP
{
    partial class FormDangNhapID
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMain;
        private Label lblLogo;
        private Label lblTitle;
        private Label lblSubTitle;
        private Label lblID;
        private Label lblPass;
        private TextBox txtID;
        private TextBox txtMatKhau;
        private Button btnDangNhap;
        private Button btnHuy;
        private CheckBox chkHienMatKhau;
        private Label lblTrangThai;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.logoShop = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.chkHienMatKhau = new System.Windows.Forms.CheckBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.pnlMain.Controls.Add(this.logoShop);
            this.pnlMain.Controls.Add(this.lblLogo);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblSubTitle);
            this.pnlMain.Controls.Add(this.lblID);
            this.pnlMain.Controls.Add(this.txtID);
            this.pnlMain.Controls.Add(this.lblPass);
            this.pnlMain.Controls.Add(this.txtMatKhau);
            this.pnlMain.Controls.Add(this.chkHienMatKhau);
            this.pnlMain.Controls.Add(this.btnDangNhap);
            this.pnlMain.Controls.Add(this.btnHuy);
            this.pnlMain.Controls.Add(this.lblTrangThai);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(32);
            this.pnlMain.Size = new System.Drawing.Size(440, 495);
            this.pnlMain.TabIndex = 0;
            // 
            // logoShop
            // 
            this.logoShop.AutoSize = true;
            this.logoShop.Font = new System.Drawing.Font("Segoe UI Black", 21F, System.Drawing.FontStyle.Bold);
            this.logoShop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.logoShop.Location = new System.Drawing.Point(152, 23);
            this.logoShop.Name = "logoShop";
            this.logoShop.Size = new System.Drawing.Size(118, 47);
            this.logoShop.TabIndex = 0;
            this.logoShop.Text = "SHOP";
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Black", 21F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(31, 22);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(136, 47);
            this.lblLogo.TabIndex = 1;
            this.lblLogo.Text = "SPORT";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(31, 92);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(259, 54);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "ĐĂNG NHẬP";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Silver;
            this.lblSubTitle.Location = new System.Drawing.Point(36, 146);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(241, 23);
            this.lblSubTitle.TabIndex = 3;
            this.lblSubTitle.Text = "Đăng nhập bằng ID nhân viên hoặc tài khoản";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblID.ForeColor = System.Drawing.Color.White;
            this.lblID.Location = new System.Drawing.Point(34, 180);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(108, 23);
            this.lblID.TabIndex = 4;
            this.lblID.Text = "ID / Tài khoản";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtID.ForeColor = System.Drawing.Color.White;
            this.txtID.Location = new System.Drawing.Point(34, 207);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(365, 34);
            this.txtID.TabIndex = 5;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblPass.ForeColor = System.Drawing.Color.White;
            this.lblPass.Location = new System.Drawing.Point(34, 252);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(84, 23);
            this.lblPass.TabIndex = 6;
            this.lblPass.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMatKhau.ForeColor = System.Drawing.Color.White;
            this.txtMatKhau.Location = new System.Drawing.Point(34, 279);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '●';
            this.txtMatKhau.Size = new System.Drawing.Size(365, 34);
            this.txtMatKhau.TabIndex = 7;
            // 
            // chkHienMatKhau
            // 
            this.chkHienMatKhau.AutoSize = true;
            this.chkHienMatKhau.ForeColor = System.Drawing.Color.Gainsboro;
            this.chkHienMatKhau.Location = new System.Drawing.Point(34, 320);
            this.chkHienMatKhau.Name = "chkHienMatKhau";
            this.chkHienMatKhau.Size = new System.Drawing.Size(114, 20);
            this.chkHienMatKhau.TabIndex = 8;
            this.chkHienMatKhau.Text = "Hiện mật khẩu";
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(34, 357);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(175, 43);
            this.btnDangNhap.TabIndex = 9;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(224, 357);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(175, 43);
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTrangThai.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTrangThai.Location = new System.Drawing.Point(34, 414);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(365, 28);
            this.lblTrangThai.TabIndex = 11;
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormDangNhapID
            // 
            this.AcceptButton = this.btnDangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(440, 495);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDangNhapID";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SPORTSHOP - Đăng nhập";
            this.Load += new System.EventHandler(this.FormDangNhapID_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        private Label logoShop;
    }
}

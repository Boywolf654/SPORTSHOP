namespace SPORTSHOP
{
    partial class formquenmatkhau
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_matkhaumoi = new System.Windows.Forms.TextBox();
            this.txt_xacnhan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_doipass = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(191, 86);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(211, 22);
            this.txt_username.TabIndex = 0;
            // 
            // txt_matkhaumoi
            // 
            this.txt_matkhaumoi.Location = new System.Drawing.Point(191, 147);
            this.txt_matkhaumoi.Name = "txt_matkhaumoi";
            this.txt_matkhaumoi.Size = new System.Drawing.Size(211, 22);
            this.txt_matkhaumoi.TabIndex = 0;
            // 
            // txt_xacnhan
            // 
            this.txt_xacnhan.Location = new System.Drawing.Point(191, 209);
            this.txt_xacnhan.Name = "txt_xacnhan";
            this.txt_xacnhan.Size = new System.Drawing.Size(211, 22);
            this.txt_xacnhan.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(26, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên Đăng Nhập :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(26, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật Khẩu Mới :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(26, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Xác Nhận Mật khẩu :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_doipass
            // 
            this.btn_doipass.Location = new System.Drawing.Point(452, 86);
            this.btn_doipass.Name = "btn_doipass";
            this.btn_doipass.Size = new System.Drawing.Size(188, 50);
            this.btn_doipass.TabIndex = 2;
            this.btn_doipass.Text = "Đổi Mật Khẩu";
            this.btn_doipass.UseVisualStyleBackColor = true;
            this.btn_doipass.Click += new System.EventHandler(this.btn_doipass_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(452, 164);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(188, 50);
            this.btn_thoat.TabIndex = 2;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // formquenmatkhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 305);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_doipass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_xacnhan);
            this.Controls.Add(this.txt_matkhaumoi);
            this.Controls.Add(this.txt_username);
            this.Name = "formquenmatkhau";
            this.Text = "formquenmatkhau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_matkhaumoi;
        private System.Windows.Forms.TextBox txt_xacnhan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_doipass;
        private System.Windows.Forms.Button btn_thoat;
    }
}
namespace SPORTSHOP._09_BaoCao
{
    partial class Frm_BaoCao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_BaoCaoDoanhThu = new System.Windows.Forms.Label();
            this.GNgrp_BoLoc = new Guna.UI2.WinForms.Guna2GroupBox();
            this.GNdtp_TuNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lbl_LoaiBaoCao = new System.Windows.Forms.Label();
            this.lbl_TuNgay = new System.Windows.Forms.Label();
            this.lbl_DenNgay = new System.Windows.Forms.Label();
            this.GNcmb_LoaiBaoCao = new Guna.UI2.WinForms.Guna2ComboBox();
            this.GNdtp_DenNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.GNbtn_XemBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.GNbtn_Xuat = new Guna.UI2.WinForms.Guna2Button();
            this.GNbtn_In = new Guna.UI2.WinForms.Guna2Button();
            this.lbl_KetQua = new System.Windows.Forms.Label();
            this.GNdgv_DanhSachSP = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lbl_TongDoanhThu = new System.Windows.Forms.Label();
            this.GNgrp_BoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GNdgv_DanhSachSP)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_BaoCaoDoanhThu
            // 
            this.lbl_BaoCaoDoanhThu.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BaoCaoDoanhThu.Location = new System.Drawing.Point(14, 18);
            this.lbl_BaoCaoDoanhThu.Name = "lbl_BaoCaoDoanhThu";
            this.lbl_BaoCaoDoanhThu.Size = new System.Drawing.Size(400, 30);
            this.lbl_BaoCaoDoanhThu.TabIndex = 0;
            this.lbl_BaoCaoDoanhThu.Text = "Báo cáo doanh thu bán hàng";
            // 
            // GNgrp_BoLoc
            // 
            this.GNgrp_BoLoc.Controls.Add(this.GNbtn_In);
            this.GNgrp_BoLoc.Controls.Add(this.GNbtn_Xuat);
            this.GNgrp_BoLoc.Controls.Add(this.GNbtn_XemBaoCao);
            this.GNgrp_BoLoc.Controls.Add(this.GNcmb_LoaiBaoCao);
            this.GNgrp_BoLoc.Controls.Add(this.lbl_DenNgay);
            this.GNgrp_BoLoc.Controls.Add(this.lbl_TuNgay);
            this.GNgrp_BoLoc.Controls.Add(this.lbl_LoaiBaoCao);
            this.GNgrp_BoLoc.Controls.Add(this.GNdtp_DenNgay);
            this.GNgrp_BoLoc.Controls.Add(this.GNdtp_TuNgay);
            this.GNgrp_BoLoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNgrp_BoLoc.ForeColor = System.Drawing.Color.OrangeRed;
            this.GNgrp_BoLoc.Location = new System.Drawing.Point(20, 60);
            this.GNgrp_BoLoc.Name = "GNgrp_BoLoc";
            this.GNgrp_BoLoc.Size = new System.Drawing.Size(840, 185);
            this.GNgrp_BoLoc.TabIndex = 1;
            this.GNgrp_BoLoc.Text = "Bộ lọc";
            // 
            // GNdtp_TuNgay
            // 
            this.GNdtp_TuNgay.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GNdtp_TuNgay.BorderRadius = 10;
            this.GNdtp_TuNgay.Checked = true;
            this.GNdtp_TuNgay.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GNdtp_TuNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNdtp_TuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.GNdtp_TuNgay.Location = new System.Drawing.Point(261, 77);
            this.GNdtp_TuNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.GNdtp_TuNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.GNdtp_TuNgay.Name = "GNdtp_TuNgay";
            this.GNdtp_TuNgay.Size = new System.Drawing.Size(270, 36);
            this.GNdtp_TuNgay.TabIndex = 1;
            this.GNdtp_TuNgay.Value = new System.DateTime(2026, 9, 18, 7, 46, 44, 217);
            // 
            // lbl_LoaiBaoCao
            // 
            this.lbl_LoaiBaoCao.BackColor = System.Drawing.Color.Transparent;
            this.lbl_LoaiBaoCao.ForeColor = System.Drawing.Color.Black;
            this.lbl_LoaiBaoCao.Location = new System.Drawing.Point(6, 54);
            this.lbl_LoaiBaoCao.Name = "lbl_LoaiBaoCao";
            this.lbl_LoaiBaoCao.Size = new System.Drawing.Size(100, 20);
            this.lbl_LoaiBaoCao.TabIndex = 2;
            this.lbl_LoaiBaoCao.Text = "Loại báo cáo";
            // 
            // lbl_TuNgay
            // 
            this.lbl_TuNgay.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TuNgay.ForeColor = System.Drawing.Color.Black;
            this.lbl_TuNgay.Location = new System.Drawing.Point(257, 54);
            this.lbl_TuNgay.Name = "lbl_TuNgay";
            this.lbl_TuNgay.Size = new System.Drawing.Size(80, 20);
            this.lbl_TuNgay.TabIndex = 2;
            this.lbl_TuNgay.Text = "Từ Ngày";
            // 
            // lbl_DenNgay
            // 
            this.lbl_DenNgay.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DenNgay.ForeColor = System.Drawing.Color.Black;
            this.lbl_DenNgay.Location = new System.Drawing.Point(559, 54);
            this.lbl_DenNgay.Name = "lbl_DenNgay";
            this.lbl_DenNgay.Size = new System.Drawing.Size(80, 20);
            this.lbl_DenNgay.TabIndex = 2;
            this.lbl_DenNgay.Text = "Đến ngày";
            // 
            // GNcmb_LoaiBaoCao
            // 
            this.GNcmb_LoaiBaoCao.BackColor = System.Drawing.Color.Transparent;
            this.GNcmb_LoaiBaoCao.BorderRadius = 9;
            this.GNcmb_LoaiBaoCao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.GNcmb_LoaiBaoCao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GNcmb_LoaiBaoCao.FillColor = System.Drawing.Color.WhiteSmoke;
            this.GNcmb_LoaiBaoCao.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNcmb_LoaiBaoCao.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNcmb_LoaiBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GNcmb_LoaiBaoCao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.GNcmb_LoaiBaoCao.ItemHeight = 30;
            this.GNcmb_LoaiBaoCao.Location = new System.Drawing.Point(6, 77);
            this.GNcmb_LoaiBaoCao.Name = "GNcmb_LoaiBaoCao";
            this.GNcmb_LoaiBaoCao.Size = new System.Drawing.Size(227, 36);
            this.GNcmb_LoaiBaoCao.TabIndex = 3;
            // 
            // GNdtp_DenNgay
            // 
            this.GNdtp_DenNgay.BorderRadius = 10;
            this.GNdtp_DenNgay.Checked = true;
            this.GNdtp_DenNgay.FillColor = System.Drawing.Color.WhiteSmoke;
            this.GNdtp_DenNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNdtp_DenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.GNdtp_DenNgay.Location = new System.Drawing.Point(554, 77);
            this.GNdtp_DenNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.GNdtp_DenNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.GNdtp_DenNgay.Name = "GNdtp_DenNgay";
            this.GNdtp_DenNgay.Size = new System.Drawing.Size(270, 36);
            this.GNdtp_DenNgay.TabIndex = 1;
            this.GNdtp_DenNgay.Value = new System.DateTime(2026, 9, 18, 7, 46, 44, 217);
            // 
            // GNbtn_XemBaoCao
            // 
            this.GNbtn_XemBaoCao.BorderRadius = 10;
            this.GNbtn_XemBaoCao.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNbtn_XemBaoCao.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNbtn_XemBaoCao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNbtn_XemBaoCao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNbtn_XemBaoCao.FillColor = System.Drawing.Color.OrangeRed;
            this.GNbtn_XemBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNbtn_XemBaoCao.ForeColor = System.Drawing.Color.White;
            this.GNbtn_XemBaoCao.Location = new System.Drawing.Point(10, 128);
            this.GNbtn_XemBaoCao.Name = "GNbtn_XemBaoCao";
            this.GNbtn_XemBaoCao.Size = new System.Drawing.Size(180, 45);
            this.GNbtn_XemBaoCao.TabIndex = 4;
            this.GNbtn_XemBaoCao.Text = "Xem báo cáo";
            // 
            // GNbtn_Xuat
            // 
            this.GNbtn_Xuat.BorderColor = System.Drawing.Color.White;
            this.GNbtn_Xuat.BorderRadius = 10;
            this.GNbtn_Xuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNbtn_Xuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNbtn_Xuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNbtn_Xuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNbtn_Xuat.FillColor = System.Drawing.Color.White;
            this.GNbtn_Xuat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNbtn_Xuat.ForeColor = System.Drawing.Color.Black;
            this.GNbtn_Xuat.Location = new System.Drawing.Point(196, 128);
            this.GNbtn_Xuat.Name = "GNbtn_Xuat";
            this.GNbtn_Xuat.Size = new System.Drawing.Size(180, 45);
            this.GNbtn_Xuat.TabIndex = 4;
            this.GNbtn_Xuat.Text = "Xuất Excel";
            // 
            // GNbtn_In
            // 
            this.GNbtn_In.BorderRadius = 10;
            this.GNbtn_In.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNbtn_In.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNbtn_In.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNbtn_In.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNbtn_In.FillColor = System.Drawing.Color.White;
            this.GNbtn_In.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNbtn_In.ForeColor = System.Drawing.Color.Black;
            this.GNbtn_In.Location = new System.Drawing.Point(382, 128);
            this.GNbtn_In.Name = "GNbtn_In";
            this.GNbtn_In.Size = new System.Drawing.Size(72, 45);
            this.GNbtn_In.TabIndex = 4;
            this.GNbtn_In.Text = "In";
            // 
            // lbl_KetQua
            // 
            this.lbl_KetQua.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_KetQua.Location = new System.Drawing.Point(14, 263);
            this.lbl_KetQua.Name = "lbl_KetQua";
            this.lbl_KetQua.Size = new System.Drawing.Size(400, 30);
            this.lbl_KetQua.TabIndex = 0;
            this.lbl_KetQua.Text = "Kết quả";
            // 
            // GNdgv_DanhSachSP
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.GNdgv_DanhSachSP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GNdgv_DanhSachSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GNdgv_DanhSachSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GNdgv_DanhSachSP.DefaultCellStyle = dataGridViewCellStyle3;
            this.GNdgv_DanhSachSP.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GNdgv_DanhSachSP.Location = new System.Drawing.Point(20, 307);
            this.GNdgv_DanhSachSP.Name = "GNdgv_DanhSachSP";
            this.GNdgv_DanhSachSP.RowHeadersVisible = false;
            this.GNdgv_DanhSachSP.RowHeadersWidth = 51;
            this.GNdgv_DanhSachSP.RowTemplate.Height = 24;
            this.GNdgv_DanhSachSP.Size = new System.Drawing.Size(840, 150);
            this.GNdgv_DanhSachSP.TabIndex = 0;
            this.GNdgv_DanhSachSP.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.GNdgv_DanhSachSP.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GNdgv_DanhSachSP.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GNdgv_DanhSachSP.ThemeStyle.HeaderStyle.Height = 4;
            this.GNdgv_DanhSachSP.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GNdgv_DanhSachSP.ThemeStyle.RowsStyle.Height = 24;
            // 
            // lbl_TongDoanhThu
            // 
            this.lbl_TongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TongDoanhThu.Location = new System.Drawing.Point(14, 483);
            this.lbl_TongDoanhThu.Name = "lbl_TongDoanhThu";
            this.lbl_TongDoanhThu.Size = new System.Drawing.Size(400, 30);
            this.lbl_TongDoanhThu.TabIndex = 0;
            this.lbl_TongDoanhThu.Text = "Tổng doanh thu";
            // 
            // Frm_BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.GNdgv_DanhSachSP);
            this.Controls.Add(this.GNgrp_BoLoc);
            this.Controls.Add(this.lbl_TongDoanhThu);
            this.Controls.Add(this.lbl_KetQua);
            this.Controls.Add(this.lbl_BaoCaoDoanhThu);
            this.Name = "Frm_BaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_BaoCao";
            this.Load += new System.EventHandler(this.Frm_BaoCao_Load);
            this.GNgrp_BoLoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GNdgv_DanhSachSP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_BaoCaoDoanhThu;
        private Guna.UI2.WinForms.Guna2GroupBox GNgrp_BoLoc;
        private Guna.UI2.WinForms.Guna2DateTimePicker GNdtp_TuNgay;
        private System.Windows.Forms.Label lbl_TuNgay;
        private System.Windows.Forms.Label lbl_LoaiBaoCao;
        private System.Windows.Forms.Label lbl_DenNgay;
        private Guna.UI2.WinForms.Guna2ComboBox GNcmb_LoaiBaoCao;
        private Guna.UI2.WinForms.Guna2DateTimePicker GNdtp_DenNgay;
        private Guna.UI2.WinForms.Guna2Button GNbtn_XemBaoCao;
        private Guna.UI2.WinForms.Guna2Button GNbtn_In;
        private Guna.UI2.WinForms.Guna2Button GNbtn_Xuat;
        private System.Windows.Forms.Label lbl_KetQua;
        private Guna.UI2.WinForms.Guna2DataGridView GNdgv_DanhSachSP;
        private System.Windows.Forms.Label lbl_TongDoanhThu;
    }
}
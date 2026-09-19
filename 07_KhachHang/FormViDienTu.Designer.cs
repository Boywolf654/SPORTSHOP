namespace SPORTSHOP._07_KhachHang
{
    partial class FormViDienTu
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader, pnlVi, pnlDiem, pnlNap;
        private System.Windows.Forms.Label lbTitle, lbSubTitle, lbSoDuCaption, lbSoDu, lbDiemCaption, lbDiem, lbHangCaption, lbHang, lbNapTitle, lbSoTien, lbLichSu;
        private Guna.UI2.WinForms.Guna2TextBox txtSoTien;
        private Guna.UI2.WinForms.Guna2Button btn100, btn200, btn500, btn1Tr, btn2Tr, btnNap, btnLichSu;
        private System.Windows.Forms.DataGridView dgvLichSu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lbSubTitle = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pnlVi = new Guna.UI2.WinForms.Guna2Panel();
            this.lbSoDuCaption = new System.Windows.Forms.Label();
            this.lbSoDu = new System.Windows.Forms.Label();
            this.pnlDiem = new Guna.UI2.WinForms.Guna2Panel();
            this.lbDiemCaption = new System.Windows.Forms.Label();
            this.lbDiem = new System.Windows.Forms.Label();
            this.lbHangCaption = new System.Windows.Forms.Label();
            this.lbHang = new System.Windows.Forms.Label();
            this.pnlNap = new Guna.UI2.WinForms.Guna2Panel();
            this.lbNapTitle = new System.Windows.Forms.Label();
            this.lbSoTien = new System.Windows.Forms.Label();
            this.txtSoTien = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn100 = new Guna.UI2.WinForms.Guna2Button();
            this.btn200 = new Guna.UI2.WinForms.Guna2Button();
            this.btn500 = new Guna.UI2.WinForms.Guna2Button();
            this.btn1Tr = new Guna.UI2.WinForms.Guna2Button();
            this.btn2Tr = new Guna.UI2.WinForms.Guna2Button();
            this.btnNap = new Guna.UI2.WinForms.Guna2Button();
            this.lbLichSu = new System.Windows.Forms.Label();
            this.btnLichSu = new Guna.UI2.WinForms.Guna2Button();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlVi.SuspendLayout();
            this.pnlDiem.SuspendLayout();
            this.pnlNap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lbSubTitle);
            this.pnlHeader.Controls.Add(this.lbTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 115);
            this.pnlHeader.TabIndex = 6;
            // 
            // lbSubTitle
            // 
            this.lbSubTitle.AutoSize = true;
            this.lbSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbSubTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbSubTitle.Location = new System.Drawing.Point(38, 68);
            this.lbSubTitle.Name = "lbSubTitle";
            this.lbSubTitle.Size = new System.Drawing.Size(320, 23);
            this.lbSubTitle.TabIndex = 0;
            this.lbSubTitle.Text = "Số dư • Điểm hội viên • Lịch sử giao dịch";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lbTitle.ForeColor = System.Drawing.Color.RosyBrown;
            this.lbTitle.Location = new System.Drawing.Point(35, 20);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(482, 50);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "💳 Ví điện tử SPORTSHOP";
            // 
            // pnlVi
            // 
            this.pnlVi.BorderRadius = 16;
            this.pnlVi.Controls.Add(this.lbSoDuCaption);
            this.pnlVi.Controls.Add(this.lbSoDu);
            this.pnlVi.FillColor = System.Drawing.Color.White;
            this.pnlVi.Location = new System.Drawing.Point(35, 140);
            this.pnlVi.Name = "pnlVi";
            this.pnlVi.Size = new System.Drawing.Size(490, 165);
            this.pnlVi.TabIndex = 5;
            // 
            // lbSoDuCaption
            // 
            this.lbSoDuCaption.AutoSize = true;
            this.lbSoDuCaption.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lbSoDuCaption.Location = new System.Drawing.Point(25, 20);
            this.lbSoDuCaption.Name = "lbSoDuCaption";
            this.lbSoDuCaption.Size = new System.Drawing.Size(177, 25);
            this.lbSoDuCaption.TabIndex = 0;
            this.lbSoDuCaption.Text = "💰  SỐ DƯ HIỆN TẠI";
            // 
            // lbSoDu
            // 
            this.lbSoDu.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.lbSoDu.Location = new System.Drawing.Point(22, 58);
            this.lbSoDu.Name = "lbSoDu";
            this.lbSoDu.Size = new System.Drawing.Size(440, 55);
            this.lbSoDu.TabIndex = 1;
            this.lbSoDu.Text = "0 đ";
            // 
            // pnlDiem
            // 
            this.pnlDiem.BorderRadius = 16;
            this.pnlDiem.Controls.Add(this.lbDiemCaption);
            this.pnlDiem.Controls.Add(this.lbDiem);
            this.pnlDiem.Controls.Add(this.lbHangCaption);
            this.pnlDiem.Controls.Add(this.lbHang);
            this.pnlDiem.FillColor = System.Drawing.Color.White;
            this.pnlDiem.Location = new System.Drawing.Point(545, 140);
            this.pnlDiem.Name = "pnlDiem";
            this.pnlDiem.Size = new System.Drawing.Size(520, 165);
            this.pnlDiem.TabIndex = 4;
            // 
            // lbDiemCaption
            // 
            this.lbDiemCaption.AutoSize = true;
            this.lbDiemCaption.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lbDiemCaption.Location = new System.Drawing.Point(25, 20);
            this.lbDiemCaption.Name = "lbDiemCaption";
            this.lbDiemCaption.Size = new System.Drawing.Size(166, 25);
            this.lbDiemCaption.TabIndex = 0;
            this.lbDiemCaption.Text = "⭐  ĐIỂM HỘI VIÊN";
            // 
            // lbDiem
            // 
            this.lbDiem.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lbDiem.Location = new System.Drawing.Point(22, 55);
            this.lbDiem.Name = "lbDiem";
            this.lbDiem.Size = new System.Drawing.Size(220, 45);
            this.lbDiem.TabIndex = 1;
            this.lbDiem.Text = "0 điểm";
            // 
            // lbHangCaption
            // 
            this.lbHangCaption.AutoSize = true;
            this.lbHangCaption.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lbHangCaption.Location = new System.Drawing.Point(290, 20);
            this.lbHangCaption.Name = "lbHangCaption";
            this.lbHangCaption.Size = new System.Drawing.Size(95, 25);
            this.lbHangCaption.TabIndex = 2;
            this.lbHangCaption.Text = "👑  HẠNG";
            // 
            // lbHang
            // 
            this.lbHang.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lbHang.Location = new System.Drawing.Point(287, 55);
            this.lbHang.Name = "lbHang";
            this.lbHang.Size = new System.Drawing.Size(200, 45);
            this.lbHang.TabIndex = 3;
            this.lbHang.Text = "Đồng";
            // 
            // pnlNap
            // 
            this.pnlNap.BorderRadius = 16;
            this.pnlNap.Controls.Add(this.lbNapTitle);
            this.pnlNap.Controls.Add(this.lbSoTien);
            this.pnlNap.Controls.Add(this.txtSoTien);
            this.pnlNap.Controls.Add(this.btn100);
            this.pnlNap.Controls.Add(this.btn200);
            this.pnlNap.Controls.Add(this.btn500);
            this.pnlNap.Controls.Add(this.btn1Tr);
            this.pnlNap.Controls.Add(this.btn2Tr);
            this.pnlNap.Controls.Add(this.btnNap);
            this.pnlNap.FillColor = System.Drawing.Color.White;
            this.pnlNap.Location = new System.Drawing.Point(35, 325);
            this.pnlNap.Name = "pnlNap";
            this.pnlNap.Size = new System.Drawing.Size(1030, 180);
            this.pnlNap.TabIndex = 3;
            // 
            // lbNapTitle
            // 
            this.lbNapTitle.AutoSize = true;
            this.lbNapTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lbNapTitle.Location = new System.Drawing.Point(25, 18);
            this.lbNapTitle.Name = "lbNapTitle";
            this.lbNapTitle.Size = new System.Drawing.Size(243, 35);
            this.lbNapTitle.TabIndex = 0;
            this.lbNapTitle.Text = "💳  Nạp tiền vào ví";
            // 
            // lbSoTien
            // 
            this.lbSoTien.AutoSize = true;
            this.lbSoTien.Location = new System.Drawing.Point(25, 58);
            this.lbSoTien.Name = "lbSoTien";
            this.lbSoTien.Size = new System.Drawing.Size(66, 16);
            this.lbSoTien.TabIndex = 1;
            this.lbSoTien.Text = "💵  Số tiền";
            // 
            // txtSoTien
            // 
            this.txtSoTien.BorderRadius = 9;
            this.txtSoTien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoTien.DefaultText = "";
            this.txtSoTien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSoTien.Location = new System.Drawing.Point(25, 84);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.PlaceholderText = "Nhập số tiền...";
            this.txtSoTien.SelectedText = "";
            this.txtSoTien.Size = new System.Drawing.Size(285, 40);
            this.txtSoTien.TabIndex = 2;
            // 
            // btn100
            // 
            this.btn100.BorderRadius = 8;
            this.btn100.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn100.ForeColor = System.Drawing.Color.White;
            this.btn100.Location = new System.Drawing.Point(354, 45);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(108, 40);
            this.btn100.TabIndex = 3;
            this.btn100.Text = "💵  100K";
            // 
            // btn200
            // 
            this.btn200.BorderRadius = 8;
            this.btn200.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn200.ForeColor = System.Drawing.Color.White;
            this.btn200.Location = new System.Drawing.Point(354, 108);
            this.btn200.Name = "btn200";
            this.btn200.Size = new System.Drawing.Size(108, 40);
            this.btn200.TabIndex = 4;
            this.btn200.Text = "💵  200K";
            // 
            // btn500
            // 
            this.btn500.BorderRadius = 8;
            this.btn500.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn500.ForeColor = System.Drawing.Color.White;
            this.btn500.Location = new System.Drawing.Point(489, 45);
            this.btn500.Name = "btn500";
            this.btn500.Size = new System.Drawing.Size(121, 40);
            this.btn500.TabIndex = 5;
            this.btn500.Text = "💵  500K";
            // 
            // btn1Tr
            // 
            this.btn1Tr.BorderRadius = 8;
            this.btn1Tr.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn1Tr.ForeColor = System.Drawing.Color.White;
            this.btn1Tr.Location = new System.Drawing.Point(489, 108);
            this.btn1Tr.Name = "btn1Tr";
            this.btn1Tr.Size = new System.Drawing.Size(121, 40);
            this.btn1Tr.TabIndex = 6;
            this.btn1Tr.Text = "💰  1 TRIỆU";
            // 
            // btn2Tr
            // 
            this.btn2Tr.BorderRadius = 8;
            this.btn2Tr.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn2Tr.ForeColor = System.Drawing.Color.White;
            this.btn2Tr.Location = new System.Drawing.Point(637, 45);
            this.btn2Tr.Name = "btn2Tr";
            this.btn2Tr.Size = new System.Drawing.Size(122, 40);
            this.btn2Tr.TabIndex = 7;
            this.btn2Tr.Text = "💰  2 TRIỆU";
            // 
            // btnNap
            // 
            this.btnNap.BorderRadius = 9;
            this.btnNap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNap.ForeColor = System.Drawing.Color.White;
            this.btnNap.Location = new System.Drawing.Point(637, 108);
            this.btnNap.Name = "btnNap";
            this.btnNap.Size = new System.Drawing.Size(180, 40);
            this.btnNap.TabIndex = 8;
            this.btnNap.Text = "💳  NẠP TIỀN";
            // 
            // lbLichSu
            // 
            this.lbLichSu.AutoSize = true;
            this.lbLichSu.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lbLichSu.Location = new System.Drawing.Point(35, 535);
            this.lbLichSu.Name = "lbLichSu";
            this.lbLichSu.Size = new System.Drawing.Size(259, 35);
            this.lbLichSu.TabIndex = 2;
            this.lbLichSu.Text = "📋  Lịch sử giao dịch";
            // 
            // btnLichSu
            // 
            this.btnLichSu.BorderRadius = 9;
            this.btnLichSu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLichSu.ForeColor = System.Drawing.Color.White;
            this.btnLichSu.Location = new System.Drawing.Point(925, 530);
            this.btnLichSu.Name = "btnLichSu";
            this.btnLichSu.Size = new System.Drawing.Size(140, 38);
            this.btnLichSu.TabIndex = 1;
            this.btnLichSu.Text = "🔄  Làm mới";
            // 
            // dgvLichSu
            // 
            this.dgvLichSu.AllowUserToAddRows = false;
            this.dgvLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSu.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSu.ColumnHeadersHeight = 29;
            this.dgvLichSu.Location = new System.Drawing.Point(35, 580);
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.ReadOnly = true;
            this.dgvLichSu.RowHeadersWidth = 51;
            this.dgvLichSu.RowTemplate.Height = 32;
            this.dgvLichSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSu.Size = new System.Drawing.Size(1030, 230);
            this.dgvLichSu.TabIndex = 0;
            // 
            // FormViDienTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1100, 840);
            this.Controls.Add(this.dgvLichSu);
            this.Controls.Add(this.btnLichSu);
            this.Controls.Add(this.lbLichSu);
            this.Controls.Add(this.pnlNap);
            this.Controls.Add(this.pnlDiem);
            this.Controls.Add(this.pnlVi);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FormViDienTu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ví điện tử SPORTSHOP";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlVi.ResumeLayout(false);
            this.pnlVi.PerformLayout();
            this.pnlDiem.ResumeLayout(false);
            this.pnlDiem.PerformLayout();
            this.pnlNap.ResumeLayout(false);
            this.pnlNap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

namespace SPORTSHOP._07_KhachHang
{
    partial class FormViDienTu
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader, pnlVi, pnlDiem, pnlNap;
        private System.Windows.Forms.Label lbTitle, lbSubTitle, lbSoDuCaption, lbSoDu, lbDiemCaption, lbDiem, lbHangCaption, lbHang, lbNapTitle, lbSoTien, lbLichSu;
        private System.Windows.Forms.Label lbIconVi, lbIconDiem;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lbSubTitle = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pnlVi = new Guna.UI2.WinForms.Guna2Panel();
            this.lbIconVi = new System.Windows.Forms.Label();
            this.lbSoDuCaption = new System.Windows.Forms.Label();
            this.lbSoDu = new System.Windows.Forms.Label();
            this.pnlDiem = new Guna.UI2.WinForms.Guna2Panel();
            this.lbIconDiem = new System.Windows.Forms.Label();
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
            this.lbSubTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(185)))));
            this.lbSubTitle.Location = new System.Drawing.Point(38, 68);
            this.lbSubTitle.Name = "lbSubTitle";
            this.lbSubTitle.Size = new System.Drawing.Size(320, 23);
            this.lbSubTitle.TabIndex = 0;
            this.lbSubTitle.Text = "Số dư • Điểm hội viên • Lịch sử giao dịch";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(35, 18);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(482, 50);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "💳 Ví điện tử SPORTSHOP";
            // 
            // pnlVi
            // 
            this.pnlVi.BackColor = System.Drawing.Color.Transparent;
            this.pnlVi.BorderRadius = 16;
            this.pnlVi.Controls.Add(this.lbIconVi);
            this.pnlVi.Controls.Add(this.lbSoDuCaption);
            this.pnlVi.Controls.Add(this.lbSoDu);
            this.pnlVi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.pnlVi.Location = new System.Drawing.Point(35, 140);
            this.pnlVi.Name = "pnlVi";
            this.pnlVi.ShadowDecoration.BorderRadius = 16;
            this.pnlVi.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.pnlVi.ShadowDecoration.Depth = 10;
            this.pnlVi.ShadowDecoration.Enabled = true;
            this.pnlVi.Size = new System.Drawing.Size(490, 165);
            this.pnlVi.TabIndex = 5;
            // 
            // lbIconVi
            // 
            this.lbIconVi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.lbIconVi.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lbIconVi.ForeColor = System.Drawing.Color.White;
            this.lbIconVi.Location = new System.Drawing.Point(22, 18);
            this.lbIconVi.Name = "lbIconVi";
            this.lbIconVi.Size = new System.Drawing.Size(50, 50);
            this.lbIconVi.TabIndex = 2;
            this.lbIconVi.Text = "💰";
            this.lbIconVi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSoDuCaption
            // 
            this.lbSoDuCaption.AutoSize = true;
            this.lbSoDuCaption.BackColor = System.Drawing.Color.Transparent;
            this.lbSoDuCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.lbSoDuCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.lbSoDuCaption.Location = new System.Drawing.Point(82, 26);
            this.lbSoDuCaption.Name = "lbSoDuCaption";
            this.lbSoDuCaption.Size = new System.Drawing.Size(145, 25);
            this.lbSoDuCaption.TabIndex = 0;
            this.lbSoDuCaption.Text = "SỐ DƯ HIỆN TẠI";
            // 
            // lbSoDu
            // 
            this.lbSoDu.BackColor = System.Drawing.Color.Transparent;
            this.lbSoDu.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lbSoDu.ForeColor = System.Drawing.Color.White;
            this.lbSoDu.Location = new System.Drawing.Point(24, 88);
            this.lbSoDu.Name = "lbSoDu";
            this.lbSoDu.Size = new System.Drawing.Size(445, 55);
            this.lbSoDu.TabIndex = 1;
            this.lbSoDu.Text = "0 đ";
            // 
            // pnlDiem
            // 
            this.pnlDiem.BackColor = System.Drawing.Color.Transparent;
            this.pnlDiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.pnlDiem.BorderRadius = 16;
            this.pnlDiem.BorderThickness = 1;
            this.pnlDiem.Controls.Add(this.lbIconDiem);
            this.pnlDiem.Controls.Add(this.lbDiemCaption);
            this.pnlDiem.Controls.Add(this.lbDiem);
            this.pnlDiem.Controls.Add(this.lbHangCaption);
            this.pnlDiem.Controls.Add(this.lbHang);
            this.pnlDiem.FillColor = System.Drawing.Color.White;
            this.pnlDiem.Location = new System.Drawing.Point(545, 140);
            this.pnlDiem.Name = "pnlDiem";
            this.pnlDiem.ShadowDecoration.BorderRadius = 16;
            this.pnlDiem.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.pnlDiem.ShadowDecoration.Depth = 6;
            this.pnlDiem.ShadowDecoration.Enabled = true;
            this.pnlDiem.Size = new System.Drawing.Size(520, 165);
            this.pnlDiem.TabIndex = 4;
            // 
            // lbIconDiem
            // 
            this.lbIconDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this.lbIconDiem.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lbIconDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lbIconDiem.Location = new System.Drawing.Point(22, 18);
            this.lbIconDiem.Name = "lbIconDiem";
            this.lbIconDiem.Size = new System.Drawing.Size(50, 50);
            this.lbIconDiem.TabIndex = 4;
            this.lbIconDiem.Text = "⭐";
            this.lbIconDiem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDiemCaption
            // 
            this.lbDiemCaption.AutoSize = true;
            this.lbDiemCaption.BackColor = System.Drawing.Color.Transparent;
            this.lbDiemCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lbDiemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(115)))), ((int)(((byte)(125)))));
            this.lbDiemCaption.Location = new System.Drawing.Point(82, 24);
            this.lbDiemCaption.Name = "lbDiemCaption";
            this.lbDiemCaption.Size = new System.Drawing.Size(121, 21);
            this.lbDiemCaption.TabIndex = 0;
            this.lbDiemCaption.Text = "ĐIỂM HỘI VIÊN";
            // 
            // lbDiem
            // 
            this.lbDiem.BackColor = System.Drawing.Color.Transparent;
            this.lbDiem.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lbDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lbDiem.Location = new System.Drawing.Point(80, 50);
            this.lbDiem.Name = "lbDiem";
            this.lbDiem.Size = new System.Drawing.Size(220, 45);
            this.lbDiem.TabIndex = 1;
            this.lbDiem.Text = "0 điểm";
            // 
            // lbHangCaption
            // 
            this.lbHangCaption.AutoSize = true;
            this.lbHangCaption.BackColor = System.Drawing.Color.Transparent;
            this.lbHangCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lbHangCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(115)))), ((int)(((byte)(125)))));
            this.lbHangCaption.Location = new System.Drawing.Point(340, 24);
            this.lbHangCaption.Name = "lbHangCaption";
            this.lbHangCaption.Size = new System.Drawing.Size(155, 21);
            this.lbHangCaption.TabIndex = 2;
            this.lbHangCaption.Text = "HẠNG THÀNH VIÊN";
            // 
            // lbHang
            // 
            this.lbHang.BackColor = System.Drawing.Color.Transparent;
            this.lbHang.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lbHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lbHang.Location = new System.Drawing.Point(338, 50);
            this.lbHang.Name = "lbHang";
            this.lbHang.Size = new System.Drawing.Size(160, 45);
            this.lbHang.TabIndex = 3;
            this.lbHang.Text = "Đồng";
            // 
            // pnlNap
            // 
            this.pnlNap.BackColor = System.Drawing.Color.Transparent;
            this.pnlNap.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.pnlNap.BorderRadius = 16;
            this.pnlNap.BorderThickness = 1;
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
            this.pnlNap.ShadowDecoration.BorderRadius = 16;
            this.pnlNap.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.pnlNap.ShadowDecoration.Depth = 6;
            this.pnlNap.ShadowDecoration.Enabled = true;
            this.pnlNap.Size = new System.Drawing.Size(1030, 180);
            this.pnlNap.TabIndex = 3;
            // 
            // lbNapTitle
            // 
            this.lbNapTitle.AutoSize = true;
            this.lbNapTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbNapTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lbNapTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lbNapTitle.Location = new System.Drawing.Point(25, 18);
            this.lbNapTitle.Name = "lbNapTitle";
            this.lbNapTitle.Size = new System.Drawing.Size(243, 35);
            this.lbNapTitle.TabIndex = 0;
            this.lbNapTitle.Text = "💳  Nạp tiền vào ví";
            // 
            // lbSoTien
            // 
            this.lbSoTien.AutoSize = true;
            this.lbSoTien.BackColor = System.Drawing.Color.Transparent;
            this.lbSoTien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lbSoTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(115)))), ((int)(((byte)(125)))));
            this.lbSoTien.Location = new System.Drawing.Point(25, 60);
            this.lbSoTien.Name = "lbSoTien";
            this.lbSoTien.Size = new System.Drawing.Size(88, 21);
            this.lbSoTien.TabIndex = 1;
            this.lbSoTien.Text = "💵  Số tiền";
            // 
            // txtSoTien
            // 
            this.txtSoTien.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.txtSoTien.BorderRadius = 9;
            this.txtSoTien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoTien.DefaultText = "";
            this.txtSoTien.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtSoTien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.txtSoTien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtSoTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            this.txtSoTien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
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
            this.btn100.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn100.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn100.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            this.btn100.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(175)))));
            this.btn100.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.btn100.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn100.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.btn100.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(233)))));
            this.btn100.Location = new System.Drawing.Point(354, 45);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(108, 40);
            this.btn100.TabIndex = 3;
            this.btn100.Text = "100K";
            this.btn100.Click += new System.EventHandler(this.btn100_Click);
            // 
            // btn200
            // 
            this.btn200.BorderRadius = 8;
            this.btn200.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn200.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn200.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            this.btn200.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(175)))));
            this.btn200.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.btn200.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn200.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.btn200.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(233)))));
            this.btn200.Location = new System.Drawing.Point(354, 108);
            this.btn200.Name = "btn200";
            this.btn200.Size = new System.Drawing.Size(108, 40);
            this.btn200.TabIndex = 4;
            this.btn200.Text = "200K";
            this.btn200.Click += new System.EventHandler(this.btn200_Click);
            // 
            // btn500
            // 
            this.btn500.BorderRadius = 8;
            this.btn500.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn500.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn500.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            this.btn500.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(175)))));
            this.btn500.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.btn500.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn500.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.btn500.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(233)))));
            this.btn500.Location = new System.Drawing.Point(489, 45);
            this.btn500.Name = "btn500";
            this.btn500.Size = new System.Drawing.Size(121, 40);
            this.btn500.TabIndex = 5;
            this.btn500.Text = "500K";
            this.btn500.Click += new System.EventHandler(this.btn500_Click);
            // 
            // btn1Tr
            // 
            this.btn1Tr.BorderRadius = 8;
            this.btn1Tr.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn1Tr.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn1Tr.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            this.btn1Tr.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(175)))));
            this.btn1Tr.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.btn1Tr.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn1Tr.ForeColor = System.Drawing.Color.White;
            this.btn1Tr.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.btn1Tr.Location = new System.Drawing.Point(489, 108);
            this.btn1Tr.Name = "btn1Tr";
            this.btn1Tr.Size = new System.Drawing.Size(121, 40);
            this.btn1Tr.TabIndex = 6;
            this.btn1Tr.Text = "1 TRIỆU";
            this.btn1Tr.Click += new System.EventHandler(this.btn1Tr_Click);
            // 
            // btn2Tr
            // 
            this.btn2Tr.BorderRadius = 8;
            this.btn2Tr.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn2Tr.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn2Tr.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            this.btn2Tr.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(175)))));
            this.btn2Tr.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.btn2Tr.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn2Tr.ForeColor = System.Drawing.Color.White;
            this.btn2Tr.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.btn2Tr.Location = new System.Drawing.Point(637, 45);
            this.btn2Tr.Name = "btn2Tr";
            this.btn2Tr.Size = new System.Drawing.Size(122, 40);
            this.btn2Tr.TabIndex = 7;
            this.btn2Tr.Text = "2 TRIỆU";
            this.btn2Tr.Click += new System.EventHandler(this.btn2Tr_Click);
            // 
            // btnNap
            // 
            this.btnNap.BorderRadius = 9;
            this.btnNap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            this.btnNap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(175)))));
            this.btnNap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnNap.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnNap.ForeColor = System.Drawing.Color.White;
            this.btnNap.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.btnNap.Location = new System.Drawing.Point(637, 108);
            this.btnNap.Name = "btnNap";
            this.btnNap.Size = new System.Drawing.Size(180, 40);
            this.btnNap.TabIndex = 8;
            this.btnNap.Text = "💳  NẠP TIỀN";
            this.btnNap.Click += new System.EventHandler(this.btnNap_Click);
            // 
            // lbLichSu
            // 
            this.lbLichSu.AutoSize = true;
            this.lbLichSu.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lbLichSu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lbLichSu.Location = new System.Drawing.Point(35, 535);
            this.lbLichSu.Name = "lbLichSu";
            this.lbLichSu.Size = new System.Drawing.Size(259, 35);
            this.lbLichSu.TabIndex = 2;
            this.lbLichSu.Text = "📋  Lịch sử giao dịch";
            // 
            // btnLichSu
            // 
            this.btnLichSu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLichSu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.btnLichSu.BorderRadius = 9;
            this.btnLichSu.BorderThickness = 1;
            this.btnLichSu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLichSu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLichSu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            this.btnLichSu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(175)))));
            this.btnLichSu.FillColor = System.Drawing.Color.White;
            this.btnLichSu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLichSu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.btnLichSu.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.btnLichSu.Location = new System.Drawing.Point(925, 530);
            this.btnLichSu.Name = "btnLichSu";
            this.btnLichSu.Size = new System.Drawing.Size(140, 38);
            this.btnLichSu.TabIndex = 1;
            this.btnLichSu.Text = "🔄  Làm mới";
            this.btnLichSu.Click += new System.EventHandler(this.btnLichSu_Click);
            // 
            // dgvLichSu
            // 
            this.dgvLichSu.AllowUserToAddRows = false;
            this.dgvLichSu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.dgvLichSu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLichSu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSu.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLichSu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLichSu.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvLichSu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLichSu.ColumnHeadersHeight = 40;
            this.dgvLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLichSu.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLichSu.EnableHeadersVisualStyles = false;
            this.dgvLichSu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.dgvLichSu.Location = new System.Drawing.Point(35, 580);
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.ReadOnly = true;
            this.dgvLichSu.RowHeadersVisible = false;
            this.dgvLichSu.RowHeadersWidth = 51;
            this.dgvLichSu.RowTemplate.Height = 34;
            this.dgvLichSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSu.Size = new System.Drawing.Size(1030, 230);
            this.dgvLichSu.TabIndex = 0;
            // 
            // FormViDienTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1100, 840);
            this.Controls.Add(this.dgvLichSu);
            this.Controls.Add(this.btnLichSu);
            this.Controls.Add(this.lbLichSu);
            this.Controls.Add(this.pnlNap);
            this.Controls.Add(this.pnlDiem);
            this.Controls.Add(this.pnlVi);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "FormViDienTu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORTSHOP - Ví điện tử";
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
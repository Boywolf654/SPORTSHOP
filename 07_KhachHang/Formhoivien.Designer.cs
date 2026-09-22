namespace SPORTSHOP._07_KhachHang
{
    partial class FormHoiVien
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblXinChao;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDong;

        private System.Windows.Forms.Panel pnlHang;
        private System.Windows.Forms.Label lblHangCaption;
        private System.Windows.Forms.Label lblHang;
        private System.Windows.Forms.Label lblDiemCaption;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.Label lblUuDai;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.Label lblQuyDoi;

        private System.Windows.Forms.Panel pnlTienDo;
        private System.Windows.Forms.Label lblNextHang;
        private System.Windows.Forms.ProgressBar progressHang;
        private System.Windows.Forms.Label lblTienDo;
        private System.Windows.Forms.Label lblConThieu;

        private System.Windows.Forms.Panel pnlHangHoiVien;
        private System.Windows.Forms.Label lblDanhSachHang;
        private System.Windows.Forms.DataGridView dgvHang;

        private System.Windows.Forms.Panel pnlLichSu;
        private System.Windows.Forms.Label lblLichSuTitle;
        private System.Windows.Forms.DataGridView dgvLichSu;

        private System.Windows.Forms.DataGridViewTextBoxColumn colHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMocDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUuDai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;

        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLyDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHD;

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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblXinChao = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlHang = new System.Windows.Forms.Panel();
            this.lblQuyDoi = new System.Windows.Forms.Label();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.lblUuDai = new System.Windows.Forms.Label();
            this.lblDiem = new System.Windows.Forms.Label();
            this.lblDiemCaption = new System.Windows.Forms.Label();
            this.lblHang = new System.Windows.Forms.Label();
            this.lblHangCaption = new System.Windows.Forms.Label();
            this.pnlTienDo = new System.Windows.Forms.Panel();
            this.lblConThieu = new System.Windows.Forms.Label();
            this.lblTienDo = new System.Windows.Forms.Label();
            this.progressHang = new System.Windows.Forms.ProgressBar();
            this.lblNextHang = new System.Windows.Forms.Label();
            this.pnlHangHoiVien = new System.Windows.Forms.Panel();
            this.dgvHang = new System.Windows.Forms.DataGridView();
            this.colHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMocDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUuDai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDanhSachHang = new System.Windows.Forms.Label();
            this.pnlLichSu = new System.Windows.Forms.Panel();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLyDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLichSuTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlHang.SuspendLayout();
            this.pnlTienDo.SuspendLayout();
            this.pnlHangHoiVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHang)).BeginInit();
            this.pnlLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.pnlHeader.Controls.Add(this.btnDong);
            this.pnlHeader.Controls.Add(this.btnLamMoi);
            this.pnlHeader.Controls.Add(this.lblXinChao);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1120, 105);
            this.pnlHeader.TabIndex = 4;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(935, 30);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(145, 38);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(795, 30);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(125, 38);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "↻  Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // lblXinChao
            // 
            this.lblXinChao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblXinChao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(95)))), ((int)(((byte)(105)))));
            this.lblXinChao.Location = new System.Drawing.Point(506, 37);
            this.lblXinChao.Name = "lblXinChao";
            this.lblXinChao.Size = new System.Drawing.Size(250, 26);
            this.lblXinChao.TabIndex = 2;
            this.lblXinChao.Text = "Xin chào";
            this.lblXinChao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(195)))));
            this.lblSubTitle.Location = new System.Drawing.Point(31, 57);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(352, 21);
            this.lblSubTitle.TabIndex = 3;
            this.lblSubTitle.Text = "Theo dõi điểm tích lũy • Hạng thành viên • Ưu đãi";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(28, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(445, 47);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "⭐  HỘI VIÊN SPORTSHOP";
            // 
            // pnlHang
            // 
            this.pnlHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHang.Controls.Add(this.lblQuyDoi);
            this.pnlHang.Controls.Add(this.lblMaKH);
            this.pnlHang.Controls.Add(this.lblUuDai);
            this.pnlHang.Controls.Add(this.lblDiem);
            this.pnlHang.Controls.Add(this.lblDiemCaption);
            this.pnlHang.Controls.Add(this.lblHang);
            this.pnlHang.Controls.Add(this.lblHangCaption);
            this.pnlHang.Location = new System.Drawing.Point(28, 125);
            this.pnlHang.Name = "pnlHang";
            this.pnlHang.Size = new System.Drawing.Size(520, 180);
            this.pnlHang.TabIndex = 3;
            // 
            // lblQuyDoi
            // 
            this.lblQuyDoi.AutoSize = true;
            this.lblQuyDoi.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblQuyDoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.lblQuyDoi.Location = new System.Drawing.Point(265, 137);
            this.lblQuyDoi.Name = "lblQuyDoi";
            this.lblQuyDoi.Size = new System.Drawing.Size(206, 20);
            this.lblQuyDoi.TabIndex = 0;
            this.lblQuyDoi.Text = "Quy đổi: 1 điểm / 10.000 VNĐ";
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMaKH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.lblMaKH.Location = new System.Drawing.Point(22, 137);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(112, 20);
            this.lblMaKH.TabIndex = 1;
            this.lblMaKH.Text = "Mã khách hàng:";
            // 
            // lblUuDai
            // 
            this.lblUuDai.AutoSize = true;
            this.lblUuDai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUuDai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.lblUuDai.Location = new System.Drawing.Point(22, 100);
            this.lblUuDai.Name = "lblUuDai";
            this.lblUuDai.Size = new System.Drawing.Size(143, 23);
            this.lblUuDai.TabIndex = 2;
            this.lblUuDai.Text = "Ưu đãi hạng: 0%";
            // 
            // lblDiem
            // 
            this.lblDiem.AutoSize = true;
            this.lblDiem.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.lblDiem.Location = new System.Drawing.Point(263, 47);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(141, 50);
            this.lblDiem.TabIndex = 3;
            this.lblDiem.Text = "0 điểm";
            // 
            // lblDiemCaption
            // 
            this.lblDiemCaption.AutoSize = true;
            this.lblDiemCaption.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDiemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(108)))));
            this.lblDiemCaption.Location = new System.Drawing.Point(265, 18);
            this.lblDiemCaption.Name = "lblDiemCaption";
            this.lblDiemCaption.Size = new System.Drawing.Size(125, 21);
            this.lblDiemCaption.TabIndex = 4;
            this.lblDiemCaption.Text = "ĐIỂM TÍCH LŨY";
            // 
            // lblHang
            // 
            this.lblHang.AutoSize = true;
            this.lblHang.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.lblHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(105)))), ((int)(((byte)(55)))));
            this.lblHang.Location = new System.Drawing.Point(20, 43);
            this.lblHang.Name = "lblHang";
            this.lblHang.Size = new System.Drawing.Size(133, 57);
            this.lblHang.TabIndex = 5;
            this.lblHang.Text = "Đồng";
            // 
            // lblHangCaption
            // 
            this.lblHangCaption.AutoSize = true;
            this.lblHangCaption.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHangCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(108)))));
            this.lblHangCaption.Location = new System.Drawing.Point(22, 18);
            this.lblHangCaption.Name = "lblHangCaption";
            this.lblHangCaption.Size = new System.Drawing.Size(129, 21);
            this.lblHangCaption.TabIndex = 6;
            this.lblHangCaption.Text = "HẠNG HIỆN TẠI";
            // 
            // pnlTienDo
            // 
            this.pnlTienDo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlTienDo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTienDo.Controls.Add(this.lblConThieu);
            this.pnlTienDo.Controls.Add(this.lblTienDo);
            this.pnlTienDo.Controls.Add(this.progressHang);
            this.pnlTienDo.Controls.Add(this.lblNextHang);
            this.pnlTienDo.Location = new System.Drawing.Point(568, 125);
            this.pnlTienDo.Name = "pnlTienDo";
            this.pnlTienDo.Size = new System.Drawing.Size(524, 180);
            this.pnlTienDo.TabIndex = 2;
            // 
            // lblConThieu
            // 
            this.lblConThieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConThieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(112)))));
            this.lblConThieu.Location = new System.Drawing.Point(25, 130);
            this.lblConThieu.Name = "lblConThieu";
            this.lblConThieu.Size = new System.Drawing.Size(470, 28);
            this.lblConThieu.TabIndex = 0;
            this.lblConThieu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTienDo
            // 
            this.lblTienDo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTienDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.lblTienDo.Location = new System.Drawing.Point(25, 98);
            this.lblTienDo.Name = "lblTienDo";
            this.lblTienDo.Size = new System.Drawing.Size(470, 24);
            this.lblTienDo.TabIndex = 1;
            this.lblTienDo.Text = "0 / 0 điểm";
            this.lblTienDo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressHang
            // 
            this.progressHang.Location = new System.Drawing.Point(25, 68);
            this.progressHang.Name = "progressHang";
            this.progressHang.Size = new System.Drawing.Size(470, 22);
            this.progressHang.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressHang.TabIndex = 2;
            // 
            // lblNextHang
            // 
            this.lblNextHang.AutoSize = true;
            this.lblNextHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNextHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.lblNextHang.Location = new System.Drawing.Point(22, 18);
            this.lblNextHang.Name = "lblNextHang";
            this.lblNextHang.Size = new System.Drawing.Size(188, 28);
            this.lblNextHang.TabIndex = 3;
            this.lblNextHang.Text = "Mục tiêu tiếp theo";
            // 
            // pnlHangHoiVien
            // 
            this.pnlHangHoiVien.BackColor = System.Drawing.Color.White;
            this.pnlHangHoiVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHangHoiVien.Controls.Add(this.dgvHang);
            this.pnlHangHoiVien.Controls.Add(this.lblDanhSachHang);
            this.pnlHangHoiVien.Location = new System.Drawing.Point(28, 325);
            this.pnlHangHoiVien.Name = "pnlHangHoiVien";
            this.pnlHangHoiVien.Size = new System.Drawing.Size(520, 455);
            this.pnlHangHoiVien.TabIndex = 1;
            // 
            // dgvHang
            // 
            this.dgvHang.AllowUserToAddRows = false;
            this.dgvHang.AllowUserToDeleteRows = false;
            this.dgvHang.AllowUserToResizeRows = false;
            this.dgvHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvHang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHang.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHang.ColumnHeadersHeight = 38;
            this.dgvHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHang,
            this.colMocDiem,
            this.colUuDai,
            this.colTrangThai});
            this.dgvHang.EnableHeadersVisualStyles = false;
            this.dgvHang.Location = new System.Drawing.Point(18, 55);
            this.dgvHang.MultiSelect = false;
            this.dgvHang.Name = "dgvHang";
            this.dgvHang.ReadOnly = true;
            this.dgvHang.RowHeadersVisible = false;
            this.dgvHang.RowHeadersWidth = 51;
            this.dgvHang.RowTemplate.Height = 48;
            this.dgvHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHang.Size = new System.Drawing.Size(482, 375);
            this.dgvHang.TabIndex = 0;
            // 
            // colHang
            // 
            this.colHang.HeaderText = "Hạng";
            this.colHang.MinimumWidth = 6;
            this.colHang.Name = "colHang";
            this.colHang.ReadOnly = true;
            this.colHang.Width = 105;
            // 
            // colMocDiem
            // 
            this.colMocDiem.HeaderText = "Mốc điểm";
            this.colMocDiem.MinimumWidth = 6;
            this.colMocDiem.Name = "colMocDiem";
            this.colMocDiem.ReadOnly = true;
            this.colMocDiem.Width = 105;
            // 
            // colUuDai
            // 
            this.colUuDai.HeaderText = "Ưu đãi";
            this.colUuDai.MinimumWidth = 6;
            this.colUuDai.Name = "colUuDai";
            this.colUuDai.ReadOnly = true;
            this.colUuDai.Width = 75;
            // 
            // colTrangThai
            // 
            this.colTrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.MinimumWidth = 6;
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // lblDanhSachHang
            // 
            this.lblDanhSachHang.AutoSize = true;
            this.lblDanhSachHang.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblDanhSachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.lblDanhSachHang.Location = new System.Drawing.Point(20, 15);
            this.lblDanhSachHang.Name = "lblDanhSachHang";
            this.lblDanhSachHang.Size = new System.Drawing.Size(260, 30);
            this.lblDanhSachHang.TabIndex = 1;
            this.lblDanhSachHang.Text = "🏆 Các hạng thành viên";
            // 
            // pnlLichSu
            // 
            this.pnlLichSu.BackColor = System.Drawing.Color.White;
            this.pnlLichSu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLichSu.Controls.Add(this.dgvLichSu);
            this.pnlLichSu.Controls.Add(this.lblLichSuTitle);
            this.pnlLichSu.Location = new System.Drawing.Point(568, 325);
            this.pnlLichSu.Name = "pnlLichSu";
            this.pnlLichSu.Size = new System.Drawing.Size(524, 455);
            this.pnlLichSu.TabIndex = 0;
            // 
            // dgvLichSu
            // 
            this.dgvLichSu.AllowUserToAddRows = false;
            this.dgvLichSu.AllowUserToDeleteRows = false;
            this.dgvLichSu.AllowUserToResizeRows = false;
            this.dgvLichSu.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLichSu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLichSu.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichSu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLichSu.ColumnHeadersHeight = 38;
            this.dgvLichSu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNgay,
            this.colDiemLS,
            this.colLyDo,
            this.colMaHD});
            this.dgvLichSu.EnableHeadersVisualStyles = false;
            this.dgvLichSu.Location = new System.Drawing.Point(18, 55);
            this.dgvLichSu.MultiSelect = false;
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.ReadOnly = true;
            this.dgvLichSu.RowHeadersVisible = false;
            this.dgvLichSu.RowHeadersWidth = 51;
            this.dgvLichSu.RowTemplate.Height = 45;
            this.dgvLichSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSu.Size = new System.Drawing.Size(486, 375);
            this.dgvLichSu.TabIndex = 0;
            // 
            // colNgay
            // 
            this.colNgay.HeaderText = "Thời gian";
            this.colNgay.MinimumWidth = 6;
            this.colNgay.Name = "colNgay";
            this.colNgay.ReadOnly = true;
            this.colNgay.Width = 125;
            // 
            // colDiemLS
            // 
            this.colDiemLS.HeaderText = "Điểm";
            this.colDiemLS.MinimumWidth = 6;
            this.colDiemLS.Name = "colDiemLS";
            this.colDiemLS.ReadOnly = true;
            this.colDiemLS.Width = 75;
            // 
            // colLyDo
            // 
            this.colLyDo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLyDo.HeaderText = "Lý do";
            this.colLyDo.MinimumWidth = 6;
            this.colLyDo.Name = "colLyDo";
            this.colLyDo.ReadOnly = true;
            // 
            // colMaHD
            // 
            this.colMaHD.HeaderText = "Hóa đơn";
            this.colMaHD.MinimumWidth = 6;
            this.colMaHD.Name = "colMaHD";
            this.colMaHD.ReadOnly = true;
            this.colMaHD.Width = 80;
            // 
            // lblLichSuTitle
            // 
            this.lblLichSuTitle.AutoSize = true;
            this.lblLichSuTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblLichSuTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.lblLichSuTitle.Location = new System.Drawing.Point(20, 15);
            this.lblLichSuTitle.Name = "lblLichSuTitle";
            this.lblLichSuTitle.Size = new System.Drawing.Size(225, 30);
            this.lblLichSuTitle.TabIndex = 1;
            this.lblLichSuTitle.Text = "📈 Lịch sử tích điểm";
            // 
            // FormHoiVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1120, 820);
            this.Controls.Add(this.pnlLichSu);
            this.Controls.Add(this.pnlHangHoiVien);
            this.Controls.Add(this.pnlTienDo);
            this.Controls.Add(this.pnlHang);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1000, 720);
            this.Name = "FormHoiVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORTSHOP - Hội viên";
            this.Load += new System.EventHandler(this.FormHoiVien_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlHang.ResumeLayout(false);
            this.pnlHang.PerformLayout();
            this.pnlTienDo.ResumeLayout(false);
            this.pnlTienDo.PerformLayout();
            this.pnlHangHoiVien.ResumeLayout(false);
            this.pnlHangHoiVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHang)).EndInit();
            this.pnlLichSu.ResumeLayout(false);
            this.pnlLichSu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.ResumeLayout(false);

        }
    }
}

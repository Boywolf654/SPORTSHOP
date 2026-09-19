namespace SPORTSHOP._07_KhachHang
{
    partial class FormHoiVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlNen = new Guna.UI2.WinForms.Guna2Panel();

            // Header
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lbTieuDe = new System.Windows.Forms.Label();
            this.lbMoTa = new System.Windows.Forms.Label();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboHang = new Guna.UI2.WinForms.Guna2ComboBox();

            // Thẻ thống kê
            this.pnlTongHoiVien = new Guna.UI2.WinForms.Guna2Panel();
            this.lbTongHoiVienCaption = new System.Windows.Forms.Label();
            this.lbTongHoiVien = new System.Windows.Forms.Label();

            this.pnlDangHoatDong = new Guna.UI2.WinForms.Guna2Panel();
            this.lbDangHoatDongCaption = new System.Windows.Forms.Label();
            this.lbDangHoatDong = new System.Windows.Forms.Label();

            this.pnlTongDiem = new Guna.UI2.WinForms.Guna2Panel();
            this.lbTongDiemCaption = new System.Windows.Forms.Label();
            this.lbTongDiem = new System.Windows.Forms.Label();

            this.pnlHangCao = new Guna.UI2.WinForms.Guna2Panel();
            this.lbHangCaoCaption = new System.Windows.Forms.Label();
            this.lbHangCao = new System.Windows.Forms.Label();

            // Danh sách
            this.dgvHoiVien = new Guna.UI2.WinForms.Guna2DataGridView();

            // Thanh hành động
            this.pnlHanhDong = new Guna.UI2.WinForms.Guna2Panel();
            this.lbHoiVienDangChon = new System.Windows.Forms.Label();
            this.numDiem = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.btnCongDiem = new Guna.UI2.WinForms.Guna2Button();
            this.btnTinhLaiHang = new Guna.UI2.WinForms.Guna2Button();
            this.btnDoiTrangThai = new Guna.UI2.WinForms.Guna2Button();

            this.pnlNen.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlTongHoiVien.SuspendLayout();
            this.pnlDangHoatDong.SuspendLayout();
            this.pnlTongDiem.SuspendLayout();
            this.pnlHangCao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoiVien)).BeginInit();
            this.pnlHanhDong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiem)).BeginInit();
            this.SuspendLayout();

            // =========================================================
            // pnlNen
            // =========================================================
            this.pnlNen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlNen.Controls.Add(this.pnlHeader);
            this.pnlNen.Controls.Add(this.pnlTongHoiVien);
            this.pnlNen.Controls.Add(this.pnlDangHoatDong);
            this.pnlNen.Controls.Add(this.pnlTongDiem);
            this.pnlNen.Controls.Add(this.pnlHangCao);
            this.pnlNen.Controls.Add(this.dgvHoiVien);
            this.pnlNen.Controls.Add(this.pnlHanhDong);
            this.pnlNen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNen.Location = new System.Drawing.Point(0, 0);
            this.pnlNen.Name = "pnlNen";
            this.pnlNen.Size = new System.Drawing.Size(1100, 686);
            this.pnlNen.TabIndex = 0;

            // =========================================================
            // pnlHeader
            // =========================================================
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.pnlHeader.BorderRadius = 12;
            this.pnlHeader.BorderThickness = 1;
            this.pnlHeader.Controls.Add(this.lbTieuDe);
            this.pnlHeader.Controls.Add(this.lbMoTa);
            this.pnlHeader.Controls.Add(this.txtTimKiem);
            this.pnlHeader.Controls.Add(this.cboHang);
            this.pnlHeader.FillColor = System.Drawing.Color.White;
            this.pnlHeader.Location = new System.Drawing.Point(24, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.ShadowDecoration.BorderRadius = 12;
            this.pnlHeader.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.pnlHeader.ShadowDecoration.Depth = 6;
            this.pnlHeader.ShadowDecoration.Enabled = true;
            this.pnlHeader.Size = new System.Drawing.Size(1052, 92);
            this.pnlHeader.TabIndex = 0;

            this.lbTieuDe.AutoSize = true;
            this.lbTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lbTieuDe.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lbTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            this.lbTieuDe.Location = new System.Drawing.Point(24, 18);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Size = new System.Drawing.Size(196, 28);
            this.lbTieuDe.TabIndex = 0;
            this.lbTieuDe.Text = "Quản lý hội viên";

            this.lbMoTa.AutoSize = true;
            this.lbMoTa.BackColor = System.Drawing.Color.Transparent;
            this.lbMoTa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lbMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(115)))), ((int)(((byte)(125)))));
            this.lbMoTa.Location = new System.Drawing.Point(26, 52);
            this.lbMoTa.Name = "lbMoTa";
            this.lbMoTa.Size = new System.Drawing.Size(360, 17);
            this.lbMoTa.TabIndex = 1;
            this.lbMoTa.Text = "Danh sách khách hàng thành viên, điểm tích lũy và hạng thành viên.";

            // txtTimKiem
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.txtTimKiem.BorderRadius = 8;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.txtTimKiem.Location = new System.Drawing.Point(572, 27);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Tìm theo tên, số điện thoại, email...";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(280, 38);
            this.txtTimKiem.TabIndex = 2;

            // cboHang
            this.cboHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboHang.BackColor = System.Drawing.Color.Transparent;
            this.cboHang.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.cboHang.BorderRadius = 8;
            this.cboHang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.cboHang.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.cboHang.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            this.cboHang.ItemHeight = 32;
            this.cboHang.Items.AddRange(new object[] {
            "Tất cả hạng",
            "Kim cương",
            "Vàng",
            "Bạc",
            "Đồng",
            "Thường"});
            this.cboHang.Location = new System.Drawing.Point(868, 27);
            this.cboHang.Name = "cboHang";
            this.cboHang.Size = new System.Drawing.Size(160, 38);
            this.cboHang.TabIndex = 3;

            // =========================================================
            // THẺ THỐNG KÊ
            // =========================================================

            // Tổng hội viên
            this.pnlTongHoiVien.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.pnlTongHoiVien.BorderRadius = 12;
            this.pnlTongHoiVien.BorderThickness = 1;
            this.pnlTongHoiVien.Controls.Add(this.lbTongHoiVienCaption);
            this.pnlTongHoiVien.Controls.Add(this.lbTongHoiVien);
            this.pnlTongHoiVien.FillColor = System.Drawing.Color.White;
            this.pnlTongHoiVien.Location = new System.Drawing.Point(24, 132);
            this.pnlTongHoiVien.Name = "pnlTongHoiVien";
            this.pnlTongHoiVien.Size = new System.Drawing.Size(254, 100);
            this.pnlTongHoiVien.TabIndex = 1;

            this.lbTongHoiVienCaption.AutoSize = true;
            this.lbTongHoiVienCaption.BackColor = System.Drawing.Color.Transparent;
            this.lbTongHoiVienCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbTongHoiVienCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(115)))), ((int)(((byte)(125)))));
            this.lbTongHoiVienCaption.Location = new System.Drawing.Point(22, 20);
            this.lbTongHoiVienCaption.Name = "lbTongHoiVienCaption";
            this.lbTongHoiVienCaption.Size = new System.Drawing.Size(88, 15);
            this.lbTongHoiVienCaption.TabIndex = 0;
            this.lbTongHoiVienCaption.Text = "Tổng hội viên";

            this.lbTongHoiVien.AutoSize = false;
            this.lbTongHoiVien.BackColor = System.Drawing.Color.Transparent;
            this.lbTongHoiVien.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lbTongHoiVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            this.lbTongHoiVien.Location = new System.Drawing.Point(22, 42);
            this.lbTongHoiVien.Name = "lbTongHoiVien";
            this.lbTongHoiVien.Size = new System.Drawing.Size(210, 42);
            this.lbTongHoiVien.TabIndex = 1;
            this.lbTongHoiVien.Text = "0";

            // Đang hoạt động
            this.pnlDangHoatDong.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.pnlDangHoatDong.BorderRadius = 12;
            this.pnlDangHoatDong.BorderThickness = 1;
            this.pnlDangHoatDong.Controls.Add(this.lbDangHoatDongCaption);
            this.pnlDangHoatDong.Controls.Add(this.lbDangHoatDong);
            this.pnlDangHoatDong.FillColor = System.Drawing.Color.White;
            this.pnlDangHoatDong.Location = new System.Drawing.Point(290, 132);
            this.pnlDangHoatDong.Name = "pnlDangHoatDong";
            this.pnlDangHoatDong.Size = new System.Drawing.Size(254, 100);
            this.pnlDangHoatDong.TabIndex = 2;

            this.lbDangHoatDongCaption.AutoSize = true;
            this.lbDangHoatDongCaption.BackColor = System.Drawing.Color.Transparent;
            this.lbDangHoatDongCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbDangHoatDongCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(115)))), ((int)(((byte)(125)))));
            this.lbDangHoatDongCaption.Location = new System.Drawing.Point(22, 20);
            this.lbDangHoatDongCaption.Name = "lbDangHoatDongCaption";
            this.lbDangHoatDongCaption.Size = new System.Drawing.Size(100, 15);
            this.lbDangHoatDongCaption.TabIndex = 0;
            this.lbDangHoatDongCaption.Text = "Đang hoạt động";

            this.lbDangHoatDong.AutoSize = false;
            this.lbDangHoatDong.BackColor = System.Drawing.Color.Transparent;
            this.lbDangHoatDong.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lbDangHoatDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lbDangHoatDong.Location = new System.Drawing.Point(22, 42);
            this.lbDangHoatDong.Name = "lbDangHoatDong";
            this.lbDangHoatDong.Size = new System.Drawing.Size(210, 42);
            this.lbDangHoatDong.TabIndex = 1;
            this.lbDangHoatDong.Text = "0";

            // Tổng điểm tích lũy
            this.pnlTongDiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.pnlTongDiem.BorderRadius = 12;
            this.pnlTongDiem.BorderThickness = 1;
            this.pnlTongDiem.Controls.Add(this.lbTongDiemCaption);
            this.pnlTongDiem.Controls.Add(this.lbTongDiem);
            this.pnlTongDiem.FillColor = System.Drawing.Color.White;
            this.pnlTongDiem.Location = new System.Drawing.Point(556, 132);
            this.pnlTongDiem.Name = "pnlTongDiem";
            this.pnlTongDiem.Size = new System.Drawing.Size(254, 100);
            this.pnlTongDiem.TabIndex = 3;

            this.lbTongDiemCaption.AutoSize = true;
            this.lbTongDiemCaption.BackColor = System.Drawing.Color.Transparent;
            this.lbTongDiemCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbTongDiemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(115)))), ((int)(((byte)(125)))));
            this.lbTongDiemCaption.Location = new System.Drawing.Point(22, 20);
            this.lbTongDiemCaption.Name = "lbTongDiemCaption";
            this.lbTongDiemCaption.Size = new System.Drawing.Size(124, 15);
            this.lbTongDiemCaption.TabIndex = 0;
            this.lbTongDiemCaption.Text = "Tổng điểm tích lũy";

            this.lbTongDiem.AutoSize = false;
            this.lbTongDiem.BackColor = System.Drawing.Color.Transparent;
            this.lbTongDiem.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lbTongDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.lbTongDiem.Location = new System.Drawing.Point(22, 42);
            this.lbTongDiem.Name = "lbTongDiem";
            this.lbTongDiem.Size = new System.Drawing.Size(210, 42);
            this.lbTongDiem.TabIndex = 1;
            this.lbTongDiem.Text = "0";

            // Hạng Vàng trở lên
            this.pnlHangCao.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.pnlHangCao.BorderRadius = 12;
            this.pnlHangCao.BorderThickness = 1;
            this.pnlHangCao.Controls.Add(this.lbHangCaoCaption);
            this.pnlHangCao.Controls.Add(this.lbHangCao);
            this.pnlHangCao.FillColor = System.Drawing.Color.White;
            this.pnlHangCao.Location = new System.Drawing.Point(822, 132);
            this.pnlHangCao.Name = "pnlHangCao";
            this.pnlHangCao.Size = new System.Drawing.Size(254, 100);
            this.pnlHangCao.TabIndex = 4;

            this.lbHangCaoCaption.AutoSize = true;
            this.lbHangCaoCaption.BackColor = System.Drawing.Color.Transparent;
            this.lbHangCaoCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbHangCaoCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(115)))), ((int)(((byte)(125)))));
            this.lbHangCaoCaption.Location = new System.Drawing.Point(22, 20);
            this.lbHangCaoCaption.Name = "lbHangCaoCaption";
            this.lbHangCaoCaption.Size = new System.Drawing.Size(126, 15);
            this.lbHangCaoCaption.TabIndex = 0;
            this.lbHangCaoCaption.Text = "Hạng Vàng trở lên";

            this.lbHangCao.AutoSize = false;
            this.lbHangCao.BackColor = System.Drawing.Color.Transparent;
            this.lbHangCao.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lbHangCao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lbHangCao.Location = new System.Drawing.Point(22, 42);
            this.lbHangCao.Name = "lbHangCao";
            this.lbHangCao.Size = new System.Drawing.Size(210, 42);
            this.lbHangCao.TabIndex = 1;
            this.lbHangCao.Text = "0";

            // =========================================================
            // dgvHoiVien
            // =========================================================
            this.dgvHoiVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoiVien.AllowUserToAddRows = false;
            this.dgvHoiVien.AllowUserToDeleteRows = false;
            this.dgvHoiVien.AllowUserToResizeRows = false;
            this.dgvHoiVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoiVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHoiVien.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHoiVien.ColumnHeadersHeight = 44;
            this.dgvHoiVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHoiVien.EnableHeadersVisualStyles = false;
            this.dgvHoiVien.Location = new System.Drawing.Point(24, 248);
            this.dgvHoiVien.MultiSelect = false;
            this.dgvHoiVien.Name = "dgvHoiVien";
            this.dgvHoiVien.ReadOnly = true;
            this.dgvHoiVien.RowHeadersVisible = false;
            this.dgvHoiVien.RowTemplate.Height = 42;
            this.dgvHoiVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoiVien.Size = new System.Drawing.Size(1052, 330);
            this.dgvHoiVien.TabIndex = 5;
            this.dgvHoiVien.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.dgvHoiVien.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHoiVien.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvHoiVien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHoiVien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHoiVien.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoiVien.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.dgvHoiVien.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.dgvHoiVien.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHoiVien.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.dgvHoiVien.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(96)))), ((int)(((byte)(108)))));
            this.dgvHoiVien.ThemeStyle.HeaderStyle.Height = 44;
            this.dgvHoiVien.ThemeStyle.ReadOnly = true;
            this.dgvHoiVien.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoiVien.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHoiVien.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dgvHoiVien.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.dgvHoiVien.ThemeStyle.RowsStyle.Height = 42;
            this.dgvHoiVien.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgvHoiVien.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));

            // =========================================================
            // pnlHanhDong
            // =========================================================
            this.pnlHanhDong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHanhDong.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.pnlHanhDong.BorderRadius = 12;
            this.pnlHanhDong.BorderThickness = 1;
            this.pnlHanhDong.Controls.Add(this.lbHoiVienDangChon);
            this.pnlHanhDong.Controls.Add(this.numDiem);
            this.pnlHanhDong.Controls.Add(this.btnCongDiem);
            this.pnlHanhDong.Controls.Add(this.btnTinhLaiHang);
            this.pnlHanhDong.Controls.Add(this.btnDoiTrangThai);
            this.pnlHanhDong.FillColor = System.Drawing.Color.White;
            this.pnlHanhDong.Location = new System.Drawing.Point(24, 590);
            this.pnlHanhDong.Name = "pnlHanhDong";
            this.pnlHanhDong.Size = new System.Drawing.Size(1052, 72);
            this.pnlHanhDong.TabIndex = 6;

            this.lbHoiVienDangChon.AutoSize = false;
            this.lbHoiVienDangChon.BackColor = System.Drawing.Color.Transparent;
            this.lbHoiVienDangChon.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lbHoiVienDangChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(115)))), ((int)(((byte)(125)))));
            this.lbHoiVienDangChon.Location = new System.Drawing.Point(24, 0);
            this.lbHoiVienDangChon.Name = "lbHoiVienDangChon";
            this.lbHoiVienDangChon.Size = new System.Drawing.Size(360, 72);
            this.lbHoiVienDangChon.TabIndex = 0;
            this.lbHoiVienDangChon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbHoiVienDangChon.Text = "Chưa chọn hội viên nào.";

            this.numDiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numDiem.BackColor = System.Drawing.Color.Transparent;
            this.numDiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.numDiem.BorderRadius = 8;
            this.numDiem.BorderThickness = 1;
            this.numDiem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.numDiem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.numDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            this.numDiem.Location = new System.Drawing.Point(400, 17);
            this.numDiem.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numDiem.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numDiem.Name = "numDiem";
            this.numDiem.Size = new System.Drawing.Size(110, 38);
            this.numDiem.TabIndex = 1;
            this.numDiem.Value = new decimal(new int[] { 100, 0, 0, 0 });

            this.btnCongDiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCongDiem.BorderRadius = 8;
            this.btnCongDiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCongDiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCongDiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            this.btnCongDiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(175)))));
            this.btnCongDiem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnCongDiem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.btnCongDiem.ForeColor = System.Drawing.Color.White;
            this.btnCongDiem.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(102)))), ((int)(((byte)(220)))));
            this.btnCongDiem.Location = new System.Drawing.Point(524, 17);
            this.btnCongDiem.Name = "btnCongDiem";
            this.btnCongDiem.Size = new System.Drawing.Size(140, 38);
            this.btnCongDiem.TabIndex = 2;
            this.btnCongDiem.Text = "Cộng điểm";

            this.btnTinhLaiHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTinhLaiHang.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.btnTinhLaiHang.BorderRadius = 8;
            this.btnTinhLaiHang.BorderThickness = 1;
            this.btnTinhLaiHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTinhLaiHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTinhLaiHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            this.btnTinhLaiHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(175)))));
            this.btnTinhLaiHang.FillColor = System.Drawing.Color.White;
            this.btnTinhLaiHang.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.btnTinhLaiHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            this.btnTinhLaiHang.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.btnTinhLaiHang.Location = new System.Drawing.Point(676, 17);
            this.btnTinhLaiHang.Name = "btnTinhLaiHang";
            this.btnTinhLaiHang.Size = new System.Drawing.Size(150, 38);
            this.btnTinhLaiHang.TabIndex = 3;
            this.btnTinhLaiHang.Text = "Tính lại hạng";

            this.btnDoiTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoiTrangThai.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnDoiTrangThai.BorderRadius = 8;
            this.btnDoiTrangThai.BorderThickness = 1;
            this.btnDoiTrangThai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDoiTrangThai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDoiTrangThai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            this.btnDoiTrangThai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(175)))));
            this.btnDoiTrangThai.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnDoiTrangThai.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.btnDoiTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnDoiTrangThai.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnDoiTrangThai.Location = new System.Drawing.Point(838, 17);
            this.btnDoiTrangThai.Name = "btnDoiTrangThai";
            this.btnDoiTrangThai.Size = new System.Drawing.Size(190, 38);
            this.btnDoiTrangThai.TabIndex = 4;
            this.btnDoiTrangThai.Text = "Đổi trạng thái";

            // =========================================================
            // FormHoiVien
            // =========================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1100, 686);
            this.Controls.Add(this.pnlNen);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1040, 640);
            this.Name = "FormHoiVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORTSHOP - Quản lý hội viên";
            this.Load += new System.EventHandler(this.FormHoiVien_Load);

            this.pnlNen.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTongHoiVien.ResumeLayout(false);
            this.pnlTongHoiVien.PerformLayout();
            this.pnlDangHoatDong.ResumeLayout(false);
            this.pnlDangHoatDong.PerformLayout();
            this.pnlTongDiem.ResumeLayout(false);
            this.pnlTongDiem.PerformLayout();
            this.pnlHangCao.ResumeLayout(false);
            this.pnlHangCao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoiVien)).EndInit();
            this.pnlHanhDong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDiem)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlNen;

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lbTieuDe;
        private System.Windows.Forms.Label lbMoTa;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2ComboBox cboHang;

        private Guna.UI2.WinForms.Guna2Panel pnlTongHoiVien;
        private System.Windows.Forms.Label lbTongHoiVienCaption;
        private System.Windows.Forms.Label lbTongHoiVien;

        private Guna.UI2.WinForms.Guna2Panel pnlDangHoatDong;
        private System.Windows.Forms.Label lbDangHoatDongCaption;
        private System.Windows.Forms.Label lbDangHoatDong;

        private Guna.UI2.WinForms.Guna2Panel pnlTongDiem;
        private System.Windows.Forms.Label lbTongDiemCaption;
        private System.Windows.Forms.Label lbTongDiem;

        private Guna.UI2.WinForms.Guna2Panel pnlHangCao;
        private System.Windows.Forms.Label lbHangCaoCaption;
        private System.Windows.Forms.Label lbHangCao;

        private Guna.UI2.WinForms.Guna2DataGridView dgvHoiVien;

        private Guna.UI2.WinForms.Guna2Panel pnlHanhDong;
        private System.Windows.Forms.Label lbHoiVienDangChon;
        private Guna.UI2.WinForms.Guna2NumericUpDown numDiem;
        private Guna.UI2.WinForms.Guna2Button btnCongDiem;
        private Guna.UI2.WinForms.Guna2Button btnTinhLaiHang;
        private Guna.UI2.WinForms.Guna2Button btnDoiTrangThai;
    }
}
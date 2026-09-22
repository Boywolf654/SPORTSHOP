namespace SPORTSHOP
{
    partial class FormQuanLyChamCong
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTieuDe;
        private Guna.UI2.WinForms.Guna2Panel pnlLoc;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNgay;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgay;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNV;
        private Guna.UI2.WinForms.Guna2ComboBox cmbNhanVien;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTrangThai;
        private Guna.UI2.WinForms.Guna2Button btnTim;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChamCong;
        private Guna.UI2.WinForms.Guna2Panel pnlThongKe;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTong;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblChua;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDang;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblXong;
        private Guna.UI2.WinForms.Guna2Panel pnlSua;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNhanVien;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGioVao;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpGioVao;
        private Guna.UI2.WinForms.Guna2CheckBox chkCoGioVao;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGioRa;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpGioRa;
        private Guna.UI2.WinForms.Guna2CheckBox chkCoGioRa;
        private Guna.UI2.WinForms.Guna2Button btnLuu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTieuDe = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlLoc = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNgay = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblNV = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbNhanVien = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnTim = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.dgvChamCong = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlThongKe = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblChua = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDang = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblXong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlSua = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNhanVien = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblGioVao = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpGioVao = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.chkCoGioVao = new Guna.UI2.WinForms.Guna2CheckBox();
            this.lblGioRa = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpGioRa = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.chkCoGioRa = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).BeginInit();
            this.pnlThongKe.SuspendLayout();
            this.pnlSua.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(32, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(375, 43);
            this.lblTieuDe.TabIndex = 4;
            this.lblTieuDe.Text = "👥 QUẢN LÝ CHẤM CÔNG";
            // 
            // pnlLoc
            // 
            this.pnlLoc.BorderRadius = 12;
            this.pnlLoc.Controls.Add(this.lblNgay);
            this.pnlLoc.Controls.Add(this.dtpNgay);
            this.pnlLoc.Controls.Add(this.lblNV);
            this.pnlLoc.Controls.Add(this.cmbNhanVien);
            this.pnlLoc.Controls.Add(this.cmbTrangThai);
            this.pnlLoc.Controls.Add(this.btnTim);
            this.pnlLoc.Controls.Add(this.btnLamMoi);
            this.pnlLoc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(42)))));
            this.pnlLoc.Location = new System.Drawing.Point(28, 72);
            this.pnlLoc.Name = "pnlLoc";
            this.pnlLoc.Size = new System.Drawing.Size(1138, 86);
            this.pnlLoc.TabIndex = 3;
            // 
            // lblNgay
            // 
            this.lblNgay.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNgay.ForeColor = System.Drawing.Color.White;
            this.lblNgay.Location = new System.Drawing.Point(18, 31);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(45, 25);
            this.lblNgay.TabIndex = 0;
            this.lblNgay.Text = "Ngày";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Checked = true;
            this.dtpNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpNgay.FillColor = System.Drawing.Color.White;
            this.dtpNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(65, 22);
            this.dtpNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(150, 42);
            this.dtpNgay.TabIndex = 1;
            this.dtpNgay.Value = new System.DateTime(2026, 9, 20, 0, 10, 26, 579);
            // 
            // lblNV
            // 
            this.lblNV.BackColor = System.Drawing.Color.Transparent;
            this.lblNV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNV.ForeColor = System.Drawing.Color.White;
            this.lblNV.Location = new System.Drawing.Point(235, 31);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(83, 25);
            this.lblNV.TabIndex = 2;
            this.lblNV.Text = "Nhân viên";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.cmbNhanVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhanVien.FocusedColor = System.Drawing.Color.Empty;
            this.cmbNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbNhanVien.ItemHeight = 30;
            this.cmbNhanVien.Location = new System.Drawing.Point(322, 22);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(270, 36);
            this.cmbNhanVien.TabIndex = 3;
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.cmbTrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangThai.FocusedColor = System.Drawing.Color.Empty;
            this.cmbTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbTrangThai.ItemHeight = 30;
            this.cmbTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Chưa vào ca",
            "Đang làm",
            "Đã hoàn thành"});
            this.cmbTrangThai.Location = new System.Drawing.Point(610, 22);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(180, 36);
            this.cmbTrangThai.TabIndex = 4;
            // 
            // btnTim
            // 
            this.btnTim.BorderRadius = 8;
            this.btnTim.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(220)))));
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Location = new System.Drawing.Point(810, 22);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(125, 42);
            this.btnTim.TabIndex = 5;
            this.btnTim.Text = "🔍 XEM";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BorderRadius = 8;
            this.btnLamMoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(95)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(950, 22);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(150, 42);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "🔄 LÀM MỚI";
            // 
            // dgvChamCong
            // 
            this.dgvChamCong.AllowUserToAddRows = false;
            this.dgvChamCong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChamCong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChamCong.ColumnHeadersHeight = 38;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChamCong.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChamCong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChamCong.Location = new System.Drawing.Point(28, 248);
            this.dgvChamCong.MultiSelect = false;
            this.dgvChamCong.Name = "dgvChamCong";
            this.dgvChamCong.ReadOnly = true;
            this.dgvChamCong.RowHeadersVisible = false;
            this.dgvChamCong.RowHeadersWidth = 51;
            this.dgvChamCong.RowTemplate.Height = 34;
            this.dgvChamCong.Size = new System.Drawing.Size(1138, 300);
            this.dgvChamCong.TabIndex = 1;
            this.dgvChamCong.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvChamCong.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvChamCong.ThemeStyle.HeaderStyle.Height = 38;
            this.dgvChamCong.ThemeStyle.ReadOnly = true;
            this.dgvChamCong.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvChamCong.ThemeStyle.RowsStyle.Height = 34;
            // 
            // pnlThongKe
            // 
            this.pnlThongKe.BorderRadius = 12;
            this.pnlThongKe.Controls.Add(this.lblTong);
            this.pnlThongKe.Controls.Add(this.lblChua);
            this.pnlThongKe.Controls.Add(this.lblDang);
            this.pnlThongKe.Controls.Add(this.lblXong);
            this.pnlThongKe.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(42)))));
            this.pnlThongKe.Location = new System.Drawing.Point(28, 170);
            this.pnlThongKe.Name = "pnlThongKe";
            this.pnlThongKe.Size = new System.Drawing.Size(1138, 64);
            this.pnlThongKe.TabIndex = 2;
            // 
            // lblTong
            // 
            this.lblTong.BackColor = System.Drawing.Color.Transparent;
            this.lblTong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTong.ForeColor = System.Drawing.Color.White;
            this.lblTong.Location = new System.Drawing.Point(25, 20);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(67, 27);
            this.lblTong.TabIndex = 0;
            this.lblTong.Text = "Tổng: 0";
            // 
            // lblChua
            // 
            this.lblChua.BackColor = System.Drawing.Color.Transparent;
            this.lblChua.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChua.ForeColor = System.Drawing.Color.Orange;
            this.lblChua.Location = new System.Drawing.Point(245, 20);
            this.lblChua.Name = "lblChua";
            this.lblChua.Size = new System.Drawing.Size(127, 27);
            this.lblChua.TabIndex = 1;
            this.lblChua.Text = "Chưa vào ca: 0";
            // 
            // lblDang
            // 
            this.lblDang.BackColor = System.Drawing.Color.Transparent;
            this.lblDang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDang.ForeColor = System.Drawing.Color.Gold;
            this.lblDang.Location = new System.Drawing.Point(500, 20);
            this.lblDang.Name = "lblDang";
            this.lblDang.Size = new System.Drawing.Size(104, 27);
            this.lblDang.TabIndex = 2;
            this.lblDang.Text = "Đang làm: 0";
            // 
            // lblXong
            // 
            this.lblXong.BackColor = System.Drawing.Color.Transparent;
            this.lblXong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblXong.ForeColor = System.Drawing.Color.LightGreen;
            this.lblXong.Location = new System.Drawing.Point(735, 20);
            this.lblXong.Name = "lblXong";
            this.lblXong.Size = new System.Drawing.Size(149, 27);
            this.lblXong.TabIndex = 3;
            this.lblXong.Text = "Đã hoàn thành: 0";
            // 
            // pnlSua
            // 
            this.pnlSua.BorderRadius = 12;
            this.pnlSua.Controls.Add(this.lblNhanVien);
            this.pnlSua.Controls.Add(this.lblGioVao);
            this.pnlSua.Controls.Add(this.dtpGioVao);
            this.pnlSua.Controls.Add(this.chkCoGioVao);
            this.pnlSua.Controls.Add(this.lblGioRa);
            this.pnlSua.Controls.Add(this.dtpGioRa);
            this.pnlSua.Controls.Add(this.chkCoGioRa);
            this.pnlSua.Controls.Add(this.btnLuu);
            this.pnlSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(42)))));
            this.pnlSua.Location = new System.Drawing.Point(28, 565);
            this.pnlSua.Name = "pnlSua";
            this.pnlSua.Size = new System.Drawing.Size(1138, 145);
            this.pnlSua.TabIndex = 0;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNhanVien.ForeColor = System.Drawing.Color.White;
            this.lblNhanVien.Location = new System.Drawing.Point(20, 16);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(183, 27);
            this.lblNhanVien.TabIndex = 0;
            this.lblNhanVien.Text = "Chưa chọn nhân viên";
            // 
            // lblGioVao
            // 
            this.lblGioVao.BackColor = System.Drawing.Color.Transparent;
            this.lblGioVao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGioVao.ForeColor = System.Drawing.Color.White;
            this.lblGioVao.Location = new System.Drawing.Point(20, 70);
            this.lblGioVao.Name = "lblGioVao";
            this.lblGioVao.Size = new System.Drawing.Size(64, 25);
            this.lblGioVao.TabIndex = 1;
            this.lblGioVao.Text = "Giờ vào";
            // 
            // dtpGioVao
            // 
            this.dtpGioVao.Checked = true;
            this.dtpGioVao.CustomFormat = "HH:mm:ss";
            this.dtpGioVao.FillColor = System.Drawing.Color.Green;
            this.dtpGioVao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpGioVao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGioVao.Location = new System.Drawing.Point(100, 62);
            this.dtpGioVao.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpGioVao.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpGioVao.Name = "dtpGioVao";
            this.dtpGioVao.ShowUpDown = true;
            this.dtpGioVao.Size = new System.Drawing.Size(125, 36);
            this.dtpGioVao.TabIndex = 2;
            this.dtpGioVao.Value = new System.DateTime(2026, 9, 20, 0, 10, 26, 793);
            // 
            // chkCoGioVao
            // 
            this.chkCoGioVao.CheckedState.BorderRadius = 0;
            this.chkCoGioVao.CheckedState.BorderThickness = 0;
            this.chkCoGioVao.ForeColor = System.Drawing.Color.White;
            this.chkCoGioVao.Location = new System.Drawing.Point(235, 68);
            this.chkCoGioVao.Name = "chkCoGioVao";
            this.chkCoGioVao.Size = new System.Drawing.Size(110, 25);
            this.chkCoGioVao.TabIndex = 3;
            this.chkCoGioVao.Text = "Có giờ vào";
            this.chkCoGioVao.UncheckedState.BorderRadius = 0;
            this.chkCoGioVao.UncheckedState.BorderThickness = 0;
            // 
            // lblGioRa
            // 
            this.lblGioRa.BackColor = System.Drawing.Color.Transparent;
            this.lblGioRa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGioRa.ForeColor = System.Drawing.Color.White;
            this.lblGioRa.Location = new System.Drawing.Point(370, 70);
            this.lblGioRa.Name = "lblGioRa";
            this.lblGioRa.Size = new System.Drawing.Size(52, 25);
            this.lblGioRa.TabIndex = 4;
            this.lblGioRa.Text = "Giờ ra";
            // 
            // dtpGioRa
            // 
            this.dtpGioRa.Checked = true;
            this.dtpGioRa.CustomFormat = "HH:mm:ss";
            this.dtpGioRa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dtpGioRa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpGioRa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGioRa.Location = new System.Drawing.Point(440, 62);
            this.dtpGioRa.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpGioRa.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpGioRa.Name = "dtpGioRa";
            this.dtpGioRa.ShowUpDown = true;
            this.dtpGioRa.Size = new System.Drawing.Size(125, 36);
            this.dtpGioRa.TabIndex = 5;
            this.dtpGioRa.Value = new System.DateTime(2026, 9, 20, 0, 10, 26, 873);
            // 
            // chkCoGioRa
            // 
            this.chkCoGioRa.CheckedState.BorderRadius = 0;
            this.chkCoGioRa.CheckedState.BorderThickness = 0;
            this.chkCoGioRa.ForeColor = System.Drawing.Color.White;
            this.chkCoGioRa.Location = new System.Drawing.Point(575, 68);
            this.chkCoGioRa.Name = "chkCoGioRa";
            this.chkCoGioRa.Size = new System.Drawing.Size(105, 25);
            this.chkCoGioRa.TabIndex = 6;
            this.chkCoGioRa.Text = "Có giờ ra";
            this.chkCoGioRa.UncheckedState.BorderRadius = 0;
            this.chkCoGioRa.UncheckedState.BorderThickness = 0;
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 8;
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(900, 54);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(205, 52);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "💾 LƯU CHẤM CÔNG";
            // 
            // FormQuanLyChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1200, 735);
            this.Controls.Add(this.pnlSua);
            this.Controls.Add(this.dgvChamCong);
            this.Controls.Add(this.pnlThongKe);
            this.Controls.Add(this.pnlLoc);
            this.Controls.Add(this.lblTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQuanLyChamCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý chấm công";
            this.Load += new System.EventHandler(this.FormQuanLyChamCong_Load);
            this.pnlLoc.ResumeLayout(false);
            this.pnlLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).EndInit();
            this.pnlThongKe.ResumeLayout(false);
            this.pnlThongKe.PerformLayout();
            this.pnlSua.ResumeLayout(false);
            this.pnlSua.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
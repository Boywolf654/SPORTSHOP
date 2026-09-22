namespace SPORTSHOP._06_BanHang
{
    partial class FormThanhToanKH
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
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lbTieuDe = new System.Windows.Forms.Label();
            this.lbMaHoaDon = new System.Windows.Forms.Label();

            this.btnTienMat = new Guna.UI2.WinForms.Guna2Button();
            this.btnChuyenKhoan = new Guna.UI2.WinForms.Guna2Button();
            this.btnThe = new Guna.UI2.WinForms.Guna2Button();

            // ---- Tiền mặt ----
            this.pnlTienMat = new Guna.UI2.WinForms.Guna2Panel();
            this.lbKhachDuaCaption = new System.Windows.Forms.Label();
            this.lbKhachDua = new System.Windows.Forms.Label();
            this.lbMenhGiaCaption = new System.Windows.Forms.Label();
            this.lbBanPhimCaption = new System.Windows.Forms.Label();

            // ---- Chuyển khoản ----
            this.pnlChuyenKhoan = new Guna.UI2.WinForms.Guna2Panel();
            this.lbCKCaption = new System.Windows.Forms.Label();
            this.btnNganHang = new Guna.UI2.WinForms.Guna2Button();
            this.btnMoMo = new Guna.UI2.WinForms.Guna2Button();
            this.btnZaloPay = new Guna.UI2.WinForms.Guna2Button();
            this.lbCKGhiChu = new System.Windows.Forms.Label();

            // ---- Thẻ ----
            this.pnlThe = new Guna.UI2.WinForms.Guna2Panel();
            this.lbTheCaption = new System.Windows.Forms.Label();
            this.btnTheVisa = new Guna.UI2.WinForms.Guna2Button();
            this.btnTheDienTu = new Guna.UI2.WinForms.Guna2Button();
            this.lbTheGhiChu = new System.Windows.Forms.Label();

            // ---- Tóm tắt ----
            this.pnlTomTat = new Guna.UI2.WinForms.Guna2Panel();
            this.lbTongTienCaption = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.lbPTCaption = new System.Windows.Forms.Label();
            this.lbPTValue = new System.Windows.Forms.Label();
            this.lbDuaCaption = new System.Windows.Forms.Label();
            this.lbDuaValue = new System.Windows.Forms.Label();
            this.lbThoiCaption = new System.Windows.Forms.Label();
            this.lbThoiValue = new System.Windows.Forms.Label();
            this.lbCanhBao = new System.Windows.Forms.Label();
            this.btnThanhToan = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();

            this.pnlHeader.SuspendLayout();
            this.pnlTienMat.SuspendLayout();
            this.pnlChuyenKhoan.SuspendLayout();
            this.pnlThe.SuspendLayout();
            this.pnlTomTat.SuspendLayout();
            this.SuspendLayout();

            // =========================================================
            // pnlHeader
            // =========================================================
            this.pnlHeader.BorderRadius = 0;
            this.pnlHeader.Controls.Add(this.lbTieuDe);
            this.pnlHeader.Controls.Add(this.lbMaHoaDon);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1020, 76);
            this.pnlHeader.TabIndex = 0;

            this.lbTieuDe.AutoSize = true;
            this.lbTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lbTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lbTieuDe.ForeColor = System.Drawing.Color.White;
            this.lbTieuDe.Location = new System.Drawing.Point(24, 22);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Size = new System.Drawing.Size(280, 30);
            this.lbTieuDe.TabIndex = 0;
            this.lbTieuDe.Text = "THANH TOÁN ĐƠN HÀNG";

            this.lbMaHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMaHoaDon.AutoSize = false;
            this.lbMaHoaDon.BackColor = System.Drawing.Color.Transparent;
            this.lbMaHoaDon.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lbMaHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(152)))), ((int)(((byte)(158)))));
            this.lbMaHoaDon.Location = new System.Drawing.Point(676, 28);
            this.lbMaHoaDon.Name = "lbMaHoaDon";
            this.lbMaHoaDon.Size = new System.Drawing.Size(320, 24);
            this.lbMaHoaDon.TabIndex = 1;
            this.lbMaHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbMaHoaDon.Text = "Hóa đơn: --";

            // =========================================================
            // NÚT CHỌN PHƯƠNG THỨC
            // =========================================================
            this.btnTienMat.BorderRadius = 10;
            this.btnTienMat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTienMat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTienMat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(64)))));
            this.btnTienMat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(124)))));
            this.btnTienMat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnTienMat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btnTienMat.ForeColor = System.Drawing.Color.White;
            this.btnTienMat.Location = new System.Drawing.Point(24, 92);
            this.btnTienMat.Name = "btnTienMat";
            this.btnTienMat.Size = new System.Drawing.Size(208, 52);
            this.btnTienMat.TabIndex = 1;
            this.btnTienMat.Text = "Tiền mặt";

            this.btnChuyenKhoan.BorderRadius = 10;
            this.btnChuyenKhoan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChuyenKhoan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChuyenKhoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(64)))));
            this.btnChuyenKhoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(124)))));
            this.btnChuyenKhoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(41)))));
            this.btnChuyenKhoan.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btnChuyenKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(192)))), ((int)(((byte)(198)))));
            this.btnChuyenKhoan.Location = new System.Drawing.Point(240, 92);
            this.btnChuyenKhoan.Name = "btnChuyenKhoan";
            this.btnChuyenKhoan.Size = new System.Drawing.Size(208, 52);
            this.btnChuyenKhoan.TabIndex = 2;
            this.btnChuyenKhoan.Text = "Chuyển khoản";

            this.btnThe.BorderRadius = 10;
            this.btnThe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(64)))));
            this.btnThe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(124)))));
            this.btnThe.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(41)))));
            this.btnThe.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btnThe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(192)))), ((int)(((byte)(198)))));
            this.btnThe.Location = new System.Drawing.Point(456, 92);
            this.btnThe.Name = "btnThe";
            this.btnThe.Size = new System.Drawing.Size(208, 52);
            this.btnThe.TabIndex = 3;
            this.btnThe.Text = "Thẻ";

            // =========================================================
            // pnlTienMat
            // =========================================================
            this.pnlTienMat.BorderRadius = 14;
            this.pnlTienMat.Controls.Add(this.lbKhachDuaCaption);
            this.pnlTienMat.Controls.Add(this.lbKhachDua);
            this.pnlTienMat.Controls.Add(this.lbMenhGiaCaption);
            this.pnlTienMat.Controls.Add(this.lbBanPhimCaption);
            this.pnlTienMat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.pnlTienMat.Location = new System.Drawing.Point(24, 160);
            this.pnlTienMat.Name = "pnlTienMat";
            this.pnlTienMat.Size = new System.Drawing.Size(640, 536);
            this.pnlTienMat.TabIndex = 4;

            this.lbKhachDuaCaption.AutoSize = true;
            this.lbKhachDuaCaption.BackColor = System.Drawing.Color.Transparent;
            this.lbKhachDuaCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lbKhachDuaCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(152)))), ((int)(((byte)(158)))));
            this.lbKhachDuaCaption.Location = new System.Drawing.Point(20, 14);
            this.lbKhachDuaCaption.Name = "lbKhachDuaCaption";
            this.lbKhachDuaCaption.Size = new System.Drawing.Size(160, 17);
            this.lbKhachDuaCaption.TabIndex = 0;
            this.lbKhachDuaCaption.Text = "SỐ TIỀN KHÁCH ĐƯA";

            this.lbKhachDua.AutoSize = false;
            this.lbKhachDua.BackColor = System.Drawing.Color.Transparent;
            this.lbKhachDua.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lbKhachDua.ForeColor = System.Drawing.Color.White;
            this.lbKhachDua.Location = new System.Drawing.Point(20, 34);
            this.lbKhachDua.Name = "lbKhachDua";
            this.lbKhachDua.Size = new System.Drawing.Size(600, 50);
            this.lbKhachDua.TabIndex = 1;
            this.lbKhachDua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbKhachDua.Text = "0 đ";

            this.lbMenhGiaCaption.AutoSize = true;
            this.lbMenhGiaCaption.BackColor = System.Drawing.Color.Transparent;
            this.lbMenhGiaCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lbMenhGiaCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(152)))), ((int)(((byte)(158)))));
            this.lbMenhGiaCaption.Location = new System.Drawing.Point(20, 92);
            this.lbMenhGiaCaption.Name = "lbMenhGiaCaption";
            this.lbMenhGiaCaption.Size = new System.Drawing.Size(210, 17);
            this.lbMenhGiaCaption.TabIndex = 2;
            this.lbMenhGiaCaption.Text = "MỆNH GIÁ NHANH (CỘNG DỒN)";

            this.lbBanPhimCaption.AutoSize = true;
            this.lbBanPhimCaption.BackColor = System.Drawing.Color.Transparent;
            this.lbBanPhimCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lbBanPhimCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(152)))), ((int)(((byte)(158)))));
            this.lbBanPhimCaption.Location = new System.Drawing.Point(20, 294);
            this.lbBanPhimCaption.Name = "lbBanPhimCaption";
            this.lbBanPhimCaption.Size = new System.Drawing.Size(120, 17);
            this.lbBanPhimCaption.TabIndex = 3;
            this.lbBanPhimCaption.Text = "BÀN PHÍM SỐ";

            // =========================================================
            // pnlChuyenKhoan
            // =========================================================
            this.pnlChuyenKhoan.BorderRadius = 14;
            this.pnlChuyenKhoan.Controls.Add(this.lbCKCaption);
            this.pnlChuyenKhoan.Controls.Add(this.btnNganHang);
            this.pnlChuyenKhoan.Controls.Add(this.btnMoMo);
            this.pnlChuyenKhoan.Controls.Add(this.btnZaloPay);
            this.pnlChuyenKhoan.Controls.Add(this.lbCKGhiChu);
            this.pnlChuyenKhoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.pnlChuyenKhoan.Location = new System.Drawing.Point(24, 160);
            this.pnlChuyenKhoan.Name = "pnlChuyenKhoan";
            this.pnlChuyenKhoan.Size = new System.Drawing.Size(640, 536);
            this.pnlChuyenKhoan.TabIndex = 5;
            this.pnlChuyenKhoan.Visible = false;

            this.lbCKCaption.AutoSize = true;
            this.lbCKCaption.BackColor = System.Drawing.Color.Transparent;
            this.lbCKCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lbCKCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(152)))), ((int)(((byte)(158)))));
            this.lbCKCaption.Location = new System.Drawing.Point(20, 24);
            this.lbCKCaption.Name = "lbCKCaption";
            this.lbCKCaption.Size = new System.Drawing.Size(230, 17);
            this.lbCKCaption.TabIndex = 0;
            this.lbCKCaption.Text = "CHỌN KÊNH CHUYỂN KHOẢN";

            this.btnNganHang.BorderRadius = 12;
            this.btnNganHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNganHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNganHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(64)))));
            this.btnNganHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(124)))));
            this.btnNganHang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(41)))));
            this.btnNganHang.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.btnNganHang.ForeColor = System.Drawing.Color.White;
            this.btnNganHang.Location = new System.Drawing.Point(20, 60);
            this.btnNganHang.Name = "btnNganHang";
            this.btnNganHang.Size = new System.Drawing.Size(600, 84);
            this.btnNganHang.TabIndex = 1;
            this.btnNganHang.Text = "Ngân hàng";

            this.btnMoMo.BorderRadius = 12;
            this.btnMoMo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMoMo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMoMo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(64)))));
            this.btnMoMo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(124)))));
            this.btnMoMo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(41)))));
            this.btnMoMo.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.btnMoMo.ForeColor = System.Drawing.Color.White;
            this.btnMoMo.Location = new System.Drawing.Point(20, 156);
            this.btnMoMo.Name = "btnMoMo";
            this.btnMoMo.Size = new System.Drawing.Size(600, 84);
            this.btnMoMo.TabIndex = 2;
            this.btnMoMo.Text = "MoMo";

            this.btnZaloPay.BorderRadius = 12;
            this.btnZaloPay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnZaloPay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnZaloPay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(64)))));
            this.btnZaloPay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(124)))));
            this.btnZaloPay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(41)))));
            this.btnZaloPay.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.btnZaloPay.ForeColor = System.Drawing.Color.White;
            this.btnZaloPay.Location = new System.Drawing.Point(20, 252);
            this.btnZaloPay.Name = "btnZaloPay";
            this.btnZaloPay.Size = new System.Drawing.Size(600, 84);
            this.btnZaloPay.TabIndex = 3;
            this.btnZaloPay.Text = "ZaloPay";

            this.lbCKGhiChu.AutoSize = false;
            this.lbCKGhiChu.BackColor = System.Drawing.Color.Transparent;
            this.lbCKGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbCKGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(152)))), ((int)(((byte)(158)))));
            this.lbCKGhiChu.Location = new System.Drawing.Point(20, 356);
            this.lbCKGhiChu.Name = "lbCKGhiChu";
            this.lbCKGhiChu.Size = new System.Drawing.Size(600, 60);
            this.lbCKGhiChu.TabIndex = 4;
            this.lbCKGhiChu.Text = "Chọn kênh chuyển khoản, sau đó nhấn \"Thanh toán\" để xác nhận khách đã chuyển đủ số tiền của hóa đơn.";

            // =========================================================
            // pnlThe
            // =========================================================
            this.pnlThe.BorderRadius = 14;
            this.pnlThe.Controls.Add(this.lbTheCaption);
            this.pnlThe.Controls.Add(this.btnTheVisa);
            this.pnlThe.Controls.Add(this.btnTheDienTu);
            this.pnlThe.Controls.Add(this.lbTheGhiChu);
            this.pnlThe.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.pnlThe.Location = new System.Drawing.Point(24, 160);
            this.pnlThe.Name = "pnlThe";
            this.pnlThe.Size = new System.Drawing.Size(640, 536);
            this.pnlThe.TabIndex = 6;
            this.pnlThe.Visible = false;

            this.lbTheCaption.AutoSize = true;
            this.lbTheCaption.BackColor = System.Drawing.Color.Transparent;
            this.lbTheCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lbTheCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(152)))), ((int)(((byte)(158)))));
            this.lbTheCaption.Location = new System.Drawing.Point(20, 24);
            this.lbTheCaption.Name = "lbTheCaption";
            this.lbTheCaption.Size = new System.Drawing.Size(150, 17);
            this.lbTheCaption.TabIndex = 0;
            this.lbTheCaption.Text = "CHỌN LOẠI THẺ";

            this.btnTheVisa.BorderRadius = 12;
            this.btnTheVisa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTheVisa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTheVisa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(64)))));
            this.btnTheVisa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(124)))));
            this.btnTheVisa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(41)))));
            this.btnTheVisa.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.btnTheVisa.ForeColor = System.Drawing.Color.White;
            this.btnTheVisa.Location = new System.Drawing.Point(20, 64);
            this.btnTheVisa.Name = "btnTheVisa";
            this.btnTheVisa.Size = new System.Drawing.Size(600, 110);
            this.btnTheVisa.TabIndex = 1;
            this.btnTheVisa.Text = "Thẻ Visa vật lý";

            this.btnTheDienTu.BorderRadius = 12;
            this.btnTheDienTu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTheDienTu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTheDienTu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(64)))));
            this.btnTheDienTu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(124)))));
            this.btnTheDienTu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(41)))));
            this.btnTheDienTu.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.btnTheDienTu.ForeColor = System.Drawing.Color.White;
            this.btnTheDienTu.Location = new System.Drawing.Point(20, 190);
            this.btnTheDienTu.Name = "btnTheDienTu";
            this.btnTheDienTu.Size = new System.Drawing.Size(600, 110);
            this.btnTheDienTu.TabIndex = 2;
            this.btnTheDienTu.Text = "Thẻ điện tử";

            this.lbTheGhiChu.AutoSize = false;
            this.lbTheGhiChu.BackColor = System.Drawing.Color.Transparent;
            this.lbTheGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbTheGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(152)))), ((int)(((byte)(158)))));
            this.lbTheGhiChu.Location = new System.Drawing.Point(20, 320);
            this.lbTheGhiChu.Name = "lbTheGhiChu";
            this.lbTheGhiChu.Size = new System.Drawing.Size(600, 60);
            this.lbTheGhiChu.TabIndex = 3;
            this.lbTheGhiChu.Text = "Chọn loại thẻ khách sử dụng, sau đó nhấn \"Thanh toán\" để xác nhận giao dịch thẻ đã thành công.";

            // =========================================================
            // pnlTomTat
            // =========================================================
            this.pnlTomTat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTomTat.BorderRadius = 14;
            this.pnlTomTat.Controls.Add(this.lbTongTienCaption);
            this.pnlTomTat.Controls.Add(this.lbTongTien);
            this.pnlTomTat.Controls.Add(this.lbPTCaption);
            this.pnlTomTat.Controls.Add(this.lbPTValue);
            this.pnlTomTat.Controls.Add(this.lbDuaCaption);
            this.pnlTomTat.Controls.Add(this.lbDuaValue);
            this.pnlTomTat.Controls.Add(this.lbThoiCaption);
            this.pnlTomTat.Controls.Add(this.lbThoiValue);
            this.pnlTomTat.Controls.Add(this.lbCanhBao);
            this.pnlTomTat.Controls.Add(this.btnThanhToan);
            this.pnlTomTat.Controls.Add(this.btnHuy);
            this.pnlTomTat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.pnlTomTat.Location = new System.Drawing.Point(688, 92);
            this.pnlTomTat.Name = "pnlTomTat";
            this.pnlTomTat.Size = new System.Drawing.Size(308, 604);
            this.pnlTomTat.TabIndex = 7;

            this.lbTongTienCaption.AutoSize = true;
            this.lbTongTienCaption.BackColor = System.Drawing.Color.Transparent;
            this.lbTongTienCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lbTongTienCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(152)))), ((int)(((byte)(158)))));
            this.lbTongTienCaption.Location = new System.Drawing.Point(20, 24);
            this.lbTongTienCaption.Name = "lbTongTienCaption";
            this.lbTongTienCaption.Size = new System.Drawing.Size(175, 17);
            this.lbTongTienCaption.TabIndex = 0;
            this.lbTongTienCaption.Text = "TỔNG TIỀN HÓA ĐƠN";

            this.lbTongTien.AutoSize = false;
            this.lbTongTien.BackColor = System.Drawing.Color.Transparent;
            this.lbTongTien.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lbTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.lbTongTien.Location = new System.Drawing.Point(20, 46);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(268, 46);
            this.lbTongTien.TabIndex = 1;
            this.lbTongTien.Text = "0 đ";

            // Dòng: phương thức
            this.lbPTCaption.AutoSize = false;
            this.lbPTCaption.BackColor = System.Drawing.Color.Transparent;
            this.lbPTCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbPTCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(152)))), ((int)(((byte)(158)))));
            this.lbPTCaption.Location = new System.Drawing.Point(20, 130);
            this.lbPTCaption.Name = "lbPTCaption";
            this.lbPTCaption.Size = new System.Drawing.Size(120, 24);
            this.lbPTCaption.TabIndex = 2;
            this.lbPTCaption.Text = "Phương thức";

            this.lbPTValue.AutoSize = false;
            this.lbPTValue.BackColor = System.Drawing.Color.Transparent;
            this.lbPTValue.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.lbPTValue.ForeColor = System.Drawing.Color.White;
            this.lbPTValue.Location = new System.Drawing.Point(140, 130);
            this.lbPTValue.Name = "lbPTValue";
            this.lbPTValue.Size = new System.Drawing.Size(148, 24);
            this.lbPTValue.TabIndex = 3;
            this.lbPTValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbPTValue.Text = "Tiền mặt";

            // Dòng: khách đưa
            this.lbDuaCaption.AutoSize = false;
            this.lbDuaCaption.BackColor = System.Drawing.Color.Transparent;
            this.lbDuaCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbDuaCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(152)))), ((int)(((byte)(158)))));
            this.lbDuaCaption.Location = new System.Drawing.Point(20, 174);
            this.lbDuaCaption.Name = "lbDuaCaption";
            this.lbDuaCaption.Size = new System.Drawing.Size(120, 24);
            this.lbDuaCaption.TabIndex = 4;
            this.lbDuaCaption.Text = "Khách đưa";

            this.lbDuaValue.AutoSize = false;
            this.lbDuaValue.BackColor = System.Drawing.Color.Transparent;
            this.lbDuaValue.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.lbDuaValue.ForeColor = System.Drawing.Color.White;
            this.lbDuaValue.Location = new System.Drawing.Point(140, 174);
            this.lbDuaValue.Name = "lbDuaValue";
            this.lbDuaValue.Size = new System.Drawing.Size(148, 24);
            this.lbDuaValue.TabIndex = 5;
            this.lbDuaValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbDuaValue.Text = "0 đ";

            // Dòng: tiền thối
            this.lbThoiCaption.AutoSize = false;
            this.lbThoiCaption.BackColor = System.Drawing.Color.Transparent;
            this.lbThoiCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbThoiCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(152)))), ((int)(((byte)(158)))));
            this.lbThoiCaption.Location = new System.Drawing.Point(20, 218);
            this.lbThoiCaption.Name = "lbThoiCaption";
            this.lbThoiCaption.Size = new System.Drawing.Size(120, 24);
            this.lbThoiCaption.TabIndex = 6;
            this.lbThoiCaption.Text = "Tiền thối lại";

            this.lbThoiValue.AutoSize = false;
            this.lbThoiValue.BackColor = System.Drawing.Color.Transparent;
            this.lbThoiValue.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lbThoiValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lbThoiValue.Location = new System.Drawing.Point(140, 216);
            this.lbThoiValue.Name = "lbThoiValue";
            this.lbThoiValue.Size = new System.Drawing.Size(148, 28);
            this.lbThoiValue.TabIndex = 7;
            this.lbThoiValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbThoiValue.Text = "0 đ";

            this.lbCanhBao.AutoSize = false;
            this.lbCanhBao.BackColor = System.Drawing.Color.Transparent;
            this.lbCanhBao.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lbCanhBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(180)))), ((int)(((byte)(60)))));
            this.lbCanhBao.Location = new System.Drawing.Point(20, 262);
            this.lbCanhBao.Name = "lbCanhBao";
            this.lbCanhBao.Size = new System.Drawing.Size(268, 60);
            this.lbCanhBao.TabIndex = 8;
            this.lbCanhBao.Text = "";

            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan.BorderRadius = 12;
            this.btnThanhToan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhToan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhToan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnThanhToan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(120)))), ((int)(((byte)(124)))));
            this.btnThanhToan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.btnThanhToan.Location = new System.Drawing.Point(20, 462);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(268, 64);
            this.btnThanhToan.TabIndex = 9;
            this.btnThanhToan.Text = "THANH TOÁN";

            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(74)))));
            this.btnHuy.BorderRadius = 12;
            this.btnHuy.BorderThickness = 1;
            this.btnHuy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(64)))));
            this.btnHuy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(124)))));
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(192)))), ((int)(((byte)(198)))));
            this.btnHuy.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.btnHuy.Location = new System.Drawing.Point(20, 536);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(268, 46);
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Text = "Hủy";

            // =========================================================
            // FormThanhToanKH
            // =========================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1020, 720);
            this.Controls.Add(this.pnlTomTat);
            this.Controls.Add(this.pnlTienMat);
            this.Controls.Add(this.pnlChuyenKhoan);
            this.Controls.Add(this.pnlThe);
            this.Controls.Add(this.btnTienMat);
            this.Controls.Add(this.btnChuyenKhoan);
            this.Controls.Add(this.btnThe);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormThanhToanKH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SPORTSHOP - Thanh toán";
            this.Load += new System.EventHandler(this.FormThanhToanKH_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTienMat.ResumeLayout(false);
            this.pnlTienMat.PerformLayout();
            this.pnlChuyenKhoan.ResumeLayout(false);
            this.pnlChuyenKhoan.PerformLayout();
            this.pnlThe.ResumeLayout(false);
            this.pnlThe.PerformLayout();
            this.pnlTomTat.ResumeLayout(false);
            this.pnlTomTat.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lbTieuDe;
        private System.Windows.Forms.Label lbMaHoaDon;

        private Guna.UI2.WinForms.Guna2Button btnTienMat;
        private Guna.UI2.WinForms.Guna2Button btnChuyenKhoan;
        private Guna.UI2.WinForms.Guna2Button btnThe;

        private Guna.UI2.WinForms.Guna2Panel pnlTienMat;
        private System.Windows.Forms.Label lbKhachDuaCaption;
        private System.Windows.Forms.Label lbKhachDua;
        private System.Windows.Forms.Label lbMenhGiaCaption;
        private System.Windows.Forms.Label lbBanPhimCaption;

        private Guna.UI2.WinForms.Guna2Panel pnlChuyenKhoan;
        private System.Windows.Forms.Label lbCKCaption;
        private Guna.UI2.WinForms.Guna2Button btnNganHang;
        private Guna.UI2.WinForms.Guna2Button btnMoMo;
        private Guna.UI2.WinForms.Guna2Button btnZaloPay;
        private System.Windows.Forms.Label lbCKGhiChu;

        private Guna.UI2.WinForms.Guna2Panel pnlThe;
        private System.Windows.Forms.Label lbTheCaption;
        private Guna.UI2.WinForms.Guna2Button btnTheVisa;
        private Guna.UI2.WinForms.Guna2Button btnTheDienTu;
        private System.Windows.Forms.Label lbTheGhiChu;

        private Guna.UI2.WinForms.Guna2Panel pnlTomTat;
        private System.Windows.Forms.Label lbTongTienCaption;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label lbPTCaption;
        private System.Windows.Forms.Label lbPTValue;
        private System.Windows.Forms.Label lbDuaCaption;
        private System.Windows.Forms.Label lbDuaValue;
        private System.Windows.Forms.Label lbThoiCaption;
        private System.Windows.Forms.Label lbThoiValue;
        private System.Windows.Forms.Label lbCanhBao;
        private Guna.UI2.WinForms.Guna2Button btnThanhToan;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}
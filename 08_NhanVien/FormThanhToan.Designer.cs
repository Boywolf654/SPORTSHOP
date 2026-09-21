using System;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    partial class FormThanhToan
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader, pnlThongTin, pnlSanPham, pnlThanhToan, pnlVi;
        private System.Windows.Forms.Label lblLogo, lblTitle, lblSubTitle;
        private System.Windows.Forms.Label lblMaDon, lblMaDonValue, lblKhach, lblKhachValue, lblSDT, lblSDTValue, lblNgay, lblNgayValue;
        private System.Windows.Forms.Label lblTrangThai, lblTrangThaiValue, lblTongTien, lblTongTienValue, lblTongSP, lblTongSPValue;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT, colSanPham, colBienThe, colPhanLoai, colSL, colDonGia, colThanhTien;
        private System.Windows.Forms.RadioButton rdoTienMat, rdoThe, rdoChuyenKhoan, rdoVi;
        private System.Windows.Forms.Label lblCashIcon, lblCardIcon, lblBankIcon, lblWalletIcon;
        private System.Windows.Forms.Label lblSoDu, lblSoDuValue, lblHint;
        private System.Windows.Forms.CheckBox chkCheckIn;
        private System.Windows.Forms.Button btnQuayLai, btnXacNhan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.pnlSanPham = new System.Windows.Forms.Panel();
            this.pnlThanhToan = new System.Windows.Forms.Panel();
            this.pnlVi = new System.Windows.Forms.Panel();

            this.lblLogo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();

            this.lblMaDon = new System.Windows.Forms.Label(); this.lblMaDonValue = new System.Windows.Forms.Label();
            this.lblKhach = new System.Windows.Forms.Label(); this.lblKhachValue = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label(); this.lblSDTValue = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label(); this.lblNgayValue = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label(); this.lblTrangThaiValue = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label(); this.lblTongTienValue = new System.Windows.Forms.Label();
            this.lblTongSP = new System.Windows.Forms.Label(); this.lblTongSPValue = new System.Windows.Forms.Label();

            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBienThe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhanLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.rdoTienMat = new System.Windows.Forms.RadioButton();
            this.rdoThe = new System.Windows.Forms.RadioButton();
            this.rdoChuyenKhoan = new System.Windows.Forms.RadioButton();
            this.rdoVi = new System.Windows.Forms.RadioButton();

            this.lblCashIcon = new System.Windows.Forms.Label();
            this.lblCardIcon = new System.Windows.Forms.Label();
            this.lblBankIcon = new System.Windows.Forms.Label();
            this.lblWalletIcon = new System.Windows.Forms.Label();

            this.lblSoDu = new System.Windows.Forms.Label();
            this.lblSoDuValue = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();

            this.chkCheckIn = new System.Windows.Forms.CheckBox();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();

            this.SuspendLayout();

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(239, 243, 248);
            this.ClientSize = new System.Drawing.Size(1280, 820);
            this.MinimumSize = new System.Drawing.Size(1100, 720);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "FormThanhToan";
            this.Text = "SPORTSHOP - Thanh toán đơn hàng";
            this.Load += new System.EventHandler(this.FormThanhToan_Load);

            // HEADER
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(18, 35, 58);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 88;

            this.lblLogo.Text = "SPORTSHOP";
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(28, 15);

            this.lblTitle.Text = "Thanh toán đơn hàng";
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(220, 18);

            this.lblSubTitle.Text = "Kiểm tra đơn → chọn phương thức → xác nhận thanh toán";
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(190, 207, 225);
            this.lblSubTitle.Location = new System.Drawing.Point(222, 48);

            this.pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] { lblLogo, lblTitle, lblSubTitle });

            // LEFT INFO
            this.pnlThongTin.BackColor = System.Drawing.Color.White;
            this.pnlThongTin.Location = new System.Drawing.Point(22, 105);
            this.pnlThongTin.Size = new System.Drawing.Size(360, 190);
            this.pnlThongTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblMaDon.Text = "Mã đơn";
            this.lblMaDon.AutoSize = true;
            this.lblMaDon.Location = new System.Drawing.Point(18, 18);
            this.lblMaDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaDon.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95);

            this.lblMaDonValue.Text = "—";
            this.lblMaDonValue.AutoSize = true;
            this.lblMaDonValue.Location = new System.Drawing.Point(135, 18);
            this.lblMaDonValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaDonValue.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95);

            this.lblKhach.Text = "Khách hàng";
            this.lblKhach.AutoSize = true;
            this.lblKhach.Location = new System.Drawing.Point(18, 52);
            this.lblKhach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKhach.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95);

            this.lblKhachValue.Text = "—";
            this.lblKhachValue.AutoSize = true;
            this.lblKhachValue.Location = new System.Drawing.Point(135, 52);
            this.lblKhachValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKhachValue.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95);

            this.lblSDT.Text = "SĐT";
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(18, 86);
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSDT.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95);

            this.lblSDTValue.Text = "—";
            this.lblSDTValue.AutoSize = true;
            this.lblSDTValue.Location = new System.Drawing.Point(135, 86);
            this.lblSDTValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSDTValue.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95);

            this.lblNgay.Text = "Ngày đặt";
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(18, 120);
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNgay.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95);

            this.lblNgayValue.Text = "—";
            this.lblNgayValue.AutoSize = true;
            this.lblNgayValue.Location = new System.Drawing.Point(135, 120);
            this.lblNgayValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgayValue.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95);

            this.lblTrangThai.Text = "Trạng thái";
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(18, 154);
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95);

            this.lblTrangThaiValue.Text = "Chờ thanh toán";
            this.lblTrangThaiValue.AutoSize = true;
            this.lblTrangThaiValue.Location = new System.Drawing.Point(135, 154);
            this.lblTrangThaiValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTrangThaiValue.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95);

            this.pnlThongTin.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMaDon,this.lblMaDonValue,this.lblKhach,this.lblKhachValue,
                this.lblSDT,this.lblSDTValue,this.lblNgay,this.lblNgayValue,
                this.lblTrangThai,this.lblTrangThaiValue
            });

            // PRODUCTS
            this.pnlSanPham.BackColor = System.Drawing.Color.White;
            this.pnlSanPham.Location = new System.Drawing.Point(398, 105);
            this.pnlSanPham.Size = new System.Drawing.Size(860, 350);
            this.pnlSanPham.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblTongSP.Text = "Sản phẩm trong đơn";
            this.lblTongSP.AutoSize = true;
            this.lblTongSP.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongSP.ForeColor = System.Drawing.Color.FromArgb(25, 52, 82);
            this.lblTongSP.Location = new System.Drawing.Point(18, 14);

            this.lblTongSPValue.Text = "0 sản phẩm";
            this.lblTongSPValue.AutoSize = true;
            this.lblTongSPValue.ForeColor = System.Drawing.Color.FromArgb(100, 110, 125);
            this.lblTongSPValue.Location = new System.Drawing.Point(740, 17);

            this.dgvSanPham.Location = new System.Drawing.Point(18, 45);
            this.dgvSanPham.Size = new System.Drawing.Size(820, 285);
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersVisible = false;
            this.dgvSanPham.EnableHeadersVisualStyles = false;
            this.dgvSanPham.ColumnHeadersHeight = 38;
            this.dgvSanPham.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(25, 52, 82);
            this.dgvSanPham.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSanPham.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.dgvSanPham.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.dgvSanPham.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(229, 240, 253);
            this.dgvSanPham.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(25, 52, 82);

            this.colSTT.HeaderText = "STT"; this.colSTT.Name = "colSTT"; this.colSTT.Width = 42;
            this.colSanPham.HeaderText = "Sản phẩm"; this.colSanPham.Name = "colSanPham"; this.colSanPham.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBienThe.HeaderText = "Biến thể"; this.colBienThe.Name = "colBienThe"; this.colBienThe.Width = 80;
            this.colPhanLoai.HeaderText = "Size / Màu"; this.colPhanLoai.Name = "colPhanLoai"; this.colPhanLoai.Width = 105;
            this.colSL.HeaderText = "SL"; this.colSL.Name = "colSL"; this.colSL.Width = 45;
            this.colDonGia.HeaderText = "Đơn giá"; this.colDonGia.Name = "colDonGia"; this.colDonGia.Width = 100;
            this.colThanhTien.HeaderText = "Thành tiền"; this.colThanhTien.Name = "colThanhTien"; this.colThanhTien.Width = 110;
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colSTT, colSanPham, colBienThe, colPhanLoai, colSL, colDonGia, colThanhTien });

            this.pnlSanPham.Controls.AddRange(new System.Windows.Forms.Control[] { lblTongSP, lblTongSPValue, dgvSanPham });

            // PAYMENT
            this.pnlThanhToan.BackColor = System.Drawing.Color.White;
            this.pnlThanhToan.Location = new System.Drawing.Point(22, 315);
            this.pnlThanhToan.Size = new System.Drawing.Size(360, 385);
            this.pnlThanhToan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            System.Windows.Forms.Label paymentTitle = new System.Windows.Forms.Label();
            paymentTitle.Text = "Chọn phương thức thanh toán";
            paymentTitle.AutoSize = true;
            paymentTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            paymentTitle.ForeColor = System.Drawing.Color.FromArgb(25, 52, 82);
            paymentTitle.Location = new System.Drawing.Point(18, 15);
            this.pnlThanhToan.Controls.Add(paymentTitle);

            this.rdoTienMat.Text = "Tiền mặt";
            this.rdoTienMat.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.rdoTienMat.Location = new System.Drawing.Point(18, 60);
            this.rdoTienMat.Size = new System.Drawing.Size(145, 25);
            this.rdoTienMat.ForeColor = System.Drawing.Color.FromArgb(35, 50, 70);

            this.lblCashIcon.Text = "$";
            this.lblCashIcon.AutoSize = true;
            this.lblCashIcon.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblCashIcon.ForeColor = System.Drawing.Color.FromArgb(27, 120, 220);
            this.lblCashIcon.Location = new System.Drawing.Point(18, 90);

            System.Windows.Forms.Label lblCashSub = new System.Windows.Forms.Label();
            lblCashSub.Text = "Thanh toán trực tiếp";
            lblCashSub.AutoSize = true;
            lblCashSub.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            lblCashSub.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145);
            lblCashSub.Location = new System.Drawing.Point(58, 92);

            this.rdoThe.Text = "Thẻ ngân hàng";
            this.rdoThe.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.rdoThe.Location = new System.Drawing.Point(182, 60);
            this.rdoThe.Size = new System.Drawing.Size(145, 25);
            this.rdoThe.ForeColor = System.Drawing.Color.FromArgb(35, 50, 70);

            this.lblCardIcon.Text = "CARD";
            this.lblCardIcon.AutoSize = true;
            this.lblCardIcon.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardIcon.ForeColor = System.Drawing.Color.FromArgb(27, 120, 220);
            this.lblCardIcon.Location = new System.Drawing.Point(182, 90);

            System.Windows.Forms.Label lblCardSub = new System.Windows.Forms.Label();
            lblCardSub.Text = "ATM / Visa / MasterCard";
            lblCardSub.AutoSize = true;
            lblCardSub.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            lblCardSub.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145);
            lblCardSub.Location = new System.Drawing.Point(222, 92);

            this.rdoChuyenKhoan.Text = "Chuyển khoản";
            this.rdoChuyenKhoan.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.rdoChuyenKhoan.Location = new System.Drawing.Point(18, 150);
            this.rdoChuyenKhoan.Size = new System.Drawing.Size(145, 25);
            this.rdoChuyenKhoan.ForeColor = System.Drawing.Color.FromArgb(35, 50, 70);

            this.lblBankIcon.Text = "BANK";
            this.lblBankIcon.AutoSize = true;
            this.lblBankIcon.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblBankIcon.ForeColor = System.Drawing.Color.FromArgb(27, 120, 220);
            this.lblBankIcon.Location = new System.Drawing.Point(18, 180);

            System.Windows.Forms.Label lblBankSub = new System.Windows.Forms.Label();
            lblBankSub.Text = "QR / ngân hàng";
            lblBankSub.AutoSize = true;
            lblBankSub.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            lblBankSub.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145);
            lblBankSub.Location = new System.Drawing.Point(58, 182);

            this.rdoVi.Text = "Ví điện tử";
            this.rdoVi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.rdoVi.Location = new System.Drawing.Point(182, 150);
            this.rdoVi.Size = new System.Drawing.Size(145, 25);
            this.rdoVi.ForeColor = System.Drawing.Color.FromArgb(35, 50, 70);

            this.lblWalletIcon.Text = "VÍ";
            this.lblWalletIcon.AutoSize = true;
            this.lblWalletIcon.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblWalletIcon.ForeColor = System.Drawing.Color.FromArgb(27, 120, 220);
            this.lblWalletIcon.Location = new System.Drawing.Point(182, 180);

            System.Windows.Forms.Label lblWalletSub = new System.Windows.Forms.Label();
            lblWalletSub.Text = "Ví SPORTSHOP";
            lblWalletSub.AutoSize = true;
            lblWalletSub.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            lblWalletSub.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145);
            lblWalletSub.Location = new System.Drawing.Point(222, 182);

            this.pnlThanhToan.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.rdoTienMat,this.lblCashIcon,lblCashSub,
                this.rdoThe,this.lblCardIcon,lblCardSub,
                this.rdoChuyenKhoan,this.lblBankIcon,lblBankSub,
                this.rdoVi,this.lblWalletIcon,lblWalletSub
            });

            this.rdoTienMat.Checked = true;
            this.rdoTienMat.CheckedChanged += PhuongThuc_CheckedChanged;
            this.rdoThe.CheckedChanged += PhuongThuc_CheckedChanged;
            this.rdoChuyenKhoan.CheckedChanged += PhuongThuc_CheckedChanged;
            this.rdoVi.CheckedChanged += PhuongThuc_CheckedChanged;

            this.pnlVi.BackColor = System.Drawing.Color.FromArgb(241, 248, 255);
            this.pnlVi.Location = new System.Drawing.Point(18, 235);
            this.pnlVi.Size = new System.Drawing.Size(322, 62);
            this.pnlVi.Visible = false;

            this.lblSoDu.Text = "Số dư ví";
            this.lblSoDu.AutoSize = true;
            this.lblSoDu.Location = new System.Drawing.Point(12, 11);
            this.lblSoDu.ForeColor = System.Drawing.Color.FromArgb(90, 100, 115);

            this.lblSoDuValue.Text = "0 đ";
            this.lblSoDuValue.AutoSize = true;
            this.lblSoDuValue.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblSoDuValue.ForeColor = System.Drawing.Color.FromArgb(20, 150, 80);
            this.lblSoDuValue.Location = new System.Drawing.Point(205, 8);

            this.pnlVi.Controls.AddRange(new System.Windows.Forms.Control[] { lblSoDu, lblSoDuValue });

            this.lblHint.Text = "Chọn phương thức phù hợp để tiếp tục thanh toán.";
            this.lblHint.AutoSize = false;
            this.lblHint.Size = new System.Drawing.Size(322, 45);
            this.lblHint.Location = new System.Drawing.Point(18, 305);
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(100, 110, 125);

            this.pnlThanhToan.Controls.AddRange(new System.Windows.Forms.Control[] { pnlVi, lblHint });

            // TOTAL RIGHT
            System.Windows.Forms.Panel total = new System.Windows.Forms.Panel();
            total.BackColor = System.Drawing.Color.White;
            total.Location = new System.Drawing.Point(398, 475);
            total.Size = new System.Drawing.Size(860, 225);
            total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            System.Windows.Forms.Label totalTitle = new System.Windows.Forms.Label();
            totalTitle.Text = "Xác nhận thanh toán";
            totalTitle.AutoSize = true;
            totalTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            totalTitle.ForeColor = System.Drawing.Color.FromArgb(25, 52, 82);
            totalTitle.Location = new System.Drawing.Point(22, 18);

            System.Windows.Forms.Label totalCaption = new System.Windows.Forms.Label();
            totalCaption.Text = "Tổng tiền cần thanh toán";
            totalCaption.AutoSize = true;
            totalCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            totalCaption.ForeColor = System.Drawing.Color.FromArgb(100, 110, 125);
            totalCaption.Location = new System.Drawing.Point(22, 65);

            this.lblTongTienValue.Text = "0 đ";
            this.lblTongTienValue.AutoSize = true;
            this.lblTongTienValue.Font = new System.Drawing.Font("Segoe UI Semibold", 25F, System.Drawing.FontStyle.Bold);
            this.lblTongTienValue.ForeColor = System.Drawing.Color.FromArgb(220, 44, 54);
            this.lblTongTienValue.Location = new System.Drawing.Point(22, 87);

            this.chkCheckIn.Text = "Tôi xác nhận khách hàng đã check-in";
            this.chkCheckIn.AutoSize = true;
            this.chkCheckIn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.chkCheckIn.Location = new System.Drawing.Point(390, 28);

            this.btnQuayLai.Text = "← Quay lại";
            this.btnQuayLai.BackColor = System.Drawing.Color.FromArgb(230, 235, 243);
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.FlatAppearance.BorderSize = 0;
            this.btnQuayLai.Location = new System.Drawing.Point(390, 145);
            this.btnQuayLai.Size = new System.Drawing.Size(125, 42);
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);

            this.btnXacNhan.Text = "✓  XÁC NHẬN THANH TOÁN";
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(22, 177, 105);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.Location = new System.Drawing.Point(530, 145);
            this.btnXacNhan.Size = new System.Drawing.Size(295, 42);
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);

            total.Controls.AddRange(new System.Windows.Forms.Control[] { totalTitle, totalCaption, lblTongTienValue, chkCheckIn, btnQuayLai, btnXacNhan });

            this.Controls.Add(total);
            this.Controls.Add(pnlSanPham);
            this.Controls.Add(pnlThanhToan);
            this.Controls.Add(pnlThongTin);
            this.Controls.Add(pnlHeader);

            this.ResumeLayout(false);
        }
    }
}

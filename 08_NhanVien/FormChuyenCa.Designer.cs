using System;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP
{
    partial class FormChuyenCa
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubTitle;
        private Label lblMaCa;
        private Label lblMaCaValue;
        private Label lblNhanVien;
        private Label lblNhanVienValue;
        private Label lblMaNV;
        private Label lblMaNVValue;

        private Panel pnlSummary;
        private Label lblSummaryTitle;
        private Label lblBatDau;
        private Label lblBatDauValue;
        private Label lblThoiGian;
        private Label lblThoiGianValue;
        private Label lblDoanhThu;
        private Label lblDoanhThuValue;
        private Label lblSoHoaDon;
        private Label lblSoHoaDonValue;
        private Label lblDonCho;
        private Label lblDonChoValue;

        private Panel pnlPayment;
        private Label lblPaymentTitle;
        private Label lblTienMat;
        private Label lblTienMatValue;
        private Label lblThe;
        private Label lblTheValue;
        private Label lblChuyenKhoan;
        private Label lblChuyenKhoanValue;
        private Label lblVi;
        private Label lblViValue;

        private Panel pnlWarning;
        private Label lblWarning;

        private CheckBox chkXacNhan;
        private Button btnChuyenCa;
        private Button btnDong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblSubTitle = new Label();
            this.lblMaCa = new Label();
            this.lblMaCaValue = new Label();
            this.lblNhanVien = new Label();
            this.lblNhanVienValue = new Label();
            this.lblMaNV = new Label();
            this.lblMaNVValue = new Label();

            this.pnlSummary = new Panel();
            this.lblSummaryTitle = new Label();
            this.lblBatDau = new Label();
            this.lblBatDauValue = new Label();
            this.lblThoiGian = new Label();
            this.lblThoiGianValue = new Label();
            this.lblDoanhThu = new Label();
            this.lblDoanhThuValue = new Label();
            this.lblSoHoaDon = new Label();
            this.lblSoHoaDonValue = new Label();
            this.lblDonCho = new Label();
            this.lblDonChoValue = new Label();

            this.pnlPayment = new Panel();
            this.lblPaymentTitle = new Label();
            this.lblTienMat = new Label();
            this.lblTienMatValue = new Label();
            this.lblThe = new Label();
            this.lblTheValue = new Label();
            this.lblChuyenKhoan = new Label();
            this.lblChuyenKhoanValue = new Label();
            this.lblVi = new Label();
            this.lblViValue = new Label();

            this.pnlWarning = new Panel();
            this.lblWarning = new Label();

            this.chkXacNhan = new CheckBox();
            this.btnChuyenCa = new Button();
            this.btnDong = new Button();

            // FormChuyenCa
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.BackColor = Color.FromArgb(244, 247, 251);
            this.ClientSize = new Size(1120, 720);
            this.MinimumSize = new Size(980, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChuyenCa";
            this.Text = "SPORTSHOP - Chuyển giao ca";
            this.Load += new EventHandler(this.FormChuyenCa_Load);

            // Header
            this.pnlHeader.BackColor = Color.FromArgb(24, 52, 88);
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(1120, 116);

            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = Color.Transparent;
            this.lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(30, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "CHUYỂN GIAO CA";

            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.BackColor = Color.Transparent;
            this.lblSubTitle.Font = new Font("Segoe UI", 11F);
            this.lblSubTitle.ForeColor = Color.FromArgb(210, 224, 240);
            this.lblSubTitle.Location = new Point(32, 62);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Text = "Tổng kết doanh thu và kết thúc ca làm việc hiện tại";

            this.lblMaCa.AutoSize = true;
            this.lblMaCa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblMaCa.ForeColor = Color.FromArgb(180, 205, 230);
            this.lblMaCa.Location = new Point(790, 15);
            this.lblMaCa.Name = "lblMaCa";
            this.lblMaCa.Text = "CA HIỆN TẠI";

            this.lblMaCaValue.AutoSize = true;
            this.lblMaCaValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblMaCaValue.ForeColor = Color.White;
            this.lblMaCaValue.Location = new Point(790, 37);
            this.lblMaCaValue.Name = "lblMaCaValue";
            this.lblMaCaValue.Text = "CA0000";

            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblNhanVien.ForeColor = Color.FromArgb(180, 205, 230);
            this.lblNhanVien.Location = new Point(950, 15);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Text = "NHÂN VIÊN";

            this.lblNhanVienValue.AutoSize = true;
            this.lblNhanVienValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblNhanVienValue.ForeColor = Color.White;
            this.lblNhanVienValue.Location = new Point(950, 40);
            this.lblNhanVienValue.Name = "lblNhanVienValue";
            this.lblNhanVienValue.Text = "—";

            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.lblMaNV.ForeColor = Color.FromArgb(180, 205, 230);
            this.lblMaNV.Location = new Point(790, 82);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Text = "MÃ NV";

            this.lblMaNVValue.AutoSize = true;
            this.lblMaNVValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblMaNVValue.ForeColor = Color.White;
            this.lblMaNVValue.Location = new Point(850, 80);
            this.lblMaNVValue.Name = "lblMaNVValue";
            this.lblMaNVValue.Text = "—";

            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblMaCa);
            this.pnlHeader.Controls.Add(this.lblMaCaValue);
            this.pnlHeader.Controls.Add(this.lblNhanVien);
            this.pnlHeader.Controls.Add(this.lblNhanVienValue);
            this.pnlHeader.Controls.Add(this.lblMaNV);
            this.pnlHeader.Controls.Add(this.lblMaNVValue);

            // Summary
            this.pnlSummary.BackColor = Color.White;
            this.pnlSummary.BorderStyle = BorderStyle.FixedSingle;
            this.pnlSummary.Location = new Point(30, 140);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new Size(690, 300);

            this.lblSummaryTitle.AutoSize = true;
            this.lblSummaryTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblSummaryTitle.ForeColor = Color.FromArgb(24, 52, 88);
            this.lblSummaryTitle.Location = new Point(22, 18);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Text = "TỔNG KẾT CA";

            this.lblBatDau.AutoSize = true;
            this.lblBatDau.Font = new Font("Segoe UI", 10F);
            this.lblBatDau.ForeColor = Color.FromArgb(100, 110, 125);
            this.lblBatDau.Location = new Point(25, 70);
            this.lblBatDau.Name = "lblBatDau";
            this.lblBatDau.Text = "Bắt đầu ca";

            this.lblBatDauValue.AutoSize = true;
            this.lblBatDauValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblBatDauValue.ForeColor = Color.FromArgb(35, 45, 60);
            this.lblBatDauValue.Location = new Point(190, 68);
            this.lblBatDauValue.Name = "lblBatDauValue";
            this.lblBatDauValue.Text = "—";

            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Font = new Font("Segoe UI", 10F);
            this.lblThoiGian.ForeColor = Color.FromArgb(100, 110, 125);
            this.lblThoiGian.Location = new Point(25, 112);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Text = "Thời gian làm";

            this.lblThoiGianValue.AutoSize = true;
            this.lblThoiGianValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblThoiGianValue.ForeColor = Color.FromArgb(35, 45, 60);
            this.lblThoiGianValue.Location = new Point(190, 110);
            this.lblThoiGianValue.Name = "lblThoiGianValue";
            this.lblThoiGianValue.Text = "—";

            this.lblDoanhThu.AutoSize = true;
            this.lblDoanhThu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDoanhThu.ForeColor = Color.FromArgb(100, 110, 125);
            this.lblDoanhThu.Location = new Point(25, 165);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Text = "DOANH THU";

            this.lblDoanhThuValue.AutoSize = true;
            this.lblDoanhThuValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblDoanhThuValue.ForeColor = Color.FromArgb(20, 150, 85);
            this.lblDoanhThuValue.Location = new Point(190, 157);
            this.lblDoanhThuValue.Name = "lblDoanhThuValue";
            this.lblDoanhThuValue.Text = "0 đ";

            this.lblSoHoaDon.AutoSize = true;
            this.lblSoHoaDon.Font = new Font("Segoe UI", 10F);
            this.lblSoHoaDon.ForeColor = Color.FromArgb(100, 110, 125);
            this.lblSoHoaDon.Location = new Point(25, 220);
            this.lblSoHoaDon.Name = "lblSoHoaDon";
            this.lblSoHoaDon.Text = "Số hóa đơn";

            this.lblSoHoaDonValue.AutoSize = true;
            this.lblSoHoaDonValue.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblSoHoaDonValue.ForeColor = Color.FromArgb(35, 45, 60);
            this.lblSoHoaDonValue.Location = new Point(190, 218);
            this.lblSoHoaDonValue.Name = "lblSoHoaDonValue";
            this.lblSoHoaDonValue.Text = "0";

            this.lblDonCho.AutoSize = true;
            this.lblDonCho.Font = new Font("Segoe UI", 10F);
            this.lblDonCho.ForeColor = Color.FromArgb(100, 110, 125);
            this.lblDonCho.Location = new Point(360, 220);
            this.lblDonCho.Name = "lblDonCho";
            this.lblDonCho.Text = "Đơn online còn chờ";

            this.lblDonChoValue.AutoSize = true;
            this.lblDonChoValue.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblDonChoValue.ForeColor = Color.FromArgb(230, 130, 30);
            this.lblDonChoValue.Location = new Point(535, 218);
            this.lblDonChoValue.Name = "lblDonChoValue";
            this.lblDonChoValue.Text = "0";

            this.pnlSummary.Controls.Add(this.lblSummaryTitle);
            this.pnlSummary.Controls.Add(this.lblBatDau);
            this.pnlSummary.Controls.Add(this.lblBatDauValue);
            this.pnlSummary.Controls.Add(this.lblThoiGian);
            this.pnlSummary.Controls.Add(this.lblThoiGianValue);
            this.pnlSummary.Controls.Add(this.lblDoanhThu);
            this.pnlSummary.Controls.Add(this.lblDoanhThuValue);
            this.pnlSummary.Controls.Add(this.lblSoHoaDon);
            this.pnlSummary.Controls.Add(this.lblSoHoaDonValue);
            this.pnlSummary.Controls.Add(this.lblDonCho);
            this.pnlSummary.Controls.Add(this.lblDonChoValue);

            // Payment
            this.pnlPayment.BackColor = Color.White;
            this.pnlPayment.BorderStyle = BorderStyle.FixedSingle;
            this.pnlPayment.Location = new Point(740, 140);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Size = new Size(350, 300);

            this.lblPaymentTitle.AutoSize = true;
            this.lblPaymentTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblPaymentTitle.ForeColor = Color.FromArgb(24, 52, 88);
            this.lblPaymentTitle.Location = new Point(20, 18);
            this.lblPaymentTitle.Name = "lblPaymentTitle";
            this.lblPaymentTitle.Text = "DOANH THU THEO PHƯƠNG THỨC";

            this.lblTienMat.AutoSize = true;
            this.lblTienMat.Font = new Font("Segoe UI", 10F);
            this.lblTienMat.ForeColor = Color.FromArgb(100, 110, 125);
            this.lblTienMat.Location = new Point(22, 72);
            this.lblTienMat.Name = "lblTienMat";
            this.lblTienMat.Text = "Tiền mặt";

            this.lblTienMatValue.AutoSize = true;
            this.lblTienMatValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTienMatValue.ForeColor = Color.FromArgb(35, 45, 60);
            this.lblTienMatValue.Location = new Point(170, 70);
            this.lblTienMatValue.Name = "lblTienMatValue";
            this.lblTienMatValue.Text = "0 đ";

            this.lblThe.AutoSize = true;
            this.lblThe.Font = new Font("Segoe UI", 10F);
            this.lblThe.ForeColor = Color.FromArgb(100, 110, 125);
            this.lblThe.Location = new Point(22, 116);
            this.lblThe.Name = "lblThe";
            this.lblThe.Text = "Thẻ";

            this.lblTheValue.AutoSize = true;
            this.lblTheValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTheValue.ForeColor = Color.FromArgb(35, 45, 60);
            this.lblTheValue.Location = new Point(170, 114);
            this.lblTheValue.Name = "lblTheValue";
            this.lblTheValue.Text = "0 đ";

            this.lblChuyenKhoan.AutoSize = true;
            this.lblChuyenKhoan.Font = new Font("Segoe UI", 10F);
            this.lblChuyenKhoan.ForeColor = Color.FromArgb(100, 110, 125);
            this.lblChuyenKhoan.Location = new Point(22, 160);
            this.lblChuyenKhoan.Name = "lblChuyenKhoan";
            this.lblChuyenKhoan.Text = "Chuyển khoản";

            this.lblChuyenKhoanValue.AutoSize = true;
            this.lblChuyenKhoanValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblChuyenKhoanValue.ForeColor = Color.FromArgb(35, 45, 60);
            this.lblChuyenKhoanValue.Location = new Point(170, 158);
            this.lblChuyenKhoanValue.Name = "lblChuyenKhoanValue";
            this.lblChuyenKhoanValue.Text = "0 đ";

            this.lblVi.AutoSize = true;
            this.lblVi.Font = new Font("Segoe UI", 10F);
            this.lblVi.ForeColor = Color.FromArgb(100, 110, 125);
            this.lblVi.Location = new Point(22, 204);
            this.lblVi.Name = "lblVi";
            this.lblVi.Text = "Ví điện tử";

            this.lblViValue.AutoSize = true;
            this.lblViValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblViValue.ForeColor = Color.FromArgb(35, 45, 60);
            this.lblViValue.Location = new Point(170, 202);
            this.lblViValue.Name = "lblViValue";
            this.lblViValue.Text = "0 đ";

            this.pnlPayment.Controls.Add(this.lblPaymentTitle);
            this.pnlPayment.Controls.Add(this.lblTienMat);
            this.pnlPayment.Controls.Add(this.lblTienMatValue);
            this.pnlPayment.Controls.Add(this.lblThe);
            this.pnlPayment.Controls.Add(this.lblTheValue);
            this.pnlPayment.Controls.Add(this.lblChuyenKhoan);
            this.pnlPayment.Controls.Add(this.lblChuyenKhoanValue);
            this.pnlPayment.Controls.Add(this.lblVi);
            this.pnlPayment.Controls.Add(this.lblViValue);

            // Warning
            this.pnlWarning.BackColor = Color.FromArgb(255, 248, 230);
            this.pnlWarning.BorderStyle = BorderStyle.FixedSingle;
            this.pnlWarning.Location = new Point(30, 460);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new Size(1060, 72);

            this.lblWarning.AutoSize = false;
            this.lblWarning.Font = new Font("Segoe UI", 10F);
            this.lblWarning.ForeColor = Color.FromArgb(135, 92, 15);
            this.lblWarning.Location = new Point(18, 14);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new Size(1015, 44);
            this.lblWarning.Text =
                "LƯU Ý  •  Sau khi chuyển ca, ca hiện tại sẽ được đóng. " +
                "Màn hình bán hàng sẽ bị khóa và nhân viên tiếp theo phải đăng nhập để mở ca mới.";

            this.pnlWarning.Controls.Add(this.lblWarning);

            // Confirm
            this.chkXacNhan.AutoSize = false;
            this.chkXacNhan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.chkXacNhan.ForeColor = Color.FromArgb(45, 55, 70);
            this.chkXacNhan.Location = new Point(35, 555);
            this.chkXacNhan.Name = "chkXacNhan";
            this.chkXacNhan.Size = new Size(700, 35);
            this.chkXacNhan.Text = "Tôi đã kiểm tra và xác nhận tổng kết ca hiện tại.";
            this.chkXacNhan.CheckedChanged += new EventHandler(this.chkXacNhan_CheckedChanged);

            // Close
            this.btnDong.BackColor = Color.White;
            this.btnDong.FlatAppearance.BorderColor = Color.FromArgb(190, 198, 208);
            this.btnDong.FlatAppearance.BorderSize = 1;
            this.btnDong.FlatStyle = FlatStyle.Flat;
            this.btnDong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDong.ForeColor = Color.FromArgb(65, 75, 90);
            this.btnDong.Location = new Point(690, 620);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new Size(160, 48);
            this.btnDong.Text = "QUAY LẠI";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new EventHandler(this.btnDong_Click);

            // Change shift
            this.btnChuyenCa.BackColor = Color.FromArgb(20, 150, 85);
            this.btnChuyenCa.FlatAppearance.BorderSize = 0;
            this.btnChuyenCa.FlatStyle = FlatStyle.Flat;
            this.btnChuyenCa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnChuyenCa.ForeColor = Color.White;
            this.btnChuyenCa.Location = new Point(865, 620);
            this.btnChuyenCa.Name = "btnChuyenCa";
            this.btnChuyenCa.Size = new Size(225, 48);
            this.btnChuyenCa.Text = "XÁC NHẬN CHUYỂN CA";
            this.btnChuyenCa.UseVisualStyleBackColor = false;
            this.btnChuyenCa.Enabled = false;
            this.btnChuyenCa.Click += new EventHandler(this.btnChuyenCa_Click);

            // Add controls
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlPayment);
            this.Controls.Add(this.pnlWarning);
            this.Controls.Add(this.chkXacNhan);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnChuyenCa);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

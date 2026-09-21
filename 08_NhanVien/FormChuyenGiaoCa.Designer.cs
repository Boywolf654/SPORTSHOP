using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP
{
    partial class FormChuyenGiaoCa
    {
        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblCa;
        private Label lblNhanVien;
        private Label lblMaNV;

        private Panel panelTongKet;
        private Label lblTongKetTitle;
        private Label lblBatDauTitle;
        private Label lblKetThucTitle;
        private Label lblThoiGianTitle;
        private Label lblDoanhThuTitle;
        private Label lblSoHoaDonTitle;
        private Label lblChoTitle;
        private Label lblBatDau;
        private Label lblKetThucDuKien;
        private Label lblThoiGian;
        private Label lblDoanhThu;
        private Label lblSoHoaDon;
        private Label lblCho;

        private Panel panelThanhToan;
        private Label lblThanhToanTitle;
        private Label lblTienMatTitle;
        private Label lblTheTitle;
        private Label lblChuyenKhoanTitle;
        private Label lblViTitle;
        private Label lblTienMat;
        private Label lblThe;
        private Label lblChuyenKhoan;
        private Label lblVi;
        private Label lblTrangThai;

        private Panel panelLuuY;
        private Label lblLuuY;
        private CheckBox chkXacNhan;
        private Button btnQuayLai;
        private Button btnChotCa;

        private void InitializeComponent()
        {
            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.lblCa = new Label();
            this.lblNhanVien = new Label();
            this.lblMaNV = new Label();

            this.panelTongKet = new Panel();
            this.lblTongKetTitle = new Label();
            this.lblBatDauTitle = new Label();
            this.lblKetThucTitle = new Label();
            this.lblThoiGianTitle = new Label();
            this.lblDoanhThuTitle = new Label();
            this.lblSoHoaDonTitle = new Label();
            this.lblChoTitle = new Label();
            this.lblBatDau = new Label();
            this.lblKetThucDuKien = new Label();
            this.lblThoiGian = new Label();
            this.lblDoanhThu = new Label();
            this.lblSoHoaDon = new Label();
            this.lblCho = new Label();

            this.panelThanhToan = new Panel();
            this.lblThanhToanTitle = new Label();
            this.lblTienMatTitle = new Label();
            this.lblTheTitle = new Label();
            this.lblChuyenKhoanTitle = new Label();
            this.lblViTitle = new Label();
            this.lblTienMat = new Label();
            this.lblThe = new Label();
            this.lblChuyenKhoan = new Label();
            this.lblVi = new Label();
            this.lblTrangThai = new Label();

            this.panelLuuY = new Panel();
            this.lblLuuY = new Label();
            this.chkXacNhan = new CheckBox();
            this.btnQuayLai = new Button();
            this.btnChotCa = new Button();

            this.SuspendLayout();

            // FORM
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(242, 246, 251);
            this.ClientSize = new Size(1180, 780);
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChuyenGiaoCa";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "SPORTSHOP - Chuyển giao ca";
            this.Load += new System.EventHandler(this.FormChuyenGiaoCa_Load);
            this.FormClosed += new FormClosedEventHandler(this.FormChuyenGiaoCa_FormClosed);

            // HEADER
            this.panelHeader.BackColor = Color.FromArgb(25, 54, 92);
            this.panelHeader.Location = new Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(1180, 145);
            this.panelHeader.TabIndex = 0;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(35, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(273, 46);
            this.lblTitle.Text = "CHUYỂN GIAO CA";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = Color.FromArgb(215, 226, 240);
            this.lblSubtitle.Location = new Point(38, 79);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new Size(368, 20);
            this.lblSubtitle.Text = "Tổng kết doanh thu và kết thúc ca làm việc hiện tại";

            this.lblCa.AutoSize = true;
            this.lblCa.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblCa.ForeColor = Color.White;
            this.lblCa.Location = new Point(820, 24);
            this.lblCa.Name = "lblCa";
            this.lblCa.Text = "CA —";

            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblNhanVien.ForeColor = Color.White;
            this.lblNhanVien.Location = new Point(822, 70);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Text = "Nhân viên";

            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Font = new Font("Segoe UI", 10F);
            this.lblMaNV.ForeColor = Color.FromArgb(210, 222, 237);
            this.lblMaNV.Location = new Point(822, 100);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Text = "MÃ NV —";

            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelHeader.Controls.Add(this.lblCa);
            this.panelHeader.Controls.Add(this.lblNhanVien);
            this.panelHeader.Controls.Add(this.lblMaNV);

            // TỔNG KẾT
            this.panelTongKet.BackColor = Color.White;
            this.panelTongKet.BorderStyle = BorderStyle.FixedSingle;
            this.panelTongKet.Location = new Point(35, 170);
            this.panelTongKet.Name = "panelTongKet";
            this.panelTongKet.Size = new Size(690, 355);
            this.panelTongKet.TabIndex = 1;

            this.lblTongKetTitle.AutoSize = true;
            this.lblTongKetTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTongKetTitle.ForeColor = Color.FromArgb(25, 54, 92);
            this.lblTongKetTitle.Location = new Point(28, 22);
            this.lblTongKetTitle.Text = "TỔNG KẾT CA";

            this.lblBatDauTitle.AutoSize = true;
            this.lblBatDauTitle.ForeColor = Color.FromArgb(85, 105, 130);
            this.lblBatDauTitle.Location = new Point(30, 70);
            this.lblBatDauTitle.Text = "Bắt đầu ca";

            this.lblKetThucTitle.AutoSize = true;
            this.lblKetThucTitle.ForeColor = Color.FromArgb(85, 105, 130);
            this.lblKetThucTitle.Location = new Point(30, 108);
            this.lblKetThucTitle.Text = "Kết thúc dự kiến";

            this.lblThoiGianTitle.AutoSize = true;
            this.lblThoiGianTitle.ForeColor = Color.FromArgb(85, 105, 130);
            this.lblThoiGianTitle.Location = new Point(30, 146);
            this.lblThoiGianTitle.Text = "Thời gian làm";

            this.lblDoanhThuTitle.AutoSize = true;
            this.lblDoanhThuTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblDoanhThuTitle.ForeColor = Color.FromArgb(25, 54, 92);
            this.lblDoanhThuTitle.Location = new Point(30, 195);
            this.lblDoanhThuTitle.Text = "DOANH THU";

            this.lblSoHoaDonTitle.AutoSize = true;
            this.lblSoHoaDonTitle.ForeColor = Color.FromArgb(85, 105, 130);
            this.lblSoHoaDonTitle.Location = new Point(30, 250);
            this.lblSoHoaDonTitle.Text = "Số hóa đơn";

            this.lblChoTitle.AutoSize = true;
            this.lblChoTitle.ForeColor = Color.FromArgb(85, 105, 130);
            this.lblChoTitle.Location = new Point(30, 288);
            this.lblChoTitle.Text = "Đơn online còn chờ";

            this.lblBatDau.AutoSize = true;
            this.lblBatDau.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblBatDau.Location = new Point(230, 67);
            this.lblBatDau.Text = "—";

            this.lblKetThucDuKien.AutoSize = true;
            this.lblKetThucDuKien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblKetThucDuKien.Location = new Point(230, 105);
            this.lblKetThucDuKien.Text = "Không cố định";

            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblThoiGian.Location = new Point(230, 143);
            this.lblThoiGian.Text = "—";

            this.lblDoanhThu.AutoSize = true;
            this.lblDoanhThu.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblDoanhThu.ForeColor = Color.FromArgb(20, 160, 78);
            this.lblDoanhThu.Location = new Point(230, 185);
            this.lblDoanhThu.Text = "0 đ";

            this.lblSoHoaDon.AutoSize = true;
            this.lblSoHoaDon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblSoHoaDon.Location = new Point(230, 247);
            this.lblSoHoaDon.Text = "0";

            this.lblCho.AutoSize = true;
            this.lblCho.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCho.Location = new Point(230, 285);
            this.lblCho.Text = "0";

            this.panelTongKet.Controls.Add(this.lblTongKetTitle);
            this.panelTongKet.Controls.Add(this.lblBatDauTitle);
            this.panelTongKet.Controls.Add(this.lblKetThucTitle);
            this.panelTongKet.Controls.Add(this.lblThoiGianTitle);
            this.panelTongKet.Controls.Add(this.lblDoanhThuTitle);
            this.panelTongKet.Controls.Add(this.lblSoHoaDonTitle);
            this.panelTongKet.Controls.Add(this.lblChoTitle);
            this.panelTongKet.Controls.Add(this.lblBatDau);
            this.panelTongKet.Controls.Add(this.lblKetThucDuKien);
            this.panelTongKet.Controls.Add(this.lblThoiGian);
            this.panelTongKet.Controls.Add(this.lblDoanhThu);
            this.panelTongKet.Controls.Add(this.lblSoHoaDon);
            this.panelTongKet.Controls.Add(this.lblCho);

            // THANH TOÁN
            this.panelThanhToan.BackColor = Color.White;
            this.panelThanhToan.BorderStyle = BorderStyle.FixedSingle;
            this.panelThanhToan.Location = new Point(750, 170);
            this.panelThanhToan.Name = "panelThanhToan";
            this.panelThanhToan.Size = new Size(395, 355);
            this.panelThanhToan.TabIndex = 2;

            this.lblThanhToanTitle.AutoSize = true;
            this.lblThanhToanTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblThanhToanTitle.ForeColor = Color.FromArgb(25, 54, 92);
            this.lblThanhToanTitle.Location = new Point(25, 22);
            this.lblThanhToanTitle.Text = "DOANH THU THEO PHƯƠNG THỨC";

            this.lblTienMatTitle.AutoSize = true;
            this.lblTienMatTitle.ForeColor = Color.FromArgb(85, 105, 130);
            this.lblTienMatTitle.Location = new Point(25, 75);
            this.lblTienMatTitle.Text = "Tiền mặt";
            this.lblTienMat.Location = new Point(210, 72);
            this.lblTienMat.AutoSize = true;
            this.lblTienMat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTienMat.Text = "0 đ";

            this.lblTheTitle.AutoSize = true;
            this.lblTheTitle.ForeColor = Color.FromArgb(85, 105, 130);
            this.lblTheTitle.Location = new Point(25, 118);
            this.lblTheTitle.Text = "Thẻ";
            this.lblThe.Location = new Point(210, 115);
            this.lblThe.AutoSize = true;
            this.lblThe.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblThe.Text = "0 đ";

            this.lblChuyenKhoanTitle.AutoSize = true;
            this.lblChuyenKhoanTitle.ForeColor = Color.FromArgb(85, 105, 130);
            this.lblChuyenKhoanTitle.Location = new Point(25, 161);
            this.lblChuyenKhoanTitle.Text = "Chuyển khoản";
            this.lblChuyenKhoan.Location = new Point(210, 158);
            this.lblChuyenKhoan.AutoSize = true;
            this.lblChuyenKhoan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblChuyenKhoan.Text = "0 đ";

            this.lblViTitle.AutoSize = true;
            this.lblViTitle.ForeColor = Color.FromArgb(85, 105, 130);
            this.lblViTitle.Location = new Point(25, 204);
            this.lblViTitle.Text = "Ví điện tử";
            this.lblVi.Location = new Point(210, 201);
            this.lblVi.AutoSize = true;
            this.lblVi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblVi.Text = "0 đ";

            this.lblTrangThai.AutoSize = false;
            this.lblTrangThai.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblTrangThai.ForeColor = Color.FromArgb(190, 80, 20);
            this.lblTrangThai.Location = new Point(25, 263);
            this.lblTrangThai.Size = new Size(345, 55);
            this.lblTrangThai.Text = "Đang kiểm tra trạng thái ca...";

            this.panelThanhToan.Controls.Add(this.lblThanhToanTitle);
            this.panelThanhToan.Controls.Add(this.lblTienMatTitle);
            this.panelThanhToan.Controls.Add(this.lblTheTitle);
            this.panelThanhToan.Controls.Add(this.lblChuyenKhoanTitle);
            this.panelThanhToan.Controls.Add(this.lblViTitle);
            this.panelThanhToan.Controls.Add(this.lblTienMat);
            this.panelThanhToan.Controls.Add(this.lblThe);
            this.panelThanhToan.Controls.Add(this.lblChuyenKhoan);
            this.panelThanhToan.Controls.Add(this.lblVi);
            this.panelThanhToan.Controls.Add(this.lblTrangThai);

            // LƯU Ý
            this.panelLuuY.BackColor = Color.FromArgb(255, 249, 229);
            this.panelLuuY.BorderStyle = BorderStyle.FixedSingle;
            this.panelLuuY.Location = new Point(35, 535);
            this.panelLuuY.Name = "panelLuuY";
            this.panelLuuY.Size = new Size(1110, 95);
            this.panelLuuY.TabIndex = 3;

            this.lblLuuY.AutoSize = false;
            this.lblLuuY.Font = new Font("Segoe UI", 9.5F);
            this.lblLuuY.ForeColor = Color.FromArgb(155, 103, 18);
            this.lblLuuY.Location = new Point(20, 13);
            this.lblLuuY.Size = new Size(1060, 68);
            this.lblLuuY.Text = "LƯU Ý  •  Ca làm việc linh hoạt, không cố định 3 ca và không giới hạn giờ chuyển ca.\r\n" +
     "Khi xác nhận chuyển giao, ca hiện tại được chốt theo thời gian thực tế và một ca mới được mở ngay.";
            this.panelLuuY.Controls.Add(this.lblLuuY);
            // XÁC NHẬN
            this.chkXacNhan.AutoSize = true;
            this.chkXacNhan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.chkXacNhan.Location = new Point(38, 640);
            this.chkXacNhan.Name = "chkXacNhan";
            this.chkXacNhan.Size = new Size(367, 23);
            this.chkXacNhan.Text = "Tôi đã kiểm tra và xác nhận tổng kết ca hiện tại.";
            this.chkXacNhan.UseVisualStyleBackColor = true;
            this.chkXacNhan.CheckedChanged += new System.EventHandler(this.chkXacNhan_CheckedChanged);

            // QUAY LẠI
            this.btnQuayLai.BackColor = Color.White;
            this.btnQuayLai.FlatAppearance.BorderColor = Color.FromArgb(25, 54, 92);
            this.btnQuayLai.FlatStyle = FlatStyle.Flat;
            this.btnQuayLai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnQuayLai.ForeColor = Color.FromArgb(25, 54, 92);
            this.btnQuayLai.Location = new Point(745, 635);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new Size(180, 48);
            this.btnQuayLai.Text = "QUAY LẠI";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);

            // CHỐT CA
            this.btnChotCa.BackColor = Color.FromArgb(20, 145, 75);
            this.btnChotCa.FlatAppearance.BorderSize = 0;
            this.btnChotCa.FlatStyle = FlatStyle.Flat;
            this.btnChotCa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnChotCa.ForeColor = Color.White;
            this.btnChotCa.Location = new Point(940, 635);
            this.btnChotCa.Name = "btnChotCa";
            this.btnChotCa.Size = new Size(205, 48);
            this.btnChotCa.Text = "✓  XÁC NHẬN CHỐT CA";
            this.btnChotCa.UseVisualStyleBackColor = false;
            this.btnChotCa.Enabled = false;
            this.btnChotCa.Click += new System.EventHandler(this.BtnChotCa_Click);

            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelTongKet);
            this.Controls.Add(this.panelThanhToan);
            this.Controls.Add(this.panelLuuY);
            this.Controls.Add(this.chkXacNhan);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.btnChotCa);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

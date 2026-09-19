using System.Windows.Forms;

namespace SPORTSHOP
{
    partial class FormTaoKhuyenMai
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cmbLoai;
        private System.Windows.Forms.Label lblGiaTri;
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.Label lblDonVi;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtSoLuongToiThieu;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private System.Windows.Forms.DateTimePicker dtpKetThuc;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Panel pnlSanPham;
        private System.Windows.Forms.Label lblSPTitle;
        private System.Windows.Forms.TextBox txtTimSanPham;
        private System.Windows.Forms.CheckBox chkChonTatCa;
        private System.Windows.Forms.Label lblDaChon;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenThuongHieu;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cmbLoai = new System.Windows.Forms.ComboBox();
            this.lblGiaTri = new System.Windows.Forms.Label();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.lblDonVi = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuongToiThieu = new System.Windows.Forms.TextBox();
            this.lblNgay = new System.Windows.Forms.Label();
            this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtpKetThuc = new System.Windows.Forms.DateTimePicker();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.pnlSanPham = new System.Windows.Forms.Panel();
            this.lblSPTitle = new System.Windows.Forms.Label();
            this.txtTimSanPham = new System.Windows.Forms.TextBox();
            this.chkChonTatCa = new System.Windows.Forms.CheckBox();
            this.lblDaChon = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.Chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenThuongHieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblPreview = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlThongTin.SuspendLayout();
            this.pnlSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(1180, 790);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo chương trình khuyến mãi";

            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 92;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(28, 14);
            this.lblTitle.Text = "🔥  TẠO CHƯƠNG TRÌNH KHUYẾN MÃI";

            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSubTitle.Location = new System.Drawing.Point(31, 55);
            this.lblSubTitle.Text = "Thiết lập điều kiện, thời gian và sản phẩm áp dụng";

            this.pnlThongTin.BackColor = System.Drawing.Color.White;
            this.pnlThongTin.Location = new System.Drawing.Point(20, 110);
            this.pnlThongTin.Size = new System.Drawing.Size(515, 525);
            this.pnlThongTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.pnlThongTin.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTen,this.txtTen,this.lblMoTa,this.txtMoTa,this.lblLoai,this.cmbLoai,
                this.lblGiaTri,this.txtGiaTri,this.lblDonVi,this.lblSoLuong,this.txtSoLuongToiThieu,
                this.lblNgay,this.dtpBatDau,this.dtpKetThuc,this.lblThoiGian
            });

            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTen.Location = new System.Drawing.Point(22, 22);
            this.lblTen.Text = "Tên chương trình *";

            this.txtTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTen.Location = new System.Drawing.Point(22, 49);
            this.txtTen.Size = new System.Drawing.Size(465, 25);

            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMoTa.Location = new System.Drawing.Point(22, 88);
            this.lblMoTa.Text = "Mô tả";

            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMoTa.Location = new System.Drawing.Point(22, 115);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoTa.Size = new System.Drawing.Size(465, 75);

            this.lblLoai.AutoSize = true;
            this.lblLoai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLoai.Location = new System.Drawing.Point(22, 207);
            this.lblLoai.Text = "Loại giảm";

            this.cmbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbLoai.Location = new System.Drawing.Point(22, 234);
            this.cmbLoai.Size = new System.Drawing.Size(210, 25);

            this.lblGiaTri.AutoSize = true;
            this.lblGiaTri.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGiaTri.Location = new System.Drawing.Point(255, 207);
            this.lblGiaTri.Text = "Giá trị";

            this.txtGiaTri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGiaTri.Location = new System.Drawing.Point(255, 234);
            this.txtGiaTri.Size = new System.Drawing.Size(170, 25);

            this.lblDonVi.AutoSize = true;
            this.lblDonVi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDonVi.Location = new System.Drawing.Point(432, 238);
            this.lblDonVi.Text = "%";

            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoLuong.Location = new System.Drawing.Point(22, 286);
            this.lblSoLuong.Text = "Số lượng tối thiểu";

            this.txtSoLuongToiThieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoLuongToiThieu.Location = new System.Drawing.Point(22, 313);
            this.txtSoLuongToiThieu.Size = new System.Drawing.Size(210, 25);

            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNgay.Location = new System.Drawing.Point(22, 365);
            this.lblNgay.Text = "Thời gian áp dụng";

            this.dtpBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBatDau.Location = new System.Drawing.Point(22, 395);
            this.dtpBatDau.Size = new System.Drawing.Size(180, 23);

            this.dtpKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpKetThuc.Location = new System.Drawing.Point(220, 395);
            this.dtpKetThuc.Size = new System.Drawing.Size(180, 23);

            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThoiGian.ForeColor = System.Drawing.Color.DimGray;
            this.lblThoiGian.Location = new System.Drawing.Point(22, 433);
            this.lblThoiGian.Text = "📅";

            this.pnlSanPham.BackColor = System.Drawing.Color.White;
            this.pnlSanPham.Location = new System.Drawing.Point(555, 110);
            this.pnlSanPham.Size = new System.Drawing.Size(605, 525);
            this.pnlSanPham.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblSPTitle.AutoSize = true;
            this.lblSPTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSPTitle.Location = new System.Drawing.Point(18, 17);
            this.lblSPTitle.Text = "🛍 SẢN PHẨM ÁP DỤNG";
            this.pnlSanPham.Controls.Add(this.lblSPTitle);
            this.pnlSanPham.Controls.Add(this.txtTimSanPham);
            this.pnlSanPham.Controls.Add(this.chkChonTatCa);
            this.pnlSanPham.Controls.Add(this.lblDaChon);
            this.pnlSanPham.Controls.Add(this.dgvSanPham);

            this.txtTimSanPham.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimSanPham.Location = new System.Drawing.Point(20, 55);
            this.txtTimSanPham.Size = new System.Drawing.Size(360, 25);

            this.chkChonTatCa.AutoSize = true;
            this.chkChonTatCa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkChonTatCa.Location = new System.Drawing.Point(395, 59);
            this.chkChonTatCa.Text = "Chọn tất cả";

            this.lblDaChon.AutoSize = true;
            this.lblDaChon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDaChon.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblDaChon.Location = new System.Drawing.Point(20, 88);
            this.lblDaChon.Text = "Đã chọn: 0 sản phẩm";

            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.AllowUserToResizeRows = false;
            this.dgvSanPham.AutoGenerateColumns = false;
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSanPham.ColumnHeadersHeight = 38;
            this.dgvSanPham.Location = new System.Drawing.Point(20, 120);
            this.dgvSanPham.MultiSelect = false;
            this.dgvSanPham.RowHeadersVisible = false;
            this.dgvSanPham.RowTemplate.Height = 35;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(560, 380);
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.Chon,this.MaSP,this.TenSP,this.TenDanhMuc,this.TenThuongHieu
            });
           
          
            this.Chon.HeaderText = "✓";
            this.Chon.Name = "Chon";
            this.Chon.Width = 42;

            this.MaSP.HeaderText = "Mã SP";
            this.MaSP.Name = "MaSP";
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.Visible = false;

            this.TenSP.HeaderText = "Tên sản phẩm";
            this.TenSP.Name = "TenSP";
            this.TenSP.DataPropertyName = "TenSP";
            this.TenSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            this.TenDanhMuc.HeaderText = "Danh mục";
            this.TenDanhMuc.Name = "TenDanhMuc";
            this.TenDanhMuc.DataPropertyName = "TenDanhMuc";
            this.TenDanhMuc.Width = 100;

            this.TenThuongHieu.HeaderText = "Thương hiệu";
            this.TenThuongHieu.Name = "TenThuongHieu";
            this.TenThuongHieu.DataPropertyName = "TenThuongHieu";
            this.TenThuongHieu.Width = 110;

            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Location = new System.Drawing.Point(20, 655);
            this.pnlBottom.Size = new System.Drawing.Size(1140, 110);
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.lblPreview);
            this.pnlBottom.Controls.Add(this.btnHuy);
            this.pnlBottom.Controls.Add(this.btnLuu);

            this.lblPreview.AutoSize = false;
            this.lblPreview.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPreview.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblPreview.Location = new System.Drawing.Point(20, 22);
            this.lblPreview.Size = new System.Drawing.Size(650, 55);
            this.lblPreview.Text = "💡 Xem trước: Mua tối thiểu 1 sản phẩm → giảm 0%";

            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(820, 26);
            this.btnHuy.Size = new System.Drawing.Size(130, 48);
            this.btnHuy.Text = "HỦY";
            this.btnHuy.UseVisualStyleBackColor = false;

            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(965, 26);
            this.btnLuu.Size = new System.Drawing.Size(150, 48);
            this.btnLuu.Text = "🔥 TẠO KHUYẾN MÃI";
            this.btnLuu.UseVisualStyleBackColor = false;

            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlSanPham);
            this.Controls.Add(this.pnlThongTin);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            this.pnlSanPham.ResumeLayout(false);
            this.pnlSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}

namespace SPORTSHOP._06_BanHang
{
    partial class themcoupon
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTieuDe, lblHuongDan;
        private Guna.UI2.WinForms.Guna2TextBox txt_macoupon, txt_ten, txt_giatri, txt_dontoithieu, txt_soluong;
        private Guna.UI2.WinForms.Guna2ComboBox txt_loai;
        private Guna.UI2.WinForms.Guna2DateTimePicker dt_ngaybatdau, dt_ketthuc;
        private Guna.UI2.WinForms.Guna2Button btn_them, btn_huy;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTieuDe = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblHuongDan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txt_macoupon = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_ten = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_loai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txt_giatri = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_dontoithieu = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_soluong = new Guna.UI2.WinForms.Guna2TextBox();
            this.dt_ngaybatdau = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dt_ketthuc = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btn_them = new Guna.UI2.WinForms.Guna2Button();
            this.btn_huy = new Guna.UI2.WinForms.Guna2Button();

            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(650, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo Voucher";

            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 105;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(24, 32, 47);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.lblHuongDan);

            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Location = new System.Drawing.Point(28, 17);
            this.lblTieuDe.Text = "🎟  TẠO VOUCHER";

            this.lblHuongDan.BackColor = System.Drawing.Color.Transparent;
            this.lblHuongDan.ForeColor = System.Drawing.Color.LightGray;
            this.lblHuongDan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHuongDan.Location = new System.Drawing.Point(31, 57);
            this.lblHuongDan.Text = "Tạo mã giảm giá mới cho khách hàng";

            this.txt_macoupon.Location = new System.Drawing.Point(35, 145); this.txt_macoupon.Size = new System.Drawing.Size(270, 38); this.txt_macoupon.BorderRadius = 8; this.txt_macoupon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txt_ten.Location = new System.Drawing.Point(345, 145); this.txt_ten.Size = new System.Drawing.Size(270, 38); this.txt_ten.BorderRadius = 8; this.txt_ten.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txt_loai.Location = new System.Drawing.Point(35, 225); this.txt_loai.Size = new System.Drawing.Size(270, 38); this.txt_loai.BorderRadius = 8; this.txt_loai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txt_giatri.Location = new System.Drawing.Point(345, 225); this.txt_giatri.Size = new System.Drawing.Size(270, 38); this.txt_giatri.BorderRadius = 8; this.txt_giatri.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txt_dontoithieu.Location = new System.Drawing.Point(35, 305); this.txt_dontoithieu.Size = new System.Drawing.Size(270, 38); this.txt_dontoithieu.BorderRadius = 8; this.txt_dontoithieu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txt_soluong.Location = new System.Drawing.Point(345, 305); this.txt_soluong.Size = new System.Drawing.Size(270, 38); this.txt_soluong.BorderRadius = 8; this.txt_soluong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dt_ngaybatdau.Location = new System.Drawing.Point(35, 385); this.dt_ngaybatdau.Size = new System.Drawing.Size(270, 38); this.dt_ngaybatdau.BorderRadius = 8; this.dt_ngaybatdau.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dt_ketthuc.Location = new System.Drawing.Point(345, 385); this.dt_ketthuc.Size = new System.Drawing.Size(270, 38); this.dt_ketthuc.BorderRadius = 8; this.dt_ketthuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            var l1 = new System.Windows.Forms.Label() { Text = "Mã voucher", AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(55, 65, 81), Location = new System.Drawing.Point(35, 122) };
            var l2 = new System.Windows.Forms.Label() { Text = "Tên chương trình", AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(55, 65, 81), Location = new System.Drawing.Point(345, 122) };
            var l3 = new System.Windows.Forms.Label() { Text = "Loại giảm", AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(55, 65, 81), Location = new System.Drawing.Point(35, 202) };
            var l4 = new System.Windows.Forms.Label() { Text = "Giá trị giảm", AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(55, 65, 81), Location = new System.Drawing.Point(345, 202) };
            var l5 = new System.Windows.Forms.Label() { Text = "Đơn tối thiểu", AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(55, 65, 81), Location = new System.Drawing.Point(35, 282) };
            var l6 = new System.Windows.Forms.Label() { Text = "Số lượt sử dụng", AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(55, 65, 81), Location = new System.Drawing.Point(345, 282) };
            var l7 = new System.Windows.Forms.Label() { Text = "Ngày bắt đầu", AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(55, 65, 81), Location = new System.Drawing.Point(35, 362) };
            var l8 = new System.Windows.Forms.Label() { Text = "Ngày kết thúc", AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(55, 65, 81), Location = new System.Drawing.Point(345, 362) };
            this.Controls.Add(l1); this.Controls.Add(l2); this.Controls.Add(l3); this.Controls.Add(l4); this.Controls.Add(l5); this.Controls.Add(l6); this.Controls.Add(l7); this.Controls.Add(l8);
            this.Controls.Add(this.txt_macoupon); this.Controls.Add(this.txt_ten); this.Controls.Add(this.txt_loai); this.Controls.Add(this.txt_giatri); this.Controls.Add(this.txt_dontoithieu); this.Controls.Add(this.txt_soluong); this.Controls.Add(this.dt_ngaybatdau); this.Controls.Add(this.dt_ketthuc);

            this.btn_them.Location = new System.Drawing.Point(35, 500);
            this.btn_them.Size = new System.Drawing.Size(270, 42);
            this.btn_them.Text = "✓  TẠO VOUCHER";
            this.btn_them.FillColor = System.Drawing.Color.FromArgb(46, 180, 126);
            this.btn_them.ForeColor = System.Drawing.Color.White;
            this.btn_them.BorderRadius = 9;
            this.btn_them.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);

            this.btn_huy.Location = new System.Drawing.Point(345, 500);
            this.btn_huy.Size = new System.Drawing.Size(270, 42);
            this.btn_huy.Text = "HỦY";
            this.btn_huy.FillColor = System.Drawing.Color.FromArgb(90, 100, 115);
            this.btn_huy.ForeColor = System.Drawing.Color.White;
            this.btn_huy.BorderRadius = 9;
            this.btn_huy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);

            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.btn_huy);
            this.pnlHeader.BringToFront();
        }

    }
}
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP
{
    partial class DieuChuyenKho
    {
        private Label lblTieuDe;
        private Label lblPhuDe;
        private Label lblKhoXuat;
        private Label lblKhoNhap;
        private Label lblBienThe;
        private Label lblSoLuong;
        private Label lblTon;
        private Label lblLyDo;
        private Label lblHuongDan;

        private ComboBox cmbKhoXuat;
        private ComboBox cmbKhoNhap;
        private ComboBox cmbBienThe;
        private NumericUpDown nudSoLuong;
        private TextBox txtLyDo;

        private Button btnChuyen;
        private Button btnDong;

        private Panel header;
        private Panel card;
        private Panel footer;
        private Panel panelSoLuong;
        private TableLayoutPanel layout;

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblPhuDe = new System.Windows.Forms.Label();
            this.lblKhoXuat = new System.Windows.Forms.Label();
            this.lblKhoNhap = new System.Windows.Forms.Label();
            this.lblBienThe = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblTon = new System.Windows.Forms.Label();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.cmbKhoXuat = new System.Windows.Forms.ComboBox();
            this.cmbKhoNhap = new System.Windows.Forms.ComboBox();
            this.cmbBienThe = new System.Windows.Forms.ComboBox();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.btnChuyen = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Panel();
            this.card = new System.Windows.Forms.Panel();
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.panelSoLuong = new System.Windows.Forms.Panel();
            this.footer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.header.SuspendLayout();
            this.card.SuspendLayout();
            this.layout.SuspendLayout();
            this.panelSoLuong.SuspendLayout();
            this.footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(32, 16);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(506, 45);
            this.lblTieuDe.TabIndex = 1;
            this.lblTieuDe.Text = "ĐIỀU CHUYỂN HÀNG GIỮA KHO";
            // 
            // lblPhuDe
            // 
            this.lblPhuDe.AutoSize = true;
            this.lblPhuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblPhuDe.Location = new System.Drawing.Point(35, 59);
            this.lblPhuDe.Name = "lblPhuDe";
            this.lblPhuDe.Size = new System.Drawing.Size(294, 21);
            this.lblPhuDe.TabIndex = 0;
            this.lblPhuDe.Text = "Chuyển tồn giữa các kho đang hoạt động";
            // 
            // lblKhoXuat
            // 
            this.lblKhoXuat.AutoSize = true;
            this.lblKhoXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKhoXuat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKhoXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblKhoXuat.Location = new System.Drawing.Point(3, 0);
            this.lblKhoXuat.Name = "lblKhoXuat";
            this.lblKhoXuat.Size = new System.Drawing.Size(211, 62);
            this.lblKhoXuat.TabIndex = 0;
            this.lblKhoXuat.Text = "KHO XUẤT";
            this.lblKhoXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKhoNhap
            // 
            this.lblKhoNhap.AutoSize = true;
            this.lblKhoNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKhoNhap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKhoNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblKhoNhap.Location = new System.Drawing.Point(3, 62);
            this.lblKhoNhap.Name = "lblKhoNhap";
            this.lblKhoNhap.Size = new System.Drawing.Size(211, 62);
            this.lblKhoNhap.TabIndex = 2;
            this.lblKhoNhap.Text = "KHO NHẬN";
            this.lblKhoNhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBienThe
            // 
            this.lblBienThe.AutoSize = true;
            this.lblBienThe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBienThe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBienThe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblBienThe.Location = new System.Drawing.Point(3, 124);
            this.lblBienThe.Name = "lblBienThe";
            this.lblBienThe.Size = new System.Drawing.Size(211, 62);
            this.lblBienThe.TabIndex = 4;
            this.lblBienThe.Text = "BIẾN THỂ SẢN PHẨM";
            this.lblBienThe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblSoLuong.Location = new System.Drawing.Point(3, 186);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(211, 62);
            this.lblSoLuong.TabIndex = 6;
            this.lblSoLuong.Text = "SỐ LƯỢNG";
            this.lblSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTon
            // 
            this.lblTon.AutoSize = true;
            this.lblTon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.lblTon.Location = new System.Drawing.Point(217, 13);
            this.lblTon.Name = "lblTon";
            this.lblTon.Size = new System.Drawing.Size(115, 20);
            this.lblTon.TabIndex = 1;
            this.lblTon.Text = "Tồn kho xuất: -";
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLyDo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLyDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblLyDo.Location = new System.Drawing.Point(3, 248);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(211, 93);
            this.lblLyDo.TabIndex = 8;
            this.lblLyDo.Text = "LÝ DO";
            this.lblLyDo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHuongDan
            // 
            this.lblHuongDan.BackColor = System.Drawing.Color.White;
            this.lblHuongDan.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHuongDan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHuongDan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblHuongDan.Location = new System.Drawing.Point(40, 368);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Padding = new System.Windows.Forms.Padding(17, 13, 17, 9);
            this.lblHuongDan.Size = new System.Drawing.Size(857, 62);
            this.lblHuongDan.TabIndex = 0;
            this.lblHuongDan.Text = "Hệ thống sẽ tự động trừ tồn kho xuất, cộng tồn kho nhận, tạo phiếu xuất kho và gh" +
    "i lịch sử tồn kho trong cùng một giao dịch.";
            // 
            // cmbKhoXuat
            // 
            this.cmbKhoXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbKhoXuat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKhoXuat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbKhoXuat.FormattingEnabled = true;
            this.cmbKhoXuat.Location = new System.Drawing.Point(217, 7);
            this.cmbKhoXuat.Margin = new System.Windows.Forms.Padding(0, 7, 0, 7);
            this.cmbKhoXuat.Name = "cmbKhoXuat";
            this.cmbKhoXuat.Size = new System.Drawing.Size(640, 31);
            this.cmbKhoXuat.TabIndex = 1;
            // 
            // cmbKhoNhap
            // 
            this.cmbKhoNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbKhoNhap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKhoNhap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbKhoNhap.FormattingEnabled = true;
            this.cmbKhoNhap.Location = new System.Drawing.Point(217, 69);
            this.cmbKhoNhap.Margin = new System.Windows.Forms.Padding(0, 7, 0, 7);
            this.cmbKhoNhap.Name = "cmbKhoNhap";
            this.cmbKhoNhap.Size = new System.Drawing.Size(640, 31);
            this.cmbKhoNhap.TabIndex = 3;
            // 
            // cmbBienThe
            // 
            this.cmbBienThe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBienThe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBienThe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBienThe.FormattingEnabled = true;
            this.cmbBienThe.Location = new System.Drawing.Point(217, 131);
            this.cmbBienThe.Margin = new System.Windows.Forms.Padding(0, 7, 0, 7);
            this.cmbBienThe.Name = "cmbBienThe";
            this.cmbBienThe.Size = new System.Drawing.Size(640, 31);
            this.cmbBienThe.TabIndex = 5;
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudSoLuong.Location = new System.Drawing.Point(0, 9);
            this.nudSoLuong.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(194, 30);
            this.nudSoLuong.TabIndex = 0;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtLyDo
            // 
            this.txtLyDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLyDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLyDo.Location = new System.Drawing.Point(220, 251);
            this.txtLyDo.Multiline = true;
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLyDo.Size = new System.Drawing.Size(634, 87);
            this.txtLyDo.TabIndex = 9;
            this.txtLyDo.Text = "Bổ sung tồn kho kho chính";
            // 
            // btnChuyen
            // 
            this.btnChuyen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnChuyen.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChuyen.FlatAppearance.BorderSize = 0;
            this.btnChuyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChuyen.ForeColor = System.Drawing.Color.White;
            this.btnChuyen.Location = new System.Drawing.Point(691, 19);
            this.btnChuyen.Margin = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.btnChuyen.Name = "btnChuyen";
            this.btnChuyen.Size = new System.Drawing.Size(217, 48);
            this.btnChuyen.TabIndex = 1;
            this.btnChuyen.Text = "XÁC NHẬN ĐIỀU CHUYỂN";
            this.btnChuyen.UseVisualStyleBackColor = false;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.White;
            this.btnDong.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnDong.Location = new System.Drawing.Point(577, 19);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(114, 48);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "HỦY";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.header.Controls.Add(this.lblPhuDe);
            this.header.Controls.Add(this.lblTieuDe);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(937, 107);
            this.header.TabIndex = 2;
            // 
            // card
            // 
            this.card.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.card.Controls.Add(this.lblHuongDan);
            this.card.Controls.Add(this.layout);
            this.card.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card.Location = new System.Drawing.Point(0, 107);
            this.card.Name = "card";
            this.card.Padding = new System.Windows.Forms.Padding(40, 27, 40, 11);
            this.card.Size = new System.Drawing.Size(937, 461);
            this.card.TabIndex = 0;
            // 
            // layout
            // 
            this.layout.ColumnCount = 2;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 217F));
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.Controls.Add(this.lblKhoXuat, 0, 0);
            this.layout.Controls.Add(this.cmbKhoXuat, 1, 0);
            this.layout.Controls.Add(this.lblKhoNhap, 0, 1);
            this.layout.Controls.Add(this.cmbKhoNhap, 1, 1);
            this.layout.Controls.Add(this.lblBienThe, 0, 2);
            this.layout.Controls.Add(this.cmbBienThe, 1, 2);
            this.layout.Controls.Add(this.lblSoLuong, 0, 3);
            this.layout.Controls.Add(this.panelSoLuong, 1, 3);
            this.layout.Controls.Add(this.lblLyDo, 0, 4);
            this.layout.Controls.Add(this.txtLyDo, 1, 4);
            this.layout.Dock = System.Windows.Forms.DockStyle.Top;
            this.layout.Location = new System.Drawing.Point(40, 27);
            this.layout.Name = "layout";
            this.layout.RowCount = 5;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.layout.Size = new System.Drawing.Size(857, 341);
            this.layout.TabIndex = 1;
            // 
            // panelSoLuong
            // 
            this.panelSoLuong.Controls.Add(this.nudSoLuong);
            this.panelSoLuong.Controls.Add(this.lblTon);
            this.panelSoLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSoLuong.Location = new System.Drawing.Point(220, 189);
            this.panelSoLuong.Name = "panelSoLuong";
            this.panelSoLuong.Size = new System.Drawing.Size(634, 56);
            this.panelSoLuong.TabIndex = 7;
            // 
            // footer
            // 
            this.footer.BackColor = System.Drawing.Color.White;
            this.footer.Controls.Add(this.btnDong);
            this.footer.Controls.Add(this.btnChuyen);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 568);
            this.footer.Name = "footer";
            this.footer.Padding = new System.Windows.Forms.Padding(23, 19, 29, 16);
            this.footer.Size = new System.Drawing.Size(937, 83);
            this.footer.TabIndex = 1;
            // 
            // DieuChuyenKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(937, 651);
            this.Controls.Add(this.card);
            this.Controls.Add(this.footer);
            this.Controls.Add(this.header);
            this.MinimumSize = new System.Drawing.Size(866, 605);
            this.Name = "DieuChuyenKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SPORTSHOP - Điều chuyển kho";
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.card.ResumeLayout(false);
            this.layout.ResumeLayout(false);
            this.layout.PerformLayout();
            this.panelSoLuong.ResumeLayout(false);
            this.panelSoLuong.PerformLayout();
            this.footer.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}

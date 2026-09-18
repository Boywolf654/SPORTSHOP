namespace SPORTSHOP
{
    partial class FormQLHinhAnhSanPham
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblSanPham = new System.Windows.Forms.Label();
            this.lblDuongDan = new System.Windows.Forms.Label();
            this.txtDuongDan = new System.Windows.Forms.TextBox();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.btnThemAnh = new System.Windows.Forms.Button();
            this.dgvAnh = new System.Windows.Forms.DataGridView();
            this.colMaAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUrlAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnhChinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.lblPreview = new System.Windows.Forms.Label();
            this.btnDatAnhChinh = new System.Windows.Forms.Button();
            this.btnXoaAnh = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(348, 31);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ HÌNH ẢNH SẢN PHẨM";
            // 
            // lblSanPham
            // 
            this.lblSanPham.AutoEllipsis = true;
            this.lblSanPham.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSanPham.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.lblSanPham.Location = new System.Drawing.Point(27, 61);
            this.lblSanPham.Name = "lblSanPham";
            this.lblSanPham.Size = new System.Drawing.Size(690, 30);
            this.lblSanPham.TabIndex = 1;
            this.lblSanPham.Text = "Sản phẩm";
            this.lblSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDuongDan
            // 
            this.lblDuongDan.AutoSize = true;
            this.lblDuongDan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDuongDan.ForeColor = System.Drawing.Color.White;
            this.lblDuongDan.Location = new System.Drawing.Point(27, 108);
            this.lblDuongDan.Name = "lblDuongDan";
            this.lblDuongDan.Size = new System.Drawing.Size(94, 17);
            this.lblDuongDan.TabIndex = 2;
            this.lblDuongDan.Text = "Ảnh đã chọn:";
            // 
            // txtDuongDan
            // 
            this.txtDuongDan.BackColor = System.Drawing.Color.FromArgb(35, 35, 37);
            this.txtDuongDan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDuongDan.ForeColor = System.Drawing.Color.White;
            this.txtDuongDan.Location = new System.Drawing.Point(128, 105);
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.ReadOnly = true;
            this.txtDuongDan.Size = new System.Drawing.Size(454, 23);
            this.txtDuongDan.TabIndex = 3;
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(592, 102);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(125, 29);
            this.btnChonFile.TabIndex = 4;
            this.btnChonFile.Text = "Chọn hình ảnh";
            this.btnChonFile.UseVisualStyleBackColor = false;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // btnThemAnh
            // 
            this.btnThemAnh.Location = new System.Drawing.Point(27, 146);
            this.btnThemAnh.Name = "btnThemAnh";
            this.btnThemAnh.Size = new System.Drawing.Size(125, 31);
            this.btnThemAnh.TabIndex = 5;
            this.btnThemAnh.Text = "Thêm ảnh";
            this.btnThemAnh.UseVisualStyleBackColor = false;
            this.btnThemAnh.Click += new System.EventHandler(this.btnThemAnh_Click);
            // 
            // dgvAnh
            // 
            this.dgvAnh.AllowUserToAddRows = false;
            this.dgvAnh.BackgroundColor = System.Drawing.Color.FromArgb(35, 35, 37);
            this.dgvAnh.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAnh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaAnh,
            this.colUrlAnh,
            this.colAnhChinh});
            this.dgvAnh.Location = new System.Drawing.Point(27, 198);
            this.dgvAnh.Name = "dgvAnh";
            this.dgvAnh.RowHeadersVisible = false;
            this.dgvAnh.RowTemplate.Height = 32;
            this.dgvAnh.Size = new System.Drawing.Size(690, 310);
            this.dgvAnh.TabIndex = 6;
            this.dgvAnh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnh_CellClick);
            // 
            // colMaAnh
            // 
            this.colMaAnh.FillWeight = 18F;
            this.colMaAnh.HeaderText = "Mã ảnh";
            this.colMaAnh.Name = "colMaAnh";
            this.colMaAnh.ReadOnly = true;
            // 
            // colUrlAnh
            // 
            this.colUrlAnh.FillWeight = 110F;
            this.colUrlAnh.HeaderText = "Đường dẫn ảnh";
            this.colUrlAnh.Name = "colUrlAnh";
            this.colUrlAnh.ReadOnly = true;
            // 
            // colAnhChinh
            // 
            this.colAnhChinh.FillWeight = 28F;
            this.colAnhChinh.HeaderText = "Trạng thái";
            this.colAnhChinh.Name = "colAnhChinh";
            this.colAnhChinh.ReadOnly = true;
            // 
            // picPreview
            // 
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(745, 105);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(280, 403);
            this.picPreview.TabIndex = 7;
            this.picPreview.TabStop = false;
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPreview.ForeColor = System.Drawing.Color.White;
            this.lblPreview.Location = new System.Drawing.Point(742, 77);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(70, 19);
            this.lblPreview.TabIndex = 8;
            this.lblPreview.Text = "Xem ảnh";
            // 
            // btnDatAnhChinh
            // 
            this.btnDatAnhChinh.Location = new System.Drawing.Point(168, 146);
            this.btnDatAnhChinh.Name = "btnDatAnhChinh";
            this.btnDatAnhChinh.Size = new System.Drawing.Size(145, 31);
            this.btnDatAnhChinh.TabIndex = 9;
            this.btnDatAnhChinh.Text = "Đặt làm ảnh chính";
            this.btnDatAnhChinh.UseVisualStyleBackColor = false;
            this.btnDatAnhChinh.Click += new System.EventHandler(this.btnDatAnhChinh_Click);
            // 
            // btnXoaAnh
            // 
            this.btnXoaAnh.Location = new System.Drawing.Point(329, 146);
            this.btnXoaAnh.Name = "btnXoaAnh";
            this.btnXoaAnh.Size = new System.Drawing.Size(115, 31);
            this.btnXoaAnh.TabIndex = 10;
            this.btnXoaAnh.Text = "Xóa ảnh";
            this.btnXoaAnh.UseVisualStyleBackColor = false;
            this.btnXoaAnh.Click += new System.EventHandler(this.btnXoaAnh_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(459, 146);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(123, 31);
            this.btnLamMoi.TabIndex = 11;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // FormQLHinhAnhSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 535);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoaAnh);
            this.Controls.Add(this.btnDatAnhChinh);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.dgvAnh);
            this.Controls.Add(this.btnThemAnh);
            this.Controls.Add(this.btnChonFile);
            this.Controls.Add(this.txtDuongDan);
            this.Controls.Add(this.lblDuongDan);
            this.Controls.Add(this.lblSanPham);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "FormQLHinhAnhSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SPORTSHOP - Quản lý hình ảnh sản phẩm";
            this.Load += new System.EventHandler(this.FormQLHinhAnhSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblSanPham;
        private System.Windows.Forms.Label lblDuongDan;
        private System.Windows.Forms.TextBox txtDuongDan;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.Button btnThemAnh;
        private System.Windows.Forms.DataGridView dgvAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUrlAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnhChinh;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Button btnDatAnhChinh;
        private System.Windows.Forms.Button btnXoaAnh;
        private System.Windows.Forms.Button btnLamMoi;
    }
}

namespace SPORTSHOP
{
    partial class Quản_lí_sản_phẩm_FormSanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbThuongHieu = new System.Windows.Forms.ComboBox();
            this.cmbDanhMuc = new System.Windows.Forms.ComboBox();
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
            this.btnSuaSP = new System.Windows.Forms.Button();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.btnLamMoiSP = new System.Windows.Forms.Button();
            this.btnXoaSP = new System.Windows.Forms.Button();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.cmbMau = new System.Windows.Forms.ComboBox();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.btnSuaBienThe = new System.Windows.Forms.Button();
            this.btnThemBienThe = new System.Windows.Forms.Button();
            this.btnXoaBienThe = new System.Windows.Forms.Button();
            this.btnLamMoiBienThe = new System.Windows.Forms.Button();
            this.dgvBienThe = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBienThe)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sản Phẩm";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSP.Location = new System.Drawing.Point(16, 66);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(271, 26);
            this.txtTenSP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Thương hiệu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Danh mục";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mô tả";
            // 
            // cmbThuongHieu
            // 
            this.cmbThuongHieu.FormattingEnabled = true;
            this.cmbThuongHieu.Location = new System.Drawing.Point(16, 124);
            this.cmbThuongHieu.Name = "cmbThuongHieu";
            this.cmbThuongHieu.Size = new System.Drawing.Size(271, 24);
            this.cmbThuongHieu.TabIndex = 4;
            // 
            // cmbDanhMuc
            // 
            this.cmbDanhMuc.FormattingEnabled = true;
            this.cmbDanhMuc.Location = new System.Drawing.Point(307, 66);
            this.cmbDanhMuc.Name = "cmbDanhMuc";
            this.cmbDanhMuc.Size = new System.Drawing.Size(264, 24);
            this.cmbDanhMuc.TabIndex = 4;
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Location = new System.Drawing.Point(307, 127);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new System.Drawing.Size(128, 20);
            this.chkTrangThai.TabIndex = 5;
            this.chkTrangThai.Text = "Đang Hoạt Động";
            this.chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // btnSuaSP
            // 
            this.btnSuaSP.Location = new System.Drawing.Point(106, 221);
            this.btnSuaSP.Name = "btnSuaSP";
            this.btnSuaSP.Size = new System.Drawing.Size(75, 23);
            this.btnSuaSP.TabIndex = 6;
            this.btnSuaSP.Text = "Sửa";
            this.btnSuaSP.UseVisualStyleBackColor = true;
            // 
            // btnThemSP
            // 
            this.btnThemSP.Location = new System.Drawing.Point(16, 221);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(75, 23);
            this.btnThemSP.TabIndex = 6;
            this.btnThemSP.Text = "Thêm";
            this.btnThemSP.UseVisualStyleBackColor = true;
            // 
            // btnLamMoiSP
            // 
            this.btnLamMoiSP.Location = new System.Drawing.Point(296, 221);
            this.btnLamMoiSP.Name = "btnLamMoiSP";
            this.btnLamMoiSP.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoiSP.TabIndex = 6;
            this.btnLamMoiSP.Text = "Làm mới";
            this.btnLamMoiSP.UseVisualStyleBackColor = true;
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.Location = new System.Drawing.Point(202, 221);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(75, 23);
            this.btnXoaSP.TabIndex = 6;
            this.btnXoaSP.Text = "Xóa";
            this.btnXoaSP.UseVisualStyleBackColor = true;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoTa.Location = new System.Drawing.Point(16, 184);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(555, 22);
            this.txtMoTa.TabIndex = 1;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(12, 250);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 24;
            this.dgvSanPham.Size = new System.Drawing.Size(563, 137);
            this.dgvSanPham.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 403);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Biến thể sản phẩm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 423);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Đang quản lí biến thể của:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(362, 453);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Giá nhập";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(468, 453);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Giá bán";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 451);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 16);
            this.label10.TabIndex = 10;
            this.label10.Text = "Size";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(212, 451);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "SKU";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(103, 451);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 16);
            this.label12.TabIndex = 10;
            this.label12.Text = "Màu";
            // 
            // cmbSize
            // 
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Location = new System.Drawing.Point(12, 470);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(82, 24);
            this.cmbSize.TabIndex = 11;
            // 
            // cmbMau
            // 
            this.cmbMau.FormattingEnabled = true;
            this.cmbMau.Location = new System.Drawing.Point(106, 470);
            this.cmbMau.Name = "cmbMau";
            this.cmbMau.Size = new System.Drawing.Size(100, 24);
            this.cmbMau.TabIndex = 11;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(365, 472);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(100, 22);
            this.txtGiaNhap.TabIndex = 12;
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(471, 472);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(100, 22);
            this.txtGiaBan.TabIndex = 12;
            // 
            // txtSKU
            // 
            this.txtSKU.Location = new System.Drawing.Point(215, 472);
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Size = new System.Drawing.Size(144, 22);
            this.txtSKU.TabIndex = 12;
            // 
            // btnSuaBienThe
            // 
            this.btnSuaBienThe.Location = new System.Drawing.Point(103, 520);
            this.btnSuaBienThe.Name = "btnSuaBienThe";
            this.btnSuaBienThe.Size = new System.Drawing.Size(75, 23);
            this.btnSuaBienThe.TabIndex = 13;
            this.btnSuaBienThe.Text = "Sửa";
            this.btnSuaBienThe.UseVisualStyleBackColor = true;
            // 
            // btnThemBienThe
            // 
            this.btnThemBienThe.Location = new System.Drawing.Point(12, 520);
            this.btnThemBienThe.Name = "btnThemBienThe";
            this.btnThemBienThe.Size = new System.Drawing.Size(75, 23);
            this.btnThemBienThe.TabIndex = 13;
            this.btnThemBienThe.Text = "Thêm";
            this.btnThemBienThe.UseVisualStyleBackColor = true;
            // 
            // btnXoaBienThe
            // 
            this.btnXoaBienThe.Location = new System.Drawing.Point(193, 520);
            this.btnXoaBienThe.Name = "btnXoaBienThe";
            this.btnXoaBienThe.Size = new System.Drawing.Size(75, 23);
            this.btnXoaBienThe.TabIndex = 13;
            this.btnXoaBienThe.Text = "Xóa";
            this.btnXoaBienThe.UseVisualStyleBackColor = true;
            // 
            // btnLamMoiBienThe
            // 
            this.btnLamMoiBienThe.Location = new System.Drawing.Point(284, 520);
            this.btnLamMoiBienThe.Name = "btnLamMoiBienThe";
            this.btnLamMoiBienThe.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoiBienThe.TabIndex = 13;
            this.btnLamMoiBienThe.Text = "Làm mới";
            this.btnLamMoiBienThe.UseVisualStyleBackColor = true;
            // 
            // dgvBienThe
            // 
            this.dgvBienThe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBienThe.Location = new System.Drawing.Point(12, 549);
            this.dgvBienThe.Name = "dgvBienThe";
            this.dgvBienThe.RowHeadersWidth = 51;
            this.dgvBienThe.RowTemplate.Height = 24;
            this.dgvBienThe.Size = new System.Drawing.Size(569, 156);
            this.dgvBienThe.TabIndex = 14;
            // 
            // Quản_lí_sản_phẩm_FormSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 717);
            this.Controls.Add(this.dgvBienThe);
            this.Controls.Add(this.btnLamMoiBienThe);
            this.Controls.Add(this.btnXoaBienThe);
            this.Controls.Add(this.btnThemBienThe);
            this.Controls.Add(this.btnSuaBienThe);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.txtSKU);
            this.Controls.Add(this.txtGiaNhap);
            this.Controls.Add(this.cmbMau);
            this.Controls.Add(this.cmbSize);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.btnXoaSP);
            this.Controls.Add(this.btnLamMoiSP);
            this.Controls.Add(this.btnThemSP);
            this.Controls.Add(this.btnSuaSP);
            this.Controls.Add(this.chkTrangThai);
            this.Controls.Add(this.cmbDanhMuc);
            this.Controls.Add(this.cmbThuongHieu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.label1);
            this.Name = "Quản_lí_sản_phẩm_FormSanPham";
            this.Load += new System.EventHandler(this.Quản_lí_sản_phẩm_FormSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBienThe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbThuongHieu;
        private System.Windows.Forms.ComboBox cmbDanhMuc;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.Button btnSuaSP;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.Button btnLamMoiSP;
        private System.Windows.Forms.Button btnXoaSP;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.ComboBox cmbMau;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.Button btnSuaBienThe;
        private System.Windows.Forms.Button btnThemBienThe;
        private System.Windows.Forms.Button btnXoaBienThe;
        private System.Windows.Forms.Button btnLamMoiBienThe;
        private System.Windows.Forms.DataGridView dgvBienThe;
    }
}
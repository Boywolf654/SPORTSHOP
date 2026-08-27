namespace SPORTSHOP
{
    partial class FormMauSac
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMauSac = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btn_lammoi = new Guna.UI2.WinForms.Guna2Button();
            this.btn_xoa = new Guna.UI2.WinForms.Guna2Button();
            this.btn_sua = new Guna.UI2.WinForms.Guna2Button();
            this.btn_them = new Guna.UI2.WinForms.Guna2Button();
            this.txt_TenMau = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_TrangThai = new Guna.UI2.WinForms.Guna2CheckBox();
            this.MaMau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMauSac)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMauSac
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dgvMauSac.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMauSac.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvMauSac.ColumnHeadersHeight = 4;
            this.dgvMauSac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvMauSac.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaMau,
            this.TenMau});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMauSac.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvMauSac.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvMauSac.Location = new System.Drawing.Point(1, 244);
            this.dgvMauSac.Name = "dgvMauSac";
            this.dgvMauSac.RowHeadersVisible = false;
            this.dgvMauSac.RowHeadersWidth = 51;
            this.dgvMauSac.RowTemplate.Height = 24;
            this.dgvMauSac.Size = new System.Drawing.Size(799, 207);
            this.dgvMauSac.TabIndex = 12;
            this.dgvMauSac.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvMauSac.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvMauSac.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvMauSac.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvMauSac.ThemeStyle.RowsStyle.Height = 24;
            this.dgvMauSac.SelectionChanged += new System.EventHandler(this.dgvMauSac_SelectionChanged);
            // 
            // btn_lammoi
            // 
            this.btn_lammoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_lammoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_lammoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_lammoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_lammoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_lammoi.ForeColor = System.Drawing.Color.White;
            this.btn_lammoi.Location = new System.Drawing.Point(611, 135);
            this.btn_lammoi.Name = "btn_lammoi";
            this.btn_lammoi.Size = new System.Drawing.Size(144, 57);
            this.btn_lammoi.TabIndex = 8;
            this.btn_lammoi.Text = "Làm Mới";
            this.btn_lammoi.Click += new System.EventHandler(this.btn_lammoi_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_xoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_xoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_xoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_xoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_xoa.ForeColor = System.Drawing.Color.White;
            this.btn_xoa.Location = new System.Drawing.Point(423, 135);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(144, 57);
            this.btn_xoa.TabIndex = 9;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_sua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_sua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_sua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_sua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_sua.ForeColor = System.Drawing.Color.White;
            this.btn_sua.Location = new System.Drawing.Point(216, 135);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(148, 57);
            this.btn_sua.TabIndex = 10;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_them
            // 
            this.btn_them.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_them.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_them.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_them.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_them.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_them.ForeColor = System.Drawing.Color.White;
            this.btn_them.Location = new System.Drawing.Point(20, 135);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(147, 57);
            this.btn_them.TabIndex = 11;
            this.btn_them.Text = "Thêm";
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // txt_TenMau
            // 
            this.txt_TenMau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TenMau.DefaultText = "";
            this.txt_TenMau.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_TenMau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_TenMau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TenMau.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TenMau.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TenMau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_TenMau.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TenMau.Location = new System.Drawing.Point(255, 18);
            this.txt_TenMau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_TenMau.Name = "txt_TenMau";
            this.txt_TenMau.PlaceholderText = "";
            this.txt_TenMau.SelectedText = "";
            this.txt_TenMau.Size = new System.Drawing.Size(229, 31);
            this.txt_TenMau.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(98, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Trạng Thái:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(98, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên Màu:";
            // 
            // chk_TrangThai
            // 
            this.chk_TrangThai.AutoSize = true;
            this.chk_TrangThai.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chk_TrangThai.CheckedState.BorderRadius = 0;
            this.chk_TrangThai.CheckedState.BorderThickness = 0;
            this.chk_TrangThai.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chk_TrangThai.Location = new System.Drawing.Point(255, 79);
            this.chk_TrangThai.Name = "chk_TrangThai";
            this.chk_TrangThai.Size = new System.Drawing.Size(128, 20);
            this.chk_TrangThai.TabIndex = 13;
            this.chk_TrangThai.Text = "Đang Hoạt Động";
            this.chk_TrangThai.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chk_TrangThai.UncheckedState.BorderRadius = 0;
            this.chk_TrangThai.UncheckedState.BorderThickness = 0;
            this.chk_TrangThai.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // MaMau
            // 
            this.MaMau.DataPropertyName = "MaMau";
            this.MaMau.HeaderText = "Mã Màu";
            this.MaMau.MinimumWidth = 6;
            this.MaMau.Name = "MaMau";
            // 
            // TenMau
            // 
            this.TenMau.DataPropertyName = "TenMau";
            this.TenMau.HeaderText = "Tên Màu";
            this.TenMau.MinimumWidth = 6;
            this.TenMau.Name = "TenMau";
            // 
            // FormMauSac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvMauSac);
            this.Controls.Add(this.btn_lammoi);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.txt_TenMau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chk_TrangThai);
            this.Name = "FormMauSac";
            this.Text = "FormMauSac";
            this.Load += new System.EventHandler(this.FormMauSac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMauSac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvMauSac;
        private Guna.UI2.WinForms.Guna2Button btn_lammoi;
        private Guna.UI2.WinForms.Guna2Button btn_xoa;
        private Guna.UI2.WinForms.Guna2Button btn_sua;
        private Guna.UI2.WinForms.Guna2Button btn_them;
        private Guna.UI2.WinForms.Guna2TextBox txt_TenMau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CheckBox chk_TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMau;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMau;
    }
}
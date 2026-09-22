using System.Drawing;
using System.Windows.Forms;
namespace SPORTSHOP
{
    partial class CanhBaoKho
    {
        private Label lblTieuDe, lblPhuDe, lblSoLuong, lblKho;
        private ComboBox cmbKho; private DataGridView dgvCanhBao;
        private Button btnLamMoi, btnDieuChuyen; private Panel header, toolbar, body, cardStats;
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblPhuDe = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblKho = new System.Windows.Forms.Label();
            this.cmbKho = new System.Windows.Forms.ComboBox();
            this.dgvCanhBao = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDieuChuyen = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Panel();
            this.toolbar = new System.Windows.Forms.Panel();
            this.cardStats = new System.Windows.Forms.Panel();
            this.body = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).BeginInit();
            this.header.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.cardStats.SuspendLayout();
            this.body.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(28, 16);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(346, 45);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "CẢNH BÁO TỒN KHO";
            // 
            // lblPhuDe
            // 
            this.lblPhuDe.AutoSize = true;
            this.lblPhuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblPhuDe.Location = new System.Drawing.Point(31, 53);
            this.lblPhuDe.Name = "lblPhuDe";
            this.lblPhuDe.Size = new System.Drawing.Size(442, 21);
            this.lblPhuDe.TabIndex = 1;
            this.lblPhuDe.Text = "Theo dõi hàng sắp hết và điều chuyển linh hoạt giữa các kho";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.lblSoLuong.Location = new System.Drawing.Point(0, 0);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(310, 44);
            this.lblSoLuong.TabIndex = 0;
            this.lblSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKho
            // 
            this.lblKho.AutoSize = true;
            this.lblKho.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblKho.Location = new System.Drawing.Point(24, 9);
            this.lblKho.Name = "lblKho";
            this.lblKho.Size = new System.Drawing.Size(115, 20);
            this.lblKho.TabIndex = 1;
            this.lblKho.Text = "KHO THEO DÕI";
            // 
            // cmbKho
            // 
            this.cmbKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKho.Location = new System.Drawing.Point(24, 30);
            this.cmbKho.Name = "cmbKho";
            this.cmbKho.Size = new System.Drawing.Size(270, 24);
            this.cmbKho.TabIndex = 2;
            // 
            // dgvCanhBao
            // 
            this.dgvCanhBao.AllowUserToAddRows = false;
            this.dgvCanhBao.AllowUserToDeleteRows = false;
            this.dgvCanhBao.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvCanhBao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCanhBao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCanhBao.BackgroundColor = System.Drawing.Color.White;
            this.dgvCanhBao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCanhBao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCanhBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCanhBao.ColumnHeadersHeight = 35;
            this.dgvCanhBao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCanhBao.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCanhBao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCanhBao.EnableHeadersVisualStyles = false;
            this.dgvCanhBao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvCanhBao.Location = new System.Drawing.Point(20, 14);
            this.dgvCanhBao.MultiSelect = false;
            this.dgvCanhBao.Name = "dgvCanhBao";
            this.dgvCanhBao.ReadOnly = true;
            this.dgvCanhBao.RowHeadersVisible = false;
            this.dgvCanhBao.RowHeadersWidth = 51;
            this.dgvCanhBao.RowTemplate.Height = 34;
            this.dgvCanhBao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCanhBao.Size = new System.Drawing.Size(1140, 450);
            this.dgvCanhBao.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(310, 26);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(105, 36);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "🔄 LÀM MỚI";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnDieuChuyen
            // 
            this.btnDieuChuyen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnDieuChuyen.FlatAppearance.BorderSize = 0;
            this.btnDieuChuyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDieuChuyen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDieuChuyen.ForeColor = System.Drawing.Color.White;
            this.btnDieuChuyen.Location = new System.Drawing.Point(430, 26);
            this.btnDieuChuyen.Name = "btnDieuChuyen";
            this.btnDieuChuyen.Size = new System.Drawing.Size(175, 36);
            this.btnDieuChuyen.TabIndex = 4;
            this.btnDieuChuyen.Text = "⚡ ĐIỀU CHUYỂN KHO";
            this.btnDieuChuyen.UseVisualStyleBackColor = false;
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.header.Controls.Add(this.lblTieuDe);
            this.header.Controls.Add(this.lblPhuDe);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1180, 92);
            this.header.TabIndex = 2;
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.Color.White;
            this.toolbar.Controls.Add(this.cardStats);
            this.toolbar.Controls.Add(this.lblKho);
            this.toolbar.Controls.Add(this.cmbKho);
            this.toolbar.Controls.Add(this.btnLamMoi);
            this.toolbar.Controls.Add(this.btnDieuChuyen);
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar.Location = new System.Drawing.Point(0, 92);
            this.toolbar.Name = "toolbar";
            this.toolbar.Padding = new System.Windows.Forms.Padding(24, 18, 24, 12);
            this.toolbar.Size = new System.Drawing.Size(1180, 74);
            this.toolbar.TabIndex = 1;
            // 
            // cardStats
            // 
            this.cardStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cardStats.Controls.Add(this.lblSoLuong);
            this.cardStats.Dock = System.Windows.Forms.DockStyle.Right;
            this.cardStats.Location = new System.Drawing.Point(846, 18);
            this.cardStats.Name = "cardStats";
            this.cardStats.Size = new System.Drawing.Size(310, 44);
            this.cardStats.TabIndex = 0;
            // 
            // body
            // 
            this.body.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.body.Controls.Add(this.dgvCanhBao);
            this.body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.body.Location = new System.Drawing.Point(0, 166);
            this.body.Name = "body";
            this.body.Padding = new System.Windows.Forms.Padding(20, 14, 20, 20);
            this.body.Size = new System.Drawing.Size(1180, 484);
            this.body.TabIndex = 0;
            // 
            // CanhBaoKho
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1180, 650);
            this.Controls.Add(this.body);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.header);
            this.MinimumSize = new System.Drawing.Size(950, 550);
            this.Name = "CanhBaoKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SPORTSHOP - Cảnh báo tồn kho";

            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).EndInit();
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.cardStats.ResumeLayout(false);
            this.body.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
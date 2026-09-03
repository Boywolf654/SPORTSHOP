namespace SPORTSHOP
{
    partial class FromKho
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
            this.components = new System.ComponentModel.Container();
            this.guna2ElipseFrom = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2PanelTieuDe = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
            // 
            // guna2ElipseFrom
            // 
            this.guna2ElipseFrom.BorderRadius = 12;
            // 
            // guna2PanelTieuDe
            // 
            this.guna2PanelTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2PanelTieuDe.Location = new System.Drawing.Point(0, 0);
            this.guna2PanelTieuDe.Name = "guna2PanelTieuDe";
            this.guna2PanelTieuDe.Size = new System.Drawing.Size(1309, 180);
            this.guna2PanelTieuDe.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 525);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1309, 100);
            this.guna2Panel1.TabIndex = 1;
            // 
            // FromKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1309, 625);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2PanelTieuDe);
            this.Name = "FromKho";
            this.Text = "FromKho";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2ElipseFrom;
        private Guna.UI2.WinForms.Guna2Panel guna2PanelTieuDe;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
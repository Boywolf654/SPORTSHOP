using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class formgiaodienbanhang : Form
    {
        public formgiaodienbanhang()
        {
            InitializeComponent();
        }

        private void tấtCảToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void baloToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            
        }

        private void formgiaodienbanhang_Load(object sender, EventArgs e)
        {
            BoTatCaPictureBox(this);
        }
        private void BoGocPictureBox(PictureBox pic, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pic.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(
                pic.Width - radius,
                pic.Height - radius,
                radius,
                radius,
                0,
                90
            );
            path.AddArc(
                0,
                pic.Height - radius,
                radius,
                radius,
                90,
                90
            );

            path.CloseFigure();

            pic.Region = new Region(path);
        }
        private void BoTatCaPictureBox(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is PictureBox pic)
                {
                    BoGocPictureBox(pic, 30);
                }

                if (control.HasChildren)
                {
                    BoTatCaPictureBox(control);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class Formdangnhap : Form
    {
        public Formdangnhap()
        {
            InitializeComponent();
        }
        
        private void Formdangnhap_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
            using (Pen pen = new Pen(Color.Gold, 2))
            {
                e.Graphics.DrawRectangle(
                    pen,
                    0,
                    0,
                    panel1.Width - 1,
                    panel1.Height - 1
                );
            }
        }

        public class RoundedTextBox : TextBox
        {
            public int BorderRadius { get; set; } = 12;
            public Color BorderColor { get; set; } = Color.Gold;

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
            }
        }

    }
}

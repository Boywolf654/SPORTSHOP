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
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
        }

        private void FormDangKy_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn_DangKy.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn_DangKy.Width - radius, btn_DangKy.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn_DangKy.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            btn_DangKy.Region = new Region(path);
        }
    }
}

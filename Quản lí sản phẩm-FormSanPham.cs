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
    public partial class Quản_lí_sản_phẩm_FormSanPham : Form
    {
        public Quản_lí_sản_phẩm_FormSanPham()
        {
            InitializeComponent();
        }
        private void BoGocButton(Button btn, int radius)//=> Hàm bo góc
        {
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath();

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            btn.Region = new Region(path);
        }
        private void Quản_lí_sản_phẩm_FormSanPham_Load(object sender, EventArgs e)
        {
            BoGocButton(btn_Them, 10);
            BoGocButton(btn_Sua, 10);
            BoGocButton(btn_Xoa, 10);
            BoGocButton(btn_Lammoi, 10);
            BoGocButton(btnThem, 10);
            BoGocButton(btnSua, 10);
            BoGocButton(btnXoa, 10);
            BoGocButton(btnLammoi, 10);
        }
    }
}

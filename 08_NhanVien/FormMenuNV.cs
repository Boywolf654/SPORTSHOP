using System;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormMenuNV : Form
    {
        // Invoice form đọc cờ này sau khi Menu đóng.
        public bool YeuCauKhoaManHinh { get; private set; }

        public FormMenuNV()
        {
            InitializeComponent();
        }

        private void btn_moket_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "MỞ KÉT THÀNH CÔNG",
                "SPORTSHOP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btn_dononline_Click(object sender, EventArgs e)
        {
            // Mở form Đơn Online FULL thay cho thông báo demo.
            using (FormDonOnline frm = new FormDonOnline())
            {
                frm.ShowDialog(this);
            }
        }

        private void btn_khoamanhinh_Click(object sender, EventArgs e)
        {
            // Đóng Menu và báo cho form hóa đơn mở màn hình khóa.
            YeuCauKhoaManHinh = true;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

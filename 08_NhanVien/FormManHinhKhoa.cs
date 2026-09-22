using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormManHinhKhoa : Form
    {
        private Image _background;

        // Nhận form hóa đơn hiện tại
        // Form hóa đơn sẽ tự hiện lại sau khi màn hình khóa đóng.
        public FormManHinhKhoa(Form formHoaDon)
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;

            // Designer hiện tại chưa nối các event này nên phải nối tại đây.
            lnkDangNhapID.LinkClicked += lnkDangNhapID_LinkClicked;
            lnkChamCong.LinkClicked += lnkChamCong_LinkClicked;
            timerClock.Tick += timerClock_Tick;

            string path = Path.Combine(
                Application.StartupPath,
                "Images",
                "LockScreen",
                "sportshop_lock_screen.png"
            );

            if (File.Exists(path))
            {
                _background = Image.FromFile(path);
                BackgroundImage = _background;
                BackgroundImageLayout = ImageLayout.Stretch;
            }

            timerClock.Start();
            CapNhatThoiGian();
        }
        private void FormManHinhKhoa_Load(object sender, EventArgs e)
        {
        }
        private void timerClock_Tick(object sender, EventArgs e)
        {
            CapNhatThoiGian();
        }

        private void CapNhatThoiGian()
        {
            DateTime now = DateTime.Now;

            lblGio.Text = now.ToString("HH:mm");

            string thu;

            switch (now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    thu = "Thứ Hai";
                    break;

                case DayOfWeek.Tuesday:
                    thu = "Thứ Ba";
                    break;

                case DayOfWeek.Wednesday:
                    thu = "Thứ Tư";
                    break;

                case DayOfWeek.Thursday:
                    thu = "Thứ Năm";
                    break;

                case DayOfWeek.Friday:
                    thu = "Thứ Sáu";
                    break;

                case DayOfWeek.Saturday:
                    thu = "Thứ Bảy";
                    break;

                default:
                    thu = "Chủ Nhật";
                    break;
            }

            lblNgay.Text = string.Format(
                "{0}, {1} tháng {2}, {3}",
                thu,
                now.Day,
                now.Month,
                now.Year
            );
        }

        private void lnkDangNhapID_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            using (var frm = new FormDangNhapID())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    // Đăng nhập ID thành công.
                    // Đóng màn hình khóa để form hóa đơn bên ngoài hiện lại.
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void lnkChamCong_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            // Form D là form chấm công hiện có của project.
            using (var frm = new D(true))
            {
                frm.ShowDialog(this);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            timerClock?.Stop();

            if (_background != null)
            {
                _background.Dispose();
                _background = null;
            }

            base.OnFormClosed(e);
        }
    }
}
using SPORTSHOP._04_NhapHang;
using SPORTSHOP._05_NhaCungCap;
using SPORTSHOP._07_KhachHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPORTSHOP
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

<<<<<<< HEAD


            Application.Run(new Formdangnhap());

         


            Application.Run(new FormThongTinKhachHang());

=======
            Application.Run(new formgiaodienbanhang());
>>>>>>> 8ded47b9c063512a14bb0cc6934ecac348ea4bbd
        }

        // Khai báo hàm API của Windows
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
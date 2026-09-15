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

            Application.Run(new FormNhapHang2());

         

=======
            Application.Run(new FormThongTinKhachHang());
>>>>>>> 34d2850b85934afcf8acae6c40006ec8fc325e57
        }

        // Khai báo hàm API của Windows
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
using SPORTSHOP._04_NhapHang;
using SPORTSHOP._05_NhaCungCap;
using SPORTSHOP._07_KhachHang;
using SPORTSHOP._01_HeThong;
using SPORTSHOP._09_BaoCao;
using SPORTSHOP._06_BanHang;
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




            Application.Run(new formgiaodienbanhang());

            Application.Run(new Formdangnhap());
            Application.Run(new FormAdmin(null));



        }

        // Khai báo hàm API của Windows
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
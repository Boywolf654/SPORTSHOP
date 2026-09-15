using SPORTSHOP._05_NhaCungCap;
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

<<<<<<< HEAD:Program.cs
            Application.Run(new FrmNhapHang());
=======
            Application.Run(new FormChiTietNhaCungCap());
>>>>>>> ec73e39db2ae5ece1bd44eff4254011910db3357:00_Core/Program.cs
        }

        // Khai báo hàm API của Windows
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
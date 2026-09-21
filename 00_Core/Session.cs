namespace SPORTSHOP
{
    public static class Session
    {
        public static int MaTK { get; set; }
        public static string TenDangNhap { get; set; }
        public static int MaVaiTro { get; set; }
        public static string TenVaiTro { get; set; }

        public static int MaNV { get; set; }
        public static int MaCa { get; set; }

        public static decimal DoanhThuCa { get; set; }
        public static void DangXuat()
        {
            MaTK = 0;
            TenDangNhap = null;
            MaVaiTro = 0;
            TenVaiTro = null;
            MaNV = 0;
            MaCa = 0;
            DoanhThuCa = 0;
        }
    }
}
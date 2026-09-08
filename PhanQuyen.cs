namespace SPORTSHOP
{
    public static class PhanQuyen
    {
        public const int ADMIN = 1;
        public const int QUAN_LY = 2;
        public const int NV_BAN_HANG = 3;
        public const int NV_KHO = 4;
        public const int KHACH_HANG = 5;

        public static bool LaAdmin()
        {
            return Session.MaVaiTro == ADMIN;
        }

        public static bool LaQuanLy()
        {
            return Session.MaVaiTro == QUAN_LY;
        }

        public static bool LaNhanVienBanHang()
        {
            return Session.MaVaiTro == NV_BAN_HANG;
        }

        public static bool LaNhanVienKho()
        {
            return Session.MaVaiTro == NV_KHO;
        }

        public static bool CoQuyenDuyetPhieuNhap()
        {
            return Session.MaVaiTro == ADMIN ||
                   Session.MaVaiTro == QUAN_LY;
        }

        public static bool CoQuyenQuanLyKho()
        {
            return Session.MaVaiTro == ADMIN ||
                   Session.MaVaiTro == QUAN_LY ||
                   Session.MaVaiTro == NV_KHO;
        }

        public static bool CoQuyenBanHang()
        {
            return Session.MaVaiTro == ADMIN ||
                   Session.MaVaiTro == QUAN_LY ||
                   Session.MaVaiTro == NV_BAN_HANG;
        }

        public static bool CoQuyenQuanLyNhanVien()
        {
            return Session.MaVaiTro == ADMIN ||
                   Session.MaVaiTro == QUAN_LY;
        }

        //PHÂN QUYỀN CHO KHO 
        //
        //
        public static bool CoQuyenXemKho()
        {
            return Session.MaVaiTro == ADMIN ||
                   Session.MaVaiTro == QUAN_LY ||
                   Session.MaVaiTro == NV_KHO;
        }

        public static bool CoQuyenThemKho()
        {
            return Session.MaVaiTro == ADMIN ||
                   Session.MaVaiTro == QUAN_LY ||
                   Session.MaVaiTro == NV_KHO;
        }

        public static bool CoQuyenSuaKho()
        {
            return Session.MaVaiTro == ADMIN ||
                   Session.MaVaiTro == QUAN_LY ||
                   Session.MaVaiTro == NV_KHO;
        }
    }
}
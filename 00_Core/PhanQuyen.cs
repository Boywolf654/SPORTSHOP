namespace SPORTSHOP
{
    public static class PhanQuyen
    {
        // ==============================
        // MÃ VAI TRÒ
        // ==============================

        public const int ADMIN = 1;
        public const int QUAN_LY = 2;
        public const int NV_BAN_HANG = 3;
        public const int NV_KHO = 4;
        public const int KHACH_HANG = 5;


        // ==============================
        // KIỂM TRA VAI TRÒ
        // ==============================

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


        // ==============================
        // DUYỆT PHIẾU NHẬP
        // Admin + Quản lý
        // ==============================

        public static bool CoQuyenDuyetPhieuNhap()
        {
            switch (Session.MaVaiTro)
            {
                case ADMIN:
                case QUAN_LY:
                    return true;

                default:
                    return false;
            }
        }


        // ==============================
        // QUẢN LÝ KHO
        // Admin + Quản lý + NV kho
        // ==============================

        public static bool CoQuyenQuanLyKho()
        {
            switch (Session.MaVaiTro)
            {
                case ADMIN:
                case QUAN_LY:
                case NV_KHO:
                    return true;

                default:
                    return false;
            }
        }


        // ==============================
        // BÁN HÀNG
        // Admin + Quản lý + NV bán hàng
        // ==============================

        public static bool CoQuyenBanHang()
        {
            switch (Session.MaVaiTro)
            {
                case ADMIN:
                case QUAN_LY:
                case NV_BAN_HANG:
                    return true;

                default:
                    return false;
            }
        }


        // ==============================
        // QUẢN LÝ NHÂN VIÊN
        // Admin + Quản lý
        // ==============================

        public static bool CoQuyenQuanLyNhanVien()
        {
            switch (Session.MaVaiTro)
            {
                case ADMIN:
                case QUAN_LY:
                    return true;

                default:
                    return false;
            }
        }


        // ==============================
        // QUẢN LÝ KHO
        // ==============================

        public static bool CoQuyenXemKho()
        {
            switch (Session.MaVaiTro)
            {
                case ADMIN:
                case QUAN_LY:
                case NV_KHO:
                    return true;

                default:
                    return false;
            }
        }

        public static bool CoQuyenThemKho()
        {
            switch (Session.MaVaiTro)
            {
                case ADMIN:
                case QUAN_LY:
                case NV_KHO:
                    return true;

                default:
                    return false;
            }
        }

        public static bool CoQuyenSuaKho()
        {
            switch (Session.MaVaiTro)
            {
                case ADMIN:
                case QUAN_LY:
                case NV_KHO:
                    return true;

                default:
                    return false;
            }
        }
    }
}
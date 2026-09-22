using System.Collections.Generic;
using System.Linq;

namespace SPORTSHOP._06_BanHang
{
    public class GioHangItem
    {
        public SanPhamTam SanPham { get; set; }

        public string Size { get; set; }

        public string MauSac { get; set; }

        // Mã biến thể thật trong CSDL.
        public int MaBienThe { get; set; }

        public int SoLuong { get; set; }

        public decimal ThanhTien
        {
            get
            {
                return SanPham.Gia * SoLuong;
            }
        }
    }

    public static class GioHangManager
    {
        private static readonly List<GioHangItem> danhSach =
            new List<GioHangItem>();

        public static List<GioHangItem> DanhSach
        {
            get
            {
                return danhSach;
            }
        }

        // Giữ overload cũ để các form khác của project không lỗi.
        public static void Them(
            SanPhamTam sanPham,
            string size,
            string mauSac,
            int soLuong)
        {
            Them(
                sanPham,
                size,
                mauSac,
                soLuong,
                0);
        }

        // Overload mới: MaBienThe đi cùng item.
        public static void Them(
            SanPhamTam sanPham,
            string size,
            string mauSac,
            int soLuong,
            int maBienThe)
        {
            if (sanPham == null)
                return;

            if (soLuong < 1)
                soLuong = 1;

            GioHangItem item = danhSach.FirstOrDefault(x =>
                x.MaBienThe > 0 &&
                maBienThe > 0 &&
                x.MaBienThe == maBienThe);

            // Tương thích với các item cũ chưa có MaBienThe.
            if (item == null && maBienThe <= 0)
            {
                item = danhSach.FirstOrDefault(x =>
                    x.SanPham != null &&
                    x.SanPham.MaSP == sanPham.MaSP &&
                    x.Size == size &&
                    x.MauSac == mauSac);
            }

            if (item != null)
            {
                item.SoLuong += soLuong;

                // Nếu item cũ chưa có mã biến thể thì bổ sung.
                if (item.MaBienThe <= 0 && maBienThe > 0)
                    item.MaBienThe = maBienThe;

                return;
            }

            danhSach.Add(new GioHangItem
            {
                SanPham = sanPham,
                Size = size,
                MauSac = mauSac,
                MaBienThe = maBienThe,
                SoLuong = soLuong
            });
        }

        public static void Xoa(GioHangItem item)
        {
            if (item != null)
                danhSach.Remove(item);
        }

        public static void XoaTatCa()
        {
            danhSach.Clear();
        }

        public static decimal TongTien()
        {
            return danhSach.Sum(x => x.ThanhTien);
        }

        public static int TongSoLuong()
        {
            return danhSach.Sum(x => x.SoLuong);
        }
    }
}

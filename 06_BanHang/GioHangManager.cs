using System.Collections.Generic;
using System.Linq;

namespace SPORTSHOP._06_BanHang
{
    public class GioHangItem
    {
        public SanPhamTam SanPham { get; set; }

        public string Size { get; set; }

        public string MauSac { get; set; }

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

        public static void Them(
            SanPhamTam sanPham,
            string size,
            string mauSac,
            int soLuong)
        {
            if (sanPham == null)
                return;

            if (soLuong < 1)
                soLuong = 1;

            GioHangItem item = danhSach.FirstOrDefault(x =>
                x.SanPham.MaSP == sanPham.MaSP &&
                x.Size == size &&
                x.MauSac == mauSac);

            if (item != null)
            {
                item.SoLuong += soLuong;
            }
            else
            {
                danhSach.Add(new GioHangItem
                {
                    SanPham = sanPham,
                    Size = size,
                    MauSac = mauSac,
                    SoLuong = soLuong
                });
            }
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
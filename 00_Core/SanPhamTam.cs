using System.Drawing;

namespace SPORTSHOP
{
    public class SanPhamTam
    {
        public int MaSP { get; set; }

        public string TenSP { get; set; }

        public decimal Gia { get; set; }

        public decimal GiaCu { get; set; }

        public string LoaiSP { get; set; }

        public Image Anh { get; set; }

        public string ThuongHieu { get; set; }

        public string MauSac { get; set; }

        public string MoTa { get; set; }

        public SanPhamTam()
        {
        }

        public SanPhamTam(
            int maSP,
            string tenSP,
            decimal gia,
            decimal giaCu,
            Image anh,
            string loaiSP,
            string thuongHieu,
            string mauSac,
            string moTa)
        {
            MaSP = maSP;
            TenSP = tenSP;
            Gia = gia;
            GiaCu = giaCu;
            Anh = anh;
            LoaiSP = loaiSP;
            ThuongHieu = thuongHieu;
            MauSac = mauSac;
            MoTa = moTa;
        }
    }
}
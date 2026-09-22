using System;
using System.Data;
using System.Data.SqlClient;

namespace SPORTSHOP
{
    public static class KhoService
    {
        // =========================================================
        // LẤY DANH SÁCH KHO ĐANG HOẠT ĐỘNG
        // =========================================================
        public static DataTable LayKhoHoatDong(KetNoiDuLieu kt)
        {
            string sql = @"
SELECT
    MaKho,
    TenKho,
    ISNULL(LoaiKho, N'Phụ') AS LoaiKho,
    DiaChi
FROM dbo.Kho
WHERE TrangThai = 1
ORDER BY
    CASE
        WHEN ISNULL(LoaiKho, N'Phụ') = N'Chính' THEN 0
        ELSE 1
    END,
    TenKho;";

            return kt.GetData(sql);
        }

        // =========================================================
        // LẤY KHO CỦA NHÂN VIÊN
        // Ưu tiên kho của ca đang làm
        // Nếu ca không có kho thì lấy MaKho của nhân viên
        // =========================================================
        public static int LayKhoCuaNhanVien(KetNoiDuLieu kt, int maNV)
        {
            string sql = @"
SELECT TOP 1
    ISNULL(c.MaKho, nv.MaKho)
FROM dbo.NhanVien nv
LEFT JOIN dbo.CaLamViec c
    ON c.MaNV = nv.MaNV
    AND c.TrangThai = N'Đang làm'
    AND c.GioKetThuc IS NULL
WHERE nv.MaNV = @MaNV
ORDER BY
    CASE
        WHEN c.MaKho IS NULL THEN 1
        ELSE 0
    END,
    c.MaCa DESC;";

            object result = kt.ExecuteScalar(
                sql,
                new SqlParameter[]
                {
                    new SqlParameter("@MaNV", maNV)
                });

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToInt32(result);
        }

        // =========================================================
        // LẤY TỒN KHO THEO KHO
        // =========================================================
        public static DataTable LayTonKho(
            KetNoiDuLieu kt,
            int maKho)
        {
            string sql = @"
SELECT
    tk.MaTonKho,
    tk.MaKho,
    k.TenKho,
    tk.MaBienThe,
    bt.SKU,
    sp.MaSP,
    sp.TenSP,
    sz.TenSize AS Size,
    ISNULL(ms.TenMau, N'') AS Mau,
    tk.SLTon,
    tk.SLToiThieu,
    CASE
        WHEN tk.SLTon <= tk.SLToiThieu THEN 1
        ELSE 0
    END AS CanhBao
FROM dbo.TonKho tk
INNER JOIN dbo.Kho k
    ON k.MaKho = tk.MaKho
INNER JOIN dbo.BienTheSanPham bt
    ON bt.MaBienThe = tk.MaBienThe
INNER JOIN dbo.SanPham sp
    ON sp.MaSP = bt.MaSP
LEFT JOIN dbo.Size sz
    ON sz.MaSize = bt.MaSize
LEFT JOIN dbo.MauSac ms
    ON ms.MaMau = bt.MaMau
WHERE tk.MaKho = @MaKho
ORDER BY
    sp.TenSP,
    sz.TenSize,
    ms.TenMau;";

            return kt.GetData(
                sql,
                new SqlParameter[]
                {
                    new SqlParameter("@MaKho", maKho)
                });
        }

        // =========================================================
        // LẤY HÀNG SẮP HẾT
        // =========================================================
        public static DataTable LayHangSapHet(
            KetNoiDuLieu kt,
            int maKho)
        {
            string sql = @"
SELECT
    tk.MaBienThe,
    bt.SKU,
    sp.MaSP,
    sp.TenSP,
    sz.TenSize AS Size,
    ISNULL(ms.TenMau, N'') AS Mau,
    tk.SLTon,
    tk.SLToiThieu,
    k.TenKho,

    ISNULL(
        (
            SELECT SUM(tk2.SLTon)
            FROM dbo.TonKho tk2
            WHERE tk2.MaBienThe = tk.MaBienThe
              AND tk2.MaKho <> tk.MaKho
        ),
        0
    ) AS TonKhoKhac

FROM dbo.TonKho tk

INNER JOIN dbo.Kho k
    ON k.MaKho = tk.MaKho

INNER JOIN dbo.BienTheSanPham bt
    ON bt.MaBienThe = tk.MaBienThe

INNER JOIN dbo.SanPham sp
    ON sp.MaSP = bt.MaSP

LEFT JOIN dbo.Size sz
    ON sz.MaSize = bt.MaSize

LEFT JOIN dbo.MauSac ms
    ON ms.MaMau = bt.MaMau

WHERE tk.MaKho = @MaKho
  AND tk.SLTon <= tk.SLToiThieu

ORDER BY
    tk.SLTon ASC,
    sp.TenSP;";

            return kt.GetData(
                sql,
                new SqlParameter[]
                {
                    new SqlParameter("@MaKho", maKho)
                });
        }

        // =========================================================
        // LẤY TỒN KHO TRONG TRANSACTION
        // Có UPDLOCK để tránh 2 người cùng điều chuyển một lúc
        // =========================================================
        public static int LayTon(
            KetNoiDuLieu kt,
            SqlConnection conn,
            SqlTransaction tran,
            int maKho,
            int maBienThe)
        {
            using (SqlCommand cmd = new SqlCommand(@"
SELECT SLTon
FROM dbo.TonKho WITH (UPDLOCK, ROWLOCK)
WHERE MaKho = @MaKho
  AND MaBienThe = @MaBienThe;", conn, tran))
            {
                cmd.Parameters.AddWithValue("@MaKho", maKho);
                cmd.Parameters.AddWithValue("@MaBienThe", maBienThe);

                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return 0;

                return Convert.ToInt32(result);
            }
        }
    }
}
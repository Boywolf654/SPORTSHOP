using System;
using System.Data;
using System.Data.SqlClient;

namespace SPORTSHOP
{
    public static class QuanLyCa
    {
        private static readonly KetNoiDuLieu kt =
            new KetNoiDuLieu();

        // =========================================================
        // KIỂM TRA NHÂN VIÊN CÓ CA ĐANG MỞ KHÔNG
        // =========================================================
        public static int LayCaDangMo(int maNV)
        {
            string sql = @"
                SELECT TOP 1 MaCa
                FROM CaLamViec
                WHERE MaNV = @MaNV
                  AND TrangThai = N'Đang làm'
                  AND GioKetThuc IS NULL
                ORDER BY MaCa DESC";

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
        // MỞ CA MỚI
        // =========================================================
        public static int MoCa(int maNV)
        {
            if (maNV <= 0)
                throw new Exception(
                    "Không xác định được nhân viên.");

            // Nếu đã có ca đang mở thì dùng lại
            int caDangMo = LayCaDangMo(maNV);

            if (caDangMo > 0)
                return caDangMo;

            string sql = @"
                INSERT INTO CaLamViec
                (
                    MaNV,
                    GioBatDau,
                    GioKetThuc,
                    DoanhThu,
                    SoHoaDon,
                    TrangThai
                )
                OUTPUT INSERTED.MaCa
                VALUES
                (
                    @MaNV,
                    GETDATE(),
                    NULL,
                    0,
                    0,
                    N'Đang làm'
                )";

            object result = kt.ExecuteScalar(
                sql,
                new SqlParameter[]
                {
                    new SqlParameter("@MaNV", maNV)
                });

            if (result == null || result == DBNull.Value)
                throw new Exception(
                    "Không thể tạo ca làm việc.");

            return Convert.ToInt32(result);
        }

        // =========================================================
        // GÁN CA HIỆN TẠI CHO SESSION
        // =========================================================
        public static void KhoiTaoCaHienTai()
        {
            if (Session.MaNV <= 0)
                throw new Exception(
                    "Session.MaNV chưa được xác định.");

            int maCa = MoCa(Session.MaNV);

            Session.MaCa = maCa;
        }

        // =========================================================
        // LẤY DOANH THU CA
        // =========================================================
        public static decimal LayDoanhThuCa(int maCa)
        {
            string sql = @"
                SELECT ISNULL(SUM(TongTien), 0)
                FROM HoaDon
                WHERE MaCa = @MaCa
                  AND TrangThaiDonHang = N'Hoàn thành'";

            object result = kt.ExecuteScalar(
                sql,
                new SqlParameter[]
                {
                    new SqlParameter("@MaCa", maCa)
                });

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToDecimal(result);
        }

        // =========================================================
        // SỐ HÓA ĐƠN TRONG CA
        // =========================================================
        public static int LaySoHoaDonCa(int maCa)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM HoaDon
                WHERE MaCa = @MaCa
                  AND TrangThaiDonHang = N'Hoàn thành'";

            object result = kt.ExecuteScalar(
                sql,
                new SqlParameter[]
                {
                    new SqlParameter("@MaCa", maCa)
                });

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToInt32(result);
        }
    }
}
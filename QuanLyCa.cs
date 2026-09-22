using System;
using System.Data;
using System.Data.SqlClient;

namespace SPORTSHOP
{
    /// <summary>
    /// Quản lý ca linh hoạt.
    /// Không còn ca 1/2/3 cố định và không kiểm tra ±10 phút.
    /// Một nhân viên chỉ được có một ca "Đang làm" tại một thời điểm.
    /// </summary>
    public static class QuanLyCa1
    {
        public static bool KiemTraCaDangLam()
        {
            if (Session.MaNV <= 0 || Session.MaCa <= 0)
                return false;

            try
            {
                KetNoiDuLieu kt = new KetNoiDuLieu();

                string sql = @"
SELECT COUNT(1)
FROM CaLamViec
WHERE MaCa=@MaCa
  AND MaNV=@MaNV
  AND TrangThai=N'Đang làm'
  AND GioKetThuc IS NULL;";

                DataTable dt = kt.GetData(sql, new SqlParameter[]
                {
                    new SqlParameter("@MaCa", Session.MaCa),
                    new SqlParameter("@MaNV", Session.MaNV)
                });

                bool dangLam = dt.Rows.Count > 0 &&
                               Convert.ToInt32(dt.Rows[0][0]) > 0;

                if (!dangLam)
                    Session.MaCa = 0;

                return dangLam;
            }
            catch
            {
                return false;
            }
        }

        public static bool KiemTraCaDangLam(SqlConnection conn, SqlTransaction tran)
        {
            if (Session.MaNV <= 0 || Session.MaCa <= 0)
                return false;

            using (SqlCommand cmd = new SqlCommand(@"
SELECT COUNT(1)
FROM CaLamViec WITH (UPDLOCK, HOLDLOCK)
WHERE MaCa=@MaCa
  AND MaNV=@MaNV
  AND TrangThai=N'Đang làm'
  AND GioKetThuc IS NULL;", conn, tran))
            {
                cmd.Parameters.Add("@MaCa", SqlDbType.Int).Value = Session.MaCa;
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = Session.MaNV;
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        /// <summary>
        /// Mở một ca mới ngay tại thời điểm gọi.
        /// Nếu nhân viên đang có ca thì không mở thêm ca thứ hai.
        /// </summary>
        public static bool MoCaMoi(out int maCaMoi, out string thongBao)
        {
            maCaMoi = 0;
            thongBao = "";

            if (Session.MaNV <= 0)
            {
                thongBao = "Chưa xác định được nhân viên đang đăng nhập.";
                return false;
            }

            try
            {
                KetNoiDuLieu kt = new KetNoiDuLieu();
                using (SqlConnection conn = kt.GetConnection())
                {
                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand check = new SqlCommand(@"
SELECT TOP 1 MaCa
FROM CaLamViec WITH (UPDLOCK, HOLDLOCK)
WHERE MaNV=@MaNV
  AND TrangThai=N'Đang làm'
  AND GioKetThuc IS NULL
ORDER BY MaCa DESC;", conn, tran))
                            {
                                check.Parameters.Add("@MaNV", SqlDbType.Int).Value = Session.MaNV;
                                object dangLam = check.ExecuteScalar();

                                if (dangLam != null && dangLam != DBNull.Value)
                                {
                                    maCaMoi = Convert.ToInt32(dangLam);
                                    Session.MaCa = maCaMoi;
                                    tran.Commit();
                                    thongBao = "Nhân viên đang có một ca làm việc.";
                                    return true;
                                }
                            }

                            using (SqlCommand insert = new SqlCommand(@"
INSERT INTO CaLamViec
(
    MaNV,
    GioBatDau,
    GioKetThuc,
    DoanhThu,
    SoHoaDon,
    TrangThai
)
VALUES
(
    @MaNV,
    GETDATE(),
    NULL,
    0,
    0,
    N'Đang làm'
);

SELECT CAST(SCOPE_IDENTITY() AS INT);", conn, tran))
                            {
                                insert.Parameters.Add("@MaNV", SqlDbType.Int).Value = Session.MaNV;
                                maCaMoi = Convert.ToInt32(insert.ExecuteScalar());
                            }

                            tran.Commit();
                            Session.MaCa = maCaMoi;
                            thongBao = "Đã mở ca mới.";
                            return true;
                        }
                        catch
                        {
                            try { tran.Rollback(); } catch { }
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                thongBao = "Không thể mở ca mới.\r\n\r\n" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Chốt ca hiện tại tại đúng thời điểm bấm xác nhận.
        /// Không giới hạn giờ và không phụ thuộc ca cố định.
        /// </summary>
        public static bool ChotCaHienTai(out string thongBao, bool yeuCauXacNhan = true)
        {
            thongBao = "";

            if (Session.MaNV <= 0 || Session.MaCa <= 0)
            {
                thongBao = "Nhân viên chưa có ca đang làm.";
                return false;
            }

            try
            {
                KetNoiDuLieu kt = new KetNoiDuLieu();

                using (SqlConnection conn = kt.GetConnection())
                {
                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            int soDong;

                            using (SqlCommand cmd = new SqlCommand(@"
UPDATE CaLamViec
SET GioKetThuc=GETDATE(),
    TrangThai=N'Đã chốt'
WHERE MaCa=@MaCa
  AND MaNV=@MaNV
  AND TrangThai=N'Đang làm'
  AND GioKetThuc IS NULL;", conn, tran))
                            {
                                cmd.Parameters.Add("@MaCa", SqlDbType.Int).Value = Session.MaCa;
                                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = Session.MaNV;
                                soDong = cmd.ExecuteNonQuery();
                            }

                            if (soDong != 1)
                            {
                                tran.Rollback();
                                Session.MaCa = 0;
                                thongBao = "Ca hiện tại không còn ở trạng thái Đang làm.";
                                return false;
                            }

                            tran.Commit();

                            int maCaCu = Session.MaCa;
                            Session.MaCa = 0;

                            thongBao =
                                "Đã chốt ca thành công.\r\n\r\n" +
                                "Mã ca: " + maCaCu + "\r\n" +
                                "Thời điểm kết thúc: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                            return true;
                        }
                        catch
                        {
                            try { tran.Rollback(); } catch { }
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                thongBao = "Không thể chốt ca.\r\n\r\n" + ex.Message;
                return false;
            }
        }

        public static string ThongBaoChuaCoCa()
        {
            if (Session.MaNV <= 0)
                return "Chưa xác định được nhân viên đang đăng nhập.";

            if (Session.MaCa <= 0)
                return "Nhân viên chưa vào ca hoặc ca đã kết thúc.";

            return "Ca hiện tại không còn ở trạng thái Đang làm.";
        }

        // Tương thích với code cũ nếu nơi nào còn gọi.
        public static void TuDongChotCaNeuHetGio()
        {
            // Không còn tự động chốt theo giờ vì ca đã chuyển sang mô hình linh hoạt.
        }

        // Tương thích với code cũ. Không còn khái niệm ca 1/2/3 cố định.
        public static string TenCa(DateTime gioBatDau)
        {
            return "Ca linh hoạt";
        }

        public static DateTime GioKetThucDuKien(DateTime gioBatDau)
        {
            return DateTime.MaxValue;
        }

        public static bool LayCaHienTai(
            out int maCa,
            out DateTime gioBatDau,
            out DateTime gioKetThucDuKien,
            out string tenCa,
            out decimal doanhThu,
            out int soHoaDon)
        {
            maCa = 0;
            gioBatDau = DateTime.MinValue;
            gioKetThucDuKien = DateTime.MaxValue;
            tenCa = "Ca linh hoạt";
            doanhThu = 0;
            soHoaDon = 0;

            if (!KiemTraCaDangLam())
                return false;

            try
            {
                KetNoiDuLieu kt = new KetNoiDuLieu();

                string sql = @"
SELECT TOP 1
    MaCa,
    GioBatDau,
    ISNULL(DoanhThu,0) AS DoanhThu,
    ISNULL(SoHoaDon,0) AS SoHoaDon
FROM CaLamViec
WHERE MaCa=@MaCa
  AND MaNV=@MaNV
  AND TrangThai=N'Đang làm'
  AND GioKetThuc IS NULL;";

                DataTable dt = kt.GetData(sql, new SqlParameter[]
                {
                    new SqlParameter("@MaCa", Session.MaCa),
                    new SqlParameter("@MaNV", Session.MaNV)
                });

                if (dt.Rows.Count == 0)
                {
                    Session.MaCa = 0;
                    return false;
                }

                DataRow r = dt.Rows[0];
                maCa = Convert.ToInt32(r["MaCa"]);
                gioBatDau = Convert.ToDateTime(r["GioBatDau"]);
                doanhThu = Convert.ToDecimal(r["DoanhThu"]);
                soHoaDon = Convert.ToInt32(r["SoHoaDon"]);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

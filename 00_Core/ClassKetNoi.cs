using System;
using System.Data;
using System.Data.SqlClient;

namespace SPORTSHOP
{
    public class KetNoiDuLieu
    {
        // =========================================================
        // CONNECTION STRING
        // =========================================================
        private readonly string connectionString;


        // =========================================================
        // KHỞI TẠO - TỰ NHẬN DIỆN MÁY
        // =========================================================
        public KetNoiDuLieu()
        {
            string tenMay = Environment.MachineName.ToUpper();

            // =====================================================
            // MÁY CỦA BẠN
            // DESKTOP-6RDD0K1\Duy
            // Database: ShopTheThao
            // =====================================================
            if (tenMay == "DESKTOP-6RDD0K1")
            {
                connectionString =
                    @"Data Source=DESKTOP-6RDD0K1\Duy;
                      Initial Catalog=ShopTheThao;
                      Integrated Security=True;
                      TrustServerCertificate=True;
                      Connect Timeout=5";
            }


            // =====================================================
            // MÁY DƯƠNG
            // DESKTOP-DJG8DC1\SQLEXPRESS
            // Database: ShopTheThao
            // =====================================================
            else if (tenMay == "DESKTOP-DJG8DC1")
            {
                connectionString =
                    @"Data Source=DESKTOP-DJG8DC1\SQLEXPRESS;
                      Initial Catalog=ShopTheThao;
                      Integrated Security=True;
                      TrustServerCertificate=True;
                      Connect Timeout=5";
            }


            // =====================================================
            // MÁY PHÚC
            // Christpham
            // Database: ShopTheThao
            // =====================================================
            else if (tenMay == "CHRISTPHAM")
            {
                connectionString =
                    @"Data Source=Christpham;
                      Initial Catalog=ShopTheThao;
                      Integrated Security=True;
                      TrustServerCertificate=True;
                      Connect Timeout=5";
            }


            // =====================================================
            // MÁY ĐỨC
            // DESKTOP-JIBUFFU\SQLEXPRESS
            // Database: SPORTSHOP
            // =====================================================
            else if (tenMay == "DESKTOP-JIBUFFU")
            {
                connectionString =
                    @"Data Source=DESKTOP-JIBUFFU\SQLEXPRESS;
                      Initial Catalog=SPORTSHOP;
                      Integrated Security=True;
                      Encrypt=True;
                      TrustServerCertificate=True;
                      Connect Timeout=5";
            }


                  

            // =====================================================
            // KHÔNG NHẬN DIỆN ĐƯỢC MÁY
            // =====================================================
            else
            {
                throw new Exception(
                    "Không nhận diện được máy đang chạy SPORTSHOP.\n\n" +
                    "Tên máy hiện tại: " +
                    Environment.MachineName +
                    "\n\n" +
                    "Hãy thêm tên máy vào KetNoiDuLieu.cs."
                );
            }
        }


        // =========================================================
        // LẤY KẾT NỐI
        // =========================================================
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }


        // =========================================================
        // TEST KẾT NỐI
        // =========================================================
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        // =========================================================
        // SELECT
        // =========================================================
        public DataTable GetData(
            string sql,
            SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                using (SqlDataAdapter adapter =
                    new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }


        // =========================================================
        // INSERT / UPDATE / DELETE
        // =========================================================
        public int Execute(
            string sql,
            SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                return cmd.ExecuteNonQuery();
            }
        }


        // =========================================================
        // SELECT TRẢ VỀ 1 GIÁ TRỊ
        // =========================================================
        public object ExecuteScalar(
            string sql,
            SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                return cmd.ExecuteScalar();
            }
        }
    }
}
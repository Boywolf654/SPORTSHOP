using System;
using System.Data;
using System.Data.SqlClient;

namespace SPORTSHOP
{
   
        public class KetNoiDuLieu
        {
            private string connectionString =
                @"Data Source=DESKTOP-6RDD0K1\Duy;
              Initial Catalog=ShopTheThao;
              Integrated Security=True;
              TrustServerCertificate=True";

            // Lấy kết nối
            public SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }

            // SELECT
            public DataTable GetData(string sql, SqlParameter[] parameters = null)
            {
                DataTable dt = new DataTable();

                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }

                return dt;
            }

            // INSERT / UPDATE / DELETE
            public int Execute(string sql, SqlParameter[] parameters = null)
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteNonQuery();
                }
            }

            // SELECT trả về 1 giá trị
            public object ExecuteScalar(string sql, SqlParameter[] parameters = null)
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteScalar();
                }
            }
        }
    }

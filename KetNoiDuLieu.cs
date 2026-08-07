using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPORTSHOP
{
    //class ket noi du lieu
    public class KetNoiDuLieu
    {
        KetNoiDuLieu kn = new KetNoiDuLieu();
        string strconn = "Data Source = DESKTOP - AOGCINN; InitialCatalog = ShopTheThao; IntegratedSecurity = True; TrustServerCertificate=True";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataTable dt = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        bool flag = true;
        public static string TK = "";
    }
}

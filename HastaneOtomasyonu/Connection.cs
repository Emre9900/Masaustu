using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneOtomasyonu
{
    public class Connection
    {
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=EMREE\\SQLEXPRESS;Initial Catalog=HastaneOtomasyonu;Integrated Security=True;");
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.DataAccessLayer
{
    class Connector
    {
        //private static readonly string USERNAME = "DB_A15DA9_termin4_admin",
        //                               PASSWORD = "Termin41337",
        //                               DATABASE = "DB_A15DA9_termin4",
        //                               SERVER = "sql5030.smarterasp.net",

        //                               URL = "user id = " + USERNAME + ";" +
        //                                     "password="  + PASSWORD + ";" +
        //                                     "server= "   + SERVER   + ";" +
        //                                     "Integrated security=false;"  + // false since it's not dependant on SSIP
        //                                     "database="  + DATABASE + ";" + 
        //                                     "connection timeout=30";      

        //Baltzar local
        private static readonly string URL = "Data Source=DESKTOP-STUECFJ;Initial Catalog=tempdb;Integrated Security=True";
        private static readonly string URL2 = "Data Source=sql5030.smarterasp.net;Initial Catalog = DB_A15DA9_termin4; Persist Security Info=True;User ID = DB_A15DA9_termin4_admin; Password=Termin41337";

        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(URL);
                conn.Open();
                return conn;

            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }
    }
}

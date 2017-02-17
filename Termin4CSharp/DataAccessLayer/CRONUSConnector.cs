using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Termin4CSharp.DataAccessLayer
{
    class CRONUSConnector

    {
        private static readonly string USERNAME = "a",
                                       PASSWORD = "a",
                                       DATABASE = "Demo Database NAV(5-0)",
                                       SERVER = "EBBA-DATOR",
                                       URL = "user id = " + USERNAME + ";" +
                                             "password = " + PASSWORD + ";" +
                                             "server = " + SERVER + ";" +
                                             "integrated security = false; " +
                                             "database = " + DATABASE + ";" +
                                             "connection timeout = 30;";
                                              
            //"Data Source=EBBA-DATOR;Initial Catalog=\"Demo Database NAV(5-0)\";User ID=a;Password=a"; 

            private static string URL2 = "Data Source=EBBA-DATOR;Initial Catalog=\"Demo Database NAV(5-0)\";User ID=a;Password=a";
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(URL2);
                conn.Open();
                Console.WriteLine("Connection open!"); 
                //conn.Close(); 
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

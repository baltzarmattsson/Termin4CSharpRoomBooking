using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.DataAccessLayer
{
    class DALConnector
    {
        private static readonly string URL = ""; // CRONUS

        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(URL);
                conn.Open();
                //Console.WriteLine("Connection open!"); 
                //conn.Close(); 
                return conn;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }
    }
}

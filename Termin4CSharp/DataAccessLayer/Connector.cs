using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Termin4CSharp.DataAccessLayer
{
    class Connector
    {
   
        //Baltzar local
        private static readonly string URL = "Data Source=DESKTOP-STUECFJ;Initial Catalog=tempdb;Integrated Security=True";
             
        /// <summary>
        /// Returns a connection to the database
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(URL);
                conn.Open();
                return conn;
            }
            catch (SqlException sqle)
            {
                MessageBox.Show("Kunde inte ansluta till \"" + URL + "\", verifiera att databasen är startad och accepterar inkommande anslutningar.");
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
                Environment.Exit(0);
            }
            return null;
        }
    }
}

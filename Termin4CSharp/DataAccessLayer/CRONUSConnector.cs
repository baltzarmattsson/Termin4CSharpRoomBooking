﻿using System;
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
        
                                              
            //"Data Source=EBBA-DATOR;Initial Catalog=\"Demo Database NAV(5-0)\";User ID=a;Password=a"; 

            //private static string URL2 = "Data Source=EBBA-DATOR;Initial Catalog=\"Demo Database NAV(5-0)\";User ID=a;Password=a";
            private static string URL2 = "Data Source=sql5024.smarterasp.net;Persist Security Info=True;User ID = DB_A15DA9_cranus_admin; Password=cranus123";
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(URL2);
                conn.Open();
                Console.WriteLine("Connection open!"); 
                //*conn.Close(); 
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

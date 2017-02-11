﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.DataAccessLayer
{
    class Connector
    {
        private static readonly string USERNAME = "DB_A15DA9_termin4_admin",
                                       PASSWORD = "Termin41337",
                                       DATABASE = "DB_A15DA9_termin4",
                                       SERVER = "sql5030.smarterasp.net",

                                       URL = "user id = " + USERNAME + ";" +
                                             "password="  + PASSWORD + ";" +
                                             "server= "   + SERVER   + ";" +
                                             "Integrated security=false;"  + // false since it's not dependant on SSIP
                                             "database="  + DATABASE + ";" + 
                                             "connection timeout=30";

      public static SqlConnection getConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(URL);
                conn.Open();
                //Console.WriteLine("Connection open!"); 
                //conn.Close(); 
                return conn;
                
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString()); 
            }
            return null; 
        }
    }
}

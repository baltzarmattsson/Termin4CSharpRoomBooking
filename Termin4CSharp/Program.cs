using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Termin4CSharp.Controller;
using Termin4CSharp.DataAccessLayer;
using Termin4CSharp.Model;
using Termin4CSharp.View;

namespace Termin4CSharp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GUIMain mainGui = new GUIMain();
            GUIMainController controller = new GUIMainController(mainGui);
            AdminTabController adminController = new AdminTabController(mainGui);
            Application.Run(mainGui);

            //DALCronus dalc = new DALCronus();
            //dalc.GetRelatives();

            //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-STUECFJ;Initial Catalog=\"Demo Database NAV (5-0)\";Persist Security Info=True;User ID=admin;Password=admin");
            //SqlCommand cmd = new SqlCommand("select * from Company", connection);
            //cmd.Connection.Open();
            //var dr = cmd.ExecuteReader();
            //foreach (var FUCK in dr)
            //    Console.WriteLine();










        }
    }
}

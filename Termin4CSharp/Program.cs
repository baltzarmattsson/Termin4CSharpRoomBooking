using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Termin4CSharp.Controller;
using Termin4CSharp.DataAccessLayer;
using Termin4CSharp.Model;
using Termin4CSharp.View;

namespace Termin4CSharp {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GUIMain mainGui = new GUIMain();
            GUIMainController controller = new GUIMainController(mainGui);
            AdminTabController adminController = new AdminTabController(mainGui);
            Application.Run(mainGui);


            //DAL dal = new DAL(null);
            //dal.GetRoomsAndOpeningHours();


            //var rooms = dal.Get(new Room(), selectAll: true).Cast<Room>().ToList();
            //Utils.ConnectRoomsWithBookableTimes(rooms, DateTime.Now);
            //Console.WriteLine();
            //DALCronus dal = new DALCronus();
            //var result = dal.GetEmployees();
            //var result2 = dal.GetEmployeeAbscence();
        }
    }
}

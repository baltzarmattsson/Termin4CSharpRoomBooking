using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Termin4CSharp.Controller;
using Termin4CSharp.DataAccessLayer;
using Termin4CSharp.Model;
using Termin4CSharp.Model.DbHelpers;
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
            //Building b = new Building("bnamename2", "a", DateTime.Now, DateTime.Now, null);
            ////dal.Add(b);
            //Room r = null;
            //List<IModel> rooms = new List<IModel>();
            //for (int i = 0; i < 5; i++) {
            //    r = new Room("bnamename", "aa" + i, 15, "1", null);
            //    rooms.Add(r);
            //}
            //int aff = dal.ConnectReferencedIModelsToIModelToQuery(rooms, b);
            //Console.WriteLine(aff);

            //Person p = new Model.Person();
            //Building b = new Building();
            //var asd = b.GetReferencedModels();
            //var asd2 = p.GetReferencedModels();
            //Console.WriteLine();
            //bool bb = asd2["Role"] is Role;
            //bool bb2 = asd["Rooms"].GetType().IsGenericType;
            //Console.WriteLine();
        }
    }
}

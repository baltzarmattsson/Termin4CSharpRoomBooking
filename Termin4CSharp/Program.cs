using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Termin4CSharp.DataAccessLayer;
using Termin4CSharp.Model;

namespace Termin4CSharp {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); */


            //Connector.getConnection(); 
            Person p = new Person("Namnnn", 1337, "email@@", "+4600");
            Console.WriteLine(p);
            Building b = new Building("Buildname", "buildaddress", DateTime.Now, DateTime.Now);
            Console.WriteLine(b);
            Room r = new Room(b, "1337", 134141, 0);
            string test = Utils.IModelToQuery(null, QueryType.ADD, r, null);

        }
    }
}

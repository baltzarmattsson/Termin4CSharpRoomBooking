using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            //Person p = new Person("Namnnn", 1337, "email@@", "+4600");
            //Building b = new Building("Buildname", "buildaddress", DateTime.Now, DateTime.Now);
            //Room r = new Room(b, "1337", 134141, 0);
            Booking book = new Booking(1006, DateTime.Now, "purporse", DateTime.Now, DateTime.Now);

            //object[] toBeAddedToDb = { p, b, r, book, book, book, book };

            //foreach (IModel o in toBeAddedToDb)
            //    Utils.IModelToQuery(null, QueryType.ADD, o, null);

            book.Purpose = "new purpose";
            Dictionary<string, object> whereParams = new Dictionary<string, object>();
            whereParams["id"] = 1003;

            DAL dal = new DAL();
            dal.Add(book);
            whereParams = new Dictionary<string, object>();
            whereParams["id"] = book.Id;
            Thread.Sleep(5000);
            dal.Remove(book, whereParams);

        }
    }
}

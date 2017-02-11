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
            Person p = new Person("Namnnn", "1337", "email@@", "+4600");
            Person p2 = new Person("Namnnnp2", "1337p2", "email@@p2", "+4600p2");
            Building b = new Building("Buildname", "buildaddress", DateTime.Now, DateTime.Now);
            Building b2 = new Building("Buildnameb2", "buildaddressb2", DateTime.Now, DateTime.Now);
            Room r = new Room(b, "1337", 134141, "0");
            Room r2 = new Room(b2, "1337r2", 13414122, "0");
            Booking book = new Booking(1017, DateTime.Now, r, p, "purporse", DateTime.Now, DateTime.Now);
            Booking book2 = new Booking(1018, DateTime.Now, r2, p2, "purporse", DateTime.Now, DateTime.Now);

            object[] toBeAddedToDb = { p, p2, b, b2, r, r2, book, book, book, book, book, book, book2, book2, book2, book2, book2 };

            DAL dal = new DAL();
            foreach (IModel o in toBeAddedToDb)
                dal.Add(o);

            foreach (IModel o in toBeAddedToDb)
                dal.Get(o);

            object[] toBeDeletedFromDb = { p2, b2, r2, book2 };
            foreach (IModel o in toBeDeletedFromDb)
                dal.Remove(o);

            //var wheres = new Dictionary<string, object>();
            //wheres["id"] = "%";
            //var results = dal.Get(new Booking(), wheres, optWhereCondition: WhereCondition.LIKE);
            //var rrr = dal.Get(new Booking(), wheres, optWhereCondition: WhereCondition.LIKE);
            ////dal.Get(new Building(), wheres, optWhereCondition: WhereCondition.LIKE);
            //var ppp = dal.Get(new Person(), wheres, optWhereCondition: WhereCondition.LIKE);

            //foreach (IModel m in rrr)
            //    Console.WriteLine("a");


        }
    }
}

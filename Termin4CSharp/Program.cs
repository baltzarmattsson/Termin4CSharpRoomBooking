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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Person p2 = new Person("Namnnnp2", "1337p2", "email@@p2", "+4600p2");
            //Building b2 = new Building("Buildnameb2", "buildaddressb2", DateTime.Now, DateTime.Now);
            //DAL dal = new DAL();
            //IModel fetched;
            //if (dal.Get(b2).Count > 0)
            //    fetched = dal.Get(b2).First();
            //else
            //    fetched = b2;

            //EditView ev = new EditView(fetched);
            //EditViewController c = new EditViewController(ev);
            //Application.Run(ev);

            DAL dal = new DAL();
            Building b = new Building("Buildname", "buildaddress", DateTime.Now, DateTime.Now);
            Building b2 = new Building("Buildnameb2", "buildaddressb2", DateTime.Now, DateTime.Now);
            Building b3 = new Building("Buildnameb3", "buildaddressb2", DateTime.Now, DateTime.Now);
            Building b4 = new Building("Buildnameb4", "buildaddressb2", DateTime.Now, DateTime.Now);
            dal.Remove(b);
            dal.Remove(b2);
            dal.Remove(b3);
            dal.Remove(b4);
            dal.Add(b);
            dal.Add(b2);
            dal.Add(b3);
            dal.Add(b4);
            Room r = new Room(b, "1337", 134141, "0", null);
            Room r2 = new Room(b2, "1337r2", 13414122, "0", null);
            dal.Add(r);
            dal.Add(r2);
            dal.Add(new Room(null, "test", 123123, "123", null));

            Room asd = dal.Get(r).First() as Room;
            Console.WriteLine(asd);
            /*
            //Connector.getConnection(); 
            Person p = new Person("Namnnn", "1337", "email@@", "+4600");
            Person p2 = new Person("Namnnnp2", "1337p2", "email@@p2", "+4600p2");
            Building b = new Building("Buildname", "buildaddress", DateTime.Now, DateTime.Now);
            Building b2 = new Building("Buildnameb2", "buildaddressb2", DateTime.Now, DateTime.Now);
            //Room r = new Room(b, "1337", 134141, "0");
            //Room r2 = new Room(b2, "1337r2", 13414122, "0");
            Booking book = new Booking(1017, DateTime.Now, r, p, "purporse", DateTime.Now, DateTime.Now);
            Booking book2 = new Booking(1018, DateTime.Now, r2, p2, "purporse", DateTime.Now, DateTime.Now);

            object[] toBeAddedToDb = { p, p2, b, b2, r, r2, book, book, book, book, book, book, book2, book2, book2, book2, book2 };

            DAL dal = new DAL();
            dal.Remove(b);
            dal.Add(b);
            Building retBuild = dal.Get(b).First() as Building;
            dal.Remove(b);
            Console.WriteLine(b.Equals(retBuild));
            Console.WriteLine();

            /*
            //foreach (IModel o in toBeAddedToDb)
            //    dal.Add(o);

            //foreach (IModel o in toBeAddedToDb)
            //    dal.Get(o);

            //Console.WriteLine(dal.Get(p).First());

            //object[] toBeDeletedFromDb = { p2, b2, r2, book2 };
            //foreach (IModel o in toBeDeletedFromDb)
            //    dal.Remove(o);

            //var wheres = new Dictionary<string, object>();
            //wheres["id"] = "%";
            //var results = dal.Get(new Booking(), wheres, optWhereCondition: WhereCondition.LIKE);
            //var rrr = dal.Get(new Booking(), wheres, optWhereCondition: WhereCondition.LIKE);
            ////dal.Get(new Building(), wheres, optWhereCondition: WhereCondition.LIKE);
            //var ppp = dal.Get(new Person(), wheres, optWhereCondition: WhereCondition.LIKE);

            //foreach (IModel m in rrr)
            //    Console.WriteLine("a");
*/

        }
    }
}

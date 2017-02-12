using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Termin4CSharp.Model;
using Termin4CSharp.DataAccessLayer;

namespace Termin4CSharp.Tests {
    [TestClass]
    public class Tests {
        [TestMethod]
        public void DALAddGetUpdateRemove() {
            Person p = new Person("testname", "testid", "testemail", "testphonenbr");
            Building b = new Building("testname", "testaddress", DateTime.Now, DateTime.Now);
            Room r = new Room(b, "testid", 134141, "0");
            
            // Testing add
            DAL dal = new DAL();

            try {
                dal.Add(p);
                dal.Add(b);
                dal.Add(r);
                Person retrievedPerson = dal.Get(p).First() as Person;
                Building retrievedBuilding = dal.Get(b).First() as Building;
                Room retrievedRoom = dal.Get(r).First() as Room;
                Assert.AreEqual(retrievedPerson, p);
                Assert.AreEqual(retrievedBuilding, b);
                Assert.AreEqual(retrievedRoom, r);


                // Testing update
                p.Name = "newtestname";
                p.Email = "newtestemail";
                p.PhoneNbr = "newtestphonenbr";

                b.Address = "newtestaddress";
                b.Avail_start = DateTime.Now;
                b.Avail_end = DateTime.Now;

                r.Capacity = 55;
                r.Floor = "newfloor";

                dal.Update(p);
                dal.Update(b);
                dal.Update(r);
                retrievedPerson = dal.Get(p).First() as Person;
                retrievedBuilding = dal.Get(b).First() as Building;
                retrievedRoom = dal.Get(r).First() as Room;
                Assert.AreEqual(retrievedPerson, p);
                Assert.AreEqual(retrievedBuilding, b);
                Assert.AreEqual(retrievedRoom, r);
            } finally {
                // Testing remove
                dal.Remove(p);
                dal.Remove(b);
                dal.Remove(r);
                Assert.AreEqual(dal.Get(p).Count, 0);
                Assert.AreEqual(dal.Get(b).Count, 0);
                Assert.AreEqual(dal.Get(r).Count, 0);
        }

    }

    }
}

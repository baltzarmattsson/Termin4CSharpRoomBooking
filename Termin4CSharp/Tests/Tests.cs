using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Termin4CSharp.Model;
using Termin4CSharp.DataAccessLayer;
using Termin4CSharp.Model.DbHelpers;

namespace Termin4CSharp.Tests {
    [TestClass]
    public class Tests {
        [TestMethod]
        public void DALAddGetUpdateRemove() {
            Person p = new Person("testname", "testid", "testemail", "testphonenbr", null);
            Building b = new Building("testname", "testaddress", DateTime.Now, DateTime.Now, null);
            //RoomType rt = new RoomType(113377, "testtype");
            Room r = new Room(b.Name, "testid", 134141, "0", null);
            r.Building = b;
            var rooms = new List<Room>();
            rooms.Add(r);
            b.Rooms = rooms;
            // Testing add
            DAL dal = new DAL(null);

            try {
                dal.Add(p);
                dal.Add(b);
                dal.Add(r);
                Person retrievedPerson = dal.GetIModel(p) as Person;
                Building retrievedBuilding = dal.GetIModel(b) as Building;
                Room retrievedRoom = dal.GetIModel(r) as Room;
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

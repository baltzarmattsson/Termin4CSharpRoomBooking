using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Termin4CSharp.Model;
using Termin4CSharp.DataAccessLayer;

namespace Termin4CSharp.Tests {
    [TestClass]
    public class Tests {
        [TestMethod]
        public void DALAddGetUpdateRemove() {
            Person p = new Person("testname", "testid", "testemail", "testphonenbr", null);
            Building b = new Building("testname", "testaddress", DateTime.Now, DateTime.Now, null);
            RoomType rt = new RoomType("testtype");
            Room r = new Room(b.Name, "testid", 134141, "0", "testtype");
            Login l = new Login("testid", "testpass");

            DAL dal = new DAL(null);
            IModel[] imodels = new IModel[] { p, b, rt, r, l };

            try {
                //Testing add
                foreach (IModel model in imodels)
                    dal.Add(model);

                Person retrievedPerson = dal.GetIModel(p) as Person;
                Building retrievedBuilding = dal.GetIModel(b) as Building;
                RoomType retrievedRoomType = dal.GetIModel(rt) as RoomType;
                Room retrievedRoom = dal.GetIModel(r) as Room;
                Login retrievedLogin = dal.GetIModel(l) as Login;

                Assert.AreEqual(retrievedPerson, p);
                Assert.AreEqual(retrievedBuilding, b);
                Assert.AreEqual(retrievedRoomType, rt);
                Assert.AreEqual(retrievedRoom, r);
                Assert.AreEqual(retrievedLogin, l);

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
                //Testing remove
                dal.Remove(p);
                dal.Remove(b);
                dal.Remove(r);
                foreach (IModel model in imodels)
                    dal.Remove(model);

                foreach (IModel model in imodels)
                    Assert.AreEqual(dal.Get(model).Count, 0);
                Assert.AreEqual(dal.Get(p).Count, 0);
                Assert.AreEqual(dal.Get(b).Count, 0);
                Assert.AreEqual(dal.Get(r).Count, 0);
            }

        }

    }
}

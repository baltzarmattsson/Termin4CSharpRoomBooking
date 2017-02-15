using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin4CSharp.DataAccessLayer;
using Termin4CSharp.Model;
using Termin4CSharp.View;

namespace Termin4CSharp.Controller {

    public class GUIMainController : IController {

        public GUIMain GUIMain { get; set; }


        public GUIMainController(GUIMain guiMain) {
            this.GUIMain = guiMain;
            this.GUIMain.Controller = this;
            this.LoadRooms();
            this.LoadFilters();
        }

        public void LoadRooms() {
            DAL dal = new DAL();
            var whereParams = new Dictionary<string, object>();
            whereParams["1"] = 1;
            var rooms = dal.Get(new Room(), whereParams).Cast<Room>().ToList();
            Console.WriteLine(rooms.Count);
            this.GUIMain.SetRooms(rooms);
        }

        public void LoadFilters() {
            DAL dal = new DAL();
            var whereParams = new Dictionary<string, object>();
            whereParams["1"] = 1;
            var rooms = dal.Get(new Room(), whereParams).Cast<Room>().ToList();
            var buildings = dal.Get(new Building(), whereParams).Cast<Building>().ToList();
            var resources = dal.Get(new Resource(), whereParams).Cast<Resource>().ToList();

            this.GUIMain.SetRoomFilters(rooms);
            this.GUIMain.SetBuildingFilters(buildings);
            this.GUIMain.SetResourceFilters(resources);

        }

        public void NotifyExceptionToView() {
            throw new NotImplementedException();
        }
    }
}

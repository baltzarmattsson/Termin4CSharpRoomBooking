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
            this.HandleFilterChange();
        }

        public void LoadRooms() {
            DAL dal = new DAL();
            var whereParams = new Dictionary<string, object>();
            // TODO fixa IModelToQuery att hämta alla attribut ifall det är en GET-query, och ifall deti nte finns
            // några where-params och IModel inte innehåller ett ID-attribut (dvs är en new IModel() av något slag)
            whereParams["1"] = 1;
            var rooms = dal.Get(new Room(), whereParams).Cast<Room>().ToList();
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

        public void HandleFilterChange() {
            var buildingFilters = this.GUIMain.GetBuildingFilters();
            var roomFilters = this.GUIMain.GetRoomFilters();
            var resourceFilters = this.GUIMain.GetResourceFilters();
            var freeTextFilter = this.GUIMain.GetTextFilter();

            DAL dal = new DAL();
            List<Room> filteredRooms = dal.FindRoomsWithFilters(buildingFilters, roomFilters, resourceFilters);
            this.GUIMain.SetRooms(filteredRooms);

            /*
            "select * from Room r where r.bName in ('Buildname') and r.id like '13%' and r.id in 

(select id from Room_Resource where resource in ('Handikappwc'))"" obs skapa Room_Resource på nytt*/
        }
    }
}

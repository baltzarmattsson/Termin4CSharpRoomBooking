using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Termin4CSharp.DataAccessLayer;
using Termin4CSharp.Model;
using Termin4CSharp.View;

namespace Termin4CSharp.Controller {

    public class GUIMainController : IController {

        public GUIMain GUIMain { get; set; }
        List<string> buildingFilters, roomFilters, resourceFilters;


        public GUIMainController(GUIMain guiMain) {
            this.GUIMain = guiMain;
            this.GUIMain.Controller = this;
            this.LoadRooms();
            this.LoadFilters();
            buildingFilters = new List<string>();
            roomFilters = new List<string>();
            resourceFilters = new List<string>();
        }

        public void LoadRooms() {
            DAL dal = new DAL();
            var rooms = dal.Get(new Room(), selectAll: true).Cast<Room>().ToList();
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
        public enum FilterBox {
            BUILDING, ROOM, RESOURCE
        }
        public void HandleFilterChange(FilterBox filterBox, CheckedListBox sender, ItemCheckEventArgs e) {

            List<string> selectedList = null;
            switch (filterBox) {
                case FilterBox.BUILDING:
                    selectedList = this.buildingFilters;
                    break;
                case FilterBox.ROOM:
                    selectedList = this.roomFilters;
                    break;
                case FilterBox.RESOURCE:
                    selectedList = this.resourceFilters;
                    break;
            }
            string selval = (string)sender.SelectedItem;
            if (e.NewValue == CheckState.Checked)
                selectedList.Add((string)sender.SelectedItem);
            else if (e.NewValue == CheckState.Unchecked)
                selectedList.Remove((string)sender.SelectedItem);


            //var buildingFilters = this.GUIMain.GetBuildingFilters();
            //var roomFilters = this.GUIMain.GetRoomFilters();
            //var resourceFilters = this.GUIMain.GetResourceFilters();
            //var freeTextFilter = this.GUIMain.GetTextFilter();

            DAL dal = new DAL();
            List<Room> filteredRooms = dal.FindRoomsWithFilters(buildingFilters, roomFilters, resourceFilters);
            this.GUIMain.SetRooms(filteredRooms);

            /*
            "select * from Room r where r.bName in ('Buildname') and r.id like '13%' and r.id in 

(select id from Room_Resource where resource in ('Handikappwc'))"" obs skapa Room_Resource på nytt*/
        }
    }
}

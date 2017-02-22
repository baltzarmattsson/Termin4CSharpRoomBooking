using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Termin4CSharp.DataAccessLayer;
using Termin4CSharp.Model;
using Termin4CSharp.View;
using System.Text.RegularExpressions;

namespace Termin4CSharp.Controller {

    public class GUIMainController : IController {

        public GUIMain GUIMain { get; set; }
        private List<string> buildingFilters, roomFilters, resourceFilters;
        public Person LoggedInUser { get; private set; }

        public int MinCapacity { get; set; }

        public GUIMainController(GUIMain guiMain) {
            this.GUIMain = guiMain;
            this.GUIMain.Controller = this;
            this.LoadRooms();
            this.LoadFilters();
            buildingFilters = new List<string>();
            roomFilters = new List<string>();
            resourceFilters = new List<string>();

            this.LoginUser("1", "1");
        }
        public void LoginUser(string username, string password) {
            if (this.LoggedInUser != null)
                this.LoggedInUser = null;
            Login login = new Login(username, password);
            DAL dal = new DAL(this);
            var whereParams = new Dictionary<string, object>();
            whereParams["password"] = password;
            List<IModel> result = dal.Get(login, whereParams);
            if (result.Any()) {
                Person tempHolder = new Person();
                tempHolder.Id = username;
                this.LoggedInUser = dal.Get(tempHolder).First() as Person;

                this.GUIMain.SetLoginResponseLabelText("Logged in as " + this.LoggedInUser.Name + " " + this.LoggedInUser.Id);
                if (String.IsNullOrEmpty(LoggedInUser.RoleName) == false) {
                    // Getting the role of the user
                    Role tempRoleObject = new Role(LoggedInUser.RoleName);
                    this.LoggedInUser.Role = dal.Get(tempRoleObject).First() as Role;
                }
            }
        }
        public void LoadRooms() {
            DAL dal = new DAL(this);
            var rooms = dal.Get(new Room(), selectAll: true).Cast<Room>().ToList();
            //rooms.Select(x => x.Bookable = dal.FindBookableTimesForRoom(x));
            foreach (Room r in rooms) {
                var bookable = dal.FindBookableTimesForRoom(r);
                //Console.WriteLine(String.Join(", ", bookable));
                r.Bookable = bookable;
            }
            this.GUIMain.SetRooms(rooms);
        }

        public void LoadFilters() {
            DAL dal = new DAL(this);
            var rooms = dal.Get(new Room(), selectAll: true).Cast<Room>().ToList();
            var buildings = dal.Get(new Building(), selectAll: true).Cast<Building>().ToList();
            var resources = dal.Get(new Resource(), selectAll: true).Cast<Resource>().ToList();

            int highestCapacity = rooms.Any() ? rooms.Max(x => x.Capacity) : 10;

            this.GUIMain.SetRoomFilters(rooms);
            this.GUIMain.SetBuildingFilters(buildings);
            this.GUIMain.SetResourceFilters(resources);
            this.GUIMain.SetMinCapacityFilter(highestCapacity);

        }

        public void NotifyExceptionToView() {
            throw new NotImplementedException();
        }
        public enum FilterBox {
            BUILDING, ROOM, RESOURCE, TRACKBAR
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
                case FilterBox.TRACKBAR:
                    this.MinCapacity = this.GUIMain.GetMinCapacityFilterValue();
                    break;

            }
            if (filterBox != FilterBox.TRACKBAR) {
                string selval = (string)sender.SelectedItem;
                if (e.NewValue == CheckState.Checked)
                    selectedList.Add(selval);
                else if (e.NewValue == CheckState.Unchecked)
                    selectedList.Remove(selval);
            }

            // TODO skapa en thread som väntar 0.5s tills man söker och stackar inte sökningar på varandra



            DAL dal = new DAL(this);
            List<Room> filteredRooms = dal.FindRoomsWithFilters(buildingFilters, roomFilters, resourceFilters, minCapacity: MinCapacity);
            this.GUIMain.SetRooms(filteredRooms);
        }

        private delegate List<Room> findFilteredRoomsDelegate(List<string> buildingNames, List<string> roomIDs, List<string> resourceNames, string freeText = null, int minCapacity = 0);

        public void HandleFreeTextFilterChange(TextBox sender, EventArgs e) {

            ObjectListView roomHolder = this.GUIMain.GetRoomHolder();
            roomHolder.ModelFilter = TextMatchFilter.Contains(roomHolder, sender.Text);


            //DAL dal = new DAL(this);
            //List<Room> filteredRooms = dal.FindRoomsWithFilters(null, null, null, sender.Text);
            //this.ClearFilterSelections();
            //this.GUIMain.SetRooms(filteredRooms);
        }

        public void ClearFilterSelections() {
            this.GUIMain.ClearFilterSelections();
        }

        public void NotifyExceptionToView(string s) {
            throw new NotImplementedException();
        }

        public void HandleCellDoubleClick(object sender, CellClickEventArgs e) {
            if (e.ColumnIndex > 4) {
                e.SubItem.BackColor = System.Drawing.Color.Yellow;
                if (e.ClickCount == 2) {
                    string itemText = e.SubItem.Text;
                    if (Regex.IsMatch(itemText, "[0-9]{2}:[0-9]{2}")) {
                        Room targetRoom = (Room)e.Model;
                        Booking b = new Booking();
                        b.RoomId = targetRoom.Id;
                        b.PersonId = this.LoggedInUser.Id;
                        b.Start_time = DateTime.Parse(e.SubItem.Text);
                        b.End_time = b.Start_time.AddHours(1);
                        EditView ev = new EditView(b, false);
                        EditViewController editController = null;
                        editController = new EditViewController(ev, null);
                        ev.Show();
                    }
                }
            }
        }
    }
}

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
using System.Web.Services;
using System.Net;

namespace Termin4CSharp.Controller
{

    public class GUIMainController : IController
    {

        public GUIMain GUIMain { get; set; }
        private HashSet<string> buildingFilters, roomFilters, resourceFilters;
        public DateTime OnDateFilter { get; private set; }

        public Person LoggedInUser { get; private set; }

        public int MinCapacity { get; set; }

        public GUIMainController(GUIMain guiMain)
        {
            this.GUIMain = guiMain;
            this.GUIMain.Controller = this;
            this.LoadRooms(DateTime.Now);
            this.LoadFilters();
            buildingFilters = new HashSet<string>();
            roomFilters = new HashSet<string>();
            resourceFilters = new HashSet<string>();
            OnDateFilter = DateTime.Now;
            
            this.AutosizeColumns();
            this.HandleAdminTabBasedOnUserRole();

            this.LoadErpAndWsComboBoxes();
        }

        private void HandleAdminTabBasedOnUserRole()
        {
            if (this.LoggedInUser != null && this.LoggedInUser.RoleName != null)
            {
                if (this.LoggedInUser.RoleName.Equals("Admin"))
                    this.GUIMain.SetAdminTabEnabled(true);
                else
                    this.GUIMain.SetAdminTabEnabled(false);
            }
            else
            {
                this.GUIMain.SetAdminTabEnabled(false);
            }
        }

        private void LoginUser(string username, string password)
        {
            if (this.LoggedInUser != null)
                this.LoggedInUser = null;
            Login login = new Login(username, password);
            DAL dal = new DAL(this);
            var whereParams = new Dictionary<string, object>();
            whereParams["password"] = password;
            List<IModel> result = dal.Get(login, whereParams);
            if (result.Any())
            {
                Person tempHolder = new Person();
                tempHolder.Id = username;
                this.LoggedInUser = dal.Get(tempHolder).First() as Person;

                this.GUIMain.SetLoginResponseLabelText("Inloggad som " + this.LoggedInUser.Name + " " + this.LoggedInUser.Id);
                this.GUIMain.UpdateRoomBookingLabel("Inloggad som " + this.LoggedInUser.Name + " " + this.LoggedInUser.Id);
                this.GUIMain.SetAdminTabEnabled(true);
                if (String.IsNullOrEmpty(LoggedInUser.RoleName) == false)
                {
                    // Getting the role of the user
                    Role tempRoleObject = new Role(LoggedInUser.RoleName);
                    this.LoggedInUser.Role = dal.Get(tempRoleObject).First() as Role;
                }
                this.SetLoginControlsToStatus(false);
            } else
            {
                this.GUIMain.SetLoginResponseLabelText("Felaktig inloggning, vänligen försök igen");
            }
            this.HandleAdminTabBasedOnUserRole();
        }

        private void LogoutUser()
        {
            this.LoggedInUser = null;
            this.GUIMain.SetFocusOnFirstTab();
            this.GUIMain.SetLoginResponseLabelText("Utloggad");
            this.GUIMain.UpdateRoomBookingLabel("");
            this.GUIMain.SetAdminTabEnabled(false);
            this.SetLoginControlsToStatus(true);
        }

        private void SetLoginControlsToStatus(bool enabled)
        {
            this.GUIMain.SetLoginControlsToStatus(enabled);
        }

        public void HandleLoginOrLogoutButtonClick(Button loginButton, string username, string password)
        {
            this.NotifyExceptionToView("");
            if (loginButton.Text.Equals("Logga in"))
            {
                this.LoginUser(username, password);
            }
            else if (loginButton.Text.Equals("Logga ut"))
            {
                this.LogoutUser();
            }
        }

        public void LoadRooms(DateTime onDate)
        {
            DAL dal = new DAL(this);
            List<Room> rooms = dal.FindRoomsWithOptionalFiltersOnDate(onDate);
            this.GUIMain.SetRooms(rooms);
        }

        public void LoadFilters()
        {
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

        public enum FilterControl
        {
            BUILDING_BOX, ROOM_BOX, RESOURCE_BOX, MIN_CAPACITY_TRACKBAR, ON_DATE_DATE_PICKER
        }
        public void HandleFilterChange(FilterControl filterControl, object sender, EventArgs e)
        {

            HashSet<string> selectedList = null;
            switch (filterControl)
            {
                case FilterControl.BUILDING_BOX:
                    selectedList = this.buildingFilters;
                    break;
                case FilterControl.ROOM_BOX:
                    selectedList = this.roomFilters;
                    break;
                case FilterControl.RESOURCE_BOX:
                    selectedList = this.resourceFilters;
                    break;
                case FilterControl.MIN_CAPACITY_TRACKBAR:
                    this.MinCapacity = ((TrackBar)sender).Value;
                    break;
                case FilterControl.ON_DATE_DATE_PICKER:
                    this.OnDateFilter = ((DateTimePicker)sender).Value;
                    break;

            }
            if (filterControl != FilterControl.ON_DATE_DATE_PICKER && filterControl != FilterControl.MIN_CAPACITY_TRACKBAR)
            {
                string selval = (string)((CheckedListBox)sender).SelectedItem;
                if (selval != null)
                {
                    if (((ItemCheckEventArgs)e).NewValue == CheckState.Checked)
                        selectedList.Add(selval);
                    else if (((ItemCheckEventArgs)e).NewValue == CheckState.Unchecked)
                        selectedList.Remove(selval);
                }
            }           
            DAL dal = new DAL(this);
            List<Room> filteredRooms = dal.FindRoomsWithOptionalFiltersOnDate(OnDateFilter, buildingFilters, roomFilters, resourceFilters, minCapacity: MinCapacity);
            this.GUIMain.SetRooms(filteredRooms);
        }

        public void HandleFreeTextFilterChange(TextBox sender, EventArgs e)
        {
            DAL dal = new DAL(this);
            List<Room> filteredRooms = dal.FindRoomsWithOptionalFiltersOnDate(this.OnDateFilter, freeText: sender.Text);
            this.ClearFilterSelections();
            this.GUIMain.SetRooms(filteredRooms);
            ObjectListView roomHolder = this.GUIMain.GetRoomHolder();
            roomHolder.ModelFilter = TextMatchFilter.Contains(roomHolder, sender.Text);
        }

        public void ClearFilterSelections()
        {
            this.buildingFilters.Clear();
            this.resourceFilters.Clear();
            this.roomFilters.Clear();
            this.MinCapacity = 0;
            this.GUIMain.ClearFilterSelections();
        }

        public void NotifyExceptionToView(string s)
        {
            this.GUIMain.SetPKResponseLabelText(s);
        }

        public void HandleCellDoubleClick(object sender, CellClickEventArgs e)
        {
            if (e.ColumnIndex > 4)
            {
                e.SubItem.BackColor = System.Drawing.Color.Yellow;
                if (e.ClickCount == 2 && this.LoggedInUser != null)
                {
                    string itemText = e.SubItem.Text;
                    if (Regex.IsMatch(itemText, "[0-9]{2}:[0-9]{2}"))
                    {
                        // Updating logged in user
                        this.LoggedInUser = (Person)new DAL(this).Get(LoggedInUser).First();
                        Room targetRoom = (Room)e.Model;
                        Booking b = new Booking();
                        b.RoomId = targetRoom.Id;
                        b.PersonId = this.LoggedInUser.Id;
                        DateTime parsedDate = DateTime.Parse(e.SubItem.Text);
                        DateTime startDate = new DateTime(OnDateFilter.Year, OnDateFilter.Month, OnDateFilter.Day, parsedDate.Hour, parsedDate.Minute, 0);
                        b.Start_time = startDate;
                        b.End_time = b.Start_time.AddHours(1);
                        EditView ev = new EditView(b, false);
                        EditViewController editController = new EditViewController(ev, guiMainController: this);
                        ev.Show();
                    }
                }
                else if (this.LoggedInUser == null)
                {
                    this.NotifyExceptionToView("Vänligen logga in för att boka rum");
                }
            }
        }

        private void LoadErpAndWsComboBoxes()
        {
            try
            {
                localhost.WebService proxy = new localhost.WebService();
                string[] wsMethods = proxy.GetTableNames();
                string[] erpQueries = proxy.GetErpQueries();
                this.GUIMain.SetWebserviceAndErpComboBoxValues(wsMethods, erpQueries);
            } catch (WebException we)
            {
                this.HandleWebserviceException(we);
            }
        }

        public void HandleChooseFileWSClick(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            OpenFileDialog ofd = new OpenFileDialog();

            localhost.WebService proxy = new localhost.WebService();

            ofd.Filter = "Text Fil (.txt)|*.txt";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string content = proxy.GetFileContent(ofd.FileName).Replace("\n", "\r\n");
                this.GUIMain.SetFileContentWS(content);
            }
        }

        private void AutosizeColumns()
        {
            foreach (ColumnHeader col in this.GUIMain.GetRoomHolder().Columns)
            {
                if (col.Index > 4)
                    break;
                //auto resize column width

                int colWidthBeforeAutoResize = col.Width;
                col.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                int colWidthAfterAutoResizeByHeader = col.Width;
                col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                int colWidthAfterAutoResizeByContent = col.Width;

                if (colWidthAfterAutoResizeByHeader > colWidthAfterAutoResizeByContent)
                    col.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void UpdateRoomBookingLabel(string text)
        {
            this.GUIMain.UpdateRoomBookingLabel(text);
        }

        public enum SELECTED_COMBOBOX
        {
            ERP, WEBSERVICE
        }

        public void HandleWebServiceComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            this.HandleComboBoxSelectedIndexChanged(SELECTED_COMBOBOX.WEBSERVICE, sender);
        }
        public void HandleERPComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            this.HandleComboBoxSelectedIndexChanged(SELECTED_COMBOBOX.ERP, sender);
        }

        public void HandleComboBoxSelectedIndexChanged(SELECTED_COMBOBOX selectedComboBox, object sender)
        {
            string selectedItem = ((ComboBox)sender).SelectedItem as string;
            object[][] data = null;

            localhost.WebService proxy;

            try
            {
                proxy = new localhost.WebService();

                if (selectedComboBox == SELECTED_COMBOBOX.ERP)
                    data = proxy.GetERPMethodBasedOnDescriptionString(selectedItem);

                else if (selectedComboBox == SELECTED_COMBOBOX.WEBSERVICE)
                    data = proxy.GetList(selectedItem, true);

            } catch (WebException we)
            {
                this.HandleWebserviceException(we);
            }

            if (data != null)
                this.GUIMain.SetWebserviceAndErpData(data);
        }

        public void HandleLogOUtMenuStripClick()
        {
            this.LogoutUser();
        }

        public void HandleMyProfileMenuStripClick()
        {
            if (this.LoggedInUser != null)
            {
                DAL dal = new DAL(this);
                this.LoggedInUser = (Person)dal.Get(this.LoggedInUser).First();
                EditView ev = new EditView(this.LoggedInUser, isExistingItemInDatabase: true, isMyProfileClick: true);
                EditViewController editController = new EditViewController(ev);
                ev.Show();
            }
        }

        private void HandleWebserviceException(WebException we)
        {
            if (we.Message.Equals("Unable to connect to the remote server"))
            {
                var regMatch = Regex.Match(we.InnerException.Message, "(?<=actively refused it )(.*?)$").Groups[0]; //finds ip and port number
                string ipAndPort = null;
                if (regMatch.Captures[0] != null)
                    ipAndPort = regMatch.Captures[0].ToString();
                MessageBox.Show(String.Format("Kunde inte ansluta till Webservice{0}, kontrollera att tjänsten är igång och accepterar inkommande anslutningar", ipAndPort == null ? "" : " på adressen " + ipAndPort));
            } else
            {
                MessageBox.Show("Fel: " + we.Message + "\n\r" + we.InnerException.Message);
            }
            Environment.Exit(0);
        }
    }
}
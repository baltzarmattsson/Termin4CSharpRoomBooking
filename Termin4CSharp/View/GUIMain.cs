﻿using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Termin4CSharp.Controller;
using Termin4CSharp.DataAccessLayer;
using Termin4CSharp.Model;
using static System.Windows.Forms.ListViewItem;
using static Termin4CSharp.Controller.GUIMainController;


namespace Termin4CSharp.View
{
    public partial class GUIMain : Form
    {
        public GUIMainController Controller { get; set; }
        public AdminTabController AdminController { get; set; }

        public GUIMain()
        {
            InitializeComponent();
            this.InitializeMainRoomViewColumns();
        }

        private void tabPage5_GotFocus(object sender, EventArgs e)
        {
            this.Controller.LoadFilters();
            this.Controller.LoadRooms(DateTime.Now);
        }

        public void SetMinCapacityFilter(int highestCapacity)
        {
            this.capacityTrackbarRoomBookingTab.Maximum = highestCapacity;
        }

        internal CheckedListBox.CheckedItemCollection GetRoomFilters()
        {
            return this.roomFilterBox.CheckedItems;
        }

        internal CheckedListBox.CheckedItemCollection GetResourceFilters()
        {
            return this.resourceFilterBox.CheckedItems;
        }

        internal CheckedListBox.CheckedItemCollection GetBuildingFilters()
        {
            return this.buildingFilterBox.CheckedItems;
        }

        public void ClearFilterSelections()
        {
            this.capacityTrackbarRoomBookingTab.Value = 0;
            CheckedListBox[] filterBoxes = { this.buildingFilterBox, this.resourceFilterBox, this.roomFilterBox };
            foreach (var fbox in filterBoxes)
            {
                fbox.SelectedItems.Clear();
                fbox.ClearSelected();
                for (int i = 0; i < fbox.Items.Count; i++)
                {
                    fbox.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        internal void SetLoginResponseLabelText(string text)
        {
            this.responseLabelLoginTab.Text = text;
        }

        private void buildingFilterBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Controller.HandleFilterChange(FilterControl.BUILDING_BOX, sender as CheckedListBox, e);
        }
        private void roomFilterBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Controller.HandleFilterChange(FilterControl.ROOM_BOX, sender as CheckedListBox, e);
        }
        private void resourceFilterBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Controller.HandleFilterChange(FilterControl.RESOURCE_BOX, sender as CheckedListBox, e);
        }

        public ObjectListView GetRoomHolder()
        {
            return this.roomHolder;
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            TextBox senderAsTextBox = (TextBox)sender;
            Controller.HandleFreeTextFilterChange(senderAsTextBox, e);
        }

        private void formatRow(object sender, FormatCellEventArgs e)
        {
            // 4 since at index 4 the Room-attributes stop, and the 24h columns begins
            if (e.ColumnIndex > 4)
            {
                Room r = (Room)e.Model;
                int index = e.ColumnIndex - 5;

                string text = null;
                Color backColor = default(Color);
                if (r.RoomStateOnHour != null)
                {
                    switch (r.RoomStateOnHour[index])
                    {
                        case RoomState.AVAILABLE:
                            text = (index < 10 ? "0" : "") + index + ":00";
                            backColor = Color.LightGreen;
                            break;
                        case RoomState.BOOKED:
                            text = "Bokad";
                            backColor = Color.IndianRed;
                            break;
                        case RoomState.BUILDING_CLOSED:
                            text = "Stängt";
                            backColor = Color.LightGray;
                            break;
                    }
                }
                e.SubItem.Text = text;
                e.SubItem.BackColor = backColor;
            }
        }

        public void SetLoginControlsToStatus(bool enabled)
        {
            this.passwordTextfieldLogin.Enabled = enabled;
            this.usernameTextfieldLogin.Enabled = enabled;
            this.loginButtonLoginTab.Text = enabled ? "Logga in" : "Logga ut";
        }

        public void SetRooms(List<Room> rooms)
        {
            this.roomHolder.SetObjects(rooms);
        }
        private void InitializeMainRoomViewColumns()
        {
            foreach (OLVColumn c in roomHolder.Columns)
                if (c.Index < 5)
                    c.Text = Utils.ConvertAttributeNameToDisplayName(new Room(), c.AspectName);
                else
                    break;

        }
        public void SetBuildingFilters(List<Building> buildings)
        {
            this.buildingFilterBox.Items.Clear();
            foreach (var building in buildings)
                this.buildingFilterBox.Items.Add(building.Name);
        }

        public void SetRoomFilters(List<Room> rooms)
        {
            this.roomFilterBox.Items.Clear();
            foreach (var room in rooms)
                this.roomFilterBox.Items.Add(room.Id);
        }
        public void SetResourceFilters(List<Resource> resources)
        {
            this.resourceFilterBox.Items.Clear();
            foreach (var resource in resources)
                this.resourceFilterBox.Items.Add(resource.Type);
        }

        public ComboBox GetAdminEditTypeComboBox()
        {
            return this.editTypeBox;
        }
        public ComboBox GetAdminEditArticleComboBox()
        {
            return this.editArticleBox;
        }
        public ComboBox GetAdminCreateTypeComboBox()
        {
            return this.createTypeBox;
        }

        private void editTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox senderAsCBox = (ComboBox)sender;
            string selectedItem = senderAsCBox.SelectedItem.ToString();
            this.AdminController.SetEditArticles(selectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.AdminController.HandleCreateNewIModelClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.AdminController.HandleEditIModelClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Controller.ClearFilterSelections();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.label11.Text = "Minst antal platser: (" + capacityTrackbarRoomBookingTab.Value + ")";
            this.Controller.HandleFilterChange(FilterControl.MIN_CAPACITY_TRACKBAR, sender, e);
        }
        public int GetMinCapacityFilterValue()
        {
            return this.capacityTrackbarRoomBookingTab.Value;
        }

        public void SetPKResponseLabelText(string text)
        {
            this.responseLabelPK.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controller.HandleLoginOrLogoutButtonClick((Button)sender, this.usernameTextfieldLogin.Text, this.passwordTextfieldLogin.Text);
        }

        public void UpdateRoomBookingLabel(string text)
        {
            this.roomBookingResponseLabel.Text = text;
        }

        public void SetWebserviceAndErpData(object[][] data)
        {

            listView2.Columns.Clear();
            listView2.Items.Clear();
            listView2.View = System.Windows.Forms.View.Details;

            // Index 0 in data is column headers
            foreach (string columnName in data[0])
                listView2.Columns.Add(columnName, listView2.Width / data[0].Length);

            for (int i = 1; i < data.Length; i++)
            {
                string[] objAsStrings = data[i].Select(x => x == null ? "" : x.ToString()).ToArray();
                listView2.Items.Add(new ListViewItem(objAsStrings));
            }
        }

        public void SetFocusOnFirstTab()
        {
            this.loginTab.Focus();
            this.tabPK.SelectedTab = this.loginTab;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Controller.HandleWebServiceComboBoxSelectedIndexChanged(sender, e);
        }

        private void myProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controller.HandleMyProfileMenuStripClick();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controller.HandleLogOUtMenuStripClick();
        }

        public void SetAdminTabEnabled(bool isEnabled)
        {
            this.adminTab.Enabled = isEnabled;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.Controller.HandleFilterChange(FilterControl.ON_DATE_DATE_PICKER, sender, e);
        }

        private void erpComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.Controller.HandleERPComboBoxSelectedIndexChanged(sender, e);
        }

        public void SetWebserviceAndErpComboBoxValues(string[] wsMethods, string[] erpQueries)
        {
            this.erpComboBox.Items.AddRange(erpQueries);
            this.webServiceComboBox.Items.AddRange(wsMethods);
        }

        private void chooseFileButtonWS_Click(object sender, EventArgs e)
        {
            this.Controller.HandleChooseFileWSClick(sender, e);
        }

        public void SetFileContentWS(string content)
        {
            this.fileContentTextBox.Text = content;
        }
    }
}

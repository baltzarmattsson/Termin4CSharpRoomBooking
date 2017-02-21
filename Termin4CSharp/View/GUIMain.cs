using BrightIdeasSoftware;
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
        private delegate bool IsBookableDelegate(object sender, EventArgs e);
        public AdminTabController AdminController { get; set; }
        private string textFilter;

        public GUIMain()
        {
            InitializeComponent();
            this.InitializeMainRoomViewColumns();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PK_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OK_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_GotFocus(object sender, EventArgs e)
        {
            this.Controller.LoadFilters();
            this.Controller.LoadRooms();
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        public void SetMinCapacityFilter(int highestCapacity) {
            this.capacityTrackbarRoomBookingTab.Maximum = highestCapacity;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        internal CheckedListBox.CheckedItemCollection GetRoomFilters() {
            return this.roomFilterBox.CheckedItems;
        }

        internal CheckedListBox.CheckedItemCollection GetResourceFilters() {
            return this.resourceFilterBox.CheckedItems;
        }

        internal string GetTextFilter() {
            return this.textFilter;
        }

        internal CheckedListBox.CheckedItemCollection GetBuildingFilters() {
            return this.buildingFilterBox.CheckedItems;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        { }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        internal void ClearFilterSelections() {
            CheckedListBox[] filterBoxes = { this.buildingFilterBox, this.resourceFilterBox, this.roomFilterBox };
            foreach (var fbox in filterBoxes) {
                fbox.SelectedItems.Clear();
                fbox.ClearSelected();
                for (int i = 0; i < fbox.Items.Count; i++) {
                    fbox.SetItemCheckState(i, CheckState.Unchecked);
                    Console.WriteLine(fbox.GetItemCheckState(i));
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void buildingFilterBox_ItemCheck(object sender, ItemCheckEventArgs e) {
            Controller.HandleFilterChange(FilterBox.BUILDING, sender as CheckedListBox, e);
        }
        private void roomFilterBox_ItemCheck(object sender, ItemCheckEventArgs e) {
            Controller.HandleFilterChange(FilterBox.ROOM, sender as CheckedListBox, e);
        }
        private void resourceFilterBox_ItemCheck(object sender, ItemCheckEventArgs e) {
            Controller.HandleFilterChange(FilterBox.RESOURCE, sender as CheckedListBox, e);
        }
        private void textBox3_TextChanged_1(object sender, EventArgs e) {
            TextBox senderAsTextBox = (TextBox)sender;
            Controller.HandleFreeTextFilterChange(senderAsTextBox, e);
        }

        private void formatRow(object sender, FormatCellEventArgs e) {
            // 4 since at index 4 the Room-attributes stop, and the 24h columns begins
            if (e.ColumnIndex > 4) {
                Room r = (Room)e.Model;
                int index = e.ColumnIndex - 5;
                e.SubItem.BackColor = r.Bookable[index] ? Color.LightGreen : Color.Red;
                e.SubItem.Text = (index < 10 ? "0" : "") + index + ":00";
            }
        }

        public void SetRooms(List<Room> rooms) {
            Random r = new Random();
            foreach (var room in rooms) {
                room.Bookable = new bool[24];
                for (int i = 0; i < 24; i++)
                    room.Bookable[i] = r.Next() % 2 == 0;
            }
            this.roomHolder.SetObjects(rooms);
        }
        private void InitializeMainRoomViewColumns() {
            //Random r = new Random();
            //foreach (var room in rooms) {
            //    room.Bookable = new bool[24];
            //    for (int i = 0; i < 24; i++)
            //        room.Bookable[i] = r.Next() % 2 == 0;
            //}
            foreach (OLVColumn c in roomHolder.Columns) {
                c.Text = Utils.ConvertAttributeNameToDisplayName(new Room(), c.AspectName);
            }
            //OLVColumn col = null;
            //for (int i = 0; i < 24; i++) {
            //    col = new OLVColumn();
            //    col.Text = (i < 10 ? "0" : "") + i + ":00";
            //    roomHolder.Columns.Add(col);
            //}
                   
        }

        public void SetBuildingFilters(List<Building> buildings) {
            this.buildingFilterBox.Items.Clear();
            foreach (var building in buildings)
                this.buildingFilterBox.Items.Add(building.Name);
        }

        public void SetRoomFilters(List<Room> rooms) {
            this.roomFilterBox.Items.Clear();
            foreach (var room in rooms)
                this.roomFilterBox.Items.Add(room.Id);
        }
        public void SetResourceFilters(List<Resource> resources) {
            this.resourceFilterBox.Items.Clear();
            foreach (var resource in resources)
                this.resourceFilterBox.Items.Add(resource.Type);
        }

        public ComboBox GetAdminEditTypeComboBox() {
            return this.editTypeBox;
        }
        public ComboBox GetAdminEditArticleComboBox() {
            return this.editArticleBox;
        }
        public ComboBox GetAdminCreateTypeComboBox() {
            return this.createTypeBox;
        }

        private void editTypeBox_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox senderAsCBox = (ComboBox)sender;
            string selectedItem = senderAsCBox.SelectedItem.ToString();
            this.AdminController.SetEditArticles(selectedItem);
        }

        private void button3_Click(object sender, EventArgs e) {
            this.AdminController.HandleCreateNewIModelClick();
        }

        private void button4_Click(object sender, EventArgs e) {
            this.AdminController.HandleEditIModelClick();
        }

        private void button5_Click(object sender, EventArgs e) {
            this.Controller.ClearFilterSelections();
        }

        private void trackBar1_Scroll(object sender, EventArgs e) {
            this.label11.Text = "Minst antal platser: (" + capacityTrackbarRoomBookingTab.Value + ")";
            this.Controller.HandleFilterChange(FilterBox.TRACKBAR, null, null);
        }
        public int GetMinCapacityFilterValue() {
            return this.capacityTrackbarRoomBookingTab.Value;
        }

        private void button1_Click(object sender, EventArgs e) {
            //this.Controller.LoginUser()
        }

        private void toolStripButton2_Click(object sender, EventArgs e) {

        }
    }
}

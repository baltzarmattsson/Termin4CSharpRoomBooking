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
using static Termin4CSharp.Controller.GUIMainController;

namespace Termin4CSharp.View
{
    public partial class GUIMain : Form
    {
        public GUIMainController Controller { get; set; }
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
            this.trackBar1.Maximum = highestCapacity;
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


            //Temp fix since Windows Forms sucks
            //this.textBox3.Text = " ";
            //this.textBox3.Text = "";

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

        public void SetRooms(List<Room> rooms) {
            this.listView1.Items.Clear();
            foreach (var room in rooms)
                this.listView1.Items.Add(new ListViewItem(Utils.GetAttributeInfo(room).Values.Select(x => x != null ? x.ToString() : "").ToArray()));
        }
        private void InitializeMainRoomViewColumns() {
            this.listView1.Columns.Clear();
            ColumnHeader c = null;
            var attInfo = Utils.GetAttributeInfo(new Room());
            foreach (var kv in attInfo) {
                c = new ColumnHeader();
                c.Text = kv.Key;
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                c.Width = this.listView1.Width / attInfo.Count;
                this.listView1.Columns.Add(c);
            }
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
            this.label11.Text = "Minst antal platser: (" + trackBar1.Value + ")";
            this.Controller.HandleFilterChange(FilterBox.TRACKBAR, null, null);
        }
        public int GetMinCapacityFilterValue() {
            return this.trackBar1.Value;
        }
    }
}

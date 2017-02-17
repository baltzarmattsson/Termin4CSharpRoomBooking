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

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

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
            //object[] arr = new object[5];
            //string[] arr2 = Utils.GetAttributeInfo(new Room()).Values.ToArray();
            //this.listView1.Items.Add(new ListViewItem(arr2));
            foreach (var room in rooms) {
                //this.listView1.Items.Add(new ListViewItem(new[] { room.BName.ToString(), room.Id, room.Floor, room.RoomType.ToString(), "tidslinje", room.Capacity.ToString() }));
                this.listView1.Items.Add(new ListViewItem(Utils.GetAttributeInfo(room).Values.Select(x => x != null ? x.ToString() : "").ToArray()));
            }
        }
        private void InitializeMainRoomViewColumns() {
            this.listView1.Columns.Clear();
            ColumnHeader c = null;
            foreach (var kv in Utils.GetAttributeInfo(new Room())) {
                c = new ColumnHeader();
                c.Text = kv.Key;
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
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


    }
}

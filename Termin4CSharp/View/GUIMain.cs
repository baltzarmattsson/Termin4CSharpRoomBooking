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
using Termin4CSharp.Model;

namespace Termin4CSharp.View
{
    public partial class GUIMain : Form
    {
        public GUIMainController Controller { get; set; }

        public GUIMain()
        {
            InitializeComponent();
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
        private void buildingFilterBox_ItemCheck(object sender, EventArgs e) {
            Console.WriteLine(sender); ;
        }
        private void roomFilterBox_ItemCheck(object sender, EventArgs e) {
            Console.WriteLine(sender); ;
        }
        private void resourceFilterBox_ItemCheck(object sender, EventArgs e) {
            Console.WriteLine(sender); ;
        }

        public void SetRooms(List<Room> rooms) {
            foreach (var room in rooms)
                this.listView1.Items.Add(new ListViewItem(new[] { room.BName.ToString(), room.Id, "tidslinje", room.Capacity.ToString() }));
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
    }
}

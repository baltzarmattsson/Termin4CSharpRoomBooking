using System.Windows.Forms;
using Termin4CSharp.View.CustomControls;

namespace Termin4CSharp.View {
    public partial class GUIMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OK = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.vScrollBar5 = new System.Windows.Forms.VScrollBar();
            this.listView2 = new System.Windows.Forms.ListView();
            this.adminTab = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.editTypeBox = new System.Windows.Forms.ComboBox();
            this.editArticleBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.createTypeBox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.buildingFilterBox = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.roomFilterBox = new System.Windows.Forms.CheckedListBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.label9 = new System.Windows.Forms.Label();
            this.resourceFilterBox = new System.Windows.Forms.CheckedListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.vScrollBar3 = new System.Windows.Forms.VScrollBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vScrollBar4 = new System.Windows.Forms.VScrollBar();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.OK.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.adminTab.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.AccessibleName = "";
            this.OK.Controls.Add(this.tabPage1);
            this.OK.Controls.Add(this.tabPage2);
            this.OK.Controls.Add(this.tabPage3);
            this.OK.Location = new System.Drawing.Point(1, 0);
            this.OK.Name = "OK";
            this.OK.SelectedIndex = 0;
            this.OK.Size = new System.Drawing.Size(939, 526);
            this.OK.TabIndex = 0;
            this.OK.SelectedIndexChanged += new System.EventHandler(this.OK_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(931, 500);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Programkonstruktion";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(931, 500);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Webbservice";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.vScrollBar5);
            this.tabPage3.Controls.Add(this.listView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(931, 500);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ERP";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(159, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Visa";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(32, 124);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 23;
            // 
            // vScrollBar5
            // 
            this.vScrollBar5.Location = new System.Drawing.Point(551, 163);
            this.vScrollBar5.Name = "vScrollBar5";
            this.vScrollBar5.Size = new System.Drawing.Size(20, 307);
            this.vScrollBar5.TabIndex = 22;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(32, 163);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(539, 307);
            this.listView2.TabIndex = 21;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // adminTab
            // 
            this.adminTab.Controls.Add(this.button3);
            this.adminTab.Controls.Add(this.createTypeBox);
            this.adminTab.Controls.Add(this.label13);
            this.adminTab.Controls.Add(this.editArticleBox);
            this.adminTab.Controls.Add(this.editTypeBox);
            this.adminTab.Controls.Add(this.label12);
            this.adminTab.Location = new System.Drawing.Point(4, 22);
            this.adminTab.Name = "adminTab";
            this.adminTab.Padding = new System.Windows.Forms.Padding(3);
            this.adminTab.Size = new System.Drawing.Size(927, 474);
            this.adminTab.TabIndex = 3;
            this.adminTab.Text = "Admin";
            this.adminTab.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(93, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "Editera";
            // 
            // editTypeBox
            // 
            this.editTypeBox.FormattingEnabled = true;
            this.editTypeBox.Items.AddRange(new object[] {
            "Byggnad",
            "Rum",
            "Person",
            "Resurs",
            "Person"});
            this.editTypeBox.Location = new System.Drawing.Point(97, 88);
            this.editTypeBox.Name = "editTypeBox";
            this.editTypeBox.Size = new System.Drawing.Size(121, 21);
            this.editTypeBox.TabIndex = 1;
            this.editTypeBox.Text = "Typ";
            // 
            // editArticleBox
            // 
            this.editArticleBox.FormattingEnabled = true;
            this.editArticleBox.Location = new System.Drawing.Point(225, 88);
            this.editArticleBox.Name = "editArticleBox";
            this.editArticleBox.Size = new System.Drawing.Size(121, 21);
            this.editArticleBox.TabIndex = 2;
            this.editArticleBox.Text = "Artikel";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(93, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 24);
            this.label13.TabIndex = 3;
            this.label13.Text = "Skapa";
            // 
            // createTypeBox
            // 
            this.createTypeBox.FormattingEnabled = true;
            this.createTypeBox.Location = new System.Drawing.Point(97, 178);
            this.createTypeBox.Name = "createTypeBox";
            this.createTypeBox.Size = new System.Drawing.Size(121, 21);
            this.createTypeBox.TabIndex = 4;
            this.createTypeBox.Text = "Typ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(224, 178);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Skapa";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.vScrollBar4);
            this.tabPage5.Controls.Add(this.listView1);
            this.tabPage5.Controls.Add(this.textBox3);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.trackBar1);
            this.tabPage5.Controls.Add(this.vScrollBar3);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.resourceFilterBox);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.vScrollBar2);
            this.tabPage5.Controls.Add(this.vScrollBar1);
            this.tabPage5.Controls.Add(this.roomFilterBox);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.buildingFilterBox);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.dateTimePicker2);
            this.tabPage5.Controls.Add(this.dateTimePicker1);
            this.tabPage5.Controls.Add(this.comboBox4);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(927, 474);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.UseVisualStyleBackColor = true;
            this.tabPage5.Click += new System.EventHandler(this.tabPage5_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Min profil",
            "Logga ut"});
            this.comboBox4.Location = new System.Drawing.Point(736, 0);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(100, 21);
            this.comboBox4.TabIndex = 3;
            this.comboBox4.Text = "Användarnamn";
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(69, 8);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(69, 34);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Från:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Till:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(9, 82);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 8;
            // 
            // buildingFilterBox
            // 
            this.buildingFilterBox.FormattingEnabled = true;
            this.buildingFilterBox.Items.AddRange(new object[] {
            "EC1",
            "EC2",
            "EC3",
            "ALFA"});
            this.buildingFilterBox.Location = new System.Drawing.Point(6, 136);
            this.buildingFilterBox.Name = "buildingFilterBox";
            this.buildingFilterBox.Size = new System.Drawing.Size(120, 49);
            this.buildingFilterBox.TabIndex = 9;
            this.buildingFilterBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.buildingFilterBox_ItemCheck);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Byggnader:";
            // 
            // roomFilterBox
            // 
            this.roomFilterBox.FormattingEnabled = true;
            this.roomFilterBox.Items.AddRange(new object[] {
            "100",
            "101",
            "102",
            "103"});
            this.roomFilterBox.Location = new System.Drawing.Point(6, 222);
            this.roomFilterBox.Name = "roomFilterBox";
            this.roomFilterBox.Size = new System.Drawing.Size(120, 49);
            this.roomFilterBox.TabIndex = 11;
            this.roomFilterBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.roomFilterBox_ItemCheck);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(109, 136);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 64);
            this.vScrollBar1.TabIndex = 12;
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(109, 222);
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(17, 64);
            this.vScrollBar2.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Rum:";
            // 
            // resourceFilterBox
            // 
            this.resourceFilterBox.FormattingEnabled = true;
            this.resourceFilterBox.Items.AddRange(new object[] {
            "Rullstolsanpassat",
            "Projektor"});
            this.resourceFilterBox.Location = new System.Drawing.Point(6, 306);
            this.resourceFilterBox.Name = "resourceFilterBox";
            this.resourceFilterBox.Size = new System.Drawing.Size(120, 49);
            this.resourceFilterBox.TabIndex = 15;
            this.resourceFilterBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.resourceFilterBox_ItemCheck);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 290);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Resurser:";
            // 
            // vScrollBar3
            // 
            this.vScrollBar3.Location = new System.Drawing.Point(109, 306);
            this.vScrollBar3.Name = "vScrollBar3";
            this.vScrollBar3.Size = new System.Drawing.Size(17, 64);
            this.vScrollBar3.TabIndex = 17;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(6, 398);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(120, 45);
            this.trackBar1.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 382);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Antal platser:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Location = new System.Drawing.Point(249, 136);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(539, 307);
            this.listView1.TabIndex = 20;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Byggnad";
            this.columnHeader1.Width = 129;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Rum";
            this.columnHeader2.Width = 129;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tidslinje";
            this.columnHeader3.Width = 129;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Antal platser";
            this.columnHeader4.Width = 129;
            // 
            // vScrollBar4
            // 
            this.vScrollBar4.Location = new System.Drawing.Point(768, 136);
            this.vScrollBar4.Name = "vScrollBar4";
            this.vScrollBar4.Size = new System.Drawing.Size(20, 307);
            this.vScrollBar4.TabIndex = 21;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.textBox2);
            this.tabPage4.Controls.Add(this.textBox1);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(927, 474);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Logga in ";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Användarnamn:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(54, 186);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lösenord:";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(54, 235);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Logga in";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(333, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "För att logga in, ange användaridentitet från Lucat nedan\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(407, 29);
            this.label5.TabIndex = 7;
            this.label5.Text = "Rumsbokning för Ekonomihögskolan\r\n";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.adminTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(935, 500);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // GUIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(940, 524);
            this.Controls.Add(this.OK);
            this.Name = "GUIMain";
            this.Text = "Lunds universitet";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.OK.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.adminTab.ResumeLayout(false);
            this.adminTab.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl OK;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private ComboBox comboBox1;
        private VScrollBar vScrollBar5;
        private ListView listView2;
        private Button button2;
        private TabControl tabControl1;
        private TabPage tabPage4;
        private Label label5;
        private Label label4;
        private Button button1;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private TabPage tabPage5;
        private VScrollBar vScrollBar4;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private TextBox textBox3;
        private Label label11;
        private TrackBar trackBar1;
        private VScrollBar vScrollBar3;
        private Label label10;
        private CheckedListBox resourceFilterBox;
        private Label label9;
        private VScrollBar vScrollBar2;
        private VScrollBar vScrollBar1;
        private CheckedListBox roomFilterBox;
        private Label label8;
        private CheckedListBox buildingFilterBox;
        private Label label7;
        private Label label6;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox4;
        private TabPage adminTab;
        private Button button3;
        private ComboBox createTypeBox;
        private Label label13;
        private ComboBox editArticleBox;
        private ComboBox editTypeBox;
        private Label label12;
    }
}
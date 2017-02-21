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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordTextfieldLogin = new System.Windows.Forms.TextBox();
            this.usernameTextfieldLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.roomView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.resourceFilterBox = new System.Windows.Forms.CheckedListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.roomFilterBox = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buildingFilterBox = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.adminTab = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.createTypeBox = new System.Windows.Forms.ComboBox();
            this.editArticleBox = new System.Windows.Forms.ComboBox();
            this.editTypeBox = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.vScrollBar5 = new System.Windows.Forms.VScrollBar();
            this.listView2 = new System.Windows.Forms.ListView();
            this.editLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.OK.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.adminTab.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.AccessibleName = "";
            this.OK.Controls.Add(this.tabPage1);
            this.OK.Controls.Add(this.tabPage2);
            this.OK.Controls.Add(this.tabPage3);
            this.OK.Location = new System.Drawing.Point(1, 0);
            this.OK.Margin = new System.Windows.Forms.Padding(4);
            this.OK.Name = "OK";
            this.OK.SelectedIndex = 0;
            this.OK.Size = new System.Drawing.Size(1252, 647);
            this.OK.TabIndex = 0;
            this.OK.SelectedIndexChanged += new System.EventHandler(this.OK_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1244, 618);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Programkonstruktion";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.adminTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1247, 615);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.passwordTextfieldLogin);
            this.tabPage4.Controls.Add(this.usernameTextfieldLogin);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(1239, 586);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Logga in ";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 69);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(504, 36);
            this.label5.TabIndex = 7;
            this.label5.Text = "Rumsbokning för Ekonomihögskolan\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 164);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(426, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "För att logga in, ange användaridentitet från Lucat nedan\r\n";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 335);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Logga in";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(68, 164);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 4;
            // 
            // passwordTextfieldLogin
            // 
            this.passwordTextfieldLogin.Location = new System.Drawing.Point(72, 289);
            this.passwordTextfieldLogin.Margin = new System.Windows.Forms.Padding(4);
            this.passwordTextfieldLogin.Name = "passwordTextfieldLogin";
            this.passwordTextfieldLogin.PasswordChar = '*';
            this.passwordTextfieldLogin.Size = new System.Drawing.Size(422, 22);
            this.passwordTextfieldLogin.TabIndex = 3;
            this.passwordTextfieldLogin.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // usernameTextfieldLogin
            // 
            this.usernameTextfieldLogin.Location = new System.Drawing.Point(72, 229);
            this.usernameTextfieldLogin.Margin = new System.Windows.Forms.Padding(4);
            this.usernameTextfieldLogin.Name = "usernameTextfieldLogin";
            this.usernameTextfieldLogin.Size = new System.Drawing.Size(422, 22);
            this.usernameTextfieldLogin.TabIndex = 1;
            this.usernameTextfieldLogin.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 270);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lösenord:";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 209);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Användarnamn:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button5);
            this.tabPage5.Controls.Add(this.roomView);
            this.tabPage5.Controls.Add(this.textBox3);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.trackBar1);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.resourceFilterBox);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.roomFilterBox);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.buildingFilterBox);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.dateTimePicker2);
            this.tabPage5.Controls.Add(this.dateTimePicker1);
            this.tabPage5.Controls.Add(this.comboBox4);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage5.Size = new System.Drawing.Size(1239, 586);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Boka rum";
            this.tabPage5.UseVisualStyleBackColor = true;
            this.tabPage5.Enter += new System.EventHandler(this.tabPage5_GotFocus);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 463);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(160, 28);
            this.button5.TabIndex = 21;
            this.button5.Text = "Rensa filter";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // roomView
            // 
            this.roomView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.roomView.Location = new System.Drawing.Point(176, 101);
            this.roomView.Margin = new System.Windows.Forms.Padding(4);
            this.roomView.Name = "roomView";
            this.roomView.Size = new System.Drawing.Size(1055, 476);
            this.roomView.TabIndex = 20;
            this.roomView.UseCompatibleStateImageBehavior = false;
            this.roomView.View = System.Windows.Forms.View.Details;
            this.roomView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
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
            this.columnHeader4.Text = "Minst antal platser: ";
            this.columnHeader4.Width = 129;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 101);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(155, 22);
            this.textBox3.TabIndex = 8;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 501);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "Antal platser:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(8, 521);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(160, 56);
            this.trackBar1.TabIndex = 18;
            this.trackBar1.Tag = "";
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 357);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Resurser:";
            // 
            // resourceFilterBox
            // 
            this.resourceFilterBox.FormattingEnabled = true;
            this.resourceFilterBox.Items.AddRange(new object[] {
            "Rullstolsanpassat",
            "Projektor"});
            this.resourceFilterBox.Location = new System.Drawing.Point(8, 377);
            this.resourceFilterBox.Margin = new System.Windows.Forms.Padding(4);
            this.resourceFilterBox.Name = "resourceFilterBox";
            this.resourceFilterBox.ScrollAlwaysVisible = true;
            this.resourceFilterBox.Size = new System.Drawing.Size(159, 72);
            this.resourceFilterBox.TabIndex = 15;
            this.resourceFilterBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.resourceFilterBox_ItemCheck);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 254);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "Rum:";
            // 
            // roomFilterBox
            // 
            this.roomFilterBox.FormattingEnabled = true;
            this.roomFilterBox.Items.AddRange(new object[] {
            "100",
            "101",
            "102",
            "103"});
            this.roomFilterBox.Location = new System.Drawing.Point(8, 273);
            this.roomFilterBox.Margin = new System.Windows.Forms.Padding(4);
            this.roomFilterBox.Name = "roomFilterBox";
            this.roomFilterBox.ScrollAlwaysVisible = true;
            this.roomFilterBox.Size = new System.Drawing.Size(159, 72);
            this.roomFilterBox.TabIndex = 11;
            this.roomFilterBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.roomFilterBox_ItemCheck);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 148);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Byggnader:";
            // 
            // buildingFilterBox
            // 
            this.buildingFilterBox.FormattingEnabled = true;
            this.buildingFilterBox.Items.AddRange(new object[] {
            "EC1",
            "EC2",
            "EC3",
            "ALFA"});
            this.buildingFilterBox.Location = new System.Drawing.Point(8, 167);
            this.buildingFilterBox.Margin = new System.Windows.Forms.Padding(4);
            this.buildingFilterBox.Name = "buildingFilterBox";
            this.buildingFilterBox.ScrollAlwaysVisible = true;
            this.buildingFilterBox.Size = new System.Drawing.Size(159, 72);
            this.buildingFilterBox.TabIndex = 9;
            this.buildingFilterBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.buildingFilterBox_ItemCheck);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Till:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Från:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(92, 42);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(92, 10);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Min profil",
            "Logga ut"});
            this.comboBox4.Location = new System.Drawing.Point(1057, 30);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(132, 24);
            this.comboBox4.TabIndex = 3;
            this.comboBox4.Text = "Användarnamn";
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // adminTab
            // 
            this.adminTab.Controls.Add(this.label14);
            this.adminTab.Controls.Add(this.editLabel);
            this.adminTab.Controls.Add(this.button4);
            this.adminTab.Controls.Add(this.button3);
            this.adminTab.Controls.Add(this.createTypeBox);
            this.adminTab.Controls.Add(this.editArticleBox);
            this.adminTab.Controls.Add(this.editTypeBox);
            this.adminTab.Location = new System.Drawing.Point(4, 25);
            this.adminTab.Margin = new System.Windows.Forms.Padding(4);
            this.adminTab.Name = "adminTab";
            this.adminTab.Padding = new System.Windows.Forms.Padding(4);
            this.adminTab.Size = new System.Drawing.Size(1239, 586);
            this.adminTab.TabIndex = 3;
            this.adminTab.Text = "Admin";
            this.adminTab.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(129, 143);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 28);
            this.button4.TabIndex = 6;
            this.button4.Text = "Editera";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(129, 252);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 28);
            this.button3.TabIndex = 5;
            this.button3.Text = "Skapa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // createTypeBox
            // 
            this.createTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.createTypeBox.FormattingEnabled = true;
            this.createTypeBox.Location = new System.Drawing.Point(129, 219);
            this.createTypeBox.Margin = new System.Windows.Forms.Padding(4);
            this.createTypeBox.Name = "createTypeBox";
            this.createTypeBox.Size = new System.Drawing.Size(160, 24);
            this.createTypeBox.TabIndex = 4;
            // 
            // editArticleBox
            // 
            this.editArticleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.editArticleBox.FormattingEnabled = true;
            this.editArticleBox.Location = new System.Drawing.Point(300, 108);
            this.editArticleBox.Margin = new System.Windows.Forms.Padding(4);
            this.editArticleBox.Name = "editArticleBox";
            this.editArticleBox.Size = new System.Drawing.Size(565, 24);
            this.editArticleBox.TabIndex = 2;
            // 
            // editTypeBox
            // 
            this.editTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.editTypeBox.FormattingEnabled = true;
            this.editTypeBox.Items.AddRange(new object[] {
            "Byggnad",
            "Rum",
            "Person",
            "Resurs",
            "Person"});
            this.editTypeBox.Location = new System.Drawing.Point(129, 108);
            this.editTypeBox.Margin = new System.Windows.Forms.Padding(4);
            this.editTypeBox.Name = "editTypeBox";
            this.editTypeBox.Size = new System.Drawing.Size(160, 24);
            this.editTypeBox.TabIndex = 1;
            this.editTypeBox.SelectedIndexChanged += new System.EventHandler(this.editTypeBox_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1244, 618);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Webbservice";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.vScrollBar5);
            this.tabPage3.Controls.Add(this.listView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1244, 618);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ERP";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(41, 75);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 25);
            this.label13.TabIndex = 26;
            this.label13.Text = "CRONUS\r\n";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(39, 30);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(554, 62);
            this.label12.TabIndex = 25;
            this.label12.Text = "Integrering och konfigurering av ERP-system\r\n\r\n";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(212, 150);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 24;
            this.button2.Text = "Visa";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Personal",
            "Personalanhörig",
            "Personalfrånvaro 2004",
            "Personal med flest antal sjukdagar",
            "Avdelningsinformation",
            "Personal med högst lön",
            "METADATA - Nycklar",
            "METADATA - Indexes",
            "METADATA - Constraints ",
            "METADATA - Tabeller",
            "METADATA - Tabeller2",
            "METADATA - Kolumner",
            "METADATA - Kolumner2"});
            this.comboBox1.Location = new System.Drawing.Point(43, 153);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 24);
            this.comboBox1.TabIndex = 23;
            // 
            // vScrollBar5
            // 
            this.vScrollBar5.Location = new System.Drawing.Point(735, 201);
            this.vScrollBar5.Name = "vScrollBar5";
            this.vScrollBar5.Size = new System.Drawing.Size(20, 378);
            this.vScrollBar5.TabIndex = 22;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(43, 201);
            this.listView2.Margin = new System.Windows.Forms.Padding(4);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(717, 377);
            this.listView2.TabIndex = 21;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // editLabel
            // 
            this.editLabel.AutoSize = true;
            this.editLabel.Font = new System.Drawing.Font("Helvetica Neue", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editLabel.Location = new System.Drawing.Point(129, 77);
            this.editLabel.Name = "editLabel";
            this.editLabel.Size = new System.Drawing.Size(85, 27);
            this.editLabel.TabIndex = 7;
            this.editLabel.Text = "Editera";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Helvetica Neue", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(129, 188);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 27);
            this.label14.TabIndex = 8;
            this.label14.Text = "Skapa";
            // 
            // GUIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1253, 645);
            this.Controls.Add(this.OK);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GUIMain";
            this.Text = "Lunds universitet";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.OK.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.adminTab.ResumeLayout(false);
            this.adminTab.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private TextBox passwordTextfieldLogin;
        private TextBox usernameTextfieldLogin;
        private Label label2;
        private Label label1;
        private TabPage tabPage5;
        private ListView roomView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private TextBox textBox3;
        private Label label11;
        private TrackBar trackBar1;
        private Label label10;
        private CheckedListBox resourceFilterBox;
        private Label label9;
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
        //private Label label13;
        private ComboBox editArticleBox;
        private ComboBox editTypeBox;
        //private Label label12;
        private Button button4;
        private Button button5;
        private Label label13;
        private Label label12;
        private Label editLabel;
        private Label label14;
    }
}
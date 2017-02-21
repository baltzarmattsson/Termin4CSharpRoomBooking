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
            this.mainLabel1PK = new System.Windows.Forms.TabControl();
            this.loginTab = new System.Windows.Forms.TabPage();
            this.mainLabelLoginTab = new System.Windows.Forms.Label();
            this.infoTextLoginTab = new System.Windows.Forms.Label();
            this.loginButtonLoginTab = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordTextfieldLogin = new System.Windows.Forms.TextBox();
            this.usernameTextfieldLogin = new System.Windows.Forms.TextBox();
            this.passwordLabelLoginTab = new System.Windows.Forms.Label();
            this.usernameLabelLoginTab = new System.Windows.Forms.Label();
            this.roomBookTab = new System.Windows.Forms.TabPage();
            this.clearFiltersButtonRoomBookingTab = new System.Windows.Forms.Button();
            this.roomView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.freeTextFilterTextbox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.capacityTrackbarRoomBookingTab = new System.Windows.Forms.TrackBar();
            this.resourceLabelRoomBookingTab = new System.Windows.Forms.Label();
            this.resourceFilterBox = new System.Windows.Forms.CheckedListBox();
            this.roomLabelRoomBookingTab = new System.Windows.Forms.Label();
            this.roomFilterBox = new System.Windows.Forms.CheckedListBox();
            this.buildingLabelRoomBookingTab = new System.Windows.Forms.Label();
            this.buildingFilterBox = new System.Windows.Forms.CheckedListBox();
            this.toDateLabelRoomBookingTab = new System.Windows.Forms.Label();
            this.fromDateLabelRoomBookingTab = new System.Windows.Forms.Label();
            this.toDatePickerRoomBookingTab = new System.Windows.Forms.DateTimePicker();
            this.fromDatePickerRoomBookingTab = new System.Windows.Forms.DateTimePicker();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.adminTab = new System.Windows.Forms.TabPage();
            this.editObjectButton = new System.Windows.Forms.Button();
            this.createObjectButton = new System.Windows.Forms.Button();
            this.createTypeBox = new System.Windows.Forms.ComboBox();
            this.editArticleBox = new System.Windows.Forms.ComboBox();
            this.editTypeBox = new System.Windows.Forms.ComboBox();
            this.mainLabel2WS = new System.Windows.Forms.TabPage();
            this.mainLabel3ERP = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.vScrollBar5 = new System.Windows.Forms.VScrollBar();
            this.listView2 = new System.Windows.Forms.ListView();
            this.editLabelAdminTab = new System.Windows.Forms.Label();
            this.createLabelAdminTab = new System.Windows.Forms.Label();
            this.OK.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.mainLabel1PK.SuspendLayout();
            this.loginTab.SuspendLayout();
            this.roomBookTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capacityTrackbarRoomBookingTab)).BeginInit();
            this.adminTab.SuspendLayout();
            this.mainLabel3ERP.SuspendLayout();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.AccessibleName = "";
            this.OK.Controls.Add(this.tabPage1);
            this.OK.Controls.Add(this.mainLabel2WS);
            this.OK.Controls.Add(this.mainLabel3ERP);
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
            this.tabPage1.Controls.Add(this.mainLabel1PK);
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
            // mainLabel1PK
            // 
            this.mainLabel1PK.Controls.Add(this.loginTab);
            this.mainLabel1PK.Controls.Add(this.roomBookTab);
            this.mainLabel1PK.Controls.Add(this.adminTab);
            this.mainLabel1PK.Location = new System.Drawing.Point(0, 0);
            this.mainLabel1PK.Margin = new System.Windows.Forms.Padding(4);
            this.mainLabel1PK.Name = "mainLabel1PK";
            this.mainLabel1PK.SelectedIndex = 0;
            this.mainLabel1PK.Size = new System.Drawing.Size(1247, 615);
            this.mainLabel1PK.TabIndex = 3;
            this.mainLabel1PK.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // loginTab
            // 
            this.loginTab.Controls.Add(this.mainLabelLoginTab);
            this.loginTab.Controls.Add(this.infoTextLoginTab);
            this.loginTab.Controls.Add(this.loginButtonLoginTab);
            this.loginTab.Controls.Add(this.label3);
            this.loginTab.Controls.Add(this.passwordTextfieldLogin);
            this.loginTab.Controls.Add(this.usernameTextfieldLogin);
            this.loginTab.Controls.Add(this.passwordLabelLoginTab);
            this.loginTab.Controls.Add(this.usernameLabelLoginTab);
            this.loginTab.Location = new System.Drawing.Point(4, 25);
            this.loginTab.Margin = new System.Windows.Forms.Padding(4);
            this.loginTab.Name = "loginTab";
            this.loginTab.Padding = new System.Windows.Forms.Padding(4);
            this.loginTab.Size = new System.Drawing.Size(1239, 586);
            this.loginTab.TabIndex = 0;
            this.loginTab.Text = "Logga in ";
            this.loginTab.UseVisualStyleBackColor = true;
            this.loginTab.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // mainLabelLoginTab
            // 
            this.mainLabelLoginTab.AutoSize = true;
            this.mainLabelLoginTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabelLoginTab.Location = new System.Drawing.Point(68, 69);
            this.mainLabelLoginTab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mainLabelLoginTab.Name = "mainLabelLoginTab";
            this.mainLabelLoginTab.Size = new System.Drawing.Size(504, 36);
            this.mainLabelLoginTab.TabIndex = 7;
            this.mainLabelLoginTab.Text = "Rumsbokning för Ekonomihögskolan\r\n";
            // 
            // infoTextLoginTab
            // 
            this.infoTextLoginTab.AutoSize = true;
            this.infoTextLoginTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoTextLoginTab.Location = new System.Drawing.Point(68, 164);
            this.infoTextLoginTab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.infoTextLoginTab.Name = "infoTextLoginTab";
            this.infoTextLoginTab.Size = new System.Drawing.Size(426, 17);
            this.infoTextLoginTab.TabIndex = 6;
            this.infoTextLoginTab.Text = "För att logga in, ange användaridentitet från Lucat nedan\r\n";
            // 
            // loginButtonLoginTab
            // 
            this.loginButtonLoginTab.Location = new System.Drawing.Point(72, 335);
            this.loginButtonLoginTab.Margin = new System.Windows.Forms.Padding(4);
            this.loginButtonLoginTab.Name = "loginButtonLoginTab";
            this.loginButtonLoginTab.Size = new System.Drawing.Size(100, 28);
            this.loginButtonLoginTab.TabIndex = 5;
            this.loginButtonLoginTab.Text = "Logga in";
            this.loginButtonLoginTab.UseVisualStyleBackColor = true;
            this.loginButtonLoginTab.Click += new System.EventHandler(this.button1_Click);
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
            // passwordLabelLoginTab
            // 
            this.passwordLabelLoginTab.AutoSize = true;
            this.passwordLabelLoginTab.Location = new System.Drawing.Point(68, 270);
            this.passwordLabelLoginTab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabelLoginTab.Name = "passwordLabelLoginTab";
            this.passwordLabelLoginTab.Size = new System.Drawing.Size(72, 17);
            this.passwordLabelLoginTab.TabIndex = 2;
            this.passwordLabelLoginTab.Text = "Lösenord:";
            this.passwordLabelLoginTab.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // usernameLabelLoginTab
            // 
            this.usernameLabelLoginTab.AutoSize = true;
            this.usernameLabelLoginTab.Location = new System.Drawing.Point(68, 209);
            this.usernameLabelLoginTab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabelLoginTab.Name = "usernameLabelLoginTab";
            this.usernameLabelLoginTab.Size = new System.Drawing.Size(108, 17);
            this.usernameLabelLoginTab.TabIndex = 0;
            this.usernameLabelLoginTab.Text = "Användarnamn:";
            this.usernameLabelLoginTab.Click += new System.EventHandler(this.label1_Click);
            // 
            // roomBookTab
            // 
            this.roomBookTab.Controls.Add(this.clearFiltersButtonRoomBookingTab);
            this.roomBookTab.Controls.Add(this.roomView);
            this.roomBookTab.Controls.Add(this.freeTextFilterTextbox);
            this.roomBookTab.Controls.Add(this.label11);
            this.roomBookTab.Controls.Add(this.capacityTrackbarRoomBookingTab);
            this.roomBookTab.Controls.Add(this.resourceLabelRoomBookingTab);
            this.roomBookTab.Controls.Add(this.resourceFilterBox);
            this.roomBookTab.Controls.Add(this.roomLabelRoomBookingTab);
            this.roomBookTab.Controls.Add(this.roomFilterBox);
            this.roomBookTab.Controls.Add(this.buildingLabelRoomBookingTab);
            this.roomBookTab.Controls.Add(this.buildingFilterBox);
            this.roomBookTab.Controls.Add(this.toDateLabelRoomBookingTab);
            this.roomBookTab.Controls.Add(this.fromDateLabelRoomBookingTab);
            this.roomBookTab.Controls.Add(this.toDatePickerRoomBookingTab);
            this.roomBookTab.Controls.Add(this.fromDatePickerRoomBookingTab);
            this.roomBookTab.Controls.Add(this.comboBox4);
            this.roomBookTab.Location = new System.Drawing.Point(4, 25);
            this.roomBookTab.Margin = new System.Windows.Forms.Padding(4);
            this.roomBookTab.Name = "roomBookTab";
            this.roomBookTab.Padding = new System.Windows.Forms.Padding(4);
            this.roomBookTab.Size = new System.Drawing.Size(1239, 586);
            this.roomBookTab.TabIndex = 1;
            this.roomBookTab.Text = "Boka rum";
            this.roomBookTab.UseVisualStyleBackColor = true;
            this.roomBookTab.Enter += new System.EventHandler(this.tabPage5_GotFocus);
            // 
            // clearFiltersButtonRoomBookingTab
            // 
            this.clearFiltersButtonRoomBookingTab.Location = new System.Drawing.Point(8, 463);
            this.clearFiltersButtonRoomBookingTab.Margin = new System.Windows.Forms.Padding(4);
            this.clearFiltersButtonRoomBookingTab.Name = "clearFiltersButtonRoomBookingTab";
            this.clearFiltersButtonRoomBookingTab.Size = new System.Drawing.Size(160, 28);
            this.clearFiltersButtonRoomBookingTab.TabIndex = 21;
            this.clearFiltersButtonRoomBookingTab.Text = "Rensa filter";
            this.clearFiltersButtonRoomBookingTab.UseVisualStyleBackColor = true;
            this.clearFiltersButtonRoomBookingTab.Click += new System.EventHandler(this.button5_Click);
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
            // freeTextFilterTextbox
            // 
            this.freeTextFilterTextbox.Location = new System.Drawing.Point(12, 101);
            this.freeTextFilterTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.freeTextFilterTextbox.Name = "freeTextFilterTextbox";
            this.freeTextFilterTextbox.Size = new System.Drawing.Size(155, 22);
            this.freeTextFilterTextbox.TabIndex = 8;
            this.freeTextFilterTextbox.TextChanged += new System.EventHandler(this.textBox3_TextChanged_1);
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
            // capacityTrackbarRoomBookingTab
            // 
            this.capacityTrackbarRoomBookingTab.Location = new System.Drawing.Point(8, 521);
            this.capacityTrackbarRoomBookingTab.Margin = new System.Windows.Forms.Padding(4);
            this.capacityTrackbarRoomBookingTab.Name = "capacityTrackbarRoomBookingTab";
            this.capacityTrackbarRoomBookingTab.Size = new System.Drawing.Size(160, 56);
            this.capacityTrackbarRoomBookingTab.TabIndex = 18;
            this.capacityTrackbarRoomBookingTab.Tag = "";
            this.capacityTrackbarRoomBookingTab.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // resourceLabelRoomBookingTab
            // 
            this.resourceLabelRoomBookingTab.AutoSize = true;
            this.resourceLabelRoomBookingTab.Location = new System.Drawing.Point(8, 357);
            this.resourceLabelRoomBookingTab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.resourceLabelRoomBookingTab.Name = "resourceLabelRoomBookingTab";
            this.resourceLabelRoomBookingTab.Size = new System.Drawing.Size(70, 17);
            this.resourceLabelRoomBookingTab.TabIndex = 16;
            this.resourceLabelRoomBookingTab.Text = "Resurser:";
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
            // roomLabelRoomBookingTab
            // 
            this.roomLabelRoomBookingTab.AutoSize = true;
            this.roomLabelRoomBookingTab.Location = new System.Drawing.Point(8, 254);
            this.roomLabelRoomBookingTab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.roomLabelRoomBookingTab.Name = "roomLabelRoomBookingTab";
            this.roomLabelRoomBookingTab.Size = new System.Drawing.Size(41, 17);
            this.roomLabelRoomBookingTab.TabIndex = 14;
            this.roomLabelRoomBookingTab.Text = "Rum:";
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
            // buildingLabelRoomBookingTab
            // 
            this.buildingLabelRoomBookingTab.AutoSize = true;
            this.buildingLabelRoomBookingTab.Location = new System.Drawing.Point(8, 148);
            this.buildingLabelRoomBookingTab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buildingLabelRoomBookingTab.Name = "buildingLabelRoomBookingTab";
            this.buildingLabelRoomBookingTab.Size = new System.Drawing.Size(81, 17);
            this.buildingLabelRoomBookingTab.TabIndex = 10;
            this.buildingLabelRoomBookingTab.Text = "Byggnader:";
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
            // toDateLabelRoomBookingTab
            // 
            this.toDateLabelRoomBookingTab.AutoSize = true;
            this.toDateLabelRoomBookingTab.Location = new System.Drawing.Point(8, 49);
            this.toDateLabelRoomBookingTab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.toDateLabelRoomBookingTab.Name = "toDateLabelRoomBookingTab";
            this.toDateLabelRoomBookingTab.Size = new System.Drawing.Size(30, 17);
            this.toDateLabelRoomBookingTab.TabIndex = 7;
            this.toDateLabelRoomBookingTab.Text = "Till:";
            // 
            // fromDateLabelRoomBookingTab
            // 
            this.fromDateLabelRoomBookingTab.AutoSize = true;
            this.fromDateLabelRoomBookingTab.Location = new System.Drawing.Point(8, 17);
            this.fromDateLabelRoomBookingTab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fromDateLabelRoomBookingTab.Name = "fromDateLabelRoomBookingTab";
            this.fromDateLabelRoomBookingTab.Size = new System.Drawing.Size(41, 17);
            this.fromDateLabelRoomBookingTab.TabIndex = 6;
            this.fromDateLabelRoomBookingTab.Text = "Från:";
            // 
            // toDatePickerRoomBookingTab
            // 
            this.toDatePickerRoomBookingTab.Location = new System.Drawing.Point(92, 42);
            this.toDatePickerRoomBookingTab.Margin = new System.Windows.Forms.Padding(4);
            this.toDatePickerRoomBookingTab.Name = "toDatePickerRoomBookingTab";
            this.toDatePickerRoomBookingTab.Size = new System.Drawing.Size(265, 22);
            this.toDatePickerRoomBookingTab.TabIndex = 5;
            // 
            // fromDatePickerRoomBookingTab
            // 
            this.fromDatePickerRoomBookingTab.Location = new System.Drawing.Point(92, 10);
            this.fromDatePickerRoomBookingTab.Margin = new System.Windows.Forms.Padding(4);
            this.fromDatePickerRoomBookingTab.Name = "fromDatePickerRoomBookingTab";
            this.fromDatePickerRoomBookingTab.Size = new System.Drawing.Size(265, 22);
            this.fromDatePickerRoomBookingTab.TabIndex = 4;
            this.fromDatePickerRoomBookingTab.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
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
            this.adminTab.Controls.Add(this.createLabelAdminTab);
            this.adminTab.Controls.Add(this.editLabelAdminTab);
            this.adminTab.Controls.Add(this.editObjectButton);
            this.adminTab.Controls.Add(this.createObjectButton);
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
            // editObjectButton
            // 
            this.editObjectButton.Location = new System.Drawing.Point(129, 143);
            this.editObjectButton.Margin = new System.Windows.Forms.Padding(4);
            this.editObjectButton.Name = "editObjectButton";
            this.editObjectButton.Size = new System.Drawing.Size(161, 28);
            this.editObjectButton.TabIndex = 6;
            this.editObjectButton.Text = "Editera";
            this.editObjectButton.UseVisualStyleBackColor = true;
            this.editObjectButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // createObjectButton
            // 
            this.createObjectButton.Location = new System.Drawing.Point(129, 252);
            this.createObjectButton.Margin = new System.Windows.Forms.Padding(4);
            this.createObjectButton.Name = "createObjectButton";
            this.createObjectButton.Size = new System.Drawing.Size(161, 28);
            this.createObjectButton.TabIndex = 5;
            this.createObjectButton.Text = "Skapa";
            this.createObjectButton.UseVisualStyleBackColor = true;
            this.createObjectButton.Click += new System.EventHandler(this.button3_Click);
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
            // mainLabel2WS
            // 
            this.mainLabel2WS.Location = new System.Drawing.Point(4, 25);
            this.mainLabel2WS.Margin = new System.Windows.Forms.Padding(4);
            this.mainLabel2WS.Name = "mainLabel2WS";
            this.mainLabel2WS.Padding = new System.Windows.Forms.Padding(4);
            this.mainLabel2WS.Size = new System.Drawing.Size(1244, 618);
            this.mainLabel2WS.TabIndex = 1;
            this.mainLabel2WS.Text = "Webbservice";
            this.mainLabel2WS.UseVisualStyleBackColor = true;
            this.mainLabel2WS.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // mainLabel3ERP
            // 
            this.mainLabel3ERP.Controls.Add(this.label13);
            this.mainLabel3ERP.Controls.Add(this.label12);
            this.mainLabel3ERP.Controls.Add(this.button2);
            this.mainLabel3ERP.Controls.Add(this.comboBox1);
            this.mainLabel3ERP.Controls.Add(this.vScrollBar5);
            this.mainLabel3ERP.Controls.Add(this.listView2);
            this.mainLabel3ERP.Location = new System.Drawing.Point(4, 25);
            this.mainLabel3ERP.Margin = new System.Windows.Forms.Padding(4);
            this.mainLabel3ERP.Name = "mainLabel3ERP";
            this.mainLabel3ERP.Padding = new System.Windows.Forms.Padding(4);
            this.mainLabel3ERP.Size = new System.Drawing.Size(1244, 618);
            this.mainLabel3ERP.TabIndex = 2;
            this.mainLabel3ERP.Text = "ERP";
            this.mainLabel3ERP.UseVisualStyleBackColor = true;
            this.mainLabel3ERP.Click += new System.EventHandler(this.tabPage3_Click);
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
            // editLabelAdminTab
            // 
            this.editLabelAdminTab.AutoSize = true;
            this.editLabelAdminTab.Font = new System.Drawing.Font("Helvetica Neue", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editLabelAdminTab.Location = new System.Drawing.Point(129, 77);
            this.editLabelAdminTab.Name = "editLabelAdminTab";
            this.editLabelAdminTab.Size = new System.Drawing.Size(85, 27);
            this.editLabelAdminTab.TabIndex = 7;
            this.editLabelAdminTab.Text = "Editera";
            // 
            // createLabelAdminTab
            // 
            this.createLabelAdminTab.AutoSize = true;
            this.createLabelAdminTab.Font = new System.Drawing.Font("Helvetica Neue", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createLabelAdminTab.Location = new System.Drawing.Point(129, 188);
            this.createLabelAdminTab.Name = "createLabelAdminTab";
            this.createLabelAdminTab.Size = new System.Drawing.Size(80, 27);
            this.createLabelAdminTab.TabIndex = 8;
            this.createLabelAdminTab.Text = "Skapa";
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
            this.mainLabel1PK.ResumeLayout(false);
            this.loginTab.ResumeLayout(false);
            this.loginTab.PerformLayout();
            this.roomBookTab.ResumeLayout(false);
            this.roomBookTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capacityTrackbarRoomBookingTab)).EndInit();
            this.adminTab.ResumeLayout(false);
            this.adminTab.PerformLayout();
            this.mainLabel3ERP.ResumeLayout(false);
            this.mainLabel3ERP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl OK;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage mainLabel2WS;
        private System.Windows.Forms.TabPage mainLabel3ERP;
        private ComboBox comboBox1;
        private VScrollBar vScrollBar5;
        private ListView listView2;
        private Button button2;
        private TabControl mainLabel1PK;
        private TabPage loginTab;
        private Label mainLabelLoginTab;
        private Label infoTextLoginTab;
        private Button loginButtonLoginTab;
        private Label label3;
        private TextBox passwordTextfieldLogin;
        private TextBox usernameTextfieldLogin;
        private Label passwordLabelLoginTab;
        private Label usernameLabelLoginTab;
        private TabPage roomBookTab;
        private ListView roomView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private TextBox freeTextFilterTextbox;
        private Label label11;
        private TrackBar capacityTrackbarRoomBookingTab;
        private Label resourceLabelRoomBookingTab;
        private CheckedListBox resourceFilterBox;
        private Label roomLabelRoomBookingTab;
        private CheckedListBox roomFilterBox;
        private Label buildingLabelRoomBookingTab;
        private CheckedListBox buildingFilterBox;
        private Label toDateLabelRoomBookingTab;
        private Label fromDateLabelRoomBookingTab;
        private DateTimePicker toDatePickerRoomBookingTab;
        private DateTimePicker fromDatePickerRoomBookingTab;
        private ComboBox comboBox4;
        private TabPage adminTab;
        private Button createObjectButton;
        private ComboBox createTypeBox;
        //private Label label13;
        private ComboBox editArticleBox;
        private ComboBox editTypeBox;
        //private Label label12;
        private Button editObjectButton;
        private Button clearFiltersButtonRoomBookingTab;
        private Label label13;
        private Label label12;
        private Label editLabelAdminTab;
        private Label createLabelAdminTab;
    }
}
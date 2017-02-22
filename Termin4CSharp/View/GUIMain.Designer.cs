using BrightIdeasSoftware;
using System.Drawing;
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.HeaderERP = new System.Windows.Forms.Label();
            this.ERPButton = new System.Windows.Forms.Button();
            this.ComboBoxERP = new System.Windows.Forms.ComboBox();
            this.ScrollBarERP = new System.Windows.Forms.VScrollBar();
            this.ListViewERP = new System.Windows.Forms.ListView();
            this.label13 = new System.Windows.Forms.Label();
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
            this.roomHolder = new BrightIdeasSoftware.ObjectListView();
            this.idColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.bnameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.capacityColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.floorColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rtypeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn9 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn10 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn11 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn12 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn13 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn14 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn15 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn16 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn17 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn18 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn19 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn20 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn21 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn22 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn23 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn24 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
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
            this.createLabelAdminTab = new System.Windows.Forms.Label();
            this.editLabelAdminTab = new System.Windows.Forms.Label();
            this.editObjectButton = new System.Windows.Forms.Button();
            this.createObjectButton = new System.Windows.Forms.Button();
            this.createTypeBox = new System.Windows.Forms.ComboBox();
            this.editArticleBox = new System.Windows.Forms.ComboBox();
            this.editTypeBox = new System.Windows.Forms.ComboBox();
            this.mainLabel2WS = new System.Windows.Forms.TabPage();
            this.mainLabel3ERP = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.searchERPButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.responseLabelLoginTab = new System.Windows.Forms.Label();
            this.tabPage3.SuspendLayout();
            this.OK.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.mainLabel1PK.SuspendLayout();
            this.loginTab.SuspendLayout();
            this.roomBookTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomHolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capacityTrackbarRoomBookingTab)).BeginInit();
            this.adminTab.SuspendLayout();
            this.mainLabel3ERP.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.HeaderERP);
            this.tabPage3.Controls.Add(this.ERPButton);
            this.tabPage3.Controls.Add(this.ComboBoxERP);
            this.tabPage3.Controls.Add(this.ScrollBarERP);
            this.tabPage3.Controls.Add(this.ListViewERP);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(931, 500);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ERP";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // HeaderERP
            // 
            this.HeaderERP.AutoSize = true;
            this.HeaderERP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderERP.Location = new System.Drawing.Point(32, 27);
            this.HeaderERP.Name = "HeaderERP";
            this.HeaderERP.Size = new System.Drawing.Size(759, 84);
            this.HeaderERP.TabIndex = 25;
            this.HeaderERP.Text = "Integrering och konfigurering av ERP-system\r\n\r\n";
            // 
            // ERPButton
            // 
            this.ERPButton.Location = new System.Drawing.Point(159, 122);
            this.ERPButton.Name = "ERPButton";
            this.ERPButton.Size = new System.Drawing.Size(75, 23);
            this.ERPButton.TabIndex = 24;
            this.ERPButton.Text = "Visa";
            this.ERPButton.UseVisualStyleBackColor = true;
            // 
            // ComboBoxERP
            // 
            this.ComboBoxERP.FormattingEnabled = true;
            this.ComboBoxERP.Items.AddRange(new object[] {
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
            this.ComboBoxERP.Location = new System.Drawing.Point(32, 124);
            this.ComboBoxERP.Name = "ComboBoxERP";
            this.ComboBoxERP.Size = new System.Drawing.Size(121, 32);
            this.ComboBoxERP.TabIndex = 23;
            // 
            // ScrollBarERP
            // 
            this.ScrollBarERP.Location = new System.Drawing.Point(551, 163);
            this.ScrollBarERP.Name = "ScrollBarERP";
            this.ScrollBarERP.Size = new System.Drawing.Size(20, 307);
            this.ScrollBarERP.TabIndex = 22;
            // 
            // ListViewERP
            // 
            this.ListViewERP.Location = new System.Drawing.Point(32, 163);
            this.ListViewERP.Name = "ListViewERP";
            this.ListViewERP.Size = new System.Drawing.Size(539, 307);
            this.ListViewERP.TabIndex = 21;
            this.ListViewERP.UseCompatibleStateImageBehavior = false;
            this.ListViewERP.View = System.Windows.Forms.View.Details;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(54, 96);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 32);
            this.label13.TabIndex = 26;
            this.label13.Text = "CRONUS\r\n";
            // 
            // OK
            // 
            this.OK.AccessibleName = "";
            this.OK.Controls.Add(this.tabPage1);
            this.OK.Controls.Add(this.mainLabel2WS);
            this.OK.Controls.Add(this.mainLabel3ERP);
            this.OK.Location = new System.Drawing.Point(2, 0);
            this.OK.Margin = new System.Windows.Forms.Padding(6);
            this.OK.Name = "OK";
            this.OK.SelectedIndex = 0;
            this.OK.Size = new System.Drawing.Size(2403, 1312);
            this.OK.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mainLabel1PK);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage1.Size = new System.Drawing.Size(2395, 1275);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Programkonstruktion";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // mainLabel1PK
            // 
            this.mainLabel1PK.Controls.Add(this.loginTab);
            this.mainLabel1PK.Controls.Add(this.roomBookTab);
            this.mainLabel1PK.Controls.Add(this.adminTab);
            this.mainLabel1PK.Location = new System.Drawing.Point(0, 0);
            this.mainLabel1PK.Margin = new System.Windows.Forms.Padding(6);
            this.mainLabel1PK.Name = "mainLabel1PK";
            this.mainLabel1PK.SelectedIndex = 0;
            this.mainLabel1PK.Size = new System.Drawing.Size(2395, 1275);
            this.mainLabel1PK.TabIndex = 3;
            // 
            // loginTab
            // 
            this.loginTab.Controls.Add(this.responseLabelLoginTab);
            this.loginTab.Controls.Add(this.mainLabelLoginTab);
            this.loginTab.Controls.Add(this.infoTextLoginTab);
            this.loginTab.Controls.Add(this.loginButtonLoginTab);
            this.loginTab.Controls.Add(this.label3);
            this.loginTab.Controls.Add(this.passwordTextfieldLogin);
            this.loginTab.Controls.Add(this.usernameTextfieldLogin);
            this.loginTab.Controls.Add(this.passwordLabelLoginTab);
            this.loginTab.Controls.Add(this.usernameLabelLoginTab);
            this.loginTab.Location = new System.Drawing.Point(4, 33);
            this.loginTab.Margin = new System.Windows.Forms.Padding(6);
            this.loginTab.Name = "loginTab";
            this.loginTab.Padding = new System.Windows.Forms.Padding(6);
            this.loginTab.Size = new System.Drawing.Size(2387, 1238);
            this.loginTab.TabIndex = 0;
            this.loginTab.Text = "Logga in ";
            this.loginTab.UseVisualStyleBackColor = true;
            // 
            // mainLabelLoginTab
            // 
            this.mainLabelLoginTab.AutoSize = true;
            this.mainLabelLoginTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabelLoginTab.Location = new System.Drawing.Point(94, 103);
            this.mainLabelLoginTab.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.mainLabelLoginTab.Name = "mainLabelLoginTab";
            this.mainLabelLoginTab.Size = new System.Drawing.Size(699, 48);
            this.mainLabelLoginTab.TabIndex = 7;
            this.mainLabelLoginTab.Text = "Rumsbokning för Ekonomihögskolan\r\n";
            // 
            // infoTextLoginTab
            // 
            this.infoTextLoginTab.AutoSize = true;
            this.infoTextLoginTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoTextLoginTab.Location = new System.Drawing.Point(94, 246);
            this.infoTextLoginTab.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.infoTextLoginTab.Name = "infoTextLoginTab";
            this.infoTextLoginTab.Size = new System.Drawing.Size(556, 25);
            this.infoTextLoginTab.TabIndex = 6;
            this.infoTextLoginTab.Text = "För att logga in, ange användaridentitet från Lucat nedan\r\n";
            // 
            // loginButtonLoginTab
            // 
            this.loginButtonLoginTab.Location = new System.Drawing.Point(99, 541);
            this.loginButtonLoginTab.Margin = new System.Windows.Forms.Padding(6);
            this.loginButtonLoginTab.Name = "loginButtonLoginTab";
            this.loginButtonLoginTab.Size = new System.Drawing.Size(138, 42);
            this.loginButtonLoginTab.TabIndex = 5;
            this.loginButtonLoginTab.Text = "Logga in";
            this.loginButtonLoginTab.UseVisualStyleBackColor = true;
            this.loginButtonLoginTab.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(94, 246);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 4;
            // 
            // passwordTextfieldLogin
            // 
            this.passwordTextfieldLogin.Location = new System.Drawing.Point(99, 434);
            this.passwordTextfieldLogin.Margin = new System.Windows.Forms.Padding(6);
            this.passwordTextfieldLogin.Name = "passwordTextfieldLogin";
            this.passwordTextfieldLogin.PasswordChar = '*';
            this.passwordTextfieldLogin.Size = new System.Drawing.Size(580, 29);
            this.passwordTextfieldLogin.TabIndex = 3;
            // 
            // usernameTextfieldLogin
            // 
            this.usernameTextfieldLogin.Location = new System.Drawing.Point(99, 343);
            this.usernameTextfieldLogin.Margin = new System.Windows.Forms.Padding(6);
            this.usernameTextfieldLogin.Name = "usernameTextfieldLogin";
            this.usernameTextfieldLogin.Size = new System.Drawing.Size(580, 29);
            this.usernameTextfieldLogin.TabIndex = 1;
            // 
            // passwordLabelLoginTab
            // 
            this.passwordLabelLoginTab.AutoSize = true;
            this.passwordLabelLoginTab.Location = new System.Drawing.Point(94, 404);
            this.passwordLabelLoginTab.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.passwordLabelLoginTab.Name = "passwordLabelLoginTab";
            this.passwordLabelLoginTab.Size = new System.Drawing.Size(100, 25);
            this.passwordLabelLoginTab.TabIndex = 2;
            this.passwordLabelLoginTab.Text = "Lösenord:";
            // 
            // usernameLabelLoginTab
            // 
            this.usernameLabelLoginTab.AutoSize = true;
            this.usernameLabelLoginTab.Location = new System.Drawing.Point(94, 314);
            this.usernameLabelLoginTab.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.usernameLabelLoginTab.Name = "usernameLabelLoginTab";
            this.usernameLabelLoginTab.Size = new System.Drawing.Size(152, 25);
            this.usernameLabelLoginTab.TabIndex = 0;
            this.usernameLabelLoginTab.Text = "Användarnamn:";
            // 
            // roomBookTab
            // 
            this.roomBookTab.Controls.Add(this.clearFiltersButtonRoomBookingTab);
            this.roomBookTab.Controls.Add(this.roomHolder);
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
            this.roomBookTab.Location = new System.Drawing.Point(4, 33);
            this.roomBookTab.Margin = new System.Windows.Forms.Padding(6);
            this.roomBookTab.Name = "roomBookTab";
            this.roomBookTab.Padding = new System.Windows.Forms.Padding(6);
            this.roomBookTab.Size = new System.Drawing.Size(2387, 1238);
            this.roomBookTab.TabIndex = 1;
            this.roomBookTab.Text = "Boka rum";
            this.roomBookTab.UseVisualStyleBackColor = true;
            this.roomBookTab.Enter += new System.EventHandler(this.tabPage5_GotFocus);
            // 
            // clearFiltersButtonRoomBookingTab
            // 
            this.clearFiltersButtonRoomBookingTab.Location = new System.Drawing.Point(11, 694);
            this.clearFiltersButtonRoomBookingTab.Margin = new System.Windows.Forms.Padding(6);
            this.clearFiltersButtonRoomBookingTab.Name = "clearFiltersButtonRoomBookingTab";
            this.clearFiltersButtonRoomBookingTab.Size = new System.Drawing.Size(220, 42);
            this.clearFiltersButtonRoomBookingTab.TabIndex = 21;
            this.clearFiltersButtonRoomBookingTab.Text = "Rensa filter";
            this.clearFiltersButtonRoomBookingTab.UseVisualStyleBackColor = true;
            this.clearFiltersButtonRoomBookingTab.Click += new System.EventHandler(this.button5_Click);
            // 
            // roomHolder
            // 
            this.roomHolder.AllColumns.Add(this.idColumn);
            this.roomHolder.AllColumns.Add(this.bnameColumn);
            this.roomHolder.AllColumns.Add(this.capacityColumn);
            this.roomHolder.AllColumns.Add(this.floorColumn);
            this.roomHolder.AllColumns.Add(this.rtypeColumn);
            this.roomHolder.AllColumns.Add(this.olvColumn1);
            this.roomHolder.AllColumns.Add(this.olvColumn2);
            this.roomHolder.AllColumns.Add(this.olvColumn3);
            this.roomHolder.AllColumns.Add(this.olvColumn4);
            this.roomHolder.AllColumns.Add(this.olvColumn5);
            this.roomHolder.AllColumns.Add(this.olvColumn6);
            this.roomHolder.AllColumns.Add(this.olvColumn7);
            this.roomHolder.AllColumns.Add(this.olvColumn8);
            this.roomHolder.AllColumns.Add(this.olvColumn9);
            this.roomHolder.AllColumns.Add(this.olvColumn10);
            this.roomHolder.AllColumns.Add(this.olvColumn11);
            this.roomHolder.AllColumns.Add(this.olvColumn12);
            this.roomHolder.AllColumns.Add(this.olvColumn13);
            this.roomHolder.AllColumns.Add(this.olvColumn14);
            this.roomHolder.AllColumns.Add(this.olvColumn15);
            this.roomHolder.AllColumns.Add(this.olvColumn16);
            this.roomHolder.AllColumns.Add(this.olvColumn17);
            this.roomHolder.AllColumns.Add(this.olvColumn18);
            this.roomHolder.AllColumns.Add(this.olvColumn19);
            this.roomHolder.AllColumns.Add(this.olvColumn20);
            this.roomHolder.AllColumns.Add(this.olvColumn21);
            this.roomHolder.AllColumns.Add(this.olvColumn22);
            this.roomHolder.AllColumns.Add(this.olvColumn23);
            this.roomHolder.AllColumns.Add(this.olvColumn24);
            this.roomHolder.CellEditUseWholeCell = false;
            this.roomHolder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColumn,
            this.bnameColumn,
            this.capacityColumn,
            this.floorColumn,
            this.rtypeColumn,
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5,
            this.olvColumn6,
            this.olvColumn7,
            this.olvColumn8,
            this.olvColumn9,
            this.olvColumn10,
            this.olvColumn11,
            this.olvColumn12,
            this.olvColumn13,
            this.olvColumn14,
            this.olvColumn15,
            this.olvColumn16,
            this.olvColumn17,
            this.olvColumn18,
            this.olvColumn19,
            this.olvColumn20,
            this.olvColumn21,
            this.olvColumn22,
            this.olvColumn23,
            this.olvColumn24});
            this.roomHolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.roomHolder.Location = new System.Drawing.Point(242, 151);
            this.roomHolder.Margin = new System.Windows.Forms.Padding(4);
            this.roomHolder.Name = "roomHolder";
            this.roomHolder.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.roomHolder.ShowGroups = false;
            this.roomHolder.Size = new System.Drawing.Size(2119, 1016);
            this.roomHolder.TabIndex = 22;
            this.roomHolder.UseCellFormatEvents = true;
            this.roomHolder.UseCompatibleStateImageBehavior = false;
            this.roomHolder.View = System.Windows.Forms.View.Details;
            this.roomHolder.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.formatRow);
            this.roomHolder.CellClick += RoomHolder_CellClick;
            //////////////this.room Holder.Cell Click += RoomHol der_Ce llClick;
            // 
            // idColumn
            // 
            this.idColumn.AspectName = "Id";
            // 
            // bnameColumn
            // 
            this.bnameColumn.AspectName = "BName";
            // 
            // capacityColumn
            // 
            this.capacityColumn.AspectName = "Capacity";
            // 
            // floorColumn
            // 
            this.floorColumn.AspectName = "Floor";
            // 
            // rtypeColumn
            // 
            this.rtypeColumn.AspectName = "RType";
            // 
            // olvColumn1
            // 
            this.olvColumn1.ButtonPadding = new System.Drawing.Size(1, 1);
            this.olvColumn1.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn1.Text = "00:00";
            // 
            // olvColumn2
            // 
            this.olvColumn2.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn2.Text = "01:00";
            // 
            // olvColumn3
            // 
            this.olvColumn3.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn3.Text = "02:00";
            // 
            // olvColumn4
            // 
            this.olvColumn4.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn4.Text = "03:00";
            // 
            // olvColumn5
            // 
            this.olvColumn5.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn5.Text = "04:00";
            // 
            // olvColumn6
            // 
            this.olvColumn6.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn6.Text = "05:00";
            // 
            // olvColumn7
            // 
            this.olvColumn7.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn7.Text = "06:00";
            // 
            // olvColumn8
            // 
            this.olvColumn8.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn8.Text = "07:00";
            // 
            // olvColumn9
            // 
            this.olvColumn9.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn9.Text = "08:00";
            // 
            // olvColumn10
            // 
            this.olvColumn10.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn10.Text = "09:00";
            // 
            // olvColumn11
            // 
            this.olvColumn11.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn11.Text = "10:00";
            // 
            // olvColumn12
            // 
            this.olvColumn12.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn12.Text = "11:00";
            // 
            // olvColumn13
            // 
            this.olvColumn13.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn13.Text = "12:00";
            // 
            // olvColumn14
            // 
            this.olvColumn14.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn14.Text = "13:00";
            // 
            // olvColumn15
            // 
            this.olvColumn15.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn15.Text = "14:00";
            // 
            // olvColumn16
            // 
            this.olvColumn16.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn16.Text = "15:00";
            // 
            // olvColumn17
            // 
            this.olvColumn17.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn17.Text = "16:00";
            // 
            // olvColumn18
            // 
            this.olvColumn18.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn18.Text = "17:00";
            // 
            // olvColumn19
            // 
            this.olvColumn19.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn19.Text = "18:00";
            // 
            // olvColumn20
            // 
            this.olvColumn20.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn20.Text = "19:00";
            // 
            // olvColumn21
            // 
            this.olvColumn21.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn21.Text = "20:00";
            // 
            // olvColumn22
            // 
            this.olvColumn22.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn22.Text = "21:00";
            // 
            // olvColumn23
            // 
            this.olvColumn23.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn23.Text = "22:00";
            // 
            // olvColumn24
            // 
            this.olvColumn24.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn24.Text = "23:00";
            // 
            // freeTextFilterTextbox
            // 
            this.freeTextFilterTextbox.Location = new System.Drawing.Point(17, 151);
            this.freeTextFilterTextbox.Margin = new System.Windows.Forms.Padding(6);
            this.freeTextFilterTextbox.Name = "freeTextFilterTextbox";
            this.freeTextFilterTextbox.Size = new System.Drawing.Size(211, 29);
            this.freeTextFilterTextbox.TabIndex = 8;
            this.freeTextFilterTextbox.TextChanged += new System.EventHandler(this.textBox3_TextChanged_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 751);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 25);
            this.label11.TabIndex = 19;
            this.label11.Text = "Antal platser:";
            // 
            // capacityTrackbarRoomBookingTab
            // 
            this.capacityTrackbarRoomBookingTab.Location = new System.Drawing.Point(11, 781);
            this.capacityTrackbarRoomBookingTab.Margin = new System.Windows.Forms.Padding(6);
            this.capacityTrackbarRoomBookingTab.Name = "capacityTrackbarRoomBookingTab";
            this.capacityTrackbarRoomBookingTab.Size = new System.Drawing.Size(220, 80);
            this.capacityTrackbarRoomBookingTab.TabIndex = 18;
            this.capacityTrackbarRoomBookingTab.Tag = "";
            this.capacityTrackbarRoomBookingTab.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // resourceLabelRoomBookingTab
            // 
            this.resourceLabelRoomBookingTab.AutoSize = true;
            this.resourceLabelRoomBookingTab.Location = new System.Drawing.Point(11, 535);
            this.resourceLabelRoomBookingTab.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.resourceLabelRoomBookingTab.Name = "resourceLabelRoomBookingTab";
            this.resourceLabelRoomBookingTab.Size = new System.Drawing.Size(96, 25);
            this.resourceLabelRoomBookingTab.TabIndex = 16;
            this.resourceLabelRoomBookingTab.Text = "Resurser:";
            // 
            // resourceFilterBox
            // 
            this.resourceFilterBox.FormattingEnabled = true;
            this.resourceFilterBox.Items.AddRange(new object[] {
            "Rullstolsanpassat",
            "Projektor"});
            this.resourceFilterBox.Location = new System.Drawing.Point(11, 565);
            this.resourceFilterBox.Margin = new System.Windows.Forms.Padding(6);
            this.resourceFilterBox.Name = "resourceFilterBox";
            this.resourceFilterBox.ScrollAlwaysVisible = true;
            this.resourceFilterBox.Size = new System.Drawing.Size(217, 76);
            this.resourceFilterBox.TabIndex = 15;
            this.resourceFilterBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.resourceFilterBox_ItemCheck);
            // 
            // roomLabelRoomBookingTab
            // 
            this.roomLabelRoomBookingTab.AutoSize = true;
            this.roomLabelRoomBookingTab.Location = new System.Drawing.Point(11, 380);
            this.roomLabelRoomBookingTab.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.roomLabelRoomBookingTab.Name = "roomLabelRoomBookingTab";
            this.roomLabelRoomBookingTab.Size = new System.Drawing.Size(58, 25);
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
            this.roomFilterBox.Location = new System.Drawing.Point(11, 410);
            this.roomFilterBox.Margin = new System.Windows.Forms.Padding(6);
            this.roomFilterBox.Name = "roomFilterBox";
            this.roomFilterBox.ScrollAlwaysVisible = true;
            this.roomFilterBox.Size = new System.Drawing.Size(217, 76);
            this.roomFilterBox.TabIndex = 11;
            this.roomFilterBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.roomFilterBox_ItemCheck);
            // 
            // buildingLabelRoomBookingTab
            // 
            this.buildingLabelRoomBookingTab.AutoSize = true;
            this.buildingLabelRoomBookingTab.Location = new System.Drawing.Point(11, 222);
            this.buildingLabelRoomBookingTab.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.buildingLabelRoomBookingTab.Name = "buildingLabelRoomBookingTab";
            this.buildingLabelRoomBookingTab.Size = new System.Drawing.Size(113, 25);
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
            this.buildingFilterBox.Location = new System.Drawing.Point(11, 251);
            this.buildingFilterBox.Margin = new System.Windows.Forms.Padding(6);
            this.buildingFilterBox.Name = "buildingFilterBox";
            this.buildingFilterBox.ScrollAlwaysVisible = true;
            this.buildingFilterBox.Size = new System.Drawing.Size(217, 76);
            this.buildingFilterBox.TabIndex = 9;
            this.buildingFilterBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.buildingFilterBox_ItemCheck);
            // 
            // toDateLabelRoomBookingTab
            // 
            this.toDateLabelRoomBookingTab.AutoSize = true;
            this.toDateLabelRoomBookingTab.Location = new System.Drawing.Point(11, 74);
            this.toDateLabelRoomBookingTab.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.toDateLabelRoomBookingTab.Name = "toDateLabelRoomBookingTab";
            this.toDateLabelRoomBookingTab.Size = new System.Drawing.Size(43, 25);
            this.toDateLabelRoomBookingTab.TabIndex = 7;
            this.toDateLabelRoomBookingTab.Text = "Till:";
            // 
            // fromDateLabelRoomBookingTab
            // 
            this.fromDateLabelRoomBookingTab.AutoSize = true;
            this.fromDateLabelRoomBookingTab.Location = new System.Drawing.Point(11, 26);
            this.fromDateLabelRoomBookingTab.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.fromDateLabelRoomBookingTab.Name = "fromDateLabelRoomBookingTab";
            this.fromDateLabelRoomBookingTab.Size = new System.Drawing.Size(58, 25);
            this.fromDateLabelRoomBookingTab.TabIndex = 6;
            this.fromDateLabelRoomBookingTab.Text = "Från:";
            // 
            // toDatePickerRoomBookingTab
            // 
            this.toDatePickerRoomBookingTab.Location = new System.Drawing.Point(127, 63);
            this.toDatePickerRoomBookingTab.Margin = new System.Windows.Forms.Padding(6);
            this.toDatePickerRoomBookingTab.Name = "toDatePickerRoomBookingTab";
            this.toDatePickerRoomBookingTab.Size = new System.Drawing.Size(363, 29);
            this.toDatePickerRoomBookingTab.TabIndex = 5;
            // 
            // fromDatePickerRoomBookingTab
            // 
            this.fromDatePickerRoomBookingTab.Location = new System.Drawing.Point(127, 15);
            this.fromDatePickerRoomBookingTab.Margin = new System.Windows.Forms.Padding(6);
            this.fromDatePickerRoomBookingTab.Name = "fromDatePickerRoomBookingTab";
            this.fromDatePickerRoomBookingTab.Size = new System.Drawing.Size(363, 29);
            this.fromDatePickerRoomBookingTab.TabIndex = 4;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Min profil",
            "Logga ut"});
            this.comboBox4.Location = new System.Drawing.Point(1454, 44);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(180, 32);
            this.comboBox4.TabIndex = 3;
            this.comboBox4.Text = "Användarnamn";
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
            this.adminTab.Location = new System.Drawing.Point(4, 33);
            this.adminTab.Margin = new System.Windows.Forms.Padding(6);
            this.adminTab.Name = "adminTab";
            this.adminTab.Padding = new System.Windows.Forms.Padding(6);
            this.adminTab.Size = new System.Drawing.Size(2387, 1238);
            this.adminTab.TabIndex = 3;
            this.adminTab.Text = "Admin";
            this.adminTab.UseVisualStyleBackColor = true;
            // 
            // createLabelAdminTab
            // 
            this.createLabelAdminTab.AutoSize = true;
            this.createLabelAdminTab.Font = new System.Drawing.Font("Helvetica Neue", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createLabelAdminTab.Location = new System.Drawing.Point(178, 282);
            this.createLabelAdminTab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.createLabelAdminTab.Name = "createLabelAdminTab";
            this.createLabelAdminTab.Size = new System.Drawing.Size(108, 38);
            this.createLabelAdminTab.TabIndex = 8;
            this.createLabelAdminTab.Text = "Skapa";
            // 
            // editLabelAdminTab
            // 
            this.editLabelAdminTab.AutoSize = true;
            this.editLabelAdminTab.Font = new System.Drawing.Font("Helvetica Neue", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editLabelAdminTab.Location = new System.Drawing.Point(178, 116);
            this.editLabelAdminTab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editLabelAdminTab.Name = "editLabelAdminTab";
            this.editLabelAdminTab.Size = new System.Drawing.Size(115, 38);
            this.editLabelAdminTab.TabIndex = 7;
            this.editLabelAdminTab.Text = "Editera";
            // 
            // editObjectButton
            // 
            this.editObjectButton.Location = new System.Drawing.Point(178, 214);
            this.editObjectButton.Margin = new System.Windows.Forms.Padding(6);
            this.editObjectButton.Name = "editObjectButton";
            this.editObjectButton.Size = new System.Drawing.Size(222, 42);
            this.editObjectButton.TabIndex = 6;
            this.editObjectButton.Text = "Editera";
            this.editObjectButton.UseVisualStyleBackColor = true;
            this.editObjectButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // createObjectButton
            // 
            this.createObjectButton.Location = new System.Drawing.Point(178, 378);
            this.createObjectButton.Margin = new System.Windows.Forms.Padding(6);
            this.createObjectButton.Name = "createObjectButton";
            this.createObjectButton.Size = new System.Drawing.Size(222, 42);
            this.createObjectButton.TabIndex = 5;
            this.createObjectButton.Text = "Skapa";
            this.createObjectButton.UseVisualStyleBackColor = true;
            this.createObjectButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // createTypeBox
            // 
            this.createTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.createTypeBox.FormattingEnabled = true;
            this.createTypeBox.Location = new System.Drawing.Point(178, 329);
            this.createTypeBox.Margin = new System.Windows.Forms.Padding(6);
            this.createTypeBox.Name = "createTypeBox";
            this.createTypeBox.Size = new System.Drawing.Size(219, 32);
            this.createTypeBox.TabIndex = 4;
            // 
            // editArticleBox
            // 
            this.editArticleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.editArticleBox.FormattingEnabled = true;
            this.editArticleBox.Location = new System.Drawing.Point(413, 162);
            this.editArticleBox.Margin = new System.Windows.Forms.Padding(6);
            this.editArticleBox.Name = "editArticleBox";
            this.editArticleBox.Size = new System.Drawing.Size(776, 32);
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
            this.editTypeBox.Location = new System.Drawing.Point(178, 162);
            this.editTypeBox.Margin = new System.Windows.Forms.Padding(6);
            this.editTypeBox.Name = "editTypeBox";
            this.editTypeBox.Size = new System.Drawing.Size(219, 32);
            this.editTypeBox.TabIndex = 1;
            this.editTypeBox.SelectedIndexChanged += new System.EventHandler(this.editTypeBox_SelectedIndexChanged);
            // 
            // mainLabel2WS
            // 
            this.mainLabel2WS.Location = new System.Drawing.Point(4, 33);
            this.mainLabel2WS.Margin = new System.Windows.Forms.Padding(6);
            this.mainLabel2WS.Name = "mainLabel2WS";
            this.mainLabel2WS.Padding = new System.Windows.Forms.Padding(6);
            this.mainLabel2WS.Size = new System.Drawing.Size(2395, 1275);
            this.mainLabel2WS.TabIndex = 1;
            this.mainLabel2WS.Text = "Webbservice";
            this.mainLabel2WS.UseVisualStyleBackColor = true;
            // 
            // mainLabel3ERP
            // 
            this.mainLabel3ERP.Controls.Add(this.label13);
            this.mainLabel3ERP.Controls.Add(this.label12);
            this.mainLabel3ERP.Controls.Add(this.searchERPButton);
            this.mainLabel3ERP.Controls.Add(this.comboBox1);
            this.mainLabel3ERP.Controls.Add(this.listView2);
            this.mainLabel3ERP.Location = new System.Drawing.Point(4, 33);
            this.mainLabel3ERP.Margin = new System.Windows.Forms.Padding(6);
            this.mainLabel3ERP.Name = "mainLabel3ERP";
            this.mainLabel3ERP.Padding = new System.Windows.Forms.Padding(6);
            this.mainLabel3ERP.Size = new System.Drawing.Size(2395, 1275);
            this.mainLabel3ERP.TabIndex = 2;
            this.mainLabel3ERP.Text = "ERP";
            this.mainLabel3ERP.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(53, 44);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(759, 84);
            this.label12.TabIndex = 25;
            this.label12.Text = "Integrering och konfigurering av ERP-system\r\n\r\n";
            // 
            // searchERPButton
            // 
            this.searchERPButton.Location = new System.Drawing.Point(123, 259);
            this.searchERPButton.Margin = new System.Windows.Forms.Padding(6);
            this.searchERPButton.Name = "searchERPButton";
            this.searchERPButton.Size = new System.Drawing.Size(138, 42);
            this.searchERPButton.TabIndex = 27;
            this.searchERPButton.Text = "Visa";
            // 
            // comboBox1
            // 
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
            this.comboBox1.Location = new System.Drawing.Point(123, 215);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(541, 32);
            this.comboBox1.TabIndex = 28;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(123, 313);
            this.listView2.Margin = new System.Windows.Forms.Padding(6);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1579, 609);
            this.listView2.TabIndex = 30;
            this.listView2.UseCompatibleStateImageBehavior = false;
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
            // responseLabelLoginTab
            // 
            this.responseLabelLoginTab.AutoSize = true;
            this.responseLabelLoginTab.Location = new System.Drawing.Point(97, 499);
            this.responseLabelLoginTab.Name = "responseLabelLoginTab";
            this.responseLabelLoginTab.Size = new System.Drawing.Size(0, 25);
            this.responseLabelLoginTab.TabIndex = 8;
            // 
            // GUIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(2407, 1310);
            this.Controls.Add(this.OK);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "GUIMain";
            this.Text = "Lunds universitet";
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.OK.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.mainLabel1PK.ResumeLayout(false);
            this.loginTab.ResumeLayout(false);
            this.loginTab.PerformLayout();
            this.roomBookTab.ResumeLayout(false);
            this.roomBookTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomHolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capacityTrackbarRoomBookingTab)).EndInit();
            this.adminTab.ResumeLayout(false);
            this.adminTab.PerformLayout();
            this.mainLabel3ERP.ResumeLayout(false);
            this.mainLabel3ERP.PerformLayout();
            this.ResumeLayout(false);

        }

        private void RoomHolder_CellClick1(object sender, CellClickEventArgs e) {
            throw new System.NotImplementedException();
        }

        private void RoomHolder_CellClick(object sender, CellClickEventArgs e) {
            this.Controller.HandleCellDoubleClick(sender, e);
        }

        #endregion

        private System.Windows.Forms.TabControl OK;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage mainLabel2WS;
        private System.Windows.Forms.TabPage mainLabel3ERP;
        private ComboBox comboBox1;
        private ListView listView2;
        private Button searchERPButton;
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
        private ObjectListView roomHolder;
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
        private Label label12;
        private Button editObjectButton;
        private Button clearFiltersButtonRoomBookingTab;
        private Label label13;
        private Label HeaderERP;
        private Label editLabelAdminTab;
        private Label createLabelAdminTab;
        private OLVColumn idColumn;
        private OLVColumn bnameColumn;
        private OLVColumn capacityColumn;
        private OLVColumn floorColumn;
        private OLVColumn rtypeColumn;
        private OLVColumn olvColumn1;
        private OLVColumn olvColumn2;
        private OLVColumn olvColumn3;
        private OLVColumn olvColumn4;
        private OLVColumn olvColumn5;
        private OLVColumn olvColumn6;
        private OLVColumn olvColumn7;
        private OLVColumn olvColumn8;
        private OLVColumn olvColumn9;
        private OLVColumn olvColumn10;
        private OLVColumn olvColumn11;
        private OLVColumn olvColumn12;
        private OLVColumn olvColumn13;
        private OLVColumn olvColumn14;
        private OLVColumn olvColumn15;
        private OLVColumn olvColumn16;
        private OLVColumn olvColumn17;
        private OLVColumn olvColumn18;
        private OLVColumn olvColumn19;
        private OLVColumn olvColumn20;
        private OLVColumn olvColumn21;
        private OLVColumn olvColumn22;
        private OLVColumn olvColumn23;
        private OLVColumn olvColumn24;
        private Button ERPButton;
        private ComboBox ComboBoxERP;
        private VScrollBar ScrollBarERP;
        private ListView ListViewERP;
        private TabPage tabPage3;
        private Label responseLabelLoginTab;
    }
}
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.vScrollBar4 = new System.Windows.Forms.VScrollBar();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label11 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.vScrollBar3 = new System.Windows.Forms.VScrollBar();
            this.label10 = new System.Windows.Forms.Label();
            this.checkedListBox3 = new System.Windows.Forms.CheckedListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.vScrollBar5 = new System.Windows.Forms.VScrollBar();
            this.listView2 = new System.Windows.Forms.ListView();
            this.OK.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.AccessibleName = "";
            this.OK.Controls.Add(this.tabPage1);
            this.OK.Controls.Add(this.tabPage2);
            this.OK.Controls.Add(this.tabPage3);
            this.OK.Location = new System.Drawing.Point(2, 0);
            this.OK.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.OK.Name = "OK";
            this.OK.SelectedIndex = 0;
            this.OK.Size = new System.Drawing.Size(1878, 1012);
            this.OK.TabIndex = 0;
            this.OK.SelectedIndexChanged += new System.EventHandler(this.OK_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl1);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Size = new System.Drawing.Size(1862, 965);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Programkonstruktion";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1870, 962);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.textBox2);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.textBox1);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Location = new System.Drawing.Point(8, 39);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage4.Size = new System.Drawing.Size(1854, 915);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Logga in ";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(102, 108);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(808, 55);
            this.label5.TabIndex = 7;
            this.label5.Text = "Rumsbokning för Ekonomihögskolan\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(102, 256);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(613, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "För att logga in, ange användaridentitet från Lucat nedan\r\n";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 523);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 44);
            this.button1.TabIndex = 5;
            this.button1.Text = "Logga in";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(102, 256);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 26);
            this.label3.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(108, 452);
            this.textBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(196, 31);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 421);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lösenord:";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(108, 358);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 31);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 327);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Användarnamn:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.vScrollBar4);
            this.tabPage5.Controls.Add(this.listView1);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.trackBar1);
            this.tabPage5.Controls.Add(this.vScrollBar3);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.checkedListBox3);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.vScrollBar2);
            this.tabPage5.Controls.Add(this.vScrollBar1);
            this.tabPage5.Controls.Add(this.checkedListBox2);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.checkedListBox1);
            this.tabPage5.Controls.Add(this.textBox3);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.dateTimePicker2);
            this.tabPage5.Controls.Add(this.dateTimePicker1);
            this.tabPage5.Controls.Add(this.comboBox4);
            this.tabPage5.Location = new System.Drawing.Point(8, 39);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage5.Size = new System.Drawing.Size(1854, 915);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.UseVisualStyleBackColor = true;
            this.tabPage5.Click += new System.EventHandler(this.tabPage5_Click);
            // 
            // vScrollBar4
            // 
            this.vScrollBar4.Location = new System.Drawing.Point(1536, 262);
            this.vScrollBar4.Name = "vScrollBar4";
            this.vScrollBar4.Size = new System.Drawing.Size(20, 590);
            this.vScrollBar4.TabIndex = 21;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Location = new System.Drawing.Point(498, 262);
            this.listView1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1074, 587);
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 735);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 25);
            this.label11.TabIndex = 19;
            this.label11.Text = "Antal platser:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 765);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(240, 90);
            this.trackBar1.TabIndex = 18;
            // 
            // vScrollBar3
            // 
            this.vScrollBar3.Location = new System.Drawing.Point(218, 588);
            this.vScrollBar3.Name = "vScrollBar3";
            this.vScrollBar3.Size = new System.Drawing.Size(17, 123);
            this.vScrollBar3.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 558);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 25);
            this.label10.TabIndex = 16;
            this.label10.Text = "Resurser:";
            // 
            // checkedListBox3
            // 
            this.checkedListBox3.FormattingEnabled = true;
            this.checkedListBox3.Items.AddRange(new object[] {
            "Rullstolsanpassat",
            "Projektor"});
            this.checkedListBox3.Location = new System.Drawing.Point(12, 588);
            this.checkedListBox3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.checkedListBox3.Name = "checkedListBox3";
            this.checkedListBox3.Size = new System.Drawing.Size(236, 108);
            this.checkedListBox3.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 396);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 25);
            this.label9.TabIndex = 14;
            this.label9.Text = "Rum:";
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(218, 427);
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(17, 123);
            this.vScrollBar2.TabIndex = 13;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(218, 262);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 123);
            this.vScrollBar1.TabIndex = 12;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "100",
            "101",
            "102",
            "103"});
            this.checkedListBox2.Location = new System.Drawing.Point(12, 427);
            this.checkedListBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(236, 108);
            this.checkedListBox2.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 231);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "Byggnader:";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "EC1",
            "EC2",
            "EC3",
            "ALFA"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 262);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(236, 108);
            this.checkedListBox1.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(18, 158);
            this.textBox3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(196, 31);
            this.textBox3.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 77);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "Till:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Från:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(138, 65);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(396, 31);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(138, 15);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(396, 31);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Min profil",
            "Logga ut"});
            this.comboBox4.Location = new System.Drawing.Point(1472, 0);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(196, 33);
            this.comboBox4.TabIndex = 3;
            this.comboBox4.Text = "Användarnamn";
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage2.Size = new System.Drawing.Size(1862, 965);
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
            this.tabPage3.Location = new System.Drawing.Point(8, 39);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage3.Size = new System.Drawing.Size(1862, 965);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ERP";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(318, 235);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 44);
            this.button2.TabIndex = 24;
            this.button2.Text = "Visa";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(64, 238);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(238, 33);
            this.comboBox1.TabIndex = 23;
            // 
            // vScrollBar5
            // 
            this.vScrollBar5.Location = new System.Drawing.Point(1102, 313);
            this.vScrollBar5.Name = "vScrollBar5";
            this.vScrollBar5.Size = new System.Drawing.Size(20, 590);
            this.vScrollBar5.TabIndex = 22;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(64, 313);
            this.listView2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1074, 587);
            this.listView2.TabIndex = 21;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // GUIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1880, 1008);
            this.Controls.Add(this.OK);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl OK;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.VScrollBar vScrollBar3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox checkedListBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.VScrollBar vScrollBar2;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.VScrollBar vScrollBar4;
        private System.Windows.Forms.ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ComboBox comboBox1;
        private VScrollBar vScrollBar5;
        private ListView listView2;
        private Button button2;
    }
}
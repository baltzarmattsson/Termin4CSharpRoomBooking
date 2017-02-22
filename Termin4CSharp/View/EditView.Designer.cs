using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Termin4CSharp.Model;
using Termin4CSharp.View.CustomControls;
using static Termin4CSharp.Controller.EditViewController;
using static Termin4CSharp.Utils;

namespace Termin4CSharp.View
{
    public partial class EditView : Form
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1539, 797);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // EditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1539, 797);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "EditView";
            this.Text = "EditView";
            this.ResumeLayout(false);

        }

        public void InitializeLoad()
        {
            if (this.Model != null)
                this.LoadModel(this.Model);
        }

        private void LoadModel(IModel model)
        {

            Label mainTitleLabel = new Label();
            mainTitleLabel.Size = new System.Drawing.Size(1500, 50);
            mainTitleLabel.Font = new System.Drawing.Font("Helvetica", 20);

            // Sätt Redigering/uppdatering/skapa ny dynamiskt vvvv
            string createOrEditLabelText = IsExistingItemInDatabase ? "Editering av" : "Skapa ny";
            mainTitleLabel.Text = string.Format("{0} {1} ", createOrEditLabelText, Utils.ConvertAttributeNameToDisplayName(model, model.GetType().Name));
            this.flowLayoutPanel1.Controls.Add(mainTitleLabel);
            this.flowLayoutPanel1.SetFlowBreak(mainTitleLabel, true);

            var attributes = Utils.GetAttributeInfo(model, MembersOptimizedFor.EDITVIEW);
            Label attributeName = null;
            foreach (var kv in attributes)
            {
                bool isIdentifyingAttribute = model.GetIdentifyingAttributes().ContainsKey(kv.Key) || (model is Login && kv.Key.Equals("Person"));

                bool controlIsVisible = true;
                // If the models id is autoincrementing, and we're not creating a new item, skip inserting a control for that value
                if (isIdentifyingAttribute && Utils.IdIsAutoIncrementInDb(model)) //!IsExisting
                    controlIsVisible = false; //continue;

                var value = kv.Value;
                if (controlIsVisible)
                {
                    attributeName = new Label();
                    attributeName.Text = Utils.ConvertAttributeNameToDisplayName(model, kv.Key);
                    this.flowLayoutPanel1.Controls.Add(attributeName);
                }

                Control control = null;

                // If IModel or List<IModel>, it's a referenced IModel/List<IModel>. For example, a Building that contains List<Room>, or Person that has a Role
                // Then we find all foreign models if it's an existing object in database, or all models available (i.e. all from that table) for the control.
                if (value is IModel || (value != null && value.GetType().IsGenericType))
                {
                    //List<IModel> imodels = Controller.GetReferenceAbleIModels(model, (IModel)value);
                    if (value is IModel)
                    {
                        Dictionary<IModel, bool> imodels = Controller.GetReferenceAbleIModels(model, ReferencedIModelType.SINGLE_IMODEL, value);
                        ComboBox comboBox = new ComboBox();
                        if (isIdentifyingAttribute)
                            comboBox.SelectedValueChanged += new EventHandler(this.Controller.HandleIdentifyingAttributesValueChange);
                        comboBox.Name = Utils.ConvertReferencedIModelToColumnName(model, kv.Key);
                        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        comboBox.Width = 500;
                        comboBox.Items.AddRange(imodels.Keys.ToArray());
                        if (imodels.Count > 0)
                        {
                            var filteredValues = imodels.Select(x => x).Where(x => x.Value);
                            object selectedValue = null;
                            if (filteredValues.Any())
                            {
                                selectedValue = filteredValues.First().Key;
                                comboBox.SelectedItem = selectedValue;
                            }
                        }
                        control = comboBox;
                        if (IsExistingItemInDatabase && model is Login && kv.Key.Equals("Person"))
                            control.Enabled = false;
                    }
                    else if (value.GetType().IsGenericType)
                    {
                        Controller.ViewHasListOfIModels = true;
                        Dictionary<IModel, bool> imodels = Controller.GetReferenceAbleIModels(model, ReferencedIModelType.LIST_OF_IMODELS, value);
                        //Sets the initial values to know what to update and insert when Save is pressed 
                        if (imodels.Any())
                            this.Controller.InitialStatusOnReferencingModels[imodels.Keys.First().GetType()] = imodels;
                        CheckedListBox checkBox = new CheckedListBox();
                        checkBox.Name = kv.Key;
                        checkBox.Width = 500;
                        foreach (var imodel in imodels)
                            checkBox.Items.Add(imodel.Key, imodel.Value);
                        checkBox.ItemCheck += new ItemCheckEventHandler(this.Controller.HandleListOfIModelsBoxCheck);
                        control = checkBox;
                    }
                }
                else
                {
                    // DateTime
                    if (value is DateTime)
                    {
                        DateTimePicker datePicker = new DateTimePicker();
                        datePicker.Width = 500;
                        datePicker.Name = kv.Key;
                        datePicker.Value = value == null || value.Equals(default(DateTime)) ? DateTime.Now : (DateTime)value;
                        if (model is Building || (model is Booking))
                        {// && (kv.Key.Equals("End_time") || kv.Key.Equals("Start_time")))) {
                            datePicker.Format = DateTimePickerFormat.Custom;
                            if (kv.Key.Equals("Timestamp"))
                                datePicker.CustomFormat = "yyyy-MM-dd \t HH:mm:ss";
                            else
                                datePicker.CustomFormat = "yyyy-MM-dd \t HH:00";
                            datePicker.ShowUpDown = true;
                        }
                        control = datePicker;
                        if (model is Booking && kv.Key.Equals("Timestamp"))
                            control.Enabled = false;
                        // Numbers
                    }
                    else if (value is Int16 || value is Int32 || value is Int64 || value is double)
                    {
                        NumberTextBox numTextBox = new NumberTextBox();
                        numTextBox.Width = 500;
                        numTextBox.Name = kv.Key;
                        if (isIdentifyingAttribute)
                            numTextBox.TextChanged += new EventHandler(this.Controller.HandleIdentifyingAttributesValueChange);
                        numTextBox.Text = "dummyval";
                        numTextBox.Text = value == null ? "0" : value.ToString();
                        control = numTextBox;
                        // Else
                    }
                    else
                    {
                        TextBox textBox = new TextBox();
                        textBox.Width = 500;
                        textBox.Name = kv.Key;
                        if (isIdentifyingAttribute)
                            textBox.TextChanged += new EventHandler(this.Controller.HandleIdentifyingAttributesValueChange);
                        textBox.Text = "dummyval";
                        textBox.Text = value == null ? "" : value.ToString();
                        control = textBox;
                    }
                }

                if (IsExistingItemInDatabase && isIdentifyingAttribute)
                    if (!(control is ComboBox || control is CheckedListBox))
                        this.oldIdentifyingAttribute[control.Name] = control.Text;
                control.Visible = controlIsVisible;
                this.flowLayoutPanel1.Controls.Add(control);
                flowLayoutPanel1.SetFlowBreak(control, controlIsVisible);
            }

            // Adding responselabel
            this.responseLabel = new Label();
            this.responseLabel.Text = "";
            this.responseLabel.Size = new System.Drawing.Size(1000, 50);
            this.responseLabel.Font = new System.Drawing.Font("Helvetica", 12);
            flowLayoutPanel1.Controls.Add(this.responseLabel);
            flowLayoutPanel1.SetFlowBreak(this.responseLabel, true);

            // Adding savebutton
            this.saveButton = new Button();
            this.saveButton.Text = "Spara";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            flowLayoutPanel1.Controls.Add(this.saveButton);

            // Adding deletebutton
            this.deleteButton = new Button();
            this.deleteButton.Text = "Ta bort";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            flowLayoutPanel1.Controls.Add(this.deleteButton);

            // Adding closebutton
            this.closeButton = new Button();
            this.closeButton.Text = "Stäng";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            flowLayoutPanel1.Controls.Add(this.closeButton);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Label responseLabel;
        private Button saveButton;
        private Button deleteButton;
        private Button closeButton;
    }
}
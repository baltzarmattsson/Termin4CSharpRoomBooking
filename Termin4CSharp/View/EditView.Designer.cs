using CustomRangeSelectorControl;
using System;
using System.Windows.Forms;
using Termin4CSharp.Model;
using Termin4CSharp.View.CustomControls;

namespace Termin4CSharp.View {
    partial class EditView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void LoadModel(IModel model) {

            Label mainTitleLabel = new Label();
            mainTitleLabel.Size = new System.Drawing.Size(1500, 50);
            mainTitleLabel.Font = new System.Drawing.Font("Helvetica", 20);
            
            // Sätt Redigering/uppdatering/skapa ny dynamiskt vvvv
            mainTitleLabel.Text = string.Format("Redigering: {0} ", model.GetType().Name);
            this.flowLayoutPanel1.Controls.Add(mainTitleLabel);

            Console.WriteLine("Private: loading: " + model.GetType());
            var attributes = Utils.GetAttributeInfo(model);
            Label attributeName = null;
            int indexCounter = 0;
            foreach (var kv in attributes) {
                var value = kv.Value;
                attributeName = new Label();
                attributeName.Text = Utils.ConvertAttributeNameToDisplayName(model, kv.Key);
                this.flowLayoutPanel1.Controls.Add(attributeName);
                // DateTime
                if (value is DateTime) {
                    DateTimePicker datePicker = new DateTimePicker();
                    datePicker.Width = 500;
                    datePicker.Value = value == null || value.Equals(default(DateTime)) ? DateTime.Now : (DateTime)value;
                    datePicker.Name = "id" + indexCounter;
                    this.flowLayoutPanel1.Controls.Add(datePicker);
                    flowLayoutPanel1.SetFlowBreak(datePicker, true);
                // Numbers
                } else if (value is Int16 || value is Int32 || value is Int64 || value is double) {
                    NumberTextBox numTextBox = new NumberTextBox();
                    numTextBox.Width = 500;
                    numTextBox.Text = value == null ? "" : value.ToString();
                    numTextBox.Name = "id" + indexCounter;
                    this.flowLayoutPanel1.Controls.Add(numTextBox);
                    flowLayoutPanel1.SetFlowBreak(numTextBox, true);
                // Else
                } else {
                    TextBox textBox = new TextBox();
                    textBox.Width = 500;
                    textBox.Text = value == null ? "" : value.ToString();
                    textBox.Name = "id" + indexCounter;
                    this.flowLayoutPanel1.Controls.Add(textBox);
                    flowLayoutPanel1.SetFlowBreak(textBox, true);
                }
                indexCounter++;
            }
        }

        #endregion
        private delegate void Testss();
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
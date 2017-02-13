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

        private void LoadModel(IModel model) {
            Console.WriteLine("Private: loading: " + model.GetType());
            var attributes = Utils.GetAttributeInfo(model);
            Label attributeName = null;
            foreach (var kv in attributes) {
                var value = kv.Value;
                attributeName = new Label();
                attributeName.Text = Utils.ConvertAttributeNameToDisplayName(model, kv.Key);
                this.flowLayoutPanel1.Controls.Add(attributeName);
                // DateTime
                if (value is DateTime) {
                    DateTimePicker datePicker = new DateTimePicker();
                    datePicker.Value = value == null ? default(DateTime) : (DateTime)value;
                    this.flowLayoutPanel1.Controls.Add(datePicker);
                // Numbers
                } else if (value is Int16 || value is Int32 || value is Int64 || value is double) {
                    NumberTextBox numTextBox = new NumberTextBox();
                    numTextBox.Text = value == null ? "" : value.ToString();
                    this.flowLayoutPanel1.Controls.Add(numTextBox);
                // Else
                } else {
                    TextBox textBox = new TextBox();
                    textBox.Text = value == null ? "" : value.ToString();
                    this.flowLayoutPanel1.Controls.Add(textBox);
                }
            }
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
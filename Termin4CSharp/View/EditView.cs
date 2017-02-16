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

namespace Termin4CSharp.View {
    public partial class EditView : Form {

        public IModel Model { get; set; }
        public EditViewController Controller { get; set; }
        public bool IsExistingItemInDatabase { get; private set; }

        public EditView(IModel model, bool isExistingItemInDatabase = true) {
            InitializeComponent();
            this.Model = model;
            LoadModel(model);
            this.IsExistingItemInDatabase = isExistingItemInDatabase;
        }

        public void SetResponseLabel(string message) {
            this.responseLabel.Text = message;
        }

        private void saveButton_Click(object sender, EventArgs e) {
            Console.WriteLine("save button?");
            this.Controller.HandleSaveButtonClick();
        }

        private void deleteButton_Click(object sender, EventArgs e) {
            Console.WriteLine("delete button");
            this.Controller.HandleDeleteButtonClick();
        }

        private void closeButton_Click(object sender, EventArgs e) {
            Console.WriteLine("closebutton");
            this.Controller.HandleCloseButtonClick();
        }

        public Control.ControlCollection GetControls() {
            return this.flowLayoutPanel1.Controls;
        }
        
    }
}

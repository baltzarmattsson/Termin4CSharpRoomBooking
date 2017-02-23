using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Termin4CSharp.Controller;
using Termin4CSharp.Model;

namespace Termin4CSharp.View
{
    public partial class EditView : Form
    {

        public IModel Model { get; set; }
        public EditViewController Controller { get; set; }
        public bool IsExistingItemInDatabase { get; private set; }
        private Dictionary<string, object> oldIdentifyingAttribute;

        public EditView(IModel model, bool isExistingItemInDatabase)
        {
            InitializeComponent();
            this.Model = model;
            this.IsExistingItemInDatabase = isExistingItemInDatabase;
            this.oldIdentifyingAttribute = new Dictionary<string, object>();
        }

        public void SetResponseLabel(string message)
        {
            this.responseLabel.Text = message;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("save button?");
            this.Controller.HandleSaveButtonClick(this.oldIdentifyingAttribute);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("delete button");
            this.Controller.HandleDeleteButtonClick();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("closebutton");
            this.Controller.HandleCloseButtonClick();
        }

        public Control.ControlCollection GetControls()
        {
            return this.flowLayoutControlHolder.Controls;
        }

        public ObjectListView GetBookingObjectListView()
        {
            foreach (var control in this.GetControls())
                if (control is ObjectListView)
                    return (ObjectListView)control;
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Termin4CSharp.DataAccessLayer;
using Termin4CSharp.Model;
using Termin4CSharp.View;
using Termin4CSharp.View.CustomControls;

namespace Termin4CSharp.Controller {
    public class EditViewController : IController {

        public EditView EditView { get; set; }
        private bool hasUnsavedChanges;

        public EditViewController(EditView editView) {
            this.EditView = editView;
            this.EditView.Controller = this;
        }

        public void Save(IModel model, bool isExistingObjectInDatbase) {
            DAL dal = new DAL();
            if (isExistingObjectInDatbase)
                dal.Update(model);
            else
                dal.Add(model);
            // TODO exception handling, gör först SqlException sedan Exception
        }
        public void Close() {
            if (hasUnsavedChanges) {
                // Är du säker, du har inte sparat
            } else
                EditView.Close();
        }
        public void Delete(IModel model) {
            DAL dal = new DAL();
            //Show popup - säkerställande
            dal.Remove(model);
        }

        private void UpdateResponseLabel(string message) {
            this.EditView.SetResponseLabel(message);
        }

        public void HasUnsavedChanges(bool value) {
            this.hasUnsavedChanges = value;
        }

        public void NotifyExceptionToView() {

        }
        public void HandleSaveButtonClick() {
            IModel model = null;
            var controlValues = this.ViewControlsToDictionary(EditView.GetControls());
            model = Utils.ParseWinFormsToIModel(EditView.Model, controlValues);
            if (model != null)
                Console.WriteLine(model);
        }
        public void HandleDeleteButtonClick() {

        }
        public void HandleCloseButtonClick() {

        }

        private Dictionary<string, object> ViewControlsToDictionary(Control.ControlCollection controls) {
            Dictionary<string, object> controlValues = new Dictionary<string, object>();
            foreach (Control c in controls) {
                if (c is TextBox) {
                    controlValues[c.Name] = ((TextBox)c).Text;
                } else if (c is NumberTextBox) {
                    try {
                        controlValues[c.Name] = Int32.Parse(((NumberTextBox)c).Text);
                    } catch (FormatException) {
                        EditView.SetResponseLabel("Ett nummer är för stort, försök igen");
                    }
                } else if (c is DateTimePicker) {
                    controlValues[c.Name] = ((DateTimePicker)c).Value;
                }
            }
            return controlValues;
        }

    }
}

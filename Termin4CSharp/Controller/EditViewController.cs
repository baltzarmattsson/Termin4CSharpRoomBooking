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
        public AdminTabController AdminController { get; set; }
        private bool hasUnsavedChanges;
        private bool isExistingObjectInDatabase = false;
        private Dictionary<string, object> identifyingAttributesValues;

        public EditViewController(EditView editView, AdminTabController adminController = null) {
            this.EditView = editView;
            this.EditView.Controller = this;
            this.isExistingObjectInDatabase = this.EditView.IsExistingItemInDatabase;
            this.AdminController = adminController;
            this.identifyingAttributesValues = new Dictionary<string, object>();

            this.EditView.InitializeLoad();
        }

        public int Save(IModel model) {
            DAL dal = new DAL();
            int affectedRows = 0;
            string dbMethod = "";
            if (isExistingObjectInDatabase) {
                affectedRows = dal.Update(model);
                dbMethod = "uppdaterad";
            } else {
                affectedRows = dal.Add(model);
                dbMethod = "tillagd";
            }
            if (affectedRows > 0)
                this.UpdateResponseLabel(string.Format("{0} {1}", model.GetType().Name, dbMethod));
            else
                this.UpdateResponseLabel(string.Format("Ingen {0} {1}", model.GetType().Name, dbMethod));
            return affectedRows;
                    
            
            // TODO exception handling, gör först SqlException sedan Exception
        }
        public void Close() {
            if (hasUnsavedChanges) {
                // Är du säker, du har inte sparat
            } else {
                EditView.Close();
                if (this.AdminController != null)
                    this.AdminController.HandleEditViewClosed();
            }
        }
        public int Delete(IModel model) {
            DAL dal = new DAL();
            //Show popup - säkerställande
            int affectedRows = dal.Remove(model);
            if (affectedRows > 0) {
                this.ClearFields(EditView.GetControls());
                this.UpdateResponseLabel(string.Format("{0} borttagen", model.GetType().Name));
            } else {
                this.UpdateResponseLabel(string.Format("Ingen {0} borttagen", model.GetType().Name));
            }
            return affectedRows;
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
            if (this.IdentifyingValuesAreNotEmpty()) {
                IModel model = null;
                var controlValues = this.ViewControlsToDictionary(EditView.GetControls());
                model = Utils.ParseWinFormsToIModel(EditView.Model, controlValues);
                if (model != null && model.GetIdentifyingAttributes().First().Value != null) {
                    Console.WriteLine(model);
                    this.Save(model);
                    this.isExistingObjectInDatabase = true;
                }
            } else {
                this.UpdateResponseLabel(string.Format("Identifierande attribut ({0}) kan ej vara tomt", string.Join(", ", this.identifyingAttributesValues.Keys)));
            }
        }
        public void HandleDeleteButtonClick() {
            IModel model = null;
            var controlValues = this.ViewControlsToDictionary(EditView.GetControls());
            model = Utils.ParseWinFormsToIModel(EditView.Model, controlValues);
            if (model != null) {
                this.Delete(model);
                this.isExistingObjectInDatabase = false;                
            }
        }
        public void HandleCloseButtonClick() {
            this.Close();
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

        private void ClearFields(Control.ControlCollection controls) {
            foreach (Control c in controls) {
                if (c is TextBox) {
                    ((TextBox)c).Text = "";
                } else if (c is NumberTextBox) {
                    ((NumberTextBox)c).Text = "";
                } else if (c is DateTimePicker) {
                    ((DateTimePicker)c).Value = DateTime.Now;
                }
            }
        }

        public void HandleIdentifyingAttributesTextChange(object sender, EventArgs e) {
            if (sender is TextBox)
                identifyingAttributesValues[((TextBox)sender).Name] = ((TextBox)sender).Text;
            else if (sender is NumberTextBox)
                identifyingAttributesValues[((NumberTextBox)sender).Name] = ((NumberTextBox)sender).Text;
            else
                throw new Exception("What type then...." + sender.GetType());
        }

        private bool IdentifyingValuesAreNotEmpty() {
            if (this.identifyingAttributesValues.Count == 0)
                return false;
            foreach (var idValue in identifyingAttributesValues)
                if (string.IsNullOrEmpty(idValue.Value.ToString()))
                    return false;
            return true;
        } 

    }
}

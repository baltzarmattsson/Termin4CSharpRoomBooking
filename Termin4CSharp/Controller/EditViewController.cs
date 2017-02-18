using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public int Save(IModel model, Dictionary<string, object> oldIdentifyingAttributes = null) {
            DAL dal = new DAL(this);
            int affectedRows = 0;
            string dbMethod = "";
            if (isExistingObjectInDatabase) {
                if (oldIdentifyingAttributes != null && oldIdentifyingAttributes.Count > 0)
                    affectedRows = dal.Update(model, oldIdentifyingAttributes);
                else
                    affectedRows = dal.Update(model);
                dbMethod = "uppdaterad";
            } else {
                affectedRows = dal.Add(model);
                dbMethod = "tillagd";
            }
            if (affectedRows > 0) {
                this.UpdateResponseLabel(string.Format("{0} {1}", model.GetType().Name, dbMethod));
                this.isExistingObjectInDatabase = true;
            } else if (affectedRows != -1) { //-1 is error from DAL
                this.UpdateResponseLabel(string.Format("Ingen {0} {1}", model.GetType().Name, dbMethod));
            }
            return affectedRows;
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
            DAL dal = new DAL(this);
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
        
        public void HandleSaveButtonClick(Dictionary<string, object> oldIdentifyingAttributes = null) {
            if (this.IdentifyingValuesAreNotEmpty()) {
                IModel model = null;
                var controlValues = this.ViewControlsToDictionary(EditView.GetControls());
                model = Utils.ParseWinFormsToIModel(EditView.Model, controlValues);
                if (model != null && model.GetIdentifyingAttributes().First().Value != null)
                    this.Save(model, oldIdentifyingAttributes);
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

        public enum ReferencedIModelType {
            SINGLE_IMODEL, LIST_OF_IMODELS
        }

        public List<IModel> GetReferenceAbleIModels(IModel target, ReferencedIModelType refModelType, object referencedIModelOrList) {

            List<IModel> fetchedIModelsFromDatabase = new List<IModel>();


            if (referencedIModelOrList != null) {
                DAL dal = new DAL(this);
                IModel iModelToFetch = null;
                if (refModelType == ReferencedIModelType.SINGLE_IMODEL) {
                    iModelToFetch = referencedIModelOrList as IModel;
                } else if (refModelType == ReferencedIModelType.LIST_OF_IMODELS) {
                    Type typeThatListHolds = referencedIModelOrList.GetType().GetGenericArguments()[0];
                    iModelToFetch = Activator.CreateInstance(typeThatListHolds) as IModel;
                }
                if (isExistingObjectInDatabase) {

                    // Setting WHERE-clause 
                    //var kvIdAtt = target.GetIdentifyingAttributes().First();
                    //string id = kvIdAtt.Key;
                    object identifyingValue = target.GetIdentifyingAttributes().First().Value;
                    var whereParams = new Dictionary<string, object>();
                    if (target is Building && iModelToFetch is Room)
                        whereParams["bname"] = identifyingValue;
                    //else if (target is Room && iModelToFetch is Building) 
                    
                    //whereParams[id] = idVal;
                    fetchedIModelsFromDatabase = dal.Get(iModelToFetch, whereParams);

                } else {
                    fetchedIModelsFromDatabase = dal.Get(iModelToFetch, selectAll: true);
                }

                // If it's a singular IModel being referenced, for example when a Login-object references a Person-object
                //if (referenceIModel != null) {
                //    if (isExistingObjectInDatabase) {
                //        var kvIdAtt = target.GetIdentifyingAttributes().First();
                //        string id = kvIdAtt.Key;
                //        object idVal = kvIdAtt.Value;
                //        var whereParams = new Dictionary<string, object>();
                //        whereParams[id] = idVal;
                //        referencableIModels = dal.Get(referenceIModel, whereParams);
                //    } else {
                //        referencableIModels = dal.Get(referenceIModel, selectAll: true);
                //    }
                //    // Else if it's a list of referenced models, for example the list of Rooms a Building holds
                //} else if (listOfReferenceIModels != null) {
                //    Type typeThatListHolds = listOfReferenceIModels.GetType().GetGenericArguments()[0];
                //    IModel instance = Activator.CreateInstance(typeThatListHolds) as IModel;
                //}

            }

            return fetchedIModelsFromDatabase;
        }

        public void HandleCloseButtonClick() {
            this.Close();
        }

        private Dictionary<string, object> ViewControlsToDictionary(Control.ControlCollection controls) {
            Dictionary<string, object> controlValues = new Dictionary<string, object>();
            foreach (Control c in controls) {
                if (c is NumberTextBox) {
                    NumberTextBox numTextBox = (NumberTextBox)c;
                    if (numTextBox.Text.Length > 0) {
                        try {
                            controlValues[c.Name] = Int32.Parse(numTextBox.Text);
                        } catch (FormatException) {
                            EditView.SetResponseLabel("Ett nummer är för stort, försök igen");
                        }
                    } else
                        controlValues[c.Name] = null;
                } else if (c is TextBox) {
                    TextBox txtBox = (TextBox)c;
                    controlValues[c.Name] = String.IsNullOrEmpty(txtBox.Text) ? null : txtBox.Text; 
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

        public void NotifyExceptionToView(string s) {
            this.UpdateResponseLabel(s);
        }        
    }
}

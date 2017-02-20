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
        private bool isExistingObjectInDatabase = false;
        private Dictionary<string, object> identifyingAttributesValues;

        public bool ViewHasListOfIModels = false;

        public Dictionary<Type, Dictionary<IModel, bool>> InitialStatusOnReferencingModels;
        private Dictionary<Type, Dictionary<IModel, bool>> changedStatusOnReferencingModels;
        //private Dictionary<Type, List<IModel>> listOfIModelsToBeReferenced;
        //private Dictionary<Type, List<IModel>> listOfIModelsToBeUnReferenced;

        public EditViewController(EditView editView, AdminTabController adminController = null) {
            this.EditView = editView;
            this.EditView.Controller = this;
            this.isExistingObjectInDatabase = this.EditView.IsExistingItemInDatabase;
            this.AdminController = adminController;
            this.identifyingAttributesValues = new Dictionary<string, object>();

            //this.listOfIModelsToBeReferenced = new Dictionary<Type, List<IModel>>();
            //this.listOfIModelsToBeUnReferenced = new Dictionary<Type, List<IModel>>();
            this.InitialStatusOnReferencingModels = new Dictionary<Type, Dictionary<IModel, bool>>();
            this.changedStatusOnReferencingModels = new Dictionary<Type, Dictionary<IModel, bool>>();

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
            EditView.Close();
            if (this.AdminController != null)
                this.AdminController.HandleEditViewClosed();

        }
        public int Delete(IModel model) {
            DAL dal = new DAL(this);
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
        
        public void HandleSaveButtonClick(Dictionary<string, object> oldIdentifyingAttributes = null) {
            if (this.IdentifyingValuesAreNotEmpty()) {
                IModel model = null;
                var controlValues = this.ViewControlsToDictionary(EditView.GetControls());
                model = Utils.ParseWinFormsToIModel(EditView.Model, controlValues);
                if (model != null && model.GetIdentifyingAttributes().First().Value != null) {
                    this.Save(model, oldIdentifyingAttributes);
                    if (this.ViewHasListOfIModels) {
                        // Foreach the keys in the originalvalues (there can be multiple lists/checklistboxes)
                        //foreach (var initStatusForType in InitialStatusOnReferencingModels) {
                        foreach (var changedStatusForType in this.changedStatusOnReferencingModels) {

                            Type referencedType = changedStatusForType.Key;
                            Dictionary<IModel, bool> changedStatus = changedStatusForType.Value;
                            Dictionary<IModel, bool> initialStatus = this.InitialStatusOnReferencingModels.ContainsKey(referencedType) ? this.InitialStatusOnReferencingModels[referencedType] : null;


                            //Type referencedType = initStatusForType.Key;
                            //Dictionary<IModel, bool> initialStatus = initStatusForType.Value;
                            //Dictionary<IModel, bool> changedStatus = this.changedStatusOnReferencingModels[referencedType];
                            //var imodelsToBeReferenced = this.listOfIModelsToBeReferenced[referencedType];

                            //List<IModel> toBeAdded = initialStatus.Select(x => x.Key).Intersect(changedStatus);

                            //resultDict = primaryDict.Keys.Intersect(secondaryDict.Keys)
                            //.ToDictionary(t => t, t => primaryDict[t]);
                            //var resDict = initialStatus.Keys.Intersect(changedStatus.Keys);

                            List<IModel> toBeAdded = new List<IModel>();
                            List<IModel> toUpdateToNull = new List<IModel>();

                            var intersected = initialStatus.Keys.Intersect(changedStatus.Keys).ToList();
                            foreach (var intersectedModel in intersected) {
                                if (initialStatus[intersectedModel] == true && changedStatus[intersectedModel] == false)
                                    toUpdateToNull.Add(intersectedModel);
                                else if (initialStatus[intersectedModel] == false && changedStatus[intersectedModel] == true)
                                    toBeAdded.Add(intersectedModel);
                            }

                            //SqlCommand add = null, setnull = null;
                            //if (toBeAdded.Any())
                            //    add = Utils.ConnectOrNullReferencedIModelsToIModelToQuery(toBeAdded, model, true);
                            //if (toUpdateToNull.Any())
                            //    setnull = Utils.ConnectOrNullReferencedIModelsToIModelToQuery(toUpdateToNull, model, false);

                            DAL dal = new DAL(this);
                            int added = 0, updated = 0;
                            if (toBeAdded.Any())
                                added = dal.ConnectOrNullReferencedIModelsToIModelToQuery(toBeAdded, model, true);
                            if (toUpdateToNull.Any())
                                updated = dal.ConnectOrNullReferencedIModelsToIModelToQuery(toUpdateToNull, model, false);
                            
                            //List<IModel> toBeAdded = initialStatus.Select(x => x).Where(y => y.Value).Intersect()
                            //List<IModel> toUpdateToNull = null;

                        }
                    }
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

        public enum ReferencedIModelType {
            SINGLE_IMODEL, LIST_OF_IMODELS
        }

        // Gets a list of all values that can be referenced by the target-model. The bool-parameter tells us
        // if it's a currently connected/referenced object or not. If it is, it's later marked as checked/selected in the
        // EditView
        public Dictionary<IModel, bool> GetReferenceAbleIModels(IModel target, ReferencedIModelType refModelType, object referencedIModelOrList) {
            
            Dictionary<IModel, bool> fetchedIModelsFromDatabase = new Dictionary<IModel, bool>();

            if (referencedIModelOrList != null) {
                DAL dal = new DAL(this);
                IModel iModelToFetch = null;
                if (refModelType == ReferencedIModelType.SINGLE_IMODEL) {
                    iModelToFetch = referencedIModelOrList as IModel;
                } else if (refModelType == ReferencedIModelType.LIST_OF_IMODELS) {
                    Type typeThatListHolds = referencedIModelOrList.GetType().GetGenericArguments()[0];
                    iModelToFetch = Activator.CreateInstance(typeThatListHolds) as IModel;
                }

                // Loads all objects to the list, and checks if they're connected already by comparing the foreignkey-column with the target-IModel ID
                List<IModel> allObjects = dal.Get(iModelToFetch, selectAll: true);

                if (target is Building && iModelToFetch is Room)
                    fetchedIModelsFromDatabase = allObjects.ToDictionary(x => x, x => ((Room)x).BName != null ? ((Room)x).BName.Equals(((Building)target).Name) : false);
                //else if (target is )
                else if (target is Person && iModelToFetch is Role)
                    fetchedIModelsFromDatabase = allObjects.ToDictionary(x => x, x => ((Role)x).Name.Equals(((Person)target).RoleName));
                else if (target is Booking && iModelToFetch is Room)
                    fetchedIModelsFromDatabase = allObjects.ToDictionary(x => x, x => ((Room)x).Id.Equals(((Booking)target).RoomId));
                else if (target is Booking && iModelToFetch is Person)
                    fetchedIModelsFromDatabase = allObjects.ToDictionary(x => x, x => ((Person)x).Id.Equals(((Booking)target).PersonId));
                else if (target is Login && iModelToFetch is Person)
                    fetchedIModelsFromDatabase = allObjects.ToDictionary(x => x, x => ((Person)x).Id.Equals(((Login)target).PersonId));
                else if (target is Room && iModelToFetch is Building)
                    fetchedIModelsFromDatabase = allObjects.ToDictionary(x => x, x => ((Building)x).Name.Equals(((Room)target).BName));
                else if (target is Room && iModelToFetch is RoomType)
                    fetchedIModelsFromDatabase = allObjects.ToDictionary(x => x, x => ((RoomType)x).Type.Equals(((Room)target).RType));
                //else if (target is Room && iModelToFetch is Resource)
                //    fetchedIModelsFromDatabase = allObjects.ToDictionary(x => x, x => ((Resource)x).)
                else
                    throw new Exception("unhandled type");

                // Now we set "True" to the objects that are 
                // Setting WHERE-clause 
                //object identifyingValue = target.GetIdentifyingAttributes().First().Value;
                //var whereParams = new Dictionary<string, object>();
                //if (target is Building && iModelToFetch is Room)
                //    whereParams["bname"] = identifyingValue;
                //List<IModel> currentlyReferencedObjects = dal.Get(iModelToFetch, whereParams);


                //if (isExistingObjectInDatabase) {

                // Setting WHERE-clause 
                //object identifyingValue = target.GetIdentifyingAttributes().First().Value;
                //var whereParams = new Dictionary<string, object>();
                //if (target is Building && iModelToFetch is Room)
                //    whereParams["bname"] = identifyingValue;
                //    //else if (target is Room && iModelToFetch is Building) 

                //    fetchedIModelsFromDatabase = dal.Get(iModelToFetch, whereParams);

                //} else {
                //    fetchedIModelsFromDatabase = dal.Get(iModelToFetch, selectAll: true);
                //}

            }

            return fetchedIModelsFromDatabase;
        }

        public void HandleListOfIModelsBoxCheck(object sender, EventArgs e) {
            CheckedListBox checkBox = (CheckedListBox)sender;
            ItemCheckEventArgs check = (ItemCheckEventArgs)e;
            IModel selectedIModel = (IModel)checkBox.SelectedItem;
            Type modelType = selectedIModel.GetType();

            // If the lists arent initialized, initialize them
            if (this.changedStatusOnReferencingModels.ContainsKey(modelType) == false) {
                this.changedStatusOnReferencingModels[modelType] = new Dictionary<IModel, bool>();
            }
            Dictionary<IModel, bool> changedList = this.changedStatusOnReferencingModels[modelType];
            //if (changedList.ContainsKey(selectedIModel))
                this.changedStatusOnReferencingModels[modelType][selectedIModel] = check.NewValue == CheckState.Checked;


            //if (!listOfIModelsToBeReferenced.ContainsKey(modelType) && !listOfIModelsToBeUnReferenced.ContainsKey(modelType)) {
            //    this.listOfIModelsToBeReferenced[modelType] = new List<IModel>();
            //    this.listOfIModelsToBeUnReferenced[modelType] = new List<IModel>();
            //}

            //if (check.NewValue == CheckState.Checked)
            //    //this.listOfIModelsToBeReferenced[modelType].Add((IModel)checkBox.SelectedItem);
            //else if (check.NewValue == CheckState.Unchecked)
            //    //this.listOfIModelsToBeUnReferenced[modelType].Add((IModel)checkBox.SelectedItem);
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
                } else if (c is ComboBox) {
                    IModel selectedIModel = (IModel)((ComboBox)c).SelectedItem;
                    if (selectedIModel != null)
                        controlValues[c.Name] = selectedIModel.GetIdentifyingAttributes().First().Value;
                    else
                        controlValues[c.Name] = null;
                } else if (c is CheckedListBox) {
                    // Skip, handled after the main-query is done
                }
            }
            return controlValues;
        }

        // TODO ta bort denna och bara stäng fönstret istället
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

        public void HandleIdentifyingAttributesValueChange(object sender, EventArgs e) {
            if (sender is TextBox)
                identifyingAttributesValues[((TextBox)sender).Name] = ((TextBox)sender).Text;
            else if (sender is NumberTextBox)
                identifyingAttributesValues[((NumberTextBox)sender).Name] = ((NumberTextBox)sender).Text;
            else if (sender is ComboBox) {
                ComboBox cb = (ComboBox)sender;
                IModel selVal = (IModel)cb.SelectedItem;
                var kv = selVal.GetIdentifyingAttributes();
                var kvfirstval = kv.First().Value;
                identifyingAttributesValues[((ComboBox)sender).Name] = ((IModel)((ComboBox)sender).SelectedItem).GetIdentifyingAttributes().First().Value;
            } else
                throw new Exception("What type then...." + sender.GetType());
        }

        private bool IdentifyingValuesAreNotEmpty() {
            if (Utils.IdIsAutoIncrementInDb(EditView.Model))
                return true;
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

using BrightIdeasSoftware;
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

namespace Termin4CSharp.Controller
{
    public class EditViewController : IController
    {

        public EditView EditView { get; set; }
        public AdminTabController AdminController { get; set; }
        public EditViewController OuterEditViewController { get; set; }
        public GUIMainController GuiMainController { get; set; }
        private bool isExistingObjectInDatabase = false;
        private Dictionary<string, object> identifyingAttributesValues;

        public bool ViewHasListOfIModels = false;

        public Dictionary<Type, Dictionary<IModel, bool>> InitialStatusOnReferencingModels;
        private Dictionary<Type, Dictionary<IModel, bool>> changedStatusOnReferencingModels;

        public DateTimePicker BookingStartDatePicker { get; set; }
        public DateTimePicker BookingEndDatePicker { get; set; }

        public EditViewController(EditView editView, AdminTabController adminController = null, EditViewController outerEditViewController = null, GUIMainController guiMainController = null)
        {
            this.EditView = editView;
            this.EditView.Controller = this;
            this.isExistingObjectInDatabase = this.EditView.IsExistingItemInDatabase;
            this.AdminController = adminController;
            this.OuterEditViewController = outerEditViewController;
            this.GuiMainController = guiMainController;
            this.identifyingAttributesValues = new Dictionary<string, object>();

            this.InitialStatusOnReferencingModels = new Dictionary<Type, Dictionary<IModel, bool>>();
            this.changedStatusOnReferencingModels = new Dictionary<Type, Dictionary<IModel, bool>>();

            this.EditView.InitializeLoad();
        }
        /// <summary>
        /// Called when the user clicks Close. Calls the AdminTabController to update its combobox values. If this EditView (inner) is created from within another EditView (outer), 
        /// the outer controller is called to update its values inside that EditView. For example a Person that edits their list of Bookings, and when the editing of the Bookings are complete, the
        /// list are updated.
        /// </summary>
        public void Close()
        {
            EditView.Close();
            if (this.AdminController != null)
                this.AdminController.HandleEditViewClosed();
            if (this.OuterEditViewController != null)
                this.UpdateBookingListInPersonEditingView();
            if (this.GuiMainController != null)
                this.GuiMainController.LoadRooms(this.GuiMainController.OnDateFilter);
        }
        /// <summary>
        /// Deletes an IModel
        /// </summary>
        /// <param name="model">IModel to be deleted</param>
        /// <returns></returns>
        public int Delete(IModel model)
        {
            DAL dal = new DAL(this);
            int affectedRows = dal.Remove(model);
            if (affectedRows > 0)
            {
                this.SetAllControlsDisabledExceptClose();
                this.UpdateResponseLabel(string.Format("{0} borttagen", model.GetType().Name));
            }
            else
            {
                this.UpdateResponseLabel(string.Format("Ingen {0} borttagen", model.GetType().Name));
            }
            return affectedRows;
        }
        /// <summary>
        /// Called when the user presses Save or Add to disable all controls except the Close button
        /// </summary>
        private void SetAllControlsDisabledExceptClose()
        {
            foreach (Control c in this.EditView.GetControls())
                if (c.Text.Equals("Stäng") == false)
                    c.Enabled = false;
            
        }
        /// <summary>
        /// Updates the responselabel
        /// </summary>
        /// <param name="message">Message to be set</param>
        /// <param name="concat">If the string should concat its previous text, or replace it</param>
        private void UpdateResponseLabel(string message, bool concat = false)
        {
            this.EditView.SetResponseLabel(message, concat);
        }
        /// <summary>
        /// Called when the user clicks the Save button. Parses the controls in the EditView to an IModel and saves/updates it in the database
        /// </summary>
        /// <param name="oldIdentifyingAttributes">If the IModel has changed their identifying attribute, these are the old/current identifying attributes</param>
        public void HandleSaveButtonClick(Dictionary<string, object> oldIdentifyingAttributes = null)
        {
            if (this.IdentifyingValuesAreNotEmpty())
            {
                IModel model = null;
                var controlValues = this.ViewControlsToDictionary(EditView.GetControls());
                if (controlValues != null)
                {
                    model = Utils.ParseWinFormsToIModel(EditView.Model, controlValues, QueryType.ADD);
                    if (model != null && model.GetIdentifyingAttributes().First().Value != null)
                    {

                        if (model is Building)
                        {
                            DateTime opening, closing;
                            opening = ((Building)model).Avail_start;
                            closing = ((Building)model).Avail_end;
                            if (opening > closing)
                            {
                                this.UpdateResponseLabel("Öppningstid kan inte vara senare än stängningstid");
                                return;
                            }
                        }

                        //Special case for booking, since it cannot overlap another booking
                        //But if it's an update to an existing item, we're not doing the check
                        if (model is Booking)
                        {
                            Booking parsedBooking = (Booking)model;
                            if (parsedBooking.RoomId == null || parsedBooking.PersonId == null || parsedBooking.Start_time == default(DateTime) || parsedBooking.End_time == default(DateTime))
                            {
                                this.UpdateResponseLabel("Något av följande fält är tomt, vänligen fyll i alla obligatoriska fält (Person, Rum, Starttid, Sluttid");
                                return;
                            }
                            if (isExistingObjectInDatabase == false)
                            {
                                DAL d = new DAL(this);
                                bool isBookable = d.IsRoomBookableOnDate(parsedBooking.RoomId, parsedBooking.Start_time, parsedBooking.End_time);
                                if (isBookable == false)
                                {
                                    this.UpdateResponseLabel("Rummet är redan bokad denna tid, vänligen välj en annan");
                                    return;
                                }
                                
                            }
                            DateTime startDate = parsedBooking.Start_time;
                            DateTime endDate = parsedBooking.End_time;
                            startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startDate.Hour, 0, 0);
                            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, endDate.Hour, 0, 0);
                            ((Booking)model).Start_time = startDate;
                            ((Booking)model).End_time = endDate;
                        }


                        // SAVING OBJECT

                        DAL dal = new DAL(this);
                        int affectedRows = 0;
                        string dbMethod = "";
                        if (isExistingObjectInDatabase)
                        {
                            if (oldIdentifyingAttributes != null && oldIdentifyingAttributes.Count > 0)
                                affectedRows = dal.Update(model, oldIdentifyingAttributes);
                            else
                                affectedRows = dal.Update(model);
                            dbMethod = "uppdaterad";
                        }
                        else
                        {
                            affectedRows = dal.Add(model);
                            dbMethod = "tillagd";
                        }
                        string displayName = Utils.ConvertAttributeNameToDisplayName(model, model.GetType().Name);
                        displayName = displayName[0].ToString().ToUpper() + displayName.Substring(1);
                        if (affectedRows > 0)
                        {
                            this.UpdateResponseLabel(string.Format("{0} {1}", displayName, dbMethod));
                            this.isExistingObjectInDatabase = true;
                            this.SetAllControlsDisabledExceptClose();
                        }
                        else if (affectedRows != -1)
                        { //-1 is error from DAL
                            this.UpdateResponseLabel(string.Format("Ingen {0} {1}", displayName, dbMethod));
                        }

                        // END OF SAVING

                        if (affectedRows > 0 && this.ViewHasListOfIModels)
                        {
                            // Foreach the keys in the originalvalues (there can be multiple lists/checklistboxes)
                            foreach (var changedStatusForType in this.changedStatusOnReferencingModels)
                            {

                                Type referencedType = changedStatusForType.Key;
                                Dictionary<IModel, bool> changedStatus = changedStatusForType.Value;
                                Dictionary<IModel, bool> initialStatus = this.InitialStatusOnReferencingModels.ContainsKey(referencedType) ? this.InitialStatusOnReferencingModels[referencedType] : null;

                                List<IModel> toBeAdded = new List<IModel>();
                                List<IModel> toDeleteOrUpdateToNull = new List<IModel>();

                                bool doOrdinaryAddAndDelete = false;

                                var intersected = initialStatus.Keys.Intersect(changedStatus.Keys).ToList();
                                foreach (var intersectedModel in intersected)
                                {
                                    if (initialStatus[intersectedModel] == true && changedStatus[intersectedModel] == false)
                                        toDeleteOrUpdateToNull.Add(intersectedModel);
                                    else if (initialStatus[intersectedModel] == false && changedStatus[intersectedModel] == true)
                                        toBeAdded.Add(intersectedModel);
                                }
                                // If it's an associationtable, and a changedStatus-dict contains elements
                                // delete all associated-table-objects with ID from each IDs
                                if (model is Room && changedStatus.Any() && changedStatus.First().Key is Resource)
                                {
                                    toBeAdded = toBeAdded.Select(x => (IModel)new Room_Resource(((Room)model).Id, ((Resource)x).Id)).ToList();
                                    toDeleteOrUpdateToNull = toDeleteOrUpdateToNull.Select(x => (IModel)new Room_Resource(((Room)model).Id, ((Resource)x).Id)).ToList();
                                    doOrdinaryAddAndDelete = true;
                                }

                                dal = new DAL(this);
                                int added = 0, updatedOrRemoved = 0;

                                if (doOrdinaryAddAndDelete && (toBeAdded.Any() || toDeleteOrUpdateToNull.Any()))
                                {
                                    foreach (IModel add in toBeAdded)
                                        added += dal.Add(add);
                                    foreach (IModel remove in toDeleteOrUpdateToNull)
                                        updatedOrRemoved += dal.Remove(remove);
                                }
                                else if (!doOrdinaryAddAndDelete)
                                {
                                    if (toBeAdded.Any())
                                        added = dal.ConnectOrNullReferencedIModelsToIModelToQuery(toBeAdded, model, true);
                                    if (toDeleteOrUpdateToNull.Any())
                                        updatedOrRemoved = dal.ConnectOrNullReferencedIModelsToIModelToQuery(toDeleteOrUpdateToNull, model, false);
                                }
                            }
                        }
                    }

                    else
                    {
                        this.UpdateResponseLabel(string.Format("Identifierande attribut ({0}) kan ej vara tomt", string.Join(", ", this.identifyingAttributesValues.Keys)));
                    }
                }
            }
        }
        /// <summary>
        /// Called when the user clicks Delete. The IModel is parsed from the controls in the EditView and is then attempted to be deleted from the database
        /// </summary>
        public void HandleDeleteButtonClick()
        {
            IModel model = null;
            var controlValues = this.ViewControlsToDictionary(EditView.GetControls());
            model = Utils.ParseWinFormsToIModel(EditView.Model, controlValues, QueryType.REMOVE);
            if (model != null)
            {
                this.Delete(model);
                this.isExistingObjectInDatabase = false;
            }
        }

        public enum ReferencedIModelType
        {
            SINGLE_IMODEL, LIST_OF_IMODELS
        }
        /// <summary>
        /// Gets a list of all values that can be referenced by the target-model. The bool-parameter tells us
        /// if it's a currently connected/referenced object or not. If it is, it's later marked as checked/selected in the
        /// EditView
        /// </summary>
        /// <param name="target">The target IModel which references other IModels</param>
        /// <param name="refModelType">What type the referenced IModels are, i.e. if the target IModel references a single IModel or multiple</param>
        /// <param name="referencedIModelOrListToFetch">The IModel or list of IModels to fetch from the database</param>
        /// <returns>A list of all referencable IModels to the target IModel</returns>
        public Dictionary<IModel, bool> GetReferenceAbleIModels(IModel target, ReferencedIModelType refModelType, object referencedIModelOrListToFetch)
        {

            Dictionary<IModel, bool> fetchedIModelsFromDatabase = new Dictionary<IModel, bool>();

            if (referencedIModelOrListToFetch != null)
            {
                DAL dal = new DAL(this);
                IModel iModelToFetch = null;
                if (refModelType == ReferencedIModelType.SINGLE_IMODEL)
                {
                    iModelToFetch = referencedIModelOrListToFetch as IModel;
                }
                else if (refModelType == ReferencedIModelType.LIST_OF_IMODELS)
                {
                    Type typeThatListHolds = referencedIModelOrListToFetch.GetType().GetGenericArguments()[0];
                    iModelToFetch = Activator.CreateInstance(typeThatListHolds) as IModel;
                }

                List<IModel> allObjects = null;
                allObjects = dal.Get(iModelToFetch, selectAll: true);

                if (target is Building && iModelToFetch is Room)
                    fetchedIModelsFromDatabase = allObjects.ToDictionary(x => x, x => ((Room)x).BName != null ? ((Room)x).BName.Equals(((Building)target).Name) : false);
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
                else if (target is Room && iModelToFetch is Resource)
                {
                    // Since they're connected in an associationtable
                    var whereParams = new Dictionary<string, object>();
                    whereParams["roomID"] = ((Room)target).Id;
                    
                    var allObjectsCasted = allObjects.Cast<Resource>().ToDictionary(x => x.Id, x => x);
                    var objectsFromAssociationTable = dal.Get(new Room_Resource(), whereParams).Cast<Room_Resource>().ToDictionary(x => x.ResId, x => x);

                    Dictionary<IModel, bool> res = allObjectsCasted.ToDictionary(x => (IModel)x.Value, x => objectsFromAssociationTable.ContainsKey(x.Key));
                    fetchedIModelsFromDatabase = res;

                }
                else
                    throw new Exception("unhandled type");
            }

            return fetchedIModelsFromDatabase;
        }
        /// <summary>
        /// Gets all bookings for a person
        /// </summary>
        /// <param name="model">The person to check bookings for</param>
        /// <returns></returns>
        public List<Booking> GetBookingsForPerson(Person model)
        {
            DAL dal = new DAL(this);
            var whereParams = new Dictionary<string, object>();
            whereParams["personid"] = model.GetIdentifyingAttributes().First().Value;
            List<Booking> results = dal.Get(new Booking(), whereParams).Cast<Booking>().ToList();

            return results;
        }
        /// <summary>
        /// Called when the user checks or unchecks an item in a list of IModels. The values are then saved for when the user clicks Save to add or removes the connection between the IModel being edited and the referenced IModels in the CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleListOfIModelsBoxCheck(object sender, EventArgs e)
        {
            CheckedListBox checkBox = (CheckedListBox)sender;
            ItemCheckEventArgs check = (ItemCheckEventArgs)e;
            IModel selectedIModel = (IModel)checkBox.SelectedItem;
            Type modelType = selectedIModel.GetType();

            // If the lists arent initialized, initialize them
            if (this.changedStatusOnReferencingModels.ContainsKey(modelType) == false)
                this.changedStatusOnReferencingModels[modelType] = new Dictionary<IModel, bool>();
            Dictionary<IModel, bool> changedList = this.changedStatusOnReferencingModels[modelType];
            this.changedStatusOnReferencingModels[modelType][selectedIModel] = check.NewValue == CheckState.Checked;

        }
        /// <summary>
        /// Calls the Close function
        /// </summary>
        public void HandleCloseButtonClick()
        {
            this.Close();
        }
        /// <summary>
        /// Saves the values in the EditViews controls and returns them as a Dictionary with key = attributename, value = the value from the control
        /// </summary>
        /// <param name="controls">The list of controls in the EditView</param>
        /// <returns>Key = attributename, value = the value from the control</returns>
        private Dictionary<string, object> ViewControlsToDictionary(Control.ControlCollection controls)
        {
            Dictionary<string, object> controlValues = new Dictionary<string, object>();
            foreach (Control c in controls)
            {
                if (c is NumberTextBox)
                {
                    NumberTextBox numTextBox = (NumberTextBox)c;
                    if (numTextBox.Text.Length > 0)
                    {
                        try
                        {
                            controlValues[c.Name] = Int32.Parse(numTextBox.Text);
                        }
                        catch (Exception e)
                        {
                            if (e is OverflowException || e is FormatException)
                                EditView.SetResponseLabel("Ett nummer är för stort, försök igen");
                            return null;
                        }
                    }
                    else
                        controlValues[c.Name] = null;
                }
                else if (c is TextBox)
                {
                    TextBox txtBox = (TextBox)c;
                    controlValues[c.Name] = String.IsNullOrEmpty(txtBox.Text) ? null : txtBox.Text;
                }
                else if (c is DateTimePicker)
                {
                    controlValues[c.Name] = ((DateTimePicker)c).Value;
                }
                else if (c is ComboBox)
                {
                    IModel selectedIModel = (IModel)((ComboBox)c).SelectedItem;
                    if (selectedIModel != null)
                        controlValues[c.Name] = selectedIModel.GetIdentifyingAttributes().First().Value;
                    else
                        controlValues[c.Name] = null;
                }
                else if (c is CheckedListBox)
                {
                    // Skip, handled after the main-query is done
                }
            }
            return controlValues;
        }
        /// <summary>
        /// Called when the user clicks the "Delete" from a right click of a Booking item when editing a person
        /// </summary>
        /// <param name="selectedBookingInRightClickMenu">The Booking to be deleted</param>
        public void HandleRightDeleteContextMenu(Booking selectedBookingInRightClickMenu)
        {
            DAL dal = new DAL(this);
            int affectedRows = dal.Remove(selectedBookingInRightClickMenu);
            if (affectedRows > 0)
            {
                this.UpdateResponseLabel("Bokning borttagen");
                ObjectListView bookingView = this.EditView.GetBookingObjectListView();
                bookingView.SetObjects(this.GetBookingsForPerson((Person)this.EditView.Model));
            }
            else if (affectedRows != -1)
            {
                this.UpdateResponseLabel("Ingen bokning borttagen");
            }
        }
        /// <summary>
        /// Shows a new EditView when the user edits a person and right clicks a booking item and clicks Edit
        /// </summary>
        /// <param name="selectedBookingInRightClickMenu">The Booking item to be edited</param>
        public void ShowNewEditView(Booking selectedBookingInRightClickMenu)
        {
            EditView innerEditView = new EditView(selectedBookingInRightClickMenu, true);
            EditViewController innerController = new EditViewController(innerEditView, outerEditViewController: this);
            innerEditView.Show();
        }
        /// <summary>
        /// Called when the user edits a control that is marked as the identifying attribute holder for that IModel, and updates this list of identifying attributes with the new value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleIdentifyingAttributesValueChange(object sender, EventArgs e)
        {
            if (sender is TextBox)
                identifyingAttributesValues[((TextBox)sender).Name] = ((TextBox)sender).Text;
            else if (sender is NumberTextBox)
                identifyingAttributesValues[((NumberTextBox)sender).Name] = ((NumberTextBox)sender).Text;
            else if (sender is ComboBox)
            {
                ComboBox cb = (ComboBox)sender;
                IModel selVal = (IModel)cb.SelectedItem;
                var kv = selVal.GetIdentifyingAttributes();
                var kvfirstval = kv.First().Value;
                identifyingAttributesValues[((ComboBox)sender).Name] = ((IModel)((ComboBox)sender).SelectedItem).GetIdentifyingAttributes().First().Value;
            }
        }
        /// <summary>
        /// Checks if the identifying attributes are valid when clicking Save. Based on if the IModel is autoincrementing in the database and if the identifying attribute value is set in its holding control
        /// </summary>
        /// <returns></returns>
        private bool IdentifyingValuesAreNotEmpty()
        {
            if (Utils.IdIsAutoIncrementInDb(EditView.Model))
                return true;
            if (this.identifyingAttributesValues.Count == 0)
                return false;
            foreach (var idValue in identifyingAttributesValues)
                if (string.IsNullOrEmpty(idValue.Value.ToString()))
                    return false;
            return true;
        }
        /// <summary>
        /// Updates the list of bookings when editing a person
        /// </summary>
        public void UpdateBookingListInPersonEditingView()
        {
            ObjectListView bookingView = this.OuterEditViewController.EditView.GetBookingObjectListView();
            if (bookingView != null)
                if (this.OuterEditViewController != null)
                    bookingView.SetObjects(this.OuterEditViewController.GetBookingsForPerson((Person)this.OuterEditViewController.EditView.Model));
        }
        /// <summary>
        /// Updates the responselabel
        /// </summary>
        /// <param name="s"></param>
        public void NotifyExceptionToView(string message)
        {
            this.UpdateResponseLabel(message);
        }
        /// <summary>
        /// Called when the user is editing a Booking and changes the starting or ending hour for that booking. The other control is then incremented or decremented to one hour above or below the other.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleBookingDateTimePickerValueChanged(object sender, EventArgs e)
        {
            DateTimePicker datePicker = (DateTimePicker)sender;

            // If it's the start hour datepicker
            if (datePicker.Name.Equals(this.BookingStartDatePicker.Name))
            {
                this.BookingEndDatePicker.Value = datePicker.Value.AddHours(1);
            }
            // Else if it's the end hour datepicker
            else
            {
                this.BookingStartDatePicker.Value = datePicker.Value.AddHours(-1);
            }
        }
    }
}

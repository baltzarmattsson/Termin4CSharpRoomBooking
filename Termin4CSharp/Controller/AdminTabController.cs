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

namespace Termin4CSharp.Controller
{
    public class AdminTabController : IController
    {

        private GUIMain GUIMain;

        private ComboBox editTypeBox;
        private ComboBox editArticleBox;
        private Dictionary<string, IModel> toStringToIModel;
        private ComboBox createTypeBox;

        public AdminTabController(GUIMain guiMain)
        {
            this.GUIMain = guiMain;
            this.GUIMain.AdminController = this;
            this.editTypeBox = GUIMain.GetAdminEditTypeComboBox();
            this.editArticleBox = GUIMain.GetAdminEditArticleComboBox();
            this.createTypeBox = GUIMain.GetAdminCreateTypeComboBox();
            this.toStringToIModel = new Dictionary<string, IModel>();

            this.LoadComboBoxes();
        }
        /// <summary>
        /// Loads the edit and create comboboxes in the Admin tab
        /// </summary>
        private void LoadComboBoxes()
        {
            DAL dal = new DAL(this);

            // Editable and creatable types
            var types = new List<string>();
            types.Add("Bokning");
            types.Add("Byggnad");
            types.Add("Person");
            types.Add("Resurs");
            types.Add("Rum");
            types.Add("Inloggning");
            types.Add("Roll");
            types.Add("Rumtyp");
            this.SetEditTypes(types);
            this.SetCreateTypes(types);
        }
        /// <summary>
        /// Called when the user clicks the create new button and have a value selected in the "create new" combobox
        /// </summary>
        public void HandleCreateNewIModelClick()
        {
            if (this.createTypeBox.SelectedItem != null)
            {
                string selectedType = this.createTypeBox.SelectedItem.ToString();
                IModel correspondingIModel = this.ParseStringToIModel(selectedType);
                if (correspondingIModel != null)
                    this.ShowEditView(correspondingIModel, false);
            }
        }



        /// <summary>
        /// Show an EditView with the param IModel
        /// </summary>
        /// <param name="model">The model that sets the controls. Its attributes can be set or empty.</param>
        /// <param name="isExistingItemInDatabase">If the IModel is an existing item in the database, to know if the ID should be updated or inserted when Save is clicked.</param>
        private void ShowEditView(IModel model, bool isExistingItemInDatabase)
        {
            if (model != null)
            {
                EditView ev = new EditView(model, isExistingItemInDatabase);
                EditViewController editController = new EditViewController(ev, this);
                ev.Show();
            }
        }
        /// <summary>
        /// Called when the user clicks the edit button and have a value selected in the "edit" combobox
        /// </summary>
        public void HandleEditIModelClick()
        {
            if (this.editArticleBox.SelectedItem != null)
            {
                string selectedIModelToString = this.editArticleBox.SelectedItem.ToString();
                IModel selectedModel = this.toStringToIModel[selectedIModelToString];
                if (selectedModel != null)
                {
                    this.ShowEditView(selectedModel, true);
                }
            }
        }
        /// <summary>
        /// Fills the createcombo box with values that can be created
        /// </summary>
        /// <param name="creatableTypes"></param>
        private void SetCreateTypes(List<string> creatableTypes)
        {
            this.createTypeBox.Items.Clear();
            this.createTypeBox.Items.AddRange(creatableTypes.ToArray());
        }
        /// <summary>
        /// Fills the edit combobox with values that can be edited, based on what's in the database for each category/IModel
        /// </summary>
        /// <param name="editTypes"></param>
        private void SetEditTypes(List<string> editTypes)
        {
            this.editTypeBox.Items.Clear();
            this.editTypeBox.Items.AddRange(editTypes.ToArray());
        }
        /// <summary>
        /// Fills the edit combobox with values that can be edited, based on what category is chosen in the leftmost combobox
        /// </summary>
        /// <param name="editType">What type (IModel) that should be edited. The values in the rightmost combobox is fetched from the database</param>
        public void SetEditArticles(object editType)
        {
            DAL dal = new DAL(this);
            IModel correspondingIModel = this.ParseStringToIModel(editType as string);
            if (correspondingIModel != null)
            {
                List<IModel> allResultsInCorrespondingTable = dal.Get(correspondingIModel, selectAll: true);
                this.editArticleBox.Items.Clear();
                this.toStringToIModel.Clear();
                foreach (var article in allResultsInCorrespondingTable)
                {
                    this.editArticleBox.Items.Add(article.ToString());
                    this.toStringToIModel[article.ToString()] = article;
                }
                if (this.editArticleBox.Items.Count > 0)
                    this.editArticleBox.SelectedIndex = 0;
                else
                    this.editArticleBox.Text = null;
            }
        }
        /// <summary>
        /// Converting string to IModel
        /// </summary>
        /// <param name="modelString">String representation of the name of an IModel</param>
        /// <returns></returns>
        private IModel ParseStringToIModel(string modelString)
        {
            IModel correspondingIModel = null;
            switch (modelString)
            {
                case "Bokning":
                    correspondingIModel = new Booking();
                    break;
                case "Byggnad":
                    correspondingIModel = new Building();
                    break;
                case "Person":
                    correspondingIModel = new Person();
                    break;
                case "Resurs":
                    correspondingIModel = new Resource();
                    break;
                case "Rum":
                    correspondingIModel = new Room();
                    break;
                case "Inloggning":
                    correspondingIModel = new Login();
                    break;
                case "Roll":
                    correspondingIModel = new Role();
                    break;
                case "Rumtyp":
                    correspondingIModel = new RoomType();
                    break;
            }
            return correspondingIModel;
        }
        /// <summary>
        /// Called when a created EditView is closed. Updates the rightmost edit combobox with updated values.
        /// </summary>
        public void HandleEditViewClosed()
        {
            //Updating the articlebox
            if (this.editTypeBox.SelectedItem != null)
            {
                string selectedEditType = this.editTypeBox.SelectedItem.ToString();
                this.SetEditArticles(selectedEditType);
            }
        }
        /// <summary>
        /// Updates the responselabel with a message
        /// </summary>
        /// <param name="message">The message in text to be displayed</param>
        public void NotifyExceptionToView(string message)
        {
            this.GUIMain.SetPKResponseLabelText(message);
        }
    }

}

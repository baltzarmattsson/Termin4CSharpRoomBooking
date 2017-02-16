using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Termin4CSharp.DataAccessLayer;
using Termin4CSharp.Model;
using Termin4CSharp.Model.DbHelpers;
using Termin4CSharp.View;
using Termin4CSharp.View.CustomControls;

namespace Termin4CSharp.Controller {
    public class AdminTabController {

        private GUIMain GUIMain;

        private ComboBox editTypeBox;
        private ComboBox editArticleBox;
        private Dictionary<string, IModel> toStringToIModel;
        private ComboBox createTypeBox;

        public AdminTabController(GUIMain guiMain) {
            this.GUIMain = guiMain;
            this.GUIMain.AdminController = this;
            this.editTypeBox = GUIMain.GetAdminEditTypeComboBox();
            this.editArticleBox = GUIMain.GetAdminEditArticleComboBox();
            this.createTypeBox = GUIMain.GetAdminCreateTypeComboBox();
            this.toStringToIModel = new Dictionary<string, IModel>();
              
            this.LoadComboBoxes();  
        }

        private void LoadComboBoxes() {
            DAL dal = new DAL();

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

        public void HandleCreateNewIModelClick() {
            if (this.createTypeBox.SelectedItem != null) {
                string selectedType = this.createTypeBox.SelectedItem.ToString();
                IModel correspondingIModel = this.ParseStringToIModel(selectedType);
                if (correspondingIModel != null)
                    this.ShowEditView(correspondingIModel, false);
            }
        }

        private void ShowEditView(IModel model, bool isExistingItemInDatabase) {
            if (model != null) {
                EditView ev = new EditView(model, isExistingItemInDatabase);
                EditViewController editController = new EditViewController(ev, this);
                ev.Show();
            }
        }

        public void HandleEditIModelClick() {
            if (this.editArticleBox.SelectedItem != null) {
                string selectedIModelToString = this.editArticleBox.SelectedItem.ToString();
                IModel selectedModel = this.toStringToIModel[selectedIModelToString];
                if (selectedModel != null) {
                    this.ShowEditView(selectedModel, true);
                }
            }
        }

        private void SetCreateTypes(List<string> creatableTypes) {
            this.createTypeBox.Items.Clear();
            this.createTypeBox.Items.AddRange(creatableTypes.ToArray());
        }

        private void SetEditTypes(List<string> editTypes) {
            this.editTypeBox.Items.Clear();
            this.editTypeBox.Items.AddRange(editTypes.ToArray());
        }
        ////private void SetEditArticles(List<IModel> editArticles) {
        //    this.editArticleBox.Items.Clear();
        //    this.toStringToIModel.Clear();
        //    foreach (var article in editArticles) {
        //        this.editArticleBox.Items.Add(article.ToString());
        //        this.toStringToIModel[article.ToString()] = article;
        //    }
        //    if (this.editArticleBox.Items.Count > 0)
        //        this.editArticleBox.SelectedIndex = 0;
        //    else
        //        this.editArticleBox.Text = null;
        //}
        public void SetEditArticles(object editType) {
            DAL dal = new DAL();
            IModel correspondingIModel = this.ParseStringToIModel(editType as string);
            if (correspondingIModel != null) {
                List<IModel> allResultsInCorrespondingTable = dal.Get(correspondingIModel, selectAll: true);
                //this.SetEditArticles(allResultsInCorrespondingTable);
                this.editArticleBox.Items.Clear();
                this.toStringToIModel.Clear();
                foreach (var article in allResultsInCorrespondingTable) {
                    this.editArticleBox.Items.Add(article.ToString());
                    this.toStringToIModel[article.ToString()] = article;
                }
                if (this.editArticleBox.Items.Count > 0)
                    this.editArticleBox.SelectedIndex = 0;
                else
                    this.editArticleBox.Text = null;
            }
        }

        private IModel ParseStringToIModel(string modelString) {
            IModel correspondingIModel = null;
            switch (modelString) {
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
        public void HandleEditViewClosed() {
            //Updating the articlebox
            if (this.editTypeBox.SelectedItem != null) {
                string selectedEditType = this.editTypeBox.SelectedItem.ToString();
                this.SetEditArticles(selectedEditType);
            }
        }
    }

}

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
        private Dictionary<string, IModel> toStringAsIModel;
        private ComboBox createTypeBox;

        public AdminTabController(GUIMain guiMain) {
            this.GUIMain = guiMain;
            this.GUIMain.AdminController = this;
            this.editTypeBox = GUIMain.GetAdminEditTypeComboBox();
            this.editArticleBox = GUIMain.GetAdminEditArticleComboBox();
            this.createTypeBox = GUIMain.GetAdminCreateTypeComboBox();

            ////test
            //List<string> asd = new List<string>();
            //asd.Add("test1");
            //asd.Add("test2");
            //asd.Add("test3");
            //this.SetEditTypes(asd);   
            this.LoadComboBoxes();  
        }

        private void LoadComboBoxes() {
            DAL dal = new DAL();

            // Editable types
            var editableAndCreatableTypes = new List<string>();
            editableAndCreatableTypes.Add("Bokning");
            editableAndCreatableTypes.Add("Byggnad");
            editableAndCreatableTypes.Add("Person");
            editableAndCreatableTypes.Add("Resurs");
            editableAndCreatableTypes.Add("Rum");
            editableAndCreatableTypes.Add("Inloggning");
            editableAndCreatableTypes.Add("Roll");
            editableAndCreatableTypes.Add("Rumtyp");
            this.SetEditTypes(editableAndCreatableTypes);
            this.SetCreateTypes(editableAndCreatableTypes);
            //
        }

        public void HandleCreateNewIModelClick() {
            string selectedType = this.createTypeBox.SelectedItem.ToString();
            IModel correspondingIModel = this.ParseStringToIModel(selectedType);

            if (correspondingIModel != null) {
                EditView ev = new EditView(correspondingIModel, isExistingItemInDatabase: false);
                EditViewController editController = new EditViewController(ev);
                ev.Show();
            }
        }
        public void HandleEditIModelClick() {
            string selectedIModel = null;
            if (this.editArticleBox.SelectedItem != null) 
                selectedIModel = this.editArticleBox.SelectedItem.ToString();
        }

        private void SetCreateTypes(List<string> creatableTypes) {
            this.createTypeBox.Items.Clear();
            this.createTypeBox.Items.AddRange(creatableTypes.ToArray());
        }

        private void SetEditTypes(List<string> editTypes) {
            this.editTypeBox.Items.Clear();
            this.editTypeBox.Items.AddRange(editTypes.ToArray());
        }
        private void SetEditArticles(List<IModel> editArticles) {
            this.editArticleBox.Items.Clear();
            //this.editArticleBox.Items.AddRange(editArticles.ToArray());
            //int indexCounter = 0;
            //ComboBoxItem item = null;
            foreach (var article in editArticles) {
                this.editArticleBox.Items.Add(article);
            }
            if (this.editArticleBox.Items.Count > 0)
                this.editArticleBox.SelectedIndex = 0;
            else
                this.editArticleBox.Text = null;
        }
        public void SetEditArticles(object editType) {
            DAL dal = new DAL();
            IModel correspondingIModel = this.ParseStringToIModel(editType as string);
            if (correspondingIModel != null) {
                List<IModel> allResultsInCorrespondingTable = dal.Get(correspondingIModel, selectAll: true);
                this.SetEditArticles(allResultsInCorrespondingTable);
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
    }
}

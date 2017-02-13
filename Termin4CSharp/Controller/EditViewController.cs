using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin4CSharp.DataAccessLayer;
using Termin4CSharp.Model;
using Termin4CSharp.View;

namespace Termin4CSharp.Controller {
    public class EditViewController : IController {

        
        public EditView EditView { get; set; }
        private bool hasUnsavedChanges;

        public EditViewController(EditView editView, IModel model) {
            this.EditView = editView;
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

        public void HasUnsavedChanges(bool value) {
            this.hasUnsavedChanges = value;
        }

        public void NotifyExceptionToView() {
            
        }
    }
}

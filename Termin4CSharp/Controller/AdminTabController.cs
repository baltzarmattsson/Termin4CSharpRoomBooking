using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Termin4CSharp.View;

namespace Termin4CSharp.Controller {
    class AdminTabController {

        private GUIMain GUIMain;

        private ComboBox editTypeBox;
        private ComboBox editArticleBox;
        private ComboBox createTypeBox;

        public AdminTabController(GUIMain guiMain) {
            this.GUIMain = guiMain;
            this.editTypeBox = GUIMain.GetAdminEditTypeComboBox();
            this.editArticleBox = GUIMain.GetAdminEditArticleComboBox();
            this.createTypeBox = GUIMain.GetAdminCreateTypeComboBox();

            //test
            List<string> asd = new List<string>();
            asd.Add("test1");
            asd.Add("test2");
            asd.Add("test3");
            this.SetEditTypes(asd);     
        }

        public void SetEditTypes(List<string> editTypes) {
            this.editTypeBox.Items.Clear();
            this.editTypeBox.Items.AddRange(editTypes.ToArray());
        }
    }
}

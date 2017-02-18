using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model {
    class Institution_Building : IModel {

        public string iName { get; set; }
        public string bName { get; set; }
        public Institution_Building() { }
        public Institution_Building(string iName, string bName) {
            this.iName = iName;
            this.bName = bName;
        }


        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["iName"] = this.iName;
            dict["bName"] = this.bName;
            return dict;
        }
        public Dictionary<string, object> GetReferencedModels() {
            var dict = new Dictionary<string, object>();
            return dict;
        }
    }
}

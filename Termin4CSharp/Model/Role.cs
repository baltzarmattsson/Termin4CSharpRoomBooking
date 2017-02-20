using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model {
    class Role : IModel {

        public string Name { get; set; }
        public Role() { }
        public Role(string roleName) {
            this.Name = roleName;
        }
        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["Name"] = this.Name;
            return dict;
        }

        public Dictionary<string, object> GetReferencedModels() {
            var dict = new Dictionary<string, object>();
            return dict;
        }

        public override string ToString() {
            return this.Name;
        }

    }
}
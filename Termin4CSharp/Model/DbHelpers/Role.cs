using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model.DbHelpers {
    class Role : IModel {

        public int Id { get; set; }
        public Role() { }
        public Role(int id) {
            this.Id = id;
        }
        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["Id"] = this.Id;
            return dict;
        }
    }
}

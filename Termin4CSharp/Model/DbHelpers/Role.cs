using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model.DbHelpers {
    class Role : IModel {

        //public int Id { get; set; }
        public string RoleName { get; set; }
        public Role() { }
        //public Role(int id) {
        //    this.Id = id;
        //}
        public Role(string roleName) {
            this.RoleName = roleName;
        }
        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["RoleName"] = this.RoleName;
            return dict;
        }
    }
}

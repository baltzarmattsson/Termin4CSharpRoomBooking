using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model.DbHelpers {
    class Login : IModel {
        public string PersonId { get; set; }
        public string Password { get; set; }

        public Login(string personId, string password) {
            this.PersonId = personId;
            this.Password = password;
        }
        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["PersonId"] = this.PersonId;
            return dict;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model {
    class Login : IModel {
        public string PersonId { get; set; }
        public string Password { get; set; }
        public Person Person { get; set; }
        public Login() { }
        public Login(string personId, string password) {
            this.PersonId = personId;
            this.Password = password;
        }
        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["PersonId"] = this.PersonId;
            return dict;
        }

        public Dictionary<string, object> GetReferencedModels() {
            var dict = new Dictionary<string, object>();
            dict["Person"] = new Person();
            return dict;
        }

        public override string ToString() {
            return string.Format("{0} {1}", this.PersonId, string.Join("", this.Password.Select(x => "*")));
        }

        public override bool Equals(object obj) {
            Login other = obj as Login;
            return this.PersonId.Equals(other.PersonId) && this.Password.Equals(other.Password);
        }
    }
}

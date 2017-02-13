using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
<<<<<<< HEAD
    class Person
=======
    class Person : IModel
>>>>>>> 9d21af75eaedf8c5433772e40dbdd0be5052d37f
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNbr { get; set; }
        
>>>>>>> 9d21af75eaedf8c5433772e40dbdd0be5052d37f

        public Person() { }
        public Person(string name, string id, string email, string phoneNbr)
        {
            this.Name = name;
            this.Id = id;
            this.Email = email;
            this.PhoneNbr = phoneNbr;
        }

        public override string ToString() {
            return string.Format("{0} {1} {2} {3}", Name, Id, Email, PhoneNbr);
        }

        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["Id"] = this.Id;
            return dict;
        }

        public override bool Equals(object obj) {
            var other = obj as Person;
            if (other == null)
                return false;
            return this.Name.Equals(other.Name) && this.Id.Equals(other.Id) && this.Email.Equals(other.Email) && this.PhoneNbr.Equals(other.PhoneNbr);
        }
    }
}
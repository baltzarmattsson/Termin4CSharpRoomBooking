using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
    public class Person : IModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNbr { get; set; }
        public string RoleName { get; set; }
        public Role Role { get; set; }

        public Person() { }
        public Person(string name, string id, string email, string phoneNbr, string roleName)
        {
            this.Name = name;
            this.Id = id;
            this.Email = email;
            this.PhoneNbr = phoneNbr;
            this.RoleName = roleName;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Name, Id, Email, PhoneNbr, RoleName);
        }

        public Dictionary<string, object> GetIdentifyingAttributes()
        {
            var dict = new Dictionary<string, object>();
            dict["Id"] = this.Id;
            return dict;
        }
        public Dictionary<string, object> GetReferencedModels()
        {
            var dict = new Dictionary<string, object>();
            dict["Role"] = new Role();
            return dict;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Person;
            if (other == null)
                return false;
            return/* this.Name.Equals(other.Name) && */this.Id.Equals(other.Id); /*&& this.Email.Equals(other.Email) && this.PhoneNbr.Equals(other.PhoneNbr); */
        }
    }
}
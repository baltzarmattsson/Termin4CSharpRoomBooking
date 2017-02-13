using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
<<<<<<< HEAD
    class Institution
=======
    class Institution : IModel
>>>>>>> 9d21af75eaedf8c5433772e40dbdd0be5052d37f
    {
        public string Name { get; set; }

        public Institution() { }
        public Institution(string name)
        {
            this.Name = name;
        }

        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["Name"] = this.Name;
            return dict;
        }

        public override string ToString() {
            return string.Format("{0}", Name);
        }

        public override bool Equals(object obj) {
            var other = obj as Person;
            if (other == null)
                return false;
            return this.Name.Equals(other.Name);
        }
    }
}

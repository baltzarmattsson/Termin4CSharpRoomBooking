using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
    class Institution : IModel
    {
        public string Name { get; set; }

        public Institution() { }
        public Institution(string name)
        {
            this.Name = name;
        }

        public Dictionary<string, object> GetIdentifyingAttributes()
        {
            var dict = new Dictionary<string, object>();
            dict["Name"] = this.Name;
            return dict;
        }
        public Dictionary<string, object> GetReferencedModels()
        {
            var dict = new Dictionary<string, object>();
            return dict;
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Person;
            if (other == null)
                return false;
            return this.Name.Equals(other.Name);
        }
    }
}

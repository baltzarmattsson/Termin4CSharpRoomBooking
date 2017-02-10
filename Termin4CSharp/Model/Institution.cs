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

        public Institution(string name)
        {
            this.Name = name;
        }

        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["Name"] = this.Name;
            return dict;
        }
    }
}

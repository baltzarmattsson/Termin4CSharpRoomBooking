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

        public string GetIdentifyingAttribute() {
            return Name;
        }
    }
}

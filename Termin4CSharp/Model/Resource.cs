using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
    class Resource : IModel
    {
        public string Type { get; set; }

        public Resource(string Type)
        {
            this.Type = Type;
        }
    }
}
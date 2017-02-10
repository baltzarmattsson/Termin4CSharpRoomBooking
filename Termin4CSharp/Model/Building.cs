using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
    class Building : IModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Avail_start { get; set; }
        public DateTime Avail_end { get; set; }

        public Building(string name, string address, DateTime avail_start, DateTime avail_end)
        {
            this.Name = name;
            this.Address = address;
            this.Avail_start = avail_start;
            this.Avail_end = avail_end;
        }

        public override string ToString() {
            return string.Format("{0} {1} {2} {3}", Name, Address, Avail_start, Avail_end);
        }

        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["Name"] = this.Name;
            return dict;
        }
    }
}



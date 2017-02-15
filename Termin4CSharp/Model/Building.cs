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
        public List<IModel> Room { get; set; }

        public Building() { }
        public Building(string name, string address, DateTime avail_start, DateTime avail_end, List<IModel> rooms)
        {
            this.Name = name;
            this.Address = address;
            this.Avail_start = avail_start;
            this.Avail_end = avail_end;
            this.Room = rooms;
        }

        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["Name"] = this.Name;
            return dict;
        }
        public override string ToString() {
            return string.Format("{0} {1} {2} {3}", Name, Address, Avail_start, Avail_end);
        }
        public override bool Equals(object obj) {
            var other = obj as Building;
            if (other == null)
                return false;
            return this.Name.Equals(other.Name) && this.Address.Equals(other.Address) && Utils.DateCompare(this.Avail_start, other.Avail_start) && Utils.DateCompare(this.Avail_end, other.Avail_end) && this.Room == other.Room;
        }
    }
}



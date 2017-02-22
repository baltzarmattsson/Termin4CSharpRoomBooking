using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
    public class Room : IModel {
        public string BName { get; set; }
        public string Id { get; set; }
        public int Capacity { get; set; }
        public string Floor { get; set; }
        public string RType { get; set; }
        public Building Building { get; set; }
        public RoomType RoomType { get; set; }
        public List<Resource> Resources { get; set; }
        public bool[] Bookable { get; set; }
        public Room() { }

        public Room(string building, string id, int capacity, string floor, string rType) {
            this.BName = building;
            this.Id = id;
            this.Capacity = capacity;
            this.Floor = floor;
            this.RType = rType;
        }

        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["Id"] = this.Id;
            return dict;
        }
        public Dictionary<string, object> GetReferencedModels() {
            var dict = new Dictionary<string, object>();
            dict["Building"] = new Building();
            dict["RoomType"] = new RoomType();
            dict["Resources"] = new List<Resource>();
            return dict;
        }

        public override string ToString() {
            return string.Format("{0} {1} {2} {3}", BName, Id, Capacity, Floor);
        }
        public override bool Equals(object obj) {
            var other = obj as Room;
            if (other == null)
                return false;
            return /*this.BName.Equals(other.BName) && */ this.Id.Equals(other.Id) && this.Capacity == other.Capacity;
            ////*** && this.Floor.Equals(other.Floor) && this.RType.Equals(other.RType); && this.Building == other.Building;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
    class Room : IModel
    {
        public string BName { get; set; }
        public string Id { get; set; }
        public int Capacity { get; set; }
        public string Floor { get; set; }
        public int? RoomType { get; set; }

        public Room() { }

        public Room(Building building, string id, int capacity, string floor, int? roomType)
        {
            this.BName = building.Name;
            this.Id = id;
            this.Capacity = capacity;
            this.Floor = floor;
            this.RoomType = roomType;
        }

        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["Id"] = this.Id;
            return dict;
        }

        public override string ToString() {
            return string.Format("{0} {1} {2} {3}", BName, Id, Capacity, Floor);
        }
        public override bool Equals(object obj) {
            var other = obj as Room;
            if (other == null)
                return false;
            return this.BName.Equals(other.BName) && this.Id.Equals(other.Id) && this.Capacity == other.Capacity && this.Floor.Equals(other.Floor);
        }
    }
}

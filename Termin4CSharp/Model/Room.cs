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
        public int Floor { get; set; }
        List<int> RoomTypes = new List<int>();

        public Room() { }

        public Room(Building building, string id, int capacity, int floor)
        {
            this.BName = building.Name;
            this.Id = id;
            this.Capacity = capacity;
            this.Floor = floor;
        }

        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["Id"] = this.Id;
            return dict;
        }
    }
}

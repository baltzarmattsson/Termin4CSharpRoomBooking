using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
    class Room
    {
        public string Id { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }

        public Room(string Id, int Capacity, int Floor)
        {
            this.Id = Id;
            this.Capacity = Capacity;
            this.Floor = Floor;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
<<<<<<< HEAD
    class Room
=======
    class Room : IModel
>>>>>>> 9d21af75eaedf8c5433772e40dbdd0be5052d37f
    {
        public string Id { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }
<<<<<<< HEAD
=======
        List<int> RoomTypes = new List<int>();
>>>>>>> 9d21af75eaedf8c5433772e40dbdd0be5052d37f

        public Room(string Id, int Capacity, int Floor)
        {
            this.Id = Id;
            this.Capacity = Capacity;
            this.Floor = Floor;
        }
    }
}

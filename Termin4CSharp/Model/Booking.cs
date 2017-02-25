using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
    public class Booking : IModel
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string RoomId { get; set; }
        public string PersonId { get; set; }
        public String Purpose { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
        public Room Room { get; set; }
        public Person Person { get; set; }

        public Booking() { }
        public Booking(int id, DateTime timestamp, Room room, Person person, string purpose, DateTime start_time, DateTime end_time)
        {
            this.Id = id;
            this.Timestamp = timestamp;
            this.RoomId = room.Id;
            this.PersonId = person.Id;
            this.Purpose = purpose;
            this.Start_time = start_time;
            this.End_time = end_time;
        }

        public Dictionary<string, object> GetIdentifyingAttributes()
        {
            var dict = new Dictionary<string, object>();
            dict["Id"] = this.Id;
            return dict;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6}", Id, Timestamp, RoomId, PersonId, Purpose, Start_time, End_time);
        }
        public override bool Equals(object obj)
        {
            var other = obj as Booking;
            if (other == null)
                return false;
            return this.Id == other.Id;
        }

        public Dictionary<string, object> GetReferencedModels()
        {
            var dict = new Dictionary<string, object>();
            dict["Room"] = new Room();
            dict["Person"] = new Person();
            return dict;
        }
    }
}
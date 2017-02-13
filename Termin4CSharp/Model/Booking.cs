using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
<<<<<<< HEAD
    class Booking
=======
    class Booking : IModel
>>>>>>> 9d21af75eaedf8c5433772e40dbdd0be5052d37f
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string RoomId { get; set; }
        public string PersonId { get; set; }
        public String Purpose { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }

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

        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["Id"] = this.Id;
            return dict;
        }

        public override string ToString() {
            return string.Format("{0} {1} {2} {3} {4} {5} {6}", Id, Timestamp, RoomId, PersonId, Purpose, Start_time, End_time);
        }
        public override bool Equals(object obj) {
            var other = obj as Booking;
            if (other == null)
                return false;
            return this.Id == other.Id && this.Timestamp.Equals(other.Timestamp) && this.RoomId.Equals(other.RoomId) &&
                this.PersonId.Equals(other.PersonId) && this.Purpose.Equals(other.Purpose) && Utils.DateCompare(this.Start_time, other.Start_time) && Utils.DateCompare(this.End_time, other.End_time);
        }
    }
}
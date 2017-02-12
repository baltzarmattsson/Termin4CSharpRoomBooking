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
        public Person Responsible { get; set; }
        public String Purpose { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }

        public Booking(int Id, DateTime Timestamp, Person Responsible, String Purpose, DateTime Start_time, DateTime End_Time)
        {
            this.Id = Id;
            this.Timestamp = Timestamp;
            this.Responsible = Responsible;
            this.Purpose = Purpose;
            this.Start_time = Start_time;
            this.End_time = End_time;
        }
    }
}
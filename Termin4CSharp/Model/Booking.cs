using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
    class Booking : IModel
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public String Purpose { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }

        public Booking(int id, DateTime timestamp, String purpose, DateTime start_time, DateTime end_time)
        {
            this.Id = id;
            this.Timestamp = timestamp;
            this.Purpose = purpose;
            this.Start_time = start_time;
            this.End_time = end_time;
        }
    }
}
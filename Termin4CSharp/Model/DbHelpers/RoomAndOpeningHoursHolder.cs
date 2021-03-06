﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model.DbHelpers
{
    /// <summary>
    /// A holder object for a room and its buildings opening and closing hour
    /// </summary>
    class RoomAndOpeningHoursHolder
    {

        public Room Room { get; set; }
        public DateTime OpeningHour { get; set; }
        public DateTime ClosingHour { get; set; }

        public RoomAndOpeningHoursHolder(Room room, DateTime openingHour, DateTime closingHour)
        {
            this.Room = room;
            this.OpeningHour = openingHour;
            this.ClosingHour = closingHour;
        }
    }
}

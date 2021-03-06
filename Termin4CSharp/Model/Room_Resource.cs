﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
    class Room_Resource : IModel
    {

        public string RoomId { get; set; }
        public int ResId { get; set; }
        public Room Room { get; set; }
        public Room_Resource() { }
        public Room_Resource(string roomId, int resId)
        {
            this.RoomId = roomId;
            this.ResId = resId;
        }
        public Dictionary<string, object> GetIdentifyingAttributes()
        {
            var dict = new Dictionary<string, object>();
            dict["RoomId"] = this.RoomId;
            dict["ResId"] = this.ResId;
            return dict;
        }
        public Dictionary<string, object> GetReferencedModels()
        {
            var dict = new Dictionary<string, object>();
            dict["Room"] = new Room();
            return dict;
        }
    }
}

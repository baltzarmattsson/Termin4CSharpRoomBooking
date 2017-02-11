using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model.DbHelpers {
    class Room_Resource : IModel {

        public string RoomId { get; set; }
        public string ResId { get; set; }
        public Room_Resource(string roomId, string resId) {
            this.RoomId = roomId;
            this.ResId = resId;
        }
        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["RoomId"] = this.RoomId;
            dict["ResId"] = this.ResId;
            return dict;
        }
    }
}

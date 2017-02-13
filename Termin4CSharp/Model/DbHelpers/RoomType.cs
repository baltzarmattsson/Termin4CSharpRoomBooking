using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model.DbHelpers {
    class RoomType : IModel {

        public int Id { get; set; }
        public string Type { get; set; }

        public RoomType() { }

        public RoomType(int id, string type) {
            this.Id = id;
            this.Type = type;
        }
        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["Id"] = this.Id;
            return dict;
        }
    }
}

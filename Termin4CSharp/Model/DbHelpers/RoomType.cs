using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model.DbHelpers {
    public class RoomType : IModel {
        
        public string Type { get; set; }

        public RoomType() { }
        public RoomType(string type) {
            this.Type = type;
        }
        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["Type"] = this.Type;
            return dict;
        }
        public Dictionary<string, object> GetReferencedModels() {
            var dict = new Dictionary<string, object>();
            return dict;
        }

        public override string ToString() {
            return this.Type;
        }

        public override bool Equals(object obj) {
            RoomType other = obj as RoomType;
            return this.Type.Equals(other.Type);
        }
    }
}

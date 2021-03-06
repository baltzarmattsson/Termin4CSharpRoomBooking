﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
    public class Resource : IModel
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public Resource() { }
        public Resource(string type)
        {
            this.Type = type;
        }

        public Dictionary<string, object> GetIdentifyingAttributes()
        {
            var dict = new Dictionary<string, object>();
            dict["Id"] = this.Id;
            return dict;
        }
        public Dictionary<string, object> GetReferencedModels()
        {
            var dict = new Dictionary<string, object>();
            return dict;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Id, Type);
        }
        public override bool Equals(object obj)
        {
            var other = obj as Resource;
            if (other == null)
                return false;
            return this.Id.Equals(other.Id) && this.Type.Equals(other.Type);
        }
    }
}
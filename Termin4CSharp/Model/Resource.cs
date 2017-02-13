﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
<<<<<<< HEAD
    class Resource
=======
    class Resource : IModel
>>>>>>> 9d21af75eaedf8c5433772e40dbdd0be5052d37f
    {
        public string Type { get; set; }

        public Resource() { }
        public Resource(string type)
        {
            this.Type = type;
        }

        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["Type"] = this.Type;
            return dict;
        }

        public override string ToString() {
            return string.Format("{0}", Type);
        }
        public override bool Equals(object obj) {
            var other = obj as Resource;
            if (other == null)
                return false;
            return this.Type.Equals(other.Type);
        }
    }
}
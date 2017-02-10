﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
    class Person : IModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNbr { get; set; }
        List<int> roles = new List<int>(); 

        public Person(string name, string id, string email, string phoneNbr)
        {
            this.Name = name;
            this.Id = id;
            this.Email = email;
            this.PhoneNbr = phoneNbr;
        }

        public override string ToString() {
            return string.Format("{0} {1} {2} {3}", Name, Id, Email, PhoneNbr);
        }

        public Dictionary<string, object> GetIdentifyingAttributes() {
            var dict = new Dictionary<string, object>();
            dict["Id"] = this.Id;
            return dict;
        }
    }
}
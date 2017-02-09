using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
    class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone_nbr { get; set; }
        List<int> roles = new List<int>(); 

        public Person(string Name, int Id, string Email, string Phone_nbr)
        {
            this.Name = Name;
            this.Id = Id;
            this.Email = Email;
            this.Phone_nbr = Phone_nbr;
        }
    }
}
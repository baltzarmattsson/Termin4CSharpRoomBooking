using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
<<<<<<< HEAD
    class Person
=======
    class Person : IModel
>>>>>>> 9d21af75eaedf8c5433772e40dbdd0be5052d37f
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone_nbr { get; set; }
<<<<<<< HEAD
        //List <int> roles 
=======
        List<int> roles = new List<int>(); 
>>>>>>> 9d21af75eaedf8c5433772e40dbdd0be5052d37f

        public Person(string Name, int Id, string Email, string Phone_nbr)
        {
            this.Name = Name;
            this.Id = Id;
            this.Email = Email;
            this.Phone_nbr = Phone_nbr;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
    class Building : IModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Av_start { get; set; }
        public DateTime Av_end { get; set; }

        public Building(string Name, string Address, DateTime Av_start, DateTime Av_end) // rätt med void?
        {
            this.Name = Name;
            this.Address = Address;
            this.Av_start = Av_start;
            this.Av_end = this.Av_end;
        }
    }
}



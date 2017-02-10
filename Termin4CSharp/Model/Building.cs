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
        public DateTime Avail_start { get; set; }
        public DateTime Avail_end { get; set; }

        public Building(string name, string address, DateTime av_start, DateTime av_end)
        {
            this.Name = name;
            this.Address = address;
            this.Avail_start = av_start;
            this.Avail_end = av_end;
        }

        public override string ToString() {
            return string.Format("{0} {1} {2} {3}", Name, Address, Avail_start, Avail_end);
        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkConfigurator.Model
{
    public class Switch 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Adapter> networkAdapters { get; set; }
        public int ports { get; set; }
        public ICollection<Host> connectedHosts { get; set; }
    }
}

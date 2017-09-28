using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkConfigurator.Model
{
    public class Adapter
    {
        public int ID { get; set; }

        public string IPAddress { get; set; }

        public Adapter(string IP)
        {
            this.IPAddress = IP;
        }
    }
}

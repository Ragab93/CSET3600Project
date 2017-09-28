using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NetworkConfigurator.Model
{
    public class Host 
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public ICollection<Adapter> NetworkAdapters { get; set; }
        public int? SwitchID { get; set; }
        public int NetworkID { get; set; }
        public virtual Switch Switch { get; set; }
        public virtual Network Network { get; set; }
       
    }
}

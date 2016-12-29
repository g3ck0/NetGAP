using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetGAP.Models
{
    public partial class Stores
    {
        public Stores()
        {
            Articles = new HashSet<Articles>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Articles> Articles { get; set; }
    }
}

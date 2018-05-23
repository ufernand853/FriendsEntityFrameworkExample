using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Agenda
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //VIRTUAL in this case means that the navigable poperty can be Lazy Loaded  
        public virtual User Owner { get; set; }
        public virtual ICollection<User> Contacts { get; set; }
    }
}

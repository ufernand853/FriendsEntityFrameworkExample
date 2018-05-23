using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Agenda
    {
        public Guid Id;
        public string Name { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<User> Contacts { get; set; }
    }
}

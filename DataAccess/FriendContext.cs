using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FriendContext : DbContext
    {
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<User> Users { get; set; }

        public FriendContext() : base("name=FriendContext")
        {

        }
    }
}

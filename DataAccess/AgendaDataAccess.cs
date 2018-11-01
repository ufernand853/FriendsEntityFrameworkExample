using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccess
{
    public class AgendaDataAccess : IDataAccess<Agenda>
    {
        public void Add(Agenda entity)
        {
            using (FriendContext context = new FriendContext())
            {
                context.Agendas.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Agenda entity)
        {
            using (FriendContext context = new FriendContext())
            {
                context.Agendas.Remove(entity);
            }
        }

        public Agenda Get(Guid id)
        {
            using (FriendContext context = new FriendContext())
            {
                Agenda agenda = context.Agendas.FirstOrDefault(a => a.Id == id);
                context.Entry(agenda).Collection(a => a.Contacts).Load(); 
                return agenda;
            }
        }

        public IEnumerable<Agenda> GetAll()
        {
            using (FriendContext context = new FriendContext())
            {
                return context.Agendas;
            }
        }

        public void Modify(Agenda entity)
        {
            using (FriendContext context = new FriendContext())
            {
                context.Entry(entity).State = EntityState.Modified;
               

                foreach (var contact in entity.Contacts)
                {
                    context.Entry(contact).State = contact.Id.Equals(Guid.Empty) ? EntityState.Added : EntityState.Unchanged;
                }

                context.SaveChanges();
            }
        }
        public void Empty()
        {

            using (FriendContext context = new FriendContext())
            {
                List<Agenda> agendas = context.Agendas.ToList();
                foreach (Agenda actual in agendas)
                {
                    Agenda toDelete = context.Agendas.Find(actual.Id);
                    context.Agendas.Remove(toDelete);
                }
                context.SaveChanges();
            }

        }
    }

}

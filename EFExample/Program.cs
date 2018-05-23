using DataAccess;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Agenda a = new Agenda()
            {
                Name = "Agenda 1",
                Id = Guid.NewGuid(),
                Contacts = new List<User>()
            };

            User owner = new User()
            {
                Id = Guid.NewGuid(),
                Age = 24,
                Name = "Ramiro"
            };

            User contact1 = new User()
            {
                Id = Guid.NewGuid(),
                Age = 22,
                Name = "Lady"
            };

            User contact2 = new User()
            {
                Id = Guid.NewGuid(),
                Age = 21,
                Name = "Sir"
            };

            a.Contacts.Add(contact1);
            a.Contacts.Add(contact2);
            a.Owner = owner;

            IRepository<Agenda> repo = new AgendaRepository();
            repo.Add(a);

            Console.WriteLine("Agenda Agregada");
            Console.ReadKey();
            Console.WriteLine("Se va a obtener la agenda");
            Console.ReadKey();
            Agenda aCopy = repo.Get(a.Id);

            Console.WriteLine(aCopy.Id);
            Console.WriteLine(aCopy.Name);
            Console.WriteLine(aCopy.Owner);

            foreach (var u in aCopy.Contacts)
            {
                Console.WriteLine(u.Name);
            }
        }
    }
}

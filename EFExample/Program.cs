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


            Console.WriteLine("Se va a agegar la agenda");
            Console.ReadKey();

            IRepository<Agenda> repo = new AgendaRepository();
            repo.Add(a);

            Console.WriteLine("Agenda Agregada");
            Console.ReadKey();
            Console.WriteLine("Se va a obtener la agenda\n\n");
            Console.ReadKey();
            Agenda aCopy = repo.Get(a.Id);

            Console.WriteLine(aCopy.Id);
            Console.WriteLine(aCopy.Name);
            Console.WriteLine(aCopy.Owner.Name);

            foreach (var u in aCopy.Contacts)
            {
                Console.WriteLine(u.Name);
            }

            Console.ReadKey();

            Console.WriteLine("\n\nSe va a modificar la agenda");
            Console.ReadKey();

            aCopy.Name = "BLABLA";
            aCopy.Owner.Name = "LadySir";

            repo = new AgendaRepository();
            repo.Modify(aCopy);

            Console.WriteLine("Agenda Modificada");
            Console.ReadKey();
            Console.WriteLine("Se va a obtener la agenda\n\n");
            Console.ReadKey();
            Agenda aCopy2 = repo.Get(a.Id);

            Console.WriteLine(aCopy2.Id);
            Console.WriteLine(aCopy2.Name);
            Console.WriteLine(aCopy2.Owner.Name);

            foreach (var u in aCopy2.Contacts)
            {
                Console.WriteLine(u.Name);
            }

            Console.ReadKey();


        }
    }
}

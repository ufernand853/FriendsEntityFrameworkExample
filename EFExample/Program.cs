﻿using DataAccess;
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
                Contacts = new List<User>()
            };

            User owner = new User()
            {
                Age = 24,
                Name = "Ramiro"
            };

            User contact1 = new User()
            {
                Age = 22,
                Name = "Lady"
            };

            User contact2 = new User()
            {
                Age = 21,
                Name = "Sir"
            };

            a.Contacts.Add(contact1);
            a.Contacts.Add(contact2);


            Console.WriteLine("Se va a agegar la agenda");
            Console.ReadKey();

            IDataAccess<Agenda> dataAccess = new AgendaDataAccess();
            dataAccess.Add(a);

            Console.WriteLine("Agenda Agregada");
            Console.ReadKey();
            Console.WriteLine("Se va a obtener la agenda\n\n");
            Console.ReadKey();
            Agenda aCopy = dataAccess.Get(a.Id);

            Console.WriteLine(aCopy.Id);
            Console.WriteLine(aCopy.Name);

            foreach (var u in aCopy.Contacts)
            {
                Console.WriteLine(u.Name);
            }

            Console.ReadKey();

            Console.WriteLine("\n\nSe va a modificar la agenda");
            Console.ReadKey();

            aCopy.Name = "BLABLA";
            aCopy.Contacts.Add(new User() { Name = "Kid", Age = 20 });

            dataAccess = new AgendaDataAccess();
            dataAccess.Modify(aCopy);

            Console.WriteLine("Agenda Modificada");
            Console.ReadKey();
            Console.WriteLine("Se va a obtener la agenda\n\n");
            Console.ReadKey();
            Agenda aCopy2 = dataAccess.Get(a.Id);

            Console.WriteLine(aCopy2.Id);
            Console.WriteLine(aCopy2.Name);

            foreach (var u in aCopy2.Contacts)
            {
                Console.WriteLine(u.Name);
            }

            Console.ReadKey();


        }
    }
}

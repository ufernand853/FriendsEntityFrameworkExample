using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using System.Collections.Generic;

namespace TestEFExample
{
    [TestClass]
    public class TestManyToMany
    {
        [TestMethod]
        public void TestAddToAgendasOneUser()
        {

            User owner = new User()
            {
                Age = 24,
                Name = "Juan Owner",
                Agendas = new List<Agenda>()

            };

            Agenda agendaUno = new Agenda()
            {
                Name = "Agenda Uno Juan Owner",
                Contacts = new List<User>()
            };

            Agenda agendaDos = new Agenda()
            {
                Name = "Agenda Dos Juan Owner",
                Contacts = new List<User>()
            };


            owner.Agendas.Add(agendaUno);
            owner.Agendas.Add(agendaDos);


            User contact1 = new User()
            {
                Age = 22,
                Name = "Lady Contact Added",
                Agendas = new List<Agenda>()
            };


            agendaUno.Contacts.Add(contact1);
            
        }
    }
}

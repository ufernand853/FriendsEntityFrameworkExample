using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using System.Collections.Generic;
using Interfaces;
using DataAccess;

namespace TestEFExample
{
    [TestClass]
    public class TestManyToMany
    {
        [TestMethod]
        public void TestAddTwoAgendasToOneUser()
        {

            User user = new User()
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


            user.Agendas.Add(agendaUno);
            user.Agendas.Add(agendaDos);

            IDataAccess<User> dataAccessUser = new UserDataAccess();
            dataAccessUser.Add(user);

        }
    }
}

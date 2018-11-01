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


        public void SetUp()
        {
            SetUpTest setUpTest = new SetUpTest();
            setUpTest.SetupCleanDB();
        }
        [TestMethod]
        public void TestAddTwoAgendasToOneUser()
        {
            SetUp();

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


        [TestMethod]
        public void TestAddUserToAgenda()
        {

            SetUp();

            User user = new User()
            {
                Age = 24,
                Name = "Juan Owner two agendas",
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


            User contact3 = new User()
            {
                Age = 22,
                Name = "Boy Contact Added to Agenda Uno",
                Agendas = new List<Agenda>()
            };


            agendaUno.Contacts.Add(contact3);

            IDataAccess<Agenda> dataAccessAgenda = new AgendaDataAccess();
            dataAccessAgenda.Modify(agendaUno);
        }
    }
}

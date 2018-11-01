

using Interfaces;
using System.Collections.Generic;

namespace DataAccess
{
    public class CleanDB
    {
        public void EmptyDB()
        {
            UserDataAccess userDataAccess=new UserDataAccess();
            AgendaDataAccess AgendaDataAccess = new AgendaDataAccess();

            userDataAccess.Empty();
            AgendaDataAccess.Empty();
        }
    }
}

using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEFExample
{
    public class SetUpTest
    {
            public void SetupCleanDB()
            {
                CleanDB cleaner = new CleanDB();
                cleaner.EmptyDB();
            }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teszt.Database;

namespace teszt
{
    class Worker
    {
        private IDataAccess _database;

        public Worker(IDataAccess database)
        {
            _database = database;
        }

        public string Start(string color)
        {
            return _database.Command(color);
        }
    }
}

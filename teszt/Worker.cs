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
        private IDatabase _database;

        public Worker(IDatabase database)
        {
            _database = database;
        }

        public string Start(string color)
        {
            return _database.Command(color);
        }
    }
}

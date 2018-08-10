using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using teszt.Database;

namespace teszt.Factory
{
    static class DatabaseFactory
    {
        public static IDatabase CreateDatabase(DatabaseType chooseDB)
        {
            switch (chooseDB)
            {
                case DatabaseType.SQLServer:
                    return new SqlServerDatabase();
                case DatabaseType.XML:
                    return new XmlReader();
                case DatabaseType.OleDb:
                    throw new NotImplementedException("Oracle database missing");
                default:
                    return new SqlServerDatabase();
            }
        }
    }
}

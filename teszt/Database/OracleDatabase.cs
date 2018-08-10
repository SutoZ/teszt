using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teszt.Database
{
    class OracleDatabase : IDatabase
    {
        private IDbConnection _connection;
        private IDbCommand _command;

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    if (ConfigurationManager
                        .ConnectionStrings["OracleConnectiontring"] == null)
                    {
                        throw new Exception("Your connetion string was not found in the configuration file");
                    }

                    string connectionString = ConfigurationManager
                        .ConnectionStrings["OracleConnectiontring"].ToString();

                    _connection = new OracleConnection(connectionString);
                }
                return _connection;
            }
        }

        public IDbCommand Command => throw new NotImplementedException();     

        string IDatabase.Command(string color)
        {
            throw new NotImplementedException();
        }
    }
}

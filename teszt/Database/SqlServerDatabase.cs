using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using teszt.Factory;
using System.Collections;

namespace teszt.Database
{
    class SqlServerDatabase : IDatabase
    {
        private SqlConnection _connection = null;
        private SqlCommand _command = null;
        private string _connectionString = null;
        readonly List<string> temp = new List<string>();

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    if (ConfigurationManager
                        .ConnectionStrings["SqlServerConnectionString"] == null)
                    {
                        throw new Exception("Your connetion string was not found in the configuration file");
                    }

                    _connectionString = ConfigurationManager
                        .ConnectionStrings["SqlServerConnectionString"].ToString();

                    _connection = new SqlConnection(_connectionString);
                }
                return _connection;
            }
        }

        public string Command(string color)
        {
            string result = "";

            if (_command == null)
            {
                _command = new SqlCommand
                {
                    Connection = (SqlConnection)Connection
                };

                using (_command)
                {
                    if (_command.Connection != null)
                    {
                        try
                        {
                            _command.CommandType = CommandType.Text;
                            _command.CommandText = "SELECT color FROM car";
                            _command.Connection.Open();

                            IDataReader reader = _command.ExecuteReader();

                            while (reader.Read())
                            {
                                temp.Add(reader.GetString(0));
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Exception happened: ", ex);
                        }

                        result = (from item in temp
                                     where item == color
                                     select item).Single();
                    }
                }
            }
            return result;
        }
    }
}
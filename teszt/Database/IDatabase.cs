using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teszt.Database
{
    public interface IDataAccess
    {
        IDbConnection Connection { get; }
        string Command(string color);
              
    }
}

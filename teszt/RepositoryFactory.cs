using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teszt.Database;

namespace teszt
{
    public static class RepositoryFactory
    {
        public static IDataAccess GetRepository()
        {
            string typeName = ConfigurationManager.AppSettings["RepositoryType"];
            Type repoType = Type.GetType(typeName);
            object repoInstace = Activator.CreateInstance(repoType);
            IDataAccess repo = repoInstace as IDataAccess;
            return repo;
        }
    }
}

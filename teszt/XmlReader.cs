using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using teszt.Database;

namespace teszt
{
    class XmlReader : IDataAccess
    {
        public IDbConnection Connection => throw new NotImplementedException();

        public string Command(string color)
        {
            var XDoc = XDocument.Load("Data.xml");

            IEnumerable<Car> cars = XDoc.Root.Elements(Constants.CAR).Select(x => new Car(x));
            
            var car = cars.Single(c => c.Color == color);

            return car.Color;
        }
    }
}

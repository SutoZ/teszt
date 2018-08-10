using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace teszt
{
    class Car
    {
        public string Color { get; set; }

        public Car(XElement item)
        {
            Color = (string)item.Element(Constants.COLOR);
        }
    }
}

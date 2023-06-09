using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ART
{
    [Serializable]
    internal class Park // Blokovat shromažďování informací o dopravě
    {
        string _name;
        List<Car> _cars;


        public Park() { }
        public Park(string name ,List<Car> cars)
        {
            _name = name;
            _cars = cars;
        }
        public string Name { get { return _name;} set { _name = value; } }
        public List<Car> Cars { get { return _cars; }set { _cars = value; } }
    }
}

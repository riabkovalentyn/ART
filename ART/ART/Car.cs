using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ART
{
    [Serializable] // Blok, který je zodpovědný za komponenty, které jsou v systému
    internal class Car
    {
        string _model;
        string _route;
        int _prise;
        int _numberOfSeats;

        public Car() { }

        public Car(string model,string route,int prise ,int numberOfSeats)
        {
            _model = model;
            _prise = prise;
            _route = route;
            _numberOfSeats = numberOfSeats;
        }
        public string Model { get { return _model;}set { _model = value; } }
        public string Route { get { return _route;}set { _route = value; } }

        public int Price  { get { return _prise; } set { _prise = value; } }
        
        public int NumberOfSeats { get { return _numberOfSeats; } set { _numberOfSeats = value; } }



    }
}

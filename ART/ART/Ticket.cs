using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ART
{
    [Serializable] //Blok zodpovědný za proměnné tiketu
    internal class Ticket
    {
        public string Park { get; set; }
        public string Model { get; set; }
        public string Route { get; set; }
        public int Cost { get; set; }
        public int CountOfSeats { get; set; }

        public Ticket() { }
        public Ticket(string park,string model,string route,int cost,int countOfSeats)
        {
            Park = park;
            Model = model;
            Route = route;
            Cost = cost;
            CountOfSeats = countOfSeats;
        }

        public override string ToString()
        {
            return "\nPark:"+Park+"\nModel:"+"\nRoute:"+Route+"\nPrice:"+Cost+"\nCount of Seats:"+CountOfSeats;
        }
    }
}

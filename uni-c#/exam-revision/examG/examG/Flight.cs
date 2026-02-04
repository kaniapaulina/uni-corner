using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examG
{
    public class Flight : IComparable<Flight>, IBookable
    {
        static long flightCounter;
        static Dictionary<string, float> airportTaxes;

        public readonly string flightID;
        public string destination;
        public decimal basePrice;
        public bool isFull;
        public HashSet<string> passengerNames;

        static Flight()
        {
            flightCounter = 1000;
            airportTaxes = new Dictionary<string, float>();
            airportTaxes.Add("KRK", 45.0f);
            airportTaxes.Add("WAW", 60.0f);
        }

        public Flight(string cel)
        {
            destination = cel;
            flightID = $"{cel}-{flightCounter}/{DateTime.Now.Year}";
            flightCounter++;
            passengerNames = new HashSet<string>();
            basePrice = 200.0m;
        }


        public virtual decimal CalculateTicketPrice()
        {
            decimal add = 0m;
            if (airportTaxes.ContainsKey(destination))
            {
                add = (decimal)airportTaxes[destination];
            }
            else
            {
                add = 100.0m;
            }
            return basePrice + add;
        }

        public int CompareTo(Flight? other)
        {
            if(other == null) return 1;
            int comparer = other.passengerNames.Count.CompareTo(this.passengerNames.Count);

            if(comparer == 0) return this.CalculateTicketPrice().CompareTo(other.CalculateTicketPrice());
            return comparer;
        }

        public override string ToString()
        {
            return $"{flightID}, Destination: {destination} ({CalculateTicketPrice():F2} PLN), Passengers: {string.Join(", ", passengerNames)}";
        }
    }
}

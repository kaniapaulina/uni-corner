using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace examG
{
    internal class Airline
    {
        public List<Flight> flights = new List<Flight>();

        public void AddFlight(Flight flight)
        {
            if (flight != null)
            {
                flights.Add(flight);
            }
        }

        public void BookPassenger(string fID, string name)
        {
            if(flights.FirstOrDefault(lot => lot.flightID == fID).passengerNames.Count <= 5)
                flights.FirstOrDefault(lot => lot.flightID == fID).passengerNames.Add(name);
            else
                flights.FirstOrDefault(lot => lot.flightID == fID).isFull = true;
        }

        public List<Flight> GetTopFlights()
        {
            decimal avg = flights.Sum(x => x.CalculateTicketPrice())/flights.Count();
            int limit = Math.Max(1, (int)Math.Floor(flights.Count * 0.25));

            return flights.OrderByDescending(x => x.CalculateTicketPrice()).Where(x => x.CalculateTicketPrice() > avg).Take(limit).ToList();
        }
    }
}

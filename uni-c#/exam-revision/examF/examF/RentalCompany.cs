using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examF
{
    public class RentalCompany
    {
        public Dictionary<string, Vehicle> transport = new Dictionary<string, Vehicle>();

        public void AddVehicle(Vehicle v)
        {
            transport.Add(v.registrationNumber, v);
        }

        public void RemoveVehicle(string regNum)
        {
            if (transport.ContainsKey(regNum)) 
            {
                transport.Remove(regNum);
            }
        }

        public List<Vehicle> GetTopPremiumVehicles()
        {
            if (transport.Count() == 0) return null;
            int limit = Math.Max(1, (int)Math.Floor(transport.Count() * 0.3));
            decimal avg = 0.0m;
            foreach (Vehicle v in transport.Values)
            {
                avg += v.CalculateRentalPrice();
            }
            avg = avg / transport.Count();
            return transport.Values.Where(x => x.CalculateRentalPrice() > avg).OrderByDescending(x => x.CalculateRentalPrice()).Take(limit).ToList();
        }
    }
}

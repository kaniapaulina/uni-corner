using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examF
{
    public class Vehicle : IPriceable, IComparable<Vehicle>
    {
        static int baseCounter;
        static float[] taxRates;

        static Vehicle()
        {
            baseCounter = 100;
            taxRates = new float[] { 0.08f, 0.23f };
        }

        public readonly string registrationNumber;
        decimal dailyRate;
        int productionYear;
        public bool isRented;

        public Vehicle()
        {
            registrationNumber = $"KR/{baseCounter}/{DateTime.Now.ToString("yyyy")}";
            baseCounter++;
            isRented = false;
            dailyRate = 50.0m;
        }

        public virtual decimal CalculateRentalPrice()
        {
            return dailyRate + dailyRate*(decimal)taxRates[1];
        }

        public int CompareTo(Vehicle? other)
        {
            return other.CalculateRentalPrice().CompareTo(this.CalculateRentalPrice());
        }

        public override string ToString()
        {
            return $"{registrationNumber}, rental price: {CalculateRentalPrice():F2} PLN [{isRented.ToString()}]";
        }
    }
}

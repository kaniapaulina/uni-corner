using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace examF
{
    public class Car : Vehicle
    {
        public bool hasGPS;

        public override decimal CalculateRentalPrice()
        {
            decimal plus = 0.0m;
            if (hasGPS) plus = 50.0m;
            return (base.CalculateRentalPrice() + plus);
        }
    }
}

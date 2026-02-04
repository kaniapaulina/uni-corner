using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examF
{
    public class Truck : Vehicle
    {
        public int maxPayload;

        public override decimal CalculateRentalPrice()
        {
            decimal over = (maxPayload-1000)*1.50m;
            if (over < 0) { over = 0; }
            return base.CalculateRentalPrice() + over;
        }
    }
}

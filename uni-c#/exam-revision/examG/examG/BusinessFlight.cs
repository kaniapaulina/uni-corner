using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examG
{
    public class BusinessFlight : Flight
    {
        public BusinessFlight(string cel):base(cel) { }
        public override decimal CalculateTicketPrice()
        {
            return base.CalculateTicketPrice()*2.5m + 150;
        }
    }
}

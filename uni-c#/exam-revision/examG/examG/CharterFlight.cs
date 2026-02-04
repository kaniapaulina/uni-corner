using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examG
{
    public class CharterFlight : Flight
    {
        bool isCargo;
        public CharterFlight(string cel) : base(cel)
        {
        }

        public override decimal CalculateTicketPrice()
        {
            if (isCargo)
            {
                return base.CalculateTicketPrice()*0.7m;
            }
            return base.CalculateTicketPrice();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examD
{
    public class PersonalComputer:Computer
    {
        bool isCaseTransparent;
        public PersonalComputer(string type, bool trans):base(type)
        {
            isCaseTransparent = trans;
        }
        public override decimal GetPrice()
        {
            return (base.GetPrice() + 68.35m);
        }
    }
}

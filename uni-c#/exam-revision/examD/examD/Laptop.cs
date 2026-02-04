using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examD
{
    public class Laptop : Computer
    {
        bool isAntiGlare;
        public Laptop(string type, bool isAntiGlare) : base(type)
        {
            this.isAntiGlare = isAntiGlare;
        }

        public string CzyJest()
        {
            return (isAntiGlare==true ? "+" : "-");
        }

        public override decimal GetPrice()
        {
            return base.GetPrice() + 116.25m;
        }

        public override string ToString()
        {
            return base.ToString() + $" AntiGlare[{CzyJest()}]";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paczkomat
{
    internal class PaczkaPolecona:Paczka
    {
        static double _oplataDodatkowa;
        static PaczkaPolecona()
        {
            _oplataDodatkowa = 10.0;
        }

        public PaczkaPolecona():base()
        {
        }

        public PaczkaPolecona(string nadawca, int rozmiar):base(nadawca, rozmiar)
        {
        }

        public override double KosztWysylki()
        {
            return base.KosztWysylki() + _oplataDodatkowa;
        }

        public override string ToString()
        {
            return base.ToString() + $" w tym oplata dodatkowa: {_oplataDodatkowa}";
        }
    }
}

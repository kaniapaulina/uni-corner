using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoria.Labs
{
    internal class PaczkaPolecona : Paczka
    {
        static double oplataDodatkowa;

        static PaczkaPolecona()
        {
            oplataDodatkowa = 10.0;
        }

        public PaczkaPolecona() : base() { }

        public PaczkaPolecona(string nadawca, int rozmiar) : base(nadawca, rozmiar)
        {
        }

        public override double KosztWysylki()
        {
            return base.KosztWysylki() + oplataDodatkowa;
        }

        public override string ToString()
        {
            return base.ToString() + $" w tym oplata dodatkowa: {oplataDodatkowa}";
        }

    }
}

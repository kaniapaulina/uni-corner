using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium_grupa_c
{
    public enum enumPozycja { przod, srodek, tyl}
    public class ReniferPociagowy:Renifer, IComparable<ReniferPociagowy>
    {
        enumPozycja pozycja;

        public ReniferPociagowy():base()
        {
            this.pozycja = enumPozycja.srodek;
        }

        public ReniferPociagowy(string nazwisko, DateTime dataUrodzenia, decimal waga, enumPozycja pozycja) : base(nazwisko, dataUrodzenia, waga)
        {
            this.pozycja = pozycja;
        }

        public int CompareTo(ReniferPociagowy? other)
        {
            return this.ObliczUdzwig().CompareTo(other.ObliczUdzwig());
            //throw new NotImplementedException();
        }

        public double MagiaSwiat()
        {
            if(DateTime.Today.Month.Equals(12))
            {
                return 3;
            }
            return 1;
        }

        public override double ObliczUdzwig()
        {
            double baza = base.ObliczUdzwig();
            switch(pozycja)
            {
                case enumPozycja.przod: return baza * 2.0*MagiaSwiat();
                case enumPozycja.srodek: return baza * 1.5*MagiaSwiat();
                case enumPozycja.tyl: return baza*MagiaSwiat();
            }
            return base.ObliczUdzwig()*MagiaSwiat();
        }
    }

}

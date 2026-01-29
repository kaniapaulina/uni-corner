using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumA
{
    public class Wojownik : Mieszkaniec, IComparable<Wojownik>
    {
        #region IComparable
        public int CompareTo(Wojownik? other)
        {
            if (other == null) return 1;
            int compare = this.Moc().CompareTo(other.Moc());
            if (compare != 0) return compare; //nie sa takie same

            return this.WagaRoli(this.Rola).CompareTo(other.WagaRoli(other.Rola));
            //throw new NotImplementedException();
        }
        #endregion IComparable

        // public int WagaRoli(Rola rola) => (int)rola
        public int WagaRoli(Rola rola)
        {
            switch (Rola)
            {
                case Rola.Piechur:
                    return 1;
                case Rola.Łucznik:
                    return 2;
                case Rola.Jeździec:
                    return 3;
            }
            return 0;
        }

        string numer;
        Rola rola;

        private string GenerujNumer()
        {
            string numer = string.Empty;
            numer = $"{rola.ToString().Substring(0, 3).ToUpper()}-{Liczebnosc.ToString("D3")}";
            return numer;
        }

        public Wojownik():base()
        {
            rola = Rola.Piechur;
            numer = GenerujNumer();
        }

        public Wojownik(string imie, string miasto, decimal waga, double szybkosc, Rola rola) : base(imie, miasto, waga, szybkosc)
        {
            this.rola = rola;
            numer = GenerujNumer();
        }



        public override double Moc()
        {
            double baseMoc = base.Moc();
            switch (rola)
            {
                 case Rola.Piechur: return baseMoc + 10;
                 case Rola.Łucznik: return baseMoc + 20;
                 case Rola.Jeździec: return baseMoc + 50;
  
            }
            return baseMoc;

        }

        public override string ToString()
        {
            return $"{Imie} z miasta {Miasto}, {rola}, {numer}, Moc:{Moc()}";
        }

        

        public string Numer { get => numer; set => numer = value; }
        public Rola Rola { get => rola; private set => rola = value; }
    }
}

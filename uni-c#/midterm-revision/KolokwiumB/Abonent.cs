using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumB
{
    public class Abonent
    {
        string imie;
        string nazwisko;
        string pesel;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string Pesel { get => pesel;
            set
            {
                if (value.Length != 11)
                {
                    throw new FormatException("Pesel nie ma 11 znaków");
  
                }
                pesel = value;
            }
        }

        public Abonent()
        {
            this.imie = string.Empty;
            this.nazwisko = string.Empty;
            this.pesel = "00000000000";
        }

        public Abonent(string imie, string nazwisko, string pesel)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.pesel = pesel;
        }

        public override string ToString()
        {
            return $"{imie} {nazwisko} [PESEL: {pesel}]";
        }
    }
}

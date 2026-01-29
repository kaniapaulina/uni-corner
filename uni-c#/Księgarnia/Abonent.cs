using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Księgarnia
{
    internal class Abonent
    {
        private string imie;
        private string nazwisko;
        private string numerTelefonu;
        private string miasto;

        public Abonent(string imie, string nazwisko, string numerTelefonu, string miasto)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.numerTelefonu = numerTelefonu;
            this.miasto = miasto;
        }

        public override string ToString()
        {
            return $"{imie} {nazwisko}, {miasto}, tel.:{numerTelefonu}";
        }

        public bool SprawdzNumerTelefonu(string numer)
        {
            const string wzorzec = @"^\d{3}-\d{3}-\d{3}$";
            return Regex.IsMatch(numer, wzorzec);
        }

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string NumerTelefonu { get => numerTelefonu;
            set
            {
                try
                {
                    string n = value;
                    if (!SprawdzNumerTelefonu(n))
                    {
                        throw new wrongNumberException("Niepoprawny format numeru telefonu. Poprawny format to XXX-XXX-XXX, gdzie X to cyfra.");
                    }
                    numerTelefonu = n;

                }
                catch (wrongNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public string Miasto { get => miasto; set => miasto = value; }
    }
}

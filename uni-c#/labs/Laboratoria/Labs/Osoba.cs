using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoria.Labs
{
    public class Osoba
    {
        // ZADANIE 1 - tworzenie klasy
        private string imie;
        private string nazwisko;
        private string adres;
        private DateTime dataUrodzenia;
        private string pesel;
        private EnumPlec plec;

        // ZADANIE 2 - implementacja wlasciwosci
        public string Imie
        {
            get => imie;
            set => imie = value;
        }

        public string Nazwisko
        {
            get => nazwisko;
            set
            {
                string s = value;
                nazwisko = char.ToUpper(s[0]) + s.Substring(1).ToLower();
                //pierwsza literka duża, reszta mała

            }
        }

        public string Adres { 
            get => adres; 
            set => adres = value; }
        public DateTime DataUrodzenia { 
            get => dataUrodzenia; 
            set => dataUrodzenia = value; }
        public EnumPlec Plec { 
            get => plec; 
            set => plec = value; }

        public string Pesel { 
            get => pesel; 
            init => pesel = value;
            //set mozna edytowac, init tylko przy inicjalizacji
        }

        // Właściwość PESEL z sprawdzaniem czy ma 11 znaków
        public string PESEL
        {
            get => pesel;
            init
            {
                try
                {
                    string p = value;
                    if (p.Length != 11)
                    {
                        throw new WrongPeselException("Niepoprawny PESEL kolego");
                    }
                    Pesel = p;
                }
                catch (WrongPeselException e)
                {
                    Console.WriteLine(e.Message);
                    Pesel = new string('0', 11);
                }
            }
        }

        // ZADANIE 4 - Konstruktory
        public Osoba()      //domyślny - inicjalizuje pesel
        {
            imie = string.Empty;
            nazwisko = string.Empty;
            adres = string.Empty;
            pesel = new string('0', 11);
            dataUrodzenia = DateTime.MinValue;
        }

        public Osoba(string imie, string nazwisko, EnumPlec plec) : this()   //konstruktor domyślny
        {
            this.imie = imie;
            Nazwisko = nazwisko;
            this.plec = plec;
        }

        public Osoba(string imie, string nazwisko, string dataUrodzenia, string pesel, EnumPlec plec)
            : this(imie, nazwisko, plec)
        {
            this.Adres = adres;
            PESEL = pesel;
            this.plec = plec;
            DateTime.TryParseExact(dataUrodzenia, new[] { "yyyy-MM-dd", "dd.MM.yyyy", "dd/MM/yyyy", "dd-MMM-yy" }, null, DateTimeStyles.None, out this.dataUrodzenia); //Ty DateType szalone
        }

        public Osoba(string imie, string nazwisko, string ulica, string miasto, int kod, string dataUrodzenia, string pesel, EnumPlec plec)
            : this(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            this.adres = $"{ulica}, {kod:00-000} {miasto}"; //osobny zapis adresu
            //kod sformatowany do postaci 00-000, inaczej uzyj stringa bo int nie lapie "-'
        }


        // ZADANIE 5 - Metoda Wiek()
        public int Wiek() //zwraca int - liczbe
        {
            if (dataUrodzenia == DateTime.MinValue)
                return -1; //brak daty urodzenia

            return DateTime.Now.Year - dataUrodzenia.Year;;
        }

        // ZADANIE 3 - Przesłonięcie ToString()
        public override string ToString()
        {
            string result = $"{imie} {nazwisko} ({plec})";

            if (dataUrodzenia != DateTime.MinValue)
            {
                result += $", ur. {dataUrodzenia:yyyy-MM-dd}";
            }

            result += $" ({pesel})";

            if (!string.IsNullOrEmpty(adres))
            {
                result += $", {adres}";
            }

            return result;
        }

        // ZADANIE 7 - Metoda z wiekiem
        public string ToStringWithAge()
        {
            string ageInfo = Wiek() >= 0
                ? (Wiek() % 10 == 2 || Wiek() % 10 == 3 || Wiek() % 10 == 4) && (Wiek() < 10 || Wiek() > 20) //TRUE
                    ? $"[{Wiek()} lata]"
                    : $"[{Wiek()} lat]"
                : "[-]"; //FALSE - brak daty

            string result = $"{imie} {nazwisko} {ageInfo} ({plec})";

            if (dataUrodzenia != DateTime.MinValue)
            {
                result += $", ur. {DataUrodzenia:yyyy-MM-dd} ({pesel})";
            }
            else
            {
                result += $" ({pesel})";
            }

            if (!string.IsNullOrEmpty(adres))
            {
                result += $", {adres}";
            }

            return result;
        }
    }
}

//mamy to panowie

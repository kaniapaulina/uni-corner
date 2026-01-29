using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsobaZespol
{
    /// <summary>
    /// Abstrakcyjna klasa bazowa reprezentująca osobę fizyczną.
    /// Dostarcza podstawowych pól: imię, nazwisko, adres, datę urodzenia, PESEL i płeć.
    /// Implementuje <see cref="IEquatable{Osoba}"/> porównując osoby po PESEL.
    /// </summary>
    public abstract class Osoba : IEquatable<Osoba>
    {
        // Zadanie 1 - pola klasy Osoba
        private string imie;
        private string nazwisko;
        private string adres;
        private DateTime dataUrodzenia;
        private string pesel;
        private EnumPlec plec;


        // Zadanie 2 - Właściwości klasy Osoba
        /// <summary>
        /// Imię osoby.
        /// </summary>
        public string Imie { get => imie; set => imie = value; }

        /// <summary>
        /// Nazwisko osoby. Setter normalizuje pierwszą literę jako wielką, pozostałe jako małe.
        /// </summary>
        public string Nazwisko
        {
            get => nazwisko; set
            {
                nazwisko = char.ToUpper(value[0]) + value.Substring(1).ToLower();
            }
        }

        /// <summary>
        /// Adres osoby.
        /// </summary>
        public string Adres { get => adres; set => adres = value; }

        /// <summary>
        /// Data urodzenia osoby.
        /// </summary>
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }

        /// <summary>
        /// PESEL osoby. Setter waliduje długość (musi mieć dokładnie 11 znaków).
        /// </summary>
        /// <exception cref="wrongPeselException">Rzucany gdy wartość PESEL nie ma 11 znaków.</exception>
        public string Pesel
        {
            get => pesel;
            set
            {
                if (value.Length != 11)
                {
                    throw new wrongPeselException("PESEL musi mieć dokładnie 11 znaków.");
                }
                pesel = value;
            }
        }

        /// <summary>
        /// Płeć osoby.
        /// </summary>
        public EnumPlec Plec { get => plec; set => plec = value; }



        /// <summary>
        /// Tworzy instancję Osoba z domyślnymi wartościami.
        /// </summary>
        public Osoba()
        {
            imie = string.Empty;
            nazwisko = string.Empty;
            adres = string.Empty;
            Pesel = new string('0', 11);
        }

        /// <summary>
        /// Tworzy osobę z podstawowymi danymi.
        /// </summary>
        /// <param name="imie">Imię.</param>
        /// <param name="nazwisko">Nazwisko.</param>
        /// <param name="plec">Płeć.</param>
        public Osoba(string imie, string nazwisko, EnumPlec plec) : this()
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.plec = plec;
        }

        /// <summary>
        /// Tworzy osobę z PESEL-em.
        /// </summary>
        /// <param name="imie">Imię.</param>
        /// <param name="nazwisko">Nazwisko.</param>
        /// <param name="pesel">PESEL (11 cyfr).</param>
        /// <param name="plec">Płeć.</param>
        public Osoba(string imie, string nazwisko, string pesel, EnumPlec plec) : this(imie, nazwisko, plec)
        {
            Pesel = pesel;
        }

        /// <summary>
        /// Tworzy osobę i ustawia datę urodzenia (parsowaną ze stringa).
        /// </summary>
        /// <param name="imie">Imię.</param>
        /// <param name="nazwisko">Nazwisko.</param>
        /// <param name="dataUrodzenia">Data urodzenia w formacie akceptowanym przez parser.</param>
        /// <param name="pesel">PESEL (11 cyfr).</param>
        /// <param name="plec">Płeć.</param>
        public Osoba(string imie, string nazwisko, string dataUrodzenia, string pesel, EnumPlec plec) : this(imie, nazwisko, pesel, plec)
        {
            DateTime.TryParseExact(dataUrodzenia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, null, System.Globalization.DateTimeStyles.None, out this.dataUrodzenia);
        }

        /// <summary>
        /// Tworzy osobę z adresem i datą urodzenia.
        /// </summary>
        /// <param name="imie">Imię.</param>
        /// <param name="nazwisko">Nazwisko.</param>
        /// <param name="adres">Adres.</param>
        /// <param name="dataUrodzenia">Data urodzenia (string parsowany).</param>
        /// <param name="pesel">PESEL (11 cyfr).</param>
        /// <param name="plec">Płeć.</param>
        public Osoba(string imie, string nazwisko, string adres, string dataUrodzenia, string pesel, EnumPlec plec) : this(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            this.adres = adres;
        }

        /// <summary>
        /// Tworzy osobę z rozbitym adresem (ulica, miasto, kod).
        /// </summary>
        /// <param name="imie">Imię.</param>
        /// <param name="nazwisko">Nazwisko.</param>
        /// <param name="ulica">Ulica.</param>
        /// <param name="miasto">Miasto.</param>
        /// <param name="kod">Kod pocztowy (int).</param>
        /// <param name="dataUrodzenia">Data urodzenia (string).</param>
        /// <param name="pesel">PESEL (11 cyfr).</param>
        /// <param name="plec">Płeć.</param>
        public Osoba(string imie, string nazwisko, string ulica, string miasto, int kod, string dataUrodzenia, string pesel, EnumPlec plec) : this(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            this.adres = $"ul. {ulica}, {kod:00-000} {miasto}";
        }

        /// <summary>
        /// Oblicza wiek osoby na podstawie daty urodzenia (pełne lata).
        /// </summary>
        /// <returns>Liczba pełnych lat (int).</returns>
        public int Wiek()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dataUrodzenia.Year;
            return age;
        }

        /// <summary>
        /// Tekstowa reprezentacja osoby, zawiera wiek (jeśli dostępny), PESEL i adres.
        /// </summary>
        /// <returns>String opisujący osobę.</returns>
        public override string ToString()
        {
            if (dataUrodzenia == DateTime.MinValue)
            {
                return $"{imie} {nazwisko} [-] ({plec}), ur. [-] ({pesel}), {adres}";
            }

            int age = this.Wiek();
            string text = "";
            if (age % 10 >= 2 && age % 10 <= 4 && (age % 100 < 10 || age % 100 >= 200))
            {
                text = "lata";
            }
            else if (age == 1)
            {
                text = "rok";
            }
            else
            {
                text = "lat";
            }

            return $"{imie} {nazwisko} [{age} {text}] ({plec}), ur. {dataUrodzenia.ToShortDateString():dd-mm-yyyy} ({pesel}), {adres}";
        }

        /// <summary>
        /// Porównuje dwie osoby po PESEL.
        /// </summary>
        /// <param name="other">Inny obiekt <see cref="Osoba"/>.</param>
        /// <returns>True jeśli PESEL-y są identyczne, w przeciwnym razie false.</returns>
        public bool Equals(Osoba? other)
        {
            if (this.Pesel == other.Pesel)
            {
                return true;
            }
            return false;
        }
    }
}

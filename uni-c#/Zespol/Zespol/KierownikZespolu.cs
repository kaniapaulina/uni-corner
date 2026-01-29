using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsobaZespol
{
    /// <summary>
    /// Reprezentuje kierownika zespołu. Dziedziczy po <see cref="Osoba"/> i wspiera klonowanie.
    /// </summary>
    public class KierownikZespolu : Osoba, ICloneable
    {
        int doswiadczenieKierownika; // w latach
        long telefonKontaktowy;

        /// <summary>
        /// Tworzy domyślnego kierownika.
        /// </summary>
        public KierownikZespolu()
        {
            this.doswiadczenieKierownika = 0;
            this.telefonKontaktowy = 0;
        }

        /// <summary>
        /// Tworzy kierownika z pełnymi danymi.
        /// </summary>
        /// <param name="imie">Imię kierownika.</param>
        /// <param name="nazwisko">Nazwisko kierownika.</param>
        /// <param name="dataUrodzenia">Data urodzenia jako string (parsowana).</param>
        /// <param name="pesel">PESEL (11 cyfr).</param>
        /// <param name="plec">Płeć (EnumPlec).</param>
        /// <param name="doswiadczenieKierownika">Doświadczenie w latach.</param>
        /// <param name="telefonKontaktowy">Numer telefonu kontaktowego (liczbowo).</param>
        public KierownikZespolu(string imie, string nazwisko, string dataUrodzenia, string pesel, EnumPlec plec, int doswiadczenieKierownika, long telefonKontaktowy) : base(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            this.doswiadczenieKierownika = doswiadczenieKierownika;
            this.telefonKontaktowy = telefonKontaktowy;
        }

        /// <summary>
        /// Doświadczenie kierownika w latach.
        /// </summary>
        public int DoswiadczenieKierownika { get => doswiadczenieKierownika; set => doswiadczenieKierownika = value; }

        /// <summary>
        /// Numer telefonu kontaktowego kierownika.
        /// </summary>
        public long TelefonKontaktowy { get => telefonKontaktowy; set => telefonKontaktowy = value; }

        /// <summary>
        /// Tworzy płytką kopię kierownika.
        /// </summary>
        /// <returns>Nowy obiekt będący kopią.</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Zwraca czytelną reprezentację kierownika.
        /// </summary>
        /// <returns>Tekst zawierający imię, nazwisko, datę urodzenia, PESEL, doświadczenie i numer telefonu.</returns>
        public override string ToString()
        {
            return $"{Imie} {Nazwisko} {DataUrodzenia:yyyy-mm-dd} {Pesel} {doswiadczenieKierownika} ({telefonKontaktowy:000-000-000})";
        }
    } 
}

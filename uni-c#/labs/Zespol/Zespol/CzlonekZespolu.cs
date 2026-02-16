using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsobaZespol
{
    /// <summary>
    /// Reprezentuje członka zespołu. Dziedziczy po <see cref="Osoba"/>.
    /// Umożliwia porównywanie (IComparable) oraz klonowanie (ICloneable).
    /// </summary>
    public class CzlonekZespolu : Osoba, IComparable<CzlonekZespolu>, ICloneable
    {
        #region EF
        [Key]
        public int CzłonekZespoluld { get; set; }
        public int ZespolId { get; set; }
        public virtual Zespol Zespol { get; set; }
        #endregion EF

        DateTime dataWstapienia;
        string funkcjaWZespole;
        bool aktywny;

        /// <summary>
        /// Tworzy nowego członka zespołu z wartościami domyślnymi.
        /// </summary>
        public CzlonekZespolu() : base()
        {
            this.funkcjaWZespole = string.Empty;
        }

        /// <summary>
        /// Tworzy członka zespołu z pełnymi danymi.
        /// </summary>
        /// <param name="imie">Imię członka.</param>
        /// <param name="nazwisko">Nazwisko członka.</param>
        /// <param name="dataUrodzenia">Data urodzenia w formacie akceptowanym przez konstruktor (np. "yyyy-MM-dd").</param>
        /// <param name="pesel">PESEL (11 cyfr) - setter może rzucić <see cref="wrongPeselException"/> jeśli niepoprawny.</param>
        /// <param name="plec">Płeć (EnumPlec).</param>
        /// <param name="dataWstapienia">Data wstąpienia do zespołu (string parsowany do DateTime).</param>
        /// <param name="funkcjaWZespole">Funkcja pełniona w zespole.</param>
        /// <param name="aktywny">Flaga aktywności członka.</param>
        public CzlonekZespolu(string imie, string nazwisko, string dataUrodzenia, string pesel, EnumPlec plec, string dataWstapienia, string funkcjaWZespole, bool aktywny) : base(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            DateTime.TryParseExact(dataWstapienia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, null, System.Globalization.DateTimeStyles.None, out this.dataWstapienia);
            this.funkcjaWZespole = funkcjaWZespole;
            this.aktywny = aktywny;
        }

        /// <summary>
        /// Data wstąpienia członka do zespołu.
        /// </summary>
        public DateTime DataWstapienia { get => dataWstapienia; set => dataWstapienia = value; }

        /// <summary>
        /// Funkcja/stanowisko członka w zespole.
        /// </summary>
        public string FunkcjaWZespole { get => funkcjaWZespole; set => funkcjaWZespole = value; }

        /// <summary>
        /// Flaga aktywności członka.
        /// </summary>
        public bool Aktywny { get => aktywny; set => aktywny = value; }

        /// <summary>
        /// Tworzy płytką kopię obiektu członka zespołu.
        /// </summary>
        /// <returns>Nowy obiekt będący kopią (memberwise clone).</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Porównuje bieżącego członka z innym członkiem.
        /// Sortowanie: najpierw po nazwisku, jeśli nazwiska równe - po imieniu.
        /// </summary>
        /// <param name="other">Inny obiekt <see cref="CzlonekZespolu"/> do porównania.</param>
        /// <returns>
        /// Liczba ujemna jeśli bieżący występuje przed <c>other</c>,
        /// zero jeśli równy,
        /// dodatnia jeśli po <c>other</c>.
        /// </returns>
        public int CompareTo(CzlonekZespolu? other)
        {
            if (other == null) { return 1; }

            if (this.Nazwisko.CompareTo(other?.Nazwisko) == 0)
            {
                return this.Imie.CompareTo(other?.Imie);
            }
            return this.Nazwisko.CompareTo(other?.Nazwisko);
        }

        /// <summary>
        /// Zwraca czytelną reprezentację członka zespołu.
        /// </summary>
        /// <returns>Tekst zawierający imię, nazwisko, status aktywności, daty i PESEL.</returns>
        public override string ToString()
        {
            return $"{Imie} {Nazwisko} {(aktywny ? "(A)" : "")} {DataUrodzenia:yyyy-mm-dd} {Pesel}, Funkcja: {funkcjaWZespole} ({dataWstapienia:dd-MMM-yyyy})";
        }
    }
}

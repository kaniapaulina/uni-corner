using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoria.Labs
{
    internal class CzlonekZespolu : Osoba
    {
        DateTime dataWstapienia;
        string funkcjaWZespole;
        bool aktywny;
        public CzlonekZespolu():base()
        {
            funkcjaWZespole = string.Empty;
        }

        public CzlonekZespolu(string imie, string nazwisko, string dataUrodzenia, string pesel, EnumPlec plec, string dataWstapienia, string funkcjaWZespole, bool aktywny) : base(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            funkcjaWZespole = funkcjaWZespole;
            this.aktywny = aktywny;
            DateTime.TryParseExact(dataWstapienia, new[] { "yyyy-MM-dd", "dd.MM.yyyy", "dd/MM/yyyy", "dd-MMM-yy" }, null, DateTimeStyles.None, out this.dataWstapienia);
        }

        public DateTime DataWstapienia { get => dataWstapienia; set => dataWstapienia = value; }
        public string FunkcjaWZespole { get => funkcjaWZespole; set => funkcjaWZespole = value; }
        public bool Aktywny { get => aktywny; set => aktywny = value; }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko} " + $"{(aktywny ? "(A)" : "")} " + $"{DataUrodzenia.ToShortDateString()} {Pesel} {Plec} {funkcjaWZespole} ({dataWstapienia.ToShortDateString()})";
        }
    }
}

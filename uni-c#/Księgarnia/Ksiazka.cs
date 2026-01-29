using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Księgarnia
{
    internal class Ksiazka
    {
        protected static long indeks;
        private string tytul;
        private DateTime dataWydania;
        private EnumWydawcy wydawca;
        private string isbn;


        static Ksiazka()
        {
            indeks = 0;
        }

        public Ksiazka(string tytul, string dataWydania, EnumWydawcy wydawca)
        {
            
            this.tytul = tytul;
            DateTime.TryParseExact(dataWydania, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, null, System.Globalization.DateTimeStyles.None, out this.dataWydania);
            this.wydawca = wydawca;
            this.isbn = $"ISBN-{this.dataWydania.Year}-{ZmienNaRzymskie(this.dataWydania.Month)}-{this.dataWydania.Day}-{indeks}";
            indeks++;
        }

        public static long Indeks { get => indeks; set => indeks = value; }
        public string Tytul { get => tytul; set => tytul = value; }
        public DateTime DataWydania { get => dataWydania; set => dataWydania = value; }
        public EnumWydawcy Wydawca { get => wydawca; set => wydawca = value; }
        public string Isbn { get => isbn; set => isbn = value; }

        public string ZmienNaRzymskie(int miesiac)
        {
            string[] rzymskie = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII" };
            return rzymskie[miesiac - 1];
        }
        public override string ToString()
        {
            return $"{isbn}: \"{ tytul}\", {wydawca} {{data wydania: {DataWydania:MMM-yyyy}}} ";
        }
    }
}

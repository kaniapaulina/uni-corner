using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoria.Labs
{
    internal class Zespol
    {
        int liczbaAktywnychCzlonkow;
        string nazwaZespolu;
        KierownikZespolu kierownik;
        List<CzlonekZespolu> czlonkowie;

        public Zespol()
        {
            liczbaAktywnychCzlonkow = 0;
            nazwaZespolu = string.Empty;
            kierownik = null;
            czlonkowie = new List<CzlonekZespolu>  ();
        }

        public Zespol(string  nazwaZespolu, KierownikZespolu k):this()
        {
            this.nazwaZespolu = nazwaZespolu;
            this.kierownik = k;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\n === Zespol: {nazwaZespolu} === ");
            sb.AppendLine($"Liczba członków: {LiczbaAktywnychCzlonkow}");
            sb.AppendLine($"Kierownik: {kierownik.ToString()}");

            foreach(CzlonekZespolu czlonek in czlonkowie)
            {
                sb.AppendLine(czlonek.ToString());
            }

            return sb.ToString();
        }

        public int LiczbaAktywnychCzlonkow { get => liczbaAktywnychCzlonkow; set => liczbaAktywnychCzlonkow = value; }
        public string NazwaZespolu { get => nazwaZespolu; set => nazwaZespolu = value; }
        internal KierownikZespolu Kierownik { get => kierownik; set => kierownik = value; }

        public void DodajCzlonka(CzlonekZespolu czlonek)
        {
            czlonkowie.Add(czlonek);
            LiczbaAktywnychCzlonkow++;
        }
    }
}

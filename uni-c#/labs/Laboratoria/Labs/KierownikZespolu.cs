using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoria.Labs
{
    internal class KierownikZespolu : Osoba
    {
        int doswiadczenieKierownicze;
        long telefonKontaktowy;

        public KierownikZespolu(string imie, string nazwisko, string dataUrodzenia, string pesel, EnumPlec plec, int doswiadczenie, long telefonKontaktowy) : base(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            doswiadczenieKierownicze = doswiadczenie;
            TelefonKontaktowy = telefonKontaktowy;
        }

        public int DoswiadczenieKierownicze { get => doswiadczenieKierownicze; set => doswiadczenieKierownicze = value; }
        public long TelefonKontaktowy { get => telefonKontaktowy; set => telefonKontaktowy = value; }

        public override string ToString()
        {
            return base.ToString() + $", {doswiadczenieKierownicze}, (tel. {telefonKontaktowy:000-000-000})";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paczkomat
{
    internal class MagazynFIFO:IMagazynuje
    {
        string nazwa;
        int iloscPaczek;
        Queue<Paczka> kolejkaPaczek = new Queue<Paczka>();

        public MagazynFIFO()
        {
            nazwa = string.Empty;
            iloscPaczek = 0;
        }

        public MagazynFIFO(string nazwa):this()
        {
            this.nazwa = nazwa;
            this.iloscPaczek = 0;
        }

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public int IloscPaczek { get => iloscPaczek; set => iloscPaczek = value; }
        internal Queue<Paczka> KolejkaPaczek { get => kolejkaPaczek; set => kolejkaPaczek = value; }

        public Paczka Pobierz()
        {
            iloscPaczek--;
            return kolejkaPaczek.Dequeue();
        }

        public Paczka PodajBiezacy()
        {
            return kolejkaPaczek.Peek();
        }

        public int PodajIlosc()
        {
            return iloscPaczek;
        }

        public void Umiesc(Paczka t)
        {
             kolejkaPaczek.Enqueue(t);
             iloscPaczek++;
        }

        public void Wyczysc()
        {
            kolejkaPaczek.Clear();
            iloscPaczek = 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Magazyn FIFO: {nazwa}\n");
            sb.AppendLine($"Ilość paczek: {iloscPaczek}\n");
            foreach (Paczka p in kolejkaPaczek)
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paczkomat
{
    internal class MagazynLIFO:IMagazynuje
    {
        string nazwa;
        int iloscPaczek;
        Stack<Paczka> stosPaczek = new Stack<Paczka>();

        public MagazynLIFO()
        {
            nazwa = string.Empty;
            iloscPaczek = 0;
        }

        public MagazynLIFO(string nazwa):this()
        {
            this.nazwa = nazwa;
            iloscPaczek = 0;
        }

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public int IloscPaczek { get => iloscPaczek; set => iloscPaczek = value; }
        internal Stack<Paczka> StosPaczek { get => stosPaczek; set => stosPaczek = value; }



        public Paczka Pobierz()
        {
            iloscPaczek--;
            return stosPaczek.Pop();
        }

        public Paczka PodajBiezacy()
        {
            return stosPaczek.Peek();
        }

        public int PodajIlosc()
        {
            return iloscPaczek;
        }

        public void Umiesc(Paczka t)
        {
            stosPaczek.Push(t);
            iloscPaczek++;
        }

        public void Wyczysc()
        {
            stosPaczek.Clear();
            iloscPaczek = 0;
        }

        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Magazyn LIFO: {nazwa}\n");
            sb.Append($"Ilość paczek: {iloscPaczek}\n");
            foreach (Paczka p in stosPaczek)
            {
                sb.Append(p.ToString());
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoria.Labs
{
    internal class MagazynFIFO : IMagazynuje
    {
        string nazwa;
        int iloscPaczek;
        Queue<Paczka> kolejka;

        public MagazynFIFO()
        {
            nazwa = string.Empty;
            iloscPaczek = 0;
            kolejka = new Queue<Paczka>();
        }

        public MagazynFIFO(string nazwa) : this()
        {
            this.nazwa = nazwa;
        }

        public Paczka Pobierz()
        {
            // throw new NotImplementedException();
            iloscPaczek--;
            return kolejka.Dequeue();
        }

        public Paczka PodajBiezacy()
        {
            //throw new NotImplementedException();
            return kolejka.Peek();
        }

        public int PodajIlosc()
        {
            //throw new NotImplementedException();
            return iloscPaczek;
        }

        public void Umiesc(Paczka t)
        {
            kolejka.Enqueue(t);
            iloscPaczek++;
            //throw new NotImplementedException();
        }

        public void Wyczysc()
        {
            //throw new NotImplementedException();
            kolejka.Clear();
            iloscPaczek--;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("=====");
            foreach (var paczka in kolejka)
            {
                sb.Append($"{paczka}");
            }
            return sb.ToString();
        }
    }
}

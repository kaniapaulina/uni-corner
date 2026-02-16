using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoria.Labs
{
    internal class MagazynLIFO : IMagazynuje
    {
        string nazwa;
        int iloscPaczek;
        Stack<Paczka> stosPaczek;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public int IloscPaczek { get => iloscPaczek; set => iloscPaczek = value; }
        internal Stack<Paczka> StosPaczek { get => stosPaczek; set => stosPaczek = value; }

        public MagazynLIFO()
        {
            stosPaczek = new Stack<Paczka>();
            iloscPaczek = 0;
            nazwa = string.Empty;
        }

        public MagazynLIFO(string nazwa) : this()
        {
            this.nazwa = nazwa; //odwolanie do ukrytego pola klasy
            //Nazwa = nazwa; - odwolanie do gettera
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== MAGAZYN LIFO - stosik: ===");
            sb.AppendLine($"NAZWA {nazwa}");
            sb.AppendLine($"Ilosc elementow: {iloscPaczek}");
            sb.AppendLine("PACZKI: ");
            foreach (var p in stosPaczek)
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString();
        }

        public void Umiesc(Paczka t)
        {
            //throw new NotImplementedException();
            stosPaczek.Push(t);
            iloscPaczek++;
        }

        public Paczka Pobierz()
        {
            //throw new NotImplementedException();
            iloscPaczek--;
            return stosPaczek.Pop();

        }

        public void Wyczysc()
        {
            stosPaczek.Clear();
            //throw new NotImplementedException();
        }

        public int PodajIlosc()
        {
            //return iloscPaczek;
            return stosPaczek.Count;
            //throw new NotImplementedException();
        }

        public Paczka PodajBiezacy()
        {
            return stosPaczek.Peek();
            //throw new NotImplementedException();
        }
    }
}

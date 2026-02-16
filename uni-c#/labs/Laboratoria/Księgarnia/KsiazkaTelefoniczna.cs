using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Księgarnia
{
    internal class KsiazkaTelefoniczna:Ksiazka
    {
        Dictionary<string, Abonent> abonenci = new Dictionary<string, Abonent>();

        public KsiazkaTelefoniczna(string tytul, string dataWydania, EnumWydawcy wydawca) : base(tytul, dataWydania, wydawca)
        {
            this.Isbn += "-KT";
        }

        public void DodajAbonenta(Abonent abonent)
        {
            //abonenci[abonent.NumerTelefonu] = abonent;
            if (abonenci.ContainsKey(abonent.NumerTelefonu))
            { 
                Console.WriteLine($"Abonent o numerze {abonent.NumerTelefonu} już istnieje w książce telefonicznej.");
            }
            else
            {
                abonenci.Add(abonent.NumerTelefonu, abonent);
            }
        }

        public void UsunAbonenta(string numerTelefonu)
        {
            if (abonenci.ContainsKey(numerTelefonu))
            {
                abonenci.Remove(numerTelefonu);
            }
            else
            {
                Console.WriteLine($"Abonent o numerze {numerTelefonu} nie istnieje w książce telefonicznej.");
            }
        }

        public List<Abonent> WyszukajAbonentow(string miasto)
        {
            List<Abonent> znalezieniAbonenci = new List<Abonent>();
            foreach (var abonent in abonenci.Values)
            {
                if (abonent.Miasto.Equals(miasto, StringComparison.OrdinalIgnoreCase))
                {
                    znalezieniAbonenci.Add(abonent);
                }
            }
            return znalezieniAbonenci;
        }

        internal Dictionary<string, Abonent> Abonenci { get => abonenci; set => abonenci = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\n==== Abonenci {base.Tytul}");
            foreach (var abonent in abonenci.Values)
            {
                sb.AppendLine(abonent.ToString());
            }
            return sb.ToString();
        }
    }
}

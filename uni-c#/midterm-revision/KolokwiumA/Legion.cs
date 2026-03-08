using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KolokwiumA
{
    public class ImieComparer : IComparer<Wojownik>
    {
        public int Compare(Wojownik? x, Wojownik? y)
        {
            return string.Compare(x?.Imie, y?.Imie);
            //throw new NotImplementedException();
        }
    }
    internal class Legion 
    {
        public static void ZapiszXML(Legion legion, string plik)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Legion));
                using (var writer = new StreamWriter(plik))
                {
                    serializer.Serialize(writer, legion);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }

        public static Legion OdczytajXML(string plik)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Legion));
                using (var writer = new StreamReader(plik))
                {
                    return (Legion)serializer.Deserialize(writer);
                }
                    
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            return null;       
        }


        string nazwa;
        Dowodca dowodca;
        List<Wojownik> wojownicy;

        public Legion()
        {
            wojownicy = new List<Wojownik>();   
            dowodca = new Dowodca();
        }

        /*
        public string Oddzial()
        {
            int luc = 0;
            int pie = 0;
            int jez = 0;
            foreach (var w in wojownicy)
            {
                switch (w.Rola)
                {
                    case Rola.Łucznik:
                        luc++;
                        break;
                    case Rola.Piechur:
                        pie++;
                        break;
                    case Rola.Jeździec:
                        jez++;
                        break;
                }
            }
            return $"Łucznil: {luc}, Piechur: {pie}, Jeździec: {jez}";
        }
        */
        public string Oddzial()
        {
            string wynik = string.Empty;
            wynik = $"Łucznik: {wojownicy.Where(w => w.Rola == Rola.Łucznik).Count()}";
            wynik += $", Piechur: {wojownicy.Where(w => w.Rola == Rola.Piechur).Count()}";
            wynik += $", Jeździec: {wojownicy.Where(w => w.Rola == Rola.Jeździec).Count()}";
            return wynik;
        }

        /*
        public double MocOddzialu()
        {
            double suma = 0.0;
            foreach (var w in wojownicy)
            {
                 suma += w.Moc();
            }
            suma += dowodca.Moc();
            return suma;
        }
        */

        public double MocOdzzialu() => wojownicy.Sum(w => w.Moc()) + dowodca.Moc();


        public void Dodaj(Wojownik w)
        {
            if (w != null)
            { wojownicy.Add(w); }
        }

        public void Zwolnij(Wojownik w)
        {
            if (w != null) { wojownicy.Remove(w);}
            
        }

        public void ZwolnijPoImieniu( string imie)
        {
            var w = wojownicy.FirstOrDefault(x => x.Imie == imie);
            wojownicy.Remove(w);
        }

        public void Sort()
        {
            wojownicy.Sort();
        }

        public void SortpoImieniu()
        { 
            wojownicy.Sort(new ImieComparer()); 
        }

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public Dowodca Dowodca { get => dowodca; set => dowodca = value; }
        public List<Wojownik> Wojownicy { get => wojownicy; set => wojownicy = value; }
    }
}

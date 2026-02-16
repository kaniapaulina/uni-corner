using System.Text;

namespace OperatorSieci
{
    internal class Program
    {
        public enum EnumTaryfa 
                { 
                      taryfa1 = 1,
                      taryfa2 = 2,
                      taryfa3 = 4
                }

        static void Main(string[] args)
        {
            Console.WriteLine("Cwiczenia 5! - edycja wszystko w jednym pliku");

            Abonent a = new Abonent("Jan", "Kowalski", "123456789");
            Abonent b = new Abonent("Anna", "Nowak", "987654321");
            Abonent c = new Abonent("Piotr", "Zalewski", "555666777");
            a.Zadzwon(10, EnumTaryfa.taryfa1);
            a.Zadzwon(5, EnumTaryfa.taryfa2);
            a.Zadzwon(20, EnumTaryfa.taryfa3);
            b.Zadzwon(15, EnumTaryfa.taryfa3);
            b.Zadzwon(25, EnumTaryfa.taryfa2);
            c.Zadzwon(30, EnumTaryfa.taryfa1);

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);

            Console.WriteLine("\n ========================= \n");

            OperatorSieci operatorSieci = new OperatorSieci("SuperOperator");
            operatorSieci.DodajAbonenta(a);
            operatorSieci.DodajAbonenta(b);
            operatorSieci.DodajAbonenta(c);
            Console.WriteLine(operatorSieci);

            Abonent d = operatorSieci.WyszukajAbonenta("555666777");
            Console.WriteLine($"Wyszukany abonent: {d.PodajDane()}");

        }
        // interfejs IAbonent ktory definiuje metody dla klasy Abonent
        public interface IAbonent
        {
            public string PodajDane();
            public void Zadzwon(double czas, EnumTaryfa taryfa);
            public (int, decimal) PodsumowanieRozmow();
        }

        // Polaczenie klasy reprezentującej pojedyncze połączenie telefoniczne
        public class Polaczenie
        {
            double czasTrwania;
            decimal oplata;
            bool wykonane;

            public Polaczenie(double czasTrwania, decimal oplata, bool wykonane)
            {
                this.czasTrwania = czasTrwania;
                this.oplata = oplata;
                this.wykonane = wykonane;
            }

            public double CzasTrwania { get => czasTrwania; set => czasTrwania = value; }
            public decimal Oplata { get => oplata; set => oplata = value; }
            public bool Wykonane { get => wykonane; set => wykonane = value; }
        }

        // Klasa Abonent implementująca interfejs IAbonent i przedstawiająca abonenta sieci telefonicznej
        public class Abonent:IAbonent
        {
            string imie;
            string nazwisko;
            string numerTelefonu;
            List<Polaczenie> polaczenia = new List<Polaczenie>();

            public Abonent(string imie, string nazwisko, string numerTelefonu)
            {
                this.imie = imie;
                this.nazwisko = nazwisko;
                this.numerTelefonu = numerTelefonu;
            }

            public override string ToString()
            {

                return $"{imie} {nazwisko} {{{numerTelefonu.Substring(0,3)}-{numerTelefonu.Substring(3,3)}-{numerTelefonu.Substring(6,3)}}}, [liczba prób: {polaczenia.Count()}, liczba rozmów: {PodsumowanieRozmow().Item1}, opłata: {PodsumowanieRozmow().Item2:F2}zł]";
            }

            public string PodajDane()
            {
                return $"{imie} {nazwisko}";
            }

            public void Zadzwon(double czas, EnumTaryfa taryfa)
            {
                Random rand = new Random();
                double los = rand.NextDouble();
                if (los < 0.3)
                {
                    Polaczenie nieudane = new Polaczenie(0, 0, false);
                    polaczenia.Add(nieudane);
                }
                else
                {
                    Polaczenie udane = new Polaczenie(czas, (decimal)czas * (int)taryfa, true);
                    polaczenia.Add(udane);
                }
            }

            // krotka to dwuelementowa struktura przechowujaca liczbe rozmow i laczna oplate
            public (int, decimal) PodsumowanieRozmow()
            {
                List<Polaczenie> udane = polaczenia.FindAll(p => p.Wykonane);
                int i = udane.Count();
                decimal suma = udane.Sum(p => p.Oplata);
                return (i, suma);
            }

            public string Imie { get => imie; set => imie = value; }
            public string Nazwisko { get => nazwisko; set => nazwisko = value; }
            public string NumerTelefonu { get => numerTelefonu; set => numerTelefonu = value; }
            internal List<Polaczenie> Polaczenia { get => polaczenia; set => polaczenia = value; }
        }

        // OperatorSieci klasy reprezentującej operatora sieci telefonicznej, która zarządza abonentami z funkcjami dodawania, wyszukiwania i obliczania zysków
        public class OperatorSieci
        {
            string nazwa;
            Dictionary<string, Abonent> abonenci = new Dictionary<string, Abonent>();

            public OperatorSieci(string nazwa)
            {
                this.nazwa = nazwa;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Operator: {nazwa} [sumaryczny zysk: {Zysk()}]");
                foreach (KeyValuePair<string, Abonent> kvp in abonenci)
                {
                    sb.AppendLine($"{kvp.Key}: {kvp.Value}");
                }
                return sb.ToString();
            }

            public void DodajAbonenta(Abonent a)
            {
                //abonenci[a.NumerTelefonu] = a;
                abonenci.Add(a.NumerTelefonu, a);
            }

            public int Zysk()
            {
                int suma = 0;
                foreach (KeyValuePair<string, Abonent> kvp in abonenci)
                {
                    suma += (int)kvp.Value.PodsumowanieRozmow().Item2;
                }
                return suma;
            }

            public Abonent WyszukajAbonenta(string numerTelefonu)
            {
                /*
                if (abonenci.ContainsKey(numerTelefonu))
                {
                    return abonenci[numerTelefonu];
                }
                else
                {
                    return null;
                }
                */
                Abonent a = new Abonent("??", "??", "??");
                return abonenci.GetValueOrDefault(numerTelefonu, a);
            }

            public string Nazwa { get => nazwa; set => nazwa = value; }
            internal Dictionary<string, Abonent> Abonenci { get => abonenci; set => abonenci = value; }
        }


    }
}











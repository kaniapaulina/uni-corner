using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoria.Labs
{
    internal class Lab3
    {
        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ĆWICZENIA 3 - DZIEDZICZENIE ===");
                Console.WriteLine("1. Zadanie 1 - Członek i Kierownik");
                Console.WriteLine("2. Zadanie 2 i 3 - Test klasy agregującej Zespół");
                Console.WriteLine("3. Ćwiczenia 4 - Paczkomat..");
                Console.WriteLine("0. Powrót do menu głównego");
                Console.Write("Wybierz zadanie: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Zadanie1();
                        break;
                    case "2":
                        Zadanie2();
                        break;
                    case "3":
                        Zadanie3();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Nie takie są cyferki do zadań");
                        break;
                }

                Console.WriteLine("\n...");
                Console.ReadKey();
            }
        }

        // ZADANIE 1 - Testy nowych klas dziedziczących po Osoba
        static void Zadanie1()
        {
            Console.WriteLine("\n=== ZADANIE 1 - CZŁONEK I KIEROWNIK ===");

            // Test 
            Console.WriteLine("\n--- Test Członka i Kierownika---");

            CzlonekZespolu cz1 = new CzlonekZespolu();
            Console.WriteLine($"Test członka - pusty: {cz1}");

            CzlonekZespolu cz2 = new CzlonekZespolu("Beata", "Nowak", "1992-10-22", "92102201347", EnumPlec.K, "2020-01-01", "projektant", true);
            Console.WriteLine($"Test członka: {cz2}");
            CzlonekZespolu cz3 = new CzlonekZespolu("Jan", "Jankowski", "1992-03-15", "92031507772", EnumPlec.M, "2015-05-01", "programista", false);
            Console.WriteLine($"Test członka: {cz3}");

            KierownikZespolu k1 = new KierownikZespolu("Adam", "Kowalski", "1990-07-01", "90070100211", EnumPlec.M, 5, 705324001);
            Console.WriteLine($"Test kierownika: {k1}");
        }
        static void Zadanie2()
        {
            CzlonekZespolu cz2 = new CzlonekZespolu("Beata", "Nowak", "1992-10-22", "92102201347", EnumPlec.K, "2020-01-01", "projektant", true);
            CzlonekZespolu cz3 = new CzlonekZespolu("Jan", "Jankowski", "1992-03-15", "92031507772", EnumPlec.M, "2015-05-01", "programista", false);
            KierownikZespolu k1 = new KierownikZespolu("Adam", "Kowalski", "1990-07-01", "90070100211", EnumPlec.M, 5, 705324001);

            Console.WriteLine("\n=== ZADANIE 2 I 3 - TEST KLASY ZESPÓŁ ===");
            Zespol z1 = new Zespol("Zespół Informatyków", k1);
            z1.DodajCzlonka(cz2);
            z1.DodajCzlonka(cz3);
            Console.WriteLine(z1);
        }

        static void Zadanie3()
        {
            Console.WriteLine("\n ===== moje paczki =====");
            Paczka p1 = new Paczka("nadawcaA", 2);
            var p2 = new Paczka("nadawcaB", 3);
            Paczka p3 = new Paczka("nadawcaC", 4);
            Paczka p4 = new Paczka("nadawcaD", 5);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);
            Console.WriteLine(p4);

            PaczkaPolecona pp1 = new PaczkaPolecona("nadawcaE", 6);
            var pp2 = new PaczkaPolecona("nadawcaF", 7);
            Console.WriteLine(pp1);
            Console.WriteLine(pp2);

            Console.WriteLine("\n ===== PIERWSZY MAGAZYN =====");
            MagazynLIFO mStos = new MagazynLIFO("Muj stośik");
            mStos.Umiesc(p1);
            mStos.Umiesc(p2);
            mStos.Umiesc(p3);
            mStos.Umiesc(p4);
            mStos.Umiesc(pp1);
            mStos.Umiesc(pp2);
            Console.WriteLine(mStos);

            Console.WriteLine("=== pobieranie ===");
            Paczka paczka1 = mStos.Pobierz();
            Console.WriteLine(paczka1);
            Console.WriteLine("\n");
            Console.WriteLine(mStos);

            Console.WriteLine("=== sprawdzanie co na szczycie ===");
            Paczka paczka2 = mStos.PodajBiezacy();
            Console.WriteLine(paczka2);
            Console.WriteLine("\n");
            Console.WriteLine(mStos);

            Console.WriteLine("=== sprawdzanie ilosci ===");
            Console.WriteLine($"Count: {mStos.PodajIlosc()}");
            Console.WriteLine($"Parametr ilosc {mStos.IloscPaczek}");

            Console.WriteLine("=== czyszczenie ===");
            mStos.Wyczysc();
            Console.WriteLine(mStos);
        }
    }
}

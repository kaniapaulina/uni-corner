using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoria.Labs
{
    // Enumeracja dla płci
    public enum EnumPlec { K = 0, M = 1 }
    public static class Lab2
    {
        //w program.cs wywoluje polecenia z poczególnych zajęć przez Run(), nie pelni innej funkcji oprocz uporządkowania poprzednych zajec w jednym projektcie
        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ĆWICZENIA 2 - KLASA OSOBA ===");
                Console.WriteLine("1. Zadanie 1-5 - Testy");
                Console.WriteLine("2. Zadanie 6 - Przykładowe osoby");
                Console.WriteLine("3. Zadanie 7 - ToString() z wiekiem");
                Console.WriteLine("0. Powrót do menu głównego");
                Console.Write("Wybierz zadanie: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": 
                        Zadanie1_5(); 
                        break;
                    case "2": 
                        Zadanie6(); 
                        break;
                    case "3": 
                        Zadanie7(); 
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

        // ZADANIE 1-5 - Test klasy Osoba
        static void Zadanie1_5()
        {
            Console.WriteLine("\n=== ZADANIE 1-5 - TEST KLASY OSOBA ===");

            // Test 
            Console.WriteLine("\n--- Test konstruktorow z zajec---");

            Osoba os1 = new Osoba();
            Console.WriteLine($"Test (pusty): {os1}");

            Osoba os2 = new Osoba("Anna", "Kowalska", EnumPlec.K);
            Console.WriteLine($"Test z imieniem i nazwiskiem: {os2}");

            Osoba os3 = new Osoba("Jan", "Nowak", "1990-05-15", "90051512345", EnumPlec.M);
            Console.WriteLine($"Test z datą urodzenia: {os3}");

            Osoba os4 = new Osoba("Maria", "Wiśniewska", "ul. Kwiatowa 10", "Warszawa", 00100, "1985-08-20", "85082054321", EnumPlec.K);
            Console.WriteLine($"Osoba z pełnym adresem: {os4}");

            // Test wieku pls dzialaj
            Console.WriteLine("\n--- Test metody Wiek() ---");
            Osoba testWiek = new Osoba("Test", "Wiekowy", "2000-01-01", "00010112345", EnumPlec.M);
            Console.WriteLine($"Wiek osoby: {testWiek.Wiek()} lat");
        }

        // ZADANIE 6 - Przykładowe osoby
        static void Zadanie6()
        {
            Console.WriteLine("\n=== ZADANIE 6 - PRZYKŁADOWE OSOBY ===");
            Osoba dżoana = new Osoba("Joanna", "Brodzik", EnumPlec.K);
            Osoba kazik = new Osoba("Kazimierz", "Jabłoński", "", "01123088332", EnumPlec.M);
            Osoba beata = new Osoba("Beata", "Nowak", "ul. Szeroka 21", "Kraków", 30345, "1992-10-22", "92102201347", EnumPlec.K);
            Osoba damiankantor = new Osoba("Damian", "Wolski", "", "90120399002", EnumPlec.M);

            Osoba jan = new Osoba("Jan", "Janowski", "ul. Wąska 102", "Warszawa", 22011, "1993-03-15", "92031507772", EnumPlec.M);

            // Wyświetlanie informacji
            Console.WriteLine("Przykładowe osoby:");
            Console.WriteLine(dżoana);
            Console.WriteLine(kazik);
            Console.WriteLine(beata);
            Console.WriteLine(damiankantor);
            Console.WriteLine(jan);
        }

        // ZADANIE 7 - ToString() z wiekiem
        static void Zadanie7()
        {
            Console.WriteLine("\n=== ZADANIE 7 - ToString() Z WIEKIEM ===");

            Osoba jo = new Osoba("Joanna", "Brodzik", EnumPlec.K);
            Osoba be = new Osoba("Beata", "Nowak", "ul. Szeroka 21", "Kraków", 30345, "1992-10-22", "92102201347", EnumPlec.K);
            Osoba da = new Osoba("Damian", "Wolski", "", "90120399002", EnumPlec.M);

            // osoba mloda zeby to currentyear nie wyrzucalo
            int currentYear = DateTime.Now.Year;
            Osoba ja = new Osoba("Jan", "Janowski", "ul. Wąska 102", "Warszawa", 22011, $"{currentYear - 22}-03-15", "00031507772", EnumPlec.M);

            Console.WriteLine("Osoby z informacją o wieku:");
            Console.WriteLine(jo.ToStringWithAge());
            Console.WriteLine(be.ToStringWithAge());
            Console.WriteLine(da.ToStringWithAge());
            Console.WriteLine(ja.ToStringWithAge());
        }
    
    }
}

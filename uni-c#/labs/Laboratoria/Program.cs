using Laboratoria.Labs;

namespace Laboratoria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ZAKRZÓWEK BASIURY <3 ===");
                Console.WriteLine("1. Ćwiczenia 1 - Zadania basicowe");
                Console.WriteLine("2. Ćwiczenia 2 - Klasa Osoba");
                Console.WriteLine("3. Ćwiczenia 3 - Dziedziczenie");
                Console.WriteLine("0. Wyjście");

                Console.Write("Wybierz: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Lab1.Run();
                        break;
                    case "2":
                        Lab2.Run();
                        break;
                    case "3":
                        Lab3.Run();
                        break;
                    case "0":
                        Console.WriteLine("Do zobaczenia!");
                        return;
                    default:
                        WaitForKey();
                        break;
                }
            }

            static void WaitForKey()
            {
                Console.WriteLine("\nNaciśnij coś pls");
                Console.ReadKey();
            }
        }
    }
}

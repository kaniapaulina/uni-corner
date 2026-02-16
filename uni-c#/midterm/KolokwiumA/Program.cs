namespace KolokwiumA
{
    public enum Rola
    {        
        Piechur=1,
        Łucznik=2,
        Jeździec=3
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kolokwium rozwiazywane z Werońskim");

            Console.WriteLine("\nZadanie 1");
            Mieszkaniec m1 = new Mieszkaniec();
            m1.Imie = "Leon";
            m1.Miasto = "Ateny";
            m1.Waga = 100;
            m1.Szybkosc = 8;
            Console.WriteLine(m1);

            
            Console.WriteLine("\nZadanie 2");
            Wojownik w1 = new Wojownik("Leon", "Ateny", 80, 10.0, Rola.Łucznik);
            Console.WriteLine(w1);

            Console.WriteLine("\nZadanie 3");
            Dowodca d1 = new Dowodca("Leonidas", "Ateny", 80, 10.0, "Wód");
            Console.WriteLine(d1);

            Console.WriteLine("\nZadanie 4:");
            Legion l1 = new Legion();
            l1.Dodaj(w1);
            Console.WriteLine(l1.Oddzial());
            Console.WriteLine(l1.MocOdzzialu());

        }
    }
}

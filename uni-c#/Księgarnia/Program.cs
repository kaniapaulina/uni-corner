namespace Księgarnia
{
    public enum EnumWydawcy { Helion, Miniatura, Marabut, Kwadratura, Rosikon, Prodoks, Springer }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cwiczenia 5 - zadanie domowe!\n");

            Ksiazka k1 = new Ksiazka("C# 12 i .NET 8 - przewodnik programisty", "2024-09-15", EnumWydawcy.Helion);
            Ksiazka k2 = new Ksiazka("Wprowadzenie do algorytmów", "2009/07/31", EnumWydawcy.Miniatura);
            Console.WriteLine(k1);
            Console.WriteLine(k2);

            Abonent a1 = new Abonent("Jan", "Kowalski", "123-456-789", "Warszawa");
            Abonent a2 = new Abonent("Anna", "Nowak", "987-654-321", "Kraków");
            Console.WriteLine(a1);
            Console.WriteLine(a2);

            KsiazkaTelefoniczna kt = new KsiazkaTelefoniczna("Moja Książka Telefoniczna", "2024-10-01", EnumWydawcy.Marabut);
            kt.DodajAbonenta(a1);
            kt.DodajAbonenta(a2);
            Console.WriteLine(kt);

        }
    }
}

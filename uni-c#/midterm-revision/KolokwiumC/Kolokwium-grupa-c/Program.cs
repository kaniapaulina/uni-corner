namespace Kolokwium_grupa_c
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kolokwium - Paulina Kania");

            // Zadanie 1 = Test 
            //Renifer r1 = new Renifer();
            //Console.WriteLine(r1);

            //Renifer r2 = new Renifer("Strzała", DateTime.Today, 150M);
            //Console.WriteLine(r2);

            ReniferPociagowy rp1 = new ReniferPociagowy("Rudolf", DateTime.Now, 150M, enumPozycja.przod);
            ReniferPociagowy rp2 = new ReniferPociagowy("Emilia", DateTime.Now, 110M, enumPozycja.tyl);
            Console.WriteLine(rp1);

            DowodcaOrszaku do1 = new DowodcaOrszaku("Misiu", DateTime.Now, 150M, 20f);
            Console.WriteLine(do1);

            Console.WriteLine("=========");
            Sanie s1 = new Sanie("Moje sanki", do1);
            s1.Zaprzegnij(rp1);
            s1.Zaprzegnij(rp2);
            Console.WriteLine(s1);

            Console.WriteLine("=========");
            s1.Sort();
            Console.WriteLine(s1);

            Console.WriteLine("=========");
            s1.SortAlfabetycznie();
            Console.WriteLine(s1);

            // wszytskie zadania zostaly wykonane -> zadanie 5 i 6 bez testów bo już sobie nie poradzilam :c

            Console.WriteLine("=========");
            Sanie.ZapiszSanieDlaMikolajaXMLDC("zaprzeg.xml", s1);
            Sanie s2 = Sanie.OdczytajXML("zaprzeg.xml");
            Console.WriteLine(s2);

        }
    }
}

namespace OsobaZespol
{
    // Definicja wyliczenia EnumPlec - zadeklarowana w głownym pliku programu jako public by była dostępna w innych plikach
    public enum EnumPlec { K = 0, M = 1 };
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("To ćwiczenia: 2, 3 i 7");

            // test dla osoby z błędnym PESELem
            //Osoba osP = new Osoba("Kazimierz", "Jabłoński", "028332", EnumPlec.M);
            //Console.WriteLine(osP);

            /* Cwiczenia 2 - testy konstruktorów klasy Osoba
            ZMIENIONA KLASA NA ABSTRAKCYJNĄ - NIE MOŻNA JUŻ UTWORZYĆ OBIEKTU TEJ KLASY
            Osoba os1 = new Osoba("Joanna", "Brodzik", EnumPlec.K);
            Osoba os2 = new Osoba("Beata", "Nowak", "Szeroka 21", "Kraków", 30345, "1992-10-22", "99041398765", EnumPlec.K);
            Osoba os3 = new Osoba("Damian", "Wolski", "90120399002", EnumPlec.M);
            Osoba os4 = new Osoba("Jan", "Janowski", "Wąska 102", "Warszawa", 22011, "2003-03-15", "92031507772", EnumPlec.K);

            Console.WriteLine(os1);
            Console.WriteLine(os2);
            Console.WriteLine(os3);
            Console.WriteLine(os4);

            Witold Adamski (A) 22.10.1992 92102266738 M sekretarz (01-sty-2020)
            Jan Janowski 15.03.1992 92031532652 M programista (01-sty-2020)
            Jan But (A) 16.05.1992 92051613915 M programista (01-cze-2019)
            Beata Nowak (A) 22.11.1993 93112225023 K projektant (01-sty-2020)
            Anna Mysza (A) 22.07.1991 91072235964 K projektant (31-lip-2019) 

            */

            CzlonekZespolu cz1 = new CzlonekZespolu("Beata", "Nowak", "1992-10-22", "0099041398765", EnumPlec.K, "2020-05-01", "Projektant", true);
            CzlonekZespolu cz2 = new CzlonekZespolu("Jan", "Janowski", "2003-03-15", "92031507772", EnumPlec.M, "2015-03-01", "Programista", false);
            CzlonekZespolu cz3 = new CzlonekZespolu("Anna", "Mysza", "1991-07-22", "91072235964", EnumPlec.K, "2019-07-31", "Projektant", true);
            CzlonekZespolu cz4 = new CzlonekZespolu("Witold", "Adamski", "1992-10-22", "92102266738", EnumPlec.M, "2020-01-01", "Sekretarz", false);
            CzlonekZespolu cz5 = new CzlonekZespolu("Jan", "But", "1992-05-16", "92051613915", EnumPlec.M, "2019-06-01", "Programista", true);

            // Adam Kowalski 01.07.1990  90070142412 M 5 (tel. 705-324-001)
            KierownikZespolu k1 = new KierownikZespolu("Adam", "Kowalski", "01.07.1990", "90070142412", EnumPlec.M, 5, 405324001);


            Console.WriteLine(cz1);
            Console.WriteLine(cz2);
            Console.WriteLine(k1);


            Console.WriteLine("======== Testowanie Zespołu\n");
            Zespol z1 = new Zespol("Grupa IT", k1);
            z1.DodajCzlonkaZespolu(cz4);
            z1.DodajCzlonkaZespolu(cz1);
            z1.DodajCzlonkaZespolu(cz3);
            z1.DodajCzlonkaZespolu(cz2);
            z1.DodajCzlonkaZespolu(cz5);
            Console.WriteLine(z1);


            Console.WriteLine("\n======== Sortowanie członków zespołu wg nazwisk:");
            z1.Sortuj();
            Console.WriteLine(z1);

            Console.WriteLine("\n======== Wyszukiwanie nieaktywnych członków zespołu:");
            var nieaktywni = z1.WyszukajNieaktywnychCzlonkow();
            foreach (var czl in nieaktywni)
            {
                Console.WriteLine(czl);
            }
            Console.WriteLine("\n ======== Kopiowanie zespołu:");
            Zespol z2 = (Zespol)z1.Clone();
            Console.WriteLine(z2);

            Console.WriteLine("\n ======= Głęboka kopia zespołu:");
            Zespol z3 = z1.DeepCopy();
            Console.WriteLine(z3);

            Console.WriteLine("\n ======= Zapisywanie zespołu do pliku XML:");
            if (z1.ZapiszXML("zespol.xml")) { Console.WriteLine("Udalo sie!"); }

            Console.WriteLine("\n ======= Odczytywanie zespołu z pliku XML:");
            Zespol z4 = Zespol.OdczytajXML("zespol.xml");
            Console.WriteLine(z4);

        }
    }
}

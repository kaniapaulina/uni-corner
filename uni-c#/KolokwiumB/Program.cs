namespace KolokwiumB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kolokwium B");

            Abonent a1 = new Abonent("Jan", "Kowalski", "89021299313");
            Abonent a2 = new Abonent("Damian", "Bednarski", "02711232123");
            Console.WriteLine(a1);

            //Telefon t1 = new Telefon("345111223", a1);
            //t1.RejestracjaRozmowy(3);
            //t1.RejestracjaRozmowy(3);
            //Console.WriteLine(t1);

            TelefonStacjonarny ts1 = new TelefonStacjonarny("440511889", a2, true);
            ts1.RejestracjaRozmowy(33);
            ts1.RejestracjaRozmowy(65);
            Console.WriteLine(ts1);

            TelefonKomórkowy tk1 = new TelefonKomórkowy("440511889", a2, EnumOperatorSieci.TMobile);
            Console.WriteLine(tk1);

            Firma f1 = new Firma("Dupa");
            f1.DodajTelefon(tk1);
            f1.DodajTelefon(ts1);
            Console.WriteLine(f1);

            Firma.ZapiszXML("f1.xml", f1);

            Firma f2 = Firma.OdczytajXML("f1.xml");

        }
    }
}

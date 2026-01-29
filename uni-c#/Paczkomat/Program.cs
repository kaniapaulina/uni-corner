namespace Paczkomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cwiczenia 4 - Paczkomat Ultra Sigma Outpost");
            Paczka p1 = new Paczka("Nadawca A", 4);
            Paczka p2 = new Paczka("Nadawca B", 3);
            Paczka p3 = new Paczka("Nadawca C", 5);
            PaczkaPolecona pp1 = new PaczkaPolecona("Nadawca D", 2);

            MagazynLIFO magazynLifo = new MagazynLIFO("Magazyn glowny");
            magazynLifo.Umiesc(p1);
            magazynLifo.Umiesc(p2);
            magazynLifo.Umiesc(p3);
            magazynLifo.Umiesc(pp1);

            Console.WriteLine("Zawartosc magazynu po dodaniu paczek:");
            Console.WriteLine(magazynLifo);
            Console.WriteLine($"Ilosc paczek w magazynie: {magazynLifo.PodajIlosc()}\n");

            Paczka pobranaPaczka = magazynLifo.Pobierz();
            Console.WriteLine($"Pobrano paczke: {pobranaPaczka}");

            int ilosc = magazynLifo.PodajIlosc();
            Console.WriteLine($"Ilosc paczek w magazynie po pobraniu: {ilosc}\n");

            magazynLifo.Wyczysc();
            Console.WriteLine($"Zawartosc magazynu po wyczyszczeniu: {magazynLifo}");



            MagazynFIFO magazynFifo = new MagazynFIFO("Magazyn FIFO");
            magazynFifo.Umiesc(p1);
            magazynFifo.Umiesc(p2);
            magazynFifo.Umiesc(p3);
            magazynFifo.Umiesc(pp1);
            Console.WriteLine("Zawartosc magazynu FIFO po dodaniu paczek:");
            Console.WriteLine(magazynFifo);
            Paczka pobranaPaczkaFifo = magazynFifo.Pobierz();
            Console.WriteLine($"Pobrano paczke z magazynu FIFO: {pobranaPaczkaFifo}");
            magazynFifo.Wyczysc();
            Console.WriteLine($"Zawartosc magazynu FIFO po wyczyszczeniu: {magazynFifo}");

        }
    }
}

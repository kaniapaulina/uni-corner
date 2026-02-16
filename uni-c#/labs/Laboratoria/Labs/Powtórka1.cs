using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoria.Labs
{
    // ========== CZĘŚĆ 1: DZIEDZICZENIE ==========

    // KLASA BAZOWA (rodzic)
    // To jest najważniejsza klasa, od której wszystko dziedziczy
    public class Pojazd
    {
        // Pola protected - widoczne w klasie i w klasach dziedziczących
        protected string marka;
        protected int rokProdukcji;

        // Konstruktor bazowy
        public Pojazd()
        {
            marka = "Nieznana";
            rokProdukcji = 2000;
        }

        public Pojazd(string marka, int rok)
        {
            this.marka = marka;
            this.rokProdukcji = rok;
        }

        // Metoda VIRTUAL - może być nadpisana w klasach potomnych
        public virtual string Informacje()
        {
            return $"Pojazd: {marka}, rok: {rokProdukcji}";
        }

        // Metoda zwykła - NIE może być nadpisana
        public string PodajMarke()
        {
            return marka;
        }
    }

    // KLASA POCHODNA (dziecko) - dziedziczy po Pojazd
    // Słowo kluczowe : Pojazd oznacza dziedziczenie
    public class Samochod : Pojazd
    {
        private int liczbaDrzwi;

        // Konstruktor - używa base() do wywołania konstruktora rodzica
        public Samochod() : base()
        {
            liczbaDrzwi = 4;
        }

        public Samochod(string marka, int rok, int drzwi) : base(marka, rok)
        {
            this.liczbaDrzwi = drzwi;
        }

        // OVERRIDE - nadpisujemy metodę z klasy bazowej
        public override string Informacje()
        {
            // base.Informacje() wywołuje metodę z klasy rodzica
            return base.Informacje() + $", drzwi: {liczbaDrzwi}";
        }

        // Własna metoda tylko w Samochod
        public void Jedz()
        {
            Console.WriteLine($"{marka} jedzie!");
        }
    }

    // KOLEJNA KLASA POCHODNA
    public class Motocykl : Pojazd
    {
        private bool maKoszyk;

        public Motocykl(string marka, int rok, bool koszyk) : base(marka, rok)
        {
            this.maKoszyk = koszyk;
        }

        public override string Informacje()
        {
            string kosz = maKoszyk ? "z koszykiem" : "bez koszyka";
            return base.Informacje() + $", {kosz}";
        }
    }

    // ========== CZĘŚĆ 2: INTERFEJSY ==========

    // INTERFEJS - kontrakt, który mówi "kto mnie implementuje, MUSI mieć te metody"
    public interface ISprawdzalny
    {
        bool CzyDostepny();
        void Zablokuj();
        void Odblokuj();
    }

    // Klasa implementująca interfejs - MUSI mieć wszystkie metody z interfejsu
    public class ProduktSklepowy : ISprawdzalny
    {
        private string nazwa;
        private bool dostepny;

        public ProduktSklepowy(string nazwa)
        {
            this.nazwa = nazwa;
            this.dostepny = true;
        }

        // Implementacja metod z interfejsu
        public bool CzyDostepny()
        {
            return dostepny;
        }

        public void Zablokuj()
        {
            dostepny = false;
            Console.WriteLine($"{nazwa} został zablokowany");
        }

        public void Odblokuj()
        {
            dostepny = true;
            Console.WriteLine($"{nazwa} został odblokowany");
        }

        public override string ToString()
        {
            return $"{nazwa} - {(dostepny ? "DOSTĘPNY" : "NIEDOSTĘPNY")}";
        }
    }

    // ========== CZĘŚĆ 3: STRUKTURY DANYCH ==========

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║  KOLOKWIUM - WSZYSTKO W JEDNYM MIEJSCU ║");
            Console.WriteLine("╔════════════════════════════════════════╗\n");

            // ===== TEST DZIEDZICZENIA =====
            TestDziedziczenia();

            // ===== TEST INTERFEJSÓW =====
            TestInterfejsow();

            // ===== STRUKTURY DANYCH =====
            TestLista();
            TestStos();
            TestKolejka();
            TestArrayList();

            Console.WriteLine("\n=== KONIEC PROGRAMU ===");
            Console.ReadKey();
        }

        // ========== TEST 1: DZIEDZICZENIE ==========
        static void TestDziedziczenia()
        {
            Console.WriteLine("\n╔═══════════════════════════════════╗");
            Console.WriteLine("║  TEST 1: DZIEDZICZENIE            ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            // Tworzymy obiekty
            Pojazd p1 = new Pojazd("Generyczny", 2020);
            Samochod s1 = new Samochod("BMW", 2022, 5);
            Motocykl m1 = new Motocykl("Harley", 2021, true);

            // POLIMORFIZM - jeden typ (Pojazd) może przechowywać różne obiekty
            Pojazd[] pojazdy = { p1, s1, m1 };

            Console.WriteLine("\n--- Wszystkie pojazdy (polimorfizm): ---");
            foreach (Pojazd p in pojazdy)
            {
                // Każdy wywołuje SWOJĄ wersję Informacje()
                Console.WriteLine(p.Informacje());
            }

            // Dostęp do metody tylko w Samochod
            Console.WriteLine("\n--- Metoda specyficzna dla Samochod: ---");
            s1.Jedz();

            Console.WriteLine("\n✓ Dziedziczenie działa!");
        }

        // ========== TEST 2: INTERFEJSY ==========
        static void TestInterfejsow()
        {
            Console.WriteLine("\n╔═══════════════════════════════════╗");
            Console.WriteLine("║  TEST 2: INTERFEJSY               ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            ProduktSklepowy produkt = new ProduktSklepowy("Laptop HP");

            Console.WriteLine($"\nProdukt: {produkt}");
            Console.WriteLine($"Czy dostępny? {produkt.CzyDostepny()}");

            produkt.Zablokuj();
            Console.WriteLine($"Po zablokowaniu: {produkt}");

            produkt.Odblokuj();
            Console.WriteLine($"Po odblokowaniu: {produkt}");

            Console.WriteLine("\n✓ Interfejsy działają!");
        }

        // ========== TEST 3: LISTA (List<T>) ==========
        static void TestLista()
        {
            Console.WriteLine("\n╔═══════════════════════════════════╗");
            Console.WriteLine("║  TEST 3: LISTA List<T>            ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            // LISTA - dynamiczna tablica, można dodawać/usuwać elementy
            // Najbardziej używana struktura!
            List<string> studenci = new List<string>();

            // DODAWANIE elementów
            Console.WriteLine("\n--- Dodawanie do listy: ---");
            studenci.Add("Anna");
            studenci.Add("Bartek");
            studenci.Add("Czesław");
            studenci.Add("Damian");
            Console.WriteLine($"Dodano 4 studentów, ilość: {studenci.Count}");

            // WYŚWIETLANIE
            Console.WriteLine("\n--- Wyświetlanie listy: ---");
            for (int i = 0; i < studenci.Count; i++)
            {
                Console.WriteLine($"{i}. {studenci[i]}");
            }

            // WSTAWIANIE na konkretną pozycję
            Console.WriteLine("\n--- Insert (wstawienie na pozycję 1): ---");
            studenci.Insert(1, "Zosia");
            foreach (string s in studenci)
            {
                Console.WriteLine($"- {s}");
            }

            // USUWANIE
            Console.WriteLine("\n--- Remove (usunięcie Bartka): ---");
            studenci.Remove("Bartek");
            studenci.ForEach(s => Console.WriteLine($"- {s}"));

            // USUWANIE po indeksie
            Console.WriteLine("\n--- RemoveAt (usunięcie indeksu 0): ---");
            studenci.RemoveAt(0);
            studenci.ForEach(s => Console.WriteLine($"- {s}"));

            // SPRAWDZANIE czy element istnieje
            Console.WriteLine("\n--- Contains (czy jest Czesław?): ---");
            bool czyJest = studenci.Contains("Czesław");
            Console.WriteLine($"Czy jest Czesław? {czyJest}");

            // SORTOWANIE
            Console.WriteLine("\n--- Sort (sortowanie alfabetyczne): ---");
            studenci.Sort();
            studenci.ForEach(s => Console.WriteLine($"- {s}"));

            // CZYSZCZENIE
            Console.WriteLine("\n--- Clear (czyszczenie całej listy): ---");
            studenci.Clear();
            Console.WriteLine($"Ilość po wyczyszczeniu: {studenci.Count}");

            Console.WriteLine("\n✓ Lista kompletna!");
        }

        // ========== TEST 4: STOS (Stack<T>) ==========
        static void TestStos()
        {
            Console.WriteLine("\n╔═══════════════════════════════════╗");
            Console.WriteLine("║  TEST 4: STOS Stack<T> - LIFO    ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            // STOS - Last In, First Out (ostatni wchodzi, pierwszy wychodzi)
            // Jak stos talerzy - bierzesz od góry!
            Stack<int> stos = new Stack<int>();

            // PUSH - dodawanie na szczyt
            Console.WriteLine("\n--- Push (dodawanie na szczyt): ---");
            stos.Push(10);
            Console.WriteLine("Dodano: 10");
            stos.Push(20);
            Console.WriteLine("Dodano: 20");
            stos.Push(30);
            Console.WriteLine("Dodano: 30");
            stos.Push(40);
            Console.WriteLine("Dodano: 40");

            Console.WriteLine($"Ilość elementów: {stos.Count}");

            // Wyświetlanie stosu (od góry do dołu)
            Console.WriteLine("\n--- Zawartość stosu (od góry): ---");
            foreach (int liczba in stos)
            {
                Console.WriteLine($"[{liczba}]");
            }

            // PEEK - podgląd szczytu (NIE usuwa!)
            Console.WriteLine("\n--- Peek (podgląd szczytu): ---");
            int szczyt = stos.Peek();
            Console.WriteLine($"Na szczycie jest: {szczyt}");
            Console.WriteLine($"Ilość NIE zmieniła się: {stos.Count}");

            // POP - zdejmowanie ze szczytu (USUWA!)
            Console.WriteLine("\n--- Pop (zdejmowanie ze szczytu): ---");
            int zdjety1 = stos.Pop();
            Console.WriteLine($"Zdjęto: {zdjety1}");
            int zdjety2 = stos.Pop();
            Console.WriteLine($"Zdjęto: {zdjety2}");

            Console.WriteLine($"Pozostało elementów: {stos.Count}");

            Console.WriteLine("\n--- Pozostała zawartość: ---");
            foreach (int liczba in stos)
            {
                Console.WriteLine($"[{liczba}]");
            }

            // CLEAR - czyszczenie
            Console.WriteLine("\n--- Clear (czyszczenie): ---");
            stos.Clear();
            Console.WriteLine($"Ilość po wyczyszczeniu: {stos.Count}");

            Console.WriteLine("\n✓ Stos kompletny!");
            Console.WriteLine("PAMIĘTAJ: LIFO = Last In, First Out");
        }

        // ========== TEST 5: KOLEJKA (Queue<T>) ==========
        static void TestKolejka()
        {
            Console.WriteLine("\n╔═══════════════════════════════════╗");
            Console.WriteLine("║  TEST 5: KOLEJKA Queue<T> - FIFO ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            // KOLEJKA - First In, First Out (pierwszy wchodzi, pierwszy wychodzi)
            // Jak kolejka w sklepie - kto pierwszy przyszedł, ten pierwszy wychodzi!
            Queue<string> kolejka = new Queue<string>();

            // ENQUEUE - dodawanie na koniec kolejki
            Console.WriteLine("\n--- Enqueue (dodawanie do kolejki): ---");
            kolejka.Enqueue("Klient 1");
            Console.WriteLine("Dodano: Klient 1");
            kolejka.Enqueue("Klient 2");
            Console.WriteLine("Dodano: Klient 2");
            kolejka.Enqueue("Klient 3");
            Console.WriteLine("Dodano: Klient 3");
            kolejka.Enqueue("Klient 4");
            Console.WriteLine("Dodano: Klient 4");

            Console.WriteLine($"Osób w kolejce: {kolejka.Count}");

            // Wyświetlanie kolejki
            Console.WriteLine("\n--- Zawartość kolejki (od początku): ---");
            foreach (string klient in kolejka)
            {
                Console.WriteLine($"→ {klient}");
            }

            // PEEK - podgląd początku (NIE usuwa!)
            Console.WriteLine("\n--- Peek (kto jest pierwszy?): ---");
            string pierwszy = kolejka.Peek();
            Console.WriteLine($"Pierwszy w kolejce: {pierwszy}");
            Console.WriteLine($"Ilość NIE zmieniła się: {kolejka.Count}");

            // DEQUEUE - obsłużenie pierwszego klienta (USUWA!)
            Console.WriteLine("\n--- Dequeue (obsługa klientów): ---");
            string obsluzony1 = kolejka.Dequeue();
            Console.WriteLine($"Obsłużono: {obsluzony1}");
            string obsluzony2 = kolejka.Dequeue();
            Console.WriteLine($"Obsłużono: {obsluzony2}");

            Console.WriteLine($"Pozostało w kolejce: {kolejka.Count}");

            Console.WriteLine("\n--- Pozostali w kolejce: ---");
            foreach (string klient in kolejka)
            {
                Console.WriteLine($"→ {klient}");
            }

            // CLEAR - czyszczenie
            Console.WriteLine("\n--- Clear (zamknięcie punktu obsługi): ---");
            kolejka.Clear();
            Console.WriteLine($"Ilość po wyczyszczeniu: {kolejka.Count}");

            Console.WriteLine("\n✓ Kolejka kompletna!");
            Console.WriteLine("PAMIĘTAJ: FIFO = First In, First Out");
        }

        // ========== TEST 6: ARRAYLIST ==========
        static void TestArrayList()
        {
            Console.WriteLine("\n╔═══════════════════════════════════╗");
            Console.WriteLine("║  TEST 6: ARRAYLIST                ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            // ARRAYLIST - stara struktura, może przechowywać RÓŻNE typy
            // Dziś rzadko używana, lepiej List<T>
            ArrayList lista = new ArrayList();

            // Można dodawać różne typy!
            Console.WriteLine("\n--- Add (dodawanie różnych typów): ---");
            lista.Add(123);                    // int
            lista.Add("Tekst");                // string
            lista.Add(45.67);                  // double
            lista.Add(true);                   // bool
            lista.Add(new DateTime(2024, 1, 1)); // DateTime

            Console.WriteLine($"Dodano {lista.Count} elementów różnych typów");

            // Wyświetlanie
            Console.WriteLine("\n--- Zawartość ArrayList: ---");
            for (int i = 0; i < lista.Count; i++)
            {
                // GetType() pokazuje typ elementu
                Console.WriteLine($"{i}. {lista[i]} (typ: {lista[i].GetType().Name})");
            }

            // INSERT - wstawianie
            Console.WriteLine("\n--- Insert (wstawienie na pozycję 2): ---");
            lista.Insert(2, "NOWY ELEMENT");
            foreach (object element in lista)
            {
                Console.WriteLine($"- {element}");
            }

            // REMOVE - usuwanie
            Console.WriteLine("\n--- Remove (usunięcie stringa 'Tekst'): ---");
            lista.Remove("Tekst");
            foreach (object element in lista)
            {
                Console.WriteLine($"- {element}");
            }

            // CONTAINS - sprawdzanie
            Console.WriteLine("\n--- Contains (czy jest liczba 123?): ---");
            bool zawiera = lista.Contains(123);
            Console.WriteLine($"Czy zawiera 123? {zawiera}");

            // SORT - sortowanie (jeśli elementy tego samego typu)
            Console.WriteLine("\n--- Próba sortowania mieszanych typów: ---");
            try
            {
                lista.Sort(); // To rzuci wyjątek bo mamy różne typy!
            }
            catch (Exception e)
            {
                Console.WriteLine($"BŁĄD: {e.Message}");
                Console.WriteLine("Nie można sortować różnych typów!");
            }

            // ArrayList z jednym typem
            Console.WriteLine("\n--- ArrayList z samymi liczbami: ---");
            ArrayList liczby = new ArrayList { 50, 20, 80, 10, 40 };
            Console.WriteLine("Przed sortowaniem:");
            foreach (int l in liczby)
            {
                Console.Write($"{l} ");
            }

            liczby.Sort();
            Console.WriteLine("\nPo sortowaniu:");
            foreach (int l in liczby)
            {
                Console.Write($"{l} ");
            }
            Console.WriteLine();

            // CLEAR
            Console.WriteLine("\n--- Clear: ---");
            lista.Clear();
            Console.WriteLine($"Ilość po wyczyszczeniu: {lista.Count}");

            Console.WriteLine("\n✓ ArrayList kompletny!");
            Console.WriteLine("UWAGA: Dziś lepiej używać List<T> zamiast ArrayList!");
        }
    }
}

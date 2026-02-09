# Programowanie Obiektowe - C#

---

# Podstawy C# i .NET

## Common Language Runtime (CLR)

**CLR** to środowisko wykonawcze programów .NET - wirtualna maszyna odpowiedzialna za:

- Zarządzanie pamięcią (Garbage Collection)
- Kompilację kodu CIL (Common Intermediate Language) do kodu maszynowego
- Obsługę wyjątków
- Bezpieczeństwo typów

### Proces wykonania programu C#

```
Kod C# → Kompilator C# → CIL (język pośredni) → CLR → Kod maszynowy
```

**Assembly** to skompilowana jednostka kodu:

- `.exe` - aplikacja wykonywalna
- `.dll` - biblioteka dynamiczna

Zawiera:

- Metadane (opis typów, metod, właściwości)
- CIL (kod pośredni)
- Manifest (informacje o zależnościach)

## Przestrzenie nazw (Namespaces)

Organizują kod i zapobiegają konfliktom nazw:

```csharp
using System;              // Podstawowe typy i operacje
using System.Collections.Generic;  // Kolekcje generyczne
using System.Linq;         // LINQ
using System.Text;         // Operacje na tekstach
using System.Xml.Serialization; // Serializacja XML
```

## Konsola - podstawowe operacje

```csharp
// Wczytywanie danych
string input = Console.ReadLine();  // Cały wiersz jako string
ConsoleKeyInfo key = Console.ReadKey();  // Pojedynczy znak

// Parsowanie (konwersja string → liczba)
if (int.TryParse(input, out int liczba))
{
    Console.WriteLine($"Liczba: {liczba}");
}
else
{
    Console.WriteLine("Niepoprawny format!");
}

// Wypisywanie z formatowaniem
Console.Write("Bez nowej linii");
Console.WriteLine("Z nową linią");

// Interpolacja stringów
int x = 10;
Console.WriteLine($"Wartość x = {x}");  // Wartość x = 10
Console.WriteLine($"x = {x:F2}");       // x = 10.00 (2 miejsca po przecinku)
Console.WriteLine($"x = {x:D5}");       // x = 00010 (dopełnienie zerami)

// Formatowanie daty
DateTime now = DateTime.Now;
Console.WriteLine($"{now:dd-MM-yyyy}");  // 09-02-2026
Console.WriteLine($"{now:MMM-yyyy}");    // Feb-2026
```

---

# Typy danych i struktury

## Typy wartościowe vs referencyjne

| **Typy wartościowe** | **Typy referencyjne** |
| --- | --- |
| Przechowywane na stosie | Przechowywane na stercie |
| `int`, `float`, `bool`, `char` | `string`, `class`, `interface` |
| `struct`, `enum` | `object`, tablice |
| Kopiowanie przez wartość | Kopiowanie przez referencję |

### Boxing i Unboxing

```csharp
// Boxing: wartość → referencja
int liczba = 42;
object obj = liczba;  // Opakowanie

// Unboxing: referencja → wartość  
int z = (int)obj;  // Rozpakowanie (wymaga rzutowania)
```

> **Uwaga:** Boxing jest kosztowny wydajnościowo - unikaj go w krytycznych fragmentach kodu!
> 

## Tablice

```csharp
// Deklaracja i inicjalizacja
int[] tablica1 = new int[5];  // Tablica 5 elementów (wartości domyślne)
int[] tablica2 = { 1, 2, 3, 4, 5 };  // Z wartościami początkowymi

// Tablice wielowymiarowe
int[,] macierz = new int[3, 4];  // Prostokątna 3x4
int[,] macierz2 = { { 1, 2 }, { 3, 4 }, { 5, 6 } };

// Tablice postrzępione (jagged)
int[][] postrzepiona = new int[3][];
postrzepiona[0] = new int[2] { 1, 2 };
postrzepiona[1] = new int[4] { 3, 4, 5, 6 };
postrzepiona[2] = new int[3] { 7, 8, 9 };

// Iteracja
foreach (int element in tablica2)
{
    Console.WriteLine(element);
}
```

## Enum - typy wyliczeniowe

```csharp
// Domyślnie wartości zaczynają się od 0
public enum Plec { K = 0, M = 1 }

// Z przypisanymi wartościami
public enum Status
{
    Nieaktywny = 0,
    Aktywny = 1,
    Zawieszony = 2
}

// Enum jako ceny
public enum Standard
{
    Economic = 200,
    HighStandard = 350,
    Luxury = 400
}

// Użycie
Plec plec = Plec.K;
if (plec == Plec.K) 
{
    Console.WriteLine("Kobieta");
}

// Konwersja string → enum
if (Enum.TryParse<Standard>("Luxury", out Standard wynik))
{
    Console.WriteLine($"Cena: {(int)wynik}");  // Cena: 400
}
```

---

# Wyrażenia regularne

Wyrażenia regularne (Regex) służą do wyszukiwania i walidacji wzorców w tekście.

## Podstawowe symbole

| Symbol | Znaczenie | Przykład |
| --- | --- | --- |
| `^` | Początek stringa | `^abc` dopasuje "abc" na początku |
| `$` | Koniec stringa | `xyz$` dopasuje "xyz" na końcu |
| `.` | Dowolny znak | `a.c` dopasuje "abc", "a1c" |
| `*` | 0 lub więcej | `ab*c` dopasuje "ac", "abc", "abbc" |
| `+` | 1 lub więcej | `ab+c` dopasuje "abc", "abbc" (nie "ac") |
| `?` | 0 lub 1 | `ab?c` dopasuje "ac" lub "abc" |
| `\d` | Cyfra | `\d+` dopasuje "123" |
| `\w` | Znak alfanumeryczny | `\w+` dopasuje "abc_123" |
| `[a-z]` | Dowolna mała litera |  |
| `[0-9]` | Dowolna cyfra |  |
| `{n}` | Dokładnie n wystąpień | `\d{3}` dopasuje "123" |

## Praktyczne przykłady

```csharp
using System.Text.RegularExpressions;

// Walidacja PESEL (11 cyfr)
string peselPattern = @"^\d{11}$";
bool isPeselValid = Regex.IsMatch("12345678901", peselPattern);  // true

// Walidacja numeru telefonu (XXX-XXX-XXX)
string phonePattern = @"^\d{3}-\d{3}-\d{3}$";
bool isPhoneValid = Regex.IsMatch("123-456-789", phonePattern);  // true

// Sprawdzenie czy string zawiera tylko cyfry
string onlyDigits = @"^[0-9]+$";
bool hasOnlyDigits = Regex.IsMatch("12345", onlyDigits);  // true

// Email (uproszczona wersja)
string emailPattern = @"^[\w.-]+@[\w.-]+\.\w+$";
bool isEmailValid = Regex.IsMatch("user@example.com", emailPattern);

// Znajdź wszystkie cyfry w tekście
string text = "Mam 2 koty i 3 psy";
MatchCollection matches = Regex.Matches(text, @"\d+");
foreach (Match match in matches)
{
    Console.WriteLine(match.Value);  // 2, 3
}
```

### Przykład w klasie

```csharp
public class Abonent
{
    private string numerTelefonu;
    
    public string NumerTelefonu
    {
        get => numerTelefonu;
        set
        {
            const string pattern = @"^\d{3}-\d{3}-\d{3}$";
            if (!Regex.IsMatch(value, pattern))
            {
                throw new ArgumentException(
                    "Niepoprawny format. Użyj XXX-XXX-XXX");
            }
            numerTelefonu = value;
        }
        }
}
```

---

# Hermetyzacja (Encapsulation)

**Hermetyzacja** to ukrywanie szczegółów implementacji i udostępnianie tylko niezbędnego interfejsu.

## Modyfikatory dostępu

| Modyfikator | Dostęp |
| --- | --- |
| `public` | Wszędzie |
| `internal` | Tylko w tym samym assembly |
| `protected` | Klasa i klasy pochodne |
| `private` | Tylko w tej klasie (domyślny dla pól) |
| `protected internal` | `protected` LUB `internal` |
| `private protected` | `protected` I `internal` |

## Właściwości (Properties)

Właściwości to "inteligentne pola" - wyglądają jak pola, ale działają jak metody.

### Auto-właściwości (najprostsza forma)

```csharp
public class Osoba
{
    // Auto-property (kompilator tworzy ukryte pole)
    public string Imie { get; set; }
    
    // Tylko do odczytu (można ustawić tylko w konstruktorze)
    public string Pesel { get; init; }
    
    // Prywatny setter
    public int Wiek { get; private set; }
}

// Użycie
Osoba o = new Osoba 
{ 
    Imie = "Jan",
    Pesel = "12345678901"  // init - tylko tu!
};
o.Imie = "Anna";  // OK
// o.Pesel = "...";  // BŁĄD - init-only
```

### Właściwości z logiką

```csharp
public class Osoba
{
    private string nazwisko;  // Pole prywatne (backing field)
    
    public string Nazwisko
    {
        get => nazwisko;
        set
        {
            // Walidacja lub transformacja
            nazwisko = char.ToUpper(value[0]) + value.Substring(1).ToLower();
        }
    }
    
    // Właściwość tylko do odczytu (computed property)
    private DateTime dataUrodzenia;
    public int Wiek
    {
        get
        {
            var dzis = DateTime.Today;
            int wiek = dzis.Year - dataUrodzenia.Year;
            if (dzis < dataUrodzenia.AddYears(wiek)) wiek--;
            return wiek;
        }
    }
}
```

### Przykład z walidacją i obsługą błędów

```csharp
public class Osoba
{
    private string pesel;
    
    public string Pesel
    {
        get => pesel;
        set
        {
            try
            {
                if (value.Length != 11 || !value.All(char.IsDigit))
                {
                    throw new ArgumentException(
                        "PESEL musi mieć 11 cyfr!");
                }
                pesel = value;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Błąd: {e.Message}");
                pesel = new string('0', 11);  // Wartość domyślna
            }
        }
    }
}
```

## readonly - pola tylko do odczytu

```csharp
public class Pojazd
{
    // Można ustawić tylko w konstruktorze
    public readonly string NumerRejestracyjny;
    
    public Pojazd(string numer)
    {
        NumerRejestracyjny = numer;  // OK
    }
    
    public void ZmienNumer(string nowy)
    {
        // NumerRejestracyjny = nowy;  // BŁĄD!
        }
}
```

---

# Dziedziczenie (Inheritance)

**Dziedziczenie** pozwala tworzyć nowe klasy bazując na istniejących, przejmując ich funkcjonalność.

## Podstawy dziedziczenia

```csharp
// Klasa bazowa (rodzic)
public abstract class Osoba  // abstract - nie można tworzyć instancji
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    protected string pesel;  // Dostępne dla klas pochodnych
    
    public Osoba()  // Konstruktor bazowy
    {
        Imie = string.Empty;
        Nazwisko = string.Empty;
    }
    
    public Osoba(string imie, string nazwisko)
    {
        Imie = imie;
        Nazwisko = nazwisko;
    }
    
    // Metoda wirtualna - może być nadpisana
    public virtual string PrzedstawSie()
    {
        return $"{Imie} {Nazwisko}";
    }
    
    // Metoda abstrakcyjna - MUSI być zaimplementowana
    public abstract double Moc();
}

// Klasa pochodna (dziecko)
public class Pracownik : Osoba
{
    public string Stanowisko { get; set; }
    public decimal Pensja { get; set; }
    
    // :base() - wywołanie konstruktora rodzica
    public Pracownik() : base()
    {
        Stanowisko = "Nieznane";
    }
    
    public Pracownik(string imie, string nazwisko, string stanowisko) 
        : base(imie, nazwisko)  // Wywołaj konstruktor rodzica
    {
        Stanowisko = stanowisko;
    }
    
    // override - nadpisanie metody wirtualnej
    public override string PrzedstawSie()
    {
        return $"{base.PrzedstawSie()}, {Stanowisko}";
    }
    
    // Implementacja metody abstrakcyjnej
    public override double Moc()
    {
        return (double)Pensja * 0.01;
    }
}
```

## Łańcuch wywołań konstruktorów

```csharp
public class Osoba
{
    public string Imie { get; set; }
    
    public Osoba()  // 1. Wywołany jako pierwszy
    {
        Console.WriteLine("Konstruktor Osoba()");
    }
    
    public Osoba(string imie) : this()  // Wywołaj this() najpierw
    {
        Console.WriteLine("Konstruktor Osoba(string)");
        Imie = imie;
    }
}

public class Pracownik : Osoba
{
    public Pracownik(string imie) : base(imie)  // Wywołaj base
    {
        Console.WriteLine("Konstruktor Pracownik(string)");
    }
}

// Wywołanie: new Pracownik("Jan")
// Wypisze:
// Konstruktor Osoba()
// Konstruktor Osoba(string)
// Konstruktor Pracownik(string)
```

## Sealed - klasy zapieczętowane

```csharp
// Nie można dziedziczyć po klasie sealed
public sealed class Administrator : Pracownik
{
    // ...
}

// public class SuperAdmin : Administrator { }  // BŁĄD!
```

## System.Object - korzeń hierarchii

**Wszystkie klasy** w C# dziedziczą po `System.Object` (alias: `object`).

Ważne metody z `Object`:

```csharp
public class Osoba
{
    public string Imie { get; set; }
    
    // ToString - reprezentacja tekstowa
    public override string ToString()
    {
        return $"Osoba: {Imie}";
    }
    
    // Equals - porównanie równości
    public override bool Equals(object obj)
    {
        if (obj is Osoba other)
            return this.Imie == other.Imie;
        return false;
    }
    
    // GetHashCode - kod skrótu (dla Dictionary, HashSet)
    public override int GetHashCode()
    {
        return Imie?.GetHashCode() ?? 0;
        }
}
```

---

# Polimorfizm

**Polimorfizm** to zdolność obiektów różnych klas do reagowania na te same wywołania metod w różny sposób.

## Polimorfizm dynamiczny (runtime)

Realizowany przez `virtual` i `override`:

```csharp
public class Zwierze
{
    public virtual void DajGlos()
    {
        Console.WriteLine("...");
    }
}

public class Pies : Zwierze
{
    public override void DajGlos()
    {
        Console.WriteLine("Hau hau!");
    }
}

public class Kot : Zwierze  
{
    public override void DajGlos()
    {
        Console.WriteLine("Miau!");
    }
}

// Użycie
Zwierze[] zwierzeta = new Zwierze[]
{
    new Pies(),
    new Kot(),
    new Zwierze()
};

foreach (var z in zwierzeta)
{
    z.DajGlos();  // Wywoła odpowiednią metodę dla każdego typu!
}
// Wyjście:
// Hau hau!
// Miau!
// ...
```

## Polimorfizm statyczny (compile-time)

### Przeciążanie metod (Method Overloading)

Ta sama nazwa, różne parametry:

```csharp
public class Kalkulator
{
    public int Dodaj(int a, int b)
    {
        return a + b;
    }
    
    public double Dodaj(double a, double b)
    {
        return a + b;
    }
    
    public string Dodaj(string a, string b)
    {
        return a + b;
    }
    
    // Różna liczba parametrów
    public int Dodaj(int a, int b, int c)
    {
        return a + b + c;
    }
}

// Kompilator wybiera odpowiednią wersję
Kalkulator k = new Kalkulator();
k.Dodaj(1, 2);           // int Dodaj(int, int)
k.Dodaj(1.5, 2.5);       // double Dodaj(double, double)
k.Dodaj("A", "B");       // string Dodaj(string, string)
```

> **Uwaga:** Nie można przeciążyć tylko po typie zwracanym!
> 

### Przeciążanie operatorów (Operator Overloading)

```csharp
public class Wektor
{
    public double X { get; set; }
    public double Y { get; set; }
    
    // Przeciążenie operatora +
    public static Wektor operator +(Wektor a, Wektor b)
    {
        return new Wektor 
        { 
            X = a.X + b.X, 
            Y = a.Y + b.Y 
        };
    }
    
    // Przeciążenie operatora ==
    public static bool operator ==(Wektor a, Wektor b)
    {
        return a.X == b.X && a.Y == b.Y;
    }
    
    public static bool operator !=(Wektor a, Wektor b)
    {
        return !(a == b);
    }
}

// Użycie
Wektor v1 = new Wektor { X = 1, Y = 2 };
Wektor v2 = new Wektor { X = 3, Y = 4 };
Wektor suma = v1 + v2;  // X=4, Y=6
```

**Operatory, które można przeciążyć:**

- Arytmetyczne: `+`, `-`, `*`, `/`, `%`
- Logiczne: `&`, `|`, `^`, `!`
- Porównania: `==`, `!=`, `<`, `>`, `<=`, `>=`
- Inne: `++`, `--`

**Nie można przeciążyć:** `=`, `.`, `?:`, `new`, `is`, `sizeof`, `typeof`

---

# Abstrakcja (Abstraction)

**Abstrakcja** to ukrywanie złożoności i pokazywanie tylko istotnych detali.

## Klasy abstrakcyjne

```csharp
// Nie można utworzyć instancji klasy abstract
public abstract class Pojazd
{
    public string Marka { get; set; }
    public int RokProdukcji { get; set; }
    
    // Metoda abstrakcyjna - brak implementacji
    public abstract double ObliczCene();
    
    // Metoda wirtualna - ma implementację, może być nadpisana
    public virtual void Zaparkuj()
    {
        Console.WriteLine("Pojazd zaparkowany");
    }
    
    // Zwykła metoda
    public void WyswietlInfo()
    {
        Console.WriteLine($"{Marka} ({RokProdukcji})");
    }
}

public class Samochod : Pojazd
{
    public int LiczbaDrzwi { get; set; }
    
    // MUSI zaimplementować metody abstrakcyjne
    public override double ObliczCene()
    {
        double bazowaCena = 50000;
        int wiek = DateTime.Now.Year - RokProdukcji;
        return bazowaCena - (wiek * 2000);
    }
    
    // Może nadpisać metody wirtualne
    public override void Zaparkuj()
    {
        Console.WriteLine("Samochód wjechał na parking");
    }
}
```

## Różnice: abstract class vs interface

| **Abstract Class** | **Interface** |
| --- | --- |
| Może zawierać implementację metod | Tylko sygnatury metod (C# <8.0) |
| Może mieć pola | Nie może mieć pól |
| Może mieć konstruktory | Nie ma konstruktorów |
| Jedno dziedziczenie | Wiele implementacji |
| `public`, `protected`, `private` | Tylko `public` |

**Kiedy używać abstract class?**

- Gdy klasy mają wspólną funkcjonalność
- Gdy potrzebujesz pól lub konstruktorów
- Gdy chcesz zdefiniować domyślne zachowanie

**Kiedy używać interface?**

- Gdy definiujesz kontrakt (co klasa MUSI umieć)
- Gdy klasa musi implementować wiele zachowań
- Gdy chcesz luźne powiązanie między komponentami

---

# Interfejsy

**Interfejs** to kontrakt definiujący zestaw metod, które klasa MUSI zaimplementować.

## Podstawy interfejsów

```csharp
// Konwencja: nazwy interfejsów zaczynają się od 'I'
public interface IPojazd
{
    // Tylko sygnatury - brak implementacji
    void Jedz();
    void Zatrzymaj();
    double PobierzPredkosc();
    
    // Właściwości
    string Marka { get; set; }
    
    // Od C# 8.0 można dodać domyślną implementację
    void Klakson()
    {
        Console.WriteLine("Bip bip!");
    }
}

// Klasa może implementować wiele interfejsów
public class Samochod : IPojazd, IComparable<Samochod>
{
    public string Marka { get; set; }
    private double predkosc;
    
    // Implementacja metod z interfejsu
    public void Jedz()
    {
        predkosc = 60;
        Console.WriteLine("Samochód jedzie");
    }
    
    public void Zatrzymaj()
    {
        predkosc = 0;
        Console.WriteLine("Samochód zatrzymany");
    }
    
    public double PobierzPredkosc()
    {
        return predkosc;
    }
    
    // CompareTo z IComparable
    public int CompareTo(Samochod other)
    {
        return this.Marka.CompareTo(other.Marka);
    }
}
```

## IComparable<T> - sortowanie naturalne

Definiuje **domyślną kolejność** sortowania dla klasy.

```csharp
public class CzlonekZespolu : IComparable<CzlonekZespolu>
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    
    public int CompareTo(CzlonekZespolu other)
    {
        if (other == null) return 1;
        
        // Sortuj po nazwisku, potem po imieniu
        int result = this.Nazwisko.CompareTo(other.Nazwisko);
        if (result == 0)  // Nazwiska są takie same
            return this.Imie.CompareTo(other.Imie);
        
        return result;
    }
}

// Użycie
List<CzlonekZespolu> lista = new List<CzlonekZespolu>();
lista.Add(new CzlonekZespolu { Imie = "Jan", Nazwisko = "Kowalski" });
lista.Add(new CzlonekZespolu { Imie = "Anna", Nazwisko = "Nowak" });
lista.Sort();  // Użyje CompareTo!
```

**CompareTo zwraca:**

- `< 0` jeśli `this` < `other`
- `0` jeśli są równe
- `> 0` jeśli `this` > `other`

## IComparer<T> - sortowanie niestandardowe

Pozwala definiować **wiele różnych sposobów sortowania** tej samej klasy.

```csharp
// Sortowanie po PESEL
public class PeselComparer : IComparer<CzlonekZespolu>
{
    public int Compare(CzlonekZespolu x, CzlonekZespolu y)
    {
        return string.Compare(x.Pesel, y.Pesel);
    }
}

// Sortowanie po wieku (malejąco)
public class WiekComparer : IComparer<CzlonekZespolu>
{
    public int Compare(CzlonekZespolu x, CzlonekZespolu y)
    {
        return y.Wiek.CompareTo(x.Wiek);  // Odwrotna kolejność!
    }
}

// Użycie
List<CzlonekZespolu> lista = /* ... */;
lista.Sort();  // Domyślne sortowanie (IComparable)
lista.Sort(new PeselComparer());  // Po PESEL
lista.Sort(new WiekComparer());   // Po wieku (malejąco)
```

## IEquatable<T> - równość logiczna

Definiuje, kiedy dwa obiekty są **logicznie równe**.

```csharp
public class Osoba : IEquatable<Osoba>
{
    public string Pesel { get; set; }
    public string Imie { get; set; }
    
    // Dwa obiekty są równe, gdy mają ten sam PESEL
    public bool Equals(Osoba other)
    {
        if (other == null) return false;
        return this.Pesel == other.Pesel;
    }
    
    // Należy też nadpisać Equals(object)
    public override bool Equals(object obj)
    {
        return Equals(obj as Osoba);
    }
    
    // I GetHashCode (dla Dictionary, HashSet)
    public override int GetHashCode()
    {
        return Pesel.GetHashCode();
    }
}

// Użycie
Osoba o1 = new Osoba { Pesel = "12345678901", Imie = "Jan" };
Osoba o2 = new Osoba { Pesel = "12345678901", Imie = "Anna" };

Console.WriteLine(o1.Equals(o2));  // true - ten sam PESEL!

// Wyszukiwanie w liście
List<Osoba> osoby = new List<Osoba> { o1, o2 };
bool istnieje = osoby.Exists(o => o.Pesel == "12345678901");
```

## ICloneable - klonowanie obiektów

Umożliwia tworzenie kopii obiektów.

```csharp
public class CzlonekZespolu : ICloneable
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public List<string> Umiejetnosci { get; set; }
    
    // Płytka kopia - kopiuje referencje
    public object Clone()
    {
        return this.MemberwiseClone();
    }
    
    // Głęboka kopia - kopiuje zawartość
    public CzlonekZespolu DeepClone()
    {
        CzlonekZespolu kopia = (CzlonekZespolu)this.MemberwiseClone();
        // Nowa lista zamiast referencji
        kopia.Umiejetnosci = new List<string>(this.Umiejetnosci);
        return kopia;
    }
}

// Różnica między płytką a głęboką kopią
var oryginal = new CzlonekZespolu
{
    Imie = "Jan",
    Umiejetnosci = new List<string> { "C#", "SQL" }
};

// Płytka kopia
var kopia1 = (CzlonekZespolu)oryginal.Clone();
kopia1.Umiejetnosci.Add("Python");
Console.WriteLine(oryginal.Umiejetnosci.Count);  // 3! (współdzielona lista)

// Głęboka kopia  
var kopia2 = oryginal.DeepClone();
kopia2.Umiejetnosci.Add("Java");
Console.WriteLine(oryginal.Umiejetnosci.Count);  // 3 (niezależna lista)
```

---

# Kolekcje i struktury danych

Kolekcje to dynamiczne zbiory elementów. C# oferuje dwa rodzaje:

- **Niegeneryczne** (`ArrayList`, `Hashtable`) - przechowują `object`
- **Generyczne** (`List<T>`, `Dictionary<TKey,TValue>`) - silnie typowane

> **Zawsze używaj kolekcji generycznych!** Są szybsze (brak boxingu) i bezpieczniejsze (type-safe).
> 

## List<T> - dynamiczna lista

```csharp
// Tworzenie
List<string> imiona = new List<string>();
List<int> liczby = new List<int> { 1, 2, 3, 4, 5 };

// Dodawanie
imiona.Add("Jan");
imiona.AddRange(new[] { "Anna", "Piotr" });

// Dostęp
string pierwsze = imiona[0];  // Jan
string ostatnie = imiona[imiona.Count - 1];  // Piotr

// Usuwanie
imiona.Remove("Jan");        // Usuń po wartości
imiona.RemoveAt(0);           // Usuń po indeksie
imiona.RemoveAll(x => x.StartsWith("A"));  // Usuń według warunku
imiona.Clear();               // Usuń wszystkie

// Wyszukiwanie
bool istnieje = imiona.Contains("Anna");
int indeks = imiona.IndexOf("Piotr");
string znaleziony = imiona.Find(x => x.Length > 3);  // Pierwszy pasujący
List<string> wszyscy = imiona.FindAll(x => x.Length > 3);  // Wszystkie

// Sortowanie
liczby.Sort();  // Rosnąco
liczby.Sort((a, b) => b.CompareTo(a));  // Malejąco
```

### Praktyczny przykład - Zespół

```csharp
public class Zespol
{
    private List<CzlonekZespolu> czlonkowie = new List<CzlonekZespolu>();
    
    public void DodajCzlonka(CzlonekZespolu czlonek)
    {
        czlonkowie.Add(czlonek);
    }
    
    // Znajdź nieaktywnych
    public List<CzlonekZespolu> WyszukajNieaktywnychCzlonkow()
    {
        return czlonkowie.Where(c => !c.Aktywny).ToList();
        // Lub: czlonkowie.FindAll(c => !c.Aktywny);
    }
    
    // Usuń po PESEL
    public void UsunCzlonka(string pesel)
    {
        czlonkowie.RemoveAll(c => c.Pesel == pesel);
    }
    
    // Sortuj
    public void Sortuj()
    {
        czlonkowie.Sort();  // Wymaga IComparable<CzlonekZespolu>
    }
}
```

## Dictionary<TKey, TValue> - słownik (mapa)

**Dictionary** przechowuje pary klucz-wartość. Klucz musi być unikalny.

```csharp
// Tworzenie
Dictionary<string, Abonent> abonenci = new Dictionary<string, Abonent>();

// Dodawanie
abonenci.Add("123-456-789", new Abonent("Jan", "Kowalski"));
abonenci["987-654-321"] = new Abonent("Anna", "Nowak");  // Lub nadpisz

// Sprawdzanie istnienia klucza (WAŻNE!)
if (abonenci.ContainsKey("123-456-789"))
{
    Abonent a = abonenci["123-456-789"];
}

// Bezpieczne pobieranie
if (abonenci.TryGetValue("123-456-789", out Abonent abonent))
{
    Console.WriteLine(abonent);
}

// Pobieranie z domyślną wartością
Abonent ab = abonenci.GetValueOrDefault("999-999-999", 
    new Abonent("Nieznany", "Nieznany"));

// Usuwanie
abonenci.Remove("123-456-789");

// Iteracja
foreach (KeyValuePair<string, Abonent> kvp in abonenci)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}

// Tylko klucze lub wartości
foreach (string numer in abonenci.Keys) { }
foreach (Abonent ab in abonenci.Values) { }
```

### Praktyczny przykład - Książka telefoniczna

```csharp
public class KsiazkaTelefoniczna
{
    private Dictionary<string, Abonent> abonenci = 
        new Dictionary<string, Abonent>();
    
    public void DodajAbonenta(Abonent abonent)
    {
        // Sprawdź duplikaty!
        if (abonenci.ContainsKey(abonent.NumerTelefonu))
        {
            Console.WriteLine("Taki numer już istnieje!");
            return;
        }
        abonenci.Add(abonent.NumerTelefonu, abonent);
    }
    
    public Abonent WyszukajAbonenta(string numer)
    {
        return abonenci.GetValueOrDefault(numer);
    }
    
    public List<Abonent> WyszukajPoMiescie(string miasto)
    {
        return abonenci.Values
            .Where(a => a.Miasto == miasto)
            .ToList();
    }
}
```

## Stack<T> - stos (LIFO)

**Last In, First Out** - ostatni wchodzi, pierwszy wychodzi (jak stos talerzy).

```csharp
Stack<Paczka> stos = new Stack<Paczka>();

// Dodaj na górę
stos.Push(new Paczka("Nadawca A", 5));
stos.Push(new Paczka("Nadawca B", 3));

// Zobacz górny element (bez usuwania)
Paczka gora = stos.Peek();

// Pobierz i usuń górny element
Paczka pobrana = stos.Pop();

// Sprawdź czy pusty
if (stos.Count > 0) { }

// Wyczyść
stos.Clear();
```

### Praktyczny przykład - Magazyn LIFO

```csharp
public interface IMagazynuje
{
    void Umiesc(Paczka p);
    Paczka Pobierz();
    void Wyczysc();
    int PodajIlosc();
}

public class MagazynLIFO : IMagazynuje
{
    private Stack<Paczka> stos = new Stack<Paczka>();
    
    public void Umiesc(Paczka p)
    {
        stos.Push(p);
    }
    
    public Paczka Pobierz()
    {
        return stos.Pop();
    }
    
    public void Wyczysc()
    {
        stos.Clear();
    }
    
    public int PodajIlosc()
    {
        return stos.Count;
    }
}
```

## Queue<T> - kolejka (FIFO)

**First In, First Out** - pierwszy wchodzi, pierwszy wychodzi (jak kolejka w sklepie).

```csharp
Queue<Paczka> kolejka = new Queue<Paczka>();

// Dodaj na koniec
kolejka.Enqueue(new Paczka("Nadawca A", 5));
kolejka.Enqueue(new Paczka("Nadawca B", 3));

// Zobacz pierwszy element (bez usuwania)
Paczka pierwszy = kolejka.Peek();

// Pobierz i usuń pierwszy element
Paczka pobrana = kolejka.Dequeue();
```

### Praktyczny przykład - Magazyn FIFO

```csharp
public class MagazynFIFO : IMagazynuje
{
    private Queue<Paczka> kolejka = new Queue<Paczka>();
    
    public void Umiesc(Paczka p)
    {
        kolejka.Enqueue(p);
    }
    
    public Paczka Pobierz()
    {
        return kolejka.Dequeue();
    }
    
    public void Wyczysc()
    {
        kolejka.Clear();
    }
    
    public int PodajIlosc()
    {
        return kolejka.Count;
    }
}
```

## HashSet<T> - zbiór (bez duplikatów)

**HashSet** automatycznie zapewnia unikalność elementów.

```csharp
HashSet<string> umiejetnosci = new HashSet<string>();

// Dodawanie - zwraca false jeśli już istnieje
bool dodano1 = umiejetnosci.Add("C#");     // true
bool dodano2 = umiejetnosci.Add("C#");     // false (duplikat!)

// Operacje na zbiorach
HashSet<string> zestaw1 = new HashSet<string> { "C#", "SQL", "Python" };
HashSet<string> zestaw2 = new HashSet<string> { "Python", "Java", "JavaScript" };

// Suma (union)
zestaw1.UnionWith(zestaw2);  
// Wynik: { "C#", "SQL", "Python", "Java", "JavaScript" }

// Przecięcie (intersection)
zestaw1.IntersectWith(zestaw2);  
// Wynik: { "Python" }

// Różnica
zestaw1.ExceptWith(zestaw2);  
// Usuwa elementy z zestaw2
```

## Porównanie kolekcji

| Kolekcja | Kiedy używać | Złożoność dostępu | Duplikaty |
| --- | --- | --- | --- |
| `List<T>` | Uporządkowana lista, dostęp po indeksie | O(1) | Tak |
| `Dictionary<K,V>` | Szybkie wyszukiwanie po kluczu | O(1) | Klucz: Nie |
| `HashSet<T>` | Unikalność elementów | O(1) | Nie |
| `Stack<T>` | LIFO (ostatni wchodzi, pierwszy wychodzi) | O(1) | Tak |
| `Queue<T>` | FIFO (pierwszy wchodzi, pierwszy wychodzi) | O(1) | Tak |
| `LinkedList<T>` | Częste wstawianie/usuwanie w środku | O(1) wstawianie | Tak |

---

# LINQ i wyrażenia lambda

**LINQ** (Language Integrated Query) to technologia do odpytywania kolekcji w C#.

## Wyrażenia lambda

Wyrażenie lambda to anonimowa funkcja (funkcja bez nazwy).

```csharp
// Składnia: (parametry) => wyrażenie

// Bez parametrów
Func<int> dajPiec = () => 5;

// Jeden parametr (nawiasy opcjonalne)
Func<int, int> kwadrat = x => x * x;
Func<int, int> kwadrat2 = (x) => x * x;  // To samo

// Wiele parametrów
Func<int, int, int> suma = (a, b) => a + b;

// Blok kodu (wymaga return)
Func<int, bool> jestParzysta = x =>
{
    if (x % 2 == 0)
        return true;
    return false;
};

// Użycie
int wynik = kwadrat(5);  // 25
```

### Lambda jako predykat

```csharp
List<int> liczby = new List<int> { 1, 2, 3, 4, 5, 6 };

// Znajdź wszystkie parzyste
List<int> parzyste = liczby.FindAll(x => x % 2 == 0);
// Wynik: { 2, 4, 6 }

// Sprawdź czy istnieje
bool istnieje = liczby.Exists(x => x > 5);  // true

// Usuń według warunku
liczby.RemoveAll(x => x < 3);
// Wynik: { 3, 4, 5, 6 }
```

## LINQ - podstawowe operacje

### Where - filtrowanie

```csharp
List<CzlonekZespolu> czlonkowie = /* ... */;

// Składnia metody
var aktywni = czlonkowie.Where(c => c.Aktywny).ToList();

// Składnia zapytania (SQL-like)
var aktywni2 = from c in czlonkowie
               where c.Aktywny
               select c;

// Wiele warunków
var programisci = czlonkowie
    .Where(c => c.Aktywny && c.Funkcja == "programista")
    .ToList();
```

### Select - projekcja (transformacja)

```csharp
// Wybierz tylko imiona
List<string> imiona = czlonkowie
    .Select(c => c.Imie)
    .ToList();

// Utwórz nowy obiekt (anonimowy typ)
var skrocone = czlonkowie
    .Select(c => new 
    { 
        PelneImie = $"{c.Imie} {c.Nazwisko}",
        Wiek = c.Wiek
    })
    .ToList();
```

### OrderBy - sortowanie

```csharp
// Rosnąco
var posortowani = czlonkowie
    .OrderBy(c => c.Nazwisko)
    .ToList();

// Malejąco
var posortowani2 = czlonkowie
    .OrderByDescending(c => c.Wiek)
    .ToList();

// Sortowanie wielokrotne
var posortowani3 = czlonkowie
    .OrderBy(c => c.Nazwisko)
    .ThenBy(c => c.Imie)
    .ToList();
```

### First, FirstOrDefault, Single

```csharp
// First - pierwszy element (rzuca wyjątek jeśli brak)
var pierwszy = czlonkowie.First();
var pierwszyAktywny = czlonkowie.First(c => c.Aktywny);

// FirstOrDefault - zwraca null jeśli brak
var pierwszy2 = czlonkowie.FirstOrDefault(c => c.Wiek > 100);

// Single - dokładnie jeden element (inaczej wyjątek)
var jedyny = czlonkowie.Single(c => c.Pesel == "12345678901");
```

### Count, Sum, Average, Min, Max

```csharp
List<int> liczby = new List<int> { 1, 2, 3, 4, 5 };

int ile = liczby.Count();          // 5
int suma = liczby.Sum();           // 15
double srednia = liczby.Average(); // 3.0
int min = liczby.Min();            // 1
int max = liczby.Max();            // 5

// Z warunkiem
int ileAktywnych = czlonkowie.Count(c => c.Aktywny);
double sredniaPlaca = czlonkowie.Average(c => c.Pensja);
```

### GroupBy - grupowanie

```csharp
// Grupuj po funkcji
var grupy = czlonkowie
    .GroupBy(c => c.Funkcja)
    .ToList();

foreach (var grupa in grupy)
{
    Console.WriteLine($"{grupa.Key}: {grupa.Count()} osób");
    foreach (var czlonek in grupa)
    {
        Console.WriteLine($"  - {czlonek.Imie}");
    }
}

// Użycie w praktyce - policz role
public string Oddzial()
{
    var grupy = wojownicy.GroupBy(w => w.Rola);
    return string.Join(", ", grupy.Select(g => $"{g.Key}: {g.Count()}"));
}
```

### Join - łączenie kolekcji

```csharp
var wynik = czlonkowie
    .Join(zespoly,
        czlonek => czlonek.ZespolId,  // Klucz z czlonkowie
        zespol => zespol.ZespolId,    // Klucz z zespoly
        (czlonek, zespol) => new      // Wynik
        {
            Imie = czlonek.Imie,
            NazwaZespolu = zespol.Nazwa
        });
```

## Przykład praktyczny - analiza zespołu

```csharp
public class Zespol
{
    public List<CzlonekZespolu> Czlonkowie { get; set; }
    
    // Wszyscy programiści
    public List<CzlonekZespolu> WyszukajFunkcje(string funkcja)
    {
        return Czlonkowie
            .Where(c => c.Funkcja.Equals(funkcja, 
                StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
    
    // Nieaktywni
    public List<CzlonekZespolu> WyszukajNieaktywnych()
    {
        return Czlonkowie.Where(c => !c.Aktywny).ToList();
    }
    
    // Średni wiek
    public double SredniWiek()
    {
        return Czlonkowie.Average(c => c.Wiek);
    }
    
    // Najstarszy członek
    public CzlonekZespolu NajstarszyZespolowy()
    {
        return Czlonkowie.OrderByDescending(c => c.Wiek).First();
    }
    
    // Grupowanie po funkcji
    public Dictionary<string, int> StatystykiFunkcji()
    {
        return Czlonkowie
            .GroupBy(c => c.Funkcja)
            .ToDictionary(g => g.Key, g => g.Count());
        }
}
```

---

# Serializacja i persystencja danych

**Serializacja** to proces przekształcania obiektów do postaci, którą można zapisać lub przesłać.

## Serializacja XML

### Podstawy

```csharp
using System.Xml.Serialization;
using System.IO;
// Klasa musi być publiczna
[XmlRoot("Zespol")]  // Opcjonalnie: nazwa głównego elementu
public class Zespol
{
    public string Nazwa { get; set; }
    [XmlAttribute]  // Jako atrybut XML zamiast elementu
    public int Id { get; set; }
    [XmlIgnore]  // Nie serializuj tego pola
    public string TymczasowyDanych { get; set; }
    public List<CzlonekZespolu> Czlonkowie { get; set; }
    // WYMAGANY konstruktor bezparametrowy!
    public Zespol()
    {
        Czlonkowie = new List<CzlonekZespolu>();
    }
}
```

### Zapis i odczyt XML (lub JSON)

```csharp
public static void ZapiszXML(Zespol zespol, string plik)
{
    try
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Zespol));
        using (StreamWriter writer = new StreamWriter(plik))
        {
            serializer.Serialize(writer, zespol);
        }
        Console.WriteLine("Zapisano!");
    }
    catch (Exception e)
    {
        Console.WriteLine($"Błąd: {e.Message}");
    }
}
public static Zespol OdczytajXML(string plik)
{
    try
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Zespol));
        using (StreamReader reader = new StreamReader(plik))
        {
            return (Zespol)serializer.Deserialize(reader);  // Rzutowanie!
        }
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("Plik nie istnieje!");
        return null;
    }
}

// Dodatkowo + Json
// ZAPIS
public void SaveToJson(string fileName, List<Student> data)
{
    string jsonString = JsonSerializer.Serialize(data);
    File.WriteAllText(fileName, jsonString);
}

// ODCZYT
public List<Student> LoadFromJson(string fileName)
{
    string jsonString = File.ReadAllText(fileName);
    return JsonSerializer.Deserialize<List<Student>>(jsonString);
}
```

## Entity Framework (CodeFirst)

Podstawowa konfiguracja:

```csharp
// 1. Zainstaluj EntityFramework 6 przez NuGet
// 2. Utwórz kontekst bazy danych
public class ZespolDbContext : DbContext
{
    public DbSet<Zespol> Zespoly { get; set; }
    public DbSet<KierownikZespolu> Kierownicy { get; set; }
    public DbSet<CzlonekZespolu> Czlonkowie { get; set; }
}
// 3. Dodaj klucze i relacje
public class Zespol
{
    [Key]
    public int ZespolId { get; set; }
    // Relacja 1:1
    public virtual KierownikZespolu KierownikZespolu { get; set; }
    // Relacja 1:n
    public virtual List<CzlonekZespolu> CzlonkowieZespolu { get; set; }
}
public class CzlonekZespolu
{
    [Key]
    public int CzlonekZespoluId { get; set; }
    // Relacja zwrotna
    public int ZespolId { get; set; }
    public virtual Zespol Zespol { get; set; }
}
// 4. Zapisz do bazy
public void SaveToDB()
{
    using var db = new ZespolDbContext();
    Console.WriteLine("Zapisywanie...");
    db.Zespoly.Add(this);
    db.SaveChanges();
    Console.WriteLine("Zapisano!");
}
// 5. Zapytania LINQ
using var db = new ZespolDbContext();
// Wszystkie zespoły alfabetycznie
var query1 = from z in db.Zespoly
             orderby z.NazwaZespolu
             select z;
// Członkowie z konkretnego zespołu
var query2 = from c in db.Czlonkowie
             join z in db.Zespoly on c.ZespolId equals z.ZespolId
             where z.ZespolId == 1
             select new { c, z.NazwaZespolu };
```

**Migracje:**

```bash
# W Package Manager Console
Enable-Migrations
Update-Database -Verbose
```

---

# Testy jednostkowe

**Testy jednostkowe** sprawdzają poprawność pojedynczych jednostek kodu.

## Struktura testu: Arrange-Act-Assert

```csharp
[TestMethod]
public void TestNazwaMetody()
{
    // ARRANGE - przygotuj dane
    int a = 5, b = 3;
    // ACT - wykonaj akcję
    int wynik = a + b;
    // ASSERT - sprawdź wynik
    Assert.AreEqual(8, wynik);
}
```

## MSTest

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
[TestClass]  // Klasa z testami
public class ZespolTests
{
    [TestMethod]
    public void KonstruktorZespol_UstawiaPoprawnaNazwe()
    {
        // Arrange
        string nazwa = "Grupa IT";
        // Act
        Zespol z = new Zespol(nazwa);
        // Assert
        Assert.AreEqual(nazwa, z.NazwaZespolu);
    }
    
    [TestMethod]
    public void KonstruktorZespol_InicjalizujeListeCzlonkow()
    {
        // Arrange & Act
        Zespol z = new Zespol();
        // Assert
        Assert.IsNotNull(z.Czlonkowie);
    }
    
    [TestMethod]
    public void DodajCzlonka_ZwiekszaLiczbeO1()
    {
        // Arrange
        Zespol z = new Zespol();
        CzlonekZespolu c = new CzlonekZespolu { Imie = "Jan" };
        int poczatkowaLiczba = z.Czlonkowie.Count;
        // Act
        z.DodajCzlonka(c);
        // Assert
        Assert.AreEqual(poczatkowaLiczba + 1, z.Czlonkowie.Count);
    }
    
    [TestMethod]
    public void CompareTo_PorownujeDwochCzlonkowPoNazwisku()
    {
        // Arrange
        var jan = new CzlonekZespolu { Imie = "Jan", Nazwisko = "Nowak" };
        var adam = new CzlonekZespolu { Imie = "Adam", Nazwisko = "Nowak" };
        // Act
        int wynik = jan.CompareTo(adam);
        // Assert
        Assert.AreEqual(1, wynik);  // Jan > Adam (alfabetycznie po imieniu)
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]  // Oczekujemy wyjątku!
    public void Pesel_NiepoprawnyFormat_RzucaWyjatek()
    {
        // Arrange
        var osoba = new Osoba();
        // Act
        osoba.Pesel = "aaaa";  // Niepoprawny - powinien rzucić wyjątek
    }
    
    [TestMethod]
    public void PorownajOsoby_TenSamPesel_ZwracaTrue()
    {
        // Arrange
        var o1 = new Osoba { Pesel = "12345678901" };
        var o2 = new Osoba { Pesel = "12345678901" };
        // Act
        bool wynik = o1.Equals(o2);
        // Assert
        Assert.IsTrue(wynik);
    }
}
```

## Dokumentacja kodu

```csharp
/// <summary>
/// Klasa reprezentująca członka zespołu
/// </summary>
public class CzlonekZespolu
{
    /// <summary>
    /// Dodaje członka do zespołu
    /// </summary>
    /// <param name="czlonek">Członek do dodania</param>
    /// <returns>True jeśli dodano pomyślnie</returns>
    public bool DodajCzlonka(CzlonekZespolu czlonek)
    {
        // ...
    }
}
```

**Generowanie XML:** Właściwości projektu → Kompilacja → Zaznacz "Plik dokumentacji XML"

---

# WPF i XAML

**WPF** to framework do tworzenia aplikacji desktopowych z GUI.

## Podstawowa struktura

```xml
<Grid>
    <!-- TextBlock - tekst -->
    <TextBlock HorizontalAlignment="Left" Height="40" 
               Margin="20,24,0,0" Text="Nazwa" 
               VerticalAlignment="Top" Width="520"/>
    <!-- TextBox - pole tekstowe -->
    <TextBox x:Name="txtNazwa" Width="200" Height="30"/>
    <!-- Button -->
    <Button x:Name="btnDodaj" Content="Dodaj" 
            Click="btnDodaj_Click" Height="40"/>
    <!-- ListBox - lista -->
    <ListBox x:Name="lbCzlonkowie" Height="200"/>
    <!-- ComboBox - lista rozwijana -->
    <ComboBox x:Name="cbFunkcja">
        <ComboBoxItem>Programista</ComboBoxItem>
        <ComboBoxItem>Tester</ComboBoxItem>
    </ComboBox>
</Grid>
```

## ObservableCollection - reaktywna kolekcja

```csharp
using System.Collections.ObjectModel;
public partial class MainWindow : Window
{
    private Zespol zespol;
    public MainWindow()
    {
        InitializeComponent();
        // Wczytaj z XML
        zespol = Zespol.OdczytajXML("zespol.xml");
        if (zespol != null)
        {
            // ObservableCollection auto-odświeża UI!
            lbCzlonkowie.ItemsSource = 
                new ObservableCollection<CzlonekZespolu>(zespol.Czlonkowie);
            txtNazwa.Text = zespol.Nazwa;
        }
    }
    
    private void btnDodaj_Click(object sender, RoutedEventArgs e)
    {
        CzlonekZespolu czlonek = new CzlonekZespolu();
        zespol.DodajCzlonka(czlonek);
        // Z ObservableCollection:
        lbCzlonkowie.ItemsSource = 
            new ObservableCollection<CzlonekZespolu>(zespol.Czlonkowie);
        // LUB jeśli już używasz ObservableCollection:
        // (ObservableCollection automatycznie odświeży UI)
    }
    
    // Pobranie wybranego elementu
    private void btnUsun_Click(object sender, RoutedEventArgs e)
    {
        if (lbCzlonkowie.SelectedItem is CzlonekZespolu czlonek)
        {
            zespol.UsunCzlonka(czlonek.Pesel);
            lbCzlonkowie.Items.Refresh();
        }
    }
    
    // ComboBox - pobranie wartości
    private void btnWybierz_Click(object sender, RoutedEventArgs e)
    {
        if (cbFunkcja.SelectedItem is ComboBoxItem selected)
        {
            string funkcja = selected.Content.ToString();
            // ...
        }
    }
}
```

## Okno dialogowe - pattern

```csharp
// OsobaWindow.xaml.cs
public partial class OsobaWindow : Window
{
    private Osoba osoba;
    public OsobaWindow(Osoba os) : this()
    {
        osoba = os;
        // Wypełnij pola
        txtImie.Text = osoba.Imie;
        txtNazwisko.Text = osoba.Nazwisko;
        txtPesel.Text = osoba.Pesel;
    }
    private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(txtImie.Text))
        {
            MessageBox.Show("Wypełnij wszystkie pola!");
            return;
        }
        osoba.Imie = txtImie.Text;
        osoba.Nazwisko = txtNazwisko.Text;
        osoba.Pesel = txtPesel.Text;
        DialogResult = true;  // Zamknij okno z sukcesem
    }
}
// MainWindow - wywołanie okna
private void btnZmien_Click(object sender, RoutedEventArgs e)
{
    OsobaWindow okno = new OsobaWindow(zespol.Kierownik);
    bool? result = okno.ShowDialog();
    if (result == true)
    {
        txtKierownik.Text = zespol.Kierownik.ToString();
    }
}
```

---

# SOLID - zasady projektowania

## 1. Single Responsibility Principle (SRP)

**Klasa powinna mieć tylko jeden powód do zmiany.**

```csharp
// ❌ ŹLE - klasa robi za dużo
public class Uzytkownik
{
    public void ZapiszDoBazy() { }
    public void WyslijEmail() { }
    public void GenerujRaport() { }
}
// ✅ DOBRZE - każda klasa ma jedną odpowiedzialność
public class UzytkownikRepository { public void Zapisz() { } }
public class EmailService { public void Wyslij() { } }
public class RaportGenerator { public void Generuj() { } }
```

## 2. Open/Closed Principle (OCP)

**Otwarte na rozszerzenia, zamknięte na modyfikacje.**

## 3. Liskov Substitution Principle (LSP)

**Obiekty klasy pochodnej powinny zastępować obiekty klasy bazowej.**

## 4. Interface Segregation Principle (ISP)

**Wiele specjalizowanych interfejsów lepiej niż jeden ogólny.**

## 5. Dependency Inversion Principle (DIP)

**Zależności od abstrakcji, nie od konkretów.**

---

# Praktyczne przykłady z egzaminów

## Egzamin 2025 - Termin 1: Hotel

```csharp
public enum EnumStandard { economic = 200, high_standard = 350, luxury = 400, superb = 699 }
public class Room
{
    private string roomNumber;
    private bool available;
    private EnumStandard standard;
    private decimal roomPrice;
    private static int roomCode = 100;
    public Room(string standard)
    {
        Available = true;
        Enum.TryParse(standard, out this.standard);
        RoomNumber = $"{standard.Substring(0, 2).ToUpper()}/{roomCode}/{DateTime.Now:yy}";
        roomCode++;
        Random rand = new Random();
        roomPrice = (decimal)(int)this.standard + rand.Next(0, 100);
    }
    public void ChangeAvailability() => Available = !Available;
    public decimal ShowPrice() => roomPrice;
}
public class Hotel
{
    public Dictionary<string, Room> Rooms { get; private set; }
    public Dictionary<string, decimal> RoomRents { get; private set; }
    public void RentRoom(string roomNumber)
    {
        var room = Rooms[roomNumber];
        if (!room.Available) return;
        string key = $"{room}, rent date: {DateTime.Now:dd-MM-yy}";
        RoomRents.Add(key, room.ShowPrice());
        room.ChangeAvailability();
    }
    public decimal TotalGain() => RoomRents.Values.Sum();
}
```

## Egzamin 2025 - Termin 2: Toy Shop z IComparable

```csharp
public class Toy : IComparable<Toy>
{
    private static long toyIndex = 500;
    public readonly string toyCode;
    private HashSet<EnumToyKind> toyKinds;
    public Toy()
    {
        toyCode = $"{toyIndex:D6}//{DateTime.Now:MM-yyyy}";
        toyIndex++;
        toyKinds = new HashSet<EnumToyKind>();
    }
    public decimal ToyPrice() => 29.99m + toyKinds.Sum(k => (decimal)k);
    // Sortowanie: najpierw po liczbie rodzajów, potem po cenie (malejąco)
    public int CompareTo(Toy other)
    {
        if (other == null) return 1;
        int compare = this.toyKinds.Count.CompareTo(other.toyKinds.Count);
        if (compare != 0) return compare;
        return other.ToyPrice().CompareTo(this.ToyPrice());
    }
}
```

---

# Ściąga

```csharp
// ===== REGEX =====
const string pesel = @"^\d{11}$";
const string telefon = @"^\d{3}-\d{3}-\d{3}$";
Regex.IsMatch("12345678901", pesel);

// ===== FORMATOWANIE =====
numer.Substring(0, 3);              // Pierwsze 3 znaki
data.ToString("dd-MM-yyyy");
cena.ToString("F2");                // 123.45
id.ToString("D5");                  // 00123

// ===== DICTIONARY - sprawdź przed dodaniem! =====
if (!dict.ContainsKey(key))
    dict.Add(key, value);
var val = dict.GetValueOrDefault(key, defaultValue);

// ===== LISTA - operacje =====
lista.RemoveAll(x => x.Age < 18);
lista.FindAll(x => x.Active);
lista.Exists(x => x.Name == "Jan");

// ===== LINQ agregacje =====
int suma = lista.Sum(x => x.Value);
double srednia = lista.Average(x => x.Value);
var max = lista.Max(x => x.Value);
var grouped = lista.GroupBy(x => x.Type);

// ===== IComparable - dwa kryteria =====
public int CompareTo(T other)
{
    if (other == null) return 1;
    int result = this.Name.CompareTo(other.Name);
    if (result == 0) return this.Age.CompareTo(other.Age);
    return result;
}

// ===== IComparer - alternatywne sortowanie =====
public class CustomComparer : IComparer<T>
{
    public int Compare(T x, T y) => x.Value.CompareTo(y.Value);
}
lista.Sort(new CustomComparer());

// ===== XML Serializacja =====
XmlSerializer ser = new XmlSerializer(typeof(T));
using (StreamWriter w = new StreamWriter("file.xml"))
    ser.Serialize(w, obiekt);
    
// XML Deserializacja  
using (StreamReader r = new StreamReader("file.xml"))
    return (T)ser.Deserialize(r);  // RZUTOWANIE!
    
// ===== KONSTRUKTOR STATYCZNY =====
private static int counter;
static MyClass() { counter = 100; }

// ===== ENUM jako wartości =====
public enum Status { Low = 10, High = 100 }
int value = (int)Status.High;  // 100

// ===== ObservableCollection (WPF) =====
var collection = new ObservableCollection<T>();
listBox.ItemsSource = collection;
collection.Add(item);  // Auto-odświeżenie UI!
```

---
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoria.Labs
{
    public static class Lab1
    {
        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ĆWICZENIA 1 - WSZYSTKIE ZADANIA ===");
                Console.WriteLine("1. Zadanie 1 - Kalkulator");
                Console.WriteLine("2. Zadanie 2 - Suma i średnia liczb podzielnych przez 3 lub 5");
                Console.WriteLine("3. Zadanie 3 - Sprawdzanie cyfry 3");
                Console.WriteLine("4. Zadanie 4 - Zamiana słów miejscami");
                Console.WriteLine("5. Zadanie 5 - Pierwiastek cyfrowy");
                Console.WriteLine("6. Zadanie 6 - NWD (rekurencja)");
                Console.WriteLine("7. Zadanie 7 - Kompresja tekstu (rekurencja)");
                Console.WriteLine("8. Zadanie 8 - Sortowanie bąbelkowe");
                Console.WriteLine("9. Zadanie 9 - Liczby pierwsze w tablicy 2D");
                Console.WriteLine("10. Zadanie 10 - Operacje na dacie");
                Console.WriteLine("0. Powrót do menu głównego");
                Console.Write("Wybierz zadanie: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": 
                        Zadanie1(); 
                        break;
                    case "2": 
                        Zadanie2(); 
                        break;
                    case "3": 
                        Zadanie3();  
                        break;
                    case "4": 
                        Zadanie4();
                        break;
                    case "5": 
                        Zadanie5(); 
                        break;
                    case "6": 
                        Zadanie6(); 
                        break;
                    case "7": 
                        Zadanie7(); 
                        break;
                    case "8": 
                        Zadanie8(); 
                        break;
                    case "9": 
                        Zadanie9(); 
                        break;
                    case "10": 
                        Zadanie10(); 
                        break;
                    case "0": 
                        return;
                    default: 
                        Console.WriteLine("Nieprawidłowy wybór!"); 
                        break;
                }

                Console.WriteLine("\nlalalala");
                Console.ReadKey();
            }
        }

        // ZADANIE 1 - Kalkulator
        // static - pole statyczne dostepne z poziomu klasy programu
        // void - funkcja niczego nie zwraca
        static void Zadanie1()
        {
            // Wczytanie danych
            Console.WriteLine("\n=== ZADANIE 1 - Kalkulator ===");
            Console.WriteLine("Podaj wyrażenie jako a+b:");
            string wejscie = Console.ReadLine();

            if (string.IsNullOrEmpty(wejscie)) 
            {
                Console.WriteLine("Nic nie wpisałeś");
                return;
            }

            // Podział elementów
            string[] elements = wejscie.Split(' ',StringSplitOptions.RemoveEmptyEntries);   

            if(elements.Length != 3)
            {
                Console.WriteLine("Jest za dużo/mało elementów");
                return;
            }

            // Parsowanie elementów
            decimal el1, el2;
            if (!decimal.TryParse(elements[0], out el1))
            {
                Console.WriteLine("El1 do poprawy");
                return;
            }
            if (!decimal.TryParse (elements[2], out el2))
            {
                Console.WriteLine("El2 do poprawy");
                return;
            }

            // Kalkulator
            char op = elements[1][0];
            decimal wynik = 0;
            switch (op)
            {
                case '+':
                    wynik = el1 + el2;
                    break;
                case '-':
                    wynik = el1 - el2;
                    break;
                case '*':
                    wynik = el1 * el2;
                    break;
                case '/':
                    if (el2 == 0)
                    {
                        Console.WriteLine("zakaz szatanie, nie dzieli sie przez zero");
                        return;
                    }
                    else
                    {
                        wynik = el1 / el2;
                    }
                    break;

                default:
                    Console.WriteLine("Nieznany operator");
                    return;
            }
            Console.WriteLine($"Wynik to {wynik:F2}");
        }
  

        // ZADANIE 2 - Suma i średnia liczb podzielnych przez 3 lub 5
        static void Zadanie2()
        {
            Console.WriteLine("\n=== ZADANIE 2 - Suma i średnia liczb podzielnych przez 3 lub 5 ===");
            Console.Write("Podaj liczbę elementów (n): ");
            int n;
            int.TryParse(Console.ReadLine(), out n);

            int liczba;
            int suma = 0, ilosc = 0;
            for (int i=0; i<n; i++)
            {
                Console.WriteLine($"Podaj {i+1}-tą liczbe całkowitą:");
                if (!int.TryParse(Console.ReadLine(), out liczba))
                {
                    Console.WriteLine("Co ty mi tu wpisujesz");
                    return;
                }
                
                if (liczba % 3 == 0 || liczba % 5 == 0)
                {
                    suma += liczba;
                    ilosc++;
                }
            }
            float srednia = suma / ilosc;
            Console.WriteLine($"ilosc liczb = {ilosc}, suma = {suma}, średnia = {srednia}");
        }

        // ZADANIE 3 - Sprawdzanie cyfry 3
        // da sie to zrobic z liczba.Contains('3')
        static void Zadanie3()
        {
            Console.WriteLine("\n=== ZADANIE 3 - Sprawdzanie cyfry 3 ===");
            Console.Write("Podaj liczbę dodatnią: ");
            int n;
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Nie rozumiem co wpisales");
                return;
            }
            int temp = n;
            int cyfra;
            bool zawiera = false;
            while (temp>0)
            {
                cyfra = temp % 10;
                if(cyfra == 3)
                {
                    zawiera = true;
                    break;
                }
                temp = temp/10;
            }
            if (zawiera)
            {
                Console.WriteLine($"Znalazlam cyfre 3 w {n} ale jestem madra");
            }
            else
            {
                Console.WriteLine("Nic nie znalazlam");
            }  
        }

        // ZADANIE 4 - Zamiana słów miejscami
        static void Zadanie4()
        {
            Console.WriteLine("\n=== ZADANIE 4 - Zamiana słów miejscami ===");
            Console.WriteLine("Podaj tekst (dwa słowa oddzielone znakiem):");

            string input = Console.ReadLine();
            char seperator = ' ';

            foreach (char c in input)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    seperator = c;
                    break;
                }
            }

            string[] words = input.Split(seperator);
            if (words.Length != 2)
            {
                Console.WriteLine("Mamy problem koledzy");
            }
            else
            {
                Console.WriteLine($"{words[1]}{seperator}{words[0]}");
            }
        }

        // ZADANIE 5 - Pierwiastek cyfrowy
        // szczerze nie rozumiem ale tarnow lo tak mowi wiec tak jest
        static void Zadanie5()
        {
            Console.WriteLine("\n=== ZADANIE 5 - Pierwiastek cyfrowy ===");
            Console.Write("Podaj liczbe: ");

            if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
            {
                while (number >= 10)
                {
                    int sum = 0;
                    int temp = number;
                    while (temp > 0)
                    {
                        sum += temp % 10;
                        temp /= 10;
                    }
                    number = sum;
                }
                Console.WriteLine($"Pierwiastek cyfrowy: {number}");
            }
            else Console.WriteLine("Nieprawidlowa liczba lolol");
        }

        // ZADANIE 6 - NWD (rekurencja)
        static int NWD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return NWD(b, a % b);
            }
               
        }
        static void Zadanie6()
        {
            Console.WriteLine("\n=== ZADANIE 6 - NWD (rekurencja) ===");
            Console.Write("Podaj pierwszą liczbę: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Podaj drugą liczbę: ");
            int b = int.Parse(Console.ReadLine());

            if (a > 0 && b > 0)
            {
                int result = NWD(a, b);
                Console.WriteLine($"NWD({a}, {b}) = {result}");
            }
            else Console.WriteLine("liczby musząa byc dodatnie");
        }

       // BREAAAAAAAAAAAAAAK
       // szybka powtórka bo w glowie mi sie kreci

        // ZADANIE 7 - Kompresja tekstu (rekurencja - ale jak??)
        // dosl nie rozumiem - do poprawy
        static string komprestekst(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return kompres(text, 0, "");
        }

        static string kompres(string text, int i, string result)
        {
            if (i >= text.Length) return result;

            char currentChar = text[i]; //lapie aktualny znak
            int count = 1;

            while (i + count < text.Length && text[i + count] == currentChar)
                count++; //zbiera ilosc, te same znaki

            result += currentChar;
            if (count > 1) result += count.ToString();

            return kompres(text, i + count, result); //index to pozycja poczatkowa i ilosc znalezionych literek
        }
        static void Zadanie7()
        {
            Console.WriteLine("\n=== ZADANIE 7 - Kompresja tekstu (rekurencja) ===");
            Console.Write("poda tekst do kompresji: ");

            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                string xd = komprestekst(input);
                Console.WriteLine($"Skompresowany: {xd}");
            }
            else Console.WriteLine("nic nie wpisales");
        }



        // ZADANIE 8 - Sortowanie bąbelkowe yuppie
        static int[] GenerateRandomArray(int size)
        {
            Random rand = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
                array[i] = rand.Next(-100, 101);
            return array;
        }

        static void BubbleSort(int[] array)     
            //w pythonie jakos fajniej sie pisze
            // dobra bubblesort dziala tak ze sprawdza wartosc w kolejnym indeksie i gdy jest mniejsza to zamienia je miejscami - troche nieefektywne ale nie pamietam notacji
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
        static void Zadanie8()
        {
            Console.WriteLine("\n=== ZADANIE 8 - Sortowanie bąbelkowe ===");
            Console.Write("Podaj rozmiar tablicy: ");

            if (int.TryParse(Console.ReadLine(), out int size) && size > 0)
            {
                int[] array = GenerateRandomArray(size);
                Console.WriteLine("Przed sortowaniem: " + string.Join(", ", array));

                //teraz wielkie kino czy to zadziala
                BubbleSort(array);
                Console.WriteLine("Po sortowaniu: " + string.Join(", ", array));
            }
            else Console.WriteLine("Coś sie popsulo z rozmiarem tbh nwm");
        }



        // ZADANIE 9 - Liczby pierwsze w tablicy 2D
        // kolejne ktorego srednio rozumiem ale jest g chyba
        static int[,] GenerateRandom2DArray(int rows, int cols)
        {
            Random rand = new Random();
            int[,] tab = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    tab[i, j] = rand.Next(1, 1001);
            return tab;
        }

        static bool IsPrime(int number)
        {
            if (number < 2) return false; //0, 1 nie pierwsze 

            for (int i = 2; i <= Math.Sqrt(number); i++) //mniejsze niz pierwiastek, dalej nie ma sensu szukac
                if (number % i == 0) {
                    return false;
                }
            return true;
        }

        static void Zadanie9()
        {
            Console.WriteLine("\n=== ZADANIE 9 - Liczby pierwsze w tablicy 2D ===");
            Console.Write("wiersze: ");
            int wie = int.Parse(Console.ReadLine());
            Console.Write("kolumny: ");
            int kol = int.Parse(Console.ReadLine());

            int[,] array = GenerateRandom2DArray(wie, kol);

            Console.WriteLine("\nczerwone = liczby pierwsze??");
            for (int i = 0; i < wie; i++)
            {
                for (int j = 0; j < wie; j++)
                {
                    if (IsPrime(array[i, j])) //TRUE
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{array[i, j],4}");
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write($"{array[i, j],4}");
                    }
                }
                Console.WriteLine();
            }
        }

        

        // ZADANIE 10 - Operacje na dacie
        static void Zadanie10()
        {
            Console.WriteLine("\n=== ZADANIE 10 - Operacje na dacie ===");

            // Dni do końca roku
            DateTime dzis = DateTime.Today;
            DateTime koniecroku = new DateTime(dzis.Year, 12, 31);
            int ilee = (koniecroku - dzis).Days;
            Console.WriteLine($"Do końca roku: {ilee} days");

            // Dni przeżyte
            Console.Write("Podaj date urodzenia (dd.mm.yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime uro))
            {
                int dayslived = (dzis - uro).Days;
                Console.WriteLine($"Przezyles: {dayslived} dni, jezu gratulacje bracie");
            }
            else Console.WriteLine("zly format daty pls");
        } //ale przyjemne na koniec
    }
}

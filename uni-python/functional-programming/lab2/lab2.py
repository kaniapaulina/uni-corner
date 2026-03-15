
# import itertools
from itertools import accumulate
from operator import itemgetter
from itertools import groupby

# PROSTE FUNKCJE
# Zadanie 1
def mySrednia(*args):
    """
    Napisz funkcję mySrednia( ?? ), która przyjmuje dowolną liczbę argumentów (w tym argumenty liczbowe i tekstowe). Skonwertuj argumenty nie liczbowe na liczby (jeśli się nie da to pomiń) i policz średnią z podanych danych liczbowych.
    """
    liczby = []
    for arg in args:
        #if isinstance(arg, int):
        #    liczby.append(arg)
        try:
            z = float(arg)
            liczby.append(z)
        except ValueError:
            continue

    suma = sum(liczby)
    ilosc = len(liczby)
    srednia = suma/ilosc if ilosc > 0 else 0
    return srednia

def zad1():
    x = mySrednia(1, 2, 3, '2.0', 'a', 1.2)
    print(f"Wynik to: {x}")

    y = mySrednia('2.0', 'a', 1.2 )
    print(f"Wynik to: {y}")

    z = mySrednia('a', 'b')
    print(f"Wynik to: {z}")

# Zadanie 2
def mySredniaTup(*args):
    """
    Napisz funkcję mySredniaTup(), która policzy średnie: harmoniczną, geometryczną i arytmetyczną z liczb zawartych w tupli. Zwróć tuple zawierającą wyniki (w powyżej podanej kolejności).
    """
    liczby = []
    for arg in args:
        # if isinstance(arg, int):
        #    liczby.append(arg)
        try:
            z = float(arg)
            liczby.append(z)
        except ValueError:
            continue

    aryt = 0
    geom = 1
    harm = 0
    for n in liczby:
        aryt += n
        geom *= n
        harm += (1 / n)
    w1 = aryt / len(liczby) if len(liczby) > 0 else 0
    w2 = geom ** (1 / len(liczby)) if len(liczby) > 0 else 0
    w3 = len(liczby) / harm if harm > 0 else 0
    return (w1, w2, w3)

def zad2():
    x = mySredniaTup(1, 2, 3, '2.0', 'a', 1.2)
    print(f"Wynik to: {x}")

    y = mySredniaTup('2.0', 'a', 1.2 )
    print(f"Wynik to: {y}")

    z = mySredniaTup('a', 'b')
    print(f"Wynik to: {z}")

# Zadanie 3
def wykladnik(k):
    """
    Napisz funkcję wykladnik(), która zwraca pierwszą potęgę (wykładnik), dla którego 2^n jest większe od zadanej wartości k.
    """
    y = 0
    n = 0
    while y<k:
        y = 2**n
        n += 1

    return n

def zad3():
    x = wykladnik(4)
    print(f"Wykladnik dla ktorego 2**n jest wieksze od 4 to: {x}")

# FUNCKJE LAMBDA
def zad4():
    """
    Sortowanie: Wykorzystując funkcję lambda posortuj listę tupli według pierwszego elementu tupli z wykorzystaniem funkcji lambda (wykorzystaj funkcję sorted() oraz metodę .sort() dla listy). Następnie posortuj listę tupli według drugiego elementu tupli.
    """
    przedmiot_ocena = [('Matma', 6.0), ('Polski', 3.5), ('Angielski', 4.5), ('Informatyka', 6.0), ('Stat', 3.0)]
    przedmiot_ocena.sort(key = lambda x: x[0])
    print(f"Przedmioty wedlug nazwy: {przedmiot_ocena}")

    posortowane1 = sorted(przedmiot_ocena, key = lambda x: x[1])
    print(f"Przedmioty wedlug oceny: {posortowane1}")

    posortowane2 = sorted(przedmiot_ocena, key=lambda x: x[1], reverse=True)
    print(f"Przedmioty wedlug oceny: {posortowane2}")

def zad5():
    lista_slownikow = [
        {
            'producent': 'Nokia',
            'model': 216,
            'kolor': 'czarny'
        },
        {
            'producent': 'Mi Max',
            'model': 2,
            'kolor': 'Złoty'
        },
        {
            'producent': 'Samsung',
            'model': 7,
            'kolor': 'Niebieski'
        },
        {
            'producent': 'Mi Max',
            'model': 2,
            'kolor': 'Różowy'
        }
    ]

    lista_slownikow.sort(key = lambda x: (x['producent'], x['kolor']))
    print(lista_slownikow)

def zad6():
    """
    Sprawdzanie pierwszej litery: Napisz funkcję lambda sprawdzającą czy podany ciąg znaków zaczyna się od podanej litery.
    """
    czy_zaczyna_sie_do = lambda s, litera : s.startswith(litera)
    print(czy_zaczyna_sie_do('Mi Max', 'M'))
    print(czy_zaczyna_sie_do('Mi Max', 'm'))

def zad7():
    """
    Pobieranie danych z daty: Napisz funkcję lambda, która z podanej daty systemowej wypisze rok, miesiąc i dzień.
    """
    return None

def zad8():
    """
    Weryfikacja liczby: Napisz funkcję lambda, która dla podanego ciągu znaków sprawdzi, czy jest to liczba ( użyj funkcji isdigit() )
    """
    czy_liczba = lambda s: s.isdigit()
    print(czy_liczba('Mi Max'))
    print(czy_liczba('1234'))

# ITERATORY
def zad9():
    """
    Niech będzie dana lista lst = ['a','b','c','d','e','f']. Wykorzystując metody z modułu itertools utwórz listę lst_res = ['a', 'ab', 'abc', 'abcd', 'abcdef'].
    """
    lst = ['a', 'b', 'c', 'z', '1', '2', 'aa', 'bb']
    l_wynik = accumulate(lst, lambda x, y: x+y)
    print(l_wynik)
    print(next(l_wynik))
    print(next(l_wynik))
    print(list(l_wynik))

def zad10():
    """
    Wbudowana funkcja enumerate pobiera iteratable i zwraca iterator po parach (indeks, wartość) dla każdej wartości w źródle. Napisz funkcję, która wczytuje od użytkownika listę imion, a następnie wypisuje je w podanym obok formacie.
    """

def zad11():
    """
    Wykorzystując metody z modułu itertools utwórz listę złożoną z maksymalnych elementów wybranych z kolejnych 1, 2, 3, 4, … elementów listy. Na przykład, dla listy [5, 3, 6, 2, 1, 9, 1] wynikiem będzie lista [5, 5, 6, 6, 6, 9, 9] (5 = max(5), 5 = max(5, 3), 6 = max(5, 3 ,6), 6 = max(5, 3, 6, 2), itd.).
    """

def zad12():
    """
    Za pomocą funkcji map() sprawdź, które wyrazy na liście są palindromami.
    """
    slowa = ["kajak", "ala", "wilk", "radar", "dama", "zegar"]
    w = list(map(lambda word: word == word[::-1], slowa))
    print((w))

def zad13():
    """
    Za pomocą funkcji map() i filter() wypisz dużymi literami wszystkie palindromy na liście.
    """
    w = list( map(lambda word : word.upper() if word == word[::-1] else x,slowa))
    print(w)
    w = list(map(str.upper,filter(lambda word : word == word[::-1],slowa)))
    print(w)

def zad14():
    """
    Niech będzie dana lista [("Klasa A",11),("Klasa A",12),("Klasa A",5), ("Klasa B",3),("Klasa B",15),("Klasa B",10),("Klasa B",2)]. Pierwszy element krotki to klasa a drugi to ilość. Bez użycia pętli oblicz, ile jest sumarycznie elementów w każdej klasie.
    """
    dane = [("Klasa A", 11), ("Klasa A", 12), ("Klasa A", 5), ("Klasa B", 3), ("Klasa B", 15), ("Klasa B", 10),
            ("Klasa B", 2)]

    dane.sort(key=itemgetter(0))
    suma_klas = {k: sum(v[1] for v in g) for k, g in groupby(dane, key=itemgetter(0))}
    print(suma_klas)

def zad15():
    """
    Wypisz pary elementów z dwóch list : numbers = [1, 2, 3, 4, 5, 6], letters = ['a', 'b', 'c', 'd', 'e', 'f'] w postaci wynik: 1 : 'a', 2 : 'b', …
    """

def zad16():
    """
    Zaimplementuj iterator zwracający n elementów ciągu Fibonacciego. Zauważ, że iterator jest klasą, która przyjmuje w konstruktorze n, implementuje protokół iteratora (__iter__, __next__), po wyczerpaniu danych zgłasza StopIteration.
    """

def zad17():
    """
    Zaimplementuj funkcję pipeline(data, *functions), która będzie reprezentowała strumień transformacji, czyli przyjmie argumenty data jako obiekt iterable i do nich zaaplikuje kolejne transformacje z *functions. Wynik ma być zwracany jako iterator (lazy) bez zapisywania wyników w liście.
    """

# GENERATORY
def zad18():
    """
    Zaimplementuj generator, który zwraca pierwszą potęgę (wykładnik), dla którego 2^n jest większe od zadanej wartości k.
    """

def zad19():
    """
    Zaimplementuj klasę reprezentującą węzeł drzewa binarnego (Node) oraz iterator przechodzący drzewo w porządku in-order. Porządek inorder oznacza: lewe poddrzewo → korzeń → prawe poddrzewo. Wykorzystaj generatory (generator yield i yield from), bez ręcznego pisania klasy iteratora. Wpisz drzewo i wypisz wierzchołki. Dla podanego drzewa powinien wypisać ciąg 1,2,3,4,5,6,7
    """

def zad20():
    """
    Zaimplementuj generator sliding_window, który przyjmuje iterable i rozmiar okna k jako argumenty, a zwraca kolejne k-elementowe podsekwencje obiektu iterable. Przykład: [1,2,3,4,5,6], k=3 → (1,2,3), (2,3,4), (3,4,5), (4,5,6)
    """

def zad21():
    """
    Zaimplementuj generator perfect_numbers zwracający liczby doskonałe mniejsze od n.
    """

def zad22():
    """
    Napisz generator, który generuje kolejne potęgi dwójki od 1 do n (n ma być parametrem generatora). Do potęgowania wykorzystaj przesunięcie bitowe.
    """

def zad23():
    """
    Napisz generator, który będzie zwracał kolejne cyfry liczby podanej od użytkownika.
Wyznacz kilka pierwszych elementów generatora. Wyznacz sumę wszystkich cyfr.
    """

def zad24():
    """
    Napisz generator naturals, który będzie zwracał nieskończony strumień liczb naturalnych. Napisz dodatkowy generator take, który będzie pobierał n liczb z podanego strumienia.
    """

def zad25():
    """
    Napisz generator, który przyjmuje inny generator i zwraca tylko liczby parzyste z jego wyników.
    """


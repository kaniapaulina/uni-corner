import math

# Zadanie 11. Proszę napisać program wypisujący podzielniki liczby.
def zad11():
    liczba = int(input("Podaj liczbe: "))
    dzielnik = 1
    while (dzielnik <= liczba // 2):
        if liczba % dzielnik == 0:
            print(dzielnik, end=" ")
        dzielnik += 1


# Zadanie 12. Proszę napisać program wypisujący rozkład liczby na czynniki pierwsze.
def zad12():
    liczba = int(input("Podaj liczbe: "))
    dzielnik = 2
    while dzielnik ** 2 <= liczba:
        while liczba % dzielnik == 0:
            print(dzielnik, end=" ")
            liczba /= dzielnik
        dzielnik += 1

    if liczba > 1:
        print(liczba)


# Zadanie 13. Liczba doskonała to liczba równa sumie swoich podzielników właściwych (mniejszych od jej samej), na przykład 6 = 1 + 2 + 3. Proszę napisać program wyszukujący liczby doskonałe mniejsze od miliona.
def dzielnik(liczba):
    dzielnik = 2
    suma = 1
    while dzielnik ** 2 < liczba:
        if liczba % dzielnik == 0:
            suma += dzielnik + (liczba // dzielnik)
        dzielnik += 1

    if dzielnik * dzielnik == liczba:
        suma += liczba
    return suma


def zad13():
    for i in range(1, 100):
        if i == dzielnik(i):
            print(i, end=" ")


# Zadanie 14. Dwie różne liczby nazywamy zaprzyjaźnionymi gdy każda jest równa sumie podzielników właściwych drugiej liczby, na przykład 220 i 284. Proszę napisać program wyszukujący liczby zaprzyjaźnione mniejsze od miliona
def podzielnik(liczba):
    dzielnik = 2
    suma = 1
    while dzielnik ** 2 < liczba:
        if liczba % dzielnik == 0:
            suma += dzielnik + (liczba // dzielnik)
        dzielnik += 1

    if dzielnik * dzielnik == liczba:
        suma += liczba
    return suma

def zad14():
    for i in range(1, 10000):
        sum1 = podzielnik(i)
        if podzielnik(sum1) == i and i > sum1:
            print(i, sum1)


# Zadanie 15. Proszę napisać program wyznaczający największy wspólny dzielnik 3 zadanych liczb naturalnych.
def nwd(a, b):
    while a != b:
        if b > a:
            b = b - a
        else:
            a = a - b
    return a

def nwd_alt(a, b):
    while b > 0:
        a, b = b, a % b
    return a

def nwd3(a, b, c):
    print(nwd_alt(nwd_alt(a, b), c))

def zad15():
    nwd3(6, 9, 12)


#Zadanie 16. Proszę napisać program wyznaczający najmniejszą wspólną wielokrotność 3 zadanych liczb naturalnych.
def nww(a, b):
    x = a*b/nwd(a,b)
    print(f"dla {a} i {b} nww: {x}")
def zad16():
    nww(24,36)

#Zadanie 17. Proszę napisać program obliczający wartości cos(x) z rozwinięcia w szereg Maclaurina.
def silnia(n):
    result = 1
    for i in range(1, n+1):
        result *= i
    return result

def zad17(x):
    cos = 0
    for i in range(0,20):
        cos += ((-1)**i)/(silnia(2*i))*(x**(2*i))
    return print(f"cos({x}) = {cos}")

#Zadanie 18. Nieskończony iloczyn (patrz zad) ma wartość 2/π. Proszę napisać program korzystający z tej zależności i wyznaczający wartość π.
def zad18():
    a = 0.5 ** (1 / 2)
    result = 1
    for i in range(1, 40):
        result *= a
        a = (0.5 + 0.5 * a) ** (1 / 2)
    pi = 2/result
    print(f"π = {pi}")
    print(f"wedlug math: π = {format(math.pi, '.10g')}")


#Zadanie 19. Dany jest ciąg określony wzorem: An+1 = (An mod 2) ∗ (3 ∗ An + 1) + (1 − An mod 2) ∗ An/2, Startując z dowolnej liczby naturalnej > 1 ciąg ten osiąga wartość 1. Proszę napisać program, który znajdzie wyraz początkowy z przedziału 2-10000 dla którego wartość 1 jest osiągalna po największej liczbie kroków.
def an1(a):
    return ((a%2)*(3*a+1)+(1-a%2)*a/2)

def zad19():
    max = 1
    num = 2
    for i in range(2,10000+1):
        an = i
        kroki = 0
        #while an != 1: - nie da rady bo konkuter ma autysm i zle policzy
        while abs(an-1)>0.0001:
            an = an1(an)
            kroki += 1
        if kroki>max:
            max = kroki
            num = i
    print(num, max)

#Zadanie 20. Dla ciągu z poprzedniego zadania proszę znaleźć najmniejszy wyraz początkowy N, dla którego ciąg osiąga wartość 1 dokładnie po N krokach.
def zad20():
    for i in range(2,1000):
        an = i
        kroki = 0
        while abs(an-1)>0.0001:
            an = an1(an)
            kroki += 1
        if kroki == i:
            return print(i)
    return None



if __name__ == "__main__":
    print("Tu sie dzieje czarna magia\n")
    zad20()


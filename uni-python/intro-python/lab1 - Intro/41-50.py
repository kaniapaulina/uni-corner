from math import factorial
from math import sqrt
import itertools

# Zadanie 41. Napisać program, który wyznacza ostatnia niezerową cyfrę liczby N!. Program powinien działać dla N rzędu 10100. Komentarz: Rozwiązanie tego zadania w języku Python jest proste, trochę większym wyzwaniem jest rozwiązanie w języku C/C++
def zad41():
    n = int(input("Podaj liczbe N: "))
    silnia = wynik = 1
    for i in range(1, n + 1):
        silnia *= i
        wynik *= i
    while wynik % 10 == 0:
        wynik //= 10
    wynik %= 10
    print(f"ostatia niezerowa cyfra {n}! = {silnia} to {wynik}")

def zad41_alt():
    n = int(input("Podaj liczbe N: "))
    silnia = factorial(n) #factorial to silnia basically
    while silnia % 10 == 0:
        silnia //= 10
    print(f"ostatia niezerowa cyfra {n}! = {factorial(n)} to {silnia%10} ")

def zad41_alt2(n):
    silnia, d = divmod(factorial(n), 10) #divmod(x,y) zwraza x//y i x%y jako (iloraz, reszta)
    while d == 0:
        silnia, d = divmod(silnia,10)
    return d


 #Zadanie 42. Proszę napisać funkcję, która zwraca wartość True gdy dwie liczby są zbudowane z tych samych cyfr (na przykład: 123 i 231, 5749 i 4597) i wartość False w przeciwnym przypadku.
def zad42(x,y):
    x = sorted(str(x))
    y = sorted(str(y))
    if x == y:
        return True
    else:
        return False

def zad42_alt(x,y):
    return sorted(str(x)) == sorted(str(y))

def zad42_alt2(x, y):
    x = str(x)
    y = str(y)
    if len(x) != len(y):
        return False

    for i in range(len(x)):
        b = 1
        for j in range(len(y)):
            if x[i] == y[j]:
                b = 0
                break
        if b:
            return False
    return True


 #Zadanie 43. Dla pewnej N-cyfrowej liczby naturalnej obliczono sumę N-tych potęg cyfr tej liczby otrzymując kolejną liczbę N-cyfrową. Na przykład dla liczb: 354, 543, 600, ... suma ta wynosi 216. Niestety pierwotna liczba zaginęła ale wiadomo, że była to największa z możliwych takich liczb. Proszę napisać program, który na podstawie zachowanej sumy wyznaczy pierwotną liczbę
def zad43(S):
    n = 1
    while 10**n <= S:
        n += 1      #liczy ile cyfr jest w Sumie -> S=216, n=3
    start = 10**(n-1)       #100
    end = 10**n - 1         #999

    for liczba in range(end, start, -1):
        s_poteg = 0
        nosnik = liczba
        while nosnik > 0:
            s_poteg += (nosnik%10) ** n
            nosnik //= 10
        if s_poteg == S:
            return liczba
    return None


 #Zadanie 44. Liczbę pierwszą będącą palindromem nazywamy “palindromem pierwszym”. Liczbę nazywamy “super palindromem pierwszym” jeżeli podczas odrzucania parami skrajnych cyfr do końca pozostaje ona palindromem pierwszym. Na przykład, liczba 373929373 jest super palindromem pierwszym bo 373929373, 7392937, 39293, 929, 2 są palindromami pierwszymi. Początkowymi super palindromami pierwszymi są: 2, 3, 5, 7, 11, 131, 151. Proszę napisać program, który wylicza ile jest super palindromów pierwszych mniejszych od zadanej liczby n.
def is_prime(x):
    dzielnik = 2
    while dzielnik ** 2 <= x:
        if x % dzielnik == 0:
            return False
        dzielnik += 1
    return True

def is_palindrom(x):
    x = str(x)
    y = x[::-1] #odwraca stringa
    return x == y

def delete(x):
    x = str(x)
    l = len(x)
    x = x[1:l-1]
    return int(x)

def is_superpalindrom(x):
    if x == 11:
        return True
    if len(str(x)) == 1:
        print(x)
        return is_prime(x)
    else:
        if is_prime(x) and is_palindrom(x):
            print(x)
            return is_superpalindrom(delete(x))

def zad44(n):
    if is_superpalindrom(n):
        print(f"{n} jest supi palindromem")
    else:
        print("dupa lol")


 #Zadanie 45. Dane są dwie liczby naturalne, m i n. Proszę napisać program, który wyznacza sumę n kolejnych cyfr po przecinku rozwinięcia dziesiętnego liczby sqrt(m)
def zad45(m,n):
    x = sqrt(m)
    c = int(x//1)
    x = str(x)
    lenc = len(str(c)) + 1

    suma = 0
    for i in range(lenc, n+lenc):
        suma += int(x[i])
    print(f"{x} suma {n} liczb po przecinku-> {suma}")

def zad45_alt(m, n):
    rozwin = int(sqrt(m)* 10**n)
    suma = 0
    for _ in range(n):
        rozwin, d = divmod(rozwin, 10) #rozwin - iloraz, d - reszta
        suma += d
    return suma

 #Zadanie 46. Mając daną dodatnią liczbę całkowitą N , stwórzmy nową liczbę dodając kwadraty cyfr liczby N . Można udowodnić, że postępując w ten sposób wielokrotnie otrzymamy w końcu wynik 1 lub 4.
 # Przykład: 13 = 12 + 32 =1+9=10(Krok1)10=12+02=1+0=1(Krok2,kończymy iterację ponieważ uzyskaliśmy liczbę 1) Jeżeli w opisanej powyżej procedurze uzyskamy wynik 1, to liczbę N nazywamy “jednokwadratową”. Proszę napisać program, który znajduje K-tą liczbę w zadanym przedziale [L, U ], która jest jednocześnie jedno-kwadratowa i pierwsza.
#nie rozumiem nie robie

 #Zadanie 47. Wybieramy dodatnią liczbę całkowitą X. Z liczby X wykreślamy ostatnią cyfrę. Postępujemy tak, aż usuniemy wszystkie cyfry liczby X. Następnie sumujemy wszystkie powstałe w ten sposób liczby, włączając liczbę X. Na przykład, jeżeli wybraliśmy X = 1234 to w kolejnych krokach otrzymamy odpowiednio liczby 1234, 123, 12, 1. Ich suma to 1370. Mamy daną liczbę całkowitą dodatnią S. Proszę napisać program, który znajduje liczbę X taką, że powyżej opisana procedura daje sumę S. Można pokazać, że dla dowolnej dodatniej liczby S istnieje co najwyżej jedna taka wartość X. Jeżeli nie ma takiego X, program powinien wypisać -1.
#tez nie robie - moze dp tego wroce

 #Zadanie 48. Proszę napisać program wyznaczający najmniejszą liczbę pierwszą o sumie cyfr równej N, której cyfry są w porządku rosnącym
def zad48(n):
    start = 10 ** (n//9)
    end = 10 ** n
    for num in range(start, end):
        digits= list(map(int, str(num)))
        if sum(digits) == n and digits == sorted(digits) and is_prime(num):
            return num
    return None


 #Zadanie 49. Proszę znaleźć najmniejszą liczbę pierwszą, której suma cyfr wynosi 101, a cyfry są w porządku nierosnącym
def zad49():
    for length in range(10, 16):
        for digit_tuple in itertools.combinations_with_replacement('987654321', length):
            num_str = ''.join(digit_tuple)
            num = int(num_str)
            if sum(int(d) for d in digit_tuple) == 101 and is_prime(num):
                return num
    return None

#albo
def prime( x ) :
    if x<2 :
        return False
    i=2
    while i * i <= x :
        if x % i == 0 :
            return False
        i += 1
    return True
#end def

def suma( x ) :
    s=0
    while x > 0 :
        s += x%10
        x //= 10
    return s
#end def

def is_rising ( n ) :
    while n > 0:
        t = n % 10
        n //= 10
        if n % 10 >= t :
            return True
    return False
#end def

def not_rising(x):

    while x > 0:
        t = x % 10
        x //= 10
        if x == 0 :
            break
        if t > x % 10 :
            return False
    return True

def zad49_alt():
    i = 11
    while True:
        if prime(i) and not_rising(i) and suma(i) == 101:
            return i
        i += 1


 #Zadanie 50. Pewnych liczb nie można przedstawić jako sumy elementów spójnych fragmentów ciągu Fibonacciego, np. 9,14,15,17,22. Proszę napisać program, który wczytuje liczbę naturalną n, wylicza i wypisuje następną taką liczbę większą od n. Można założyć, że 0 < n < 1000.
#fibonacci zostaw mnie


if __name__ == "__main__":
    print("Zabijam sie\n")
    print(zad42_alt2(345, 435))

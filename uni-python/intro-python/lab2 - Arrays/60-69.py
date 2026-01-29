from math import sqrt
import random

#Zadanie 60. Napisać funkcję zamieniającą i wypisującą liczbę naturalną na system o podstawie 2-16.
from unittest import result
def zad60_zle(n):
    if n == 0:
        return n
    two = []
    while n > 0:
        two.append(n % 2)
        n //= 2

    brak = len(two) % 4
    for _ in range(4-brak):
        two.append(0)
    print(two.reverse())
    #ta funkcja zamienia liczbe dziesietna na dwojkową ale w bardzo uposledzony sposob

def zad60(n, base):
    if n == 0:
        return "0"
    if base < 2 or base > 16:
        return "zla baza"

    digits = list("0123456789ABCDEF")
    result = []
    num = n
    while num > 0:
        result.append(digits[num%base])
        num //= base

    return ''.join(result[::-1])


#Zadanie 61. Napisać funkcje sprawdzającą, czy dwie liczby naturalne są one zbudowane z takich samych cyfr, np. 123 i 321, 1255 i 5125, 11000 i 10001.
def count_digits(n):
    count = [0] * 10
    for digit in str(n):
        count[int(digit)] += 1
    return count

def zad61(x,y):
    print(sorted(str(x)) == sorted(str(y)))
    print(count_digits(x) == count_digits(y))

#Zadanie 62. Napisać program generujący i wypisujący liczby pierwsze mniejsze od N metodą Sita Eratostenesa.
def zad62(n):
    is_prime = [True] * (n+1)
    for i in range(2, n+1):
        if is_prime[i]:
            rep = 2
            j = i
            while j*rep < n:
                is_prime[j*rep] = False
                rep += 1

            #for i in range(i+i, n+1, i):
                #is_prime[i] = False
        else:
            continue
        print(i, is_prime[i])

#Zadanie 63. Proszę napisać program obliczający i wypisujący stałą e z rozwinięcia w szereg e = 1/0! + 1/1! +1/2! +1/3!+... z dokładnością N cyfr dziesiętnych (N jest rzędu 1000).

#Zadanie 64. Napisać program, który wczytuje wprowadzany z klawiatury ciąg liczb naturalnych zakończonych zerem stanowiącym wyłącznie znacznik końca danych. Program powinien wypisać 10 co do wielkości wartość, jaka wystąpiła w ciągu. Można założyć, że w ciągu znajduje się wystarczająca liczba elementów.
def zad64():
    print("jezu co")

#Zadanie 65. Napisać program wypełniający N-elementową tablicę T liczbami naturalnymi 1-1000 i sprawdzający czy każdy element tablicy zawiera co najmniej jedną cyfrę nieparzystą.
def zad65(n):
    tab = []
    for _ in range(n):
        tab.append(random.randint(1,1000))
    print(tab)
    count = 0
    for num in tab:
        while num > 0:
            reszta = num % 10
            if reszta % 2 != 0:
                count += 1
                break
            num //= 10
    if count == n:
        print("Sa liczby nieparzyste")
    else:
        print("No i co to ma byc")


#Zadanie 66. Napisać program wypełniający N-elementową tablicę T liczbami pseudolosowymi z zakresu 1-1000 i sprawdzający, czy istnieje element tablicy zawierający wyłącznie cyfry nieparzyste.
def parzyste(num):
    while num > 0:
        reszta = num % 10
        if reszta % 2 == 0:
            return False
        num //= 10
    return True

def zad66(n):
    tab = []
    for _ in range(n):
        tab.append(random.randint(1, 1000))
    print(tab)

    for num in tab:
        if parzyste(num):
            return print("oho cos jest")
    return print("No nic nie ma")

#Zadanie 67. Dana jest N-elementowa tablica T zawierająca liczby naturalne. W tablicy możemy przeskoczyć z pola o indeksie k o n pól w prawo jeżeli wartość n jest czynnikiem pierwszym liczby T[k]. Napisać funkcję sprawdzającą czy jest możliwe przejście z pierwszego pola tablicy na ostatnie pole.

#Zadanie 68. Napisać funkcję, która dla N-elementowej tablicy T wypełnionej liczbami naturalnym wyznacza długość najdłuższego, spójnego podciągu rosnącego.

#Zadanie 69. Napisać funkcję, która dla N-elementowej tablicy T wypełnionej liczbami naturalnym wyznacza długość najdłuższego, spójnego podciągu arytmetycznego.


if __name__ == "__main__":
    zad66(4)
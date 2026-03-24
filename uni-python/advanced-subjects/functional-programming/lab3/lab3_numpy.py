import random

import numpy as np
from numpy import random
from pandas.core.computation.expressions import where


def zad1():
    """
    Zadanie 1. Utwórz tablicę numpy nxn zawierającą liczby losowe o rozkładzie normalnym o średniej 3 i odchyleniu standardowym 2. Następnie oblicz:
    a) Wyznacznik macierzy
    b) Macierz odwrotną / pseudo-odwrotną
    c) Macierz transponowaną
    d) Wypisz wartości własne i wektory własne macierzy
    """
    n = int(input("n: "))
    matrix = random.normal(loc=3, scale=2, size=(n,n))
    print(matrix)

    print("\n a) \n")
    det = np.linalg.det(matrix)
    print(det)

    print("\n b) \n")
    inverse = np.linalg.inv(matrix)
    print(inverse)

    print("\n c) \n")
    transpose = np.transpose(matrix)
    print(transpose)

    print("\n d) \n")
    eigenvalues, eigenvectors = np.linalg.eig(matrix)
    print(eigenvalues)
    print(eigenvectors)

def zad2():
    """
    Zadanie 2. Napisz funkcję, która zlicza częstotliwość występowania poszczególnych wartości w tablicy numpy.
    """
    tablica = np.array([x for x in random.randint(1, 10, 10)])

    cnt = {}
    for i in range(1, 11):
        cnt[i] = 0

    for x in tablica:
        if x in cnt:
            cnt[x] += 1

    print(f"{tablica}\n")
    print(cnt)

def zad3():
    """
    Zadanie 3. Napisz funkcję, która zamienia wszystkie wartości ujemne na zero w tablicy numpy oraz wszystkie wartości NaN na średnią z kolumn w tablicy numpy.
    """
    tablica = np.array([x for x in random.randint(-10, 10, (3,3))])
    arr = tablica.copy()
    """
    tablica_rows, tablica_cols = np.shape(tablica)
    srednia = [0]*tablica_cols

    for x in tablica:
        #i = 0
        for r in x:
            if r<0:
                r = 0
            #srednia[i] += r
            #i += 1

    for x in np.nditer(tablica):
        if x<0:
            x = 0
    """
    arr[arr < 0] = 0
    #np.where(tablica < 0, 0, tablica) - dziala
    #np.place(tablica, tablica<0, 0) - dziala
    srednia = np.nanmean(arr, axis = 0)
    np.where(np.isnan(arr), srednia, arr)

    print(srednia)
    print(tablica)

def zad4():
    """
    Zadanie 4. Wczytaj lub utwórz przykładową tablicę numpy o rozmiarze (100, 5), a następnie:
        • Znormalizuj (na podstawie minimum i maksimum w każdej kolumnie) dane w każdej kolumnie w taki sposób, aby wartości były w zakresie [0, 1].
        • Zwróć znormalizowaną tablicę oraz średnią wartość każdej kolumny po normalizacji.
    """
    tablica = np.array(random.randint(-10, 10, (100,5)))
    arr = tablica.copy()

    maks = np.max(arr, axis = 0)
    mini = np.min(arr, axis = 0)

    norm_arr = (arr-mini)/(maks-mini)
    print(norm_arr)

    srednia = np.mean(norm_arr, axis = 0)
    print(srednia)

def zad5():
    """
    Zadanie 5. Utwórz tablicę numpy o wymiarach (50, 10), w której każda kolumna reprezentuje różne cechy, a następnie
        • Oblicz macierz korelacji pomiędzy kolumnami danych.
        • Znajdź parę kolumn, która ma najwyższą wartość korelacji dodatniej i parę z najwyższą korelacją ujemną.
    """
    tablica = np.array(random.randint(-10, 10, (50, 10)))

def zad6():
    """
    Zadanie 6. Obraz może być przedstawiony jako tablica numpy, w której piksele są wartościami numerycznymi. Napisz operacje przetwarzania obrazu, takie jak konwersja do odcieni szarości, rozmycie i wykrywanie krawędzi:
        • Wczytaj obraz i przekształć go w tablicę numpy (każdy piksel ma trzy wartości: R, G, B).
        • Przekształć obraz do odcieni szarości (wykorzystując odpowiednie wagi dla kanałów R, G, B).
        • Zastosuj rozmycie obrazu przy użyciu splotu macierzy (np. użyj macierzy Gaussa do rozmycia).
    """


def play():
    match int(input("Podaj numer zadania: ")):
        case 1:
            zad1()
        case 2:
            zad2()
        case 3:
            zad3()
        case 4:
            zad4()
        case 5:
            zad5()
        case 6:
            zad6()
        case _:
            print("Podałes zły numer")

play()





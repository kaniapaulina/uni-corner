import random

import numpy as np
from numpy import random

from PIL import Image
from PIL import ImageFilter


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
    # np.linalg.inv rzuci blad jesli macierz jest osobliwa, uzyj np.linalg.pinv()
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

    cnt = {i:0 for i in range(1, 11)}
    for x in tablica:
        if x in cnt:
            cnt[x] += 1

    print(f"{tablica}\n")
    print(cnt)

    print(" - - - ")

    liczba, ilosc = np.unique(tablica, return_counts=True)
    for i in range(len(liczba)):
        print(f"{liczba[i]}: {ilosc[i]}")
    print(" - - - ")
    wynik = {liczba[i].item():ilosc[i].item() for i in range(len(liczba))}
    print(wynik)

def zad3():
    """
    Zadanie 3. Napisz funkcję, która zamienia wszystkie wartości ujemne na zero w tablicy numpy oraz wszystkie wartości NaN na średnią z kolumn w tablicy numpy.
    """
    tablica = np.array([x for x in random.randint(-10, 10, (3,3))])
    arr = tablica.copy()

    arr = arr.astype(float)
    arr[1, 1] = np.nan
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
    wynik = np.where(np.isnan(arr), srednia, arr)

    print(srednia)
    print(wynik)

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
    korelacja = np.corrcoef(tablica, rowvar = False)

    for i in range((korelacja.shape[0])):
        korelacja[i][i] = 0

    print(korelacja)
    """
    max = korelacja[0][0]
    maxrow = 0
    maxcol = 0
    min = korelacja[0][0]
    minrow = 0
    mincol = 0
    for col in range(korelacja.shape[0]):
        for row in range(korelacja.shape[1]):
            if abs(korelacja[row][col])>max:
                max = korelacja[row][col]
                maxcol = col
                maxrow = row
            if abs(korelacja[row][col])<min:
                min = korelacja[row][col]
                mincol = col
                minrow = row
    """
    print(np.unravel_index(np.argmax(korelacja), shape=korelacja.shape))

def zad6():
    """
    Zadanie 6. Obraz może być przedstawiony jako tablica numpy, w której piksele są wartościami numerycznymi. Napisz operacje przetwarzania obrazu, takie jak konwersja do odcieni szarości, rozmycie i wykrywanie krawędzi:
        • Wczytaj obraz i przekształć go w tablicę numpy (każdy piksel ma trzy wartości: R, G, B).
        • Przekształć obraz do odcieni szarości (wykorzystując odpowiednie wagi dla kanałów R, G, B).
        • Zastosuj rozmycie obrazu przy użyciu splotu macierzy (np. użyj macierzy Gaussa do rozmycia).
    """
    im = Image.open("jołchan.png")

    img = np.array(im)
    print(img.shape)

    def grayscale(img):
        #img = np.dot(img[:, :,  0], 0.2126)
        #img = np.dot(img[:, :, 1], 0.7152)
        #img = np.dot(img[:, :, 2], 0.0722)
        img.astype(np.uint8)
        wynik = np.dot(img, [0.2126, 0.7152, 0.0722])
        im = Image.fromarray(wynik)
        im.show()

    def rozmycie(img):
        wynik = np.zeros_like(img)
        for x in range(0, img.shape[0]-1):
            for y in range(0, img.shape[1]-1):
                fragment = img[x-1:x+2, y-1:y+2]
                kernel = np.array([[1/3, 1/3, 1/3], [1/3, 1/3, 1/3], [0, 0, 0]])
                wynik[x, y] = np.sum(fragment*kernel)
        wynik.astype(np.uint8)
        im = Image.fromarray(wynik)
        im.show()

    def rozmycie_alt(im):
        img = Image.fromarray(im)
        blurred = img.filter(ImageFilter.GaussianBlur(radius=5))
        blurred.show()

    rozmycie(img)
    rozmycie_alt(img)

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





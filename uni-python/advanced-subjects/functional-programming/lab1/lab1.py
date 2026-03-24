import math
import random
import string

# INPUT OUTPUT
def zad1():
    """
    Zadanie 1.Napisz program proszący użytkownika o podanie dwóch liczb a i b. Wypisz w konsoli ich sumę, różnicę, iloczyn, iloraz oraz pierwiastek(a+b)
    """
    a = int(input("Podaj liczbe a: "))
    b = int(input("Podaj liczbe b: "))

    print(f"Suma: {a+b}")
    print(f"Różnica: {a-b}")
    print(f"Iloczyn: {a*b}")
    print(f"Iloraz: {a/b}")
    print(f"Wyrażenie: {math.sqrt(a+b)}")

def zad2():
    """
    Zadanie 2.Napisz program zgadywanka, który polega na wylosowaniu przez komputer liczby od 1 do 5, a użytkownik zgaduje jaka to liczba.
    """
    goal = random.randint(1, 5)
    guess = int(input("Zgadnij liczbe z przedziału 1-5: "))

    if guess == goal: print("Zgadłeś!")
    else: print(":(")

# LISTY
def zad3():
    """
    Zadanie 3.Wygeneruj 10 elementową listę (nums) zawierającą całkowite liczby losowe z przedziału [2,8]. Napisz program
        a) wypisujący wszystkie elementy listy nums wraz z indeksami
        b) usuwający z listy nums liczby nieparzyste,
        c) zamieniający wartości elementów nieparzystych w nums na ich indeksy (uwaga jeśli wartości się powtarzają to brany będzie indeks której wartości?)
        d) usunie z listy nums wszystkie wystąpienia liczb 2 i 3,
        e) po każdej liczbie podzielnej przez 3 w liście nums wstawi nowy dodatkowy element o wartości 15.
    """
    """
    nums = []
    for i in range(10):
        nums.append(random.randint(2, 8))
    """
    nums = [ random.randint(2, 8) for _ in range(10) ]
    print(nums)

    print("Podpunkt a:")
    """
    for i in range(len(nums)):
        #print(f"",_, " - index:", nums.index(_)) - nie dziala bo liczby
        print(f"", nums[i]," - index:", i)
    """
    for (i, num) in enumerate(nums, start=0):
        print(f"[{i}] {num}")
    print("")

    print("Podpunkt b:")
    parzyste = [n for n in nums if n%2 == 0]
    print(parzyste)
    """
    parzyste = list(filter(lambda n: n%2 == 0, nums))
    for n in nums:
        if(n%2 == 0):
            nums.remove(n)
    print(nums)
    """
    print("")

    print("Podpunkt c:")
    print(f"Przed: {nums}")
    nums_test = nums.copy()
    for n in nums_test:
        if(n%2 == 1):
            #nums[nums.index(n)] = nums.index(n)
            i = nums_test.index(n)
            del nums_test[i]
            nums_test.insert(i, i)
    print(f"Po: {nums_test}")
    print("")

    print("Podpunkt d:")
    print(f"Przed: {nums}")
    without_2_and_3 = [n for n in nums if n!=2 and n!=3]
    print(f"Po: {without_2_and_3}")
    print("")

    print("Podpunkt e:")
    nums_test2 = nums
    for n in nums_test2:
        if n % 3 == 0:
            j = 15
            i = nums_test2.index(n)
            nums_test2.insert(i+1, j)
    print(f"Po: {nums_test2}")

# TUPLE
def zad4():
    """
    Zadanie 4.Wygeneruj 10 elementową tuplę (tnums) zawierającą całkowite liczby losowe z przedziału [2,15]. Napisz program:
        a) wypisujący wszystkie elementy tupli tnums wraz z indeksami
        b) wyznaczający średnie: harmoniczną, geometryczną i arytmetyczną z liczb zawartych w tupli tnums,
        c) zliczy wszystkie wystąpienia liczby 3 i 5 w tupli tnums
    """
    tnums = tuple([random.randint(2, 15) for _ in range(10)])
    print(tnums)

    print("Podpunkt a:")
    for (i, tnum) in enumerate(tnums):
        print(f"[{i}] {tnum}")
    print("")

    print("Podpunkt b:")
    aryt = 0
    geom = 1
    harm = 0
    for n in tnums:
        aryt += n
        geom *= n
        harm += (1/n)
    w1 = aryt/len(tnums)
    w2 = geom**(1/len(tnums))
    w3 = len(tnums)/harm
    print(f"Srednia arytmetyczna: {w1}")
    print(f"Srednia geometryczna: {w2}")
    print(f"Srednia harmoniczna: {w3}")
    print("")

    print("Podpunkt c:")
    print(f"Powtorzenia 3: {tnums.count(3)}, powtorzenia 5: {tnums.count(5)}")

def zad5():
    """
    Zadanie 5.Utwórz listę przedmiotów do losowania
    sub = [mat, stat, ang, python, BI, … inne]

    Utwórz listę studentów do losowania
    names =[Ania, Kasia, Marek, Franek, Zosia, Magda, Adam, Michał, …]

    Utwórz o tej samej liczności co lista names listę identyfikatorów:
    ids = [23222, 23223, 23224, 23225, …]

    Wygeneruj listę studentów group =[ student1, student2, student3, …] przy czym student to tupla: student= (id, name, subjects), gdzie subjects to lista przedmiotów, które student zaliczył (może być różnej długości)
    """
    sub = ["Calculus", "Algebra", "Discrete Math", "Statistics", "Probability", "Econometrics"]
    names = ["Ania", "Hania", "Bania", "Kania", "Frania", "Brania", "Flania", "Prania", "Dania", "Tania", "Vania"]
    ids = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]

    group = []
    for i in range(10):
        #nazwa = "".join(["Student", str(i+1)])
        index = ids[random.randint(0, len(ids)-1)]
        del ids[ids.index(index)]
        name = names[random.randint(0, len(names)-1)]
        del names[names.index(name)]

        subjects = []
        # random.sample(sequence, k - number of elements to select)
        subidx = random.sample(range(0, len(sub)), random.randint(1, len(sub)-1))
        for j in subidx:
            element = sub[j]
            subjects.append(element)

        student = (index, name, subjects)
        group.append(student)
    print(group)

# SŁOWNIKI
def zad7():
    """
    Zadanie 7.
        a) Napisz program, który na podstawie listy: student_grades = [("Alice", 5), ("Bob", 4), ("Eve", 3), ("AAA", "BBB")] utworzy słownik z listy par student – ocena tak, aby usunąć wszystkie oceny, które nie są liczbami.
        b) Utwórz słownik, który mapuje małe litery na ich wartości ASCII.
        c) Utwórz zagnieżdżony słownik, w którym zewnętrzny słownik mapuje liczbę do innego słownika zawierającego kwadraty i sześciany.
    """
    student_grades = [("Alice", 5), ("Bob", 4), ("Eve", 3), ("AAA", "BBB")]
    student = {}

    print("Podpunkt a:")
    for i in range(len(student_grades)):
        if(type(student_grades[i][1]) == int):
            student[student_grades[i][0]] = student_grades[i][1]
    print(student)
    print("")

    print("Podpunkt b:")
    asciivalue = {}
    value = [n for n in range(97, 123)]
    letters = list(string.ascii_lowercase)
    for i in range(len(value)):
        asciivalue[letters[i]] = value[i]
    print(asciivalue)
    print("")

    print("Podpunkt c:")
    asciivalue_elevated = {}
    for i in range(len(value)):
        asciivalue_elevated[letters[i]] = {value[i]: [value[i]**2, value[i]**3]}
    print(asciivalue_elevated)
    print("")

# ZBIORY
def zad8():
    """
    Zadanie 8. Dana jest lodziarnia, która sprzedaje lody o różnych smakach:
    smak = [śmietankowe, pistacjowe, truskawkowe, jagodowe, cytrynowe]
    Lody mogą być w dwóch rozmiarach: rozmiar = [duże , małe]
    Lody mogą mieć dodatki: dodatek = [polewa czekoladowa, polewa karmelowa, posypka czekoladowa, posypka kolorowa] Utwórz zbiór zawierający wszystkie możliwe tuple postaci: (duże, śmietankowe, posypka kolorowa)

    """
    smak = ["śmietankowe", "pistacjowe", "truskawkow", "jagodowe", "cytrynowe"]
    rozmiar = ["duże", "małe"]
    dodatek = ["polewa czekoladowa", "polewa karmelowa", "posypka czekoladowa", "posypka kolorowa"]

    s = set()
    for i in range(len(smak)):
        for j in range(len(rozmiar)):
            for k in range(len(dodatek)):
                s.add((smak[i], rozmiar[j], dodatek[k]))
    print(s)

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
        case 7:
            zad7()
        case 8:
            zad8()

        case _:
            print("Podałes zły numer")

play()
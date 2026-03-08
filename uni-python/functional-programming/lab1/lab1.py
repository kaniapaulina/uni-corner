import math
import random
import string

# INPUT OUTPUT
# Zadanie 1 - Działania matematyczne
def zad1():
    a = int(input("Podaj liczbe a: "))
    b = int(input("Podaj liczbe b: "))

    print(f"Suma: {a+b}")
    print(f"Różnica: {a-b}")
    print(f"Iloczyn: {a*b}")
    print(f"Iloraz: {a/b}")
    print(f"Wyrażenie: {math.sqrt(a+b)}")

# ZADANIE 2 - Zgadywanka
def zad2():
    goal = random.randint(1, 5)
    guess = int(input("Zgadnij liczbe z przedziału 1-5: "))

    if guess == goal: print("Zgadłeś!")
    else: print(":(")

# LISTY
# ZADANIE 3 -  Operacje na listach
def zad3():
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
# ZADANIE 4 - operacje na krotkach
def zad4():
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

# ZADANIE 5 - lista przedmiotów i studentów
def zad5():
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
        subidx = random.sample(range(0, len(sub)), random.randint(1, len(sub)-1))
        for j in subidx:
            element = sub[j]
            subjects.append(element)

        student = (index, name, subjects)
        group.append(student)
    print(group)

# SŁOWNIKI
# ZADANIE 7 - Działania na słownikach
def zad7():
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

# Zbiory
# ZADANIE 8 - tworzenie setu
def zad8():
    smak = ["śmietankowe", "pistacjowe", "truskawkow", "jagodowe", "cytrynowe"]
    rozmiar = ["duże", "małe"]
    dodatek = ["polewa czekoladowa", "polewa karmelowa", "posypka czekoladowa", "posypka kolorowa"]

    s = set()
    for i in range(len(smak)):
        for j in range(len(rozmiar)):
            for k in range(len(dodatek)):
                s.add((smak[i], rozmiar[j], dodatek[k]))
    print(s)
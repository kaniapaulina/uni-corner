import math
import string

# WYRAŻENIA LISTOWE
def zad1():
    """
    Zadanie 1. Napisz program, który zwróci listę z sumą cyfr każdej liczby z zakresu od 10 do 19.
    """
    cyfry = [n for n in range(10, 20)]
    suma_cyfr = []
    for num in cyfry:
        suma_cyfr.append(suma_cyfry(num))
    print(suma_cyfr)

def suma_cyfry(n):
    suma = 0
    while n > 0:
        reszta = n % 10
        suma += reszta
        n = n // 10
    return suma

def zad2():
    """
    Zadanie 2. Spłaszcz listę list liczb, np. [[1, 2, 3], [4, 5], [6, 7, 8]].
    """
    list = [[1, 2, 3], [4, 5], [6, 7, 8]]

    # Sposób 1
    list1 = []
    for x in list:
        list1.extend(x)
    print(list1)

    # Sposób 2
    print(sum(list, []))

    # Sposób 3
    print([item for sublist in list for item in sublist])

def zad3():
    """
    Zadanie 3. Dla macierzy 3x3 zawierającej liczby od 1 do 9, wygeneruj nową macierz, w której znajdą się tylko liczby większe niż 5.
    """
    macierz0 = [
        [1, 2, 3],
        [4, 5, 6],
        [7, 8, 9]
    ]

    list = [n for n in range(1, 10)]
    matrix = []
    index = 0
    for i in range(3):
        row = []
        for j in range(3):
            row.append(list[index])
            index += 1
        matrix.append(row)
    print(matrix)

    matrix1 = []
    index = 0
    for i in range(3):
        row = []
        for j in range(3):
            if(list[index] < 5):
                row.append(0)
            else:
                row.append(list[index])
            index += 1
        matrix1.append(row)
    print(matrix1)

def zad4():
    """
    Zadanie 4. Napisz wyrażenie listowe, które będzie realizować mnożenie dwóch macierzy 3x3.
    """
    macierzA = [[1,2,3], [4,5,6], [7,8,9]]
    macierzB = [[1,2,3], [4,5,6], [7,8,9]]
    print(multiply_matrixes(macierzA, macierzB))

def multiply_matrixes(A, B):
    #result = []
    #for i in range(len(A)):
    #    row = []
    #    for j in range(len(B[0])):
    #        product = 0
    #        for v in range(len(A[i])):
    #            product += A[i][v] * B[v][j]
    #        row.append(product)

     #   result.append(row)

    #return result
    n = 3
    result = [[0] * n for i in range(n)]
    for i in range(n):
        for j in range(n):
            result[i][j] = sum((A[i][v] * B[v][j] for v in range(n)))
    return result

def zad5():
    """
    Zadanie 5. Masz słownik, gdzie kluczami są słowa, a wartościami są liczby. Użyj wyrażenia listowego, aby stworzyć nowy słownik, który będzie zawierał tylko te słowa, które mają co najmniej 5 liter, a wartości tych słów zostaną podwojone.
    """
    przyklad = {
        "abcd": 12,
        "efgh": 13,
        "ijklmno": 14,
        "pqrstuvwg": 15,
        "xyz": 16
    }

    #result = {
    #    x:y*2 for y in przyklad.values() for x in przyklad.keys() if len(x) > 5
    #}

    result = {
        k: v*2 for k, v in zip(przyklad.keys(), przyklad.values()) if len(k)>5
    }
    print(result)

    alt_result = dict([(x, y*2) for x, y in przyklad.items() if len(x)>5])
    print(alt_result)

def zad6():
    """
    Zadanie 6. Używając wyrażenia listowego, wygeneruj listę liczb pierwszych w zakresie od 2 do 100.
    """
    #print([x for x in range(2, 101) for y in range(2, round(math.sqrt(x))) if x%y != 0])
    print([x for x in range(2, 101) if all(x%y != 0 for y in range(2, round(math.sqrt(x))+1))])

def zad7():
    """
    Zadanie 7. Stwórz szyfr Cezara, który przesuwa litery w podanym słowie o 3 miejsca w alfabecie, używając wyrażenia listowego.
    """
    word = "Helloworld"
    shift = 4
    result = ''.join(chr((ord(ch) - ord('a') + shift)%26 + ord('a')) for ch in word.lower())

    print(result)
    print(szyfr_cezara(word, shift))
    print(caesar_cypher(word, shift))

def szyfr_cezara(m, key):
    result = ""
    for c in m:
        if c in string.ascii_letters:
            start = ord('A') if c.isupper() else ord('a')
            new_c = chr((ord(c) - start + key) % 26 + start)
            result += new_c
        else:
            result += c
    return result

def caesar_cypher(m, key):
    return ''.join([chr(((ord(char) - 65 + key) % 26) + 65) if char.isupper() else chr(((ord(char) - 97 + key) % 26) + 97) if char.islower() else char for char in m])

def zad8():
    """
    Zadanie 8. Wygeneruj listę zawierającą wielokrotności liczb od 1 do 10 dla wartości od 1 do 100, ale tylko te wielokrotności, które są mniejsze niż 50.
    """
    wielokrotnosc = [x for x in range(1, 11)]
    result = []
    n = 1
    for i in range(len(wielokrotnosc)):
        for j in range(wielokrotnosc[i], 101, wielokrotnosc[i]):
            if j < 50:
                result.append(j)
    print(result)

def zad9():
    """
    Zadanie 9. Wygeneruj listę zawierającą liczby Fibonacci'ego do wartości 100, ale tylko te liczby, które są parzyste.
    """
    n = 0
    m = 1
    fib = []
    result = []
    while m < 80:
        m, n = m + n, m
        fib.append(m)
        if m%2 == 0:
            result.append(m)
    print(f"Ciąg Fibonacci'ego: {fib}")
    print(result)

def zad10():
    """
    Zadanie 10. Z danej listy zdań stwórz listę zawierającą słowa o długości co najmniej 4 znaków, przekształcone na wielkie litery.
    """
    lista_zdan = ["I am Paulina", "This is a cool Program that transforms a sentence into words"]
    result = []
    for element in lista_zdan:
        element += " "
        slowo = []
        for chr in element:
            if chr != " ":
                slowo.append(chr)
            else:
                if len("".join(slowo)) >= 4:
                    result.append("".join(slowo).upper())
                slowo = []
    #print([n for n in result if len(n)>=4])
    print(result)

def zad10_alt():
    lista_zdan = ["I am Paulina", "This is a cool Program that transforms a sentence into words"]
    print(lista_zdan)

    resulta = []
    for element in lista_zdan:
        formatted = element.split()
        resulta.append(formatted)
    print(resulta)

    resultb = []
    for sentence in resulta:
        for word in sentence:
            if len(word)>=4:
                x = word.upper()
                resultb.append(x)

    print(resultb)

def zad11():
    """
    Zadanie 11. Utwórz słownik, w którym kluczami są liczby, a wartościami ich kwadraty. Jako klucze należy uwzględniać wyłącznie liczby parzyste.
    """
    numbers = [n for n in range(20) if n%2==0]
    dict_num = {}
    for n in numbers:
        dict_num[n] = n**2
    print(dict_num)

def zad12():
    """
    Zadanie 12. Utwórz słownik, w którym kluczami będą liczby, a wartościami ich kwadraty, ale uwzględnij tylko wpisy, w których kwadrat jest większy niż 10.
    """
    numbers = [n for n in range(20) if n**2>10]
    dict_num = {}
    for n in numbers:
        dict_num[n] = n ** 2
    print(dict_num)

def zad13():
    """
    Zadanie 13. Mając istniejący słownik, zamień klucze i wartości.
    """
    istniejacy_slownik = {
        "jeden": 1,
        "dwa": 2,
        "trzy": 3,
        "cztery": 4
    }
    nowy_slownik = {}
    for key, value in istniejacy_slownik.items():
        nowy_slownik[value] = key
    print(istniejacy_slownik)
    print(nowy_slownik)

def zad14():
    """
    Zadanie 14. Utwórz słownik, który mapuje małe litery na ich wartości ASCII.
    """
    litery = [n for n in string.ascii_lowercase]
    small_letters = {}
    for i in range(0, len(litery)):
        small_letters[litery[i]] = ord('a') + i
    print(small_letters)

def zad15():
    """
    Zadanie 15. Utwórz zagnieżdżony słownik, w którym zewnętrzny słownik mapuje liczbę do innego słownika zawierającego kwadraty i sześciany.
    """
    slownik = {}
    for i in range(10):
        slownik[i] = {
            i**2: i**3
        }
    print(slownik)


# Funkcja do szybkiego testowania
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
        case 7:
            zad7()
        case 8:
            zad8()
        case 9:
            zad9()
        case 10:
            zad10()
        case 11:
            zad11()
        case 12:
            zad12()
        case 13:
            zad13()
        case 14:
            zad14()
        case 15:
            zad15()
        case _:
            print("Podałes zły numer")

play()

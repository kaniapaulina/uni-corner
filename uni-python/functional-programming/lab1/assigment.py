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

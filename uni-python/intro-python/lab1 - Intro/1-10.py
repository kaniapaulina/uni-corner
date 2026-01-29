import time

# Zadanie 1. Proszę napisać program poszukujący trójkątów Pitagorejskich w których długość przekątnej jest mniejsza od liczby N wprowadzonej z klawiatury
def zad1():
    n = input("Podaj ograniczenie: ")
    n = int(n)

    for a in range(1, n):
        for b in range(a, n):
            c = ((a * a) + (b * b)) ** (1 / 2)
            if c.is_integer() and c < n:
                print(f"{c}²  = {a}²  + {b}²")


# Zadanie 2. Proszę napisać program wypisujący elementy ciągu Fibonacciego mniejsze od miliona
def zad2():
    a = b = 1
    while a < 1000:
        print(a, end=" ")
        #a, b = b, a + b     #wykonuje dzialania w tym samym czasie
        xd = a
        a = b
        b = xd + b


# Zadanie 3. Proszę znaleźć wyrazy początkowe ciągu zamiast 1,1 o najmniejszej sumie, aby w ciągu analogicznym do ciągu Fibonacciego wystąpił wyraz równy numerowi bieżącego roku.
def zad3():
    rok = 2025
    ciag = (rok - 1, 1)
    for i in range(1, rok + 1):
        x = i
        y = rok
        while y > x:
            x, y = y - x, x
        if x + y < sum(ciag):
            ciag = (y, x)
    print(ciag)

def zad3_alt():
    rok = 2025
    najlepsza_para = (1, rok - 1)

    for a in range(1, rok // 2 + 1):
        for b in range(a, rok - a + 1):
            x, y = a, b
            while y < rok:
                x, y = y, x + y
            if y == rok and (a + b) < sum(najlepsza_para):
                najlepsza_para = (a, b)

    if sum(najlepsza_para) < rok:
        print(f"wyrazy początkowe: {najlepsza_para} i najmniejsza suma: {sum(najlepsza_para)}")
    else:
        print("Nie znaleziono odpowiedniej pary dla roku", rok)


# Zadanie 4. Proszę napisać program sprawdzający czy istnieje spójny podciąg ciągu Fibonacciego o zadanej sumie.
def zad4():
    f1 = f2 = k1 = k2 = 1
    sum = 0
    a = int(input("Podaj sume: "))

    while sum < a:
        sum = sum + f1  # sum += f1
        f1, f2 = f2, f1 + f2
    while sum > a:
        sum = sum - k1  # sum -= k1
        k1, k2 = k2, k1 + k2

    if sum == a:
        print(f"Tak, istnieje spójny podciąg ciągu Fibonacciego o sumie {a}.")
        return True
    else:
        print(f"Nie istnieje spójny podciąg ciągu Fibonacciego o sumie {a}.")
        return False


# Zadanie 5. Pierwiastek całkowitoliczbowy z liczby naturalnej to część całkowita z pierwiastka z tej liczby.
# Proszę napisać program obliczający taki pierwiastek korzystając z zależności 1 + 3 + 5 + ... = n^2
def zad5():
    liczba = int(input("Podaj liczbe: "))

    suma = 0
    odd = 1
    licznik = 0

    while suma <= liczba:
        suma += odd
        odd += 2
        licznik += 1

    print(licznik - 1)


# Zadanie 6. Proszę napisać program wyznaczający pierwiastek kwadratowy ze wzoru Newtona.
def zad6():
    x = int(input("Podaj liczbę: "))
    x1 = 1
    x2 = (x1 + x / x1) / 2
    while abs(x2 - x1) > 0.0001:
        x1 = x2
        x2 = (x1 + x / x1) / 2
    print(f"Pierwiastek {x} wynosi {x2}")


# Zadanie 7. Proszę zmodyfikować wzór Newtona aby program z poprzedniego zadania obliczał pierwiastek stopnia 3.
def zad7():
    x = int(input("Podaj liczbę: "))
    x1 = 2
    x2 = (2 * x1 + x / (x1 * x1)) / 3
    while abs(x2 - x1) > 0.0001:
        x1 = x2
        x2 = (2 * x1 + x / (x1 ** 2)) / 3
    print(f"Pierwiastek {x} wynosi {x2}")


# Zadanie 8. Proszę napisać program rozwiązujący równanie x^x = 2024 metodą bisekcji
def zad8():
    a = 4
    b = 5
    while abs(b - a) > 0.00001:
        if ((a + b) / 2) ** ((a + b) / 2) > 2024:
            b = (a + b) / 2
        else:
            a = (a + b) / 2
    print(a, b)


# Zadanie 9. Proszę napisać program wczytujący liczbę naturalną i odpowiadający na pytanie, czy liczba ta jest iloczynem dowolnych dwóch kolejnych wyrazów ciągu Fibonacciego.
def zad9():
    liczba = int(input("Podaj liczbe: "))
    a = b = 1
    while a * b <= liczba:
        a, b = b, a + b
    if (a * b == liczba):
        print(f"{a} * {b} = {liczba}")
    else:
        print("No i nie pasuje")


# Zadanie 10. Proszę napisać program sprawdzający czy zadana liczba jest pierwszą.
def zad10():
    liczba = int(input("Podaj liczbe: "))
    if (abs(liczba) < 2):
        print("No i co podajesz liczbe 0/1")
    else:
        dzielnik = 2
        while (dzielnik ** 2 <= liczba):
            if liczba % dzielnik == 0:
                return print("liczba nie jest pierwsza")
            dzielnik += 1
        return print("Liczba jest pierwsza")



def test_wydajnosci(zadanie):
    start = time.time()
    zadanie
    print(f"zadanie wykonane w {time.time() - start:.4f}s")



if __name__ == "__main__":
    print("Tu sie dzieje czarna magia\n")

    test = zad6()
    test
    test_wydajnosci(test)
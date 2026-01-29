# -*- coding: ibm852 -*-  # Okreslenie kodowania pliku
def NWD(a: int, b: int) -> int:  # Definicja funkcji obliczajacej NWD dla dwoch liczb calkowitych
    try:  # Proba wykonania kodu w celu obslugi potencjalnych bledow
        print(f"({a}, {b})") #Wyswietlenie poczatkowych wartosci liczb przed przeksztalceniem
        a, b = abs(a), abs(b)  # Konwersja liczb na wartosci bezwzgledne (eliminacja ujemnych)
        if a == 0 or b == 0:  # Sprawdzenie, czy jedna z liczb jest rowna 0
            if a + b != 0:  # Jesli jedna z liczb jest zerem, a druga rozna od zera
                result = max(a, b)  # Wynik to druga, niezerowa liczba
            else:
                result = "Nieskonczenie wiele dzielnikow"  # Jesli obie liczby to 0, TO NWD ma nieskonczenie wiele rozwiazan
            print("NWD wynosi: ") # Wyswietlenie ostatecznego wyniku - NWD
            return result  # Zwrocenie wyniku w przypadku obecnosci zera
        while a != b:  # Petla wykonuje sie, dopoki a i b nie sa rowne
            if a < b:  # Jesli a jest mniejsze od b
                b -= a  # Odejmuje a od b i przypisuje nowa wartosc b
            else:  # W przeciwnym wypadku, gdy a jest wieksze lub rowne b
                a -= b  # Odejmuje b od a i przypisuje nowa wartosc a
            print(a, b)  # Wyswietlenie aktualnych wartosci a i b w trakcie dzialania petli
        print("NWD wynosi: ")  # Wyswietlenie ostatecznego wyniku - NWD
        return a # Zwraca wynik uzywajac identyfikatora a
    except:  # Obsluga bledow dla niepoprawnych danych wejsciowych
        print("Invalid input, exiting")  # Komunikat bledu w przypadku niewlasciwego wejscia
        return None # Zwrocenie wartosci None, jesli wystapi blad

if __name__ == "__main__":
    print(f"{NWD(-128, 48)}\n")  # Test funkcji dla liczb -128 i 48
    print(f"{NWD(-222, 52)}\n")  # Test funkcji dla liczb -222 i 52
    print(f"{NWD(0, 52)}\n")  # Test funkcji dla liczb 0 i 52

import math     #importuje modul math do obliczeń matematycznych (dla math.sqrt())
import sys      #importuje modul sys by korzystac z argumentów podanych w CMD

def trojmian(a: int, b: int, c: int) -> int:    #definiuje funkcję przyjmującą trzy liczby int (całkowite)
    if a == 0:      #Sprawdza, czy a = 0 (bo wtedy nie jest to funkcja kwadratowa)
        return "To nie jest funkcja kwadratowa"  #zwraca komunikat

    try:
        delta = (b ** 2) - (4 * a * c)      #Oblicza deltę

        if delta > 0:       #Jeśli delta jest większa od 0 - dwa pierwiastki rzeczywiste
            pone = (-b - math.sqrt(delta)) / (2 * a)  #liczy pierwsze miejsce zerowe
            ptwo = (b - math.sqrt(delta)) / (2 * a)  #liczy drugie miejsce zerowe
            return f"Miejsca zerowe to {pone} i {ptwo}"     #zwraca dwa pierwiastki

        elif delta == 0:        #Jeśli delta wynosi 0 - jedno miejsce zerowe
            pzero = -b / (2 * a)  #liczy miejsce zerowe
            return f"Miejsce zerowe wynosi: {pzero}"        #zwraca jedno miejsce zerowe

        else:       #jeśli delta < 0 - pierwiastki zespolone
            re = -b / (2 * a)       #Część rzeczywista
            im = math.sqrt(-delta) / (2 * a)        #Część urojona
            pone = complex(re, im)      #pierwszy pierwiastek = re + imj
            ptwo = complex(re, -im)     #drugi pierwiastek = re - imj
            return f"Miejsca zerowe to liczby zespolone: {pone}, {ptwo}"  #zwraca pierwiastki zespolone

    except:  #Obsługuje błędy (błędne dane wejściowe)
        return "Invalid Input"  #zwraca komunikat


if __name__ == '__main__':  #"Jeśli plik jest uruchamiany jako skrypt, wykonaj poniższe linijki"
    print(trojmian(1, 0, 1))  #Test dla delta < 0 (wynik to liczby zespolone)
    print(trojmian(1, 2, 1))  #Test dla delta = 0 (wynik tojedno miejsce zerowe)
    print(trojmian(0, 9, 3))  #TTest dla a = 0 (ma wyskoczyc bład)

    if len(sys.argv) != 4:  #Sprawdza, czy liczba przekazanych argumentów wynosi dokładnie 4 (nazwa skryptu + 3 liczby)
        print("Podaj trzy liczby jako argumenty: a, b, c")  #wypisuje komunikat
        sys.exit(1) #zakończenie programu z kodem 1 (błąd)
    else: #nie podano poprawną ilość danych
        a = int(sys.argv[1]) #wspolczynnik a
        b = int(sys.argv[2]) #wspolczynnik b
        c = int(sys.argv[3]) #wspolczynnik c
        wynik = trojmian(a, b, c) #wywoluje funkcje trojmian dla podanych liczb
        print(f"Dla {a}*x^2 + {b}*x + {c}: ",  wynik) #wyświetla wynik obliczeń, pokazując równanie kwadratowe i jego pierwiastki
        sys,exit(0) #zakończenie programu z kodem 0 (wszystko przebiegło poprawnie)

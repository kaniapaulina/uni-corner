import sys  #importuje biblioteke sys

def mSHA(a):       #definuje funkcje
    try:           # program ma sie sprobowac wykonac, jesli dane bede poprawne funkcja przejdzie do nastepnego kroku
        a = int(a)     #zamieniam typ zmiennej a z str na int
        suma=a         #przypisuje wartosci suma wartosc a
        while (suma >= 10):  # petla ma sie wykonywac dopoki suma bedzie wieksza lub rowna 10
            a = suma         #przypisanie a watosc sumy
            suma = 0         #przypisanie sumie watosci 0
            while (a != 0):  #petla ma sie wykonywac dopoki a bedzie rozne od 0, petla ma dodawac cyfry podanej liczby
                suma += a % 10  #dodanie do sumy reszty z dzielenia a przez 10
                a = a // 10     #podstawienie za a calkowtego dzielenia a przez 10
    except:                  # jesli wprowadzone dane nie beda prawidlowe wykonaja sie ponizsze kroki
        return("Error!!")    #zwracam napis "Error!!"

    return suma              #zwracam sume

if __name__=="__main__":     #rozpoczecie czesci testowej
    print("Test dla 567: ", mSHA("567"))      #wywołanie funkcji dla argumentu 567, gdzie 567 jest napisem
    print("Test dla 5678: ", mSHA("5678"))    #wywołanie funkcji dla argumentu 5678, gdzie 5678 jest napisem
    print("Test dla abc: ", mSHA("abc"))      #wywołanie funkcji dla argumentu abc, co wypisuje Error

    if len(sys.argv) > 1:    #warunek sprawdzajacy czy uzytkownik podal argument
        b = sys.argv[1]      #jest tak, to program przypisuje pod wartosc a pierwszy argument podany podczas uruchamiania kodu w terminalu
        c = mSHA(b)          #przypisuje pod wartosc b wynik dzialania funkcji mSHA
        print(f"Test dla {b}: {c}")       #program wypisuje wynik dla podanego argumentu
    else:                    #jesli warunek jest falszem to program wykonuje ponizszy krok
        print("Proszę podać liczbę jako argument wywołania programu.")   #program wysetla prosbe o argumentu ktory bedzie nam sluzył jak parametr wywolania programu
    sys.exit(0)              #zakonczenie programu

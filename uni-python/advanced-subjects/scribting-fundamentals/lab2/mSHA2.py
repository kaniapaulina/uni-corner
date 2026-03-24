import sys

def mSHA(a):
    try:
        a = int(a)  # Konwersja na int
    except:
        return "Błąd: Podano niepoprawne dane!"

    while a >= 10:
        suma = 0
        while a != 0:
            digit = a % 10      # oblicz ostatnia cyfre
            a = a //10      #usuń ostatnia cyfre z liczby
            suma += digit       # dodaj cyfre do sumy wynikowej
        a = suma
    return a

if __name__=="__main__":
    print("Test dla 567: ", mSHA("567"))
    print("Test dla 123456: ",mSHA("123456"))
    print("Test dla abc: ",mSHA("abc"))
    if len(sys.argv) > 1:
        b = sys.argv[1]
        c = mSHA(b)
        print(f"Test dla {b}: {c}")
    else:
        print("Nie podano argumentu wlasnego")
    sys.exit(0)
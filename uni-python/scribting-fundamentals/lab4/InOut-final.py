# -*- coding: ibm852 -*-
import sys
import math
import tkinter as tk
from tkinter import filedialog, messagebox

licznik_bledow = 0

def euler(dat) -> tuple:  # funkcja licz¥ca wato˜† y(x)
    licznik = dat[0] - dat[2]  # licznik = X1 - X3
    mianownik = dat[1] + dat[2]  # mianownik = X2 + X3
    # if mianownik == 0:  # jezeli mianownik rowny 0
    #     print("Nie mo¾na dzieli† przez zero!")
    #     return
    wykladnik = -((licznik / mianownik) ** 2)  # licz© sam wykˆadnik ze wzoru z polecenia
    return math.e ** (wykladnik)  # zwracam e podnisione do zmiennej wykladnik

# SEKCJA WCZYTYWANIA - z pliku InOut.dat
def wejscie():
    global dct, licznik_bledow
    file = filedialog.askopenfilename(filetypes=[("Pliki tekstowe", "*.dat")])
    #wejscie = "Data.dat"
    uchwyt = open(file, 'r')
    Plik = uchwyt.readlines()
    dct = {}

    for linia in Plik[1:]:
        listalinia = linia.split(',')
        try:
            numlist = list(map(float, listalinia[1:]))
            case, x1, x2, x3 = listalinia[0], numlist[0], numlist[1], numlist[2]
            dct[case] = [x1, x2, x3]
        except:  # je˜li jaka˜ warto˜† jest nieprawidˆowa
            licznik_bledow = 0
            if True:
                licznik_bledow += 1  # zliczam ilo˜† bˆ©d¢w
            print(">> ERROR! >>", listalinia, "<<")
            pass

        komura.delete("1.0", tk.END)

        komura.insert(tk.END, "Dane zostaly poprawnie zaladowane.\n")

# SEKCJA WPISYWANIA - do pliku wynik
def wpis():
    if not dct:
        c = tk.Label(text=f">>NIE MA DANYCH!!!<<")
        c.pack()
        return
    # print dct
    Klucze = list(dct.keys())
    Klucze.sort()

    uchwyt = open("Wynik.dat", 'a')  # otwiera plik Wynik, zeby co˜ w nim dopisa†
    uchwyt.write("\n")

    uchwyt.write("\n>>ERROR COUNT: {}<<\n".format(licznik_bledow))
    uchwyt.write("      -- %5s  --: %10s, %10s, %10s, %10s \n" % ("Case", "x1", "x2", "x3", "y(x)"))
    print(">>ERROR COUNT:", licznik_bledow, "<<")
    print("      -- %5s  --: %10s, %10s, %10s, %10s " % ("Case", "x1", "x2", "x3", "y(x)"))
    wynik = ("      -- %5s  --: %10s, %10s, %10s, %10s " % ("Case", "x1", "x2", "x3", "y(x)"))
    wynik += "\n"

    j = 0
    for k in Klucze:
        y = euler(dct[k])  # liczymy z kazdego wynik
        j += 1
        if j >= 10:
            print(f"for %5s - values: %10.3f, %10.3f, %10.3f, %9.4f" % (k, dct[k][0], dct[k][1], dct[k][2], y))
            uchwyt.write("for {:>5} - values: {:>10.3f}, {:>10.3f}, {:>10.5f}: {:>9.4f}\n".format(k, dct[k][0], dct[k][1],dct[k][2], y))
            wynik += ("for {:>5} - values: {:>10.3f}, {:>10.3f}, {:>10.5f}: {:>9.4f}\n".format(k, dct[k][0], dct[k][1],dct[k][2], y))
        else:
            print(f"for %5s - values: %10.3f, %10.3f, %10.3f, %10.4f" % (k, dct[k][0], dct[k][1], dct[k][2], y))
            uchwyt.write("for {:>5} - values: {:>10.3f}, {:>10.3f}, {:>10.5f}: {:>10.4f}\n".format(k, dct[k][0], dct[k][1],dct[k][2], y))
            wynik += ("for {:>5} - values: {:>10.3f}, {:>10.3f}, {:>10.5f}: {:>10.4f}\n".format(k, dct[k][0], dct[k][1],dct[k][2], y))
    uchwyt.close()  # zakonczenie dopisywania danych do pliku

    komura.delete("1.0", tk.END)
    komura.insert(tk.END, wynik)
    messagebox.showinfo("Sukces", "Wynik zapisany w >>Wynik.dat<<!")

## testing/module code
if __name__ == "__main__":
    if len(sys.argv) > 1 :
        #print (f"Niepoprawne wprowadzenie danych, Uzycie: {sys.argv[0]}")
        #sys.exit(1)
        root = tk.Tk()
        xd = tk.Label(text=f"Niepoprawne wprowadzenie danych, Uzycie: {sys.argv[0]}")
        xd.pack()
        root.mainloop()

    else:
        root = tk.Tk()
        root.title("FAJNY PROJEKT!!!")
        root.geometry("600x450")

        xd_wczytaj = tk.Button(root, text="Wczytaj plik", command=wejscie, width=20)
        xd_wczytaj.pack(pady=5)

        xd_przetworz = tk.Button(root, text="Przetworz dane", command=wpis, width=20)
        xd_przetworz.pack(pady=5)

        komura = tk.Text(root, height=15, width=70)
        komura.pack(pady=5)

        root.mainloop()
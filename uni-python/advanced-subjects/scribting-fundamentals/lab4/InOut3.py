#-*- coding: ibm852 -*-
import sys
import math
import tkinter as tk
from tkinter import filedialog, messagebox

def euler(dat)->tuple:
    licznik=dat[0] - dat[2]
    mianownik= dat[1] + dat[2]
    wykladnik = -((licznik/mianownik)**2)
    return math.e**(wykladnik)

# SEKCJA WCZYTYWANIA - z pliku InOut.dat
def wejscie():
    global dct
    file = filedialog.askopenfilename(filetypes=[("Pliki tekstowe", "*.dat")])

    wejscie = "InOut2.dat"    #wejscie = plik wejsciowy
    uchwyt = open(wejscie, 'r')
    Plik = uchwyt.readlines()

    dct={}
    licznik_bledow = 0

    for linia in Plik[1:]:
        listalinia = linia.strip().split(',')       #strip - usuwa whitespace
        try:
            numlist=list(map(float, listalinia[1:]))
            case,x1,x2,x3 = listalinia[0],numlist[0],numlist[1],numlist[2]
            dct[case]= [x1,x2,x3]

        except ValueError:
            licznik_bledow += 1
            #print(f">> ERROR! >>{listalinia[0]}<<")
            aa = tk.Label(f">> ERROR! >>{listalinia[0]}<<")
            aa.pack()

        komura.delete("1.0", tk.END)

        komura.insert(tk.END, "Dane zostały poprawnie załadowane.\n")

    if licznik_bledow:
        b = tk.Label(text=f">>Licznik bledow: {licznik_bledow}<<")
        b.pack()
        #print(f">>Licznik bledow: {licznik_bledow}<<")

# SEKCJA WPISYWANIA - do pliku InOut3.dat
def wpis():
    if not dct:
        c = tk.Label(text=f">>NIE MA DANYCH!!!<<")
        c.pack()
        return

    Klucze = sorted(list(dct.keys()))
        
    max_len_opis = max(len(str(k)) for k in Klucze)
    max_len_x1 = max(len(str(dct[k][0])) for k in Klucze)
    max_len_x2 = max(len(str(dct[k][1])) for k in Klucze)
    max_len_x3 = max(len(str(dct[k][2])) for k in Klucze)
    max_len_y = max(len(str(euler(dct[k]))) for k in Klucze)
        
    wyjscie = "InOut3.dat"
    uchwyt=open(wyjscie, 'w')
        
    uchwyt.write(f"{'Opis':<{max_len_opis+1}}  {'X1':<{max_len_x1}}  {'X2':<{max_len_x2}}  {'X3':<{max_len_x3}}  {'y(x)':<{max_len_y}}\n")
    wynik = f"{'Opis':<{max_len_opis+1}}  {'X1':<{max_len_x1}}  {'X2':<{max_len_x2}}  {'X3':<{max_len_x3}}  {'y(x)':<{max_len_y}}\n"

    j=0
    for k in Klucze:
        y = euler(dct[k])
        j+=1
        if j>=10:
            uchwyt.write(f"{'Opis':<{max_len_opis}}{j}  {dct[k][0]:<{max_len_x1}}  {dct[k][1]:<{max_len_x2}}  {dct[k][2]:<{max_len_x3}}  {y:<{max_len_y}.3f}\n")
            wynik += f"{'Opis':<{max_len_opis}}{j}  {dct[k][0]:<{max_len_x1}}  {dct[k][1]:<{max_len_x2}}  {dct[k][2]:<{max_len_x3}}  {y:<{max_len_y}.3f}\n"
        else:
            uchwyt.write(f"{'Opis':<{max_len_opis}}{j:<2}  {dct[k][0]:<{max_len_x1}}  {dct[k][1]:<{max_len_x2}}  {dct[k][2]:<{max_len_x3}}  {y:<{max_len_y}.3f}\n")
            wynik += f"{'Opis':<{max_len_opis}}{j:<2}  {dct[k][0]:<{max_len_x1}}  {dct[k][1]:<{max_len_x2}}  {dct[k][2]:<{max_len_x3}}  {y:<{max_len_y}.3f}\n"
    
    uchwyt.close()
    komura.delete("1.0", tk.END)
    komura.insert(tk.END, wynik)

# SEKCJA ZAPISANIA
def zapis():
    plik_zapis = filedialog.asksaveasfilename(defaultextension=".dat", filetypes=[("Pliki tekstowe", "*.dat"), ("Wszystkie pliki", "*.*")])
    if not plik_zapis:
        return
    
    messagebox.showinfo("Sukces", "Plik zapisany pomyślnie!")

if __name__=="__main__":
    if len(sys.argv) > 1 :
        #print (f"Niepoprawne wprowadzenie danych, Uzycie: {sys.argv[0]}")
        #sys.exit(1) 
        root = tk.Tk()
        xd = tk.Label(text=f"Niepoprawne wprowadzenie danych, Uzycie: {sys.argv[0]}")
        xd.pack()
        root.mainloop()

    else:
        root = tk.Tk()
        root.title("Fajny projekt polecam nie pozdrawiam")
        root.geometry("600x450")

        xd_wczytaj = tk.Button(root, text="Wczytaj plik", command=wejscie, width=20)
        xd_wczytaj.pack(pady=5)

        xd_przetworz = tk.Button(root, text="Przetworz dane", command=wpis, width=20)
        xd_przetworz.pack(pady=5)

        komura = tk.Text(root, height=15, width=70)
        komura.pack(pady=5)

        xd_zapisz = tk.Button(root, text="Zapisz wynik", command=zapis, width=20)
        xd_zapisz.pack(pady=5)

        root.mainloop()
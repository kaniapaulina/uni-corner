### !"C:\Program Files\Python35\python.exe"
#-*- coding: ibm852 -*-
import sys
import math

def euler(dat)->tuple:
    licznik=dat[0] - dat[2]
    mianownik= dat[1] + dat[2]
    wykladnik = -((licznik/mianownik)**2)
    return math.e**(wykladnik)

## testing/module code
if __name__=="__main__":
    if len(sys.argv) > 1 :
        print ("U�ycie:", sys.argv[0], "nazwa_pliku.ext")
        sys.exit(1) # kod wykonania (b��d)
    else:
##      uchwyt = open(sys.argv[1], 'r')
        uchwyt = open("InOut.dat", 'r')
        Plik = uchwyt.readlines()
        dct={}
        F1 = "Dla przyp: '%s', temp.=%10.3f, cisn.=%10.3f, wilg.=%10.3f"
        F2 = 'Dla przyp: "{0:<s}", temp.={1:<10.3f}, cisn.={2:<10.3f}, wilg.={3:<10.3f}'

        for linia in Plik[1:]:
            listalinia = linia.split(',')
            try:
              numlist=list(map(float, listalinia[1:]))
              case,x1,x2,x3=listalinia[0],numlist[0],numlist[1],numlist[2]
              dct[case]= [x1,x2,x3]
              #dct.update({listalinia[0]:string.atof(listalinia[1])})
              #dct.update({case:[x1,x2,x3]})
              # w=x1^3-2*x2+x3
            except:
                licznik_bledow=0
                if True:
                    licznik_bledow+=1
                print(">>Licznik b��d�w:", licznik_bledow, "<<")
                print(">> ERROR! >>",listalinia, "<<")
                pass

        #print dct
        Klucze = list(dct.keys())
        Klucze.sort()
        max_len_opis = max(len(str(k)) for k in Klucze)
        max_len_x1 = max(len(str(dct[k][0])) for k in Klucze)
        max_len_x2 = max(len(str(dct[k][1])) for k in Klucze)
        max_len_x3 = max(len(str(dct[k][2])) for k in Klucze)
        max_len_y = max(len(str(euler(dct[k]))) for k in Klucze)
        
        uchwyt=open("InOut2.dat", 'w')
        uchwyt.write(f"{'Opis':<{max_len_opis+1}}  {'X1':<{max_len_x1}}  {'X2':<{max_len_x2}}  {'X3':<{max_len_x3}}  {'y(x)':<{max_len_y}}\n")
        j=0
        for k in Klucze:
            y = euler(dct[k])
            j+=1
            if j>=10:
                uchwyt.write(f"{'Opis':<{max_len_opis}}{j}  {dct[k][0]:<{max_len_x1}}  {dct[k][1]:<{max_len_x2}}  {dct[k][2]:<{max_len_x3}}  {y:<{max_len_y}.3f}\n")
            else:
                uchwyt.write(f"{'Opis':<{max_len_opis}}{j:<2}  {dct[k][0]:<{max_len_x1}}  {dct[k][1]:<{max_len_x2}}  {dct[k][2]:<{max_len_x3}}  {y:<{max_len_y}.3f}\n")
        uchwyt.close()


#for ystr in sys.argv[1:]: # wszystkie parametry wywo�ania
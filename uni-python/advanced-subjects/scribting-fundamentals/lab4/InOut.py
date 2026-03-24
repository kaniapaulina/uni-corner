### !"C:\Program Files\Python35\python.exe"
#-*- coding: ibm852 -*-
import sys
# import string
import locale
from TriSolver import trisolve

## testing/module code
if __name__=="__main__":
    if len(sys.argv) > 1 :
        print ("U¾ycie:", sys.argv[0], "nazwa_pliku.ext")
        sys.exit(1) # kod wykonania (bˆ¥d)
    else:
##        uchwyt = open(sys.argv[1], 'r')
        uchwyt = open("InOut.dat", 'r')
        Plik = uchwyt.readlines()
        print( Plik ) # lista napis¢w
        print( Plik[0] )
        dct={}
        print( dir(dct))
        F1 = "Dla przyp: '%s', temp.=%10.3f, cisn.=%10.3f, wilg.=%10.3f"
        F2 = 'Dla przyp: "{0:<s}", temp.={1:<10.3f}, cisn.={2:<10.3f}, wilg.={3:<10.3f}'

        for linia in Plik[1:]:
            print( linia,)
            listalinia = linia.split(',')
            try:
              numlist=list(map(float, listalinia[1:]))
              print( ">",listalinia)
              print( ">",listalinia[0],numlist)
              case,x1,x2,x3=listalinia[0],numlist[0],numlist[1],numlist[2]
              print( F1 % (case,x1,x2,x3))
              print( F2.format(case,x1,x2,x3)) #nowa forma
              dct[case]= [x1,x2,x3]
              #dct.update({listalinia[0]:string.atof(listalinia[1])})
              #dct.update({case:[x1,x2,x3]})
              # w=x1^3-2*x2+x3
            except:
              print(">> ERROR! >>",listalinia, "<<")
              pass

        #print dct
        Klucze = list(dct.keys())
        print( type(Klucze))
        Klucze.sort()

        print( "      -- %5s  --: %10s, %10s, %10s"% ("Case", "a", "b", "c"))
        for k in Klucze:
            x1,x2=trisolve(dct[k])
            print( "for %5s - values: %10.3f, %10.3f, %10.3f: "% (k, dct[k][0], dct[k][1], dct[k][2]), x1, x2)

        uchwyt.close()
#for ystr in sys.argv[1:]: # wszystkie parametry wywoˆania

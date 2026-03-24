#-*- coding: ibm852 -*-

#import string
import locale
import math
import configparser as CP

def trojmian(a, b, c):
    try:
        a=float(a)
        b=float(b)
        c=float(c)

    except Exception:
      sys.exit()

    dlt=b**2-(4*a*c)

    if dlt>=0:
       dlt=math.sqrt(dlt)
       x1=(-b+dlt)/(2*a)
       x2=(-b-dlt)/(2*a)

    else:
        x0=-b/(2*a)
        i = math.sqrt(-dlt)/(2*a)
        x1=str(x0) +'+i*'+str(i)
        x2=str(x0) +'-i*'+str(i)

    return (str(x1), str(x2))

def ConfigSectionMap(scx):
    dict1 = {}
    options = rd.options(scx)
    for option in options:
        try:
            dict1[option] = rd.get(scx, option)
            # print( option, "\\", dict1[option])
        except:
            print("exception on %s !" % option)
            dict1[option] = None

    return dict1
#=================================================
#=================================================

if __name__ == '__main__':   # blok testowy - gˆ¢wny program
  napPL="W sekcji [%d]: '%s':"
  napEN="In section [%d]: '%s':"

  print(locale.getlocale())  ## locale.LC_NUMERIC))
  rd = CP.ConfigParser()
  rd.read('trm.rc')    ## czytamy plik z danymi
  ##rd.read('config.rc')    ## czytamy plik z danymi
  scts = rd.sections() ## pobieramy list© sekcji
  ind=1

  nap=napPL
  for sct in scts:
      case = ConfigSectionMap(sct)

#      print( nap % (ind,sct), case)

      case,x1,x2,x3=case['temp'],case['a'],case['b'],case['c']
      x={}
      x1,x2,x3= map(float,[x1,x2,x3])
#      x1,x2,x3= map(locale.atof,[x1,x2,x3])
      x[case]=x1,x2,x3
      if case.count(',')==1:
        temp,opis=case.split(',')
      else:
        temp=case
        opis="Brak opisu"
      temp=float(temp)
#      print(temp,opis)
#      print( type(x), x )
      print( "Dla przyp[%d]: \"%s\": temp.=%10.3f, ci˜n.=%10.3f, wilg.=%10.3f, pr©dko˜† wiatru=%10.3f" % \
                      (ind, opis,    temp,         x1,           x2,        x3), "\n")
      ind +=1










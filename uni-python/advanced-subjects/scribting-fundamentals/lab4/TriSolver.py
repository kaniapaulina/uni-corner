#-*- coding: ibm852 -*-
#version 20240304

from math import sqrt

def trisolve(dat)->tuple:
  """Solves equation a*x^2+b*x+c=0, in real domain.

      trisolve(input) - input - sequence of coefficients a,b,c,
                                returns real tuple or None tuple
      ================================
  """
  dlt=dat[1]**2-4*dat[0]*dat[2]
  if dlt >= 0:
        a2=2*dat[0]
        dlt=sqrt(dlt)/a2
        x0=-dat[1]/a2
        return x0-dlt,x0+dlt
  else:
        #print( "brak pierwiastk¢w rzeczywistych")
        return None,None
#================================#

#####[ testing/module code ]######
if __name__=="__main__":
  x1,x2=trisolve([1,2,-2])
  if x1:
      print( "x1= {0:010.2f};".format(x1))
      print( "x2= {0:<10.2f};".format(x2))
  else:
      print( "brak pierwiastk¢w rzeczywistych")
  print("*_"*9 + "* \n")
#================================/

#!C:\Users\SilverBear\AppData\Local\Programs\Python\Python312\python.exe
#-*- coding: utf-8 -*-
"""
Created on Tue Mar 12, 2024

@author: Lecturer
"""

import sys
import Trm
# from Trojmian2024 import trojmian

print("My name is: ", __name__,"\n")
print(f"My name is: {__name__}\n")

if __name__ == "__main__":
  i = 0
  sum = 0
  for opt in sys.argv:
    print(f"{i} option is:{type(opt)}:{opt}\n")
    try:
      sum += float(opt)
    except:
      print("no, kicha...\n")
    i += 1
# (x1, x2)= ('1.0', '-3.0')
  if (len(sys.argv)>=4):
    print(f"You passed {len(sys.argv)-1} arguments which is enough\n")
    print("(x1, x2)=", Trm.trojmian(float(sys.argv[1]), float(sys.argv[2]), float(sys.argv[3])))
  else:
    print(f"Three positional, numerical arguments are required,\n"
          f"but You passed {len(sys.argv)-1} only.\nConcentrate - Intended use is: prog a b c")

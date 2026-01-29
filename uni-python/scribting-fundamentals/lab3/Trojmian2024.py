#-*- coding: utf-8 -*-
"""
Created on Sat Mai 10 02:02:02 2020

@author: Lecturer
"""

import sys
import math
from tkinter import *
admin = Tk()
admin.title("Pierwiastki trójmianu kwadratowego")
admin.geometry ('480x220')

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

aLabel=Label(admin, text="a", font='Cambria 18')
aLabel.place(x=20, y=20, width=60, height=40)

aEntry=Entry(admin, bd=1)
aEntry.place(x=70, y=20, width= 90, height=40)


bLabel=Label(admin, text="b", font='Cambria 18')
bLabel.place(x=160, y=20, width=60, height=40)

bEntry=Entry(admin, bd=1)
bEntry.place(x=210, y=20, width= 90, height=40)

cLabel=Label(admin, text="c", font='Cambria 18')
cLabel.place(x=300, y=20, width=60, height=40)

cEntry=Entry(admin, bd=1)
cEntry.place(x=350, y=20, width= 90, height=40)


def account():
     x1,x2 = trojmian(aEntry.get(), bEntry.get(), cEntry.get())
     x1Entry.delete(0,END)
     x1Entry.insert(0,x1)

     x2Entry.delete(0,END)
     x2Entry.insert(0,x2)

button= Button(text= "ROZWIĄŻ", command=account, font= 'Cambria 16')
button.place (x=13, y=80, width= 240, height=40)

x1Label=Label(admin, text="x1", font='Cambria 18')
x1Label.place(x=60, y=140, width=60, height=40)

x1Entry=Entry(admin, bd=1)
x1Entry.place(x=110, y=140, width= 110, height=40)

x2Label=Label(admin, text="x2", font='Cambria 18')
x2Label.place(x=220, y=140, width=60, height=40)

x2Entry=Entry(admin, bd=1)
x2Entry.place(x=270, y=140, width= 110, height=40)

admin.mainloop()

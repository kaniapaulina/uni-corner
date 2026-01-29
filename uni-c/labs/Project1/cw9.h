#ifndef CW9_H
#define CW9_H

#include <math.h>

// Zadanie 1
double mcarloint(double (*f)(double), double a, double b, int n);

// Zadanie 2
double trapezint(double (*f)(double), double a, double b, int n);

// Zadanie 3
double simpsonint(double (*f)(double), double a, double b, int n);

// Zadanie 4
double f1(double x);
double f2(double x);
double f3(double x);
void compare_methods();

// Zadanie 5
typedef enum { niski, sredni, wysoki } Wzrost;

typedef struct {
    char imie[30];
    char nazwisko[30];
    Wzrost wzrost;
} Person;

void print_person(Person p);
void zadanie5();


#endif
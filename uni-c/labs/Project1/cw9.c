// Wzkaüniki do funkcji jako parametr funkcji, struktury, typedef, typ wyliczeniowy

#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>
#include <string.h>

#include "cw9.h"

// ZADANIE 1
// - Monte Carlo
double mcarloint(double (*f)(double), double a, double b, int n) {
    double sum = 0;
    srand(time(NULL));
    for (int i = 0; i < n; i++) {
        double x = a + (b - a) * rand() / (double)RAND_MAX;
        sum += f(x);
    }
    return (b - a) * sum / n;
}

// ZADANIE 2
// - Metoda trapezÛw
double trapezint(double (*f)(double), double a, double b, int n) {
    double h = (b - a) / n;
    double sum = (f(a) + f(b)) / 2;
    for (int i = 1; i < n; i++) {
        sum += f(a + i * h);
    }
    return sum * h;
}

// ZADANIE 3
// - Metoda Simpsona
double simpsonint(double (*f)(double), double a, double b, int n) {
    if (n % 2 != 0) n++;
    double h = (b - a) / n;
    double sum = f(a) + f(b);
    for (int i = 1; i < n; i++) {
        double x = a + i * h;
        sum += (i % 2 == 0) ? 2 * f(x) : 4 * f(x);
    }
    return sum * h / 3;
}

// ZADANIE 4 
// - Przyk≥adowe funkcje
double f1(double x) { return x * x; }
double f2(double x) { return sin(x); }
double f3(double x) { return exp(x); }

void compare_methods() {
    FILE* fp = fopen("results.txt", "w");
    double a = 0, b = 1;
    int n = 10000;

    fprintf(fp, "Funkcja 1 (x^2):\n");
    fprintf(fp, "Monte Carlo: %f\n", mcarloint(f1, a, b, n));
    fprintf(fp, "Trapezy: %f\n", trapezint(f1, a, b, n));
    fprintf(fp, "Simpson: %f\n\n", simpsonint(f1, a, b, n));

    fprintf(fp, "Funkcja 2 (sin(x)):\n");
    fprintf(fp, "Monte Carlo: %f\n", mcarloint(f2, a, b, n));
    fprintf(fp, "Trapezy: %f\n", trapezint(f2, a, b, n));
    fprintf(fp, "Simpson: %f\n\n", simpsonint(f2, a, b, n));

    fprintf(fp, "Funkcja 3 (exp(x)):\n");
    fprintf(fp, "Monte Carlo: %f\n", mcarloint(f3, a, b, n));
    fprintf(fp, "Trapezy: %f\n", trapezint(f3, a, b, n));
    fprintf(fp, "Simpson: %f\n", simpsonint(f3, a, b, n));

    fclose(fp);
}

/*
// ZADANIE 5
// - Struktura Person
#undef WZROST_DEFINED
#undef PERSON_DEFINED

#ifndef WZROST_DEFINED
#define WZROST_DEFINED
typedef enum { niski, sredni, wysoki } Wzrost;
#endif

#ifndef PERSON_DEFINED
#define PERSON_DEFINED
typedef struct {
    char imie[30];
    char nazwisko[30];
    Wzrost wzrost;
} Person;
#endif


void print_person(Person p) {
    const char* wzrost_str[] = { "niski", "sredni", "wysoki" };
    printf("%s %s (%s)\n", p.imie, p.nazwisko, wzrost_str[p.wzrost]);
}

int compare_persons(const void* a, const void* b) {
    Person* pa = (Person*)a;
    Person* pb = (Person*)b;
    return strcmp(pa->nazwisko, pb->nazwisko);
}

void zadanie5() {
    Person people[3] = {
        {"Jan", "Kowalski", sredni},
        {"Anna", "Nowak", wysoki},
        {"Piotr", "Wisniewski", niski}
    };

    printf("Przed sortowaniem:\n");
    for (int i = 0; i < 3; i++) print_person(people[i]);

    qsort(people, 3, sizeof(Person), compare_persons);

    printf("\nPo sortowaniu:\n");
    for (int i = 0; i < 3; i++) print_person(people[i]);
}
*/
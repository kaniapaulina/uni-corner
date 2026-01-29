
#include <stdio.h>
#include <stdlib.h>

// Zadanie 1
typedef struct {
    char imie[30];
    char nazwisko[50];
    char data_ur[11];
    float placa;
} Pracownik;

// Zadanie 2
Pracownik* read_employees(char* fname, unsigned int* n);
void test_read_employees();

// Zadanie 3
int cmpempl(const void* a, const void* b);

// Zadanie 4
void cw11_zad4();

// Zadanie 5
Pracownik* highest_salary(Pracownik* pracownicy, int n);

// Zadanie 6
void print_by_lastname_letter(Pracownik* pracownicy, int n, char letter);

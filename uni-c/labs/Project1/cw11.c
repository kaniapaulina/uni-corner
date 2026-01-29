#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include <math.h>
#include <stdlib.h>
#include <time.h>
#include <ctype.h>

#include "cw11.h"

// ZADANIE 1
// - definiowanie struktur, w headerze

// ZADANIE 2
// - odczytanie danych z pliku
char cesar_letter(char c, int n) {
	char base = isupper(c) ? 'A' : 'a';
	if (n < 0) { 
		n = 26 + n; 
	}
	return (c - base + n) % 26 + base;
}

void cezar(char s[], int p) {
	for (int i = 0; s[i] != '\0'; ++i) {
		s[i] = cesar_letter(s[i], p);
	}
}

Pracownik* read_employees(char* fname, unsigned int *n) {
	FILE* fin = fopen(fname, "r");
	if (!fin) {
		return NULL; // file not opened
	}

	unsigned int nrec;
	unsigned short ncesar;

	if (fscanf_s(fin, "%u %hu", &nrec, &ncesar) != 2) {
		fclose(fin);
		return NULL; // incorrect data
	}

	Pracownik* empl = (Pracownik*)malloc(nrec * sizeof(Pracownik));
	if (empl == NULL) { fclose(fin);  return NULL; } // error in allocating memory

	*n = 0;
	for (unsigned int i = 0; i < nrec; ++i) {
		if (feof(fin)) { break; }
		if (fscanf_s(fin,
			"%s %s %hu/%hu/%hu %f",
			empl[i].imie, (unsigned int)sizeof(empl[i].imie),
			empl[i].nazwisko, (unsigned int)sizeof(empl[i].nazwisko),
			&empl[i].data_ur, &empl[i].placa) < 4) {
			--i; 
			continue;
		}
		cezar(empl[i].imie, -ncesar);
		cezar(empl[i].nazwisko, -ncesar);
		++(*n);
	}
	fclose(fin);
	return empl;
}

void test_read_employees()
{
	char* fname = "D:\\IiE\\SEMESTR2\\Programowanie Komputerowe\\Æwiczenia\\cwiczonka\\dane2025.txt";
	unsigned int n;
	Pracownik* employees = read_employees(fname, &n);
	for (unsigned int i = 0; i < n; ++i) {
		printf("%s %s\n", employees[i].imie, employees[i].nazwisko);
	}
	free(employees);
	employees = NULL;
}


// ZADANIE 3
int cmpempl(const void* a, const void* b) {
    Pracownik* pa = (Pracownik*)a;
    Pracownik* pb = (Pracownik*)b;
    int year_a, year_b;
    scanf(pa->data_ur, "%*d-%*d-%d", &year_a);
    scanf(pb->data_ur, "%*d-%*d-%d", &year_b);
    return year_a - year_b;
}

// ZADANIE 4
void cw11_zad4() {
    Pracownik* pracownicy = read_employees("D:\\IiE\\SEMESTR2\\Programowanie Komputerowe\\Æwiczenia\\cwiczonka\\dane2025.txt", 10);
    if (!pracownicy) return;

    // Dodanie nowego pracownika
    strcpy(pracownicy[0].imie, "MojeImie");
    strcpy(pracownicy[0].nazwisko, "MojeNazwisko");
    strcpy(pracownicy[0].data_ur, "01-01-2000");
    pracownicy[0].placa = 5000.0;

    qsort(pracownicy, 10, sizeof(Pracownik), cmpempl);

    FILE* bin = fopen("pracownicy.bin", "wb");
    fwrite(pracownicy, sizeof(Pracownik), 10, bin);
    fclose(bin);

    // Odczyt z pliku binarnego
    bin = fopen("pracownicy.bin", "rb");
    Pracownik odczytani[10];
    fread(odczytani, sizeof(Pracownik), 10, bin);
    fclose(bin);

    for (int i = 0; i < 10; i++) {
        printf("%s %s %s %.2f\n",
            odczytani[i].imie,
            odczytani[i].nazwisko,
            odczytani[i].data_ur,
            odczytani[i].placa);
    }

    free(pracownicy);
}

// ZADANIE 5
Pracownik* highest_salary(Pracownik* pracownicy, int n) {
    if (n == 0) return NULL;

    Pracownik* max = &pracownicy[0];
    for (int i = 1; i < n; i++) {
        if (pracownicy[i].placa > max->placa) {
            max = &pracownicy[i];
        }
    }
    return max;
}

// Zadanie 6
void print_by_lastname_letter(Pracownik* pracownicy, int n, char letter) {
    for (int i = 0; i < n; i++) {
        if (pracownicy[i].nazwisko[0] == letter) {
            printf("%s %s\n", pracownicy[i].imie, pracownicy[i].nazwisko);
        }
    }
}


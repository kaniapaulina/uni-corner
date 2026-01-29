// OPERACJE WEJSCIA/WYJSCIA

/*
	NOTATKI
	liczba calkowita
int - %d
short int/long int - %hd/%ld
long long - %lld
unsigned int - %u

int - %o (notacja ósemkowa)
int - %x (notacja szesnastkowa)

	liczba rzeczywista
float - %f
double - %lf

	znak, ³añcuch
char - %c
char[] - %s
*/

#include <stdio.h>
#include "cw1.h"

// ZADANIE 1 
// - "Hello World", standardowe wyjscie: stdout/printf
void cw1_zad1() {
	printf("Hello World! \n");
}

// ZADANIE 2 
// - standardowe wejscie: stdin/scanf
void cw1_zad2() {
	int a, b, c;
	printf("Podaj dwie liczby:");
	scanf_s("%d %d", &a, &b);	// s - znaczy ¿e safe XD
	c = a * b;
	if (a == b) {
		printf("Square[%d, %d] with an area: %d", a, b, c);
	}
	else {
		printf("Rectangle[% d, % d] with an area: % d", a, b, c);
	}
}

// ZADANIE 3
// - dla litery ‘a’ oraz liczby 89, komunikat to a = 89
void cw1_zad3() {
	int x;
	printf("Wpisz liczbe calkowita:");
	if (scanf_s("%d", &x) < 1 || ferror(stdin) != 0)	//niepoprawne wczytanie danych
	{
		x = -1;
	}

	fseek(stdin, 0, SEEK_END);	// czyszczenie bufora

	char lit;
	printf("wpisz litere np a:");
	if (scanf_s("%c", &lit, (unsigned int)sizeof(lit)) < 1 || ferror(stdin) != 0)	//char, element, dlugosc
	{
		lit = '?';
	}

	printf("%c = %d", lit, x);
}

void cw1_zad3_alt() {
	char c;
	int liczba;

	printf("Podaj literke i liczbe:");
	scanf_s("%c %d", &c, 1, &liczba); // 1 - d³ugosc wprowadzonych danych
	printf("%c = %d", c, liczba);
}

// ZADANIE 4
// - Wypisz rok z pelnej daty
void cw1_zad4() {
	int day, mon, year;
	printf_s("Wpisz date (dd/mm/yyyy) \n");
	if ((scanf_s("%d/%d/%d", &day, &mon, &year)) < 3 || ferror(stdin) != 0) {
		printf("Co ty robisz lol");
		return;
	}
	printf("You were born in %d", year);
}

// ZADANIE 5
// - wypisanie Imie i Nazwisko
void cw1_zad5() {
	char imie[30], nazwisko[30];
	printf("Podaj imie i nazwisko: ");
	if ((scanf_s("%s %s", &imie, 30, &nazwisko, 30)) < 2 || ferror(stdin) != 0) {
		// zamiast 30 - (unsigned int)sizeof(imie)
		printf("Niepoprawne dane!\n");
		return;
	}
	printf("Witaj %s %s", imie, nazwisko);
}
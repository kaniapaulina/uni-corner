// OPERACJE NA NAPISACH

#include <stdio.h>
#include "cw5.h"
#include <string.h>
#include <ctype.h> //isupper, islower
#include <stdlib.h>

// ZADANIE 1
// - dlugosc napisu bez uzycia strlen()
int my_stren(const char* str) {
	int length = 0;
	for (int i = 0; str[i] != '\0'; i++) { //'\0' - koniec lancucha znakow
		length++;
	}
	printf("DLugosc: %d", length);
}

void cw5_zad1() {
	my_stren("Wiosna");
}

// ZADANIE 2
// - pojawienie sie literki
int find_char(const char* s, char c) {
	int size = strlen(*s);
	for (int i = 0; i < size; i++) {
		if (s[i] == c) {
			printf("Literka %c pojawila sie na %d pozycji", c, i + 1);
		}
	}
}

void cw5_zad2() {
	find_char("Kuba i Asia", 'b'); //const char "", char ''
}

// ZADANIE 3
// - ilosc capitalized letters
int numof_big_letters_alt(const char* s) {
	int count = 0;
	while (*s) {
		if (isupper(*s)) {
			count++;
		}
		s++;
	}
	printf("Ilosc duzych liter to: %d", count);
 }

int numof_big_letters(const char* s) {
	int count = 0;
	int size = strlen(s);
	for (int i = 0; i<size;i++) {
		if (isupper(s[i])) {
			count++;
		}
	}
	printf("Ilosc duzych liter to: %d", count);
}

void cw5_zad3() {
	char s[50];
	printf("Podaj jakies zdanie: ");
	gets_s(s, sizeof(s));
	numof_big_letters(s);
}

// ZADANIE 4
// - szyfr cezara ? nie robie tego lol

//  ZADANIE 5
// - wypisanie wszytskich elementow zdania
void wyrazy_w_zdaniu(char* s) {
	char* last = NULL;
	char* wyraz = strtok_s(s, " ", &last);
	while (wyraz != NULL)  {
		printf("Wyraz: %s\n", wyraz);
		wyraz = strtok_s(NULL, " ", &last);
	}
}

void cw5_zad5() {
	char zdanie[] = "Programowanie w C";
	wyrazy_w_zdaniu(zdanie);
}

// ZADANIE 6
// - najczesciej wystepuj¹ca litera w zdaniu
char najczestsza_litera(const char* s) {
	// nie robie XD
}

// ZADANIE 7
// - czy wyraz jest palindromem (czytane tak samo od konca)
int palindrom(const char* s) {
	int size = strlen(s);
	for (int i = 0; i < size/2; i++) {
		if (s[i] != s[size-1-i]) {
			printf(" -> wyraz nie jest palindromem");
			return 0;
			}
	}
	return 1;
}

void cw5_zad7() {
	const char* tab[] = { "kajak", "banan", "potop" };
	int n = sizeof(tab) / sizeof(tab[0]);
	for (int i = 0; i < n; i++) {
		printf("%s", tab[i]);
		if (palindrom(tab[i])) {
			printf(" -> OK");
		}
		printf("\n");
	}
}

// ZADANIE 8
// - sklejanie maila
void email_address(const char* name, const char* surname) {
	int len = strlen(name) + strlen(surname) + strlen(".@agh.edu.pl") +1; //na '\0'
	char* result = (char*)malloc(len * sizeof(char));

	if (!result) {
		printf("B³¹d alokacji pamiêci.\n");
		return;
	}

	strcpy_s(result, len, name);
	strcat_s(result, len, ".");
	strcat_s(result, len, surname);
	strcat_s(result, len, "@agh.edu.pl");
	printf("%s\n", result);

	free(result);
}

void cw5_zad8() {
	const char* name = "Paulina";
	const char* surname = "Kania";
	email_address(name, surname);
}

//  ZADANIE 9
// - ilosc wyrazow zaczynajacych sie na dana literke
int wyrazy_na_litere(const char* s, char litera) {
	char* str_copy = _strdup(s);

	char* last = NULL;
	int licznik = 0;
	char* wyraz = strtok_s(str_copy, " ", &last);
	while (wyraz != NULL) {
		if (wyraz[0] == litera) {
			printf("%s\n", wyraz);
			licznik++;
		}
		wyraz = strtok_s(NULL, " ", &last);
	}
	printf("ilosc slow na literke %c: %d", litera, licznik);

	free(str_copy);
	return licznik;
}

void cw5_zad9() {
	wyrazy_na_litere("Gugudan i aespa i Gaga", 'G');
}
// FUNKCJE REKURENCYJNE

#include <stdio.h>
#include "cw6.h"
#include <stdlib.h>

// ZADANIE 1
// - dlugosc napisu
int rlen(char* s) {
	if (*s == '\0') {
		return 0;
	}
	else {
		return 1 + rlen(s + 1);
	}
}

void cw6_zad1() {
	char* text = "Test Test";
	printf("Dlugosc napisu: %d", rlen(text));
}

// ZADANIE 2
// - palindrom
int rpalindrom(char* s, int i) {
	int end = strlen(s) - 1; //pozycyjnie, -1 bo zaczyna sie od 0 pozycja
	if (i >= end / 2) {
		return 1;
	}
	if (s[i] != s[end - i]) {
		return 0;
	}
	return rpalindrom(s, i + 1);
}

void cw6_zad2() {
	char* tab[] = { "kajak", "banan", "potop", "kotlet", "owocowo", "strach", "spodek", "oko" };
	int size = sizeof(tab) / sizeof(tab[0]);
	for (int i = 0; i < size; i++) {
		if (rpalindrom(tab[i],0)) {
			printf("%s -> OK\n", tab[i]);
		}
		else {
			printf("%s\n", tab[i]);
		}
	}
}

// ZADANIE 3 
// - ilosc literki w napisie
int rfrequency(char* s, char c) {
	if (*s == '\0') {
		return 0;
	}
	if (*s == c) {
		return 1 + rfrequency(s + 1, c);
	}
	return rfrequency(s + 1, c);
}

void cw6_zad3() {
	char* s = "FiFi";
	char c = 'F';
	printf("Ilosc: %d", rfrequency(s, c));
}

// ZADANIE 4
// - silnia
int rfactorial(unsigned int n) {
	if (n == 0 || n == 1) {
		return 1;
	}
	else {
		return n * rfactorial(n - 1);
	}
}

void cw6_zad4() {
	printf("Silnia z 3 wynosi: %d", rfactorial(3));
}

// ZADANIE 5
// - NWD
int rnwd(unsigned int a, unsigned int b) {
	if (a > b) {
		a = a - b;
		return rnwd(a, b);
	}
	if (a < b) {
		b = b - a;
		return rnwd(a, b);
	}
	return a;
}

unsigned int nwd1(unsigned int a, unsigned int b) {
	if (b == 0)
		return a; // jeœli b jest 0, zwracamy a – to NWD
	else
		return nwd1(b, a % b); // wywo³anie rekurencyjne
}

void cw6_zad5() {
	srand(time(NULL));
	for (int i = 0; i < 20; i++) {
		int a = rand() % 1000;
		int b = rand() % 1000;
		printf("Dla (%d, %d) nwd wynosi: %d\n", a, b, rnwd(a, b));
	}
}

// ZADANIE 6
// - pozycja pierwszej cyfry w napisie
int rfind_first_digit(char* s) { //start: s=0
	if (*s == '\0') {
		return -1;
	}
	if (*s >= '0' && *s <= '9') {
		return 1;
	}

	int next = rfind_first_digit(s + 1);
	if (next == -1) {
		return -1;
	}
	else {
		return 1 + next;
	}
}

void cw6_zad6() {
	printf("Pierwsza liczba jest na: %d pozycji", rfind_first_digit("xdd3"));

}

// ZADANIE 7
// - liczenie sum cyfr
int rsum_of_digits(unsigned int n) {
	if (n == 0) {
		return 0;
	}
	return (n % 10) + rsum_of_digits(n / 10);
}

void cw6_zad7() {
	printf("Suma dla 123 to: %d", rsum_of_digits(123));
}

// ZADANIE 8
// - liczba Catalana XD
int rcatalan(unsigned int n) {
	if (n == 0) {
		return 1;
	}
	int sum = 0;
	for (int i = 0; i < n; i++) {
		sum += rcatalan(i) * rcatalan(n - 1 - i);
	}
	return sum;
}

void cw6_zad8() {
	printf("%d", rcatalan(5));
}
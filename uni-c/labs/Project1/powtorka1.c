// POWTORKA

//stdio.h	Operacje wejœcia / wyjœcia: printf(), scanf(), fopen(), fgets()
//stdlib.h	Funkcje ogólne : malloc(), free(), exit(), rand(), atoi()
//string.h	Operacje na ³añcuchach znaków : strcpy(), strlen(), strcmp()
//math.h	Funkcje matematyczne : pow(), sqrt(), sin(), abs()
//ctype.h	Sprawdzanie znaków : isdigit(), isalpha(), toupper(), tolower()
//time.h	Operacje na czasie : time(), clock(), difftime(), srand()

#include <stdio.h>
#include <string.h>
#include <math.h>
#include <stdlib.h>
#include <time.h>
#include <ctype.h>

//Z2
#define M 50

// ZADANIE 1
void zadanie1_test() {
	int ile;
	printf("Ile podasz liczb: ");
	scanf_s("%d", &ile);  	
	
	for (int i = 0; i < ile; i++) {
		int liczba;
		printf("Podaj liczbê: ");
		scanf_s("%d", &liczba);
		if (liczba % 10 == 9) {
			printf("%d konczy sie na 9\n", liczba);
		}
	}
}

void zadanie1() {
	int ile;
	printf("Ile podasz liczb: ");
	scanf_s("%d", &ile);
	int tab[100];
	printf("Podaj liczby: ");
	for (int i = 0; i < ile; i++) {
		scanf_s("%d", &tab[i]);
	}
	for (int i=0;i<ile;i++){
		if (abs(tab[i]) % 10 == 9) {
			printf("%d konczy sie na 9\n", tab[i]);
		}
	}
}

// ZADANIE 2
void zadanie2() {
	char imie[30], nazwisko[30];
	printf("Podaj swoje imie i nazwisko: ");
	scanf_s("%s %s", &imie, 30, &nazwisko, 30);
	int day, month, year;
	printf("Podaj swoj¹ date urodzenia (dd/mm/yyyy): ");
	scanf_s("%d/%d/%d", &day, &month, &year);

	int tab[M];
	int licznik = 0;
	srand(time(NULL));
	for (int i = 0; i < M; i++) {
		tab[i] = rand() % 63 - 31;
		printf("%d ", tab[i]);
		if (abs(tab[i]) < day) {
			licznik++;
		}
	}
	float wynik = (float)licznik / M;
	printf("\n");
	printf("Procent liczb mniejszych: %.2f%%", wynik*100);
	
}

// ZADANIE 3
int zadanie3(int a) {
	if (a == 0) {
		return 0;
	}
	else {
		return a % 10 + zadanie3(a / 10);
	}
}
// ZADANIE 4
int zadanie4(int n) {
	int m = 0;
	while (n > 0) {
		for (int i = 0; i < m; i++) {
			printf(" ");
		}
		for (int j = 0; j < n; j++) {
			printf("* ");
		}
		printf("\n");
		m += 2; 
		n -= 2;
	}
	return 1;
}


// ZADANIE 5
void zadanie5(char* s) {

	for (int i = 0; s[i] != '\0'; i++) {
		if (isupper(s[i])) {
			s[i] = tolower(s[i]);
		}
		else if (islower(s[i])) {
			s[i] = toupper(s[i]);
		}
	}
	printf("%s", s);
}



// TABLICE JEDNOWYMIAROWE

#include "cw7.h"
#include <stdlib.h>

// 0^0 = 0
// 1^0 = 1
// 0^1 = 1
// 1^1 = 0
//ZAD5
#define SWAP(x,y) \
	if (&x != &y) { \
		x ^= y; \
		y ^= x; \
		x ^= y; \
	} 

#define MAX 100

// ZADANIE 1
// - suma poszczegolnych cyfr w tablicy
int cw7_zad1(long long liczba) {
	//char tab[30];
	//sprintf_s(tab, sizeof(tab), "%lld", liczba); //zapisuje liczbe jako znak, czyli cyfre lld na tab
	int suma = 0;
	//for (int i = 0; i < strlen(tab); i++) {
	//	suma = suma + tab[i] - '0'; //konwersja na znak cyfry
	//}
	while (liczba != 0) {
		suma += liczba % 10; //pobiera ostatnia liczbe
		liczba /= 10; //usuwa ostatnia liczbe
	}
	return suma;
} //blad byl w inicjacji tab w petli btw

void cw7_zad1_test() {
	long long tab[] = { 78, 34, 123, 678, 34, 567, 1023, 5869, 5, 435, 546, 666, 999 };
	int size = sizeof(tab) / sizeof(tab[0]);
	for (int i = 0; i < size; i++) {
		printf_s("%lld: %d \n", tab[i], cw7_zad1(tab[i]));
	}
}

// ZADANIE 2
// - pierwsze wystapienie liczby w tablicy
int cw7_zad2(long long tab[], int size, long long wartosc) {
	int index = -1;
	for (int i = 0; i < size; i++) {
		if (tab[i] == wartosc) {
			index = 1;
			break;
		}
	}
	return index;
}

void cw7_zad2_test() {
	long long tab[] = { 78, 34, 123, 678, 34, 567, 1023, 5869, 5, 435, 546, 666, 999 };
	int size = sizeof(tab) / sizeof(tab[0]);
	long long wartosc = 678;

	int index = cw7_zad2(tab, size, wartosc);
	if (index == -1) {
		printf("Nie ma kolegi");
	}
	else {
		printf("Znalazlem kolege %lld tyle razy: %d", wartosc, index);
	}
}

// ZADANIE 3
// - maxymalna liczba podzielna przez 3
int cw7_zad3(long long tab[], int size) {
	int max = -10000;
	for (int i = 0; i < size; i++) {
		if (tab[i] % 3 == 0) {
			if (tab[i] > max) {
				max = tab[i];
			}
		}
	}
	return max;
}

void cw7_zad3_test() {
	int tab[10];
	int size = 10;
	srand(time(NULL));
	for (int i = 0; i < size; i++) {
		tab[i] = (rand() % 121) - 60;
		printf_s("los: %d \n", tab[i]);
	}

	int max = cw7_zad3(tab, size);
	if (max == -10000) {
		printf("Nie ma liczby podzilenej przez 3");
	}
	else {
		printf("Najwieksza liczba to: %d", max);
	}
}

// ZADANIE 4
int cw7_zad4(int tab[], int size, int liczba) {
	int licznik = 0;
	for (int i = 0; i < size; i++) {
		if (tab[i] == liczba) {
			licznik++;
		}
	}
	return licznik;
}

void cw7_zad4_test() {
	int tab[] = { 18, 3, 5, 29, 3, 18, 6, 9, 32, 3, 9, 9, 9, 23, 3, 18, 21, 6, 7, 7, 1, 2, 6, 5, 4, 8, 9, 9, 1, 9, 23 };
	int size = sizeof(tab) / sizeof(tab[0]);
	int liczba;
	printf("podaj jakas liczbe dobry czlowieku: ");
	if (scanf_s("%d", &liczba) != 1) {  // Check if input was successful
		printf("Niepoprawne dane! Wprowadz liczbe.\n");
		return;  // Exit if input is invalid
	}
	int licznik = cw7_zad4(tab, size, liczba);
	printf("Liczba %d wystepuje %d razy", liczba, licznik);
}

// ZADANIE 5
void cw7_zad5(int tab[], int size) {
	for (int i = 0; i < size-1; i++) {
		for (int j = 0; j < size -1- i; j++) {
			if (tab[j] > tab[j + 1]) {
				SWAP(tab[j], tab[j + 1]);
			}
		}
	}
}

void cw7_zad5_test() {
	int tab[MAX];
	srand(time(NULL));

	for (int i = 0; i < MAX; i++) {
		tab[i] = rand() % 1000;
	}

	printf("Tablica PRZED sortowaniem:\n");
	for (int i = 0; i < MAX; i++) {
		printf("%d ", tab[i]);
	}

	cw7_zad5(tab, MAX);

	printf("\n\nTablica PO sortowaniu:\n");
	for (int i = 0; i < MAX; i++) {
		printf("%d ", tab[i]);
	}

	printf("\n");
}

// ZADANIE 6
void cw7_zad6(int tab[], int size) {
	for (int i = 0; i < size - 1; i++) {
		int max = i;
		for (int j = i + 1; j < size; j++) {
			if (tab[j] > tab[max]) {
				max = j;
			}
		}
		SWAP(tab[i], tab[max]);
	}
}

void cw7_zad6_test() {
	int tab[60];
	int size = sizeof(tab) / sizeof(tab[0]);
	srand(time(NULL));
	for (int i = 0; i < size; i++) {
		tab[i] = rand() % 121 - 60;
	}

	printf("Tabela Przed Sortowaniem\n");
	for (int i = 0; i < size; i++) {
		printf("%d ", tab[i]);
	}
	printf("\n");

	cw7_zad6(tab, size);

	printf("Tabela Po Sortowaniu\n");
	for (int i = 0; i < size; i++) {
		printf("%d ", tab[i]);
	}
}

// ZADANIE 8
// - szachownica
void cw7_zad8() {
	int tab[10][10];
	for (int i = 0; i < 10; i++) {
		for (int j = 0; j < 10; j++) {
			tab[i][j] = (i + j) % 2;
		}
	}
	for (int i = 0; i < 10; i++) {
		for (int j = 0; j < 10; j++) {
			printf_s("\t%d ", tab[i][j]);
		}
		printf_s("\n");
	}

}
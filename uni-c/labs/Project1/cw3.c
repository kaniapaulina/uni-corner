// FUNKCJE, INSTRUKCJE STERUJ¥CE

#include <stdio.h>
#include "cw3.h"
#include <math.h>
#include <stdlib.h>

// ZADANIE 1
// - dzielone przez 3 i 5
int div_3_or_5(int a) {
	if ((a % 3 == 0) || (a % 5 == 0)) {
			return 1; //true
		}
		else {
			return 0; //false
		}
}
void cw3_zad1() {
	if (div_3_or_5(15)) { // funkcja testowa
		printf("Dzieli sie");
	}
	else {
		printf("Nie dzieli sie");
	}
}

// ZADANIE 2
// - operator bitowy sprawdzajacy czy liczby maja ten sam znak
int same_signs(int a, int b) {
	int c;
	c = a ^ b; // roznica znaku

	if (c > 0) {
		printf("(%d, %d) Takie same\n", a, b);
	}
	else {
		printf("(%d, %d) Inne\n ", a, b);
	}

	//samo return starczy by zwrocic prawda lub falsz, powyzej jest wersja rozbudowana
	return ((a ^ b) >= 0); // bramka XOR - gdy znaki s¹ rowne: 1, gdy przeciwne: 0
}

void cw3_zad2() {
	same_signs(3, -3); // funkcja testowa
}

//  ZADANIE 3
// - czy a jest poteg¹ dwójki, wykorzystuj¹c przesuniêcie bitowe
int is_power_of_2(unsigned int a) {
	return (a != 0) && ((a & (a - 1)) == 0); //to jest w postaci binarnej tu robione..
}

void cw3_zad3() {
	if (is_power_of_2(4)) { // funkcja testowa
		printf("jest git");
	}
	else {
		printf("Nie jest git");
	}
}

//  ZADANIE 4
// - wykorzystujac div3or5 liczy sume i srednia liczb
void cw3_zad4() { //void sum_avg_div_3_or_5()
	int n, x;
	int suma = 0, ile = 0;
	printf("Ile podasz liczb \n");
	scanf_s("%d", &n);
	for (int i = 0; i < n; i++) {
		printf("Podaj liczbe %d: ", i + 1);
		scanf_s("%d", &x);
		if (div_3_or_5(x)) {
			suma = suma + x;
			ile++;
		}
	}
	if (ile>0) {
		float srednia = suma / ile;
		printf("Suma: %d, srednia: %.2f", suma, srednia);
	}
	else {
		printf("Nic sie nie dzieli przez 3 i 5");
	}
}

// ZADANIE 5
// - ile jest liczb ktore s¹ potêg¹ dwojki

int is_power_of_two(unsigned int n) {
	return n != 0 && (n & (n - 1)) == 0;
}
int num_of_power_of_2() {
	unsigned int liczba;
	int licznik = 0;
	do {
		if (scanf_s("%u", &liczba) != 0 && is_power_of_two(liczba)) {
			licznik++;
		}
	} while (liczba != 0);
	printf("Ilosc liczb podzielnych przez 2 to: %d", licznik);
}

//  ZADANIE 6 
// - przetestuj same_signs na 10 parach losowych liczb
void cw3_zad6() {
	srand(time(NULL));
	int i = 0;
	while (i < 10) {
		int a = rand() % 201 - 100; //los n (czyli od 0 do n-1)
		int b = rand() % 201 - 100;
		same_signs(a, b);
		i++;
	}
}

// ZADANIE 7
// - NWD
int nwd(int a, int b) {
	a = abs(a);
	b = abs(b);
	while (a != b) {
		if (a > b) {
			a -= b;
		}
		else {
			b -= a;
		}
	}
	return a;
}

// ZADANIE 8
// - test NWD
void nwd_test() {
	srand(time(NULL));
	int a = rand() % 101 - 50;	
	int los;
	printf("Podaj ilosc liczb b: ");
	scanf_s("%d", &los);
	for (int i=0; i<los;i++) {
		int b = rand() % 101 - 50;
		printf("Najwiekszy wspolny dzielnik (%d, %d) to: %d\n", a, b, nwd(a, b));
	}
}
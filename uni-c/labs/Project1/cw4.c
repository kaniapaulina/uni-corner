// DYREKTYWY PREPROCESORA, MAKRA, MAKROFUNKCJE

#include <stdio.h>
#include "cw4.h"

// ZAD1
#define MAXW 20
#define MAXH MAXW+30
// ZAD2
#define TABELEM 4, 5, 6, -7, 8, 0, 12, 1, 6, -5, 8, -7, 9, 10, -22
// ZAD3
#define EVEN(x) (((x)%2) == 0 ? 1:0) //zwraca jeden gdy prawda, 0 gdy falsz
// ZAD5
#define MAX2(x,y) ((x) > (y) ? (x):(y))
// ZAD7
#define SIGN(x) ((x) < 0 ? -1:((x) > 0 ? 1:0))
#define SIGN2(x) \
{               \
    if(x<0)     \
    {            \
        printf("%d", -1); \
    }                \
    else if (x==0)    \
    {                \
        printf("%d", 0);    \
    }                \
    else            \
    {                \
        printf("%d", 1);    \
    }                \
}                    \




// ZADANIE 1
// - dyrektywy procesora
void cw4_zad1() {
	printf("Iloczyn wynosi: %d", MAXW * MAXH);
}

// ZADANIE 2
// - wypisanie tablicy
void test_tabelem() {
	int tab[] = { TABELEM };
	int size = sizeof(tab)/sizeof(tab[0]);
	printf("ilosc elementow: %d\n", size);
	for (int i = 0; i < size; i++) {
		printf("%d ", tab[i]);
	}
}

// ZADANIE 3
// - jednoargumentowa makrofunkcja EVEN
void cw4_zad3() {
	int a = 3;
	if (EVEN(a)) {
		printf("%d jest parzysta\n", a);
	}
	else {
		printf("%d jest nieparzysta\n", a);
	}
}

// ZADANIE 4
// - dopisanie do test_tabelem, tylko elementow parzystych
void cw4_zad4() {
	int tab[] = { TABELEM };
	int size = sizeof(tab) / sizeof(tab[0]);
	printf("ilosc elementow: %d\n", size);
	for (int i = 0; i < size; i++) {
		if (tab[i] % 2 != 0) {
			printf("%d ", tab[i]);
		}
	}
}

// ZADANIE 5
// - makrofunkcja MAX2, zwracaj¹ca najwiekszy argument
void cw4_zad5() {
	int a = 3, b = 5;
	int max = MAX2(a,b);
	printf("MAX to: %d", max);
}

// ZADANIE 6
// - dopisac do test_tabelem MAX2
void cw4_zad6() {
	int tab[] = { TABELEM };
	int size = sizeof(tab) / sizeof(tab[0]);
	int max = tab[0];
	printf("ilosc elementow: %d\n", size);
	for (int i = 0; i < size; i++) {
		printf("%d ", tab[i]);
		max = MAX2(tab[i], max);
	}
	printf("\nNajwieksza wartosc to: %d", max);
}

// ZADANIE 7
// - wypisanie znaku z tablicy
void cw4_zad7() {
	int tab[] = { TABELEM };
	int size = sizeof(tab) / sizeof(tab[0]);
	int max = tab[0];
	printf("ilosc elementow: %d\n", size);
	for (int i = 0; i < size; i++) {
		int znak = SIGN(tab[i]);
		printf("element %d wynosi: %d z znakiem: %d\n", i+1, tab[i], znak);
		max = MAX2(tab[i], max);
	}
	printf("\nNajwieksza wartosc to: %d", max);
}

// ZADANIE 8
// - ciag bonafidego obciagnij mi chuja
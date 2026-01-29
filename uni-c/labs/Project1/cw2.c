// OPERACJE WEJSCIA/WYJSCIA

/*
sizeof - Rozmiar w bajtach - Wszystko	
_countof - Iloœæ elementów w tablicy - Tylko tablice
strlen - Iloœæ znaków do \0 - Tylko char[]	

*/


#include <stdio.h>
#include "cw2.h"
#include <math.h>
#include <time.h>
#include <stdlib.h>
#include <string.h>

// ZADANIE 6
// - podaj trzy liczby i oblicz max i average
void cw2_zad6() {
    int a, b, c, max;
    double ave;
    printf("Podaj trzy liczby:");
    scanf_s("%d %d %d", &a, &b, &c);
    max = a;
    if (max < b) {
        max = b;
    }
    if (max < c) {
        max = c;
    }
    ave = (a + b + c) / 3.0;
    printf("max(%d, %d, %d) = %d \n", a, b, c, max);
    printf("avg(%d, %d, %d) = %.2lf", a, b, c, ave);
}

// ZADANIE 7
// - podaj liczbe w notacjach osemkowych i szesnastkowych
void cw2_zad7() {
    int liczba;
    printf("Podaj liczbe kolego:");
    scanf_s("%d", &liczba);
    printf("%d, %o, %x", liczba, liczba, liczba);
}

// ZADANIE 8
// - wypisane danych plus petla z rozpoznawaniem danych
void cw2_zad8() {
    char imie[30], nazwisko[30];
    int wiek;
    float waga, wzrost;
    char gender; 
    printf("Podaj swoje imie i nazwisko\n");
    scanf_s("%s %s", &imie, 30, &nazwisko, 30); // 30 - (unsigned)_countof(imie)
    printf("Podaj swoj wiek, wage i wzrost\n");
    scanf_s("%d %f %f", &wiek, &waga, &wzrost);

    while (getchar() != '\n'); // oproznienie buffora

    printf("Podaj swoja plec (K/M)\n");
    scanf_s("%c", &gender, 1);

    float BMI = waga / (wzrost*wzrost);

    if (gender == 'K' || gender == 'k') { 
        printf("%s %s (woman) with BMI %.1f", imie, nazwisko, BMI);
    }
    else {
        printf("%s %s (man) with BMI %.1f", imie, nazwisko, BMI);
    }
}

void cw2_zad8_alt() {
    char imie[30], nazwisko[30];
    int wiek;
    float waga, wzrost;
    char gender[2]; 
    printf("Podaj swoje imie i nazwisko\n");
    scanf_s("%s %s", &imie, 30, &nazwisko, 30); // 30 - (unsigned)_countof(imie)
    printf("Podaj swoj wiek, wage i wzrost\n");
    scanf_s("%d %f %f", &wiek, &waga, &wzrost);

    printf("Podaj swoja plec (K/M)\n");
    scanf_s("%s", &gender, (unsigned)sizeof(gender));

    float BMI = waga / (wzrost * wzrost);

    if (gender[0] == 'K' || gender[0] == 'k') { 
        printf("%s %s (woman) with BMI %.1f", imie, nazwisko, BMI);
    }
    else {
        printf("%s %s (man) with BMI %.1f", imie, nazwisko, BMI);
    }
}

// ZADANIE 9
// - dzia³ania matematyczne
void cw2_zad9() {
    double num1, num2, wynik;
    char operacja;
    if (scanf_s("%lf %c %lf", &num1, &operacja, 1, &num2) != 3 || ferror(stdin) != 0) {
        printf("Error");
        return;
    }

    switch (operacja) {
        case '+':
            wynik = num1 + num2;
            printf("Wynik to %.2lf \n", wynik);
            break;
        case '-':
            wynik = num1 - num2;
            printf("Wynik to %.2lf \n", wynik);
            break;
        case '*':
            wynik = num1 * num2;
            printf("Wynik to %.2lf \n", wynik);
            break;
        case '/':
            if (num2 == 0) {
                printf("NIE DZIEL PRZEZ ZERO");
                return;
            }
            else {
                wynik = num1 / num2;
                printf("Wynik to %.2lf \n", wynik);
            }
            break;
        default:
            printf("Co ty tworzysz");
    }
}

// ZADANIE 10
// - równanie kwadratowe
void cw2_zad10() {
    float a, b, c;
    printf("Podaj a, b i c \n");
    if (scanf_s("%f %f %f", &a, &b, &c) < 3 || ferror(stdin) != 0) {
        printf("ERROR");
        return;
    }
    float delta = b*b - 4 * a * c; // pow(b,2)
    if (delta > 0) {
        float x1 = ((-b) - sqrt(delta)) / 2 * a;
        float x2 = ((-b) + sqrt(delta)) / 2 * a;
        printf("x1 = %.2f i x2 = %.2f", x1, x2);
    }
    else if (delta == 0) {
        float x = (-1*b) / 2 * a;
        printf("x = %.2f", x);
    }
    else {
        float real =  (- 1 * b) / (2 * a);
        float imag = sqrt(-delta) / (2 * a);
        printf("Dwa pierwiastki zespolone:\n");
        printf("x1 = %.2f - %.2fi\n", real, imag);
        printf("x2 = %.2f + %.2fi\n", real, imag);
    }
}

// ZADANIE 11
// - Zgadywanka
void cw2_zad11() {
    srand(time(NULL));
    int los = rand() % 10 + 1;
    int answer;
    int i = 0;
    printf("Podaj liczbê z zakresu 1-10: ");
    do {
        if (scanf_s("%d", &answer) < 1 || ferror(stdin) != 0) {
            printf("ERROR");
            while (getchar() != '\n'); // czyszczenie bufora
            continue;
        }

        if (answer > los) {
            printf("Too big!\n");
            i++;
        }
        else if (answer < los) {
            printf("Too small!\n");
            i++;
        }
        else {
            break;
        }
    } while (answer != los);
    printf("Zgadles popelniajac %d bledow", i);
}

// ZADANIE 12
// - funkcja znajduj¹ca dana literke i miejsce wystapienia
void cw2_zad12() {
    char slowo[30];
    char literka;
    printf("Podaj s³owo: ");
    scanf_s("%s", slowo, (unsigned)_countof(slowo));

    getchar(); //usuwa znak nowej linijki po enterze - ignoruje ale bez tego nie dziala..

    printf("Podaj literkê do wyszukania: ");
    scanf_s("%c", &literka, 1);

    for (int i = 0; i < (unsigned)_countof(slowo); i++) {
        if (slowo[i] == literka) {
            int position = i + 1;
            printf("position([%c] in %s = %d \n", literka, slowo, position);
        }
    }
}
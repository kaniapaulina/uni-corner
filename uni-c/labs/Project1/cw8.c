// TABLICE DWUWYMIAROWE
// i alokacja pamiêci

#include "cw8.h"
#include <stdio.h>
#include <stdlib.h>

// ZADANIE 1
// - najwiekszy i najmniejszy element tablicy
void min_max_row(int* a, int n, int* min, int* max) {
    *min = a[0];
    *max = a[0];
    for (int i = 1; i < n; i++) {
        if (a[i] < *min) *min = a[i];
        if (a[i] > *max) *max = a[i];
    }
}

// ZADANIE 2
// - dzialanie na macierzach
int** allocate_matrix(int n, int m) {
    int** a = (int**)malloc(n * sizeof(int*));
    for (int i = 0; i < n; i++) {
        a[i] = (int*)malloc(m * sizeof(int));
    }
    return a;
}

void fill_matrix(int** a, int n, int m) {
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            a[i][j] = rand() % 100;
        }
    }
}

void print_matrix(int** a, int n, int m) {
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            printf("%d ", a[i][j]);
        }
        printf("\n");
    }
}

void free_matrix(int** a, int n) {
    for (int i = 0; i < n; i++) {
        free(a[i]);
    }
    free(a);
}

void min_max_tab_2D(int** a, int n, int m) {
    int min, max;
    for (int i = 0; i < n; i++) {
        min_max_row(a[i], m, &min, &max);
        printf("Wiersz %d: min = %d, max = %d\n", i, min, max);
    }
}

void test_min_max_tab_2D() {
    int n = 3, m = 4;
    int** a = allocate_matrix(n, m);
    fill_matrix(a, n, m);
    print_matrix(a, n, m);
    min_max_tab_2D(a, n, m);
    free_matrix(a, n);
}

// ZADANIE 3
// - suma po przek¹tnych
int suma_przekatnych(int** a, int n) {
    int sum = 0;
    for (int i = 0; i < n; i++) {
        sum += a[i][i]; // g³ówna przek¹tna
        sum += a[i][n - 1 - i]; // przeciwna przek¹tna
    }
    if (n % 2 == 1) sum -= a[n / 2][n / 2]; // odejmij œrodek jeœli by³ dodany dwukrotnie
    return sum;
}

void test_sums() {
    int n = 3;
    int** a = allocate_matrix(n, n);
    fill_matrix(a, n, n);
    print_matrix(a, n, n);
    printf("Suma przek¹tnych: %d\n", suma_przekatnych(a, n));
    free_matrix(a, n);
}

// ZADANIE 4
// - najwiekszy wspolny dzielnik
int nwdmatrix(int a, int b) {
    while (b != 0) {
        int temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

void max_rwdmatrix(int** a, int n, int m) {
    int max_nwd = 0;
    for (int i1 = 0; i1 < n; i1++) {
        for (int j1 = 0; j1 < m; j1++) {
            for (int i2 = 0; i2 < n; i2++) {
                for (int j2 = 0; j2 < m; j2++) {
                    if (i1 != i2 || j1 != j2) {
                        int current = nwd(a[i1][j1], a[i2][j2]);
                        if (current > max_nwd) max_nwd = current;
                    }
                }
            }
        }
    }
    printf("Najwiêkszy NWD: %d\n", max_nwd);
}

// ZADANIE 5
// - porównywanie wartoœci, quick sort
int compare(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

void sort_quick(int* a, int n) {
    qsort(a, n, sizeof(int), compare);
}

void sort_rows(int** a, int n, int m) {
    for (int i = 0; i < n; i++) {
        sort_quick(a[i], m);
    }
}

// ZADANIE 6
// - obracanie macierzy o 90 stopni
int** rotate90degree(int** a, int n, int m) {
    int** rotated = allocate_matrix(m, n);
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            rotated[i][j] = a[j][m - 1 - i];
        }
    }
    return rotated;
}
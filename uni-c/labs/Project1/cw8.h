//#ifndef cw8_h
#define cw8_h

#pragma once
#include <stdlib.h>

// Zadanie 1
void min_max_row(int* a, int n, int* min, int* max);

// Zadanie 2
int** allocate_matrix(int n, int m);
void fill_matrix(int** a, int n, int m);
void print_matrix(int** a, int n, int m);
void free_matrix(int** a, int n);
void min_max_tab_2D(int** a, int n, int m);
void test_min_max_tab_2D();

// Zadanie 3
int suma_przekatnych(int** a, int n);
void test_sums();

// Zadanie 4
int nwdmatrix(int a, int b);
void max_rwdmatrix(int** a, int n, int m);

// Zadanie 5
int compare(const void* a, const void* b);
void sort_quick(int* a, int n);
void sort_rows(int** a, int n, int m);

// Zadanie 6
int** rotate90degree(int** a, int n, int m);

//#endif // cw8_h
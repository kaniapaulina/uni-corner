/*#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include "macierz.h"

int** allocate_matrix(int n, int m)
{
	int** a = malloc(n * sizeof(*a));
	if (a == NULL) { return NULL; }
	for (int i = 0; i < n; ++i) {
		a[i] = malloc(m * sizeof(**a));
		if (a[i] == NULL) {
			for (int j = 0; j < i; ++j) {
				free(a[j]);
			}
			free(a);
			a = NULL;
			return NULL;
		}
	}
	return a;
}

void free_matrix(int** a, int n)
{
	for (int i = 0; i < n; ++i) {
		free(a[i]);
	}
	free(a);
	a = NULL;
}

void fill_matrix(int** a, int n, int m, int start, int end)
{
	srand((unsigned int)time(0));
	for (int i = 0; i < n; ++i) {
		for (int j = 0; j < m; ++j) {
			a[i][j] = rand() % (end - start + 1) + start;
		}
	}
}

void print_matrix(int** a, int n, int m)
{
	for (int i = 0; i < n; ++i) {
		for (int j = 0; j < m; ++j) {
			printf("%4d", a[i][j]);
		}
		printf("\n");
	}
}*/
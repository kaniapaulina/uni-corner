#ifndef TETRIS_H
#define TETRIS_H

#include <stdbool.h>

#define WIDTH 10
#define HEIGHT 20
#define BLOCK_SIZE 4
#define HIGHSCORE_FILE "tetris_scores.csv"

// Deklaracja tablicy shapes
extern const int shapes[7][4][4][4];

extern int board[HEIGHT][WIDTH];
extern int score;
extern int current_piece, rotation, x, y;

void nowyblok();
bool ruszamypanowie(int new_x, int new_y, int new_rot);
void rysuj();
void fulllinia();

#endif
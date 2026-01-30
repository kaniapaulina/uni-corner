


#include "tetris.h"
#include <conio.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include <windows.h>

// Tetromino shapes (I, O, S, Z, T, L, J) in all rotations
const int shapes[7][4][4][4] = {
    // I piece
    {{{0,0,0,0}, {1,1,1,1}, {0,0,0,0}, {0,0,0,0}},
    {{0,0,1,0}, {0,0,1,0}, {0,0,1,0}, {0,0,1,0}},
    {{0,0,0,0}, {0,0,0,0}, {1,1,1,1}, {0,0,0,0}},
    {{0,1,0,0}, {0,1,0,0}, {0,1,0,0}, {0,1,0,0}}},
    // O piece
    {{{0,0,0,0}, {0,1,1,0}, {0,1,1,0}, {0,0,0,0}},
    {{0,0,0,0}, {0,1,1,0}, {0,1,1,0}, {0,0,0,0}},
    {{0,0,0,0}, {0,1,1,0}, {0,1,1,0}, {0,0,0,0}},
    {{0,0,0,0}, {0,1,1,0}, {0,1,1,0}, {0,0,0,0}}},
    // S piece
    {{{0,0,0,0}, {0,0,1,1}, {0,1,1,0}, {0,0,0,0}},
    {{0,0,1,0}, {0,0,1,1}, {0,0,0,1}, {0,0,0,0}},
    {{0,0,0,0}, {0,0,1,1}, {0,1,1,0}, {0,0,0,0}},
    {{0,1,0,0}, {0,1,1,0}, {0,0,1,0}, {0,0,0,0}}},
    // Z piece
    {{{0,0,0,0}, {1,1,0,0}, {0,1,1,0}, {0,0,0,0}},
    {{0,0,0,1}, {0,0,1,1}, {0,0,1,0}, {0,0,0,0}},
    {{0,0,0,0}, {1,1,0,0}, {0,1,1,0}, {0,0,0,0}},
    {{0,0,1,0}, {0,1,1,0}, {0,1,0,0}, {0,0,0,0}}},
    // T piece
    {{{0,0,0,0}, {0,1,0,0}, {1,1,1,0}, {0,0,0,0}},
    {{0,0,0,0}, {0,1,0,0}, {0,1,1,0}, {0,1,0,0}},
    {{0,0,0,0}, {1,1,1,0}, {0,1,0,0}, {0,0,0,0}},
    {{0,0,1,0}, {0,1,1,0}, {0,0,1,0}, {0,0,0,0}}},
    // L piece
    {{{0,0,0,0}, {1,0,0,0}, {1,1,1,0}, {0,0,0,0}},
    {{0,0,0,0}, {0,1,1,0}, {0,1,0,0}, {0,1,0,0}},
    {{0,0,0,0}, {1,1,1,0}, {0,0,1,0}, {0,0,0,0}},
    {{0,0,1,0}, {0,0,1,0}, {0,1,1,0}, {0,0,0,0}}},
    // J piece
    {{{0,0,0,0}, {0,0,1,0}, {1,1,1,0}, {0,0,0,0}},
    {{0,0,0,0}, {0,1,0,0}, {0,1,0,0}, {0,1,1,0}},
    {{0,0,0,0}, {1,1,1,0}, {1,0,0,0}, {0,0,0,0}},
    {{0,1,1,0}, {0,0,1,0}, {0,0,1,0}, {0,0,0,0}}}
};

int board[HEIGHT][WIDTH] = { 0 };
int score = 0;
int current_piece, rotation, x, y;

void nowyblok() {
    current_piece = rand() % 7;
    rotation = 0;
    x = WIDTH / 2 - 2;
    y = 0;

    // Check if game over
    for (int i = 0; i < BLOCK_SIZE; i++) {
        for (int j = 0; j < BLOCK_SIZE; j++) {
            if (shapes[current_piece][rotation][i][j] &&
                (y + i >= HEIGHT || (y + i >= 0 && board[y + i][x + j]))) {
                system("cls");
                printf("Game Over! Score: %d\n", score);
                exit(0);
            }
        }
    }
}

bool ruszamypanowie(int new_x, int new_y, int new_rot) {
    for (int i = 0; i < BLOCK_SIZE; i++) {
        for (int j = 0; j < BLOCK_SIZE; j++) {
            if (shapes[current_piece][new_rot][i][j]) {
                int board_x = new_x + j;
                int board_y = new_y + i;

                if (board_x < 0 || board_x >= WIDTH || board_y >= HEIGHT)
                    return false;
                if (board_y >= 0 && board[board_y][board_x])
                    return false;
            }
        }
    }
    return true;
}

void rysuj() {
    system("cls");
    int highscore = load_highscore();

    // Draw board with current piece
    for (int i = 0; i < HEIGHT; i++) {
        printf("|");
        for (int j = 0; j < WIDTH; j++) {
            // Check if this cell is part of the current piece
            int piece_cell = 0;
            if (i >= y && i < y + BLOCK_SIZE && j >= x && j < x + BLOCK_SIZE) {
                piece_cell = shapes[current_piece][rotation][i - y][j - x];
            }

            if (piece_cell) printf("[]");
            else if (board[i][j]) printf("##");
            else printf("  ");
        }
        printf("|\n");
    }

    // Draw bottom border
    printf("+");
    for (int i = 0; i < WIDTH; i++) printf("--");
    printf("+\n");

    printf("Score: %d | High Score: %d\n", score, highscore);
    printf("Controls: Arrow keys to move, Space to rotate\n");
}

void fulllinia() {
    for (int i = HEIGHT - 1; i >= 0; i--) {
        int line_full = 1;
        for (int j = 0; j < WIDTH; j++) {
            if (!board[i][j]) line_full = 0;
        }

        if (line_full) {
            // Move all lines above down
            memmove(&board[1], &board[0], sizeof(board[0]) * i);
            // Clear top line
            memset(&board[0], 0, sizeof(board[0]));
            score += 100;
            i++; // Check same line again
        }
    }
}

// ZAPISYWANIE WYNIKU W PLIKU CSV
void save_highscore(int score) {
    FILE* file = fopen(HIGHSCORE_FILE, "a"); // 'a' - tryb dopisywania

    if (file != NULL) {
        // Pobierz aktualn¹ datê i czas
        time_t now = time(NULL);
        struct tm* t = localtime(&now);
        char date_str[20];
        strftime(date_str, sizeof(date_str), "%Y-%m-%d %H:%M:%S", t);

        // Zapisz wynik w formacie: data,wynik
        fprintf(file, "%s,%d\n", date_str, score);
        fclose(file);
    }
}

//Funkcja wczytuj¹ca najwy¿szy wynik z pliku
int load_highscore() {
    FILE* file = fopen(HIGHSCORE_FILE, "r");
    int highscore = 0;

    if (file != NULL) {
        char line[100];
        while (fgets(line, sizeof(line), file)) {
            int current_score;
            if (scanf_s(line, "%*[^,],%d", &current_score) == 1) {
                if (current_score > highscore) {
                    highscore = current_score;
                }
            }
        }
        fclose(file);
    }

    return highscore;
}
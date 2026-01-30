//#ifdef _MSC_VER
//#define safe_sprintf sprintf_s
//#else
//#define safe_sprintf snprintf
//#endif
//
//
//#include "tetris2.h"
//#include <conio.h>
//#include <stdio.h>
//#include <stdlib.h>
//#include <string.h>
//#include <time.h>
//#include <windows.h>
//
//// Tetromino shapes (I, O, S, Z, T, L, J) in all rotations
//const char shapes[7][4][4][4] = {
//    // I piece
//    {{{0,0,0,0}, {1,1,1,1}, {0,0,0,0}, {0,0,0,0}},
//     {{0,0,1,0}, {0,0,1,0}, {0,0,1,0}, {0,0,1,0}},
//     {{0,0,0,0}, {0,0,0,0}, {1,1,1,1}, {0,0,0,0}},
//     {{0,1,0,0}, {0,1,0,0}, {0,1,0,0}, {0,1,0,0}}},
//     // O piece
//     {{{0,0,0,0}, {0,1,1,0}, {0,1,1,0}, {0,0,0,0}},
//      {{0,0,0,0}, {0,1,1,0}, {0,1,1,0}, {0,0,0,0}},
//      {{0,0,0,0}, {0,1,1,0}, {0,1,1,0}, {0,0,0,0}},
//      {{0,0,0,0}, {0,1,1,0}, {0,1,1,0}, {0,0,0,0}}},
//      // S piece
//      {{{0,0,0,0}, {0,0,1,1}, {0,1,1,0}, {0,0,0,0}},
//       {{0,0,1,0}, {0,0,1,1}, {0,0,0,1}, {0,0,0,0}},
//       {{0,0,0,0}, {0,0,1,1}, {0,1,1,0}, {0,0,0,0}},
//       {{0,1,0,0}, {0,1,1,0}, {0,0,1,0}, {0,0,0,0}}},
//       // Z piece
//       {{{0,0,0,0}, {1,1,0,0}, {0,1,1,0}, {0,0,0,0}},
//        {{0,0,0,1}, {0,0,1,1}, {0,0,1,0}, {0,0,0,0}},
//        {{0,0,0,0}, {1,1,0,0}, {0,1,1,0}, {0,0,0,0}},
//        {{0,0,1,0}, {0,1,1,0}, {0,1,0,0}, {0,0,0,0}}},
//        // T piece
//        {{{0,0,0,0}, {0,1,0,0}, {1,1,1,0}, {0,0,0,0}},
//         {{0,0,0,0}, {0,1,0,0}, {0,1,1,0}, {0,1,0,0}},
//         {{0,0,0,0}, {1,1,1,0}, {0,1,0,0}, {0,0,0,0}},
//         {{0,0,1,0}, {0,1,1,0}, {0,0,1,0}, {0,0,0,0}}},
//         // L piece
//         {{{0,0,0,0}, {1,0,0,0}, {1,1,1,0}, {0,0,0,0}},
//          {{0,0,0,0}, {0,1,1,0}, {0,1,0,0}, {0,1,0,0}},
//          {{0,0,0,0}, {1,1,1,0}, {0,0,1,0}, {0,0,0,0}},
//          {{0,0,1,0}, {0,0,1,0}, {0,1,1,0}, {0,0,0,0}}},
//          // J piece
//          {{{0,0,0,0}, {0,0,1,0}, {1,1,1,0}, {0,0,0,0}},
//           {{0,0,0,0}, {0,1,0,0}, {0,1,0,0}, {0,1,1,0}},
//           {{0,0,0,0}, {1,1,1,0}, {1,0,0,0}, {0,0,0,0}},
//           {{0,1,1,0}, {0,0,1,0}, {0,0,1,0}, {0,0,0,0}}}
//};
//
//char board[HEIGHT][WIDTH] = { 0 };
//int score = 0;
//int current_piece, rotation, x, y;
//
//// Console handle for faster output
//HANDLE hConsole;
//COORD bufferSize = { WIDTH * 2 + 2, HEIGHT + 4 };
//COORD bufferCoord = { 0, 0 };
//SMALL_RECT writeArea = { 0, 0, WIDTH * 2 + 1, HEIGHT + 3 };
//CHAR_INFO consoleBuffer[(WIDTH * 2 + 2) * (HEIGHT + 4)];
//
//void init_console() {
//    hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
//    SetConsoleWindowInfo(hConsole, TRUE, &writeArea);
//    SetConsoleScreenBufferSize(hConsole, bufferSize);
//}
//
//void new_piece() {
//    current_piece = rand() % 7;
//    rotation = 0;
//    x = WIDTH / 2 - 2;
//    y = 0;
//
//    // Check if game over
//    for (int i = 0; i < BLOCK_SIZE; i++) {
//        for (int j = 0; j < BLOCK_SIZE; j++) {
//            if (shapes[current_piece][rotation][i][j] &&
//                (y + i >= HEIGHT || (y + i >= 0 && board[y + i][x + j]))) {
//                system("cls");
//                printf("Game Over! Score: %d\n", score);
//                exit(0);
//            }
//        }
//    }
//}
//
//bool valid_move(int new_x, int new_y, int new_rot) {
//    for (int i = 0; i < BLOCK_SIZE; i++) {
//        for (int j = 0; j < BLOCK_SIZE; j++) {
//            if (shapes[current_piece][new_rot][i][j]) {
//                int board_x = new_x + j;
//                int board_y = new_y + i;
//
//                if (board_x < 0 || board_x >= WIDTH || board_y >= HEIGHT)
//                    return false;
//                if (board_y >= 0 && board[board_y][board_x])
//                    return false;
//            }
//        }
//    }
//    return true;
//}
//
//void draw() {
//    // Clear the buffer
//    for (int i = 0; i < bufferSize.X * bufferSize.Y; i++) {
//        consoleBuffer[i].Char.AsciiChar = ' ';
//        consoleBuffer[i].Attributes = 7;
//    }
//
//    // Draw borders
//    for (int i = 0; i < HEIGHT + 1; i++) {
//        consoleBuffer[i * bufferSize.X].Char.AsciiChar = '|';
//        consoleBuffer[i * bufferSize.X + WIDTH * 2 + 1].Char.AsciiChar = '|';
//    }
//    for (int i = 0; i < WIDTH * 2 + 2; i++) {
//        consoleBuffer[(HEIGHT + 1) * bufferSize.X + i].Char.AsciiChar = '-';
//    }
//
//    // Draw board with current piece
//    for (int i = 0; i < HEIGHT; i++) {
//        for (int j = 0; j < WIDTH; j++) {
//            int pos = (i + 1) * bufferSize.X + 1 + j * 2;
//
//            // Check if this cell is part of the current piece
//            int piece_cell = 0;
//            if (i >= y && i < y + BLOCK_SIZE && j >= x && j < x + BLOCK_SIZE) {
//                piece_cell = shapes[current_piece][rotation][i - y][j - x];
//            }
//
//            if (piece_cell) {
//                consoleBuffer[pos].Char.AsciiChar = '[';
//                consoleBuffer[pos + 1].Char.AsciiChar = ']';
//                consoleBuffer[pos].Attributes = consoleBuffer[pos + 1].Attributes = 14; // Yellow
//            }
//            else if (board[i][j]) {
//                consoleBuffer[pos].Char.AsciiChar = '[';
//                consoleBuffer[pos + 1].Char.AsciiChar = ']';
//                consoleBuffer[pos].Attributes = consoleBuffer[pos + 1].Attributes = 11; // Cyan
//            }
//        }
//    }
//
//    // Draw score
//    char scoreText[20];
//    safe_sprintf(scoreText, sizeof(scoreText), "Score: %d", score);
//    for (int i = 0; i < strlen(scoreText); i++) {
//        consoleBuffer[(HEIGHT + 3) * bufferSize.X + i].Char.AsciiChar = scoreText[i];
//    }
//
//    // Write the buffer to console
//    WriteConsoleOutput(hConsole, consoleBuffer, bufferSize, bufferCoord, &writeArea);
//}
//
//void merge_piece() {
//    for (int i = 0; i < BLOCK_SIZE; i++) {
//        for (int j = 0; j < BLOCK_SIZE; j++) {
//            if (shapes[current_piece][rotation][i][j]) {
//                if (y + i >= 0) { // Only merge if above or at the top
//                    board[y + i][x + j] = 1;
//                }
//            }
//        }
//    }
//}
//
//void clear_lines() {
//    for (int i = HEIGHT - 1; i >= 0; i--) {
//        int line_full = 1;
//        for (int j = 0; j < WIDTH; j++) {
//            if (!board[i][j]) line_full = 0;
//        }
//
//        if (line_full) {
//            // Move all lines above down
//            memmove(&board[1], &board[0], sizeof(board[0]) * i);
//            // Clear top line
//            memset(&board[0], 0, sizeof(board[0]));
//            score += 100;
//            i++; // Check same line again
//        }
//    }
//}
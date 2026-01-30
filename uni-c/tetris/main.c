#include "tetris.h"
#include "tetris2.h"
#include <conio.h>    // dla _kbhit i _getch
#include <stdio.h>    // dla printf
#include <stdlib.h>   // dla rand, exit
#include <time.h>     // dla time
#include <windows.h>  // dla Sleep


int main() {
    srand((unsigned)time(NULL));
    nowyblok();

    while (1) {
        // Handle input
        if (_kbhit()) {
            int key = _getch();
            switch (key) {
            case 32: // Space - rotate
                if (ruszamypanowie(x, y, (rotation + 1) % 4))
                    rotation = (rotation + 1) % 4;
                break;
            case 75: // Left
                if (ruszamypanowie(x - 1, y, rotation)) x--;
                break;
            case 77: // Right
                if (ruszamypanowie(x + 1, y, rotation)) x++;
                break;
            case 80: // Down
                if (ruszamypanowie(x, y + 1, rotation)) y++;
                break;
            }
        }

        // Game logic
        static int counter = 0;
        if (++counter > 15) {  // Zwiêkszona wartoœæ spowalnia grê
            counter = 0;
            if (ruszamypanowie(x, y + 1, rotation)) {
                y++;
            }
            else {
                // Scalanie klocka z plansz¹
                for (int i = 0; i < BLOCK_SIZE; i++) {
                    for (int j = 0; j < BLOCK_SIZE; j++) {
                        if (shapes[current_piece][rotation][i][j] && y + i >= 0) {
                            board[y + i][x + j] = 1;
                        }
                    }
                }
                fulllinia();
                nowyblok();
            }
        }

        rysuj();
        Sleep(100);  // Zwiêkszona wartoœæ spowalnia grê
    }

    return 0;


    //WERSJA DRUGAA
    //srand(time(NULL));
    //init_console();
    //new_piece();

    //clock_t lastTime = clock();
    //const int targetFrameTime = 200; // Milliseconds per frame

    //while (1) {
    //    clock_t currentTime = clock();
    //    float deltaTime = (float)(currentTime - lastTime) * 1000 / CLOCKS_PER_SEC;

    //    if (deltaTime >= targetFrameTime) {
    //        // Handle input
    //        if (_kbhit()) {
    //            int key = _getch();
    //            switch (key) {
    //            case 32: // Space - rotate
    //                if (valid_move(x, y, (rotation + 1) % 4))
    //                    rotation = (rotation + 1) % 4;
    //                break;
    //            case 75: // Left
    //                if (valid_move(x - 1, y, rotation)) x--;
    //                break;
    //            case 77: // Right
    //                if (valid_move(x + 1, y, rotation)) x++;
    //                break;
    //            case 80: // Down
    //                if (valid_move(x, y + 1, rotation)) y++;
    //                break;
    //            }
    //        }

    //        // Game logic
    //        if (valid_move(x, y + 1, rotation)) {
    //            y++;
    //        }
    //        else {
    //            merge_piece();
    //            clear_lines();
    //            new_piece();
    //        }

    //        draw();
    //        lastTime = currentTime;
    //    }
    //}

    return 0;
}
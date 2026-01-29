#include <stdio.h>
#include <stdlib.h>

#include "cw12.h"

// Zadanie 1
// - w headerze

// Zadanie 2
Node* create_node(int value) {
    Node* newNode = (Node*)malloc(sizeof(Node));
    if (newNode == NULL) {
        printf("Blad alokacji");
        return 0;
    }
    Node* node = malloc(sizeof(Node));
    node->data = value;
    node->left = NULL;
    node->right = NULL;
    return node;
}

// Zadanie 3
Node* insertLeft(Node* root, int value) {
    root->left = create_node(value);
    return root->left;
}

Node* insertRight(Node* root, int value) {
    root->right = create_node(value);
    return root->right;
}

// Zadanie 4 - Metody przechodzenia
void inorder(Node* root) {
    if (root == NULL) return;
    inorder(root->left);
    printf("%d ", root->data);
    inorder(root->right);
}

void preorder(Node* root) {
    if (root == NULL) return;
    printf("%d ", root->data);
    preorder(root->left);
    preorder(root->right);
}

// Zadanie 5 - Testowanie
void test_tree() {
    Node* root = create_node(1);
    insertLeft(root, 2);
    insertRight(root, 3);

    insertLeft(root->left, 4);
    insertRight(root->left, 5);

    printf("Inorder: ");
    inorder(root);
    printf("\n");

    printf("Preorder: ");
    preorder(root);
    printf("\n");
}
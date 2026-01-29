
// Zadanie 1
typedef struct Node Node;

struct Node {
    int data;
    struct Node* left;
    struct Node* right;
};

// Zadanie 2
Node* create_node(int value);

// Zadanie 3
Node* insertLeft(Node* root, int value);
Node* insertRight(Node* root, int value);

// Zadanie 4
void inorder(Node* root);
void preorder(Node* root);

// Zadanie 5
void test_tree();



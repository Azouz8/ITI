#include <iostream>
#include <vector>
using namespace std;

class Employee
{
public:
    int id;
    string name;
    Employee(int id = 0, string name = "")
    {
        this->id = id;
        this->name = name;
    }
};

class Node
{
public:
    Employee emp;
    Node *left, *right;
    Node(Employee e)
    {
        emp = e;
        left = nullptr;
        right = nullptr;
    }
};

class BST
{
public:
    Node *root;
    BST()
    {
        root = nullptr;
    }

    void allocateNewNode(Employee e)
    {
        Node *newNode = new Node(e);
        if (!root)
        {
            root = newNode;
        }
        else
        {
            insertNode(root, newNode);
        }
        balanceTree(root);
    }
    void insertNode(Node *&current, Node *newNode)
    {
        if (newNode->emp.id < current->emp.id)
        {
            if (!current->left)
            {
                current->left = newNode;
            }
            else
            {
                insertNode(current->left, newNode);
            }
        }
        else if (newNode->emp.id > current->emp.id)
        {
            if (!current->right)
            {
                current->right = newNode;
            }
            else
            {
                insertNode(current->right, newNode);
            }
        }
        else
        {
            cout << "Node already Exist\n";
        }
    }
    void traverseTree(Node *root)
    {
        if (root != NULL)
        {
            traverseTree(root->left);
            cout << "ID: " << root->emp.id << ", Name: " << root->emp.name << endl;
            traverseTree(root->right);
        }
    }
    int countNodes(Node *root)
    {
        if (root != NULL)
        {
            return countNodes(root->left) + 1 + countNodes(root->right);
        }
        return 0;
    }
    int countLevels(Node *root)
    {
        if (root == NULL)
        {
            return 0;
        }
        int leftLevels = countLevels(root->left);
        int rightLevels = countLevels(root->right);
        return max(leftLevels, rightLevels) + 1;
    }
    void Delete(Node *&root, int empID)
    {
        if (root == NULL)
        {
            return;
        }
        if (empID < root->emp.id)
        {
            Delete(root->left, empID);
        }
        else if (empID > root->emp.id)
        {
            Delete(root->right, empID);
        }
        else if (empID == root->emp.id)
        {
            removeNode(root);
        }
    }
    void removeNode(Node *&root)
    {
        if (root->left == NULL && root->right == NULL)
        {
            delete root;
            root = NULL;
        }
        else if (root->left == NULL)
        {
            Node *temp = root;
            root = root->right;
            delete temp;
        }
        else if (root->right == NULL)
        {
            Node *temp = root;
            root = root->left;
            delete temp;
        }
        else
        {
            Node *parent = root;
            Node *successor = root->left;
            while (successor->right != NULL)
            {
                parent = successor;
                successor = successor->right;
            }
            root->emp = successor->emp;
            Delete(root->left, successor->emp.id);
        }
    }
    void balanceTree(Node *&root)
    {
        vector<Employee> arr;
        inorderFill(root, arr);
        deleteTree(root);
        root = buildBalanced(arr, 0, (int)arr.size() - 1);
    }
    void inorderFill(Node *node, vector<Employee> &out)
    {
        if (!node)
            return;
        inorderFill(node->left, out);
        out.push_back(node->emp);
        inorderFill(node->right, out);
    }

    void deleteTree(Node *&node)
    {
        if (!node)
            return;
        deleteTree(node->left);
        deleteTree(node->right);
        delete node;
        node = nullptr;
    }

    Node *buildBalanced(const vector<Employee> &arr, int l, int r)
    {
        if (l > r)
            return nullptr;
        int mid = l + (r - l) / 2;
        Node *n = new Node(arr[mid]);
        
        n->left = buildBalanced(arr, l, mid - 1);
        n->right = buildBalanced(arr, mid + 1, r);
        return n;
    }
};

int main()
{
    BST tree;
    tree.allocateNewNode(Employee(3, "Ali"));
    tree.allocateNewNode(Employee(1, "Ahmed"));
    tree.allocateNewNode(Employee(4, "Mohamed"));
    tree.allocateNewNode(Employee(2, "Omar"));

    cout << "In-order Traversal of BST:" << endl;
    tree.traverseTree(tree.root);

    cout << "Total Nodes in BST: " << tree.countNodes(tree.root) << endl;
    cout << "Total Levels in BST: " << tree.countLevels(tree.root) << endl;

    int deleteID = 3;
    cout << "Deleting Employee with ID: " << deleteID << endl;
    tree.Delete(tree.root, deleteID);

    cout << "In-order Traversal after Deletion:" << endl;
    tree.traverseTree(tree.root);
}
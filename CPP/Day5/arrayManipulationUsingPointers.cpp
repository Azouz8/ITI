#include <iostream>
using namespace std;

int main()
{
    cout << "Enter the size of the array: ";
    int size;
    cin >> size;
    int *arr = new int[size];
    int *curr = arr;
    for (int i = 0; i < size; i++, curr++)
    {
        cout << "Enter Index: " << i << ": ";
        cin >> *curr;
    }
    system("cls");
    curr = arr;
    cout << "Ur array ->\n";
    for (int i = 0; i < size; i++, curr++)
    {
        cout << *curr << endl;
    }
}
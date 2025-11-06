#include <iostream>
using namespace std;

void replaceNums(int arr[], int size)
{
    for (int i = 0; i < size; i++)
    {
        if (i < size / 2)
        {
            arr[i] = 1;
        }
        else
        {
            arr[i] = 0;
        }
    }
}

void displayArray(int arr[], int size)
{
    for (int i = 0; i < size; i++)
    {
        cout << arr[i] << "\t";
    }
}

int main()
{
    int arr[10] = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
    replaceNums(arr, 10);
    displayArray(arr, 10);
}
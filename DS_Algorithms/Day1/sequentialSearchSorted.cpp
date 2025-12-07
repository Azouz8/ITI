#include <iostream>
using namespace std;

int seqSearchSorted(int *arr, int size, int value)
{
    for (int i = 0; (i < size) && (value >= arr[i]); i++)
    {
        if (arr[i] == value)
        {
            return i;
        }
    }
    return -1;
}

int main()
{
    int arr[5] = {1, 2, 3, 4, 5};
    cout << seqSearchSorted(arr, 5, 55);
}
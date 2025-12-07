#include <iostream>
using namespace std;

int binarySearchRec(int target, int *arr, int low, int high)
{
    int middle;
    while (low <= high)
    {
        middle = (low + high) / 2;
        if (target == arr[middle])
        {
            return middle;
        }
        else if (target < arr[middle])
        {
            high = middle - 1;
            binarySearchRec(target, arr, low, high);
        }
        else
        {
            low = middle + 1;
            binarySearchRec(target, arr, low, high);
        }
    }
    return -1;
}

int binarySearchItr(int target, int *arr, int size)
{
    int low = 0, high = size - 1, middle;
    while (low <= high)
    {
        middle = (low + high) / 2;
        if (target == arr[middle])
        {
            return middle;
        }
        else if (target < arr[middle])
        {
            high = middle - 1;
        }
        else
        {
            low = middle + 1;
        }
    }
    return -1;
}

int main()
{
    int arr[8] = {1, 2, 3, 4, 5, 6, 7, 8};
    cout << binarySearchRec(4, arr, 0, 7) << endl;
    cout << binarySearchItr(4, arr, 7);
}
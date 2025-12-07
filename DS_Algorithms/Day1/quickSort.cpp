#include <iostream>
using namespace std;

void swap(int &a, int &b)
{
    int temp = a;
    a = b;
    b = temp;
}

void quickSort(int *arr, int left, int right)
{
    if (right <= left)
        return;
    int pivot = arr[right];
    int partitionIndex = left;
    for (int i = left; i < right; i++)
    {
        if (arr[i] <= pivot)
        {
            swap(arr[i], arr[partitionIndex]);
            partitionIndex++;
        }
    }
    swap(arr[partitionIndex], arr[right]);
    quickSort(arr, left, partitionIndex - 1);
    quickSort(arr, partitionIndex + 1, right);
}

int main()
{
    int arr[8] = {5, 2, 4, 6, 8, 1, 3, 7};
    quickSort(arr, 0, 7);
    for (int i = 0; i < 8; i++)
    {
        cout << arr[i] << "  ";
    }
}
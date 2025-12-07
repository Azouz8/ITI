#include <iostream>
#include <vector>
using namespace std;

void heapify(int *arr, int size, int i)
{
    int largest = i;
    int l = 2 * i + 1;
    int r = 2 * i + 2;

    if (l < size && arr[l] > arr[largest])
        largest = l;

    if (r < size && arr[r] > arr[largest])
        largest = r;

    if (largest != i)
    {
        swap(arr[i], arr[largest]);
        heapify(arr, size, largest);
    }
}

void heapSort(int *arr, int size)
{
    int n = size;

    for (int i = n / 2 - 1; i >= 0; i--)
    {
        heapify(arr, n, i);
    }
    for (int i = n - 1; i > 0; i--)
    {

        swap(arr[0], arr[i]);

        heapify(arr, i, 0);
    }
}

int main()
{
    int arr[7] = {9, 4, 3, 8, 10, 2, 5};

    heapSort(arr, 7);

    for (int i = 0; i < 7; ++i)
        cout << arr[i] << " ";
}
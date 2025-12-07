#include <iostream>
using namespace std;

void swap(int &a, int &b)
{
    int temp = a;
    a = b;
    b = temp;
}

void bubbleSort(int *arr, int size)
{
    bool sorted = false;
    for (int i = 0; i < size && !sorted; i++)
    {
        sorted = true;
        for (int j = 0; j < size - 1 - i; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                swap(arr[j], arr[j + 1]);
                sorted = false;
            }
        }
    }
}

int main()
{
    int arr[8] = {5, 2, 4, 6, 8, 1, 3, 7};
    bubbleSort(arr , 8);
    for(int i=0; i<8; i++){
        cout<<arr[i]<<"  ";
    }
}
#include <iostream>
#include <vector>
using namespace std;

void merge(int *arr, int lFirst, int lLast, int rFirst, int rLast)
{
    vector<int> tempArr;
    int saveFirst = lFirst;
    while ((lFirst <= lLast) && (rFirst <= rLast))
    {
        if (arr[lFirst] < arr[rFirst])
        {
            tempArr.push_back(arr[lFirst++]);
        }
        else
        {
            tempArr.push_back(arr[rFirst++]);
        }
    }
    while (lFirst <= lLast)
    {
        tempArr.push_back(arr[lFirst++]);
    }
    while (rFirst <= rLast)
    {
        tempArr.push_back(arr[rFirst++]);
    }
    for (int i = saveFirst; i < rLast; i++)
    {
        arr[i] = tempArr[i - saveFirst];
    }
}

void mergeSort(int left, int right, int *arr)
{
    if (left >= right)
        return;
    int middle = (left + right) / 2;
    mergeSort(left, middle, arr);
    mergeSort(middle + 1, right, arr);
    merge(arr, left, middle, middle + 1, right);
}

int main()
{
    int arr[8] = {5, 2, 4, 6, 8, 1, 3, 7};
    mergeSort(0, 7, arr);
    for (int i = 0; i < 8; i++)
    {
        cout << arr[i] << "  ";
    }
}
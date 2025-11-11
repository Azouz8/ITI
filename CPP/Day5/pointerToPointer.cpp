#include <iostream>
using namespace std;

int main()
{
    int rows, cols;
    cout << "Enter number of rows: ";
    cin >> rows;
    cout << "Enter number of columns: ";
    cin >> cols;

    int **arr = new int *[rows];
    for (int i = 0; i < rows; i++)
        arr[i] = new int[cols];

    cout << "\nEnter elements of the array:\n";
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            cout << "arr[" << i << "][" << j << "] = ";
            cin >> arr[i][j];
        }
    }

    cout << "\nArray elements are:\n";
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            cout << *(*(arr + i) + j) << " ";
        }
        cout << endl;
    }
}

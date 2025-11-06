#include <iostream>
using namespace std;

int main()
{
    int n, acc = 1;
    cout << "Enter Grid Dimension: ";
    cin >> n;
    int row = 0, col = n/2;
    do
    {
        if (row < 0)
            row = n - 1;
        if (col > n - 1)
            col = 0;

        cout << "\033[" << (row+2)*2 << ";" << col*6 << "H" << acc;
        if (acc % n == 0)
        {
            row++;
            acc++;
            continue;
        }
        row--;
        col++;
        acc++;
    } while (acc <= n * n);
}
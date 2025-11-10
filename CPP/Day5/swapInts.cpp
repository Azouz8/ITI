#include <iostream>
using namespace std;

void swapByAddress(int *x, int *y)
{
    int temp = *x;
    *x = *y;
    *y = temp;
}
void swapByRef(int &x, int &y)
{
    int temp = x;
    x = y;
    y = temp;
}

int main()
{
    int n1 = 10, n2 = 20;
    swapByAddress(&n1, &n2);
    cout << "First Swap (using Address)\n";
    cout << "n1: " << n1 << endl
         << "n2: " << n2 << endl;
    swapByRef(n1, n2);
    cout << "First Swap (using Refrence)\n";
    cout << "n1: " << n1 << endl
         << "n2: " << n2 << endl;
}
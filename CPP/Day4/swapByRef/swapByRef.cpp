#include <iostream>
using namespace std;

void swap(int &x, int &y)
{
    int temp;
    temp = x;
    x = y;
    y = temp;
}

int main()
{
    int n1 = 5, n2 = 6;
    swap(n1, n2);
    cout << "n1: " << n1 << "\nn2: " << n2 << endl;
}
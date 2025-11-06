#include <iostream>
using namespace std;

int main()
{
    int n , breaker = 1;
    cout<<"Enter Dimension: ";
    cin>>n;
    for (int i = 0; i < n * n; i++)
    {
        if (i % (n + 1) == 0)
        {
            cout << "* ";
        }
        else
        {
            cout << "- ";
        }
        if (breaker % n == 0)
        {
            cout << endl;
        }
        breaker++;
    }
}
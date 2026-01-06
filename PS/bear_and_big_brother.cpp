#include <iostream>
using namespace std;

int main()
{
    int limak, bob, year = 0;
    cin >> limak >> bob;
    while (true)
    {
        if (limak > bob)
        {
            break;
        }
        else
        {
            limak *= 3;
            bob *= 2;
            year++;
        }
    }
    cout << year;
}
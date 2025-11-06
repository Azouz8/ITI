#include <iostream>
using namespace std;

int main()
{
    int n1, n2;
    cout << "Enter 2 Numbers: ";
    cin >> n1 >> n2;
    char op;

    while (op != 'e' || op != 'E')
    {
        cout << "a-add\nb-subtract\nc-multiply\nd-divide\ne-exit\n";
        cout << "Choose the operation: ";
        cin >> op;

        switch (op)
        {
        case 'a':
        case 'A':
            cout << "sum = " << n1 + n2<<endl;
            break;
        case 'b':
        case 'B':
            cout << "sub = " << n1 - n2<<endl;
            break;
        case 'c':
        case 'C':
            cout << "mul = " << n1 * n2<<endl;
            break;
        case 'd':
        case 'D':
            cout << "div = " << n1 / n2<<endl;
            break;
        case 'e':
        case 'E':
            return 0;
            break;

        default:
            cout << "Not a valid Operation\n";
            break;
        }
    }
}
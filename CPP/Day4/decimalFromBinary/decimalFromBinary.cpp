#include <iostream>
using namespace std;

int binaryToDecimal(int binary)
{
    if (binary == 0)
        return 0;

    return (binary % 10) + 2 * binaryToDecimal(binary / 10);
}

int main()
{
    int binary = 1010;
    cout << "Decimal value: " << binaryToDecimal(binary) << endl;
}

#include <iostream>
#include <complex>
using namespace std;

template <class T>
T sum(T a, T b)
{
    return a + b;
}

int main()
{
    int n1 = 5, n2 = 10;
    cout << "Int sum = " << sum(n1, n2) << endl;

    float n3 = 1.5f, n4 = 2.5f;
    cout << "Float sum = " << sum(n3, n4) << endl;

    double n5 = 3.14, n6 = 2.86;
    cout << "Double sum = " << sum(n5, n6) << endl;

    complex<double> c1(1.0, 2.0);
    complex<double> c2(3.0, 4.0);
    cout << "Complex sum = " << sum(c1, c2) << endl;

}

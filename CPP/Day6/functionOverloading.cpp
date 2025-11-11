#include <iostream>
using namespace std;

class Calculator
{
public:
    int sum(int x, int y)
    {
        return x + y;
    }
    double sum(int x, double y)
    {
        return x + y;
    }
    double sum(double x, int y)
    {
        return x + y;
    }
    double sum(double x, double y)
    {
        return x + y;
    }
};

int main()
{
    Calculator c;
    cout<<c.sum(5,3)<<endl;
    cout<<c.sum(5,3.5)<<endl;
    cout<<c.sum(5.9,3)<<endl;
    cout<<c.sum(5.4,3.3)<<endl;
}
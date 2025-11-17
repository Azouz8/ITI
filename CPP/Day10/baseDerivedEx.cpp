#include <iostream>
using namespace std;

class Base
{
protected:
    int a, b;

public:
    Base() = default;
    Base(int n) : a(n), b(n) {}
    Base(int n1, int n2) : a(n1), b(n2) {}
    void setA(int n)
    {
        a = n;
    }
    void setB(int n)
    {
        b = n;
    }
    int getA()
    {
        return a;
    }
    int getB()
    {
        return b;
    }
    int calcSum()
    {
        return a + b;
    }
};

class Derived : public Base
{
private:
    int c;

public:
    Derived() : c(0) {}
    Derived(int n) : Base(n), c(n) {}
    Derived(int n1, int n2, int n3) : Base(n1, n2), c(n3) {}
    void setC(int num)
    {
        c = num;
    }
    int getC()
    {
        return c;
    }
    int calcSum()
    {
        return Base::calcSum() + c;
    }
};

int main()
{
    Derived d;
    d.setA(5);
    d.setB(6);
    d.setC(1);
    cout << d.calcSum() << endl;
}
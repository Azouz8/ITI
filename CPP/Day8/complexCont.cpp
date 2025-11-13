#include <iostream>
using namespace std;

class Complex
{
private:
    float real, img;
    static int activeObjCount;

public:
    Complex() = default;
    Complex(float val)
    {
        cout << "Parameterized Constructor Called (float)" << endl;
        this->real = val;
        this->img = val;
        activeObjCount++;
    }
    Complex(float real, float img)
    {
        cout << "Parameterized Constructor Called (float, float)" << endl;
        this->real = real;
        this->img = img;
        activeObjCount++;
    }
    Complex operator+(Complex c2)
    {
        Complex c3(0, 0);
        c3.real = this->real + c2.real;
        c3.img = this->img + c2.img;
        return c3;
    }
    Complex operator-(Complex c2)
    {
        Complex c3(0, 0);
        c3.real = this->real - c2.real;
        c3.img = this->img - c2.img;
        return c3;
    }
    Complex operator*(Complex c2)
    {
        Complex c3(0, 0);
        c3.real = this->real * c2.real;
        c3.img = this->img * c2.img;
        return c3;
    }
    Complex operator/(Complex c2)
    {
        Complex c3(0, 0);
        c3.real = this->real / c2.real;
        c3.img = this->img / c2.img;
        return c3;
    }
    bool operator>(Complex c2)
    {
        if (this->real > c2.real)
        {
            return true;
        }
        else if (this->real < c2.real)
        {
            return false;
        }
        else
        {
            if (this->img > c2.img)
            {
                return true;
            }
            else if (this->img < c2.img)
            {
                return false;
            }
        }
    }
    bool operator<(Complex c2)
    {
        if (this->real < c2.real)
        {
            return true;
        }
        else if (this->real > c2.real)
        {
            return false;
        }
        else
        {
            if (this->img < c2.img)
            {
                return true;
            }
            else if (this->img > c2.img)
            {
                return false;
            }
        }
    }
    Complex operator++()
    {
        this->real++;
        return *this;
    }
    Complex operator--()
    {
        this->real--;
        return *this;
    }
    friend ostream &operator<<(ostream &out, const Complex &c);
    ~Complex()
    {
        cout << "Destructor Called" << endl;
        activeObjCount--;
    }
    static int getNoOfActiveObj()
    {
        return activeObjCount;
    }
    void display()
    {
        if (real == 0)
        {
            if (img == 0)
            {
                cout << 0 << endl;
            }
            else if (img == 1)
                cout << "i" << endl;
            else if (img == -1)
                cout << "-i" << endl;
            else
                cout << img << "i" << endl;
        }
        else if (img == 0)
        {
            cout << real << endl;
        }
        else if (img < 0)
        {
            if (img == -1)
            {
                cout << real << " - i" << endl;
            }
            else
            {
                cout << real << " - " << -img << "i" << endl;
            }
        }
        else
        {
            if (img == 1)
            {
                cout << real << " + i" << endl;
            }
            else if (img == -1)
            {
                cout << real << " - i" << endl;
            }
            else
            {
                cout << real << " + " << img << "i" << endl;
            }
        }
    }
};

int Complex::activeObjCount = 0;
ostream &operator<<(ostream &out, const Complex &c)
{
    out << c.real << " + " << c.img << "i";
    return out;
}

int main()
{
    Complex c1(5.0f, 7.0f);
    Complex c2(-3.0f, -3.0f);
    Complex c3(0.0f, -8.0f);
    Complex c4(0.0f, 8.0f);
    Complex c5(0.0f, -9.0f);
    cout << "Active Complex Objects: " << Complex::getNoOfActiveObj() << endl;
    Complex c9 = c1 + c2;
    cout << "c1 + c2: " << c9 << endl;
    cout << "c1: " << c1 << endl;
    if (c1 > c2)
    {
        cout << "c1 is greater than c2" << endl;
    }
    else
    {
        cout << "c2 is greater than c1" << endl;
    }
    cout <<"c1 after incrementing: "<< ++c1 << endl;
}
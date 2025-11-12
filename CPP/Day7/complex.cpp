#include <iostream>
using namespace std;

class Complex
{
private:
    float real, img;
    static int activeObjCount;

public:
    Complex()
    {
        cout << "Default Constructor Called" << endl;
        real = 0;
        img = 0;
        activeObjCount++;
    }
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

int main()
{
    Complex c1(5.0f, 7.0f);
    Complex c2(-3.0f, -3.0f);
    Complex c3(0.0f, -8.0f);
    cout << "Active Complex Objects: " << Complex::getNoOfActiveObj() << endl;
    Complex c4(0.0f, 8.0f);
    Complex c5(0.0f, -9.0f);
    Complex c6(-9.0f, 3.0f);
    Complex c7(8.0f, 1.0f);
    Complex c8(0.0f, 0.0f);
    cout << "Active Complex Objects: " << Complex::getNoOfActiveObj() << endl;
    c1.display();
    c2.display();
    c3.display();
    c4.display();
    c5.display();
    c6.display();
    c7.display();
    c8.display();

    c6.~Complex();
    c7.~Complex();
    cout << "Active Complex Objects: " << Complex::getNoOfActiveObj() << endl;
}
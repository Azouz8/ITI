#include <iostream>
using namespace std;

int main()
{
    cout << "Enter Ur Grade: ";
    int grade;
    cin >> grade;
    if (grade >= 85)
    {
        if (grade > 100)
        {
            cout << "Extreme Grade\n";
        }
        else
        {
            cout << "Grade: A\n";
        }
    }
    else if (grade >= 75)
    {
        cout << "Grade: B\n";
    }

    else if (grade >= 65)
    {
        cout << "Grade: C\n";
    }
    else if (grade >= 60)
    {
        cout << "Grade: D\n";
    }
    else
    {
        cout << "Grade: F\n";
    }
}
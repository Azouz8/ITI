#include <iostream>
#include <array>
using namespace std;

struct emp
{
    int id;
    string name;
    int age;
    int salary;
};

int main()
{
    int n;
    cout << "Enter the Number of Employees: ";
    cin >> n;
    array<emp, 100> employees;
    for (int i = 0; i < n; i++)
    {
        cout << "\033[" << i * 4 + 3 << ";0H" << "Emp" << i + 1 << endl;
        cout << "\033[" << i * 4 + 4 << ";5H" << "ID: " << endl;
        cout << "\033[" << i * 4 + 4 << ";30H" << "Name: " << endl;
        cout << "\033[" << i * 4 + 5 << ";5H" << "Age: " << endl;
        cout << "\033[" << i * 4 + 5 << ";30H" << "Salary: " << endl;
    }
    for (int i = 0; i < n; i++)
    {
        cout << "\033[" << i * 4 + 4 << ";5H" << "ID: ";
        cin >> employees.at(i).id;
        cout << "\033[" << i * 4 + 4 << ";30H" << "Name: ";
        cin >> employees.at(i).name;
        cout << "\033[" << i * 4 + 5 << ";5H" << "Age: ";
        cin >> employees.at(i).age;
        cout << "\033[" << i * 4 + 5 << ";30H" << "Salary: ";
        cin >> employees.at(i).salary;
    }
    system("cls");
    cout << "\033[1;0H" << "Entered Data" << endl;
    for (int i = 0; i < n; i++)
    {
        cout << "\033[" << i * 4 + 2 << ";0H" << "Emp" << i + 1 << endl;
        cout << "\033[" << i * 4 + 3 << ";5H" << "ID: " << employees.at(i).id << endl;
        cout << "\033[" << i * 4 + 3 << ";30H" << "Name: " << employees.at(i).name << endl;
        cout << "\033[" << i * 4 + 4 << ";5H" << "Age: " << employees.at(i).age << endl;
        cout << "\033[" << i * 4 + 4 << ";30H" << "Salary: " << employees.at(i).salary << endl;
    }
    int x;
    cin >> x;
}
#include <iostream>
#include <array>
using namespace std;

struct Employee
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
    Employee *employees = new Employee[n];
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
        cin >> (employees + i)->id;
        cout << "\033[" << i * 4 + 4 << ";30H" << "Name: ";
        cin >> (employees + i)->name;
        cout << "\033[" << i * 4 + 5 << ";5H" << "Age: ";
        cin >> (employees + i)->age;
        cout << "\033[" << i * 4 + 5 << ";30H" << "Salary: ";
        cin >> (employees + i)->salary;
    }
    system("cls");
    cout << "\033[1;0H" << "Entered Data" << endl;
    for (int i = 0; i < n; i++)
    {
        cout << "\033[" << i * 4 + 2 << ";0H" << "Emp" << i + 1 << endl;
        cout << "\033[" << i * 4 + 3 << ";5H" << "ID: " << (employees + i)->id << endl;
        cout << "\033[" << i * 4 + 3 << ";30H" << "Name: " << (employees + i)->name << endl;
        cout << "\033[" << i * 4 + 4 << ";5H" << "Age: " << (employees + i)->age << endl;
        cout << "\033[" << i * 4 + 4 << ";30H" << "Salary: " << (employees + i)->salary << endl;
    }
    int x;
    cin >> x;
}
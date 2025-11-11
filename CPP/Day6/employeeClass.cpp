#include <iostream>
using namespace std;

class Employee
{
public:
    int id, age, salary;
    string name;
};

int main()
{
    Employee e1;
    e1.name = "Ali";
    e1.age = 23;
    e1.id = 1;
    e1.salary = 200000;
    cout << "ID: " << e1.id << endl;
    cout << "Name: " << e1.name << endl;
    cout << "Age: " << e1.age << endl;
    cout << "Salary: " << e1.salary << endl;
}
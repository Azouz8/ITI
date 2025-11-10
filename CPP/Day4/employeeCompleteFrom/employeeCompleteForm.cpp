#include <iostream>
#include <conio.h>
#include <array>
using namespace std;

void startForm();
void addNumOfEmp(int &n);
void takeNoOfEmp(int &n);
void printAllEmp(int n);
void displayFormOptions();
int takeKeyboardInput();
void handlePressedKey(int key);
void handlePressedOption();
void takeEmpIndex(int &n);
void printEmpAt(int n);
void addEmpAtIndex(int &index);
void getEmpIndexInput(int &n);

array<string, 5> options = {"New", "New at", "Display", "Display all", "Exit"};
int current = 0, exitFlag = 0, optionChoosed = 0, noOfEmp, empIndex, empInsertionIndex, operationDone = 0;

struct Employee
{
    int id;
    string name;
    int age;
    int salary;
};

array<Employee, 100> employees;
void startForm()
{
    optionChoosed = 0;

    while (!optionChoosed && !exitFlag)
    {
        displayFormOptions();
        handlePressedKey(takeKeyboardInput());
    }
}
void addEmpAtIndex(int &index)
{
    system("cls");
    cout << "\033[1;0H" << "Emp" << index << endl;
    cout << "\033[2;5H" << "ID: ";
    cout << "\033[2;30H" << "Name: ";
    cout << "\033[3;5H" << "Age: ";
    cout << "\033[3;30H" << "Salary: ";
    /////////////////////////////////////
    cout << "\033[2;5H" << "ID: ";
    cin >> employees.at(index).id;
    cout << "\033[2;30H" << "Name: ";
    cin >> employees.at(index).name;
    cout << "\033[3;5H" << "Age: ";
    cin >> employees.at(index).age;
    cout << "\033[3;30H" << "Salary: ";
    cin >> employees.at(index).salary;
    operationDone = 1;
    system("cls");
    cout << "Employee added Successfully!";
}
void getEmpIndexInput(int &n)
{
    system("cls");
    cout << "Enter the Index: ";
    cin >> n;
    addEmpAtIndex(n);
}
void addNumOfEmp(int &n)
{
    system("cls");
    for (int i = 0; i < n; i++)
    {
        cout << "\033[" << i * 4 + 1 << ";0H" << "Emp" << i + 1 << endl;
        cout << "\033[" << i * 4 + 2 << ";5H" << "ID: " << endl;
        cout << "\033[" << i * 4 + 2 << ";30H" << "Name: " << endl;
        cout << "\033[" << i * 4 + 3 << ";5H" << "Age: " << endl;
        cout << "\033[" << i * 4 + 3 << ";30H" << "Salary: " << endl;
    }
    for (int i = 0; i < n; i++)
    {
        cout << "\033[" << i * 4 + 2 << ";5H" << "ID: ";
        cin >> employees.at(i).id;
        cout << "\033[" << i * 4 + 2 << ";30H" << "Name: ";
        cin >> employees.at(i).name;
        cout << "\033[" << i * 4 + 3 << ";5H" << "Age: ";
        cin >> employees.at(i).age;
        cout << "\033[" << i * 4 + 3 << ";30H" << "Salary: ";
        cin >> employees.at(i).salary;
    }
    operationDone = 1;
    system("cls");
    cout << "Employees added Successfully!";
}
void takeNoOfEmp(int &n)
{
    system("cls");
    cout << "Enter the Number of Employees: ";
    cin >> n;
    addNumOfEmp(n);
}
void takeEmpIndex(int &n)
{
    system("cls");
    cout << "Enter the Employees Index: ";
    cin >> n;
    printEmpAt(n);
}

void printAllEmp(int n)
{
    system("cls");
    if (n < 100 && employees.at(0).id > 0)
    {
        cout << "             All Employees" << endl;
        for (int i = 0; i < n; i++)
        {
            cout << "\033[" << i * 4 + 2 << ";0H" << "Emp No. " << i + 1 << endl;
            cout << "\033[" << i * 4 + 3 << ";5H" << "ID: " << employees.at(i).id << endl;
            cout << "\033[" << i * 4 + 3 << ";30H" << "Name: " << employees.at(i).name << endl;
            cout << "\033[" << i * 4 + 4 << ";5H" << "Age: " << employees.at(i).age << endl;
            cout << "\033[" << i * 4 + 4 << ";30H" << "Salary: " << employees.at(i).salary << endl;
        }
    }
    else
    {
        cout << "\033[0;0H" << "There is no Employees yet!" << endl;
    }
    cout << "\n\nPress any key to return to the menu...";
    _getch();
}
void printEmpAt(int n)
{
    system("cls");
    if (employees.at(n).id > 0)
    {
        cout << "            Employees" << endl;
        cout << "\033[" << 3 << ";0H" << "Emp No. " << n + 1 << endl;
        cout << "\033[" << 4 << ";5H" << "ID: " << employees.at(n).id << endl;
        cout << "\033[" << 4 << ";30H" << "Name: " << employees.at(n).name << endl;
        cout << "\033[" << 5 << ";5H" << "Age: " << employees.at(n).age << endl;
        cout << "\033[" << 5 << ";30H" << "Salary: " << employees.at(n).salary << endl;
    }
    else
    {
        cout << "\033[0;0H" << "There is no Employees at this index yet!" << endl;
    }
    cout << "\n\nPress any key to return to the menu...";
    _getch();
}

void displayFormOptions()
{
    system("cls");
    cout << "\033[1;15H" << "Employee Form\n";

    for (int i = 0; i < options.size(); i++)
    {
        if (i == current)
        {
            cout << "\033[31m" << options.at(i) << "\033[0m" << endl;
        }
        else
        {

            cout << options.at(i) << endl;
        }
    }
}

int takeKeyboardInput()
{
    int key = _getch();
    return key;
}
void handlePressedKey(int key)
{
    if (key == 27)
    {
        cout << "Exiting...\n";
        exitFlag = 1;
    }
    else if (key == 72)
    {
        if (current > 0)
        {
            current--;
        }
    }
    else if (key == 80)
    {
        if (current < 4)
        {
            current++;
        }
    }
    else if (key == 13)
    {
        optionChoosed = 1;
    }
}

void handlePressedOption()
{

    switch (current)
    {
    case 0:
        takeNoOfEmp(noOfEmp);
        operationDone = 1;
        break;
    case 1:
        getEmpIndexInput(empInsertionIndex);
        operationDone = 1;
        break;

    case 2:
        takeEmpIndex(empIndex);
        break;

    case 3:
        printAllEmp(noOfEmp);
        operationDone = 1;
        break;

    case 4:
    {
        cout << "Exiting....\n";
        exitFlag = 1;
        break;
    }

    default:
        break;
    }
}

int main()
{
    cout << "Press arrow keys (ESC to exit):\n";
    while (!exitFlag)
    {
        optionChoosed = 0;
        operationDone = 0;
        startForm();
        handlePressedOption();
    }
}

#include <iostream>
using namespace std;

class Employee
{
public:
    int id, age, salary;
    string name;
    Employee(int id = 0, int age = 0, int salary = 0, string name = "")
    {
        this->id = id;
        this->age = age;
        this->salary = salary;
        this->name = name;
    }
};

class Node
{
public:
    Employee emp;
    Node *next, *prev;

    Node(Employee e)
    {
        emp = e;
        next = nullptr;
        prev = nullptr;
    }
};

class SortedEmpLinkedList
{
    Node *head, *tail;

public:
    SortedEmpLinkedList()
    {
        head = nullptr;
        tail = nullptr;
    }
    SortedEmpLinkedList(const SortedEmpLinkedList &other)
    {
        head = tail = nullptr;
        Node *current = other.head;
        while (current)
        {
            Node *newNode = new Node(current->emp);
            if (!head)
            {
                head = tail = newNode;
            }
            else
            {
                tail->next = newNode;
                newNode->prev = tail;
                tail = newNode;
            }
            current = current->next;
        }
    }
    void insertEmployee(Employee e)
    {
        Node *newNode = new Node(e);
        if (!head) // emptyList
        {
            head = tail = newNode;
            return;
        }
        if (e.id < head->emp.id) // must be a head
        {
            newNode->next = head;
            head->prev = newNode;
            head = newNode;
            return;
        }
        Node *current = head;
        while (current && current->emp.id < e.id)
        {
            current = current->next;
        }
        if (!current) // must be a tail
        {
            tail->next = newNode;
            newNode->prev = tail;
            tail = newNode;
        } 
        else // between 2 nodes
        {
            newNode->next = current;
            newNode->prev = current->prev;
            current->prev->next = newNode;
            current->prev = newNode;
        }
    }
    bool deleteNode(int id)
    {
        Node *current = head;
        while (current)
        {
            if (current->emp.id == id)
            {
                if (current->prev) // not head
                {
                    current->prev->next = current->next;
                }
                else //head
                {
                    current->next->prev = nullptr;
                    head = current->next;
                }
                if (current->next) // not tail
                {
                    current->next->prev = current->prev;
                }
                else // tail
                {
                    current->prev->next = nullptr;
                    tail = current->prev;
                }
                delete current;
                return true;
            }
            current = current->next;
        }
        return false;
    }
    Node searchEmployee(int id)
    {
        Node *current = head;
        while (current)
        {
            if (current->emp.id == id)
            {
                return *current;
            }
            current = current->next;
        }
        throw runtime_error("Employee not found");
    }
    void DisplayEmpById(int id)
    {
        Node *current = head;
        while (current)
        {
            if (current->emp.id == id)
            {
                cout << "ID: " << current->emp.id << ", Name: " << current->emp.name
                     << ", Age: " << current->emp.age << ", Salary: " << current->emp.salary << endl;
                return;
            }
            current = current->next;
        }
        cout << "Employee with ID " << id << " not found." << endl;
    }
    void displayAllEmp()
    {
        Node *current = head;
        while (current)
        {
            cout << "ID: " << current->emp.id << ", Name: " << current->emp.name
                 << ", Age: " << current->emp.age << ", Salary: " << current->emp.salary << endl;
            current = current->next;
        }
    }
};

int main()
{
    Employee e1(1, 30, 1111, "Ali");
    Employee e2(2, 28, 2222, "Ahmed");
    Employee e3(3, 35, 3333, "Mohamed");

    SortedEmpLinkedList empList;
    empList.insertEmployee(e1);
    empList.insertEmployee(e2);
    empList.insertEmployee(e3);

    cout << "Enter Employee ID to Display: ";
    int id;
    cin >> id;
    empList.DisplayEmpById(id);
    cout << "-------------------------------" << endl;
    cout << "Enter Employee ID to Delete: " << endl;
    cin >> id;
    if (empList.deleteNode(id))
    {
        cout << "Employee deleted successfully." << endl;
    }
    else
    {
        cout << "Employee not found." << endl;
    }
    cout << "-------------------------------" << endl;
    cout << "All Employees:" << endl;
    empList.displayAllEmp();

    SortedEmpLinkedList empList2 = empList;
    cout << "-------------------------------" << endl;
    cout << "All Employees from Copy ctr:" << endl;
    empList2.displayAllEmp();
}
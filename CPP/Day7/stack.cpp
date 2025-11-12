#include <iostream>
using namespace std;
class Stack
{
private:
    int top;
    static int countOfObjectCreated;
    int size;
    int *data;

public:
    Stack()
    {
        size = 10;
        countOfObjectCreated++;
        top = 0;
        data = new int[size];
    }
    Stack(int size)
    {
        this->size = size;
        countOfObjectCreated++;
        top = 0;
        data = new int[size];
    }
    static int getNoOfObjectsCreated()
    {
        return countOfObjectCreated;
    }
    void showElements()
    {
        for (int i = top - 1; i >= 0; i--)
        {
            cout << data[i] << " ";
        }
        cout << endl;
    }
    void push(int *e)
    {
        if (top == size)
            cout << "Stack is full";
        data[top] = *e;
        top++;
    }
    int pop()
    {
        if (top <= 0)
        {
            cout << "Empty stack" << endl;
            return 0;
        }
        top--;
        return data[top];
    }
    ~Stack()
    {
        delete[] data;
    }
};

int Stack::countOfObjectCreated = 0;

int main()
{
    Stack s1 = Stack(10);
    Stack s2 = Stack();
    int a = 10, b = 20, c = 30, d = 40;
    s1.push(&a);
    s1.push(&b);
    s2.push(&c);
    s2.push(&d);
    cout << "Stack 1 elements: ";
    s1.showElements();
    cout << "Stack 2 elements: ";
    s2.showElements();
    cout << "Stack 1 elements after pop: " << s1.pop() << endl;
    s1.showElements();
    cout << "Stack 2 elements after pop: " << s2.pop() << endl;
    cout << "Stack 2 elements after pop: " << s2.pop() << endl;
    cout << "Stack 2 elements after pop: " << s2.pop() << endl;
    cout << "Stack 2 elements after pop: " << s2.pop() << endl;
    s2.showElements();
    cout << "Number of objects created: " << Stack::getNoOfObjectsCreated() << endl;
    return 0;
}
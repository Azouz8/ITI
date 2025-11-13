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
    // Stack()
    // {
    //     size = 10;
    //     countOfObjectCreated++;
    //     top = 0;
    //     data = new int[size];
    // }
    Stack(int size = 5)
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
    Stack(Stack &obj)
    {
        this->size = obj.size;
        this->top = obj.top;
        this->data = new int[size];
        for (int i = 0; i < top; i++)
        {
            this->data[i] = obj.data[i];
        }
        countOfObjectCreated++;
        cout << "Copy Constructor Called" << endl;
    }
    Stack(Stack &&obj)
    {
        this->size = obj.size;
        this->top = obj.top;
        this->data = new int[size];
        for (int i = 0; i < top; i++)
        {
            this->data[i] = obj.data[i];
        }
        obj.data = nullptr;
        obj.top = 0;
        obj.size = 0;
        cout << "Move Constructor Called" << endl;
    }
    Stack operator=(Stack &obj)
    {
        this->size = obj.size;
        this->top = obj.top;
        this->data = new int[size];
        for (int i = 0; i < top; i++)
        {
            this->data[i] = obj.data[i];
        }
        return *this;
    }
    Stack operator=(Stack &&obj)
    {
        this->size = obj.size;
        this->top = obj.top;
        this->data = new int[size];
        for (int i = 0; i < top; i++)
        {
            this->data[i] = obj.data[i];
        }
        return *this;
        obj.data = nullptr;
        obj.top = 0;
        obj.size = 0;
    }
    int operator[](int index) const
    {
        if (index < 0 || index >= top)
        {
            cout << "Index out of range" << endl;
        }
        return data[index];
    }
    ~Stack()
    {
        delete[] data;
    }
};

int Stack::countOfObjectCreated = 0;

int main()
{
    Stack s2();
    Stack s1(10);
    int a = 10, b = 20, c = 30, d = 40;
    s1.push(&a);
    s1.push(&b);
    cout << "Element at index 1: " << s1[1] << endl;
    cout << "Stack 1 elements: ";
    s1.showElements();
    cout << "Stack 1 elements after pop: " << s1.pop() << endl;
    s1.showElements();
    cout << "Number of objects created: " << Stack::getNoOfObjectsCreated() << endl;
    Stack s3(s1);
    cout << "Stack 3 elements: ";
    s3.showElements();
    return 0;
}
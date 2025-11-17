#include <iostream>
using namespace std;

template <class T>
class Stack
{
private:
    int top;
    int size;
    T* data;
    static int countOfObjectCreated;

public:

    Stack(int size = 5)
        : size(size), top(0)
    {
        data = new T[size];
        countOfObjectCreated++;
        cout << "Default Constructor Called\n";
    }

    Stack(const Stack& other)
        : size(other.size), top(other.top)
    {
        data = new T[size];
        for (int i = 0; i < top; i++)
            data[i] = other.data[i];

        countOfObjectCreated++;
        cout << "Copy Constructor Called\n";
    }

    Stack(Stack&& other)
        : size(other.size), top(other.top), data(other.data)
    {
        other.data = nullptr;
        other.size = 0;
        other.top = 0;
        countOfObjectCreated++;
        cout << "Move Constructor Called\n";
    }

    Stack& operator=(const Stack& other)
    {
        if (this == &other)
            return *this;

        delete[] data;

        size = other.size;
        top = other.top;

        data = new T[size];
        for (int i = 0; i < top; i++)
            data[i] = other.data[i];

        return *this;
    }

    Stack& operator=(Stack&& other)
    {
        if (this == &other)
            return *this;

        delete[] data;

        size = other.size;
        top = other.top;
        data = other.data;

        other.data = nullptr;
        other.size = 0;
        other.top = 0;

        return *this;
    }

    void push(const T& element)
    {
        if (top == size)
        {
            cout << "Stack is full\n";
            return;
        }
        data[top++] = element;
    }

    T pop()
    {
        if (top <= 0)
        {
            cout << "Empty stack\n";
            return T();
        }
        return data[--top];
    }

    void showElements() const
    {
        for (int i = top - 1; i >= 0; i--)
            cout << data[i] << " ";
        cout << endl;
    }

    T operator[](int index) const
    {
        if (index < 0 || index >= top)
        {
            cout << "Index out of range\n";
            return T();
        }
        return data[index];
    }

    static int getNoOfObjectsCreated()
    {
        return countOfObjectCreated;
    }

    ~Stack()
    {
        delete[] data;
    }
};

template <class T>
int Stack<T>::countOfObjectCreated = 0;

int main()
{
    Stack<int> s1(10);

    s1.push(10);
    s1.push(20);
    s1.push(30);

    cout << "Element at index 1: " << s1[1] << endl;
    cout << "Stack elements: ";
    s1.showElements();
    
    cout << "Popped: " << s1.pop() << endl;
    s1.showElements();
    cout << "Number of int-Stacks created: "
    << Stack<int>::getNoOfObjectsCreated() << endl;
    Stack<int> s2 = s1;
    Stack<int> s3 = move(s1);
    
    cout << "Stack s2: ";
    s2.showElements();
    cout << "Stack s3: ";
    s3.showElements();
    
    Stack<string> s4;
    s4.push("Ali");
    s4.push("Azouz");
    cout << "Stack 4 elements: ";
    s4.showElements();
    
    return 0;
}

#include <iostream>
using namespace std;

struct Node
{
    int value;
    Node *next;
};
class LinkedList
{
public:
    Node *head, *tail;
    LinkedList()
    {
        head = tail = nullptr;
    }
    virtual void push(int value) {}
    virtual Node pop() {}
    virtual Node peek() {}
};

class Stack : public LinkedList
{

public:
    Stack() : LinkedList() {}
    void push(int value) override
    {
        Node *newNode = new Node();
        newNode->value = value;
        newNode->next = head;
        head = newNode;
    }
    Node pop() override
    {
        if (head == nullptr)
        {
            cout << "Empty Stack" << endl;
            exit(0);
        }
        Node poppedNode = *head;
        Node *temp = head;
        head = head->next;
        delete temp;
        return poppedNode;
    }
    Node peek() override
    {
        if (head == nullptr)
        {
            cout << "Empty Stack" << endl;
            exit(0);
        }
        return *head;
    }
};
class Queue : public LinkedList
{
public:
    Queue() : LinkedList() {}
    void push(int value)
    {
        Node *newNode = new Node();
        newNode->value = value;
        newNode->next = nullptr;
        if (tail == nullptr)
        {
            head = tail = newNode;
            return;
        }
        tail->next = newNode;
        tail = newNode;
    }
    Node pop()
    {
        if (head == nullptr)
        {
            cout << "Empty Queue" << endl;
            exit(0);
        }
        Node dequeuedNode = *head;
        Node *temp = head;
        head = head->next;
        if (head == nullptr)
        {
            tail = nullptr;
        }
        delete temp;
        return dequeuedNode;
    }
    Node peek()
    {
        if (head == nullptr)
        {
            cout << "Empty Queue" << endl;
            exit(0);
        }
        return *head;
    }
};

int main()
{
    Stack s;
    s.push(10);
    s.push(20);
    s.push(30);
    cout << "Top element is: " << s.peek().value << endl;
    cout << "Popped element is: " << s.pop().value << endl;
    cout << "Top element is: " << s.peek().value << endl;

    Queue q;
    q.push(10);
    q.push(20);
    q.push(30);
    cout << "Front element is: " << q.peek().value << endl;
    cout << "Dequeued element is: " << q.pop().value << endl;
    cout << "Front element is: " << q.peek().value << endl;
}

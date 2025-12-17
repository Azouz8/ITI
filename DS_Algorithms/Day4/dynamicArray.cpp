#include <iostream>
using namespace std;

template <typename T>
class DynamicArray
{
    T *arr;
    int capacity;
    int size;
    static const int spareCapacity = 4;

public:
    explicit DynamicArray(int initSize = 10)
        : size(0), capacity(initSize + spareCapacity)
    {
        arr = new int[capacity + spareCapacity];
    }
    ~DynamicArray()
    {
        delete[] arr;
    }
    DynamicArray(const DynamicArray &other)
        : size(other.size), capacity(other.capacity)
    {
        arr = new int[capacity];
        for (int i = 0; i < size; i++)
            arr[i] = other.arr[i];
    }
    int getSize()
    {
        return size;
    }
    int getCapacity()
    {
        return capacity;
    }
    int &operator[](int index)
    {
        return arr[index];
    }
    void push_back(T value)
    {
        if (size == capacity)
        {
            capacity *= 2;
            T *newArr = new T[capacity];
            for (int i = 0; i < size; i++)
                newArr[i] = arr[i];
            delete[] arr;
            arr = newArr;
        }
        arr[size++] = value;
    }
    void pop_back()
    {
        if (size > 0)
            size--;
    }
    void remove(T value)
    {
        for (int i = 0; i < size; i++)
        {
            if (arr[i] == value)
            {
                for (int j = i; j < size - 1; j++)
                {
                    arr[j] = arr[j + 1];
                }
                size--;
                break;
            }
        }
    }
    void removeAt(int index)
    {
        if (index < 0 || index >= size)
            return;
        for (int i = index; i < size - 1; i++)
        {
            arr[i] = arr[i + 1];
        }
        size--;
    }
};

int main()
{
    DynamicArray<int> dynArr;
    dynArr.push_back(10);
    dynArr.push_back(20);
    dynArr.push_back(30);
    dynArr.push_back(40);

    cout << "Array elements: ";
    for (int i = 0; i < dynArr.getSize(); i++)
        cout << dynArr[i] << " ";
    cout << endl;

    cout << "Array size: " << dynArr.getSize() << endl;
    cout << "Array capacity: " << dynArr.getCapacity() << endl;

    dynArr.remove(30);
    cout << "Array elements: ";
    for (int i = 0; i < dynArr.getSize(); i++)
        cout << dynArr[i] << " ";
    cout << endl;

    dynArr.removeAt(2);
    cout << "Array elements: ";
    for (int i = 0; i < dynArr.getSize(); i++)
        cout << dynArr[i] << " ";
    cout << endl;
}

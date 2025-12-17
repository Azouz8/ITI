#include <iostream>
#include <vector>
using namespace std;

template <typename T>
class BinaryHeap
{
    int currentSize;
    vector<T> heap;

public:
    explicit BinaryHeap(int capacity = 100)
        : heap(capacity + 1), currentSize(0) {}

    T &operator[](int index)
    {
        return heap[index];
    }
    void printHeap()
    {
        for (int i = 1; i <= currentSize; i++)
            cout << heap[i] << " ";
        cout << endl;
    }
    bool isEmpty() const
    {
        return currentSize == 0;
    }
    T &findMin()
    {
        return heap[1];
    }
    void insert(const T &value)
    {
        if (currentSize >= heap.size() - 1)
            heap.resize(heap.size() * 2);

        int hole = ++currentSize;
        heap[hole] = value;
        heapifyUp(hole);
    }
    T deleteMin()
    {
        if (isEmpty())
            return T();

        T minItem = heap[1];
        heap[1] = heap[currentSize--];
        heapifyDown(1);
        return minItem;
    }
    void heapifyUp(int index)
    {
        while (index > 0)
        {
            int parent = index / 2;
            if (heap[index] < heap[parent])
            {
                swap(heap[index], heap[parent]);
                index = parent;
            }
            else
                break;
        }
    }

    void heapifyDown(int index)
    {
        int size = heap.size();
        while (index < size)
        {
            int leftChild = 2 * index;
            int rightChild = 2 * index + 1;
            int largest = index;

            if (leftChild <= currentSize && heap[leftChild] < heap[largest])
                largest = leftChild;
            if (rightChild <= currentSize && heap[rightChild] < heap[largest])
                largest = rightChild;

            if (largest != index)
            {
                swap(heap[index], heap[largest]);
                index = largest;
            }
            else
                break;
        }
    }
};

int main()
{
    BinaryHeap<int> bh;
    bh.insert(10);
    // 10
    bh.insert(5);
    //  5
    // 10
    bh.insert(20);
    //    5
    // 10   20
    bh.insert(3);
    //     3
    //   5   20
    // 10
    bh.printHeap();

    cout << "Minimum: " << bh.findMin() << endl;

    bh.deleteMin();
    bh.printHeap();
    cout << "Heap[2]: " << bh[2] << endl;
}
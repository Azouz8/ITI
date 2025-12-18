#include <iostream>
#include <list>
#include <vector>
#include <functional>
#include <algorithm>
#include <queue>
using namespace std;

template <class KeyType, class ValueType>
class MapEntry
{
    KeyType key;
    ValueType value;

public:
    MapEntry(const KeyType &k, const ValueType &v) : key(k), value(v) {}
    KeyType getKey() const
    {
        return key;
    }
    ValueType getValue() const
    {
        return value;
    }
};

template <class KeyType, class ValueType>
class HashMap
{
    int currentSize;
    vector<list<MapEntry<KeyType, ValueType>>> table;

public:
    explicit HashMap(int size = 101) : table(size), currentSize(0)
    {
        table.resize(size > 0 ? size : 11);
    }

    bool isExist(const KeyType &key) const
    {
        int listIndex = myHashFn(key);
        const list<MapEntry<KeyType, ValueType>> &bucket = table[listIndex];
        for (const auto &itr : bucket)
        {
            if (itr.getKey() == key)
            {
                return true;
            }
        }
        return false;
    }
    bool insert(const KeyType &key, const ValueType &value)
    {
        if (isExist(key))
            return false;
        int listIndex = myHashFn(key);
        table[listIndex].push_back(MapEntry<KeyType, ValueType>(key, value));
        currentSize++;
        return true;
    }
    bool remove(const KeyType &key)
    {
        int listIndex = myHashFn(key);
        list<MapEntry<KeyType, ValueType>> &bucket = table[listIndex];
        for (auto itr = bucket.begin(); itr != bucket.end(); itr++)
        {
            if (itr->getKey() == key)
            {
                bucket.erase(itr);
                currentSize--;
                return true;
            }
        }
        return false;
    }

    void clearMap()
    {
        for (auto &bucket : table)
            bucket.clear();
        currentSize = 0;
    }
    void rehash()
    {
        vector<list<MapEntry<KeyType, ValueType>>> oldTable = table;
        table.assign(oldTable.size() * 2, list<MapEntry<KeyType, ValueType>>());
        currentSize = 0;
        for (const auto &bucket : oldTable)
        {
            for (const auto &item : bucket)
            {
                insert(item.getKey(), item.getValue());
            }
        }
    }

    ValueType lookUp(const KeyType &key) const
    {
        int listIndex = myHashFn(key);
        const list<MapEntry<KeyType, ValueType>> &bucket = table[listIndex];
        for (const auto &item : bucket)
        {
            if (item.getKey() == key)
            {
                return item.getValue();
            }
        }
        throw runtime_error("Key not found");
    }

protected:
    int myHashFn(const KeyType &key) const
    {
        hash<KeyType> hashFn;
        return hashFn(key) % table.size();
    }
};

int main()
{
    HashMap<string, int> students(5);

    students.insert("Ali", 95);
    students.insert("Ahmed", 88);
    students.insert("Mohamed", 72);
    students.insert("Sayed", 91);

    if (students.isExist("Ali"))
    {
        cout << "Ali's Grade: " << students.lookUp("Ali") << endl;
    }

    cout << "----------------------------" << endl;
    bool inserted = students.insert("Ali", 100);
    if (!inserted)
    {
        cout << "Connot Insert Duplicate Key" << endl;
    }
    cout << "----------------------------" << endl;
    students.remove("Ahmed");
    if (!students.isExist("Ahmed"))
    {
        cout << "Ahmed was removed" << endl;
    }

    try
    {
        int grade = students.lookUp("Salma");
        cout << "Salma's Grade: " << grade << endl;
    }
    catch (const runtime_error &e)
    {
        cout << e.what() << endl;
    }

    return 0;
}
#include <iostream>
using namespace std;

int main()
{
    string s;
    cin >> s;
    string sNew = "";
    for (int i = 0; i < s.length(); i++)
    {
        bool exist = false;
        for (int j = 0; j < i; j++)
        {
            if (s[i] == s[j])
            {
                exist = true;
            }
        }
        if (!exist)
        {
            sNew += s[i];
        }
    }
    if (sNew.length() % 2 == 0)
    {
        cout << "CHAT WITH HER!";
    }
    else
    {
        cout << "IGNORE HIM!";
    }
}
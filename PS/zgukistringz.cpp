#include <iostream>
using namespace std;

int main()
{
    string a, b, c;
    cin >> a >> b >> c;
    bool flag = true;
    string s = "";
    for (int i = 0; i < c.length(); i++)
    {
        for (int j = 0; j < a.length(); j++)
        {
            if (c[i] != a[j] && j == a.length() - 1)
            {
                flag = false;
                break;
            }
            if (c[i] == a[j])
            {
                flag = true;
                break;
            }
            flag = false;
        }
        if (!flag)
            break;
    }
    if (flag)
    {
        s += c;

        for (int i = 0; i < c.length(); i++)
        {
            for (int j = 0; j < a.length(); j++)
            {
                if (c[i] == a[j])
                {
                    // a = a.substr(0, i + 1) + a.substr(i+2 , )
                    
                        // break;
                }
                flag = false;
            }
        }
    }
    for (int i = 0; i < b.length(); i++)
    {
        for (int j = 0; j < a.length(); j++)
        {
            if (b[i] != a[j] && j == a.length() - 1)
            {
                flag = false;
                break;
            }
            if (b[i] == a[j])
            {
                flag = true;
                break;
            }
            flag = false;
        }
        if (!flag)
            break;
    }
    if (flag)
    {
        s += b;
    }
    cout << s;
    for (int i = 0; i < s.length(); i++)
    {
    }
}
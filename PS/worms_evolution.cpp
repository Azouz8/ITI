#include <iostream>
using namespace std;

int main()
{
    int t;
    cin >> t;
    int arr[t];
    for (int i = 0; i < t; i++)
    {
        cin >> arr[i];
    }
    bool found = false;
    for (int k = 0; k < t; k++)
    {
        for (int i = 0; i < t; i++)
        {
            for (int j = 0; j < t && i != j; j++)
            {
                if (arr[i] + arr[j] == arr[k])
                {
                    found = true;
                    cout << k + 1 << " " << j + 1 << " " << i + 1;
                    return 0;
                }
            }
          
        }
       
    }
    if (!found)
    {
        cout << -1;
    }
}
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
    int maxR = 0;
    for (int i = 0; i < t; i++)
    {
        int tempR = 0;
        for (int j = i + 1; j < t; j++)
        {
            if (arr[i] == arr[j])
            {
                tempR++;
            }
        }
        if(tempR > maxR){
            maxR = tempR;
        }
    }
    cout<<maxR+1;
}
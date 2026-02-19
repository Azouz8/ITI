#include <iostream>
#include <vector>
using namespace std;

int main()
{
    int n, m;
    cin >> n >> m;
    vector<int> city, cel;
    for (int i = 0; i < n+m; i++)
    {
        cin >> city[i];
    }
    // for (int i = 0; i < m; i++)
    // {
    //     cin >> cel[i];
    // }
    
    // int minimal = 0;
    // for (int i = 0; i < n; i++)
    // {
    //     // int tempMini = INT32_MAX;
    //     // for (int j = 0; j < m; j++)
    //     // {
    //     //     if (abs(city[i] - cel[j]) < tempMini)
    //     //     {
    //     //         tempMini = abs(city[i] - cel[j]);
    //     //     }
    //     // }
    //     // if (tempMini > minimal)
    //     // {
    //     //     minimal = tempMini;
    //     // }

    //     int tempMini = INT32_MAX;
    //     if (i > 0)
    //     {
    //         if (i < m)
    //         {
    //             tempMini = min(abs(city[i] - cel[i - 1]), abs(city[i] - cel[i]));
    //             tempMini = min(tempMini, abs(city[i] - cel[i + 1]));
    //         }
    //         else
    //         {
    //             tempMini = min(tempMini, abs(city[i] - cel[m - 1]));
    //         }
    //         if (tempMini > minimal)
    //         {
    //             minimal = tempMini;
    //         }
    //     }
    //     else
    //     {
    //         tempMini = min(abs(city[i] - cel[i]), abs(city[i] - cel[i + 1]));

    //         if (tempMini > minimal)
    //         {
    //             minimal = tempMini;
    //         }
    //     }
    // }
    // cout << minimal;
}
#include <iostream>
using namespace std;

int main(){
    int arr[5][5];
    int row,col;
    for(int i=0;i<5;i++){
        for(int j=0; j<5; j++){
            cin>>arr[i][j];
            if(arr[i][j] == 1){
                row=i;
                col=j;
            }
        }
    }
    int p = abs(row-2)+abs(col-2);
    cout<<p;
}
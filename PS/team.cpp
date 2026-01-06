#include <iostream>
using namespace std;
 
 
int main() {
 
  int n;
  cin>>n;
  int x,y,z;
  int count=0;
  for(int i=0;i<n;i++){
    cin>>x>>y>>z;
    int sum= x+y+z;
    if(sum>=2){
        count++;
    }
  }
  cout<<count;
}
#include <iostream>
#include <conio.h>
#include <array>
using namespace std;

int main()
{
    cout << "Press arrow keys (ESC to exit):\n";
    int current = 0;
    while (true)
    {
        cout << "\033[3;15H" << "Employee Form\n";
        array<string, 4> options = {"New", "Display", "Display all", "Exit"};
        for (int i = 0; i < options.size(); i++)
        {
            if (i == current)
            {
                cout << "\033[31m" << options.at(i) << "\033[0m" << endl;
            }
            else
            {

                cout << options.at(i) << endl;
            }
        }
        int key = _getch();
        if (key == 27)
        {
            cout << "Exiting...\n";
            break;
        }
        else if (key == 72)
        {
            if (current > 0)
            {
                current--;
            }
        }
        else if (key == 80)
        {
            if (current < 3)
            {
                current++;
            }
        }
        else if (key == 13)
        {
            if (current == 3)
            {
                cout << "Exiting...\n";
                return 0;
            }
            system("cls");
            cout << "Option pressed is:" << options.at(current) << endl;
            int x;
            cin>>x;
            return 0;
        }
    }
}
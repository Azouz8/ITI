#include <iostream>
#include <string>
#include <vector>
#include <conio.h>
using namespace std;

int main()
{
    vector<string> lines;
    int currentLine = 1;
    int cursor = 1;
    int textSize = 0;
    string text = "";
    while (true)
    {
        for (int i = 0; i < lines.size(); i++)
        {
            cout << "\033[" << i + 1 << ";" << 1 << "H" << lines[i];
        }
        cout << "\033[" << currentLine << ";" << cursor << "H";
        int key = _getch();
        if (key == 27)
        {
            cout << "Exiting...\n";
            break;
        }
        else if (key == 71)
        {
            cursor = 1;
            cout << "\033[" << currentLine << ";" << cursor << "H";
        }
        else if (key == 79)
        {
            cursor = textSize + 1;
            cout << "\033[3;15H";
            cout << "\033[" << currentLine << ";" << cursor << "H";
        }
        else if (key == 72)
        {
            if (currentLine > 0)
                currentLine--;
        }
        else if (key == 80)
        {
            if (currentLine <= lines.size())
                currentLine++;
        }
        else if (key >= 33 && key <= 126)
        {
            text += static_cast<char>(key);
            cout << "\033[" << currentLine << ";" << 1 << "H" << text;
            textSize++;
            cursor++;
        }
        else if (key == 13)
        {
            currentLine++;
            lines.push_back(text);
            text = "";
            textSize = 0;
            cursor = 1;
            system("cls");
        }
    }
}
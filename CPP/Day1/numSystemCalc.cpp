#include <iostream>

int main()
{
    int DNum;
    std::cout << "Enter UR Num: " << std::endl;
    std::cin >> DNum;
    std::cout << "HEX: ";
    std::cout << std::hex << DNum << std::endl;
    std::cout << "OCT: ";
    std::cout << std::oct << DNum << std::endl;
}
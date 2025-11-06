#include <iostream>

int main()
{
    int n1, n2;
    std::cout << "Enter first Num: " << std::endl;
    std::cin >> n1;
    std::cout << "Enter second Num: " << std::endl;
    std::cin >> n2;
    std::cout << "Sum = " << n1 + n2 << std::endl;
    std::cout << "Diff = " << n1 - n2 << std::endl;
    std::cout << "Average = " << (n1 + n2) / 2.0 << std::endl;
}
#include <iostream>
#include "../StaticLib1/Vector.h"

int main()
{
    // Конструктор без параметрів
    Vector v1;

    // Конструктор з параметрами
    Vector v2(5, 3.14159 / 4);

    // Конструктор копіювання
    Vector v3(v2);

    std::cout << "Вектор v2:" << std::endl;
    std::cout << "r = " << v2.getR() << std::endl;
    std::cout << "кут = " << v2.getAngle() << std::endl;
    std::cout << "X = " << v2.getX() << std::endl;
    std::cout << "Y = " << v2.getY() << std::endl;

    return 0;
}
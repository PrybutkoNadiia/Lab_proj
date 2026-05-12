#include <iostream>
#include "Rectangle.h"
#include "Circle.h"
#include "Shape.h"

// Створення методу за межами класів для демонстрації поліморфізму
void printResult(Shape* figure) {
    // Виклик віртуальних методів через вказівник базового класу
    std::cout << "Area: " << figure->getArea() << std::endl;
    std::cout << "Perimeter: " << figure->getPerimeter() << std::endl;
    std::cout << "-----------------------" << std::endl;
}

int main() {
    // Створення об'єктів класів
    Rectangle rect(0, 0, 5, 4);
    Circle circ(3);

    // Виклик методу для різних об'єктів (поліморфізм)
    printResult(&rect);
    printResult(&circ);

    return 0;
}
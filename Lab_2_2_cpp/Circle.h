#pragma once

#include "Shape.h"

// Створення класу Коло
class Circle : public Shape {
private:
    double radius; // Дані класу

public:
    // Конструктор класу Коло
    Circle(double r);

    // Оголошення методів обчислення
    double getArea() const override;
    double getPerimeter() const override;
};

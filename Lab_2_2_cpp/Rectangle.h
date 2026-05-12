#pragma once

#include "Shape.h"

// Створення класу Прямокутник
class Rectangle : public Shape {
private:
    double x1, y1, x2, y2; // Дані класу

public:
    // Конструктор класу Прямокутник
    Rectangle(double x1, double y1, double x2, double y2);

    // Оголошення методів обчислення
    double getArea() const override;
    double getPerimeter() const override;
};

#include "Rectangle.h"
#include <cmath>

// Реалізація конструктора
Rectangle::Rectangle(double x1, double y1, double x2, double y2)
    : x1(x1), y1(y1), x2(x2), y2(y2) {
}

// Реалізація обчислення площі
double Rectangle::getArea() const {
    return std::abs(x2 - x1) * std::abs(y2 - y1);
}

// Реалізація обчислення периметра
double Rectangle::getPerimeter() const {
    return 2 * (std::abs(x2 - x1) + std::abs(y2 - y1));
}
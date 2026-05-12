#include "Circle.h"
#include <cmath>

// Реалізація конструктора
Circle::Circle(double r) : radius(r) {}

// Реалізація обчислення площі
double Circle::getArea() const {
    return 3.14159 * radius * radius;
}

// Реалізація обчислення периметра
double Circle::getPerimeter() const {
    return 2 * 3.14159 * radius;
}
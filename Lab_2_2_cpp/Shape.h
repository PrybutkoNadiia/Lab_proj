#pragma once

// Створення базового класу Фігури
class Shape {
public:
    // Віртуальні функції для обчислення площі та периметра
    virtual double getArea() const = 0;
    virtual double getPerimeter() const = 0;

    // Віртуальний деструктор для коректного видалення об'єктів
    virtual ~Shape() {}
};
#ifndef VECTOR_H 
#define VECTOR_H 

#include <string>

class Vector { // Створення класу Vector для представлення вектора у полярних координатах
private:
    double length;          // Довжина вектора
    double angleInDegrees;  // Кут у градусах

public:
    // Конструктор
    Vector(double l, double a); 

    // Методи обчислення
    double calculateX() const;
    double calculateY() const;

    // Метод для отримання опису об'єкта
    std::string getPolarData() const;
};

#endif
